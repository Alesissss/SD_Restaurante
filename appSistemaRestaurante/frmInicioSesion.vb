Imports libDatos
Imports libNegocio

Public Class frmInicioSesion
    Dim objConexion As New clsConectaBD
    Dim objUsuario As New clsUsuario
    Public estadoInicio As Boolean = False
    Public usuario As String = ""

    Private Sub chkContraseña_CheckedChanged(sender As Object, e As EventArgs) Handles chkContraseña.CheckedChanged
        Try
            txtPregunta.Clear()
            txtRespuesta.Clear()
            If txtUsuario.TextLength > 0 Then
                grbContraseña.Enabled = chkContraseña.Checked
                txtPregunta.Text = objUsuario.obtenerPreguntaSec(txtUsuario.Text)
                txtRespuesta.Focus()
            Else
                MessageBox.Show("Debe ingresar nombre de usuario!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                txtUsuario.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnConectar_Click(sender As Object, e As EventArgs) Handles btnConectar.Click
        Try
            objConexion.conectar()
            txtEstado.Text = objConexion.estadoCN
        Catch ex As Exception
            MessageBox.Show("Problemas de conexión a la BD", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDesconectar_Click(sender As Object, e As EventArgs) Handles btnDesconectar.Click
        Try
            objConexion.desconectar()
            txtEstado.Text = objConexion.estadoCN
        Catch ex As Exception
            MessageBox.Show("Problemas de conexión a la BD", "MENSAJE", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnAceptar_Click(sender As Object, e As EventArgs) Handles btnAceptar.Click
        Try
            If txtUsuario.TextLength > 0 And txtContraseña.TextLength > 0 Then
                If objUsuario.iniciarSesion(txtUsuario.Text, txtContraseña.Text) Then
                    MessageBox.Show("Bienvenido al Sistema!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    estadoInicio = True
                    usuario = txtUsuario.Text
                    Me.Close()
                Else
                    MessageBox.Show("Credenciales incorrectas, intente nuevamente!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingresar Usuario y Contraseña!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtUsuario.Focus()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            If objUsuario.validarRespuestaPregSec(txtUsuario.Text, txtRespuesta.Text) Then
                MessageBox.Show("Bienvenido al Sistema!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                estadoInicio = True
                usuario = txtUsuario.Text
                Me.Close()
            Else
                MessageBox.Show("Respuesta incorrecta, intente nuevamente!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Sub frmInicioSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class