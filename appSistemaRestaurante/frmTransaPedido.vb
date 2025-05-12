Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports libNegocio
Public Class frmTransaPedido
    Dim objPedido As New clsPedido
    Dim objMesa As New clsMesa
    Dim objMesero As New clsMesero
    Dim dtMesa As New DataTable
    Dim dtMesero As New DataTable


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
        txtNumMesa.Text = objPedido.generarIDPedido()
        txtNumMesa.Enabled = False

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
        dgvDetalles.Columns.Add("cantidad", "Cantidad")
        dgvDetalles.Columns.Add("precioVenta", "Precio Venta")

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
                    MessageBox.Show("Id de Mesa no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
                    MessageBox.Show("Id de Mesero no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
            objPedido.RegistrarPedido(idPedido, idCliente, idMesero, idMesa, dgvDetalles)

            ' Mensaje de éxito
            MessageBox.Show("Pedido registrado correctamente.")
        Catch ex As Exception
            ' Mensaje de error
            MessageBox.Show("Error al registrar el pedido: " & ex.Message)
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

End Class