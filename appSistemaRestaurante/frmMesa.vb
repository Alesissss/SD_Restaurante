Imports libNegocio
Public Class frmMesa
    Dim objMes As New clsMesa
    Dim dtMes As New DataTable
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
    End Sub

    Private Sub listarMesas()
        Dim dtMesero As New DataTable
        Dim ind As Integer = 0
        Try
            dgvMesas.DataSource = objMes.listarMesas

            'Llenar el listView'
            dtMesero = objMes.listarMesas
            For Each mesero In dtMesero.Rows
                lsvMesas.Items.Add(dtMesero.Rows(ind).Item(0))
                lsvMesas.Items(ind).SubItems.Add(dtMesero.Rows(ind).Item(1))
                lsvMesas.Items(ind).SubItems.Add(IIf(dtMesero.Rows(ind).Item(2), "Vigente", "No Vigente"))
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
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                'Generar el ID del mesero
                txtIDMes.Text = objMes.generarIDMesa
            Else
                btnNuevo.Text = "Nuevo"
                'Registrar nuevo mesero
                objMes.guardarMesa(CInt(txtIDMes.Text), txtCapacidad.Text, chkEstado.Checked)

                limpiarControles()
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
End Class