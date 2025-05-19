Imports libNegocio
Imports System.Windows.Forms

Public Class frmConsultarPedidosVigentes
    Dim objPed As New clsPedido
    ' Dim dtMes As New DataTable ' Declarada en tu código original, la mantenemos.

    ' Para mantener una referencia al formulario que llama (frmTransaPedido)
    Public Property FormularioPadre As frmTransaPago

    Private Sub frmConsultarPedidosVigentes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvPedidos.View = View.Details
        lsvPedidos.FullRowSelect = True
        lsvPedidos.GridLines = True
        lsvPedidos.Columns.Clear()

        ' --- COLUMNAS DEL LISTVIEW PARA MOSTRAR PEDIDOS ---
        lsvPedidos.Columns.Add("ID Pedido", 80)
        lsvPedidos.Columns.Add("Fecha", 120)
        lsvPedidos.Columns.Add("Monto", 80)
        lsvPedidos.Columns.Add("Estado Pedido", 100)
        lsvPedidos.Columns.Add("Estado Pago", 100)
        lsvPedidos.Columns.Add("ID Mesero", 80)
        lsvPedidos.Columns.Add("N° Mesa", 80)

        listarPedidos()
    End Sub

    Private Sub listarPedidos()
        Try
            Dim dtPedidos As DataTable = objPed.listarPedidosVigentes()
            lsvPedidos.Items.Clear()

            If dtPedidos IsNot Nothing AndAlso dtPedidos.Rows.Count > 0 Then
                For Each fila As DataRow In dtPedidos.Rows
                    ' Lectura de columnas reales
                    Dim idPedido As String = If(Not fila.IsNull("idPedido"), fila("idPedido").ToString(), "")
                    Dim fecha As String = If(Not fila.IsNull("fecha"), Convert.ToDateTime(fila("fecha")).ToString("dd/MM/yyyy HH:mm"), "")
                    Dim monto As String = If(Not fila.IsNull("monto"), Convert.ToDecimal(fila("monto")).ToString("F2"), "")
                    Dim estadoPedido As String = "Desconocido"
                    If Not fila.IsNull("estadoPedido") Then
                        estadoPedido = If(Convert.ToInt32(fila("estadoPedido")) = 0, "Finalizado", "Pendiente")
                    End If
                    Dim estadoPago As String = "Desconocido"
                    If Not fila.IsNull("estadoPago") Then
                        estadoPago = If(Convert.ToInt32(fila("estadoPago")) = 0, "Pagado", "Pendiente")
                    End If
                    Dim idMesero As String = If(Not fila.IsNull("idMesero"), fila("idMesero").ToString(), "")
                    Dim numeroMesa As String = If(Not fila.IsNull("numeroMesa"), fila("numeroMesa").ToString(), "")

                    ' Crear el ListViewItem
                    Dim item As New ListViewItem(idPedido)
                    item.Tag = idPedido ' útil para operaciones posteriores

                    item.SubItems.Add(fecha)
                    item.SubItems.Add(monto)
                    item.SubItems.Add(estadoPedido)
                    item.SubItems.Add(estadoPago)
                    item.SubItems.Add(idMesero)
                    item.SubItems.Add(numeroMesa)

                    lsvPedidos.Items.Add(item)
                Next
            Else
                Dim itemVacio As New ListViewItem("No hay pedidos para mostrar.")
                itemVacio.SubItems.Add("") ' Fecha
                itemVacio.SubItems.Add("") ' Monto
                itemVacio.SubItems.Add("") ' EstadoPedido
                itemVacio.SubItems.Add("") ' EstadoPago
                itemVacio.SubItems.Add("") ' IdMesero
                itemVacio.SubItems.Add("") ' NumeroMesa
                lsvPedidos.Items.Add(itemVacio)
            End If

            AjustarAnchoColumnasListView()

        Catch ex As Exception
            MessageBox.Show("Error al listar los pedidos:" & vbCrLf & ex.Message,
                        "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub lsvPedidos_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles lsvPedidos.MouseDoubleClick
        If lsvPedidos.SelectedItems.Count > 0 Then
            Dim selectedItem As ListViewItem = lsvPedidos.SelectedItems(0)

            ' Obtener el idPedido (lo guardamos tanto en .Text como en .Tag)
            Dim idPedido As String = If(selectedItem.Tag IsNot Nothing, selectedItem.Tag.ToString(), selectedItem.Text)
            Dim montoTotal As String = selectedItem.SubItems(2).Text
            Dim estadoPedido As String = selectedItem.SubItems(3).Text

            If FormularioPadre IsNot Nothing Then
                ' Asignar el idPedido al TextBox del formulario padre
                FormularioPadre.txtIDPedido.Text = idPedido
                FormularioPadre.txtTotalPed.Text = montoTotal
                FormularioPadre.lblEstado.Text = estadoPedido

                Me.Close() ' Cerrar el formulario actual
            Else
                MessageBox.Show("No se ha especificado un formulario de destino para los datos.",
                            "Error de Programación", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    ' Tu método AjustarAnchoColumnasListView (sin cambios, igual al que proporcionaste anteriormente)
    Private Sub AjustarAnchoColumnasListView()
        If lsvPedidos Is Nothing OrElse lsvPedidos.View <> View.Details OrElse lsvPedidos.Columns.Count = 0 Then
            Return
        End If
        Dim totalWidthOfPreviousColumns As Integer = 0
        Dim scrollBarWidth As Integer = 0
        If lsvPedidos.Items.Count > 0 AndAlso lsvPedidos.Scrollable Then
            If lsvPedidos.Items(lsvPedidos.Items.Count - 1).Bounds.Bottom > lsvPedidos.ClientSize.Height Then
                scrollBarWidth = SystemInformation.VerticalScrollBarWidth
            End If
        End If
        If lsvPedidos.Columns.Count > 1 Then
            For i As Integer = 0 To lsvPedidos.Columns.Count - 2
                lsvPedidos.Columns(i).Width = -2 ' Autoajuste basado en contenido y cabecera
                totalWidthOfPreviousColumns += lsvPedidos.Columns(i).Width
            Next
        End If
        Dim lastColumnIndex As Integer = lsvPedidos.Columns.Count - 1
        If lastColumnIndex >= 0 Then
            Dim lastColumn As ColumnHeader = lsvPedidos.Columns(lastColumnIndex)
            Dim availableWidthForLastColumn As Integer = lsvPedidos.ClientSize.Width - totalWidthOfPreviousColumns - scrollBarWidth
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