Imports libNegocio
Public Class frmConsultarProductos

    Dim objProd As New clsProducto()
    Public frmTransaccion As frmTransaPedido
    Private Sub listarProductos()
        Dim dtProducto As New DataTable
        Dim ind As Integer = 0
        Try
            ' Llenar el DataGridView con los productos

            dgvProducto.DataSource = objProd.listarProductos()
            With dgvProducto
                .Columns(0).HeaderText = "ID"
                .Columns(1).HeaderText = "Nombre"
                .Columns(2).HeaderText = "Descripción"
                .Columns(3).HeaderText = "Precio"
                .Columns(4).HeaderText = "Vigente"
                .Columns(5).HeaderText = "Tipo"
            End With
        Catch ex As Exception
            MessageBox.Show("Error al listar productos: " & ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarProductos()
    End Sub

    Private Sub dgvProducto_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvProducto.CellClick
        If e.RowIndex >= 0 Then
            Dim fila As DataGridViewRow = dgvProducto.Rows(e.RowIndex)
            Dim nombreProducto As String = fila.Cells("nombre").Value.ToString()

            Dim cantidadStr As String = InputBox($"¿Cuántos '{nombreProducto}' desea pedir?", "Cantidad de Producto")

            If IsNumeric(cantidadStr) AndAlso CInt(cantidadStr) > 0 Then
                Dim cantidad As Integer = CInt(cantidadStr)
                Dim idProducto As Integer = CInt(fila.Cells("idProducto").Value)
                Dim descripcion As String = fila.Cells("descripcion").Value.ToString()
                Dim precio As Single = CSng(fila.Cells("precio").Value)
                frmTransaccion.montoTotal = frmTransaccion.montoTotal + Decimal.Parse(cantidad * precio)

                ' Llamar al método del otro formulario
                frmTransaccion.AgregarDetalle(idProducto, nombreProducto, descripcion, cantidad, precio)
                frmTransaccion.txtMonto.Text = frmTransaccion.montoTotal

                Me.Close() ' Opcional: cerrar luego de seleccionar el producto
            Else
                MessageBox.Show("Ingrese una cantidad válida.")
            End If
        End If
    End Sub

End Class