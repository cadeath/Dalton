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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboAccessType = New System.Windows.Forms.ComboBox()
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
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
        Me.txtPrivilegeType.Location = New System.Drawing.Point(86, 13)
        Me.txtPrivilegeType.Name = "txtPrivilegeType"
        Me.txtPrivilegeType.Size = New System.Drawing.Size(172, 20)
        Me.txtPrivilegeType.TabIndex = 0
        '
        'lvPrivilegeType
        '
        Me.lvPrivilegeType.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2})
        Me.lvPrivilegeType.FullRowSelect = True
        Me.lvPrivilegeType.Location = New System.Drawing.Point(12, 75)
        Me.lvPrivilegeType.Name = "lvPrivilegeType"
        Me.lvPrivilegeType.Size = New System.Drawing.Size(246, 195)
        Me.lvPrivilegeType.TabIndex = 4
        Me.lvPrivilegeType.UseCompatibleStateImageBehavior = False
        Me.lvPrivilegeType.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Privilege Type"
        Me.ColumnHeader1.Width = 140
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(264, 77)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "PrivilegeType"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "AccessType"
        '
        'cboAccessType
        '
        Me.cboAccessType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboAccessType.FormattingEnabled = True
        Me.cboAccessType.Items.AddRange(New Object() {"Full Access", "Read Only", "No Access"})
        Me.cboAccessType.Location = New System.Drawing.Point(86, 43)
        Me.cboAccessType.Name = "cboAccessType"
        Me.cboAccessType.Size = New System.Drawing.Size(172, 21)
        Me.cboAccessType.TabIndex = 7
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "AccessType"
        Me.ColumnHeader2.Width = 101
        '
        'frmaddPrivilege
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(337, 279)
        Me.Controls.Add(Me.cboAccessType)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnRemove)
        Me.Controls.Add(Me.lvPrivilegeType)
        Me.Controls.Add(Me.txtPrivilegeType)
        Me.Controls.Add(Me.btnAdd)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
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
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboAccessType As System.Windows.Forms.ComboBox
End Class
