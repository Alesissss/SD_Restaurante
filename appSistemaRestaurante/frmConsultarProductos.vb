Imports libNegocio
Public Class frmConsultarProductos

    Dim objProd As New clsProducto()
    Public frmTransaccion As frmTransaPedido

    Private Sub listarProductos()
        Dim dtProducto As New DataTable
        Dim ind As Integer = 0
        Try
            dgvProducto.DataSource = objProd.listarProductos()

            With dgvProducto
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "Nombre"
                .Columns(2).HeaderText = "Descripción"
                .Columns(3).HeaderText = "Precio"
                .Columns(4).HeaderText = "Tipo"
                .Columns(5).HeaderText = "Carta"
                .Columns(6).HeaderText = "Vigente"
            End With
        Catch ex As Exception
            MessageBox.Show("Error al listar productos: " & ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarProductos()
    End Sub

    Private Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducto.CellClick
        If e.RowIndex >= 0 Then ' Asegurarse de que no es la fila de cabecera
            Dim fila As DataGridViewRow = dgvProducto.Rows(e.RowIndex)

            Dim nombreProducto As String
            Dim idProducto As Integer
            Dim precio As Single
            Dim idCartaProducto As String
            Try
                nombreProducto = Convert.ToString(fila.Cells("nombre").Value)
                idProducto = Convert.ToInt32(fila.Cells("idProducto").Value)
                precio = Convert.ToSingle(fila.Cells("precio").Value)
                idCartaProducto = Convert.ToString(fila.Cells("carta").Value)
            Catch exConvert As FormatException
                MessageBox.Show("Error al convertir los datos del producto. Verifique que los valores sean correctos." & vbCrLf & exConvert.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Catch exNull As NullReferenceException
                MessageBox.Show("Uno de los valores esperados del producto es nulo." & vbCrLf & exNull.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Catch ex As Exception
                MessageBox.Show("Error al obtener datos del producto: " & ex.Message & vbCrLf & "Asegúrese de que los nombres de columna 'idProducto', 'nombre', 'precio', 'carta' coincidan con su origen de datos.", "Error de Acceso a Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try

            Dim cantidadStr As String = InputBox($"¿Cuántos '{nombreProducto}' desea pedir?", "Cantidad de Producto")

            If Not String.IsNullOrEmpty(cantidadStr) AndAlso IsNumeric(cantidadStr) Then
                Dim cantidad As Integer = CInt(cantidadStr)
                If cantidad > 0 Then
                    frmTransaccion.AgregarDetalle(idProducto, nombreProducto, precio, cantidad, idCartaProducto)

                    Me.Close()
                Else
                    MessageBox.Show("La cantidad debe ser mayor a cero.", "Cantidad Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            ElseIf Not String.IsNullOrEmpty(cantidadStr) Then
                MessageBox.Show("Ingrese una cantidad numérica válida.", "Entrada Inválida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
End Class