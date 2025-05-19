Imports libNegocio

Public Class frmMDIPrincipal
    Dim objFrmInicio As New frmInicioSesion
    Private Sub frmMDIPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        inicioSesion()
        lblFecha.Text = DateString
        lblHora.Text = TimeString
    End Sub

    Private Sub IniciarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IniciarSesiónToolStripMenuItem.Click, ToolStripButton1.Click
        inicioSesion()
    End Sub

    Private Sub inicioSesion()
        objFrmInicio = New frmInicioSesion
        Dim objUsuario As New clsUsuario
        objFrmInicio.ShowDialog()
        Try
            If objFrmInicio.estadoInicio Then
                'Con acceso
                lblUsuario.Text = objFrmInicio.usuario
                lblUsuario.Text &= " / " & objUsuario.obtenerNombreUsuario(objFrmInicio.usuario)
            Else
                'Acceso denegado
                Me.Close()
            End If
        Catch ex As Exception

        End Try


    End Sub

    Private Sub tmrTiempo_Tick(sender As Object, e As EventArgs) Handles tmrTiempo.Tick
        lblHora.Text = TimeString
    End Sub

    Private Sub ClientesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClientesToolStripMenuItem.Click
        Dim objFrmCliente As New frmCliente
        objFrmCliente.ShowDialog()
    End Sub
    Private Sub MeseroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeseroToolStripMenuItem.Click
        Dim objFrmMesero As New frmMesero
        objFrmMesero.ShowDialog()
    End Sub

    Private Sub MesasToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MesasToolStripMenuItem.Click
        Dim objFrmMesa As New frmMesa
        objFrmMesa.ShowDialog()
    End Sub

    Private Sub CajeroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CaejeroToolStripMenuItem.Click
        Dim objFrmCajero As New frmCajero
        objFrmCajero.ShowDialog()
    End Sub

    Private Sub TipoProductoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoProductoToolStripMenuItem.Click
        Dim objFrmTipoProducto As New frmTipoProducto
        objFrmTipoProducto.ShowDialog()
    End Sub

    Private Sub TipoUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TipoUsuarioToolStripMenuItem.Click
        Dim objFrmTipoUsuario As New frmTipoUsuario
        objFrmTipoUsuario.ShowDialog()
    End Sub

    Private Sub UsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UsuarioToolStripMenuItem.Click
        Dim objFrmUsuario As New frmUsuario
        objFrmUsuario.ShowDialog()
    End Sub

    Private Sub ProductosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ProductosToolStripMenuItem.Click
        Dim objFrmProducto As New frmProducto
        objFrmProducto.ShowDialog()
    End Sub

    Private Sub PedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PedidoToolStripMenuItem.Click
        Dim objFrmPedido As New frmTransaPedido
        objFrmPedido.ShowDialog()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs) Handles ToolStripButton2.Click

    End Sub

    Private Sub CartaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CartaToolStripMenuItem.Click
        Dim objFrmCarta As New frmCarta
        frmCarta.ShowDialog()
    End Sub

    Private Sub ConsultarCartaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsultarCartaToolStripMenuItem.Click
        Dim objFrmConsultarCarta As New frmConsultarCarta
        frmConsultarCarta.ShowDialog()
    End Sub

    Private Sub SalirToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalirToolStripMenuItem.Click
        Dim resultado As DialogResult = MessageBox.Show("¿Estás seguro de que deseas salir del sistema?", "SIST-REST 2025", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If resultado = DialogResult.Yes Then
            Me.Close()
        End If
    End Sub

    Private Sub CerrarSesiónToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CerrarSesiónToolStripMenuItem.Click
        inicioSesion()
        lblUsuario.Text = ""
    End Sub

    Private Sub CambiarUsuarioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CambiarUsuarioToolStripMenuItem.Click
        inicioSesion()
    End Sub

    Private Sub AperturaDeCajaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AperturaDeCajaToolStripMenuItem.Click

    End Sub

    Private Sub RegistrarPagoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RegistrarPagoToolStripMenuItem.Click
        Dim objFrmPago As New frmTransaPago
        objFrmPago.Show()
    End Sub
End Class