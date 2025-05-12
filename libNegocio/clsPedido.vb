Imports libDatos
Imports System.Windows.Forms

Public Class clsPedido
    Private objMan As New clsMantenimiento()
    Private strSQL As String = ""
    Private dtPedido As New DataTable()
    Private objCliente As New clsCliente()
    Private objMesero As New clsMesero()
    Private objMesa As New clsMesa()

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

    Public Sub InsertarPedido(idPedido As Integer, idCliente As Integer, idMesero As Integer, idMesa As Integer, monto As Single)
        strSQL = "INSERT INTO PEDIDO (idPedido, fecha, monto, estadoPedido, estadoPago, idCliente, idMesero, idMesa) 
                  VALUES (@idPedido, GETDATE(), @monto, 'Pendiente', 'Pendiente', @idCliente, @idMesero, @idMesa)"
        Try
            Dim parametros As New Dictionary(Of String, Object) From {
                {"@idPedido", idPedido},
                {"@monto", monto},
                {"@idCliente", idCliente},
                {"@idMesero", idMesero},
                {"@idMesa", idMesa}
            }
            objMan.ejecutarComando(strSQL, parametros)
        Catch ex As Exception
            Throw New Exception("Error al insertar el pedido: " & ex.Message)
        End Try
    End Sub


    Public Sub InsertarDetallePedido(idPedido As Integer, idProducto As Integer, cantidad As Integer, precioVenta As Single)
        strSQL = "INSERT INTO DETALLE_PEDIDO (idProducto, idPedido, cantidad, precioVenta) 
                  VALUES (@idProducto, @idPedido, @cantidad, @precioVenta)"
        Try
            Dim parametros As New Dictionary(Of String, Object) From {
                {"@idProducto", idProducto},
                {"@idPedido", idPedido},
                {"@cantidad", cantidad},
                {"@precioVenta", precioVenta}
            }
            objMan.ejecutarComando(strSQL, parametros)
        Catch ex As Exception
            Throw New Exception("Error al insertar detalle de pedido: " & ex.Message)
        End Try
    End Sub


    Public Sub RegistrarPedido(idPedido As Integer, idCliente As Integer, idMesero As Integer, idMesa As Integer, dgvDetalles As DataGridView)
        ' Verificar existencia de cliente, mesero y mesa
        If Not objCliente.VerificarCliente(idCliente) Then
            Throw New Exception("El cliente no existe.")
        End If

        If Not objMesero.VerificarMesero(idMesero) Then
            Throw New Exception("El mesero no existe.")
        End If

        If Not objMesa.VerificarMesa(idMesa) Then
            Throw New Exception("La mesa no existe.")
        End If

        ' Calcular el monto total del pedido
        Dim montoTotal As Single = 0
        For Each row As DataGridViewRow In dgvDetalles.Rows
            If Not row.IsNewRow Then
                Dim precio As Single = Convert.ToSingle(row.Cells("Precio").Value)
                Dim cantidad As Integer = Convert.ToInt32(row.Cells("Cantidad").Value)
                montoTotal += precio * cantidad
            End If
        Next

        ' Insertar el pedido en la base de datos
        InsertarPedido(idPedido, idCliente, idMesero, idMesa, montoTotal)

        ' Insertar los detalles del pedido
        For Each row As DataGridViewRow In dgvDetalles.Rows
            If Not row.IsNewRow Then
                Dim idProducto As Integer = Convert.ToInt32(row.Cells("idProducto").Value)
                Dim cantidad As Integer = Convert.ToInt32(row.Cells("Cantidad").Value)
                Dim precioVenta As Single = Convert.ToSingle(row.Cells("Precio").Value)

                InsertarDetallePedido(idPedido, idProducto, cantidad, precioVenta)
            End If
        Next
    End Sub

End Class
