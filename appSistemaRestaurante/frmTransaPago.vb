Imports libNegocio

Public Class frmTransaPago
    Dim objCajero As New clsCajero
    Dim objPedido As New clsPedido
    Private Sub frmTransaPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub btnConsultarCajero_Click(sender As Object, e As EventArgs) Handles btnConsultarCajero.Click
        Using formularioListado As New frmConsultarCajero()
            formularioListado.FormularioPadre = Me
            formularioListado.ShowDialog()
        End Using
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Using formularioListado As New frmConsultarPedidosVigentes()
            formularioListado.FormularioPadre = Me
            formularioListado.ShowDialog()
        End Using
    End Sub
    Private Sub btnBuscarMesero_Click(sender As Object, e As EventArgs) Handles btnBuscarMesero.Click
        Using formularioListado As New frmConsultarClientes()
            formularioListado.FormularioPadre = Me
            formularioListado.ShowDialog()
        End Using
    End Sub
    Private Sub btnRegistrarPedido_Click(sender As Object, e As EventArgs) Handles btnRegistrarPedido.Click
        Try
            ' Suponiendo que el DataGridView tiene la información del pedido
            Dim idPedido As Integer = Convert.ToInt32(txtIDPedido.Text)
            Dim idCliente As Integer = Convert.ToInt32(txtCodCli.Text)
            Dim idCajero As Integer = Convert.ToInt32(txtIDCajero.Text)

            ' Llamamos al método de la capa lógica
            objPedido.PagarPedidoTransaccional(idPedido, idCajero, idCliente)

            ' Mensaje de éxito
            limpiar()
            MessageBox.Show("Pedido pagado correctamente.")
        Catch ex As Exception
            ' Mensaje de error
            MessageBox.Show("Error al pagar el pedido " & ex.Message)
        End Try
    End Sub
    Private Sub limpiar()
        txtIDCajero.Text = ""
        txtIDPedido.Text = ""
        txtTotalPed.Text = ""
        lblEstado.Text = ""
        txtCodCli.Text = ""
        txtNomCli.Text = ""
        txtDNICli.Text = ""

    End Sub
End Class