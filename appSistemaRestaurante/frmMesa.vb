Imports System.Net.Security
Imports libNegocio
Public Class frmMesa
    Dim objMes As New clsMesa
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
    Private Sub limpiarControles()
        For Each miControl In Me.pnlDatos.Controls
            If TypeOf miControl Is TextBox Then
                miControl.Clear
            End If
        Next
        chkEstado.Checked = False
        listarMesas()
    End Sub

    Private Sub frmMesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarMesas()
        pintarFrm(dgvMesas, lsvMesas)

    End Sub

    Private Sub listarMesas()
        Dim dtMesero As New DataTable
        Dim ind As Integer = 0
        Try
            dgvMesas.DataSource = objMes.listarMesas
            formatearTabla(dgvMesas)
            'Llenar el listView'
            dtMesero = objMes.listarMesas
            For Each mesero In dtMesero.Rows
                lsvMesas.Items.Add(dtMesero.Rows(ind).Item(0))
                lsvMesas.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(1))
                lsvMesas.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(2))
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

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Dim camposAValidar() As Object = {txtIDMes.Text, txtCapacidad.Text}
        Try
            If btnNuevo.Text = "Nuevo" Then
                'Generar el ID del mesero
                txtIDMes.Text = objMes.generarIDMesa
                btnNuevo.Text = "Guardar"
            Else
                If Not ValidationManager.camposLlenos(camposAValidar) Then
                    MessageBox.Show("Todos los campos son necesario", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Not ValidationManager.isNumber(txtCapacidad.Text) Then
                    MessageBox.Show("La capacidad es un campo numérico", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'Faltan validaciones de campos numéricos



                'Registrar nuevo mesero
                objMes.guardarMesa(CInt(txtIDMes.Text), txtCapacidad.Text, chkEstado.Checked)

                limpiarControles()
                btnNuevo.Text = "Nuevo"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objMes.modificarMesa(CInt(txtIDMes.Text), txtCapacidad.Text, chkEstado.Checked)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objMes.eliminarMesa(CInt(txtIDMes.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objMes.darBajaMesa(CInt(txtIDMes.Text))
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
            If txtIDMes.TextLength > 0 Then
                dtMes = objMes.buscarMesa(CInt(txtIDMes.Text))
                If dtMes.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtCapacidad.Text = dtMes.Rows(0).Item(1)
                    chkEstado.Checked = dtMes.Rows(0).Item(2)
                Else
                    MessageBox.Show("Id de Mesa no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Mesa a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub dgvMesas_Click(sender As Object, e As EventArgs) Handles dgvMesas.Click
        If dgvMesas.CurrentRow IsNot Nothing AndAlso dgvMesas.CurrentRow.Index >= 0 Then
            Dim cellValue As Object = dgvMesas.CurrentRow.Cells(0).Value

            If cellValue IsNot Nothing AndAlso Not Convert.IsDBNull(cellValue) Then
                txtIDMes.Text = cellValue.ToString()
                If Not String.IsNullOrWhiteSpace(txtIDMes.Text) Then
                    btnBuscar_Click(sender, e)
                Else
                End If
            Else
                txtIDMes.Text = String.Empty
                MessageBox.Show("La celda seleccionada no contiene un ID válido.", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub lsvMesas_Click(sender As Object, e As EventArgs) Handles lsvMesas.Click
        txtIDMes.Text = lsvMesas.SelectedItems(0).Text
        btnBuscar_Click(sender, e)
    End Sub

    'Pegar siempre
    Private Sub formatearTabla(dgv As DataGridView)
        dgv.Columns("idMesa").HeaderText = "ID"
        dgv.Columns("capacidad").HeaderText = "Capacidad"
        dgv.Columns("estado").HeaderText = "Estado"
    End Sub

    Private Sub dgvClientes_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvMesas.CellFormatting
        If dgvMesas.Columns(e.ColumnIndex).Name = "estado" Then
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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub pnlDatos_Paint(sender As Object, e As PaintEventArgs) Handles pnlDatos.Paint

    End Sub
End Class