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
        chkEstadoMesa.Enabled = False
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

        ' Columnas necesarias para insertar en BD
        dgvDetalles.Columns.Add("idProducto", "ID Producto")
        dgvDetalles.Columns.Add("nombre", "Nombre")
        dgvDetalles.Columns.Add("descripcion", "Descripcion")
        dgvDetalles.Columns.Add("cantidad", "Cantidad")
        dgvDetalles.Columns.Add("precio", "Precio")
        dgvDetalles.Columns.Add("total", "Total")
        dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill  ' Ajusta el ancho de las columnas.
        dgvDetalles.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells

        ' Columnas solo visuales (opcional, para el usuario)
        'dgvDetalles.Columns.Add("nombre", "Nombre Producto") ' Solo visual
    End Sub


    Private Sub btnBuscarMesa_Click(sender As Object, e As EventArgs) Handles btnBuscarMesa.Click
        Try
            If txtNumMesa.TextLength > 0 Then
                dtMesa = objMesa.buscarMesa(CInt(txtNumMesa.Text))
                If dtMesa.Rows.Count > 0 Then
                    txtCapMesa.Text = dtMesa.Rows(0).Item(1)
                    chkEstadoMesa.Checked = dtMesa.Rows(0).Item(2)
                Else
                    MessageBox.Show("Esta mesa no se encuentra disponible!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Mesa a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
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

    Public Sub AgregarDetalle(idProducto As Integer, nombre As String, descripcion As String, cantidad As Integer, precio As Single)
        Dim total As Single = cantidad * precio
        dgvDetalles.Rows.Add(idProducto, nombre, descripcion, cantidad, precio, total)
    End Sub

    Private Sub dgvDetalles_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalles.CellContentClick

    End Sub
    Private Sub dgvDetalles_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalles.CellClick
        If e.RowIndex >= 0 Then ' Asegura que no se esté haciendo clic en el encabezado
            Dim fila As DataGridViewRow = dgvDetalles.Rows(e.RowIndex)
            txtCodProducto.Text = fila.Cells("idProducto").Value.ToString()
            txtNomProducto.Text = fila.Cells("nombre").Value.ToString()
        End If
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtCodProducto.Text = "" Then
            MessageBox.Show("Seleccione un producto para eliminar.", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim idAEliminar As String = txtCodProducto.Text
        For Each fila As DataGridViewRow In dgvDetalles.Rows
            If fila.Cells("idProducto").Value.ToString() = idAEliminar Then
                dgvDetalles.Rows.Remove(fila)
                Exit For ' Salir después de encontrar y eliminar
            End If
        Next

        ' Limpiar los campos
        txtMonto.Text = objPedido.calcularMonto(dgvDetalles)
        txtCodProducto.Text = ""
        txtNomProducto.Text = ""
    End Sub
End Class