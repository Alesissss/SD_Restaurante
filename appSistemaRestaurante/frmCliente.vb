Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports System.Drawing
Imports libNegocio
Public Class frmCliente
    Dim objCli As New clsCliente
    Dim dtCli As New DataTable
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


    Private Sub frmMesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarClientes()
        pintarFrm(dgvClientes, lsvClientes)
    End Sub

    Private Sub formatearTabla(dgv As DataGridView)
        dgv.Columns("idCliente").HeaderText = "ID"
        dgv.Columns("dniCliente").HeaderText = "DNI"
        dgv.Columns("nombres").HeaderText = "Nombres"
        dgv.Columns("apellidos").HeaderText = "Apellidos"
        dgv.Columns("telefono").HeaderText = "Teléfono"
        dgv.Columns("correo").HeaderText = "Correo"
        dgv.Columns("estado").HeaderText = "Estado"
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim camposAValidar() As Object = {txtApellidos.Text, txtCorreo.Text, txtDni.Text, txtIDCliente.Text, txtNombres.Text, txtTelefono.Text}
        Try
            If btnNuevo.Text = "Nuevo" Then
                'Generar el ID del cliente
                txtIDCliente.Text = objCli.generarIDCliente()
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


                'Registrar nuevo cliente
                objCli.guardarCliente(CInt(txtIDCliente.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)
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
                miControl.Clear()
            End If
        Next
        chkEstado.Checked = False
        listarClientes()
    End Sub
    Private Sub listarClientes()
        Dim dtCliente As New DataTable
        Dim ind As Integer = 0
        Try
            dgvClientes.DataSource = objCli.listarClientes
            formatearTabla(dgvClientes)

            'Llenar el listView'
            dtCliente = objCli.listarClientes
            For Each mesero In dtCliente.Rows
                lsvClientes.Items.Add(dtCliente.Rows(ind).Item(0))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(1))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(2) + " " + dtCliente.Rows(ind).Item(3))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(4))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(5))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(6))
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
            objCli.modificarCliente(CInt(txtIDCliente.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objCli.eliminarCliente(CInt(txtIDCliente.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objCli.darBajaCliente(CInt(txtIDCliente.Text))
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
            If txtIDCliente.TextLength > 0 Then
                dtCli = objCli.buscarCliente(CInt(txtIDCliente.Text))
                If dtCli.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtDni.Text = dtCli.Rows(0).Item(1)
                    txtNombres.Text = dtCli.Rows(0).Item(2)
                    txtApellidos.Text = dtCli.Rows(0).Item(3)
                    txtTelefono.Text = dtCli.Rows(0).Item(4)
                    txtCorreo.Text = dtCli.Rows(0).Item(5)
                    chkEstado.Checked = dtCli.Rows(0).Item(6)
                Else
                    MessageBox.Show("Id de Cliente no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Cliente a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvClientes_Click(sender As Object, e As EventArgs) Handles dgvClientes.Click
        If dgvClientes.CurrentRow IsNot Nothing AndAlso dgvClientes.CurrentRow.Index >= 0 Then
            Dim cellValue As Object = dgvClientes.CurrentRow.Cells(0).Value

            If cellValue IsNot Nothing AndAlso Not Convert.IsDBNull(cellValue) Then
                txtIDCliente.Text = cellValue.ToString()
                If Not String.IsNullOrWhiteSpace(txtIDCliente.Text) Then
                    btnBuscar_Click(sender, e)
                Else
                End If
            Else
                txtIDCliente.Text = String.Empty
                MessageBox.Show("La celda seleccionada no contiene un ID válido.", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub lsvClientes_Click(sender As Object, e As EventArgs) Handles lsvClientes.Click
        txtIDCliente.Text = lsvClientes.SelectedItems(0).Text
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub dgvClientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvClientes.CellFormatting
        If dgvClientes.Columns(e.ColumnIndex).Name = "estado" Then
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