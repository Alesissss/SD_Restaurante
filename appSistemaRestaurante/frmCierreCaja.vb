Public Class frmCierreCaja
    Private Sub frmCierreCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblNumArqueo.Text = "0"
        lblNumArqueo.ReadOnly = True

        ' Asignar usuario desde el formulario principal
        lblUsuario.Text = frmMDIPrincipal.lblUsuario.Text
        lblUsuario.ReadOnly = True

        ' Asignar fecha actual
        dtpFechaApertura.Value = Date.Now
        dtpFechaApertura.Enabled = False

        ' Moneda fija
        txtMoneda.Text = "Soles"
        txtMoneda.ReadOnly = True

        ' Cargar filas en el DataGridView
        InicializarDenominaciones()
        pintarFrm(dgvDetalles)
    End Sub
    Public Sub pintarFrm(dgv As DataGridView)
        'Pintar algunos paneles
        pnlBotones.BackColor = ColorTranslator.FromHtml("#FFFFFF")
        'Estilo de botones
        For Each ctrl As Control In pnlBotones.Controls
            If TypeOf ctrl Is Button Then
                Dim btn As Button = DirectCast(ctrl, Button)
                btn.FlatStyle = FlatStyle.Flat
                btn.UseVisualStyleBackColor = False '
                btn.FlatAppearance.BorderSize = 0
                btn.BackColor = ColorTranslator.FromHtml("#413732")
                btn.ForeColor = Color.White
                btn.Font = New Font("MS Reference Sans Serif", 8, FontStyle.Regular)
            End If
        Next

        'Estilizar tabla
        dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv.AllowUserToAddRows = False

        dgv.DefaultCellStyle.Font = New Font("MS Reference Sans Serif", 8)
        dgv.DefaultCellStyle.BackColor = Color.White
        dgv.ColumnHeadersDefaultCellStyle.Font = New Font("MS Reference Sans Serif", 8, FontStyle.Bold)
        dgv.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#2E201D")
        dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgv.EnableHeadersVisualStyles = False
        dgv.CellBorderStyle = DataGridViewCellBorderStyle.None
        dgv.GridColor = Color.LightGray

    End Sub

    Private Sub cmbCaja_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCaja.SelectedIndexChanged
        If cmbCaja.SelectedIndex <> -1 Then
            pnlCargar.Visible = True
            'CargarDatosCaja(cmbCaja.SelectedValue) ' Supone que usas DataSource
        Else
            pnlCargar.Visible = False
        End If
    End Sub
    Private Sub CalcularMontoTotal()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvDetalles.Rows
            total += Convert.ToDecimal(row.Cells("Subtotal").Value)
        Next

        lblMontoTotal.Text = total.ToString("N2")
        lblMontoTotalTexto.Text = NumeroATexto(total)
    End Sub
    Private Sub InicializarDenominaciones()
        With dgvDetalles
            .Columns.Clear()
            .Columns.Add("Denominacion", "Denominación")
            .Columns.Add("Cantidad", "Cantidad")
            .Columns.Add("Subtotal", "Subtotal")

            .Rows.Add("Billete de S/200")
            .Rows.Add("Billete de S/100")
            .Rows.Add("Billete de S/50")
            .Rows.Add("Billete de S/20")
            .Rows.Add("Billete de S/10")
            .Rows.Add("Moneda de S/5")
            .Rows.Add("Moneda de S/2")
            .Rows.Add("Moneda de S/1")
            .Rows.Add("Moneda de 0.20")
            .Rows.Add("Moneda de 0.10")

            For Each row As DataGridViewRow In .Rows
                row.Cells("Cantidad").Value = 0
                row.Cells("Subtotal").Value = "0.00"
            Next
        End With
    End Sub


    Private Function ObtenerValorMoneda(denominacion As String) As Decimal
        Select Case denominacion
            Case "Billete de S/200" : Return 200
            Case "Billete de S/100" : Return 100
            Case "Billete de S/50" : Return 50
            Case "Billete de S/20" : Return 20
            Case "Billete de S/10" : Return 10
            Case "Moneda de S/5" : Return 5
            Case "Moneda de S/2" : Return 2
            Case "Moneda de S/1" : Return 1
            Case "Moneda de 0.20" : Return 0.2D
            Case "Moneda de 0.10" : Return 0.1D
            Case Else : Return 0
        End Select
    End Function

    Private Sub dgvDetalles_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgvDetalles.CellEndEdit
        If e.ColumnIndex = dgvDetalles.Columns("Cantidad").Index Then
            Dim cantidad As Integer = 0
            Integer.TryParse(dgvDetalles.Rows(e.RowIndex).Cells("Cantidad").Value.ToString(), cantidad)

            Dim denominacionTexto As String = dgvDetalles.Rows(e.RowIndex).Cells("Denominacion").Value.ToString()
            Dim valorMoneda As Decimal = ObtenerValorMoneda(denominacionTexto)

            Dim subtotal As Decimal = valorMoneda * cantidad
            dgvDetalles.Rows(e.RowIndex).Cells("Subtotal").Value = subtotal.ToString("N2")

            CalcularMontoTotal()
        End If
    End Sub

    Public Function NumeroATexto(ByVal numero As Decimal) As String
        Dim enteros As Long = Math.Truncate(numero)
        Dim decimales As Integer = CInt((numero - enteros) * 100)

        Dim textoEntero As String = ConvertirNumero(enteros)
        Dim textoDecimal As String = If(decimales > 0, " CON " & decimales.ToString("00") & "/100", "")

        Return textoEntero & textoDecimal & " SOLES"
    End Function

    Private Function ConvertirNumero(ByVal numero As Long) As String
        If numero = 0 Then Return "CERO"

        Dim unidades() As String = {"", "UNO", "DOS", "TRES", "CUATRO", "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ", "ONCE", "DOCE", "TRECE", "CATORCE", "QUINCE"}
        Dim decenas() As String = {"", "", "VEINTE", "TREINTA", "CUARENTA", "CINCUENTA", "SESENTA", "SETENTA", "OCHENTA", "NOVENTA"}
        Dim centenas() As String = {"", "CIENTO", "DOSCIENTOS", "TRESCIENTOS", "CUATROCIENTOS", "QUINIENTOS", "SEISCIENTOS", "SETECIENTOS", "OCHOCIENTOS", "NOVECIENTOS"}

        Dim texto As String = ""
        Dim millones As Long = numero \ 1000000
        numero = numero Mod 1000000
        Dim miles As Long = numero \ 1000
        numero = numero Mod 1000
        Dim cientos As Long = numero

        If millones > 0 Then
            If millones = 1 Then
                texto &= "UN MILLÓN "
            Else
                texto &= ConvertirNumero(millones) & " MILLONES "
            End If
        End If

        If miles > 0 Then
            If miles = 1 Then
                texto &= "MIL "
            Else
                texto &= ConvertirNumero(miles) & " MIL "
            End If
        End If

        If cientos > 0 Then
            If cientos = 100 Then
                texto &= "CIEN"
            Else
                Dim c As Integer = cientos \ 100
                Dim d As Integer = (cientos Mod 100) \ 10
                Dim u As Integer = cientos Mod 10
                Dim resto As Integer = cientos Mod 100

                If resto <= 15 Then
                    texto &= centenas(c)
                    If resto > 0 Then texto &= " " & unidades(resto)
                ElseIf resto < 20 Then
                    texto &= centenas(c) & " DIECI" & unidades(u).ToLower()
                ElseIf resto < 30 Then
                    texto &= centenas(c) & " VEINTI" & unidades(u).ToLower()
                Else
                    texto &= centenas(c)
                    If d > 0 Then texto &= " " & decenas(d)
                    If u > 0 Then texto &= " Y " & unidades(u)
                End If
            End If
        End If

        Return texto.Trim()
    End Function




End Class