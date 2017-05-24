Imports totp

Public Class frmMain

    Dim s_USER As New Sys_user

    Friend dateSet As Boolean = False
    Friend doSegregate As Boolean = False
    Friend doExpiry As Boolean = False
    Friend doForfeitItem As Boolean = False

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        pButton.Enabled = Not st

        'File
        ChangePasswordToolStrip.Enabled = Not st
        CloseOpenStore.Enabled = Not st
        UserManagementToolStripMenuItem.Enabled = Not st
        UpdateToolStripMenuItem.Enabled = Not st
        SettingsToolStripMenuItem.Enabled = Not st
        RateToolStripMenuItem.Enabled = Not st
        If Not st Then
            LogOutToolStripMenuItem.Text = "&Log Out"
        Else
            LogOutToolStripMenuItem.Text = "&Login"
        End If

        'Tools
        ExpiryListToolStripMenuItem.Enabled = Not st
        ExpiryGeneratorToolStripMenuItem.Enabled = Not st
        JournalEntriesToolStripMenuItem.Enabled = Not st
        CashCountToolStripMenuItem.Enabled = Not st
        BSPReportToolStripMenuItem.Enabled = Not st
        ItemPulloutToolStripMenuItem.Enabled = Not st
        ORManagerToolStripMenuItem.Enabled = Not st
        AccountingExtractToolStripMenuItem.Enabled = Not st
        SalesToolStripMenuItem.Enabled = Not st
        StockInToolStripMenuItem.Enabled = Not st
        ItemMasterDataToolStripMenuItem.Enabled = Not st
        '-------------------------------------------------
        SalesToolStripMenuItem.Enabled = Not st
        StockInToolStripMenuItem.Enabled = Not st
        ItemMasterDataToolStripMenuItem.Enabled = Not st
        '-------------------------------------------------
        BackupToolStripMenuItem.Enabled = Not st
        AuditConsoleToolStripMenuItem.Enabled = Not st
        ConsoleToolStripMenuItem.Enabled = Not st

        If st Then
            tsUser.Text = "No User yet"
        Else
            tsUser.Text = "Greetings " & FullName
        End If

        'Reports
        MonthlyToolStripMenuItem.Enabled = Not st
        DailyToolStripMenuItem.Enabled = Not st
        HourlyReportToolStripMenuItem.Enabled = Not st
        HourlySummaryToolStripMenuItem.Enabled = Not st
        DailyCashCountToolStripMenuItem.Enabled = Not st
        SMSNoticeToolStripMenuItem1.Enabled = Not st
    End Sub

    Private Sub ExecuteSegregate()
        doSegregate = AutoSegregate()
    End Sub

    Private Sub ExecuteExpiry()
        If doExpiry Then
            Exit Sub
        End If
        doExpiry = True

        frmSMSnotice.autoStart = True
        Load_Expiry(frmSMSnotice)
    End Sub

    Private Sub Sample_Text()
        If Not DEV_MODE Then Exit Sub

        Dim msg As String = "This is a sample message from DIS (Dalton Integrated System) Prototype. Please be advice - SenderID testing"
        'smsUtil.SendSMS("639360944853", msg) 'Don2
        'smsUtil.SendSMS("639257977559", msg) 'Eskie
        'smsUtil.SendSMS("639363678923", msg) 'Emz
        'smsUtil.SendSMS("639553491069", msg) 'Irish
        'smsUtil.SendSMS("639553491065", msg) 'Neimrod
        'smsUtil.SendSMS("639999403288", msg) 'PTU
        'smsUtil.SendSMS("639228072094", msg) 'LYU
        'smsUtil.SendSMS("639228323324", msg) 'PTU

        'Console.WriteLine("Sample texting sent")
    End Sub

    Private Sub ExecuteForfeiting()
        doForfeitItem = DoForfeitingItem()
    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pButton.Location = New Point(450, 160)
        'Generate_QR()
        Me.Text = My.Application.Info.Title & " | Version " & Me.GetType.Assembly.GetName.Version.ToString & IIf(mod_system.DEV_MODE, " <<DEVELOPER MODE>>", "")
        Me.Text &= IIf(mod_system.PROTOTYPE, " !!PROTOTYPE!!", "")
        If Not ConfiguringDB() Then MsgBox("DATABASE CONNECTION PROBLEM", MsgBoxStyle.Critical) : Exit Sub

        Patch_if_Patchable()

        If Not DBCompatibilityCheck() Then MsgBox("Please update the database version", MsgBoxStyle.Critical) : End

        If POSuser.UserName = "" Then
            Console.WriteLine("Not Yet Login")
            NotYetLogin()
        Else
            Console.WriteLine(POSuser.FullName & " welcome!")
            NotYetLogin(False)
        End If
        ' Set the color in the MDI client.
        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                ctl.BackColor = Me.BackColor
            End If
        Next ctl

        If Not CheckSystem() Then
            frmSettings.Show()
            frmSettings.Focus()
            frmSettings.TopMost = True
        End If

        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()
    End Sub

    Friend Sub CheckStoreStatus()
        mod_system.LoadCurrentDate()
        'CloseOpenStore.Enabled = Not dateSet
    End Sub

    Friend Sub LoadChild(ByVal frm As Form)
        frm.MdiParent = Me
        frm.TopMost = True
        frm.BringToFront()
        frm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        If UType = "Admin" Then frmSettings.AccessType = "Full Access" : GoTo NExtLine
        Select Case AccountRule.HasPrivilege("Settings")
            Case "Full Access"
                frmSettings.AccessType = AccountRule.HasPrivilege("Settings")
            Case "Read Only"
                frmSettings.AccessType = AccountRule.HasPrivilege("Settings")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmSettings.AccessType)
        frmSettings.Show()

    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        If UType = "Admin" Then frmUserManagementNew.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("User Management")
            Case "Full Access"
                frmUserManagementNew.AccessType = AccountRule.HasPrivilege("User Management")
            Case "Read Only"
                frmUserManagementNew.AccessType = AccountRule.HasPrivilege("User Management")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmUserManagementNew.AccessType)
        frmUserManagementNew.Show()
    End Sub

    Private Sub ExpiryGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryGeneratorToolStripMenuItem.Click
        If UType = "Admin" Then frmExtractor.accessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Expiry List")
            Case "Full Access"
                frmExtractor.accessType = AccountRule.HasPrivilege("Expiry List")
            Case "Read Only"
                frmExtractor.accessType = AccountRule.HasPrivilege("Expiry List")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmExtractor.accessType)
        frmExtractor.FormType = frmExtractor.ExtractType.Expiry
        frmExtractor.Show()
    End Sub

    Private Sub JournalEntriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntriesToolStripMenuItem.Click
        If UType = "Admin" Then frmExtractor.accessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Journal Entries")
            Case "Full Access"
                frmExtractor.accessType = AccountRule.HasPrivilege("Journal Entries")
            Case "Read Only"
                frmExtractor.accessType = AccountRule.HasPrivilege("Journal Entries")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmExtractor.accessType)
        frmExtractor.FormType = frmExtractor.ExtractType.JournalEntry
        frmExtractor.Show()
    End Sub

    Private Sub btnMoneyTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneyTransfer.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then frmMoneyTransfer.accessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Money Transfer")
            Case "Full Access"
                frmMoneyTransfer.accessType = AccountRule.HasPrivilege("Money Transfer")
            Case "Read Only"
                frmMoneyTransfer.accessType = AccountRule.HasPrivilege("Money Transfer")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmMoneyTransfer.accessType)
        frmMoneyTransfer.Show()
    End Sub

    Private Sub btnDollarBuying_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDollarBuying.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then frmmoneyexchange.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Dollar Buying")
            Case "Full Access"
                frmmoneyexchange.AccessType = AccountRule.HasPrivilege("Dollar Buying")
            Case "Read Only"
                frmmoneyexchange.AccessType = AccountRule.HasPrivilege("Dollar Buying")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmmoneyexchange.AccessType)
        frmmoneyexchange.Show()
    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then frmCashInOut2.AccessType = "Full Access" : GoTo Nextline

        Select Case AccountRule.HasPrivilege("Cash In/Out")
            Case "Full Access"
                frmCashInOut2.AccessType = AccountRule.HasPrivilege("Cash In/Out")
            Case "Read Only"
                frmCashInOut2.AccessType = AccountRule.HasPrivilege("Cash In/Out")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access to Cash In/Out.")
        End Select

