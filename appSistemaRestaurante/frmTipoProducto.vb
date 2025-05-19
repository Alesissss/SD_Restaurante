Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports libNegocio

Public Class frmTipoProducto
    Dim objTipoProd As New clsTipoProducto
    Dim dtTipoProd As New DataTable

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
        Dim camposAValidar() As Object = {txtDescripcion.Text, txtIDProducto.Text, txtNombres.Text}
        Try
            If btnNuevo.Text = "Nuevo" Then

                'Generar el ID del mesero
                txtIDProducto.Text = objTipoProd.generarIDTipoProducto
                btnNuevo.Text = "Guardar"
            Else
                If Not ValidationManager.camposLlenos(camposAValidar) Then
                    MessageBox.Show("Todos los campos son necesarios", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If txtNombres.TextLength > 30 Then
                    MessageBox.Show("El nombre es muy extenso", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                If txtDescripcion.TextLength > 100 Then
                    MessageBox.Show("La descripción es muy extensa", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'Registrar nuevo mesero
                objTipoProd.guardarTipoProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, chkEstado.Checked)

                    limpiarControles()
                    btnNuevo.Text = "Nuevo"
                End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objTipoProd.modificarTipoProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, chkEstado.Checked)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objTipoProd.eliminarTipoProducto(CInt(txtIDProducto.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objTipoProd.darBajaTipoProducto(CInt(txtIDProducto.Text))
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
            If txtIDProducto.TextLength > 0 Then
                dtTipoProd = objTipoProd.buscarTipoProducto(CInt(txtIDProducto.Text))
                If dtTipoProd.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtNombres.Text = dtTipoProd.Rows(0).Item(1)
                    txtDescripcion.Text = dtTipoProd.Rows(0).Item(2)
                    chkEstado.Checked = dtTipoProd.Rows(0).Item(3)
                Else
                    MessageBox.Show("Id de Tipo Producto no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Tipo Producto a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        listar_tipo_productos()
    End Sub

    Private Sub frmTipoProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listar_tipo_productos()
        pintarFrm(dgvProductos, lsvProductos)
    End Sub

    Private Sub listar_tipo_productos()
        Dim dttp As New DataTable
        Dim ind As Integer = 0
        Try
            dgvProductos.DataSource = objTipoProd.listarTiposProducto
            formatearTabla(dgvProductos)
            'Llenar el listView'
            dttp = objTipoProd.listarTiposProducto
            For Each mesero In dttp.Rows
                lsvProductos.Items.Add(dttp.Rows(ind).Item(0))
                lsvProductos.Items(ind).SubItems.Add(dttp.Rows(ind).Item(1))
                lsvProductos.Items(ind).SubItems.Add(dttp.Rows(ind).Item(2))
                lsvProductos.Items(ind).SubItems.Add(dttp.Rows(ind).Item(3))
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
    Private Sub dgvProductos_Click(sender As Object, e As EventArgs) Handles dgvProductos.Click
        If dgvProductos.CurrentRow IsNot Nothing AndAlso dgvProductos.CurrentRow.Index >= 0 Then
            Dim cellValue As Object = dgvProductos.CurrentRow.Cells(0).Value

            If cellValue IsNot Nothing AndAlso Not Convert.IsDBNull(cellValue) Then
                txtIDProducto.Text = cellValue.ToString()
                If Not String.IsNullOrWhiteSpace(txtIDProducto.Text) Then
                    btnBuscar_Click(sender, e)
                Else
                End If
            Else
                txtIDProducto.Text = String.Empty
                MessageBox.Show("La celda seleccionada no contiene un ID válido.", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub lsvProductos_Click(sender As Object, e As EventArgs) Handles lsvProductos.Click
        txtIDProducto.Text = lsvProductos.SelectedItems(0).Text
        btnBuscar_Click(sender, e)
    End Sub

    Private Sub formatearTabla(dgv As DataGridView)
        dgv.Columns("idTipo").HeaderText = "ID"
        dgv.Columns("nombre").HeaderText = "Nombre"
        dgv.Columns("descripcion").HeaderText = "Descripción"
        dgv.Columns("estado").HeaderText = "Estado"
    End Sub

    Private Sub dgvMeseros_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvProductos.CellFormatting
        If dgvProductos.Columns(e.ColumnIndex).Name = "estado" Then
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