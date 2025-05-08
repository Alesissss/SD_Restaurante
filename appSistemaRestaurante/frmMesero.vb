Imports libNegocio

Public Class frmMesero
    Dim objMes As New clsMesero
    Dim dtMes As New DataTable

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                'Generar el ID del mesero
                txtIDMes.Text = objMes.generarIDMesero
            Else
                btnNuevo.Text = "Nuevo"
                'Registrar nuevo mesero
                objMes.guardarMesero(CInt(txtIDMes.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, cmbSexo.Text, dtpFecha.Value, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)

                limpiarControles()
            End If
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
        dtpFecha.Value = Now.Date
        cmbSexo.Text = ""
        chkEstado.Checked = False
        listarMeseros()
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objMes.modificarMesero(CInt(txtIDMes.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, cmbSexo.Text, dtpFecha.Value, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objMes.eliminarMesero(CInt(txtIDMes.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objMes.darBajaMesero(CInt(txtIDMes.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub frmMesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarMeseros()

    End Sub

    Private Sub listarMeseros()
        Dim dtMesero As New DataTable
        Dim ind As Integer = 0
        Try
            dgvEmpleados.DataSource = objMes.listarMesero

            'Llenar el listView'
            dtMesero = objMes.listarMesero
            For Each mesero In dtMesero.Rows
                lsvEmpleados.Items.Add(dtMesero.Rows(ind).Item(0))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(1))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(2) + " " + dtMesero.Rows(ind).Item(3))
                lsvEmpleados.Items(ind).SubItems.Add(IIf(dtMesero.Rows(ind).Item(4), "Masculino", "Femenino"))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(5))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(6))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(7))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(8))
                lsvEmpleados.Items(ind).SubItems.Add(IIf(dtMesero.Rows(ind).Item(9), "Vigente", "No Vigente"))
                ind += 1
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub habilitarBotones(est As Boolean)
        btnEliminar.Enabled = est
        btnModificar.Enabled = est
        btnDarBaja.Enabled = est
    End Sub
    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If txtIDMes.TextLength > 0 Then
                dtMes = objMes.buscarMesero(CInt(txtIDMes.Text))
                If dtMes.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtDni.Text = dtMes.Rows(0).Item(1)
                    txtNombres.Text = dtMes.Rows(0).Item(2)
                    txtApellidos.Text = dtMes.Rows(0).Item(3)
                    cmbSexo.Text = IIf(dtMes.Rows(0).Item(4), "Masculino", "Femenino")
                    dtpFecha.Value = dtMes.Rows(0).Item(5)
                    txtDireccion.Text = dtMes.Rows(0).Item(6)
                    txtTelefono.Text = dtMes.Rows(0).Item(7)
                    txtCorreo.Text = dtMes.Rows(0).Item(8)
                    chkEstado.Checked = dtMes.Rows(0).Item(9)
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

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub dgvEmpleados_Click(sender As Object, e As EventArgs) Handles dgvEmpleados.Click
        'índice de fila seleccionada: dgvEmpleados.SelectedRows(0).Index
        txtIDMes.Text = dgvEmpleados.SelectedRows(0).Cells(0).Value
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub lsvEmpleados_Click(sender As Object, e As EventArgs) Handles lsvEmpleados.Click
        txtIDMes.Text = lsvEmpleados.SelectedItems(0).Text
        btnBuscar_Click(sender, e)
    End Sub
End Class