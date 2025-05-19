Imports System.Runtime.Remoting
Imports libNegocio

Public Class frmProducto
    Dim objProducto As New clsProducto
    Dim objTipoProducto As New clsTipoProducto
    Dim objCarta As New clsCarta
    Private Sub frmProducto_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarTipos()
        listarProductos()
        pintarFrm(dgvCarta, lsvCarta)
        listarProductos()
    End Sub
    Private Sub listarProductos()
        Dim dtProducto As New DataTable
        Dim ind As Integer = 0
        Try
            dgvProductos.DataSource = objProducto.listarProductos()
            'Llenar el listView'
            dtProducto = objProducto.listarProductos()
            For Each mesero In dtProducto.Rows
                lsvProductos.Items.Add(dtProducto.Rows(ind).Item(0))
                lsvProductos.Items(ind).SubItems.Add(dtProducto.Rows(ind).Item(1))
                lsvProductos.Items(ind).SubItems.Add(dtProducto.Rows(ind).Item(2))
                lsvProductos.Items(ind).SubItems.Add(dtProducto.Rows(ind).Item(3))
                lsvProductos.Items(ind).SubItems.Add(dtProducto.Rows(ind).Item(4))
                lsvProductos.Items(ind).SubItems.Add(dtProducto.Rows(ind).Item(5))
                lsvProductos.Items(ind).SubItems.Add(dtProducto.Rows(ind).Item(6))
                ind += 1
            Next
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

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
    Private Sub listarCartas()
        Try
            Dim dtCarta As DataTable
            dtCarta = objCarta.listarCartas()

            cbxCarta.DataSource = dtCarta
            cbxTipo.DisplayMember = "nombre"
            cbxTipo.ValueMember = "idCarta"
            cbxTipo.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar las cartas: " & ex.Message)
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
                If Not IsNumeric(txtPrecio.Text) Then
                    MessageBox.Show("El precio debe ser un valor numérico", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                If Decimal.Parse(txtPrecio.Text) <= 0 Then
                    MessageBox.Show("El precio no puede ser negativo o 0", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
                'Fin sección validaciones


                'Registrar nuevo mesero
                objProducto.guardarProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, txtPrecio.Text, chkEstado.Checked, cbxTipo.SelectedValue, cbxCarta.SelectedValue)

                limpiarControles()
                btnNuevo.Text = "Nuevo"
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objProducto.modificarProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, txtPrecio.Text, chkEstado.Checked, cbxTipo.SelectedValue, cbxCarta.SelectedValue)
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
        listarProductos()
    End Sub
    Private Sub habilitarBotones(est As Boolean)
        btnEliminar.Enabled = est
        btnModificar.Enabled = est
        btnDarBaja.Enabled = est
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objProducto.eliminarProducto(CInt(txtIDProducto.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objProducto.darBajaProducto(CInt(txtIDProducto.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub

    Private Sub formatearTabla(dgv As DataGridView)
        dgv.Columns("idProducto").HeaderText = "ID"
        dgv.Columns("nombre").HeaderText = "Nombre"
        dgv.Columns("descripcion").HeaderText = "Descripción"
        dgv.Columns("precio").HeaderText = "Precio"
        dgv.Columns("tipo_producto").HeaderText = "Tipo"
        dgv.Columns("estado").HeaderText = "Estado"
    End Sub

    Private Sub listarProductos()
        Dim dtCliente As New DataTable
        Dim ind As Integer = 0
        Try
            dgvCarta.DataSource = objProducto.listarProductos

            formatearTabla(dgvCarta)

            'Llenar el listView'
            dtCliente = objProducto.listarProductos
            For Each mesero In dtCliente.Rows
                lsvCarta.Items.Add(dtCliente.Rows(ind).Item(0))
                lsvCarta.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(1))
                lsvCarta.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(2))
                lsvCarta.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(3))
                lsvCarta.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(4))
                ind += 1
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub dgvCarta_CellFormatting(sender As Object, e As DataGridViewCellFormattingEventArgs) Handles dgvCarta.CellFormatting
        If dgvCarta.Columns(e.ColumnIndex).Name = "estado" Then
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

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        Dim dtCliente As New DataTable
        Try
            If txtIDProducto.TextLength > 0 Then
                dtCliente = objProducto.buscarProducto(CInt(txtIDProducto.Text))
                If dtCliente.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtNombres.Text = dtCliente.Rows(0).Item(1)
                    txtDescripcion.Text = dtCliente.Rows(0).Item(2)
                    txtPrecio.Text = dtCliente.Rows(0).Item(3)
                    txtIDProducto.Text = dtCliente.Rows(0).Item(3)
                    chkEstado.Checked = dtCliente.Rows(0).Item(5)
                Else
                    MessageBox.Show("Id de producto no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de producto a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class