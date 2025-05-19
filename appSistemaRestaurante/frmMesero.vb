Imports libNegocio

Public Class frmMesero
    Dim objMes As New clsMesero
    Dim dtMes As New DataTable


    Public Sub pintarFrm(dgv As DataGridView, lsv As ListView)
        'Pintar algunos paneles
        pnlDatos.BackColor = ColorTranslator.FromHtml("#C5CEC3")
        pnlBotones.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        'Estilo de botones
        For Each ctrl As Control In pnlBotones.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                btn.FlatStyle = FlatStyle.Flat
                btn.UseVisualStyleBackColor = False '
                btn.FlatAppearance.BorderSize = 0
                btn.BackColor = ColorTranslator.FromHtml("#413732")
                btn.ForeColor = Color.White
                btn.Font = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            End If
        Next

        'Estilizar tabla
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AllowUserToAddRows = False

        dgv.DefaultCellStyle.Font = New Font("MS Reference Sans Serif", 8)
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("MS Reference Sans Serif", 8, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E201D")
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.EnableHeadersVisualStyles = False
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgv.GridColor = Color.LightGray
        'Estilizar lsv

        With lsv
            .View = View.Details
            .FullRowSelect = True
            .GridLines = True
            .Font = New Font("MS Reference Sans Serif", 8)
            .BackColor = Color.White
            .ForeColor = Color.Black
        End With
        lsv.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)

    End Sub
    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim camposAValidar() As Object = {txtApellidos.Text, txtCorreo.Text, txtDni.Text, txtIDMes.Text, txtNombres.Text, txtTelefono.Text}
        Try
            If btnNuevo.Text = "Nuevo" Then

                'Generar el ID del mesero
                txtIDMes.Text = objMes.generarIDMesero
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

                If Not ValidationManager.fecha.ValidarFechaNacimiento(dtpFecha) Then
                    MessageBox.Show("Los fecha de nacimiento ingresada no es válida", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'Fin sección validaciones


                'Registrar nuevo mesero
                objMes.guardarMesero(CInt(txtIDMes.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, cmbSexo.Text, dtpFecha.Value, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)

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
        pintarFrm(dgvEmpleados, lsvEmpleados)

    End Sub

    Private Sub listarMeseros()
        Dim dtMesero As New DataTable
        Dim ind As Integer = 0
        Try
            dgvEmpleados.DataSource = objMes.listarMesero
            formatearTabla(dgvEmpleados)
            'Llenar el listView'
            dtMesero = objMes.listarMesero

            For Each mesero In dtMesero.Rows
                lsvEmpleados.Items.Add(dtMesero.Rows(ind).Item(0))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(1))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(2) + " " + dtMesero.Rows(ind).Item(3))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(4))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(5))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(6))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(7))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(8))
                lsvEmpleados.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(9))
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

    Private Sub dgvEmpleados_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgvEmpleados.CellContentClick

    End Sub

    'Pegar siempre
    Private Sub formatearTabla(dgv As DataGridView)
        dgv.Columns("idMesero").HeaderText = "ID"
        dgv.Columns("dniMesero").HeaderText = "DNI"
        dgv.Columns("nombres").HeaderText = "Nombres"
        dgv.Columns("apellidos").HeaderText = "Apellidos"
        dgv.Columns("sexo").HeaderText = "Sexo"
        dgv.Columns("fechaNac").HeaderText = "Fecha de nacimiento"
        dgv.Columns("telefono").HeaderText = "Teléfono"
        dgv.Columns("correo").HeaderText = "Correo"
        dgv.Columns("estado").HeaderText = "Estado"
    End Sub

    Private Sub dgvMeseros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvEmpleados.CellFormatting
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