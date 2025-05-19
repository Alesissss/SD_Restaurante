Imports libNegocio

Public Class frmTransaPago
    Dim objCajero As New clsCajero
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
End Class