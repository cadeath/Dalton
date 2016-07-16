<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackUpDataSettings
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
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPath2 = New System.Windows.Forms.TextBox()
        Me.btnBrowseBackup = New System.Windows.Forms.Button()
        Me.btnBackup = New System.Windows.Forms.Button()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'fbdBackup
        '
        Me.fbdBackup.SelectedPath = "C:\"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPath2)
        Me.GroupBox2.Controls.Add(Me.btnBrowseBackup)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(302, 54)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Backup Directory"
        '
        'txtPath2
        '
        Me.txtPath2.Location = New System.Drawing.Point(6, 19)
        Me.txtPath2.Name = "txtPath2"
        Me.txtPath2.Size = New System.Drawing.Size(206, 20)
        Me.txtPath2.TabIndex = 5
        '
        'btnBrowseBackup
        '
        Me.btnBrowseBackup.Location = New System.Drawing.Point(218, 19)
        Me.btnBrowseBackup.Name = "btnBrowseBackup"
        Me.btnBrowseBackup.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseBackup.TabIndex = 6
        Me.btnBrowseBackup.Text = "Browse"
        Me.btnBrowseBackup.UseVisualStyleBackColor = True
        '
        'btnBackup
        '
        Me.btnBackup.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBackup.Location = New System.Drawing.Point(12, 72)
        Me.btnBackup.Name = "btnBackup"
        Me.btnBackup.Size = New System.Drawing.Size(302, 36)
        Me.btnBackup.TabIndex = 3
        Me.btnBackup.Text = "&Create File"
        Me.btnBackup.UseVisualStyleBackColor = True
        '
        'frmBackUpDataSettings
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 116)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnBackup)
        Me.Name = "frmBackUpDataSettings"
        Me.Text = "BackUp Data Settings"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents btnBackup As System.Windows.Forms.Button
    Friend WithEvents txtPath2 As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseBackup As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
