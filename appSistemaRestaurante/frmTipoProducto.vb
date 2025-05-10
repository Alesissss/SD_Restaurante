Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports libNegocio

Public Class frmTipoProducto
    Dim objTipoProd As New clsTipoProducto
    Dim dtTipoProd As New DataTable

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                'Generar el ID del mesero
                txtIDProducto.Text = objTipoProd.generarIDTipoProducto
            Else
                btnNuevo.Text = "Nuevo"
                'Registrar nuevo mesero
                objTipoProd.guardarTipoProducto(CInt(txtIDProducto.Text), txtNombres.Text, txtDescripcion.Text, chkEstado.Checked)

                limpiarControles()
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
    End Sub

    Private Sub listar_tipo_productos()
        Dim dttp As New DataTable
        Dim ind As Integer = 0
        Try
            dgvProductos.DataSource = objTipoProd.listarTiposProducto

            'Llenar el listView'
            dttp = objTipoProd.listarTiposProducto
            For Each mesero In dttp.Rows
                lsvProductos.Items.Add(dttp.Rows(ind).Item(0))
                lsvProductos.Items(ind).SubItems.Add(dttp.Rows(ind).Item(1))
                lsvProductos.Items(ind).SubItems.Add(dttp.Rows(ind).Item(2))
                lsvProductos.Items(ind).SubItems.Add(IIf(dttp.Rows(ind).Item(3), "Vigente", "No Vigente"))
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
End Class