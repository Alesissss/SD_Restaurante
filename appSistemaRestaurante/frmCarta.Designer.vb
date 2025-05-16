<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCarta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCarta))
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.txtDescripcion = New System.Windows.Forms.TextBox()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.chkEstado = New System.Windows.Forms.CheckBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtIDCarta = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnDarBaja = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvCarta = New System.Windows.Forms.DataGridView()
        Me.lsvCarta = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlDatos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvCarta, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.LightBlue
        Me.pnlDatos.Controls.Add(Me.txtDescripcion)
        Me.pnlDatos.Controls.Add(Me.btnBuscar)
        Me.pnlDatos.Controls.Add(Me.chkEstado)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.txtNombres)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.txtIDCarta)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.pnlDatos.Location = New System.Drawing.Point(0, 0)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(403, 264)
        Me.pnlDatos.TabIndex = 2
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(134, 132)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(257, 90)
        Me.txtDescripcion.TabIndex = 12
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(257, 29)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(48, 43)
        Me.btnBuscar.TabIndex = 11
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chkEstado
        '
        Me.chkEstado.AutoSize = True
        Me.chkEstado.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.chkEstado.Location = New System.Drawing.Point(134, 232)
        Me.chkEstado.Name = "chkEstado"
        Me.chkEstado.Size = New System.Drawing.Size(85, 22)
        Me.chkEstado.TabIndex = 10
        Me.chkEstado.Text = "(Vigente)"
        Me.chkEstado.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label10.Location = New System.Drawing.Point(69, 232)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Estado:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label9.Location = New System.Drawing.Point(37, 126)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Descripcion:"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(134, 87)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(257, 24)
        Me.txtNombres.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label3.Location = New System.Drawing.Point(62, 86)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nombre:"
        '
        'txtIDCarta
        '
        Me.txtIDCarta.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDCarta.Location = New System.Drawing.Point(134, 37)
        Me.txtIDCarta.Name = "txtIDCarta"
        Me.txtIDCarta.Size = New System.Drawing.Size(117, 26)
        Me.txtIDCarta.TabIndex = 1
        Me.txtIDCarta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.Location = New System.Drawing.Point(62, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Carta:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnDarBaja)
        Me.Panel2.Controls.Add(Me.btnEliminar)
        Me.Panel2.Controls.Add(Me.btnModificar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Panel2.Location = New System.Drawing.Point(409, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(191, 264)
        Me.Panel2.TabIndex = 3
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(24, 211)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(143, 43)
        Me.btnSalir.TabIndex = 16
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'btnDarBaja
        '
        Me.btnDarBaja.Enabled = False
        Me.btnDarBaja.Image = CType(resources.GetObject("btnDarBaja.Image"), System.Drawing.Image)
        Me.btnDarBaja.Location = New System.Drawing.Point(24, 158)
        Me.btnDarBaja.Name = "btnDarBaja"
        Me.btnDarBaja.Size = New System.Drawing.Size(143, 43)
        Me.btnDarBaja.TabIndex = 15
        Me.btnDarBaja.Text = "Dar Baja"
        Me.btnDarBaja.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnDarBaja.UseVisualStyleBackColor = True
        '
        'btnEliminar
        '
        Me.btnEliminar.Enabled = False
        Me.btnEliminar.Image = CType(resources.GetObject("btnEliminar.Image"), System.Drawing.Image)
        Me.btnEliminar.Location = New System.Drawing.Point(24, 109)
        Me.btnEliminar.Name = "btnEliminar"
        Me.btnEliminar.Size = New System.Drawing.Size(143, 43)
        Me.btnEliminar.TabIndex = 14
        Me.btnEliminar.Text = "Eliminar"
        Me.btnEliminar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnEliminar.UseVisualStyleBackColor = True
        '
        'btnModificar
        '
        Me.btnModificar.Enabled = False
        Me.btnModificar.Image = CType(resources.GetObject("btnModificar.Image"), System.Drawing.Image)
        Me.btnModificar.Location = New System.Drawing.Point(24, 60)
        Me.btnModificar.Name = "btnModificar"
        Me.btnModificar.Size = New System.Drawing.Size(143, 43)
        Me.btnModificar.TabIndex = 13
        Me.btnModificar.Text = "Modificar"
        Me.btnModificar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnModificar.UseVisualStyleBackColor = True
        '
        'btnNuevo
        '
        Me.btnNuevo.Image = CType(resources.GetObject("btnNuevo.Image"), System.Drawing.Image)
        Me.btnNuevo.Location = New System.Drawing.Point(24, 11)
        Me.btnNuevo.Name = "btnNuevo"
        Me.btnNuevo.Size = New System.Drawing.Size(143, 43)
        Me.btnNuevo.TabIndex = 12
        Me.btnNuevo.Text = "Nuevo"
        Me.btnNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnNuevo.UseVisualStyleBackColor = True
        '
        'dgvCarta
        '
        Me.dgvCarta.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCarta.Location = New System.Drawing.Point(0, 270)
        Me.dgvCarta.Name = "dgvCarta"
        Me.dgvCarta.Size = New System.Drawing.Size(600, 156)
        Me.dgvCarta.TabIndex = 4
        '
        'lsvCarta
        '
        Me.lsvCarta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4})
        Me.lsvCarta.FullRowSelect = True
        Me.lsvCarta.GridLines = True
        Me.lsvCarta.HideSelection = False
        Me.lsvCarta.Location = New System.Drawing.Point(0, 432)
        Me.lsvCarta.Name = "lsvCarta"
        Me.lsvCarta.Size = New System.Drawing.Size(600, 160)
        Me.lsvCarta.TabIndex = 5
        Me.lsvCarta.UseCompatibleStateImageBehavior = False
        Me.lsvCarta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "NOMBRE"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "DESCRIPCION"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "VIGENCIA"
        '
        'frmCarta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(600, 592)
        Me.Controls.Add(Me.lsvCarta)
        Me.Controls.Add(Me.dgvCarta)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlDatos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCarta"
        Me.Text = ".: GESTIONAR CARTA :."
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvCarta, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDatos As Panel
    Friend WithEvents txtDescripcion As TextBox
    Friend WithEvents btnBuscar As Button
    Friend WithEvents chkEstado As CheckBox
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtIDCarta As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnDarBaja As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvCarta As DataGridView
    Friend WithEvents lsvCarta As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
End Class
