Imports System.Runtime.Remoting
Imports libNegocio

Public Class frmCarta
    Dim objCar As New clsCarta
    Dim dtCar As New DataTable

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                'Generar el ID del mesero
                txtIDCarta.Text = objCar.generarIDCarta
            Else
                btnNuevo.Text = "Nuevo"
                'Registrar nuevo mesero
                objCar.guardarCarta(CInt(txtIDCarta.Text), txtNombres.Text, txtDescripcion.Text, chkEstado.Checked)

                limpiarControles()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnModificar_Click(sender As Object, e As EventArgs) Handles btnModificar.Click
        Try
            objCar.modificarCarta(CInt(txtIDCarta.Text), txtNombres.Text, txtDescripcion.Text, chkEstado.Checked)
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        Try
            objCar.eliminarCarta(CInt(txtIDCarta.Text))
            limpiarControles()
            habilitarBotones(False)
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnDarBaja_Click(sender As Object, e As EventArgs) Handles btnDarBaja.Click
        Try
            objCar.darBajaCarta(CInt(txtIDCarta.Text))
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
            If txtIDCarta.TextLength > 0 Then
                dtCar = objCar.buscarCarta(CInt(txtIDCarta.Text))
                If dtCar.Rows.Count > 0 Then
                    habilitarBotones(True)
                    txtNombres.Text = dtCar.Rows(0).Item(1)
                    txtDescripcion.Text = dtCar.Rows(0).Item(2)
                    chkEstado.Checked = dtCar.Rows(0).Item(3)
                Else
                    MessageBox.Show("Id de Carta no existe!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            Else
                MessageBox.Show("Ingrese Id de Carta a buscar!!", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Information)
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
        listarCarta()
    End Sub

    Private Sub frmCarta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarCarta()
    End Sub

    Private Sub listarCarta()
        Dim dtcar As New DataTable
        Dim ind As Integer = 0
        Try
            dgvCarta.DataSource = objCar.listarCartas

            'Llenar el listView'
            dtcar = objCar.listarCartas
            For Each mesero In dtcar.Rows
                lsvCarta.Items.Add(dtcar.Rows(ind).Item(0))
                lsvCarta.Items(ind).SubItems.Add(dtcar.Rows(ind).Item(1))
                lsvCarta.Items(ind).SubItems.Add(dtcar.Rows(ind).Item(2))
                lsvCarta.Items(ind).SubItems.Add(IIf(dtcar.Rows(ind).Item(3), "Vigente", "No Vigente"))
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
    Private Sub dgvCarta_Click(sender As Object, e As EventArgs) Handles dgvCarta.Click
        If dgvCarta.CurrentRow IsNot Nothing AndAlso dgvCarta.CurrentRow.Index >= 0 Then
            Dim cellValue As Object = dgvCarta.CurrentRow.Cells(0).Value

            If cellValue IsNot Nothing AndAlso Not Convert.IsDBNull(cellValue) Then
                txtIDCarta.Text = cellValue.ToString()
                If Not String.IsNullOrWhiteSpace(txtIDCarta.Text) Then
                    btnBuscar_Click(sender, e)
                Else
                End If
            Else
                txtIDCarta.Text = String.Empty
                MessageBox.Show("La celda seleccionada no contiene un ID válido.", "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub
    Private Sub lsvCarta_Click(sender As Object, e As EventArgs) Handles lsvCarta.Click
        txtIDCarta.Text = lsvCarta.SelectedItems(0).Text
        btnBuscar_Click(sender, e)
    End Sub
End Class