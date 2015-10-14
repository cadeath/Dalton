<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UserManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpiryGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JournalEntriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashCountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TutorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.pInfo = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pButton = New System.Windows.Forms.Panel()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.frmClientMngmnt = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.msMenu.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pInfo.SuspendLayout()
        Me.pButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'msMenu
        '
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ReportToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(908, 24)
        Me.msMenu.TabIndex = 0
        Me.msMenu.Text = "msMenu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UserManagementToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'UserManagementToolStripMenuItem
        '
        Me.UserManagementToolStripMenuItem.Name = "UserManagementToolStripMenuItem"
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UserManagementToolStripMenuItem.Text = "User &Management"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UpdateToolStripMenuItem.Text = "&Update Rate"
        '
        'SettingsToolStripMenuItem
        '
        Me.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem"
        Me.SettingsToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.SettingsToolStripMenuItem.Text = "&Settings"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(168, 6)
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpiryGeneratorToolStripMenuItem, Me.JournalEntriesToolStripMenuItem, Me.CashCountToolStripMenuItem, Me.ToolStripSeparator2, Me.BackupToolStripMenuItem})
        Me.ToolsToolStripMenuItem.Name = "ToolsToolStripMenuItem"
        Me.ToolsToolStripMenuItem.Size = New System.Drawing.Size(48, 20)
        Me.ToolsToolStripMenuItem.Text = "&Tools"
        '
        'ExpiryGeneratorToolStripMenuItem
        '
        Me.ExpiryGeneratorToolStripMenuItem.Name = "ExpiryGeneratorToolStripMenuItem"
        Me.ExpiryGeneratorToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ExpiryGeneratorToolStripMenuItem.Text = "&Expiry Generator"
        '
        'JournalEntriesToolStripMenuItem
        '
        Me.JournalEntriesToolStripMenuItem.Name = "JournalEntriesToolStripMenuItem"
        Me.JournalEntriesToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.JournalEntriesToolStripMenuItem.Text = "&Journal Entries"
        '
        'CashCountToolStripMenuItem
        '
        Me.CashCountToolStripMenuItem.Name = "CashCountToolStripMenuItem"
        Me.CashCountToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CashCountToolStripMenuItem.Text = "&Cash Count"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(157, 6)
        '
        'BackupToolStripMenuItem
        '
        Me.BackupToolStripMenuItem.Name = "BackupToolStripMenuItem"
        Me.BackupToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.BackupToolStripMenuItem.Text = "&Backup"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "&Report"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TutorialToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AboutToolStripMenuItem.Text = "&Help"
        '
        'TutorialToolStripMenuItem
        '
        Me.TutorialToolStripMenuItem.Name = "TutorialToolStripMenuItem"
        Me.TutorialToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.TutorialToolStripMenuItem.Text = "&Tutorial"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(123, 22)
        Me.AboutUsToolStripMenuItem.Text = "&About Us"
        '
        'pbLogo
        '
        Me.pbLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), System.Drawing.Image)
        Me.pbLogo.Location = New System.Drawing.Point(0, 24)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(908, 120)
        Me.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbLogo.TabIndex = 1
        Me.pbLogo.TabStop = False
        '
        'pInfo
        '
        Me.pInfo.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.pInfo.Controls.Add(Me.lblMessage)
        Me.pInfo.Controls.Add(Me.lblTitle)
        Me.pInfo.Location = New System.Drawing.Point(12, 161)
        Me.pInfo.Name = "pInfo"
        Me.pInfo.Size = New System.Drawing.Size(365, 333)
        Me.pInfo.TabIndex = 5
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.Location = New System.Drawing.Point(15, 41)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(310, 279)
        Me.lblMessage.TabIndex = 5
        Me.lblMessage.Text = resources.GetString("lblMessage.Text")
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Yellow
        Me.lblTitle.Location = New System.Drawing.Point(15, 16)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(209, 20)
        Me.lblTitle.TabIndex = 4
        Me.lblTitle.Text = "Pellentesque a libero nisl"
        '
        'pButton
        '
        Me.pButton.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pButton.Controls.Add(Me.Button7)
        Me.pButton.Controls.Add(Me.Button8)
        Me.pButton.Controls.Add(Me.Button9)
        Me.pButton.Controls.Add(Me.Button4)
        Me.pButton.Controls.Add(Me.Button5)
        Me.pButton.Controls.Add(Me.Button6)
        Me.pButton.Controls.Add(Me.Button3)
        Me.pButton.Controls.Add(Me.frmClientMngmnt)
        Me.pButton.Controls.Add(Me.Button1)
        Me.pButton.Location = New System.Drawing.Point(393, 160)
        Me.pButton.Name = "pButton"
        Me.pButton.Size = New System.Drawing.Size(503, 334)
        Me.pButton.TabIndex = 0
        '
        'Button7
        '
        Me.Button7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button7.Location = New System.Drawing.Point(349, 231)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(137, 90)
        Me.Button7.TabIndex = 26
        Me.Button7.Text = "Cash In/Out"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.Button8.Location = New System.Drawing.Point(185, 231)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(137, 90)
        Me.Button8.TabIndex = 25
        Me.Button8.Text = "POS"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Button9.Location = New System.Drawing.Point(22, 231)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(137, 90)
        Me.Button9.TabIndex = 24
        Me.Button9.Text = "Branch2Branch"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.Button4.Location = New System.Drawing.Point(349, 120)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(137, 90)
        Me.Button4.TabIndex = 23
        Me.Button4.Text = "Dollar Buying"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Button5.Location = New System.Drawing.Point(185, 120)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(137, 90)
        Me.Button5.TabIndex = 22
        Me.Button5.Text = "Lay Away"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.Button6.Location = New System.Drawing.Point(22, 120)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(137, 90)
        Me.Button6.TabIndex = 21
        Me.Button6.Text = "Insurance"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.Location = New System.Drawing.Point(349, 17)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(137, 90)
        Me.Button3.TabIndex = 20
        Me.Button3.Text = "Money Transfer"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'frmClientMngmnt
        '
        Me.frmClientMngmnt.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.frmClientMngmnt.Location = New System.Drawing.Point(185, 17)
        Me.frmClientMngmnt.Name = "frmClientMngmnt"
        Me.frmClientMngmnt.Size = New System.Drawing.Size(137, 90)
        Me.frmClientMngmnt.TabIndex = 19
        Me.frmClientMngmnt.Text = "Client"
        Me.frmClientMngmnt.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(22, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(137, 90)
        Me.Button1.TabIndex = 18
        Me.Button1.Text = "Pawning"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(908, 506)
        Me.Controls.Add(Me.pButton)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.pInfo)
        Me.MainMenuStrip = Me.msMenu
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pawnshop System"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.msMenu.ResumeLayout(False)
        Me.msMenu.PerformLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.pInfo.ResumeLayout(False)
        Me.pInfo.PerformLayout()
        Me.pButton.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents msMenu As System.Windows.Forms.MenuStrip
    Friend WithEvents FileToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pbLogo As System.Windows.Forms.PictureBox
    Friend WithEvents ReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AboutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UpdateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SettingsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents UserManagementToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExpiryGeneratorToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JournalEntriesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashCountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents BackupToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents TutorialToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents pInfo As System.Windows.Forms.Panel
    Friend WithEvents lblMessage As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents pButton As System.Windows.Forms.Panel
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents frmClientMngmnt As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
