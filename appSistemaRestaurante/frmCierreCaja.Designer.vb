<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCierreCaja
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCierreCaja))
        Me.dgvDetalles = New System.Windows.Forms.DataGridView()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNumArqueo = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.TextBox()
        Me.dtpFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.pnlCargar = New System.Windows.Forms.Panel()
        Me.txtBaseCaja = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFechaCierre = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblMontoTotalTexto = New System.Windows.Forms.Label()
        Me.lblMontoTotal = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.pnlCargar.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
        '
        'dgvDetalles
        '
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalles.Location = New System.Drawing.Point(401, 66)
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.Size = New System.Drawing.Size(356, 217)
        Me.dgvDetalles.TabIndex = 18
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.cmbCaja)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.txtMoneda)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.lblNumArqueo)
        Me.pnlDatos.Controls.Add(Me.lblUsuario)
        Me.pnlDatos.Location = New System.Drawing.Point(23, 66)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(356, 166)
        Me.pnlDatos.TabIndex = 14
        '
        'cmbCaja
        '
        Me.cmbCaja.FormattingEnabled = True
        Me.cmbCaja.Location = New System.Drawing.Point(144, 16)
        Me.cmbCaja.Name = "cmbCaja"
        Me.cmbCaja.Size = New System.Drawing.Size(200, 21)
        Me.cmbCaja.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(90, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Caja:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(23, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Número de arqueo:"
        '
        'txtMoneda
        '
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(144, 116)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(200, 20)
        Me.txtMoneda.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(40, 82)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Usuario/Cajero:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(72, 116)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Moneda:"
        '
        'lblNumArqueo
        '
        Me.lblNumArqueo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNumArqueo.Location = New System.Drawing.Point(144, 50)
        Me.lblNumArqueo.Name = "lblNumArqueo"
        Me.lblNumArqueo.Size = New System.Drawing.Size(109, 20)
        Me.lblNumArqueo.TabIndex = 4
        '
        'lblUsuario
        '
        Me.lblUsuario.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblUsuario.Location = New System.Drawing.Point(144, 79)
        Me.lblUsuario.Name = "lblUsuario"
        Me.lblUsuario.Size = New System.Drawing.Size(200, 20)
        Me.lblUsuario.TabIndex = 5
        '
        'dtpFechaApertura
        '
        Me.dtpFechaApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaApertura.Location = New System.Drawing.Point(144, 13)
        Me.dtpFechaApertura.Name = "dtpFechaApertura"
        Me.dtpFechaApertura.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaApertura.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 19)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de apertura:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(18, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(185, 25)
        Me.Label5.TabIndex = 16
        Me.Label5.Text = "CIERRE DE CAJA"
        '
        'pnlCargar
        '
        Me.pnlCargar.Controls.Add(Me.txtBaseCaja)
        Me.pnlCargar.Controls.Add(Me.Label8)
        Me.pnlCargar.Controls.Add(Me.dtpFechaCierre)
        Me.pnlCargar.Controls.Add(Me.Label6)
        Me.pnlCargar.Controls.Add(Me.Label3)
        Me.pnlCargar.Controls.Add(Me.dtpFechaApertura)
        Me.pnlCargar.Location = New System.Drawing.Point(23, 251)
        Me.pnlCargar.Name = "pnlCargar"
        Me.pnlCargar.Size = New System.Drawing.Size(356, 166)
        Me.pnlCargar.TabIndex = 17
        '
        'txtBaseCaja
        '
        Me.txtBaseCaja.Location = New System.Drawing.Point(144, 83)
        Me.txtBaseCaja.Name = "txtBaseCaja"
        Me.txtBaseCaja.Size = New System.Drawing.Size(134, 20)
        Me.txtBaseCaja.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 86)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Base en caja:"
        '
        'dtpFechaCierre
        '
        Me.dtpFechaCierre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaCierre.Location = New System.Drawing.Point(144, 50)
        Me.dtpFechaCierre.Name = "dtpFechaCierre"
        Me.dtpFechaCierre.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaCierre.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(29, 53)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(84, 13)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Fecha de cierre:"
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Location = New System.Drawing.Point(401, 367)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(355, 50)
        Me.pnlBotones.TabIndex = 19
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(82, 3)
        Me.btnCancelar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(126, 40)
        Me.btnCancelar.TabIndex = 18
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = CType(resources.GetObject("btnGuardar.Image"), System.Drawing.Image)
        Me.btnGuardar.Location = New System.Drawing.Point(216, 3)
        Me.btnGuardar.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(126, 40)
        Me.btnGuardar.TabIndex = 17
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'lblMontoTotalTexto
        '
        Me.lblMontoTotalTexto.AutoSize = True
        Me.lblMontoTotalTexto.Enabled = False
        Me.lblMontoTotalTexto.Location = New System.Drawing.Point(459, 334)
        Me.lblMontoTotalTexto.Name = "lblMontoTotalTexto"
        Me.lblMontoTotalTexto.Size = New System.Drawing.Size(297, 13)
        Me.lblMontoTotalTexto.TabIndex = 22
        Me.lblMontoTotalTexto.Text = "DOSCIENTOS CINCUENTA MIL SOLES CON 0 CENTAVOS"
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.Location = New System.Drawing.Point(616, 294)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(140, 26)
        Me.lblMontoTotal.TabIndex = 21
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(500, 297)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 20)
        Me.Label9.TabIndex = 20
        Me.Label9.Text = "Monto total:"
        '
        'frmCierreCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(776, 450)
        Me.Controls.Add(Me.lblMontoTotalTexto)
        Me.Controls.Add(Me.lblMontoTotal)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.dgvDetalles)
        Me.Controls.Add(Me.pnlCargar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.pnlDatos)
        Me.Name = "frmCierreCaja"
        Me.Text = "Form1"
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.pnlCargar.ResumeLayout(False)
        Me.pnlCargar.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pnlDatos As Panel
    Friend WithEvents cmbCaja As ComboBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents txtMoneda As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFechaApertura As DateTimePicker
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNumArqueo As TextBox
    Friend WithEvents lblUsuario As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents pnlCargar As Panel
    Friend WithEvents dgvDetalles As DataGridView
    Friend WithEvents Label6 As Label
    Friend WithEvents dtpFechaCierre As DateTimePicker
    Friend WithEvents Label8 As Label
    Friend WithEvents txtBaseCaja As TextBox
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblMontoTotalTexto As Label
    Friend WithEvents lblMontoTotal As TextBox
    Friend WithEvents Label9 As Label
End Class