nextline:
        frmCashInOut2.Show()
    End Sub

    Private Sub CloseOpenStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseOpenStore.Click
        If UType = "Admin" Then GoTo nextlineTODO

        Select Case AccountRule.HasPrivilege("Open Store")
            Case "Full Access"
                frmOpenStore.AccessType = AccountRule.HasPrivilege("Open Store")
            Case "Read Only"
                frmOpenStore.AccessType = AccountRule.HasPrivilege("Open Store")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

nextlineTODO:
        Console.WriteLine(frmOpenStore.AccessType)
        frmOpenStore.Show()
    End Sub

    Private Sub btnClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClient.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then GoTo nextlineTODO

        Select Case AccountRule.HasPrivilege("Client Management")
            Case "Full Access"
                frmClient.AccessType = AccountRule.HasPrivilege("Client Management")
            Case "Read Only"
                frmClient.AccessType = AccountRule.HasPrivilege("Client Management")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

nextlineTODO:
        Console.WriteLine(frmClient.AccessType)
        frmClient.Show()

        If Not (POSuser.isSuperUser Or POSuser.canClientManage) Then
            MsgBoxAuthoriation("You don't have access to Client Management")
            Exit Sub
        End If
        frmClientNew.Show()

    End Sub

    Private Sub btnPawning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPawning.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then GoTo nextlineTODO

        Select Case AccountRule.HasPrivilege("Pawning")
            Case "Full Access"
                frmPawning.AccessType = AccountRule.HasPrivilege("Pawning")
            Case "Read Only"
                frmPawning.AccessType = AccountRule.HasPrivilege("Pawning")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

