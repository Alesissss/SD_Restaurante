Imports System.Runtime.Remoting
Imports libNegocio

Public Class frmProducto
    Dim objProducto As New clsProducto
    Dim objTipoProducto As New clsTipoProducto
    Private Sub frmProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarTipos()
    End Sub

    Private Sub listarTipos()
        Try
            Dim dtTipo As DataTable
            dtTipo = objTipoProducto.listarTiposProducto()

            cbxTipo.DataSource = dtTipo
            cbxTipo.DisplayMember = "nombre"
            cbxTipo.ValueMember = "idTipo"
            cbxTipo.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar los tipos de producto: " & ex.Message)
        End Try
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim camposAValidar() As Object = {txtNombres.Text, txtDescripcion.Text, txtPrecio.Text}
        Try
            If btnNuevo.Text = "Nuevo" Then

                'Generar el ID del mesero
                txtIDProducto.Text = objProducto.generarIDProducto()
                btnNuevo.Text = "Guardar"
            Else
                'Sección validaciones
                If Not ValidationManager.camposLlenos(camposAValidar) Then
                    MessageBox.Show("Todos los campos son necesarios", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If Decimal.Parse(txtPrecio.Text) <= 0 Then
                    MessageBox.Show("El precio no puede ser negativo o 0", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'Fin sección validaciones


                'Registrar nuevo mesero
                objProducto.guardarProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, txtPrecio.Text, chkEstado.Checked, cbxTipo.SelectedValue)

                limpiarControles()
                btnNuevo.Text = "Nuevo"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objProducto.modificarProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, txtPrecio.Text, chkEstado.Checked, cbxTipo.SelectedValue)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub limpiarControles()
        For Each miControl In Me.pnlDatos.Controls
            If TypeOf miControl Is TextBox Then
                miControl.Clear
            End If
        Next
        cbxTipo.Text = ""
        chkEstado.Checked = False
    End Sub
    Private Sub habilitarBotones(est As Boolean)
        btnEliminar.Enabled = est
        btnModificar.Enabled = est
        btnDarBaja.Enabled = est
    End Sub
End Class