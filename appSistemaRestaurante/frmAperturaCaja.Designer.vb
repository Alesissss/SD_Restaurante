<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAperturaCaja
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAperturaCaja))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.lblNumArqueo = New System.Windows.Forms.TextBox()
        Me.lblUsuario = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dgvDetalles = New System.Windows.Forms.DataGridView()
        Me.dtpFechaApertura = New System.Windows.Forms.DateTimePicker()
        Me.txtMoneda = New System.Windows.Forms.TextBox()
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.cmbCaja = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblMontoTotal = New System.Windows.Forms.TextBox()
        Me.pnlBotones = New System.Windows.Forms.Panel()
        Me.btnCancelar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.lblMontoTotalTexto = New System.Windows.Forms.Label()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pnlDatos.SuspendLayout()
        Me.pnlBotones.SuspendLayout()
        Me.SuspendLayout()
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(97, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Fecha de apertura:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(72, 140)
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(29, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(221, 25)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "APERTURA DE CAJA"
        '
        'dgvDetalles
        '
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalles.Location = New System.Drawing.Point(27, 261)
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.Size = New System.Drawing.Size(533, 158)
        Me.dgvDetalles.TabIndex = 9
        '
        'dtpFechaApertura
        '
        Me.dtpFechaApertura.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpFechaApertura.Location = New System.Drawing.Point(144, 106)
        Me.dtpFechaApertura.Name = "dtpFechaApertura"
        Me.dtpFechaApertura.Size = New System.Drawing.Size(200, 20)
        Me.dtpFechaApertura.TabIndex = 10
        '
        'txtMoneda
        '
        Me.txtMoneda.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMoneda.Location = New System.Drawing.Point(144, 137)
        Me.txtMoneda.Name = "txtMoneda"
        Me.txtMoneda.Size = New System.Drawing.Size(200, 20)
        Me.txtMoneda.TabIndex = 11
        '
        'pnlDatos
        '
        Me.pnlDatos.Controls.Add(Me.cmbCaja)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.txtMoneda)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Controls.Add(Me.dtpFechaApertura)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.lblNumArqueo)
        Me.pnlDatos.Controls.Add(Me.lblUsuario)
        Me.pnlDatos.Location = New System.Drawing.Point(27, 69)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(356, 175)
        Me.pnlDatos.TabIndex = 12
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
        'Panel2
        '
        Me.Panel2.BackgroundImage = CType(resources.GetObject("Panel2.BackgroundImage"), System.Drawing.Image)
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Location = New System.Drawing.Point(389, 69)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(172, 175)
        Me.Panel2.TabIndex = 13
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(300, 440)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 20)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Monto total:"
        '
        'lblMontoTotal
        '
        Me.lblMontoTotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMontoTotal.Location = New System.Drawing.Point(416, 437)
        Me.lblMontoTotal.Name = "lblMontoTotal"
        Me.lblMontoTotal.Size = New System.Drawing.Size(134, 26)
        Me.lblMontoTotal.TabIndex = 15
        '
        'pnlBotones
        '
        Me.pnlBotones.Controls.Add(Me.btnCancelar)
        Me.pnlBotones.Controls.Add(Me.btnGuardar)
        Me.pnlBotones.Location = New System.Drawing.Point(27, 523)
        Me.pnlBotones.Name = "pnlBotones"
        Me.pnlBotones.Size = New System.Drawing.Size(534, 50)
        Me.pnlBotones.TabIndex = 16
        '
        'btnCancelar
        '
        Me.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancelar.Image = CType(resources.GetObject("btnCancelar.Image"), System.Drawing.Image)
        Me.btnCancelar.Location = New System.Drawing.Point(263, 7)
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
        Me.btnGuardar.Location = New System.Drawing.Point(397, 7)
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
        Me.lblMontoTotalTexto.Location = New System.Drawing.Point(253, 489)
        Me.lblMontoTotalTexto.Name = "lblMontoTotalTexto"
        Me.lblMontoTotalTexto.Size = New System.Drawing.Size(297, 13)
        Me.lblMontoTotalTexto.TabIndex = 17
        Me.lblMontoTotalTexto.Text = "DOSCIENTOS CINCUENTA MIL SOLES CON 0 CENTAVOS"
        '
        'frmAperturaCaja
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(572, 581)
        Me.Controls.Add(Me.lblMontoTotalTexto)
        Me.Controls.Add(Me.pnlBotones)
        Me.Controls.Add(Me.lblMontoTotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.dgvDetalles)
        Me.Controls.Add(Me.Label5)
        Me.Name = "frmAperturaCaja"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Apertura de caja"
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.pnlBotones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents lblNumArqueo As TextBox
    Friend WithEvents lblUsuario As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents dgvDetalles As DataGridView
    Friend WithEvents dtpFechaApertura As DateTimePicker
    Friend WithEvents txtMoneda As TextBox
    Friend WithEvents pnlDatos As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents lblMontoTotal As TextBox
    Friend WithEvents pnlBotones As Panel
    Friend WithEvents btnCancelar As Button
    Friend WithEvents btnGuardar As Button
    Friend WithEvents lblMontoTotalTexto As Label
    Friend WithEvents cmbCaja As ComboBox
    Friend WithEvents Label7 As Label
End Class