nextlineTODO:
        Console.WriteLine(frmPawning.AccessType)
        frmPawning.Show()
    End Sub

    Private Sub tmrCurrent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrent.Tick
        ClosingStoreToolStripMenuItem.Enabled = dateSet
        If dateSet Then
            tsCurrentDate.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
            If Not doSegregate Then ExecuteSegregate()
            ExecuteExpiry()
            If Not doForfeitItem Then ExecuteForfeiting()
        Else
            tsCurrentDate.Text = "Date not set"
        End If
    End Sub

    Private Sub btnBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBranch.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then GoTo nextlineTODO

        Select Case AccountRule.HasPrivilege("Borrowings")
            Case "Full Access"
                frmBorrowing.AccessType = AccountRule.HasPrivilege("Borrowings")
            Case "Read Only"
                frmBorrowing.AccessType = AccountRule.HasPrivilege("Borrowings")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

nextlineTODO:
        Console.WriteLine(frmBorrowing.AccessType)
        frmBorrowing.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        If LogOutToolStripMenuItem.Text = "&Login" Then
            frmLogin1.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            POSuser = Nothing
            Dim formNames As New List(Of String)
            For Each Form In My.Application.OpenForms
                If Form.Name <> "frmMain" Or Not Form.name <> "frmLogin1" Then
                    formNames.Add(Form.Name)
                End If
            Next
            For Each currentFormName As String In formNames
                Application.OpenForms(currentFormName).Close()
            Next
            lblPasswordExpiry.Text = "Password Expiry"
            MsgBox("Thank you!", MsgBoxStyle.Information)
            NotYetLogin()
            frmLogin1.Show()
        End If
    End Sub

    Private Sub MsgBoxAuthoriation(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Critical, "Authorization Invalid")
    End Sub

    Private Sub btnInsurance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsurance.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then frmInsurance.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Insurance")
            Case "Full Access"
                frmInsurance.AccessType = AccountRule.HasPrivilege("Insurance")
            Case "Read Only"
                frmInsurance.AccessType = AccountRule.HasPrivilege("Insurance")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmInsurance.AccessType)
        frmInsurance.Show()
    End Sub

    Private Sub btnLayAway_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayAway.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub
        If UType = "Admin" Then dev_Pawning2.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Lay away")
            Case "Full Access"
            Case "Read Only"
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
         If DEV_MODE Then dev_Pawning2.Show()
    End Sub

    Private Sub btnPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOS.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If UType = "Admin" Then frmSales.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("POS")
            Case "Full Access"
                frmSales.AccessType = AccountRule.HasPrivilege("POS")
            Case "Read Only"
                frmSales.AccessType = AccountRule.HasPrivilege("POS")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmSales.AccessType)
        frmSales.Show()
    End Sub

    Private Sub CashCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashCountToolStripMenuItem.Click
        If UType = "Admin" Then frmCashCount.accessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Cash Count")
            Case "Full Access"
                frmCashCount.accessType = AccountRule.HasPrivilege("Cash Count")
            Case "Read Only"
                frmCashCount.accessType = AccountRule.HasPrivilege("Cash Count")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmCashCount.accessType)
        frmCashCount.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        If UType = "Admin" Then frmBackUpDataSettings.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Backup")
            Case "Full Access"
                frmBackUpDataSettings.AccessType = AccountRule.HasPrivilege("Backup")
            Case "Read Only"
                frmBackUpDataSettings.AccessType = AccountRule.HasPrivilege("Backup")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmBackUpDataSettings.AccessType)
        frmBackUpDataSettings.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        frmRate.Show()
    End Sub

    Private Sub ConsoleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsoleToolStripMenuItem.Click
        If UType = "Admin" Then frmAdminPanel.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Migrate")
            Case "Full Access"
                frmAdminPanel.AccessType = AccountRule.HasPrivilege("Migrate")
            Case "Read Only"
                frmAdminPanel.AccessType = AccountRule.HasPrivilege("Migrate")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmAdminPanel.AccessType)
        frmAdminPanel.Show()
    End Sub

    Private Sub ClosingStoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosingStoreToolStripMenuItem.Click
        If UType = "Admin" Then frmSettings.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Open Store")
            Case "Full Access"
                frmOpenStore.AccessType = AccountRule.HasPrivilege("Open Store")
            Case "Read Only"
                frmOpenStore.AccessType = AccountRule.HasPrivilege("Open Store")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmSettings.AccessType)
        frmCashCountV2.Show()
        frmCashCountV2.isClosing = True
    End Sub

    Private Sub frmMain_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged
        Console.WriteLine(Me.Width)
        pButton.Top = 161
        If Me.WindowState = FormWindowState.Maximized Then
            pButton.Left = 543
        End If
        If Me.Width < 1080 And Not Me.WindowState = FormWindowState.Maximized Then
            pButton.Anchor = AnchorStyles.Right
        Else
            pButton.Anchor = AnchorStyles.None
            pButton.Left = 543
        End If

    End Sub

    Private Sub RateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RateToolStripMenuItem.Click
        If UType = "Admin" Then frmRate2.AccessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Update Rates")
            Case "Full Access"
                frmRate2.accessType = AccountRule.HasPrivilege("Update Rates")
            Case "Read Only"
                frmRate2.accessType = AccountRule.HasPrivilege("Update Rates")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmRate2.AccessType)
        frmRate2.Show()
    End Sub

    Private Sub InsuranceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        qryDate.FormType = qryDate.ReportType.DailyInsurance
        qryDate.Show()
    End Sub

    Private Sub AboutUsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutUsToolStripMenuItem.Click
        'ab.Show()
        ab2.TopMost = True
        ab2.Show()
    End Sub

    Private Sub ORManagerToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ORManagerToolStripMenuItem.Click
        frmPrintManager.Show()
    End Sub

    Private Sub ItemPulloutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPulloutToolStripMenuItem.Click
        'If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        ''qryPullOut.Show()
        'If Not OTPDisable Then
        '    diagOTP.FormType = diagOTP.OTPType.Pullout
        '    If Not CheckOTP() Then Exit Sub
        'Else
        '    qryPullOut.Show()
        'End If

        'If Not (POSuser.isSuperUser Or POSuser.canPullOut) Then
        '    Dim tmpNewOtp As New OneTimePassword
        '    If Not OTPDisable Then
        '        diagOTPv2.GeneralOTP = tmpNewOtp
        '        diagOTPv2.ShowDialog()
        '        If Not diagOTPv2.isCorrect Then
        '            Exit Sub
        '        Else
        '            qryPullOut.Show()
        '        End If
        '    Else
        '        qryPullOut.Show()
        '    End If
        'Else
        '    qryPullOut.Show()
        'End If

        OTPItemPullout_Initialization()
        If Not isOTPOn("Pullout") Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.TopMost = True
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isValid Then
                Exit Sub
            Else
                qryPullOut.Show()
                Dim NewOtp As New ClassOtp("PullOut", diagGeneralOTP.txtPIN.Text)
            End If
        Else
            qryPullOut.Show()
        End If
    End Sub

    Private Sub BSPReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSPReportToolStripMenuItem.Click
        If UType = "Admin" Then frmExtractor.accessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Journal Entries")
            Case "Full Access"
                frmExtractor.accessType = AccountRule.HasPrivilege("Journal Entries")
            Case "Read Only"
                frmExtractor.accessType = AccountRule.HasPrivilege("Journal Entries")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmExtractor.accessType)
        frmExtractor.FormType = frmExtractor.ExtractType.MoneyTransferBSP
        frmExtractor.Show()
    End Sub

    Private Sub ChangelogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangelogToolStripMenuItem.Click
        Dim changeLog As String = "changelog.txt"
        System.Diagnostics.Process.Start("notepad.exe", changeLog)
    End Sub

    Private Sub ChangePasswordToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStrip.Click
        frmChangePasswordNew.Show()
    End Sub

    Private Sub AuditConsoleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditConsoleToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        AuditModule_Initialization()

        If Not isOTPOn("Audit") Then
            diagOTPv2.GeneralOTP = AuditOTP
            diagOTPv2.ShowDialog()
            If Not diagOTPv2.isCorrect Then
                Exit Sub
            Else
                frmAuditConsole.Show()
            End If
        Else
            frmAuditConsole.Show()
        End If

    End Sub

    Private Sub AccountingExtractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountingExtractToolStripMenuItem.Click
        ExtractDataFromDatabase.ShowDialog()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        frmExtractor.FormType = frmExtractor.ExtractType.PTUFile
        frmExtractor.Show()
    End Sub

    Private Sub StockInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInToolStripMenuItem.Click
        frmInventory.Show()
    End Sub

    Private Sub ItemMasterDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemMasterDataToolStripMenuItem.Click
        frmImport_IMD.Show()
    End Sub

    Private Sub ExpiryListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryListToolStripMenuItem.Click
        If UType = "Admin" Then frmSMSnotice.accessType = "Full Access" : GoTo NExtLine

        Select Case AccountRule.HasPrivilege("Expiry List")
            Case "Full Access"
                frmSMSnotice.accessType = AccountRule.HasPrivilege("Expiry List")
            Case "Read Only"
                frmSMSnotice.accessType = AccountRule.HasPrivilege("Expiry List")
            Case "No Access"
                MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        End Select

