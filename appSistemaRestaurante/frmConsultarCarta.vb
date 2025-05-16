Imports libNegocio

Public Class frmConsultarCarta
    Private objPro As New clsProducto()
    Private Sub frmConsultarCarta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lsvCarta.View = View.Details
        lsvCarta.GridLines = True
        lsvCarta.FullRowSelect = True
        lsvCarta.MultiSelect = False

        lsvCarta.Columns.Clear()
        lsvCarta.Columns.Add("Nombre", 200, HorizontalAlignment.Left)
        lsvCarta.Columns.Add("Descripción", 300, HorizontalAlignment.Left)
        lsvCarta.Columns.Add("Precio", 100, HorizontalAlignment.Right)
        Me.lsvCarta.Anchor = (AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right)
        AddHandler Me.lsvCarta.Resize, AddressOf LsvProductos_ResizeHandler
    End Sub
    Private Sub listarProductosDeCarta(ByVal idCartaParaMostrar As Integer)
        Try
            Dim dtProductos As DataTable = objPro.ListarProductosPorIdCarta(idCartaParaMostrar)

            lsvCarta.Items.Clear()

            If dtProductos IsNot Nothing AndAlso dtProductos.Rows.Count > 0 Then
                For Each fila As DataRow In dtProductos.Rows
                    Dim nombreProducto As String = If(fila.IsNull("nombre"), String.Empty, fila.Item("nombre").ToString())
                    Dim descProducto As String = If(fila.IsNull("descripcion"), String.Empty, fila.Item("descripcion").ToString())
                    Dim precioProductoStr As String

                    If fila.IsNull("precio") Then
                        precioProductoStr = String.Empty
                    ElseIf TypeOf fila.Item("precio") Is Decimal Then
                        precioProductoStr = DirectCast(fila.Item("precio"), Decimal).ToString("N2")
                    Else
                        precioProductoStr = fila.Item("precio").ToString()
                    End If

                    Dim item As New ListViewItem(nombreProducto)
                    item.SubItems.Add(descProducto)
                    item.SubItems.Add(precioProductoStr)

                    lsvCarta.Items.Add(item)
                Next
            Else
                Dim itemVacio As New ListViewItem("No hay productos registrados para esta carta.")
                itemVacio.SubItems.Add("")
                itemVacio.SubItems.Add("")
                lsvCarta.Items.Add(itemVacio)
            End If

            AjustarAnchoColumnasListView()

        Catch ex As Exception
            MessageBox.Show("Error al listar los productos de la carta (ID: " & idCartaParaMostrar & "): " & vbCrLf & ex.Message,
                            "Error de Carga", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub AjustarAnchoColumnasListView()
        If lsvCarta Is Nothing OrElse lsvCarta.View <> View.Details OrElse lsvCarta.Columns.Count = 0 Then
            Return
        End If

        Dim totalWidthOfPreviousColumns As Integer = 0
        Dim scrollBarWidthAsInteger As Integer = 0

        If lsvCarta.Items.Count > 0 AndAlso lsvCarta.Scrollable Then
            If lsvCarta.Items(lsvCarta.Items.Count - 1).Bounds.Bottom > lsvCarta.ClientSize.Height Then
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

            Dim currentLastColWidth As Integer = lastColumn.Width
            lastColumn.Width = -1
            Dim minLastColumnHeaderWidth As Integer = lastColumn.Width
            lastColumn.Width = currentLastColWidth

            If availableWidthForLastColumn > minLastColumnHeaderWidth Then
                lastColumn.Width = availableWidthForLastColumn
            Else
                lastColumn.Width = minLastColumnHeaderWidth
            End If
        End If
    End Sub

    Private Sub LsvProductos_ResizeHandler(sender As Object, e As EventArgs)
        AjustarAnchoColumnasListView()
    End Sub

    Private Sub btnCarta1_Click(sender As Object, e As EventArgs) Handles btnCarta1.Click
        listarProductosDeCarta(1)
    End Sub

    Private Sub btnCarta2_Click(sender As Object, e As EventArgs) Handles btnCarta2.Click
        listarProductosDeCarta(2)
    End Sub

    ' ... sumar + cartas en el caso que existan mas

End Class