<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransaPedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransaPedido))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.txtNumPedido = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.chkEstadoMesa = New System.Windows.Forms.CheckBox()
        Me.btnBuscarMesa = New System.Windows.Forms.Button()
        Me.txtCapMesa = New System.Windows.Forms.TextBox()
        Me.txtNumMesa = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.btnBuscarMesero = New System.Windows.Forms.Button()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtNumMesero = New System.Windows.Forms.TextBox()
        Me.txtNomMesero = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDNIMesero = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.btnConsultarProducto = New System.Windows.Forms.Button()
        Me.txtNomProducto = New System.Windows.Forms.TextBox()
        Me.txtCodProducto = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.dgvDetalles = New System.Windows.Forms.DataGridView()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.txtMonto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel5.SuspendLayout()
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel6.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.Panel1.Controls.Add(Me.txtNumPedido)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.dtpFecha)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 76)
        Me.Panel1.TabIndex = 0
        '
        'txtNumPedido
        '
        Me.txtNumPedido.Location = New System.Drawing.Point(100, 26)
        Me.txtNumPedido.Name = "txtNumPedido"
        Me.txtNumPedido.Size = New System.Drawing.Size(181, 20)
        Me.txtNumPedido.TabIndex = 3
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(47, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(47, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Número:"
        '
        'dtpFecha
        '
        Me.dtpFecha.Location = New System.Drawing.Point(469, 26)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(200, 20)
        Me.dtpFecha.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(409, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Fecha:"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.chkEstadoMesa)
        Me.Panel2.Controls.Add(Me.btnBuscarMesa)
        Me.Panel2.Controls.Add(Me.txtCapMesa)
        Me.Panel2.Controls.Add(Me.txtNumMesa)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Location = New System.Drawing.Point(12, 94)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(302, 210)
        Me.Panel2.TabIndex = 1
        '
        'chkEstadoMesa
        '
        Me.chkEstadoMesa.AutoSize = True
        Me.chkEstadoMesa.Location = New System.Drawing.Point(100, 133)
        Me.chkEstadoMesa.Name = "chkEstadoMesa"
        Me.chkEstadoMesa.Size = New System.Drawing.Size(62, 17)
        Me.chkEstadoMesa.TabIndex = 8
        Me.chkEstadoMesa.Text = "Vigente"
        Me.chkEstadoMesa.UseVisualStyleBackColor = True
        '
        'btnBuscarMesa
        '
        Me.btnBuscarMesa.Location = New System.Drawing.Point(206, 62)
        Me.btnBuscarMesa.Name = "btnBuscarMesa"
        Me.btnBuscarMesa.Size = New System.Drawing.Size(75, 23)
        Me.btnBuscarMesa.TabIndex = 7
        Me.btnBuscarMesa.Text = "Buscar"
        Me.btnBuscarMesa.UseVisualStyleBackColor = True
        '
        'txtCapMesa
        '
        Me.txtCapMesa.Location = New System.Drawing.Point(100, 97)
        Me.txtCapMesa.Name = "txtCapMesa"
        Me.txtCapMesa.Size = New System.Drawing.Size(181, 20)
        Me.txtCapMesa.TabIndex = 5
        '
        'txtNumMesa
        '
        Me.txtNumMesa.Location = New System.Drawing.Point(100, 64)
        Me.txtNumMesa.Name = "txtNumMesa"
        Me.txtNumMesa.Size = New System.Drawing.Size(100, 20)
        Me.txtNumMesa.TabIndex = 4
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
        Me.Label4.Location = New System.Drawing.Point(33, 97)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Capacidad:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(47, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Numero:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Mesa"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.SystemColors.ActiveBorder
        Me.Panel3.Controls.Add(Me.btnBuscarMesero)
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.txtNumMesero)
        Me.Panel3.Controls.Add(Me.txtNomMesero)
        Me.Panel3.Controls.Add(Me.Label9)
        Me.Panel3.Controls.Add(Me.Label7)
        Me.Panel3.Controls.Add(Me.txtDNIMesero)
        Me.Panel3.Controls.Add(Me.Label6)
        Me.Panel3.Location = New System.Drawing.Point(320, 94)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(386, 210)
        Me.Panel3.TabIndex = 2
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
        'txtNumMesero
        '
        Me.txtNumMesero.Location = New System.Drawing.Point(95, 64)
        Me.txtNumMesero.Name = "txtNumMesero"
        Me.txtNumMesero.Size = New System.Drawing.Size(183, 20)
        Me.txtNumMesero.TabIndex = 11
        '
        'txtNomMesero
        '
        Me.txtNomMesero.Location = New System.Drawing.Point(95, 131)
        Me.txtNomMesero.Name = "txtNomMesero"
        Me.txtNomMesero.Size = New System.Drawing.Size(266, 20)
        Me.txtNomMesero.TabIndex = 10
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
        'txtDNIMesero
        '
        Me.txtDNIMesero.Location = New System.Drawing.Point(95, 97)
        Me.txtDNIMesero.Name = "txtDNIMesero"
        Me.txtDNIMesero.Size = New System.Drawing.Size(266, 20)
        Me.txtDNIMesero.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(22, 25)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(42, 13)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Mesero"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.SystemColors.ButtonShadow
        Me.Panel4.Controls.Add(Me.btnConsultarProducto)
        Me.Panel4.Controls.Add(Me.txtNomProducto)
        Me.Panel4.Controls.Add(Me.txtCodProducto)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.btnEliminar)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Location = New System.Drawing.Point(12, 310)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(693, 98)
        Me.Panel4.TabIndex = 3
        '
        'btnConsultarProducto
        '
        Me.btnConsultarProducto.Location = New System.Drawing.Point(524, 24)
        Me.btnConsultarProducto.Name = "btnConsultarProducto"
        Me.btnConsultarProducto.Size = New System.Drawing.Size(153, 23)
        Me.btnConsultarProducto.TabIndex = 18
        Me.btnConsultarProducto.Text = "Consultar"
        Me.btnConsultarProducto.UseVisualStyleBackColor = True
        '
        'txtNomProducto
        '
        Me.txtNomProducto.Location = New System.Drawing.Point(296, 46)
        Me.txtNomProducto.Name = "txtNomProducto"
        Me.txtNomProducto.Size = New System.Drawing.Size(198, 20)
        Me.txtNomProducto.TabIndex = 17
        '
        'txtCodProducto
        '
        Me.txtCodProducto.Location = New System.Drawing.Point(100, 46)
        Me.txtCodProducto.Name = "txtCodProducto"
        Me.txtCodProducto.Size = New System.Drawing.Size(100, 20)
        Me.txtCodProducto.TabIndex = 16
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(234, 50)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(47, 13)
        Me.Label13.TabIndex = 13
        Me.Label13.Text = "Nombre:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(33, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "Código:"
        '
        'btnEliminar
        '
        Me.btnEliminar.Location = New System.Drawing.Point(524, 53)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(153, 27)
        Me.btnEliminar.TabIndex = 9
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(24, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(53, 13)
        Me.Label11.TabIndex = 8
        Me.Label11.Text = "Producto:"
        '
        'Panel5
        '
        Me.Panel5.Controls.Add(Me.dgvDetalles)
        Me.Panel5.Location = New System.Drawing.Point(14, 414)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(692, 283)
        Me.Panel5.TabIndex = 4
        '
        'dgvDetalles
        '
        Me.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetalles.Location = New System.Drawing.Point(3, 3)
        Me.dgvDetalles.Name = "dgvDetalles"
        Me.dgvDetalles.RowHeadersWidth = 51
        Me.dgvDetalles.Size = New System.Drawing.Size(686, 277)
        Me.dgvDetalles.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Button1)
        Me.Panel6.Controls.Add(Me.txtMonto)
        Me.Panel6.Controls.Add(Me.Label14)
        Me.Panel6.Location = New System.Drawing.Point(14, 703)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(693, 51)
        Me.Panel6.TabIndex = 5
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(25, 13)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(208, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "REGISTRAR PEDIDO"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'txtMonto
        '
        Me.txtMonto.Location = New System.Drawing.Point(485, 13)
        Me.txtMonto.Name = "txtMonto"
        Me.txtMonto.Size = New System.Drawing.Size(182, 20)
        Me.txtMonto.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(425, 16)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 13)
        Me.Label14.TabIndex = 0
        Me.Label14.Text = "Monto:"
        '
        'frmTransaPedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 759)
        Me.Controls.Add(Me.Panel6)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel4)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmTransaPedido"
        Me.Text = "Transacción del pedido"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel5.ResumeLayout(False)
        CType(Me.dgvDetalles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnBuscarMesa As Button
    Friend WithEvents txtCapMesa As TextBox
    Friend WithEvents txtNumMesa As TextBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtDNIMesero As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtNumPedido As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents txtNumMesero As TextBox
    Friend WithEvents txtNomMesero As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents txtNomProducto As TextBox
    Friend WithEvents txtCodProducto As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents btnEliminar As Button
    Friend WithEvents Label11 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Panel6 As Panel
    Friend WithEvents btnBuscarMesero As Button
    Friend WithEvents dgvDetalles As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents txtMonto As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents chkEstadoMesa As CheckBox
    Friend WithEvents btnConsultarProducto As Button
End Class
