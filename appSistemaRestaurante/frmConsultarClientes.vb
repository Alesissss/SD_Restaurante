Imports libNegocio

Public Class frmConsultarClientes
    Dim objCliente As New clsCliente
    Public Property FormularioPadre As frmTransaPago
    Private Sub frmConsultarClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarClientes()
    End Sub
    Private Sub listarClientes()
        Dim dtCliente As New DataTable
        Dim ind As Integer = 0
        Try
            'Llenar el listView'
            dtCliente = objCliente.listarClientesVigentes()
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
    Private Sub lsvClientes_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvClientes.MouseDoubleClick
        If lsvClientes.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = lsvClientes.SelectedItems(0)

            ' Obtener el idPedido (lo guardamos tanto en .Text como en .Tag)
            Dim idCliente As String = If(selectedItem.Tag IsNot Nothing, selectedItem.Tag.ToString(), selectedItem.Text)
            Dim nombres As String = selectedItem.SubItems(2).Text
            Dim DNI As String = selectedItem.SubItems(3).Text

            If FormularioPadre IsNot Nothing Then
                ' Asignar el idPedido al TextBox del formulario padre
                FormularioPadre.txtCodCli.Text = idCliente
                FormularioPadre.txtDNICli.Text = DNI
                FormularioPadre.txtNomCli.Text = nombres

                Me.Close() ' Cerrar el formulario actual
            Else
                MessageBox.Show("No se ha especificado un formulario de destino para los datos.",
                            "Error de Programación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    ' Tu método AjustarAnchoColumnasListView (sin cambios, igual al que proporcionaste anteriormente)
    Private Sub AjustarAnchoColumnasListView()
        If lsvClientes Is Nothing OrElse lsvClientes.View <> View.Details OrElse lsvClientes.Columns.Count = 0 Then
            Return
        End If
        Dim totalWidthOfPreviousColumns As Integer = 0
        Dim scrollBarWidth As Integer = 0
        If lsvClientes.Items.Count > 0 AndAlso lsvClientes.Scrollable Then
            If lsvClientes.Items(lsvClientes.Items.Count - 1).Bounds.Bottom > lsvClientes.ClientSize.Height Then
                scrollBarWidth = SystemInformation.VerticalScrollBarWidth
            End If
        End If
        If lsvClientes.Columns.Count > 1 Then
            For i As Integer = 0 To lsvClientes.Columns.Count - 2
                lsvClientes.Columns(i).Width = -2 ' Autoajuste basado en contenido y cabecera
                totalWidthOfPreviousColumns += lsvClientes.Columns(i).Width
            Next
        End If
        Dim lastColumnIndex As Integer = lsvClientes.Columns.Count - 1
        If lastColumnIndex >= 0 Then
            Dim lastColumn As ColumnHeader = lsvClientes.Columns(lastColumnIndex)
            Dim availableWidthForLastColumn As Integer = lsvClientes.ClientSize.Width - totalWidthOfPreviousColumns - scrollBarWidth
            Dim currentLastColWidth As Integer = lastColumn.Width
            lastColumn.Width = -1 ' Autoajuste basado solo en cabecera
            Dim minLastColumnHeaderWidth As Integer = lastColumn.Width
            lastColumn.Width = currentLastColWidth ' Restaurar para la comparación

            ' Decidir el ancho de la última columna
            If availableWidthForLastColumn > minLastColumnHeaderWidth Then
                lastColumn.Width = availableWidthForLastColumn
            ElseIf minLastColumnHeaderWidth > 0 Then ' Si el encabezado tiene algún ancho
                lastColumn.Width = minLastColumnHeaderWidth
            Else
                ' Si el espacio disponible es muy pequeño y el encabezado también,
                ' se podría ajustar al contenido o un mínimo.
                lastColumn.Width = -2 ' Ajustar al contenido como fallback
            End If

            ' Asegurarse de que la última columna no tenga un ancho negativo.
            If lastColumn.Width < 0 AndAlso minLastColumnHeaderWidth > 0 Then
                lastColumn.Width = minLastColumnHeaderWidth
            ElseIf lastColumn.Width < 0 Then
                lastColumn.Width = 50 ' Un valor mínimo por defecto si todo falla
            End If
        End If
    End Sub
End Class