NExtLine:
        Console.WriteLine(frmSMSnotice.accessType)
        frmSMSnotice.Show()
    End Sub

    Private Delegate Sub displayStatus_callback(ByVal str As String)
    Friend Sub displayStatus(ByVal str As String)
        statusStrip.Items("tssOthers").Text = str

        'If statusStrip.InvokeRequired Then
        '    statusStrip.Invoke(New displayStatus_callback(AddressOf displayStatus), str)
        'Else
        '    statusStrip.Items("tssOthers").Text = str
        'End If
    End Sub


    'Montly Report
    Private Sub ReportsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportsToolStripMenuItem1.Click
        qryDate.Show()
    End Sub

    Private Sub SequenceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SequenceToolStripMenuItem1.Click
        qrySequence.Show()
    End Sub

    Private Sub CashInOutSummaryToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashInOutSummaryToolStripMenuItem1.Click
        qryCashInOut.FormType = qryCashInOut.FormTrans.Monthly
        qryCashInOut.Show()
    End Sub

    Private Sub AuctionMonthlyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuctionMonthlyToolStripMenuItem.Click
        qryAuction.Show()
    End Sub

    Private Sub MonthlySegrregatedListToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlySegrregatedListToolStripMenuItem1.Click
        frmSegreList.FormType = frmSegreList.SegreReport.Monthly
        frmSegreList.Show()
    End Sub

    Private Sub MonthlyInventoryReportsToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyInventoryReportsToolStripMenuItem1.Click
        frmSalesReport.Show()
    End Sub


    'Daily Report
    Private Sub OutstandingToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingToolStripMenuItem1.Click
        qryPullOut_List.FormType = qryPullOut_List.DailyReport.Outstanding
        qryPullOut_List.Show()
    End Sub

    Private Sub AuditReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditReportToolStripMenuItem1.Click
        qryPullOut_List.FormType = qryPullOut_List.DailyReport.AuditReport
        qryPullOut_List.Show()
    End Sub

    Private Sub LoanRegisterToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoanRegisterToolStripMenuItem1.Click
        qryLoan.Show()
    End Sub

    Private Sub MoneyTransferToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoneyTransferToolStripMenuItem1.Click
        qryMoneyTransfer.Show()
    End Sub

    Private Sub InsuranceToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsuranceToolStripMenuItem1.Click
        qryDate.FormType = qryDate.ReportType.DailyInsurance
        qryDate.Show()
    End Sub

    Private Sub DollarReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DollarReportToolStripMenuItem1.Click
        qryDate.FormType = qryDate.ReportType.DollarDaily
        qryDate.Show()
    End Sub

    Private Sub CashInOutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashInOutToolStripMenuItem1.Click
        qryCashInOut.FormType = qryCashInOut.FormTrans.Daily
        qryCashInOut.Show()
    End Sub

    Private Sub SegregatedListToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SegregatedListToolStripMenuItem1.Click
        frmSegreList.FormType = frmSegreList.SegreReport.Daily
        frmSegreList.Show()
    End Sub

    Private Sub ItemPulloutToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPulloutToolStripMenuItem2.Click
        qryPullOut_List.FormType = qryPullOut_List.DailyReport.Pullout
        qryPullOut_List.Show()
    End Sub

    Private Sub VoidReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoidReportToolStripMenuItem1.Click
        qryDate.FormType = qryDate.ReportType.VoidReportDaily
        qryDate.Show()
    End Sub

    Private Sub SalesReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem1.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.Sale
        frmSalesReport.Show()
    End Sub

    Private Sub InventoryReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryReportToolStripMenuItem1.Click
        'If Not OTPDisable Then
        '    diagOTP.FormType = diagOTP.OTPType.Inventory
        '    If Not CheckOTP() Then Exit Sub
        'Else
        '    frmSalesReport.FormType = frmSalesReport.SaleReport.Inventory
        '    frmSalesReport.Show()
        'End If

        OTPInventory_Initialization()

        If Not isOTPOn("Inventory") Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.TopMost = True
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isValid Then
                Exit Sub
            Else
                frmSalesReport.FormType = frmSalesReport.SaleReport.Inventory
                frmSalesReport.Show()
                Dim NewOtp As New ClassOtp("Inventory Report", diagGeneralOTP.txtPIN.Text)
            End If
        Else
            frmSalesReport.FormType = frmSalesReport.SaleReport.Inventory
            frmSalesReport.Show()
        End If
    End Sub

    Private Sub StockoutReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockoutReportToolStripMenuItem1.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.StockOut
        frmSalesReport.Show()
    End Sub

    Private Sub StockInReportToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInReportToolStripMenuItem1.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.StockIn
        frmSalesReport.Show()
    End Sub

    Private Sub LayawayPaymentToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayawayPaymentToolStripMenuItem.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.LayAway
        frmSalesReport.Show()
    End Sub

    Private Sub LayawayListToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LayawayListToolStripMenuItem1.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.LayawayList
        frmSalesReport.Show()
    End Sub

    Private Sub ForfeitedLayawayToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ForfeitedLayawayToolStripMenuItem.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.Forfeit
        frmSalesReport.Show()
    End Sub

    'Hourly Report
    Private Sub HourlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourlyReportToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.Hourly
        qryDate.Show()
    End Sub

    Private Sub HourlySummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourlySummaryToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.HourlySummary
        qryDate.Show()
    End Sub

    Private Sub DailyCashCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyCashCountToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.DailyCashCount
        qryDate.Show()
    End Sub

    Private Sub MonthlyExpiryListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyExpiryListToolStripMenuItem.Click
        frmSMSList.FormType = frmSMSList.ReportType.MonthlyExpiry
        frmSMSList.Show()
    End Sub

    Private Sub ExpiryListToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryListToolStripMenuItem2.Click
        frmSMSList.FormType = frmSMSList.ReportType.DailyExpiry
        frmSMSList.Show()
    End Sub

    Private Sub SMSNoticeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SMSNoticeToolStripMenuItem1.Click
        frmSMSInfo.Show()
    End Sub

    Private Sub bgwForPasswordExpiry_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwForPasswordExpiry.DoWork
        If UType = "Admin" Then Exit Sub
        tmrForPasswordExpiry.Stop()
        Dim ms As String

        If Not ifTblExist("TBL_USER_DEFAULT") Then
            Exit Sub
        End If

        If s_USER.Get_rem_PassExp = 1 Then
            ms = s_USER.Get_rem_PassExp & " Day Remaining"
        ElseIf s_USER.Get_rem_PassExp <= 0 Then
            ms = " Password Has Been Expired"
        Else
            ms = s_USER.Get_rem_PassExp & " Days Remaining"
        End If
        lblPasswordExpiry.Text = "Password Expiry: " & ms
    End Sub

    Private Sub tmrForPasswordExpiry_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrForPasswordExpiry.Tick
        tmrForPasswordExpiry.Stop()
        bgwForPasswordExpiry.RunWorkerAsync()
    End Sub

End Class