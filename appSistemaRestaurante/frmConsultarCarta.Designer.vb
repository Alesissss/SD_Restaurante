﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmConsultarCarta
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmConsultarCarta))
        Me.lsvCarta = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.pnlDatos = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnCarta1 = New System.Windows.Forms.Button()
        Me.btnCarta2 = New System.Windows.Forms.Button()
        Me.pnlDatos.SuspendLayout()
        Me.SuspendLayout()
        '
        'lsvCarta
        '
        Me.lsvCarta.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lsvCarta.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.lsvCarta.FullRowSelect = True
        Me.lsvCarta.GridLines = True
        Me.lsvCarta.HideSelection = False
        Me.lsvCarta.Location = New System.Drawing.Point(12, 65)
        Me.lsvCarta.Name = "lsvCarta"
        Me.lsvCarta.Size = New System.Drawing.Size(776, 384)
        Me.lsvCarta.TabIndex = 0
        Me.lsvCarta.UseCompatibleStateImageBehavior = False
        Me.lsvCarta.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "NOMBRE"
        Me.ColumnHeader1.Width = 352
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "DESCRIPCION"
        Me.ColumnHeader2.Width = 446
        '
        'pnlDatos
        '
        Me.pnlDatos.BackColor = System.Drawing.Color.LightBlue
        Me.pnlDatos.Controls.Add(Me.btnCarta2)
        Me.pnlDatos.Controls.Add(Me.btnCarta1)
        Me.pnlDatos.Controls.Add(Me.Label1)
        Me.pnlDatos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.pnlDatos.Location = New System.Drawing.Point(12, 12)
        Me.pnlDatos.Name = "pnlDatos"
        Me.pnlDatos.Size = New System.Drawing.Size(162, 47)
        Me.pnlDatos.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!)
        Me.Label1.Location = New System.Drawing.Point(18, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Carta N*"
        '
        'btnCarta1
        '
        Me.btnCarta1.Location = New System.Drawing.Point(89, 11)
        Me.btnCarta1.Name = "btnCarta1"
        Me.btnCarta1.Size = New System.Drawing.Size(28, 30)
        Me.btnCarta1.TabIndex = 1
        Me.btnCarta1.Text = "1"
        Me.btnCarta1.UseVisualStyleBackColor = True
        '
        'btnCarta2
        '
        Me.btnCarta2.Location = New System.Drawing.Point(123, 11)
        Me.btnCarta2.Name = "btnCarta2"
        Me.btnCarta2.Size = New System.Drawing.Size(28, 31)
        Me.btnCarta2.TabIndex = 2
        Me.btnCarta2.Text = "2"
        Me.btnCarta2.UseVisualStyleBackColor = True
        '
        'frmConsultarCarta
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.pnlDatos)
        Me.Controls.Add(Me.lsvCarta)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmConsultarCarta"
        Me.Text = ".: CONSULTAR CARTA :."
        Me.pnlDatos.ResumeLayout(False)
        Me.pnlDatos.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lsvCarta As ListView
    Friend WithEvents ColumnHeader1 As ColumnHeader
    Friend WithEvents ColumnHeader2 As ColumnHeader
    Friend WithEvents pnlDatos As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnCarta2 As Button
    Friend WithEvents btnCarta1 As Button
End Class
