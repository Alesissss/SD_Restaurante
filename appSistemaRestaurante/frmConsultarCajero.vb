Imports libNegocio

Public Class frmConsultarCajero
    Dim objCaj As New clsCajero
    Public Property FormularioPadre As frmTransaPago
    Private Sub frmConsultarCajero_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        listarCajeros()
    End Sub
    Private Sub listarCajeros()
        Dim dtCajero As New DataTable
        Dim ind As Integer = 0
        Try

            'Llenar el listView'
            dtCajero = objCaj.listarCajerosVigentes()
            For Each mesero In dtCajero.Rows
                lsvCajeros.Items.Add(dtCajero.Rows(ind).Item(0))
                lsvCajeros.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(1))
                lsvCajeros.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(2) + " " + dtCajero.Rows(ind).Item(3))
                lsvCajeros.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(4))
                lsvCajeros.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(5))
                lsvCajeros.Items(ind).SubItems.Add(dtCajero.Rows(ind).Item(6))
                ind += 1
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
    Private Sub lsvCajeros_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvCajeros.MouseDoubleClick
        Try
            If lsvCajeros.SelectedItems.Count > 0 Then
                Dim selectedItem As ListViewItem = lsvCajeros.SelectedItems(0)

                ' Obtener datos del item seleccionado
                Dim idCajero As String = If(selectedItem.Tag IsNot Nothing, selectedItem.Tag.ToString(), selectedItem.Text)

                If FormularioPadre IsNot Nothing Then
                    ' Asignar el ID del cajero
                    FormularioPadre.txtIDCajero.Text = idCajero

                    Me.Close() ' Cerrar el formulario de listado de mesas
                Else
                    MessageBox.Show("No se ha especificado un formulario de destino para los datos.", "Error de Programación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message, "SIST-REST 2025", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    ' Tu método AjustarAnchoColumnasListView (sin cambios, igual al que proporcionaste anteriormente)
    Private Sub AjustarAnchoColumnasListView()
        If lsvCajeros Is Nothing OrElse lsvCajeros.View <> View.Details OrElse lsvCajeros.Columns.Count = 0 Then
            Return
        End If
        Dim totalWidthOfPreviousColumns As Integer = 0
        Dim scrollBarWidth As Integer = 0
        If lsvCajeros.Items.Count > 0 AndAlso lsvCajeros.Scrollable Then
            If lsvCajeros.Items(lsvCajeros.Items.Count - 1).Bounds.Bottom > lsvCajeros.ClientSize.Height Then
                scrollBarWidth = SystemInformation.VerticalScrollBarWidth
            End If
        End If
        If lsvCajeros.Columns.Count > 1 Then
            For i As Integer = 0 To lsvCajeros.Columns.Count - 2
                lsvCajeros.Columns(i).Width = -2 ' Autoajuste basado en contenido y cabecera
                totalWidthOfPreviousColumns += lsvCajeros.Columns(i).Width
            Next
        End If
        Dim lastColumnIndex As Integer = lsvCajeros.Columns.Count - 1
        If lastColumnIndex >= 0 Then
            Dim lastColumn As ColumnHeader = lsvCajeros.Columns(lastColumnIndex)
            Dim availableWidthForLastColumn As Integer = lsvCajeros.ClientSize.Width - totalWidthOfPreviousColumns - scrollBarWidth
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