Imports libNegocio

Public Class frmCajero
    Dim objCaj As New clsCajero
    Dim dtCaj As New DataTable
    Private Sub frmCajero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarCajeros()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim camposAValidar() As Object = {txtApellidos.Text, txtCorreo.Text, txtDni.Text, txtIDCajero.Text, txtNombres.Text, txtTelefono.Text}
        Try
            If btnNuevo.Text = "Nuevo" Then

                'Generar el ID del mesero
                txtIDCajero.Text = objCaj.generarIDCajero
                btnNuevo.Text = "Guardar"
            Else
                'Sección validaciones
                If Not ValidationManager.camposLlenos(camposAValidar) Then
                    MessageBox.Show("Todos los campos son necesarios", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If Not ValidationManager.dni.esValido(txtDni.Text) Then
                    MessageBox.Show("El DNI está compuesto por ocho dígitos", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If Not ValidationManager.correo.esValido(txtCorreo.Text) Then
                    MessageBox.Show("El correo ingresado no es válido", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If Not ValidationManager.telefono.esValido(txtTelefono.Text) Then
                    MessageBox.Show("El telefono ingresado es inválido", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If txtNombres.TextLength > 40 Then
                    MessageBox.Show("El nombre ingresado es muy largo", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If txtApellidos.TextLength > 40 Then
                    MessageBox.Show("Los apellidos ingresados son muy largos", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'Fin sección validaciones

                'Registrar nuevo mesero
                objCaj.guardarCajero(CInt(txtIDCajero.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)

                limpiarControles()
                btnNuevo.Text = "Nuevo"
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
        chkEstado.Checked = False
        listarCajeros()
    End Sub
    Private Sub listarCajeros()
        Dim dtCajero As New DataTable
        Dim ind As Integer = 0
        Try
            dgvEmpleados.DataSource = objCaj.listarCajeros
            formatearTabla(dgvEmpleados)

            'Llenar el listView'
            dtCajero = objCaj.listarCajeros
            For Each mesero In dtCajero.Rows
                lsvEmpleados.Items.Add(dtCajero.Rows(ind).Item(0))
                lsvEmpleados.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(1))
                lsvEmpleados.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(2) + " " + dtCajero.Rows(ind).Item(3))
                lsvEmpleados.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(4))
                lsvEmpleados.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(5))
                lsvEmpleados.Items(ind).SubItems.Add(IIf(dtCajero.Rows(ind).Item(6), "Vigente", "No Vigente"))
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

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objCaj.modificarCajero(CInt(txtIDCajero.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objCaj.eliminarCajero(CInt(txtIDCajero.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objCaj.darBajaCajero(CInt(txtIDCajero.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Try
            If txtIDCajero.TextLength > 0 Then
                dtCaj = objCaj.buscarCajero(CInt(txtIDCajero.Text))
                If dtCaj.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtDni.Text = dtCaj.Rows(0).Item(1)
                    txtNombres.Text = dtCaj.Rows(0).Item(2)
                    txtApellidos.Text = dtCaj.Rows(0).Item(3)
                    txtTelefono.Text = dtCaj.Rows(0).Item(4)
                    txtCorreo.Text = dtCaj.Rows(0).Item(5)
                    chkEstado.Checked = dtCaj.Rows(0).Item(6)
                Else
                    MessageBox.Show("Id de Cajero no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Cajero a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvEmpleados_Click(sender As Object, e As EventArgs) Handles dgvEmpleados.Click
        'índice de fila seleccionada: dgvEmpleados.SelectedRows(0).Index
        txtIDCajero.Text = dgvEmpleados.SelectedRows(0).Cells(0).Value
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub lsvEmpleados_Click(sender As Object, e As EventArgs) Handles lsvEmpleados.Click
        txtIDCajero.Text = lsvEmpleados.SelectedItems(0).Text
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub formatearTabla(dgv As DataGridView)
        dgv.Columns("idCajero").HeaderText = "ID"
        dgv.Columns("dniCajero").HeaderText = "DNI"
        dgv.Columns("nombres").HeaderText = "Nombres"
        dgv.Columns("apellidos").HeaderText = "Apellidos"
        dgv.Columns("telefono").HeaderText = "Teléfono"
        dgv.Columns("correo").HeaderText = "Correo"
        dgv.Columns("estado").HeaderText = "Estado"
    End Sub

    Private Sub dgvClientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEmpleados.CellFormatting
        If dgvEmpleados.Columns(e.ColumnIndex).Name = "estado" Then
            If e.Value IsNot Nothing Then
                Dim valor = e.Value.ToString()

                If valor = "Activo" Then
                    e.CellStyle.BackColor = Color.LightGreen
                    e.CellStyle.ForeColor = Color.Black
                ElseIf valor = "Inactivo" Then
                    e.CellStyle.BackColor = Color.LightCoral
                    e.CellStyle.ForeColor = Color.White
                End If

                e.FormattingApplied = True
            End If
        End If
    End Sub
End Class