Imports libNegocio

Public Class frmTransaPago
    Dim objCajero As New clsCajero
    Private Sub frmTransaPago_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
    Private Sub listarCajeros()
        Dim dtCajero As New DataTable
        dtCajero = objCajero.listarCajeros()
    End Sub
End Class