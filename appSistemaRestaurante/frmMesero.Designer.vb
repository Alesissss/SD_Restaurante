<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMesero
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMesero))
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.btnBuscar = New System.Windows.Forms.Button()
        Me.chkEstado = New System.Windows.Forms.CheckBox()
        Me.dtpFecha = New System.Windows.Forms.DateTimePicker()
        Me.cmbSexo = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtCorreo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTelefono = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDireccion = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtApellidos = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtNombres = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDni = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtIDMes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.btnSalir = New System.Windows.Forms.Button()
        Me.btnDarBaja = New System.Windows.Forms.Button()
        Me.btnEliminar = New System.Windows.Forms.Button()
        Me.btnModificar = New System.Windows.Forms.Button()
        Me.btnNuevo = New System.Windows.Forms.Button()
        Me.dgvEmpleados = New System.Windows.Forms.DataGridView()
        Me.lsvEmpleados = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlDatos.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.LightBlue
        Me.pnlDatos.Controls.Add(Me.btnBuscar)
        Me.pnlDatos.Controls.Add(Me.chkEstado)
        Me.pnlDatos.Controls.Add(Me.dtpFecha)
        Me.pnlDatos.Controls.Add(Me.cmbSexo)
        Me.pnlDatos.Controls.Add(Me.Label10)
        Me.pnlDatos.Controls.Add(Me.txtCorreo)
        Me.pnlDatos.Controls.Add(Me.Label9)
        Me.pnlDatos.Controls.Add(Me.txtTelefono)
        Me.pnlDatos.Controls.Add(Me.Label8)
        Me.pnlDatos.Controls.Add(Me.txtDireccion)
        Me.pnlDatos.Controls.Add(Me.Label7)
        Me.pnlDatos.Controls.Add(Me.Label6)
        Me.pnlDatos.Controls.Add(Me.Label5)
        Me.pnlDatos.Controls.Add(Me.txtApellidos)
        Me.pnlDatos.Controls.Add(Me.Label4)
        Me.pnlDatos.Controls.Add(Me.txtNombres)
        Me.pnlDatos.Controls.Add(Me.Label3)
        Me.pnlDatos.Controls.Add(Me.txtDni)
        Me.pnlDatos.Controls.Add(Me.Label2)
        Me.pnlDatos.Controls.Add(Me.txtIDMes)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Location = New System.Drawing.Point(12, 12)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(403, 363)
        Me.pnlDatos.TabIndex = 0
        '
        'btnBuscar
        '
        Me.btnBuscar.FlatAppearance.BorderSize = 0
        Me.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBuscar.Image = CType(resources.GetObject("btnBuscar.Image"), System.Drawing.Image)
        Me.btnBuscar.Location = New System.Drawing.Point(257, 20)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(48, 43)
        Me.btnBuscar.TabIndex = 11
        Me.btnBuscar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'chkEstado
        '
        Me.chkEstado.AutoSize = True
        Me.chkEstado.Location = New System.Drawing.Point(134, 327)
        Me.chkEstado.Name = "chkEstado"
        Me.chkEstado.Size = New System.Drawing.Size(96, 22)
        Me.chkEstado.TabIndex = 10
        Me.chkEstado.Text = "(Vigente)"
        Me.chkEstado.UseVisualStyleBackColor = True
        '
        'dtpFecha
        '
        Me.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpFecha.Location = New System.Drawing.Point(134, 194)
        Me.dtpFecha.Name = "dtpFecha"
        Me.dtpFecha.Size = New System.Drawing.Size(117, 26)
        Me.dtpFecha.TabIndex = 6
        '
        'cmbSexo
        '
        Me.cmbSexo.FormattingEnabled = True
        Me.cmbSexo.Items.AddRange(New Object() {"Femenino", "Masculino"})
        Me.cmbSexo.Location = New System.Drawing.Point(134, 165)
        Me.cmbSexo.Name = "cmbSexo"
        Me.cmbSexo.Size = New System.Drawing.Size(117, 26)
        Me.cmbSexo.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(62, 328)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 18)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Estado:"
        '
        'txtCorreo
        '
        Me.txtCorreo.Location = New System.Drawing.Point(134, 293)
        Me.txtCorreo.Name = "txtCorreo"
        Me.txtCorreo.Size = New System.Drawing.Size(226, 26)
        Me.txtCorreo.TabIndex = 9
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(61, 296)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(67, 18)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Correo:"
        '
        'txtTelefono
        '
        Me.txtTelefono.Location = New System.Drawing.Point(134, 261)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.Size = New System.Drawing.Size(117, 26)
        Me.txtTelefono.TabIndex = 8
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(51, 264)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(77, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Teléfono:"
        '
        'txtDireccion
        '
        Me.txtDireccion.Location = New System.Drawing.Point(134, 229)
        Me.txtDireccion.Name = "txtDireccion"
        Me.txtDireccion.Size = New System.Drawing.Size(226, 26)
        Me.txtDireccion.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(46, 232)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(82, 18)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Dirección:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(31, 200)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(97, 18)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Fecha Nac.:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(75, 168)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 18)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Sexo:"
        '
        'txtApellidos
        '
        Me.txtApellidos.Location = New System.Drawing.Point(134, 133)
        Me.txtApellidos.Name = "txtApellidos"
        Me.txtApellidos.Size = New System.Drawing.Size(226, 26)
        Me.txtApellidos.TabIndex = 4
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(49, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Apellidos:"
        '
        'txtNombres
        '
        Me.txtNombres.Location = New System.Drawing.Point(134, 101)
        Me.txtNombres.Name = "txtNombres"
        Me.txtNombres.Size = New System.Drawing.Size(226, 26)
        Me.txtNombres.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(45, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nombres:"
        '
        'txtDni
        '
        Me.txtDni.Location = New System.Drawing.Point(134, 69)
        Me.txtDni.Name = "txtDni"
        Me.txtDni.Size = New System.Drawing.Size(117, 26)
        Me.txtDni.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(86, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "DNI:"
        '
        'txtIDMes
        '
        Me.txtIDMes.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIDMes.Location = New System.Drawing.Point(134, 37)
        Me.txtIDMes.Name = "txtIDMes"
        Me.txtIDMes.Size = New System.Drawing.Size(117, 26)
        Me.txtIDMes.TabIndex = 1
        Me.txtIDMes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(37, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID Mesero:"
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.btnSalir)
        Me.Panel2.Controls.Add(Me.btnDarBaja)
        Me.Panel2.Controls.Add(Me.btnEliminar)
        Me.Panel2.Controls.Add(Me.btnModificar)
        Me.Panel2.Controls.Add(Me.btnNuevo)
        Me.Panel2.Location = New System.Drawing.Point(421, 12)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(191, 363)
        Me.Panel2.TabIndex = 1
        '
        'btnSalir
        '
        Me.btnSalir.Image = CType(resources.GetObject("btnSalir.Image"), System.Drawing.Image)
        Me.btnSalir.Location = New System.Drawing.Point(24, 305)
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
        'dgvEmpleados
        '
        Me.dgvEmpleados.AllowUserToAddRows = False
        Me.dgvEmpleados.AllowUserToDeleteRows = False
        Me.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmpleados.Location = New System.Drawing.Point(12, 381)
        Me.dgvEmpleados.Name = "dgvEmpleados"
        Me.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmpleados.Size = New System.Drawing.Size(601, 140)
        Me.dgvEmpleados.TabIndex = 17
        '
        'lsvEmpleados
        '
        Me.lsvEmpleados.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8, Me.ColumnHeader9})
        Me.lsvEmpleados.Font = New System.Drawing.Font("Verdana", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvEmpleados.FullRowSelect = True
        Me.lsvEmpleados.GridLines = True
        Me.lsvEmpleados.HideSelection = False
        Me.lsvEmpleados.Location = New System.Drawing.Point(12, 528)
        Me.lsvEmpleados.MultiSelect = False
        Me.lsvEmpleados.Name = "lsvEmpleados"
        Me.lsvEmpleados.Size = New System.Drawing.Size(600, 122)
        Me.lsvEmpleados.TabIndex = 18
        Me.lsvEmpleados.UseCompatibleStateImageBehavior = False
        Me.lsvEmpleados.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "ID"
        Me.ColumnHeader1.Width = 35
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DNI"
        Me.ColumnHeader2.Width = 55
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Nombres"
        Me.ColumnHeader3.Width = 110
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Sexo"
        Me.ColumnHeader4.Width = 55
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "F. Nac."
        Me.ColumnHeader5.Width = 65
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Dirección"
        Me.ColumnHeader6.Width = 80
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Teléfono"
        Me.ColumnHeader7.Width = 70
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Correo"
        Me.ColumnHeader8.Width = 65
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "Estado"
        '
        'frmMesero
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 658)
        Me.Controls.Add(Me.lsvEmpleados)
        Me.Controls.Add(Me.dgvEmpleados)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.pnlDatos)
        Me.Font = New System.Drawing.Font("Verdana", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "frmMesero"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = ".: GESTIONAR MESERO :."
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        CType(Me.dgvEmpleados, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pnlDatos As Panel
    Friend WithEvents Label10 As Label
    Friend WithEvents txtCorreo As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents txtTelefono As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtDireccion As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents txtApellidos As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtNombres As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents txtDni As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtIDMes As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents chkEstado As CheckBox
    Friend WithEvents dtpFecha As DateTimePicker
    Friend WithEvents cmbSexo As ComboBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents btnSalir As Button
    Friend WithEvents btnDarBaja As Button
    Friend WithEvents btnEliminar As Button
    Friend WithEvents btnModificar As Button
    Friend WithEvents btnNuevo As Button
    Friend WithEvents dgvEmpleados As DataGridView
    Friend WithEvents btnBuscar As Button
    Friend WithEvents lsvEmpleados As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents ColumnHeader3 As ColumnHeader
    Friend WithEvents ColumnHeader4 As ColumnHeader
    Friend WithEvents ColumnHeader5 As ColumnHeader
    Friend WithEvents ColumnHeader6 As ColumnHeader
    Friend WithEvents ColumnHeader7 As ColumnHeader
    Friend WithEvents ColumnHeader8 As ColumnHeader
    Friend WithEvents ColumnHeader9 As ColumnHeader
End Class
