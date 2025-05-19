Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports libDatos

Public Class clsPedido
    Private strSQL As String = ""
    Private objCliente As New clsCliente()
    Private objMesero As New clsMesero()
    Private objMesa As New clsMesa()
    Dim objMan As New clsMantenimiento()
    Dim dtPedido As New DataTable
    Public Function generarIDPedido() As Integer
        strSQL = "SELECT ISNULL(MAX(idPedido), 0) + 1 FROM PEDIDO"
        Try
            dtPedido = objMan.listarComando(strSQL)
            If dtPedido.Rows.Count > 0 Then
                Return Convert.ToInt32(dtPedido.Rows(0).Item(0))
            End If
        Catch ex As Exception
            Throw New Exception("Error al generar el ID de Pedido: " & ex.Message)
        End Try
        Return 0
    End Function
    Public Function calcularMonto(dgvDetalles As DataGridView) As Decimal
        Dim montoTotal As Single = 0
        For Each row As DataGridViewRow In dgvDetalles.Rows
            If Not row.IsNewRow Then
                montoTotal += Convert.ToSingle(row.Cells("Precio").Value) * Convert.ToInt32(row.Cells("Cantidad").Value)
            End If
        Next
        Return montoTotal
    End Function

    Public Function VerificarPedido(idPedido As Integer) As Boolean
        strSQL = "SELECT COUNT(*) FROM PEDIDO WHERE idPedido = @idPedido"
        Try
            Dim parametros As New Dictionary(Of String, Object) From {
                {"@idPedido", idPedido}
            }
            Dim dt As DataTable = objMan.listarComando(strSQL, parametros)
            If dt.Rows.Count > 0 Then
                Return Convert.ToInt32(dt.Rows(0).Item(0)) > 0
            End If
        Catch ex As Exception
            Throw New Exception("Error al verificar mesero: " & ex.Message)
        End Try
        Return False
    End Function

    Public Sub RegistrarPedidoTransaccional(idPedido As Integer, idCliente As Integer, idMesero As Integer, idMesa As Integer, dgvDetalles As DataGridView)
        If Not objCliente.VerificarCliente(idCliente) Then Throw New Exception("El cliente no existe.")
        If Not objMesero.VerificarMesero(idMesero) Then Throw New Exception("El mesero no existe.")
        If Not objMesa.VerificarMesa(idMesa) Then Throw New Exception("La mesa no existe o no se encuentra disponible.")


        Using conn As New SqlConnection("Data Source=(local);Initial Catalog=BD_RESTAURANTE;User ID=sa;Password=zien1219;")
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Dim montoTotal = 0
            montoTotal = calcularMonto(dgvDetalles)
            Try
                ' Insertar Pedido
                strSQL = "INSERT INTO PEDIDO (idPedido, fecha, monto, estadoPedido, estadoPago, idCliente, idMesero, idMesa) 
                      VALUES (@idPedido, GETDATE(), @monto, '1', '1', @idCliente, @idMesero, @idMesa)"
                Using cmdPedido As New SqlCommand(strSQL, conn, transaction)
                    cmdPedido.Parameters.AddWithValue("@idPedido", idPedido)
                    cmdPedido.Parameters.AddWithValue("@monto", montoTotal)
                    cmdPedido.Parameters.AddWithValue("@idCliente", idCliente)
                    cmdPedido.Parameters.AddWithValue("@idMesero", idMesero)
                    cmdPedido.Parameters.AddWithValue("@idMesa", idMesa)
                    cmdPedido.ExecuteNonQuery()
                End Using

                ' Insertar Detalles
                strSQL = "INSERT INTO DETALLE_PEDIDO (idProducto, idPedido, cantidad, precioVenta) 
                      VALUES (@idProducto, @idPedido, @cantidad, @precioVenta)"
                For Each row As DataGridViewRow In dgvDetalles.Rows
                    If Not row.IsNewRow Then
                        Using cmdDetalle As New SqlCommand(strSQL, conn, transaction)
                            cmdDetalle.Parameters.AddWithValue("@idProducto", Convert.ToInt32(row.Cells("idProducto").Value))
                            cmdDetalle.Parameters.AddWithValue("@idPedido", idPedido)
                            cmdDetalle.Parameters.AddWithValue("@cantidad", Convert.ToInt32(row.Cells("Cantidad").Value))
                            cmdDetalle.Parameters.AddWithValue("@precioVenta", Convert.ToSingle(row.Cells("Precio").Value))
                            cmdDetalle.ExecuteNonQuery()
                        End Using
                    End If
                Next

                ' Cambiar estado de la mesa
                strSQL = "UPDATE MESA SET estado = 0 WHERE idMesa = @idMesa"
                Using cmdUpdateMesa As New SqlCommand(strSQL, conn, transaction)
                    cmdUpdateMesa.Parameters.AddWithValue("@idMesa", idMesa)
                    cmdUpdateMesa.ExecuteNonQuery()
                End Using

                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                Throw New Exception("Error al registrar pedido (se revirtió la transacción): " & ex.Message)
            End Try
        End Using
    End Sub
    Public Function listarPedidosVigentes() As DataTable
        strSQL = "SELECT idPedido, fecha, monto, estadoPedido, estadoPago, idMesero, (select numero from mesa where idMesa = ped.idMesa) as numeroMesa from pedido ped WHERE estadoPedido = 1"
        Try
            Return objMan.listarComando(strSQL)
        Catch ex As Exception
            Throw New Exception("Error al listar los pedidos vigentes: " & ex.Message)
        End Try
    End Function
    Public Sub PagarPedidoTransaccional(idPedido As Integer, idCajero As Integer, idCliente As Integer)
        If Not objCliente.VerificarCliente(idPedido) Then Throw New Exception("El pedido no existe.")
        If Not objMesa.VerificarMesa(idCajero) Then Throw New Exception("El cajero no existe.")
        If Not objMesa.VerificarMesa(idCliente) Then Throw New Exception("El cliente no existe.")

        Using conn As New SqlConnection("Data Source=(local);Initial Catalog=BD_RESTAURANTE;User ID=sa;Password=zien1219;")
            conn.Open()
            Dim transaction As SqlTransaction = conn.BeginTransaction()
            Try
                ' Insertar Pedido
                strSQL = "UPDATE PEDIDO estadoPedido = 0, estadoPago = 0, idCliente = @idCliente, idCajero = @idCajero WHERE idPedido = @idPedido"
                Using cmdPedido As New SqlCommand(strSQL, conn, transaction)
                    cmdPedido.Parameters.AddWithValue("@idPedido", idPedido)
                    cmdPedido.Parameters.AddWithValue("@idCliente", idCliente)
                    cmdPedido.Parameters.AddWithValue("@idCajero", idCajero)
                    cmdPedido.ExecuteNonQuery()
                End Using

                ' Liberar mesa
                strSQL = "UPDATE MESA set estado = 1 WHERE idMesa = (select idMesa from pedido where idPedido = @idPedido)"
                Using cmdMesa As New SqlCommand(strSQL, conn, transaction)
                    cmdMesa.Parameters.AddWithValue("@idPedido", idPedido)
                    cmdMesa.ExecuteNonQuery()
                End Using

                transaction.Commit()
            Catch ex As Exception
                transaction.Rollback()
                Throw New Exception("Error al pagar pedido (se revirtió la transacción): " & ex.Message)
            End Try
        End Using
    End Sub

End Class