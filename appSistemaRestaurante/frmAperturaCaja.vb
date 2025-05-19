Imports libNegocio
Imports libDatos
Public Class frmAperturaCaja
    Dim objUsuario As New clsUsuario
    Dim objFrmInicio As New frmInicioSesion
    Dim objCajero As New clsCajero
    Dim objConexion As clsConectaBD
    Private Sub frmAperturaCaja_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        listarTipos()
        InicializarDenominaciones()
        pintarFrm(dgvDetalles)

    End Sub

    Private Sub listarTipos()
        Try
            Dim dtTipo As DataTable
            dtTipo = objCajero.listarCajeros()

            cmbCaja.DataSource = dtTipo
            cmbCaja.DisplayMember = "nombre"
            cmbCaja.ValueMember = "idCajero"
            cmbCaja.SelectedIndex = -1
        Catch ex As Exception
            MessageBox.Show("Error al cargar los cajeros: " & ex.Message)
        End Try
    End Sub
    Public Sub pintarFrm(dgv As DataGridView)
        'Pintar algunos paneles
        pnlDatos.BackColor = ColorTranslator.FromHtml("#C5CEC3")
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

    Private Sub CalcularMontoTotal()
        Dim total As Decimal = 0

        For Each row As DataGridViewRow In dgvDetalles.Rows
            total += Convert.ToDecimal(row.Cells("Subtotal").Value)
        Next

        lblMontoTotal.Text = total.ToString("N2")
        lblMontoTotalTexto.Text = NumeroATexto(total)
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

    Private Sub btnCancelar_Click(sender As Object, e As EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        Try
            Dim idCajero As Integer = Convert.ToInt32(cmbCaja.SelectedValue)
            Dim idUsuario As Integer = ObtenerIdUsuarioActual()
            Dim fechaApertura As DateTime = dtpFechaApertura.Value
            Dim base As Decimal = Convert.ToDecimal(lblMontoTotal.Text)
            Dim moneda As String = txtMoneda.Text
            Dim estado As String = "ABIERTO"

            ' Crear la lista de detalles a insertar
            Dim detalles As New List(Of Tuple(Of String, Decimal))

            For Each fila As DataGridViewRow In dgvDetalles.Rows
                If Not fila.IsNewRow Then
                    Dim descripcion As String = fila.Cells("Denominacion").Value.ToString()
                    Dim subtotal As Decimal = Convert.ToDecimal(fila.Cells("Subtotal").Value)

                    If subtotal > 0 Then
                        detalles.Add(New Tuple(Of String, Decimal)(descripcion, subtotal))
                    End If
                End If
            Next

            ' Insertar todo dentro de una transacción
            Dim idArqueo As Integer = InsertarArqueoYDetalles(idCajero, idUsuario, fechaApertura, base, moneda, estado, detalles)

            MessageBox.Show("¡Caja aperturada correctamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.Close()

        Catch ex As Exception
            MessageBox.Show("Error al guardar la apertura de caja: " & ex.Message)
        End Try
    End Sub
    Private Function InsertarArqueoYDetalles(idCajero As Integer, idUsuario As Integer, fechaApertura As DateTime, base As Decimal, moneda As String, estado As String, detalles As List(Of Tuple(Of String, Decimal))) As Integer
        Dim idGenerado As Integer = 0
        Dim cadenaConexion As String = objConexion.gen_cad_cloud()

        Using conn As New SqlClient.SqlConnection(cadenaConexion)
            conn.Open()
            Dim trans As SqlClient.SqlTransaction = conn.BeginTransaction()

            Try
                ' Insertar ArqueoCaja
                Dim sqlArqueo As String = "INSERT INTO ArqueoCaja (idCajero, idUsuario, fechaApertura, base, moneda, estado)
                                       VALUES (@idCajero, @idUsuario, @fechaApertura, @base, @moneda, @estado);
                                       SELECT SCOPE_IDENTITY();"

                Using cmdArqueo As New SqlClient.SqlCommand(sqlArqueo, conn, trans)
                    cmdArqueo.Parameters.AddWithValue("@idCajero", idCajero)
                    cmdArqueo.Parameters.AddWithValue("@idUsuario", idUsuario)
                    cmdArqueo.Parameters.AddWithValue("@fechaApertura", fechaApertura)
                    cmdArqueo.Parameters.AddWithValue("@base", base)
                    cmdArqueo.Parameters.AddWithValue("@moneda", moneda)
                    cmdArqueo.Parameters.AddWithValue("@estado", estado)

                    idGenerado = Convert.ToInt32(cmdArqueo.ExecuteScalar())
                End Using

                ' Insertar detalles
                Dim sqlDetalle As String = "INSERT INTO DetalleArqueo (idArqueo, descripcion, monto)
                                        VALUES (@idArqueo, @descripcion, @monto);"

                For Each detalle In detalles
                    Using cmdDetalle As New SqlClient.SqlCommand(sqlDetalle, conn, trans)
                        cmdDetalle.Parameters.AddWithValue("@idArqueo", idGenerado)
                        cmdDetalle.Parameters.AddWithValue("@descripcion", detalle.Item1)
                        cmdDetalle.Parameters.AddWithValue("@monto", detalle.Item2)

                        cmdDetalle.ExecuteNonQuery()
                    End Using
                Next

                trans.Commit()
            Catch ex As Exception
                trans.Rollback()
                Throw New Exception("Error al insertar arqueo y detalles: " & ex.Message)
            End Try
        End Using

        Return idGenerado
    End Function

    Public Function ObtenerIdUsuarioActual() As Integer
        Dim nombreUsuarioActual As String = frmInicioSesion.usuario ' <- Esto puede venir de una propiedad global

        Dim dt As DataTable = objUsuario.buscarUsuarioPorNombre(nombreUsuarioActual)

        If dt.Rows.Count > 0 Then
            Return Convert.ToInt32(dt.Rows(0)("idUduario"))
        Else
            Throw New Exception("Usuario no encontrado.")
        End If
    End Function
End Class