Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports libNegocio
Public Class frmTransaPedido
    Public montoTotal As Decimal = 0
    Dim objPedido As New clsPedido
    Dim objMesa As New clsMesa
    Dim objMesero As New clsMesero
    Dim dtMesa As New DataTable
    Dim dtMesero As New DataTable
    Private Sub limpiar()
        cargarDatos()
        txtCapMesa.Text = ""
        txtCodProducto.Text = ""
        txtDNIMesero.Text = ""
        txtMonto.Text = ""
        txtNomMesero.Text = ""
        txtNomProducto.Text = ""
        txtNumMesa.Text = ""
        txtNumMesero.Text = ""
        dgvDetalles.Rows.Clear()


    End Sub
    Private Sub deshabilitarMesa()
        txtCapMesa.Enabled = False
    End Sub
    Private Sub deshabilitarMesero()
        txtNomMesero.Enabled = False
        txtDNIMesero.Enabled = False
    End Sub
    Private Sub deshabilitarProducto()
        txtNomMesero.Enabled = False
        txtDNIMesero.Enabled = False
    End Sub
    Private Sub cargarDatos()
        dtpFecha.Value = DateTime.Now
        dtpFecha.Enabled = False
        txtMonto.Enabled = False
        txtNumPedido.Text = objPedido.generarIDPedido()
        txtNumPedido.Enabled = False

    End Sub
    Private Sub frmTransaPedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cargarDatos()
        deshabilitarMesa()
        deshabilitarMesero()
        deshabilitarProducto()

        dgvDetalles.AutoGenerateColumns = False
        dgvDetalles.Columns.Clear()

        ' Columnas deseadas: idProducto, nombre, precio (unitario), cantidad, idCarta, y un total por ítem
        dgvDetalles.Columns.Add("idProducto", "ID Producto")
        dgvDetalles.Columns.Add("nombre", "Nombre Producto")
        dgvDetalles.Columns.Add("precio", "Precio Unit.") ' Precio unitario del producto
        dgvDetalles.Columns.Add("cantidad", "Cantidad")
        dgvDetalles.Columns.Add("idCarta", "ID Carta")   ' ID de la carta a la que pertenece el producto
        dgvDetalles.Columns.Add("totalItem", "Total Ítem") ' Columna para el total (Cantidad * Precio Unit.)

        ' Aplicar formato y alineación a las columnas según sea necesario
        dgvDetalles.Columns("precio").DefaultCellStyle.Format = "N2"
        dgvDetalles.Columns("totalItem").DefaultCellStyle.Format = "N2"
        dgvDetalles.Columns("cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalles.Columns("precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalles.Columns("totalItem").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvDetalles.Columns("idCarta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight ' o Left, según preferencia

        dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvDetalles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells
        dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvDetalles.MultiSelect = False
    End Sub

    Private Sub btnBuscarMesero_Click(sender As Object, e As EventArgs) Handles btnBuscarMesero.Click
        Try
            If txtNumMesero.TextLength > 0 Then
                dtMesero = objMesero.buscarMesero(CInt(txtNumMesero.Text))
                If dtMesero.Rows.Count > 0 Then
                    txtDNIMesero.Text = dtMesero.Rows(0).Item(1)
                    txtNomMesero.Text = dtMesero.Rows(0).Item(2) & " " & dtMesero.Rows(0).Item(3)
                Else
                    MessageBox.Show("Este mesero no se encuentra disponible!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Mesero a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub bthRegistrarPedido_Click(sender As Object, e As EventArgs) Handles btnRegistrarPedido.Click
        Try
            ' Suponiendo que el DataGridView tiene la información del pedido
            Dim idPedido As Integer = Convert.ToInt32(txtNumPedido.Text)
            Dim idCliente As Integer = Convert.ToInt32(1)
            Dim idMesero As Integer = Convert.ToInt32(txtNumMesero.Text)
            Dim idMesa As Integer = Convert.ToInt32(txtNumMesa.Text)

            ' Llamamos al método de la capa lógica
            objPedido.RegistrarPedidoTransaccional(idPedido, idCliente, idMesero, idMesa, dgvDetalles)

            ' Mensaje de éxito
            limpiar()
            MessageBox.Show("Pedido registrado correctamente.")
        Catch ex As Exception
            ' Mensaje de error
            MessageBox.Show("Error al registrar el pedido " & ex.Message)
        End Try
    End Sub

    Private Sub btnConsultarProducto_Click(sender As Object, e As EventArgs) Handles btnConsultarProducto.Click
        Dim fProd As New frmConsultarProductos()
        fProd.frmTransaccion = Me ' Pasar la instancia actual de frmTransaPedido

        fProd.ShowDialog()
    End Sub

    ' Nueva firma del método AgregarDetalle
    Public Sub AgregarDetalle(idProducto As Integer, nombre As String, precioUnitario As Single, cantidad As Integer, idCarta As Integer)
        Dim productoYaExiste As Boolean = False
        Dim valorAdicional As Decimal = Convert.ToDecimal(cantidad * precioUnitario) ' Valor de los productos que se están agregando AHORA

        ' Iterar sobre las filas existentes en dgvDetalles para buscar el producto
        For Each fila As DataGridViewRow In dgvDetalles.Rows
            ' Omitir la fila para nuevos registros si está visible (AllowUserToAddRows = True)
            If fila.IsNewRow Then Continue For

            ' Asegurarse que la celda "idProducto" no es Nothing antes de convertir
            If fila.Cells("idProducto").Value IsNot Nothing AndAlso Convert.ToInt32(fila.Cells("idProducto").Value) = idProducto Then
                ' Producto encontrado, actualizar la cantidad y el total del ítem para esa fila
                Dim cantidadExistente As Integer = Convert.ToInt32(fila.Cells("cantidad").Value)
                Dim nuevaCantidad As Integer = cantidadExistente + cantidad
                Dim nuevoTotalItemFila As Decimal = Convert.ToDecimal(nuevaCantidad * precioUnitario)

                fila.Cells("cantidad").Value = nuevaCantidad
                fila.Cells("totalItem").Value = nuevoTotalItemFila

                productoYaExiste = True
                Exit For ' Salir del bucle una vez que el producto es encontrado y actualizado
            End If
        Next

        ' Si el producto no fue encontrado en el DataGridView, añadirlo como una nueva fila
        If Not productoYaExiste Then
            ' El valorAdicional es el totalItem para la nueva fila
            dgvDetalles.Rows.Add(idProducto, nombre, precioUnitario, cantidad, idCarta, valorAdicional)
        End If

        ' Actualizar el monto total del pedido.
        ' Esto suma el valor de los productos recién agregados o el incremento de cantidad de un producto existente.
        Me.montoTotal += valorAdicional
        Me.txtMonto.Text = Me.montoTotal.ToString("N2")
    End Sub
    Private Sub dgvDetalles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalles.CellClick
        If e.RowIndex >= 0 AndAlso e.RowIndex < dgvDetalles.Rows.Count - If(dgvDetalles.AllowUserToAddRows, 1, 0) Then
            Dim fila As DataGridViewRow = dgvDetalles.Rows(e.RowIndex)
            txtCodProducto.Text = If(fila.Cells("idProducto").Value IsNot Nothing, fila.Cells("idProducto").Value.ToString(), "")
            txtNomProducto.Text = If(fila.Cells("nombre").Value IsNot Nothing, fila.Cells("nombre").Value.ToString(), "")
            ' Si tenías un TextBox para descripción, puedes limpiarlo o quitarlo.
        Else
            txtCodProducto.Text = ""
            txtNomProducto.Text = ""
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If dgvDetalles.SelectedRows.Count > 0 Then
            Dim filaSeleccionada As DataGridViewRow = dgvDetalles.SelectedRows(0)

            If filaSeleccionada.IsNewRow Then
                MessageBox.Show("No se puede eliminar la fila de nuevos registros.", "Operación no Válida", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim valorTotalItemFila As Object = filaSeleccionada.Cells("totalItem").Value ' Usar el nombre de la columna de total
            Dim totalItemFilaEliminada As Decimal = 0D

            If valorTotalItemFila IsNot Nothing AndAlso Decimal.TryParse(valorTotalItemFila.ToString(), totalItemFilaEliminada) Then
                Me.montoTotal -= totalItemFilaEliminada
                Me.txtMonto.Text = Me.montoTotal.ToString("N2")
            End If

            dgvDetalles.Rows.Remove(filaSeleccionada)

            ' Limpiar campos de texto si el producto eliminado era el que se mostraba
            If txtCodProducto.Text = If(filaSeleccionada.Cells("idProducto").Value IsNot Nothing, filaSeleccionada.Cells("idProducto").Value.ToString(), "") Then
                txtCodProducto.Text = ""
                txtNomProducto.Text = ""
            End If

            If dgvDetalles.Rows.Count = 0 Or (dgvDetalles.Rows.Count = 1 And dgvDetalles.Rows(0).IsNewRow) Then
                Me.montoTotal = 0D
                Me.txtMonto.Text = "0.00"
            End If
        Else
            MessageBox.Show("Seleccione un producto de la lista para eliminar.", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Using formularioListado As New frmListadoMesas()
            formularioListado.FormularioPadre = Me
            formularioListado.ShowDialog()
        End Using
    End Sub
End Class