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

    Private Sub MeseroToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MeseroToolStripMenuItem.Click
        Dim objFrmMesero As New frmMesero
        objFrmMesero.ShowDialog()
    End Sub
End Class