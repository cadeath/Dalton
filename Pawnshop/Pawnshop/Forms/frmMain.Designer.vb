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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        Me.msMenu = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CloseOpenStore = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClosingStoreToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.UserManagementToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.UpdateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.RateToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.LogOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExpiryGeneratorToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JournalEntriesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BSPReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashCountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemPulloutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ORManagerToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BackupToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ConsoleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.SequenceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashInOutSummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator()
        Me.OutstandingToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LoanRegisterToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MoneyTransferToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InsuranceToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DollarReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CashInOutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SegregatedListToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ItemPulloutToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator()
        Me.HourlyReportToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.HourlySummaryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.DailyCashCountToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.TutorialToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ChangelogToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AboutUsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.pbLogo = New System.Windows.Forms.PictureBox()
        Me.pInfo = New System.Windows.Forms.Panel()
        Me.lblMessage = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.pButton = New System.Windows.Forms.Panel()
        Me.btnCash = New System.Windows.Forms.Button()
        Me.btnPOS = New System.Windows.Forms.Button()
        Me.btnBranch = New System.Windows.Forms.Button()
        Me.btnDollarBuying = New System.Windows.Forms.Button()
        Me.btnLayAway = New System.Windows.Forms.Button()
        Me.btnInsurance = New System.Windows.Forms.Button()
        Me.btnMoneyTransfer = New System.Windows.Forms.Button()
        Me.btnClient = New System.Windows.Forms.Button()
        Me.btnPawning = New System.Windows.Forms.Button()
        Me.statusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsCurrentDate = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsUser = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tmrCurrent = New System.Windows.Forms.Timer(Me.components)
        Me.webAds = New System.Windows.Forms.WebBrowser()
        Me.bannerSize = New System.Windows.Forms.PictureBox()
        Me.ChangePasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.msMenu.SuspendLayout()
        CType(Me.pbLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.pInfo.SuspendLayout()
        Me.pButton.SuspendLayout()
        Me.statusStrip.SuspendLayout()
        CType(Me.bannerSize, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'msMenu
        '
        Me.msMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem, Me.ToolsToolStripMenuItem, Me.ReportToolStripMenuItem, Me.AboutToolStripMenuItem})
        Me.msMenu.Location = New System.Drawing.Point(0, 0)
        Me.msMenu.Name = "msMenu"
        Me.msMenu.Size = New System.Drawing.Size(1063, 24)
        Me.msMenu.TabIndex = 0
        Me.msMenu.Text = "msMenu"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CloseOpenStore, Me.ClosingStoreToolStripMenuItem, Me.ToolStripSeparator3, Me.UserManagementToolStripMenuItem, Me.UpdateToolStripMenuItem, Me.RateToolStripMenuItem, Me.SettingsToolStripMenuItem, Me.ToolStripSeparator1, Me.LogOutToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "&File"
        '
        'CloseOpenStore
        '
        Me.CloseOpenStore.Name = "CloseOpenStore"
        Me.CloseOpenStore.Size = New System.Drawing.Size(171, 22)
        Me.CloseOpenStore.Text = "&Open Store"
        '
        'ClosingStoreToolStripMenuItem
        '
        Me.ClosingStoreToolStripMenuItem.Name = "ClosingStoreToolStripMenuItem"
        Me.ClosingStoreToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ClosingStoreToolStripMenuItem.Text = "&Close Store"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(168, 6)
        '
        'UserManagementToolStripMenuItem
        '
        Me.UserManagementToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ChangePasswordToolStripMenuItem})
        Me.UserManagementToolStripMenuItem.Name = "UserManagementToolStripMenuItem"
        Me.UserManagementToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UserManagementToolStripMenuItem.Text = "User &Management"
        '
        'UpdateToolStripMenuItem
        '
        Me.UpdateToolStripMenuItem.Name = "UpdateToolStripMenuItem"
        Me.UpdateToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.UpdateToolStripMenuItem.Text = "&Maintenance"
        Me.UpdateToolStripMenuItem.Visible = False
        '
        'RateToolStripMenuItem
        '
        Me.RateToolStripMenuItem.Name = "RateToolStripMenuItem"
        Me.RateToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.RateToolStripMenuItem.Text = "&Rate"
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
        'LogOutToolStripMenuItem
        '
        Me.LogOutToolStripMenuItem.Name = "LogOutToolStripMenuItem"
        Me.LogOutToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.LogOutToolStripMenuItem.Text = "&Log Out"
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(171, 22)
        Me.ExitToolStripMenuItem.Text = "E&xit"
        '
        'ToolsToolStripMenuItem
        '
        Me.ToolsToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ExpiryGeneratorToolStripMenuItem, Me.JournalEntriesToolStripMenuItem, Me.BSPReportToolStripMenuItem, Me.CashCountToolStripMenuItem, Me.ItemPulloutToolStripMenuItem, Me.ORManagerToolStripMenuItem, Me.ToolStripSeparator2, Me.BackupToolStripMenuItem, Me.ConsoleToolStripMenuItem})
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
        'BSPReportToolStripMenuItem
        '
        Me.BSPReportToolStripMenuItem.Name = "BSPReportToolStripMenuItem"
        Me.BSPReportToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.BSPReportToolStripMenuItem.Text = "&BSP Report"
        '
        'CashCountToolStripMenuItem
        '
        Me.CashCountToolStripMenuItem.Name = "CashCountToolStripMenuItem"
        Me.CashCountToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.CashCountToolStripMenuItem.Text = "&Cash Count"
        Me.CashCountToolStripMenuItem.Visible = False
        '
        'ItemPulloutToolStripMenuItem
        '
        Me.ItemPulloutToolStripMenuItem.Name = "ItemPulloutToolStripMenuItem"
        Me.ItemPulloutToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ItemPulloutToolStripMenuItem.Text = "&Item Pullout"
        '
        'ORManagerToolStripMenuItem
        '
        Me.ORManagerToolStripMenuItem.Name = "ORManagerToolStripMenuItem"
        Me.ORManagerToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ORManagerToolStripMenuItem.Text = "&Print Manager"
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
        'ConsoleToolStripMenuItem
        '
        Me.ConsoleToolStripMenuItem.Name = "ConsoleToolStripMenuItem"
        Me.ConsoleToolStripMenuItem.Size = New System.Drawing.Size(160, 22)
        Me.ConsoleToolStripMenuItem.Text = "&Console"
        '
        'ReportToolStripMenuItem
        '
        Me.ReportToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem2, Me.SequenceToolStripMenuItem, Me.CashInOutSummaryToolStripMenuItem, Me.ToolStripSeparator5, Me.OutstandingToolStripMenuItem, Me.LoanRegisterToolStripMenuItem, Me.MoneyTransferToolStripMenuItem, Me.InsuranceToolStripMenuItem, Me.DollarReportToolStripMenuItem, Me.CashInOutToolStripMenuItem, Me.SegregatedListToolStripMenuItem, Me.ItemPulloutToolStripMenuItem1, Me.ToolStripSeparator4, Me.HourlyReportToolStripMenuItem, Me.HourlySummaryToolStripMenuItem, Me.DailyCashCountToolStripMenuItem})
        Me.ReportToolStripMenuItem.Name = "ReportToolStripMenuItem"
        Me.ReportToolStripMenuItem.Size = New System.Drawing.Size(54, 20)
        Me.ReportToolStripMenuItem.Text = "&Report"
        '
        'ToolStripMenuItem2
        '
        Me.ToolStripMenuItem2.Name = "ToolStripMenuItem2"
        Me.ToolStripMenuItem2.Size = New System.Drawing.Size(192, 22)
        Me.ToolStripMenuItem2.Text = "&Monthly Reports"
        '
        'SequenceToolStripMenuItem
        '
        Me.SequenceToolStripMenuItem.Name = "SequenceToolStripMenuItem"
        Me.SequenceToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SequenceToolStripMenuItem.Text = "&Sequence"
        '
        'CashInOutSummaryToolStripMenuItem
        '
        Me.CashInOutSummaryToolStripMenuItem.Name = "CashInOutSummaryToolStripMenuItem"
        Me.CashInOutSummaryToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CashInOutSummaryToolStripMenuItem.Text = "Cash In/Out Summary"
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(189, 6)
        '
        'OutstandingToolStripMenuItem
        '
        Me.OutstandingToolStripMenuItem.Name = "OutstandingToolStripMenuItem"
        Me.OutstandingToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.OutstandingToolStripMenuItem.Text = "&Outstanding"
        '
        'LoanRegisterToolStripMenuItem
        '
        Me.LoanRegisterToolStripMenuItem.Name = "LoanRegisterToolStripMenuItem"
        Me.LoanRegisterToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.LoanRegisterToolStripMenuItem.Text = "&Loan Register"
        '
        'MoneyTransferToolStripMenuItem
        '
        Me.MoneyTransferToolStripMenuItem.Name = "MoneyTransferToolStripMenuItem"
        Me.MoneyTransferToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.MoneyTransferToolStripMenuItem.Text = "Money Transfer"
        '
        'InsuranceToolStripMenuItem
        '
        Me.InsuranceToolStripMenuItem.Name = "InsuranceToolStripMenuItem"
        Me.InsuranceToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.InsuranceToolStripMenuItem.Text = "&Insurance"
        '
        'DollarReportToolStripMenuItem
        '
        Me.DollarReportToolStripMenuItem.Name = "DollarReportToolStripMenuItem"
        Me.DollarReportToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.DollarReportToolStripMenuItem.Text = "D&ollar Report"
        '
        'CashInOutToolStripMenuItem
        '
        Me.CashInOutToolStripMenuItem.Name = "CashInOutToolStripMenuItem"
        Me.CashInOutToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.CashInOutToolStripMenuItem.Text = "Cash I&n/Out"
        '
        'SegregatedListToolStripMenuItem
        '
        Me.SegregatedListToolStripMenuItem.Name = "SegregatedListToolStripMenuItem"
        Me.SegregatedListToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.SegregatedListToolStripMenuItem.Text = "Segregated List"
        '
        'ItemPulloutToolStripMenuItem1
        '
        Me.ItemPulloutToolStripMenuItem1.Name = "ItemPulloutToolStripMenuItem1"
        Me.ItemPulloutToolStripMenuItem1.Size = New System.Drawing.Size(192, 22)
        Me.ItemPulloutToolStripMenuItem1.Text = "Item &Pullout"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(189, 6)
        '
        'HourlyReportToolStripMenuItem
        '
        Me.HourlyReportToolStripMenuItem.Name = "HourlyReportToolStripMenuItem"
        Me.HourlyReportToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.HourlyReportToolStripMenuItem.Text = "&Hourly Report"
        '
        'HourlySummaryToolStripMenuItem
        '
        Me.HourlySummaryToolStripMenuItem.Name = "HourlySummaryToolStripMenuItem"
        Me.HourlySummaryToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.HourlySummaryToolStripMenuItem.Text = "H&ourly Summary"
        '
        'DailyCashCountToolStripMenuItem
        '
        Me.DailyCashCountToolStripMenuItem.Name = "DailyCashCountToolStripMenuItem"
        Me.DailyCashCountToolStripMenuItem.Size = New System.Drawing.Size(192, 22)
        Me.DailyCashCountToolStripMenuItem.Text = "&Daily Cash Count"
        '
        'AboutToolStripMenuItem
        '
        Me.AboutToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.TutorialToolStripMenuItem, Me.ChangelogToolStripMenuItem, Me.AboutUsToolStripMenuItem})
        Me.AboutToolStripMenuItem.Name = "AboutToolStripMenuItem"
        Me.AboutToolStripMenuItem.Size = New System.Drawing.Size(44, 20)
        Me.AboutToolStripMenuItem.Text = "&Help"
        '
        'TutorialToolStripMenuItem
        '
        Me.TutorialToolStripMenuItem.Name = "TutorialToolStripMenuItem"
        Me.TutorialToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.TutorialToolStripMenuItem.Text = "&Tutorial"
        '
        'ChangelogToolStripMenuItem
        '
        Me.ChangelogToolStripMenuItem.Name = "ChangelogToolStripMenuItem"
        Me.ChangelogToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.ChangelogToolStripMenuItem.Text = "&Changelog"
        '
        'AboutUsToolStripMenuItem
        '
        Me.AboutUsToolStripMenuItem.Name = "AboutUsToolStripMenuItem"
        Me.AboutUsToolStripMenuItem.Size = New System.Drawing.Size(132, 22)
        Me.AboutUsToolStripMenuItem.Text = "&About Us"
        '
        'pbLogo
        '
        Me.pbLogo.Dock = System.Windows.Forms.DockStyle.Top
        Me.pbLogo.Image = CType(resources.GetObject("pbLogo.Image"), System.Drawing.Image)
        Me.pbLogo.Location = New System.Drawing.Point(0, 24)
        Me.pbLogo.Name = "pbLogo"
        Me.pbLogo.Size = New System.Drawing.Size(1063, 120)
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
        Me.pInfo.Size = New System.Drawing.Size(365, 417)
        Me.pInfo.TabIndex = 5
        Me.pInfo.Visible = False
        '
        'lblMessage
        '
        Me.lblMessage.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblMessage.Location = New System.Drawing.Point(15, 41)
        Me.lblMessage.Name = "lblMessage"
        Me.lblMessage.Size = New System.Drawing.Size(310, 366)
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
        Me.pButton.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.pButton.Controls.Add(Me.btnCash)
        Me.pButton.Controls.Add(Me.btnPOS)
        Me.pButton.Controls.Add(Me.btnBranch)
        Me.pButton.Controls.Add(Me.btnDollarBuying)
        Me.pButton.Controls.Add(Me.btnLayAway)
        Me.pButton.Controls.Add(Me.btnInsurance)
        Me.pButton.Controls.Add(Me.btnMoneyTransfer)
        Me.pButton.Controls.Add(Me.btnClient)
        Me.pButton.Controls.Add(Me.btnPawning)
        Me.pButton.Location = New System.Drawing.Point(543, 161)
        Me.pButton.Name = "pButton"
        Me.pButton.Size = New System.Drawing.Size(503, 334)
        Me.pButton.TabIndex = 0
        '
        'btnCash
        '
        Me.btnCash.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCash.Location = New System.Drawing.Point(349, 231)
        Me.btnCash.Name = "btnCash"
        Me.btnCash.Size = New System.Drawing.Size(137, 90)
        Me.btnCash.TabIndex = 26
        Me.btnCash.Text = "Cash In/Out"
        Me.btnCash.UseVisualStyleBackColor = True
        '
        'btnPOS
        '
        Me.btnPOS.Anchor = System.Windows.Forms.AnchorStyles.Bottom
        Me.btnPOS.Location = New System.Drawing.Point(185, 231)
        Me.btnPOS.Name = "btnPOS"
        Me.btnPOS.Size = New System.Drawing.Size(137, 90)
        Me.btnPOS.TabIndex = 25
        Me.btnPOS.Text = "POS"
        Me.btnPOS.UseVisualStyleBackColor = True
        '
        'btnBranch
        '
        Me.btnBranch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnBranch.Location = New System.Drawing.Point(22, 231)
        Me.btnBranch.Name = "btnBranch"
        Me.btnBranch.Size = New System.Drawing.Size(137, 90)
        Me.btnBranch.TabIndex = 24
        Me.btnBranch.Text = "Branch2Branch"
        Me.btnBranch.UseVisualStyleBackColor = True
        '
        'btnDollarBuying
        '
        Me.btnDollarBuying.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.btnDollarBuying.Location = New System.Drawing.Point(349, 120)
        Me.btnDollarBuying.Name = "btnDollarBuying"
        Me.btnDollarBuying.Size = New System.Drawing.Size(137, 90)
        Me.btnDollarBuying.TabIndex = 23
        Me.btnDollarBuying.Text = "Foreign Exchange"
        Me.btnDollarBuying.UseVisualStyleBackColor = True
        '
        'btnLayAway
        '
        Me.btnLayAway.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnLayAway.Location = New System.Drawing.Point(185, 120)
        Me.btnLayAway.Name = "btnLayAway"
        Me.btnLayAway.Size = New System.Drawing.Size(137, 90)
        Me.btnLayAway.TabIndex = 22
        Me.btnLayAway.Text = "Lay Away"
        Me.btnLayAway.UseVisualStyleBackColor = True
        '
        'btnInsurance
        '
        Me.btnInsurance.Anchor = System.Windows.Forms.AnchorStyles.Left
        Me.btnInsurance.Location = New System.Drawing.Point(22, 120)
        Me.btnInsurance.Name = "btnInsurance"
        Me.btnInsurance.Size = New System.Drawing.Size(137, 90)
        Me.btnInsurance.TabIndex = 21
        Me.btnInsurance.Text = "Insurance"
        Me.btnInsurance.UseVisualStyleBackColor = True
        '
        'btnMoneyTransfer
        '
        Me.btnMoneyTransfer.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnMoneyTransfer.Location = New System.Drawing.Point(349, 17)
        Me.btnMoneyTransfer.Name = "btnMoneyTransfer"
        Me.btnMoneyTransfer.Size = New System.Drawing.Size(137, 90)
        Me.btnMoneyTransfer.TabIndex = 20
        Me.btnMoneyTransfer.Text = "Money Transfer"
        Me.btnMoneyTransfer.UseVisualStyleBackColor = True
        '
        'btnClient
        '
        Me.btnClient.Anchor = System.Windows.Forms.AnchorStyles.Top
        Me.btnClient.Location = New System.Drawing.Point(185, 17)
        Me.btnClient.Name = "btnClient"
        Me.btnClient.Size = New System.Drawing.Size(137, 90)
        Me.btnClient.TabIndex = 19
        Me.btnClient.Text = "Client"
        Me.btnClient.UseVisualStyleBackColor = True
        '
        'btnPawning
        '
        Me.btnPawning.Location = New System.Drawing.Point(22, 17)
        Me.btnPawning.Name = "btnPawning"
        Me.btnPawning.Size = New System.Drawing.Size(137, 90)
        Me.btnPawning.TabIndex = 18
        Me.btnPawning.Text = "Pawning"
        Me.btnPawning.UseVisualStyleBackColor = True
        '
        'statusStrip
        '
        Me.statusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsCurrentDate, Me.tsUser})
        Me.statusStrip.Location = New System.Drawing.Point(0, 581)
        Me.statusStrip.Name = "statusStrip"
        Me.statusStrip.Size = New System.Drawing.Size(1063, 22)
        Me.statusStrip.TabIndex = 6
        Me.statusStrip.Text = "ss"
        '
        'tsCurrentDate
        '
        Me.tsCurrentDate.Name = "tsCurrentDate"
        Me.tsCurrentDate.Size = New System.Drawing.Size(70, 17)
        Me.tsCurrentDate.Text = "Date not set"
        '
        'tsUser
        '
        Me.tsUser.BackColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.tsUser.Name = "tsUser"
        Me.tsUser.Size = New System.Drawing.Size(68, 17)
        Me.tsUser.Text = "No User yet"
        '
        'tmrCurrent
        '
        Me.tmrCurrent.Enabled = True
        '
        'webAds
        '
        Me.webAds.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.webAds.Location = New System.Drawing.Point(15, 520)
        Me.webAds.MinimumSize = New System.Drawing.Size(20, 20)
        Me.webAds.Name = "webAds"
        Me.webAds.ScrollBarsEnabled = False
        Me.webAds.Size = New System.Drawing.Size(322, 56)
        Me.webAds.TabIndex = 7
        Me.webAds.Visible = False
        '
        'bannerSize
        '
        Me.bannerSize.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.bannerSize.Image = CType(resources.GetObject("bannerSize.Image"), System.Drawing.Image)
        Me.bannerSize.Location = New System.Drawing.Point(0, 522)
        Me.bannerSize.Name = "bannerSize"
        Me.bannerSize.Size = New System.Drawing.Size(322, 56)
        Me.bannerSize.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.bannerSize.TabIndex = 9
        Me.bannerSize.TabStop = False
        Me.bannerSize.Visible = False
        '
        'ChangePasswordToolStripMenuItem
        '
        Me.ChangePasswordToolStripMenuItem.Name = "ChangePasswordToolStripMenuItem"
        Me.ChangePasswordToolStripMenuItem.Size = New System.Drawing.Size(168, 22)
        Me.ChangePasswordToolStripMenuItem.Text = "Change &Password"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(106, Byte), Integer), CType(CType(185, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1063, 603)
        Me.Controls.Add(Me.bannerSize)
        Me.Controls.Add(Me.statusStrip)
        Me.Controls.Add(Me.pButton)
        Me.Controls.Add(Me.pbLogo)
        Me.Controls.Add(Me.msMenu)
        Me.Controls.Add(Me.pInfo)
        Me.Controls.Add(Me.webAds)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
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
        Me.statusStrip.ResumeLayout(False)
        Me.statusStrip.PerformLayout()
        CType(Me.bannerSize, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents btnCash As System.Windows.Forms.Button
    Friend WithEvents btnPOS As System.Windows.Forms.Button
    Friend WithEvents btnBranch As System.Windows.Forms.Button
    Friend WithEvents btnDollarBuying As System.Windows.Forms.Button
    Friend WithEvents btnLayAway As System.Windows.Forms.Button
    Friend WithEvents btnInsurance As System.Windows.Forms.Button
    Friend WithEvents btnMoneyTransfer As System.Windows.Forms.Button
    Friend WithEvents btnClient As System.Windows.Forms.Button
    Friend WithEvents btnPawning As System.Windows.Forms.Button
    Friend WithEvents AboutUsToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CloseOpenStore As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents statusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents tsCurrentDate As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tmrCurrent As System.Windows.Forms.Timer
    Friend WithEvents LogOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsUser As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents ConsoleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClosingStoreToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemPulloutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LoanRegisterToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripMenuItem2 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents DailyCashCountToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SequenceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SegregatedListToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashInOutSummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents MoneyTransferToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents OutstandingToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ItemPulloutToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents RateToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents webAds As System.Windows.Forms.WebBrowser
    Friend WithEvents bannerSize As System.Windows.Forms.PictureBox
    Friend WithEvents InsuranceToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ORManagerToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HourlyReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CashInOutToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents HourlySummaryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents BSPReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DollarReportToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangelogToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ChangePasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
