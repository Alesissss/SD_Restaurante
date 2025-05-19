Imports libNegocio
Imports System.Windows.Forms
Imports System.Globalization

Public Class frmConsultarCarta
    Private objPro As New clsProducto()
    Private isAdjustingColumns As Boolean = False

    Private dtProductosActuales As DataTable
    Private currentIdCartaMostrada As Integer
    Private Const MSG_NO_PRODUCTOS As String = "No hay productos registrados para esta carta."

    Private Sub frmConsultarCarta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvCarta.View = View.Details
        lsvCarta.GridLines = True
        lsvCarta.FullRowSelect = True
        lsvCarta.MultiSelect = False

        lsvCarta.Columns.Clear()
        lsvCarta.Columns.Add("Tipo producto", 200, HorizontalAlignment.Left)
        lsvCarta.Columns.Add("Nombre", 200, HorizontalAlignment.Left)
        lsvCarta.Columns.Add("Descripción", 300, HorizontalAlignment.Left)
        lsvCarta.Columns.Add("Precio", 100, HorizontalAlignment.Right)
        Me.lsvCarta.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right Or AnchorStyles.Bottom)

        AddHandler Me.lsvCarta.Resize, AddressOf LsvProductos_ResizeHandler
        AddHandler Me.lsvCarta.ItemActivate, AddressOf LsvCarta_ItemActivate_Handler ' Para manejar doble clic o Enter
    End Sub

    Private Sub SetCartaButtonsEnabled(enabled As Boolean)
        If Me.Controls.ContainsKey("btnCarta1") Then DirectCast(Me.Controls("btnCarta1"), Button).Enabled = enabled
        If Me.Controls.ContainsKey("btnCarta2") Then DirectCast(Me.Controls("btnCarta2"), Button).Enabled = enabled
        ' Añade más botones si es necesario
    End Sub

    Private Sub listarProductosDeCarta(ByVal idCartaParaMostrar As Integer)
        If isAdjustingColumns Then Return

        SetCartaButtonsEnabled(False)
        Me.Cursor = Cursors.WaitCursor

        Me.currentIdCartaMostrada = idCartaParaMostrar
        lsvCarta.Items.Clear()
        Me.dtProductosActuales = Nothing

        Try
            Me.dtProductosActuales = objPro.ListarProductosPorIdCarta(idCartaParaMostrar)
            lsvCarta.BeginUpdate()

            If Me.dtProductosActuales IsNot Nothing AndAlso Me.dtProductosActuales.Rows.Count > 0 Then
                If Not (Me.dtProductosActuales.Columns.Contains("tipo_producto") AndAlso
                        Me.dtProductosActuales.Columns.Contains("nombre") AndAlso
                        Me.dtProductosActuales.Columns.Contains("descripcion") AndAlso
                        Me.dtProductosActuales.Columns.Contains("precio")) Then
                    MessageBox.Show("Faltan columnas esenciales (tipo_producto, nombre, descripcion, precio) en los datos de la carta. Contacte al administrador.",
                                    "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If

                For Each fila As DataRow In Me.dtProductosActuales.Rows
                    Dim tipoProducto As String = If(fila.IsNull("tipo_producto"), String.Empty, fila.Item("tipo_producto").ToString())
                    Dim nombreProducto As String = If(fila.IsNull("nombre"), String.Empty, fila.Item("nombre").ToString())
                    Dim descProducto As String = If(fila.IsNull("descripcion"), String.Empty, fila.Item("descripcion").ToString())
                    Dim precioProductoStr As String
                    Dim precioDecimal As Decimal = 0D

                    If fila.IsNull("precio") Then
                        precioProductoStr = "0.00"
                    ElseIf TypeOf fila.Item("precio") Is Decimal Then
                        precioDecimal = DirectCast(fila.Item("precio"), Decimal)
                        precioProductoStr = precioDecimal.ToString("N2")
                    Else
                        If Decimal.TryParse(fila.Item("precio").ToString(), NumberStyles.Any, CultureInfo.InvariantCulture, precioDecimal) Then
                            precioProductoStr = precioDecimal.ToString("N2")
                        Else
                            precioProductoStr = fila.Item("precio").ToString()
                        End If
                    End If

                    Dim item As New ListViewItem(tipoProducto)
                    item.SubItems.Add(nombreProducto)
                    item.SubItems.Add(descProducto)
                    item.SubItems.Add(precioProductoStr)
                    lsvCarta.Items.Add(item)
                Next
            Else
                Dim itemVacio As New ListViewItem(MSG_NO_PRODUCTOS)
                itemVacio.SubItems.Add("-")
                itemVacio.SubItems.Add("-")
                itemVacio.SubItems.Add("-")
                lsvCarta.Items.Add(itemVacio)
            End If
        Catch ex As Exception
            MessageBox.Show("Error al listar los productos de la carta (ID: " & idCartaParaMostrar & "): " & vbCrLf & ex.Message,
                            "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            lsvCarta.EndUpdate()
            AjustarAnchoColumnasListView()
            Me.Cursor = Cursors.Default
            SetCartaButtonsEnabled(True)
        End Try
    End Sub

    Private Sub LsvCarta_ItemActivate_Handler(sender As Object, e As EventArgs) Handles lsvCarta.ItemActivate
        If lsvCarta.SelectedItems.Count > 0 Then
            Dim selectedListViewItem As ListViewItem = lsvCarta.SelectedItems(0)
            Dim selectedIndex As Integer = selectedListViewItem.Index

            If Me.dtProductosActuales IsNot Nothing AndAlso selectedIndex >= 0 AndAlso selectedIndex < Me.dtProductosActuales.Rows.Count Then
                Dim filaProductoSeleccionado As DataRow = Me.dtProductosActuales.Rows(selectedIndex)

                If Not filaProductoSeleccionado.Table.Columns.Contains("nombre") Then
                    MessageBox.Show("Información del producto incompleta (falta nombre).", "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Return
                End If

                Dim nombreProducto As String = If(filaProductoSeleccionado.IsNull("nombre"), "[Sin Nombre]", filaProductoSeleccionado.Item("nombre").ToString())

                MessageBox.Show($"Producto seleccionado: {nombreProducto}", "Producto Seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                If Not selectedListViewItem.Text.StartsWith(MSG_NO_PRODUCTOS) Then
                    MessageBox.Show("Por favor, seleccione un producto válido de la lista.", "Selección Inválida", MessageBoxButtons.OK, MessageBoxIcon.Information)
                End If
            End If
        End If
    End Sub

    Private Sub AjustarAnchoColumnasListView()
        If isAdjustingColumns Then Return
        If lsvCarta Is Nothing OrElse lsvCarta.View <> View.Details OrElse lsvCarta.Columns.Count = 0 Then
            Return
        End If

        isAdjustingColumns = True
        lsvCarta.BeginUpdate()

        Try
            Dim totalWidthOfPreviousColumns As Integer = 0
            Dim scrollBarWidthAsInteger As Integer = 0

            If lsvCarta.Items.Count > 0 AndAlso lsvCarta.Scrollable Then
                Dim lastItem As ListViewItem = lsvCarta.Items(lsvCarta.Items.Count - 1)
                If lastItem.Bounds.Bottom + CInt(lsvCarta.Font.Height * 0.75) > lsvCarta.ClientSize.Height Then
                    scrollBarWidthAsInteger = SystemInformation.VerticalScrollBarWidth
                End If
            End If

            If lsvCarta.Columns.Count > 1 Then
                For i As Integer = 0 To lsvCarta.Columns.Count - 2
                    lsvCarta.Columns(i).Width = -2
                    totalWidthOfPreviousColumns += lsvCarta.Columns(i).Width
                Next
            End If

            Dim lastColumnIndex As Integer = lsvCarta.Columns.Count - 1
            If lastColumnIndex >= 0 Then
                Dim lastColumn As ColumnHeader = lsvCarta.Columns(lastColumnIndex)
                Dim availableWidthForLastColumn As Integer = lsvCarta.ClientSize.Width - totalWidthOfPreviousColumns - scrollBarWidthAsInteger

                Dim minLastColumnHeaderWidth As Integer
                Using g As Graphics = lsvCarta.CreateGraphics()
                    minLastColumnHeaderWidth = CInt(g.MeasureString(lastColumn.Text, lsvCarta.Font).Width) + 25
                End Using

                If availableWidthForLastColumn > minLastColumnHeaderWidth Then
                    lastColumn.Width = availableWidthForLastColumn
                Else
                    lastColumn.Width = -2
                    If lastColumn.Width < minLastColumnHeaderWidth Then
                        lastColumn.Width = minLastColumnHeaderWidth
                    End If
                    Dim minAbsoluteWidth As Integer = 75
                    If lastColumn.Width < minAbsoluteWidth AndAlso availableWidthForLastColumn > minAbsoluteWidth Then
                        lastColumn.Width = minAbsoluteWidth
                    ElseIf lastColumn.Width < minAbsoluteWidth AndAlso availableWidthForLastColumn <= minAbsoluteWidth AndAlso availableWidthForLastColumn > 0 Then
                        lastColumn.Width = availableWidthForLastColumn
                    ElseIf availableWidthForLastColumn <= 0 Then
                        lastColumn.Width = minAbsoluteWidth
                    End If
                End If
            End If
        Finally
            lsvCarta.EndUpdate()
            isAdjustingColumns = False
        End Try
    End Sub

    Private Sub LsvProductos_ResizeHandler(sender As Object, e As EventArgs) Handles lsvCarta.Resize
        If Not isAdjustingColumns Then
            AjustarAnchoColumnasListView()
        End If
    End Sub

    Private Sub btnCarta1_Click(sender As Object, e As EventArgs) Handles btnCarta1.Click
        listarProductosDeCarta(1)
    End Sub

    Private Sub btnCarta2_Click(sender As Object, e As EventArgs) Handles btnCarta2.Click
        listarProductosDeCarta(2)
    End Sub

    ' ... (otros botones de carta)
End Class