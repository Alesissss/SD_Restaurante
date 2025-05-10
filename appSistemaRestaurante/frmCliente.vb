Imports System.Runtime.Remoting
Imports System.Security.Cryptography
Imports libNegocio
Public Class frmCliente
    Dim objCli As New clsCliente
    Dim dtCli As New DataTable

    Private Sub frmMesero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarClientes()
    End Sub

    Private Sub btnNuevo_Click(sender As Object, e As EventArgs) Handles btnNuevo.Click
        Try
            If btnNuevo.Text = "Nuevo" Then
                btnNuevo.Text = "Guardar"
                'Generar el ID del cliente
                txtIDCliente.Text = objCli.generarIDCliente()
            Else
                btnNuevo.Text = "Nuevo"
                'Registrar nuevo cliente
                objCli.guardarCliente(CInt(txtIDCliente.Text), txtDni.Text, txtNombres.Text, txtApellidos.Text, txtTelefono.Text, txtCorreo.Text, chkEstado.Checked)
                limpiarControles()
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

            'Llenar el listView'
            dtCliente = objCli.listarClientes
            For Each mesero In dtCliente.Rows
                lsvClientes.Items.Add(dtCliente.Rows(ind).Item(0))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(1))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(2) + " " + dtCliente.Rows(ind).Item(3))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(4))
                lsvClientes.Items(ind).SubItems.Add(dtCliente.Rows(ind).Item(5))
                lsvClientes.Items(ind).SubItems.Add(IIf(dtCliente.Rows(ind).Item(6), "Vigente", "No Vigente"))
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
End Class