<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmTransaPago
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransaPago))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.lblEstado = New System.Windows.Forms.Label()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.txtTotalPed = New System.Windows.Forms.TextBox()
        Me.txtIDPedido = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnBuscarMesero = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCodCli = New System.Windows.Forms.TextBox()
        Me.txtNomCli = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDNICli = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtIDCajero = New System.Windows.Forms.TextBox()
        Me.btnConsultarCajero = New System.Windows.Forms.Button()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.btnRegistrarPedido = New System.Windows.Forms.Button()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.btnConsultarCajero)
        Me.Panel1.Controls.Add(Me.txtIDCajero)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(699, 76)
        Me.Panel1.TabIndex = 1
        '
        'dtpFecha
        '
        Me.dtpFecha.Enabled = False
        Me.dtpFecha.Location = New System.Drawing.Point(445, 25)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(385, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblEstado)
        Me.Panel2.Controls.Add(Me.btnBuscar)
        Me.Panel2.Controls.Add(Me.txtTotalPed)
        Me.Panel2.Controls.Add(Me.txtIDPedido)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(302, 210)
        Me.Panel2.TabIndex = 2
        '
        'lblEstado
        '
        Me.lblEstado.AutoSize = True
        Me.lblEstado.Location = New System.Drawing.Point(97, 131)
        Me.lblEstado.Name = "lblEstado"
        Me.lblEstado.Size = New System.Drawing.Size(92, 13)
        Me.lblEstado.TabIndex = 10
        Me.lblEstado.Text = "Estado del pedido"
        '
        'btnBuscar
        '
        Me.btnBuscar.Location = New System.Drawing.Point(206, 64)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscar.TabIndex = 9
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'txtTotalPed
        '
        Me.txtTotalPed.Location = New System.Drawing.Point(100, 97)
        Me.txtTotalPed.Name = "txtTotalPed"
        Me.txtTotalPed.ReadOnly = True
        Me.txtTotalPed.Size = New System.Drawing.Size(181, 20)
        Me.txtTotalPed.TabIndex = 5
        '
        'txtIDPedido
        '
        Me.txtIDPedido.Location = New System.Drawing.Point(100, 64)
        Me.txtIDPedido.Name = "txtIDPedido"
        Me.txtIDPedido.ReadOnly = True
        Me.txtIDPedido.Size = New System.Drawing.Size(100, 20)
        Me.txtIDPedido.TabIndex = 4
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(47, 131)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Estado:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(47, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Total:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Código:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Pedido"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel3.Controls.Add(Me.btnBuscarMesero)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtCodCli)
        Me.Panel3.Controls.Add(Me.txtNomCli)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtDNICli)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(325, 94)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(386, 210)
        Me.Panel3.TabIndex = 3
        '
        'btnBuscarMesero
        '
        Me.btnBuscarMesero.Location = New System.Drawing.Point(286, 62)
        Me.btnBuscarMesero.Name = "btnBuscarMesero"
        Me.btnBuscarMesero.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscarMesero.TabIndex = 8
        Me.btnBuscarMesero.Text = "Buscar"
        Me.btnBuscarMesero.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(35, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Código:"
        '
        'txtCodCli
        '
        Me.txtCodCli.Location = New System.Drawing.Point(95, 64)
        Me.txtCodCli.Name = "txtCodCli"
        Me.txtCodCli.ReadOnly = True
        Me.txtCodCli.Size = New System.Drawing.Size(183, 20)
        Me.txtCodCli.TabIndex = 11
        '
        'txtNomCli
        '
        Me.txtNomCli.Location = New System.Drawing.Point(95, 131)
        Me.txtNomCli.Name = "txtNomCli"
        Me.txtNomCli.ReadOnly = True
        Me.txtNomCli.Size = New System.Drawing.Size(266, 20)
        Me.txtNomCli.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(26, 138)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(52, 13)
        Me.Label9.TabIndex = 9
        Me.Label9.Text = "Nombres:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(49, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(29, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "DNI:"
        '
        'txtDNICli
        '
        Me.txtDNICli.Location = New System.Drawing.Point(95, 97)
        Me.txtDNICli.Name = "txtDNICli"
        Me.txtDNICli.ReadOnly = True
        Me.txtDNICli.Size = New System.Drawing.Size(266, 20)
        Me.txtDNICli.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Cliente"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(36, 28)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(40, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Cajero:"
        '
        'txtIDCajero
        '
        Me.txtIDCajero.Location = New System.Drawing.Point(89, 25)
        Me.txtIDCajero.Name = "txtIDCajero"
        Me.txtIDCajero.ReadOnly = True
        Me.txtIDCajero.Size = New System.Drawing.Size(66, 20)
        Me.txtIDCajero.TabIndex = 5
        '
        'btnConsultarCajero
        '
        Me.btnConsultarCajero.Location = New System.Drawing.Point(161, 23)
        Me.btnConsultarCajero.Name = "btnConsultarCajero"
        Me.btnConsultarCajero.Size = New System.Drawing.Size(75, 23)
        Me.btnConsultarCajero.TabIndex = 13
        Me.btnConsultarCajero.Text = "Buscar"
        Me.btnConsultarCajero.UseVisualStyleBackColor = True
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.btnRegistrarPedido)
        Me.Panel6.Location = New System.Drawing.Point(12, 326)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(699, 51)
        Me.Panel6.TabIndex = 6
        '
        'btnRegistrarPedido
        '
        Me.btnRegistrarPedido.Location = New System.Drawing.Point(256, 16)
        Me.btnRegistrarPedido.Name = "btnRegistrarPedido"
        Me.btnRegistrarPedido.Size = New System.Drawing.Size(135, 23)
        Me.btnRegistrarPedido.TabIndex = 2
        Me.btnRegistrarPedido.Text = "PAGAR PEDIDO"
        Me.btnRegistrarPedido.UseVisualStyleBackColor = True
        '
        'frmTransaPago
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(723, 424)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTransaPago"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ".: REGISTRAR PAGO :."
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents lblEstado As Label
    Friend WithEvents btnBuscar As Button
    Friend WithEvents txtTotalPed As TextBox
    Friend WithEvents txtIDPedido As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents btnBuscarMesero As Button
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCodCli As TextBox
    Friend WithEvents txtNomCli As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDNICli As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents btnConsultarCajero As Button
    Friend WithEvents txtIDCajero As TextBox
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnRegistrarPedido As Button
End Class
