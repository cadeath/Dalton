<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBackup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBackup))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.chkOn3 = New System.Windows.Forms.CheckBox()
        Me.chkOn2 = New System.Windows.Forms.CheckBox()
        Me.chkCP3 = New System.Windows.Forms.CheckBox()
        Me.chkCP2 = New System.Windows.Forms.CheckBox()
        Me.btnBrowse3 = New System.Windows.Forms.Button()
        Me.btnBrowse2 = New System.Windows.Forms.Button()
        Me.btnBrowse1 = New System.Windows.Forms.Button()
        Me.txtPath3 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPath2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPath1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lstFileList = New System.Windows.Forms.ListBox()
        Me.btnExecute = New System.Windows.Forms.Button()
        Me.btnBrowseFile = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkOn3)
        Me.GroupBox1.Controls.Add(Me.chkOn2)
        Me.GroupBox1.Controls.Add(Me.chkCP3)
        Me.GroupBox1.Controls.Add(Me.chkCP2)
        Me.GroupBox1.Controls.Add(Me.btnBrowse3)
        Me.GroupBox1.Controls.Add(Me.btnBrowse2)
        Me.GroupBox1.Controls.Add(Me.btnBrowse1)
        Me.GroupBox1.Controls.Add(Me.txtPath3)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtPath2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtPath1)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(254, 258)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Redundancy"
        '
        'chkOn3
        '
        Me.chkOn3.AutoSize = True
        Me.chkOn3.Location = New System.Drawing.Point(208, 182)
        Me.chkOn3.Name = "chkOn3"
        Me.chkOn3.Size = New System.Drawing.Size(40, 17)
        Me.chkOn3.TabIndex = 16
        Me.chkOn3.Text = "On"
        Me.chkOn3.UseVisualStyleBackColor = True
        '
        'chkOn2
        '
        Me.chkOn2.AutoSize = True
        Me.chkOn2.Location = New System.Drawing.Point(208, 93)
        Me.chkOn2.Name = "chkOn2"
        Me.chkOn2.Size = New System.Drawing.Size(40, 17)
        Me.chkOn2.TabIndex = 15
        Me.chkOn2.Text = "On"
        Me.chkOn2.UseVisualStyleBackColor = True
        '
        'chkCP3
        '
        Me.chkCP3.AutoSize = True
        Me.chkCP3.Location = New System.Drawing.Point(9, 228)
        Me.chkCP3.Name = "chkCP3"
        Me.chkCP3.Size = New System.Drawing.Size(82, 17)
        Me.chkCP3.TabIndex = 7
        Me.chkCP3.Text = "Copy/Paste"
        Me.chkCP3.UseVisualStyleBackColor = True
        '
        'chkCP2
        '
        Me.chkCP2.AutoSize = True
        Me.chkCP2.Location = New System.Drawing.Point(9, 139)
        Me.chkCP2.Name = "chkCP2"
        Me.chkCP2.Size = New System.Drawing.Size(82, 17)
        Me.chkCP2.TabIndex = 4
        Me.chkCP2.Text = "Copy/Paste"
        Me.chkCP2.UseVisualStyleBackColor = True
        '
        'btnBrowse3
        '
        Me.btnBrowse3.Location = New System.Drawing.Point(173, 228)
        Me.btnBrowse3.Name = "btnBrowse3"
        Me.btnBrowse3.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse3.TabIndex = 8
        Me.btnBrowse3.Text = "Browse"
        Me.btnBrowse3.UseVisualStyleBackColor = True
        '
        'btnBrowse2
        '
        Me.btnBrowse2.Location = New System.Drawing.Point(173, 139)
        Me.btnBrowse2.Name = "btnBrowse2"
        Me.btnBrowse2.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse2.TabIndex = 5
        Me.btnBrowse2.Text = "Browse"
        Me.btnBrowse2.UseVisualStyleBackColor = True
        '
        'btnBrowse1
        '
        Me.btnBrowse1.Location = New System.Drawing.Point(173, 58)
        Me.btnBrowse1.Name = "btnBrowse1"
        Me.btnBrowse1.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse1.TabIndex = 2
        Me.btnBrowse1.Text = "Browse"
        Me.btnBrowse1.UseVisualStyleBackColor = True
        '
        'txtPath3
        '
        Me.txtPath3.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath3.Location = New System.Drawing.Point(9, 202)
        Me.txtPath3.Name = "txtPath3"
        Me.txtPath3.ReadOnly = True
        Me.txtPath3.Size = New System.Drawing.Size(239, 20)
        Me.txtPath3.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 186)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Path 3"
        '
        'txtPath2
        '
        Me.txtPath2.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath2.Location = New System.Drawing.Point(9, 113)
        Me.txtPath2.Name = "txtPath2"
        Me.txtPath2.ReadOnly = True
        Me.txtPath2.Size = New System.Drawing.Size(239, 20)
        Me.txtPath2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Path 2"
        '
        'txtPath1
        '
        Me.txtPath1.BackColor = System.Drawing.SystemColors.Window
        Me.txtPath1.Location = New System.Drawing.Point(9, 32)
        Me.txtPath1.Name = "txtPath1"
        Me.txtPath1.ReadOnly = True
        Me.txtPath1.Size = New System.Drawing.Size(239, 20)
        Me.txtPath1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(38, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Path 1"
        '
        'lstFileList
        '
        Me.lstFileList.FormattingEnabled = True
        Me.lstFileList.Location = New System.Drawing.Point(272, 12)
        Me.lstFileList.Name = "lstFileList"
        Me.lstFileList.Size = New System.Drawing.Size(180, 238)
        Me.lstFileList.TabIndex = 9
        '
        'btnExecute
        '
        Me.btnExecute.Location = New System.Drawing.Point(458, 12)
        Me.btnExecute.Name = "btnExecute"
        Me.btnExecute.Size = New System.Drawing.Size(121, 52)
        Me.btnExecute.TabIndex = 11
        Me.btnExecute.Text = "Execute Backup"
        Me.btnExecute.UseVisualStyleBackColor = True
        '
        'btnBrowseFile
        '
        Me.btnBrowseFile.Location = New System.Drawing.Point(377, 256)
        Me.btnBrowseFile.Name = "btnBrowseFile"
        Me.btnBrowseFile.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowseFile.TabIndex = 10
        Me.btnBrowseFile.Text = "Open Folder"
        Me.btnBrowseFile.UseVisualStyleBackColor = True
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(458, 99)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(121, 23)
        Me.btnClose.TabIndex = 13
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(458, 70)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(121, 23)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Text = "&Save Settings"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'frmBackup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(586, 284)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnBrowseFile)
        Me.Controls.Add(Me.btnExecute)
        Me.Controls.Add(Me.lstFileList)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "frmBackup"
        Me.Text = "Backup System"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents chkCP3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkCP2 As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrowse3 As System.Windows.Forms.Button
    Friend WithEvents btnBrowse2 As System.Windows.Forms.Button
    Friend WithEvents btnBrowse1 As System.Windows.Forms.Button
    Friend WithEvents txtPath3 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPath2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtPath1 As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lstFileList As System.Windows.Forms.ListBox
    Friend WithEvents btnExecute As System.Windows.Forms.Button
    Friend WithEvents btnBrowseFile As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkOn3 As System.Windows.Forms.CheckBox
    Friend WithEvents chkOn2 As System.Windows.Forms.CheckBox
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
End Class
