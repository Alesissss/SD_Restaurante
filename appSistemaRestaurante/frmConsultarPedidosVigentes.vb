Imports libNegocio
Imports System.Windows.Forms

Public Class frmConsultarPedidosVigentes
    Dim objMes As New clsMesa
    ' Dim dtMes As New DataTable ' Declarada en tu código original, la mantenemos.

    ' Para mantener una referencia al formulario que llama (frmTransaPedido)
    Public Property FormularioPadre As frmTransaPedido

    Private Sub frmListadoMesas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvMesas.View = View.Details
        lsvMesas.FullRowSelect = True
        lsvMesas.GridLines = True
        lsvMesas.Columns.Clear()

        ' --- COLUMNAS DEL LISTVIEW ACTUALIZADAS ---
        lsvMesas.Columns.Add("ID Mesa", 80)      ' O "N° Mesa"
        lsvMesas.Columns.Add("Capacidad", 100)   ' O "Capacidad"
        lsvMesas.Columns.Add("Estado", 100)

        listarMesas()
    End Sub

    Private Sub listarMesas()
        Try
            Dim dtDatosMesas As DataTable = objMes.listarMesas()
            lsvMesas.Items.Clear()

            If dtDatosMesas IsNot Nothing AndAlso dtDatosMesas.Rows.Count > 0 Then
                For Each fila As DataRow In dtDatosMesas.Rows
                    ' --- LECTURA DE DATOS ACTUALIZADA SEGÚN NUEVAS COLUMNAS ---
                    ' Asumimos que el DataTable de objMes.listarMesas() devuelve:
                    ' "idMesa" (el ID/Número de la mesa)
                    ' "cantidad" (la capacidad de la mesa)
                    ' "estado" (un valor Booleano para Vigente/No Vigente)

                    Dim idMesaActual As String = String.Empty
                    If Not fila.IsNull("idMesa") Then ' Asegúrate que "idMesa" sea el nombre correcto de tu columna
                        idMesaActual = fila.Item("idMesa").ToString()
                    End If

                    Dim cantidadMesa As String = String.Empty
                    If Not fila.IsNull("capacidad") Then ' Asegúrate que "cantidad" sea el nombre correcto
                        cantidadMesa = fila.Item("capacidad").ToString()
                    End If

                    Dim estadoMesaStr As String = "No Vigente" ' Valor por defecto
                    If Not fila.IsNull("estado") Then ' Asegúrate que "estado" sea el nombre correcto
                        Try
                            If Convert.ToBoolean(fila.Item("estado")) Then
                                estadoMesaStr = "Vigente"
                            End If
                        Catch exConv As Exception
                            ' Console.WriteLine($"Error convirtiendo estado para mesa {idMesaActual}: {exConv.Message}")
                        End Try
                    End If

                    ' El primer texto del item es idMesaActual
                    Dim item As New ListViewItem(idMesaActual)
                    ' Guardamos el idMesaActual también en Tag por si se necesita una referencia no formateada
                    item.Tag = idMesaActual

                    ' Añadimos los subitems: cantidad y estado
                    item.SubItems.Add(cantidadMesa)  ' Este es SubItems(1)
                    item.SubItems.Add(estadoMesaStr)   ' Este es SubItems(2)

                    lsvMesas.Items.Add(item)
                Next
            Else
                Dim itemVacio As New ListViewItem("No hay mesas para mostrar.")
                itemVacio.SubItems.Add("") ' Para columna Cantidad
                itemVacio.SubItems.Add("") ' Para columna Estado
                lsvMesas.Items.Add(itemVacio)
            End If

            AjustarAnchoColumnasListView()

        Catch ex As Exception
            MessageBox.Show("Error al listar las mesas:" & vbCrLf & ex.Message,
                            "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lsvMesas_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvMesas.MouseDoubleClick
        If lsvMesas.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = lsvMesas.SelectedItems(0)

            ' Obtener datos del item seleccionado
            ' El ID de la mesa se guardó en la propiedad Tag (y también es el texto principal del item)
            Dim idMesa As String = If(selectedItem.Tag IsNot Nothing, selectedItem.Tag.ToString(), selectedItem.Text)

            ' selectedItem.SubItems(1).Text es "Cantidad" (Capacidad)
            Dim capacidadMesa As String = selectedItem.SubItems(1).Text

            ' selectedItem.SubItems(2).Text es "Estado"
            Dim estadoMesa As String = selectedItem.SubItems(2).Text

            If FormularioPadre IsNot Nothing Then
                ' Asignar el ID de la mesa
                FormularioPadre.txtNumMesa.Text = idMesa

                ' --- NUEVA LÍNEA PARA ASIGNAR LA CAPACIDAD ---
                FormularioPadre.txtCapMesa.Text = capacidadMesa
                ' ----------------------------------------------

                ' Asignar el estado de la mesa al Label lblEstado
                Try
                    ' Intenta encontrar el control lblEstado en el formulario padre
                    Dim lbl As Label = Nothing
                    Dim foundControls() As Control = FormularioPadre.Controls.Find("lblEstado", True)

                    If foundControls.Length > 0 Then
                        lbl = DirectCast(foundControls(0), Label)
                    End If

                    If lbl IsNot Nothing Then
                        lbl.Text = estadoMesa
                    Else
                        MessageBox.Show("No se encontró el control 'lblEstado' en el formulario de pedido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        ' Considera si quieres mostrar el estado en chkEstadoMesa si lblEstado no existe
                        ' Dim chk As CheckBox = DirectCast(FormularioPadre.Controls.Find("chkEstadoMesa", True).FirstOrDefault(), CheckBox)
                        ' If chk IsNot Nothing Then
                        ' chk.Checked = (estadoMesa.ToLower() = "vigente")
                        ' End If
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error al actualizar lblEstado en el formulario de pedido: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try

                Me.Close() ' Cerrar el formulario de listado de mesas
            Else
                MessageBox.Show("No se ha especificado un formulario de destino para los datos.", "Error de Programación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    ' Tu método AjustarAnchoColumnasListView (sin cambios, igual al que proporcionaste anteriormente)
    Private Sub AjustarAnchoColumnasListView()
        If lsvMesas Is Nothing OrElse lsvMesas.View <> View.Details OrElse lsvMesas.Columns.Count = 0 Then
            Return
        End If
        Dim totalWidthOfPreviousColumns As Integer = 0
        Dim scrollBarWidth As Integer = 0
        If lsvMesas.Items.Count > 0 AndAlso lsvMesas.Scrollable Then
            If lsvMesas.Items(lsvMesas.Items.Count - 1).Bounds.Bottom > lsvMesas.ClientSize.Height Then
                scrollBarWidth = SystemInformation.VerticalScrollBarWidth
            End If
        End If
        If lsvMesas.Columns.Count > 1 Then
            For i As Integer = 0 To lsvMesas.Columns.Count - 2
                lsvMesas.Columns(i).Width = -2 ' Autoajuste basado en contenido y cabecera
                totalWidthOfPreviousColumns += lsvMesas.Columns(i).Width
            Next
        End If
        Dim lastColumnIndex As Integer = lsvMesas.Columns.Count - 1
        If lastColumnIndex >= 0 Then
            Dim lastColumn As ColumnHeader = lsvMesas.Columns(lastColumnIndex)
            Dim availableWidthForLastColumn As Integer = lsvMesas.ClientSize.Width - totalWidthOfPreviousColumns - scrollBarWidth
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