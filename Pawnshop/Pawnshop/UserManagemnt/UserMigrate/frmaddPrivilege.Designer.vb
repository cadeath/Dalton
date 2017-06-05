<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmaddPrivilege
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnAdd = New System.Windows.Forms.Button()
        Me.txtPrivilegeType = New System.Windows.Forms.TextBox()
        Me.lvPrivilegeType = New System.Windows.Forms.ListView()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.btnRemove = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(264, 12)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(67, 23)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "&Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'txtPrivilegeType
        '
        Me.txtPrivilegeType.Location = New System.Drawing.Point(12, 12)
        Me.txtPrivilegeType.Name = "txtPrivilegeType"
        Me.txtPrivilegeType.Size = New System.Drawing.Size(246, 20)
        Me.txtPrivilegeType.TabIndex = 0
        '
        'lvPrivilegeType
        '
        Me.lvPrivilegeType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me.lvPrivilegeType.FullRowSelect = True
        Me.lvPrivilegeType.Location = New System.Drawing.Point(12, 38)
        Me.lvPrivilegeType.Name = "lvPrivilegeType"
        Me.lvPrivilegeType.Size = New System.Drawing.Size(246, 232)
        Me.lvPrivilegeType.TabIndex = 4
        Me.lvPrivilegeType.UseCompatibleStateImageBehavior = False
        Me.lvPrivilegeType.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Privilege Type"
        Me.ColumnHeader1.Width = 241
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(264, 41)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(67, 23)
        Me.btnRemove.TabIndex = 2
        Me.btnRemove.Text = "&Remove"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(264, 247)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(67, 23)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmaddPrivilege
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 279)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lvPrivilegeType)
        Me.Controls.Add(Me.txtPrivilegeType)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmaddPrivilege"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Add Privilege"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents txtPrivilegeType As System.Windows.Forms.TextBox
    Friend WithEvents lvPrivilegeType As System.Windows.Forms.ListView
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
End Class
