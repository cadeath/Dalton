Public Class frmMainnEW
    Dim s_USER As New Sys_user


    Friend dateSet As Boolean = False
    Friend doSegregate As Boolean = False


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
        ToolStripMenuItem2.Enabled = Not st 'Monthly Report
        SequenceToolStripMenuItem.Enabled = Not st 'Sequence Report
        CashInOutSummaryToolStripMenuItem.Enabled = Not st 'Cash InOut Summary
        AuctionMonthlyJewelryReportToolStripMenuItem.Enabled = Not st 'Auction MOnthly
        MonthlyInventoryReportsToolStripMenuItem.Enabled = Not st
        MonthlySegrregatedListToolStripMenuItem.Enabled = Not st
        '-------------------------------------------------
        OutstandingToolStripMenuItem.Enabled = Not st
        AuditReportToolStripMenuItem.Enabled = Not st
        LoanRegisterToolStripMenuItem.Enabled = Not st
        MoneyTransferToolStripMenuItem.Enabled = Not st
        InsuranceToolStripMenuItem.Enabled = Not st
        DollarReportToolStripMenuItem.Enabled = Not st
        CashInOutToolStripMenuItem.Enabled = Not st
        SegregatedListToolStripMenuItem.Enabled = Not st
        ItemPulloutToolStripMenuItem1.Enabled = Not st
        VoidReportToolStripMenuItem.Enabled = Not st
        SalesReportToolStripMenuItem.Enabled = Not st
        InventoryReportToolStripMenuItem.Enabled = Not st
        StockoutReportToolStripMenuItem.Enabled = Not st
        StockInReportToolStripMenuItem.Enabled = Not st
        '-------------------------------------------------
        HourlyReportToolStripMenuItem.Enabled = Not st
        HourlySummaryToolStripMenuItem.Enabled = Not st
        DailyCashCountToolStripMenuItem.Enabled = Not st
    End Sub

    Private Sub ExecuteSegregate()
        doSegregate = AutoSegregate()
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

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        End
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not AccountRule.HasPrivilege("Usermanagment") Then
            MsgBoxAuthoriation("You Don't have access to User Management.")
            Exit Sub
        End If

        'frmUserManagement1.Show()
    End Sub

    Private Sub btnMoneyTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneyTransfer.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Money Transfer") Then
            MsgBoxAuthoriation("You Don't have access to Money Transfer.")
            Exit Sub
        End If
        frmMoneyTransfer.Show()
    End Sub

    Private Sub btnDollarBuying_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDollarBuying.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Dollar Buying") Then
            MsgBoxAuthoriation("You Don't have access to Dollar Buying.")
            Exit Sub
        End If
        frmmoneyexchange.Show()
    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Cash In/Out") Then
            MsgBoxAuthoriation("You Don't have access to Cash In/Out.")
            Exit Sub
        End If
        frmCashInOut2.Show()
    End Sub

    Private Sub CloseOpenStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseOpenStore.Click

        If Not AccountRule.HasPrivilege("Close Store") Then
            MsgBoxAuthoriation("You Don't have access to Close Store.")
            Exit Sub
        End If
        frmOpenStore.Show()
    End Sub

    Private Sub btnClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClient.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Client Management") Then
            MsgBoxAuthoriation("You Don't have access to Client Management.")
            Exit Sub
        End If
        frmClient.Show()
    End Sub

    Private Sub btnPawning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPawning.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Pawning") Then
            MsgBoxAuthoriation("You Don't have access to Pawning.")
            Exit Sub
        End If
        frmPawning.Show()
    End Sub

    Private Sub tmrCurrent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrent.Tick

    End Sub

    Private Sub btnBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBranch.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Borrowings") Then
            MsgBoxAuthoriation("You Don't have access to Borrowings.")
            Exit Sub
        End If
        frmBorrowing.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        If LogOutToolStripMenuItem.Text = "&Login" Then
            frmLogin.Show()
        Else
            Dim ans As DialogResult = MsgBox("Do you want to LOGOUT?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Logout")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            POSuser = Nothing
            Dim formNames As New List(Of String)
            For Each Form In My.Application.OpenForms
                If Form.Name <> "frmMainnEW" Or Not Form.name <> "frmLogin" Then
                    formNames.Add(Form.Name)
                End If
            Next
            For Each currentFormName As String In formNames
                Application.OpenForms(currentFormName).Close()
            Next
            MsgBox("Thank you!", MsgBoxStyle.Information)
            NotYetLogin()
            frmLogin.Show()
        End If
    End Sub

    Private Sub MsgBoxAuthoriation(ByVal msg As String)
        MsgBox(msg, MsgBoxStyle.Critical, "Authorization Invalid")
    End Sub

    Private Sub btnInsurance_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInsurance.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Insurance") Then
            MsgBoxAuthoriation("You Don't have access to Insurance.")
            Exit Sub
        End If
        'Insurance show form
        frmInsurance.Show()
    End Sub

    Private Sub btnLayAway_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayAway.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If DEV_MODE Then dev_Pawning2.Show()

        If Not AccountRule.HasPrivilege("Lay away") Then
            MsgBoxAuthoriation("You Don't have access to Lay away.")
            Exit Sub
        End If

    End Sub

    Private Sub btnPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOS.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("POS") Then
            MsgBoxAuthoriation("You Don't have access to POS.")
            Exit Sub
        End If
        frmSales.Show()
    End Sub

    Private Sub CashCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashCountToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not AccountRule.HasPrivilege("Cash Count") Then
            MsgBoxAuthoriation("You Don't have access to Cash Count.")
            Exit Sub
        End If
        frmCashCount.Show()
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Backup") Then
            MsgBoxAuthoriation("You Don't have access to Backup.")
            Exit Sub
        End If

        'frmBackup.Show()
        frmBackUpDataSettings.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        frmRate.Show()
    End Sub

    Private Sub ConsoleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConsoleToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Console") Then
            MsgBoxAuthoriation("You Don't have access to Console.")
            Exit Sub
        End If
        'frmMIS.Show()
        frmAdminPanel.Show()
    End Sub

    Private Sub ClosingStoreToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClosingStoreToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Close Store") Then
            MsgBoxAuthoriation("You Don't have access to Close Store.")
            Exit Sub
        End If

        frmCashCountV2.Show()
        frmCashCountV2.isClosing = True
    End Sub

    Private Sub LoanRegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoanRegisterToolStripMenuItem.Click
        qryLoan.Show()
    End Sub

    Private Sub DailyCashCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DailyCashCountToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.DailyCashCount
        qryDate.Show()
    End Sub

    Private Sub SequenceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SequenceToolStripMenuItem.Click
        qrySequence.Show()
    End Sub

    Private Sub SegregatedListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SegregatedListToolStripMenuItem.Click
        frmSegreList.FormType = frmSegreList.SegreReport.Daily
        frmSegreList.Show()
    End Sub

    Private Sub CashInOutSummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashInOutSummaryToolStripMenuItem.Click
        qryCashInOut.FormType = qryCashInOut.FormTrans.Monthly
        qryCashInOut.Show()
    End Sub

    Private Sub MoneyTransferToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MoneyTransferToolStripMenuItem.Click
        qryMoneyTransfer.Show()
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

    Private Sub OutstandingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OutstandingToolStripMenuItem.Click
        qryPullOut_List.FormType = qryPullOut_List.DailyReport.Outstanding
        qryPullOut_List.Show()
    End Sub

    Private Sub RateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RateToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Update Rate") Then
            MsgBoxAuthoriation("You Don't have access to Update Rates.")
            Exit Sub
        End If

        frmRate2.Show()
    End Sub

    Private Sub InsuranceToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InsuranceToolStripMenuItem.Click
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

        'qryPullOut.Show()
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.Pullout
            If Not CheckOTP() Then Exit Sub
        Else
            qryPullOut.Show()
        End If
    End Sub

    Private Sub ItemPulloutToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemPulloutToolStripMenuItem1.Click
        qryPullOut_List.FormType = qryPullOut_List.DailyReport.Pullout
        qryPullOut_List.Show()
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click
        qryDate.Show()
    End Sub

    Private Sub CashInOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashInOutToolStripMenuItem.Click
        qryCashInOut.FormType = qryCashInOut.FormTrans.Daily
        qryCashInOut.Show()
    End Sub

    Private Sub HourlySummaryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourlySummaryToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.HourlySummary
        qryDate.Show()
    End Sub

    Private Sub HourlyReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HourlyReportToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.Hourly
        qryDate.Show()
    End Sub

    Private Sub BSPReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BSPReportToolStripMenuItem.Click
        If Not POSuser.canJournalEntryGenerate Then
            MsgBoxAuthoriation("You don't have access to Journal Entry Generator")
            Exit Sub
        End If

        frmExtractor.FormType = frmExtractor.ExtractType.MoneyTransferBSP
        frmExtractor.Show()
    End Sub

    Private Sub DollarReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DollarReportToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.DollarDaily
        qryDate.Show()
    End Sub

    Private Sub ChangelogToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangelogToolStripMenuItem.Click
        Dim changeLog As String = "changelog.txt"
        System.Diagnostics.Process.Start("notepad.exe", changeLog)
    End Sub

    Private Sub AuctionMonthlyJewelryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuctionMonthlyJewelryReportToolStripMenuItem.Click
        qryAuction.Show()
    End Sub

    Private Sub AuditReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditReportToolStripMenuItem.Click
        qryPullOut_List.FormType = qryPullOut_List.DailyReport.AuditReport
        qryPullOut_List.Show()
    End Sub

    Private Sub ChangePasswordToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChangePasswordToolStrip.Click
        frmChangePassword.Show()
    End Sub

    Private Sub VoidReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VoidReportToolStripMenuItem.Click
        qryDate.FormType = qryDate.ReportType.VoidReportDaily
        qryDate.Show()

    End Sub
    Private Sub AuditConsoleToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AuditConsoleToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        AuditModule_Initialization()

        If Not OTPDisable Then
            diagOTPv2.GeneralOTP = AuditOTP
            diagOTPv2.ShowDialog()
            If Not diagOTPv2.isCorrect Then
                Exit Sub
            Else
                frmAuditConsole.Show()
            End If

        End If

    End Sub

    Private Sub AccountingExtractToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AccountingExtractToolStripMenuItem.Click
        ExtractDataFromDatabase.ShowDialog()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem.Click
        frmExtractor.FormType = frmExtractor.ExtractType.PTUFile
        frmExtractor.Show()
    End Sub

    Private Sub SalesReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesReportToolStripMenuItem.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.Sale
        frmSalesReport.Show()
    End Sub

    Private Sub InventoryReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles InventoryReportToolStripMenuItem.Click
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.Inventory
            If Not CheckOTP() Then Exit Sub
        Else
            frmSalesReport.FormType = frmSalesReport.SaleReport.Inventory
            frmSalesReport.Show()
        End If
    End Sub

    Private Sub StockInToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInToolStripMenuItem.Click
        frmInventory.Show()
    End Sub

    Private Sub ItemMasterDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemMasterDataToolStripMenuItem.Click
        frmImport_IMD.Show()
    End Sub

    Private Sub StockoutReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockoutReportToolStripMenuItem.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.StockOut
        frmSalesReport.Show()
    End Sub

    Private Sub StockInReportToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles StockInReportToolStripMenuItem.Click
        frmSalesReport.FormType = frmSalesReport.SaleReport.StockIn
        frmSalesReport.Show()
    End Sub

    Private Sub MonthlyInventoryReportsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlyInventoryReportsToolStripMenuItem.Click
        frmSalesReport.Show()
    End Sub

    Private Sub MonthlySegrregatedListToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MonthlySegrregatedListToolStripMenuItem.Click
        frmSegreList.FormType = frmSegreList.SegreReport.Monthly
        frmSegreList.Show()
    End Sub

    Private Sub frmMainnEW_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        pButton.Location = New Point(450, 160) : tmrForPasswordExpiry.Start()
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

    Private Sub UserManagementToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        'If UType = "Admin" Then GoTo NExtLine

        'If Not AccountRule.HasPrivilege("Usermanagment") Then
        '    MsgBoxAuthoriation("You Don't have access in this module.") : Exit Sub
        'End If
NExtLine:
        frmUserManagementNew.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub bgwForPasswordExpiry_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgwForPasswordExpiry.RunWorkerCompleted
        Console.WriteLine("Generating successful.") : tmrForPasswordExpiry.Start()
    End Sub

    Private Sub bgwForPasswordExpiry_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgwForPasswordExpiry.DoWork
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

    Private Sub SettingsToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Settings") Then
            MsgBoxAuthoriation("You Don't have access to Settings.")
            Exit Sub
        End If

        If CheckFormActive() Then Exit Sub

        frmSettings.Show()
    End Sub

    Private Sub ExpiryGeneratorToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryGeneratorToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Expiry Generator") Then
            MsgBoxAuthoriation("You Don't have access to Expiry Generator.")
            Exit Sub
        End If

        frmExtractor.FormType = frmExtractor.ExtractType.Expiry
        frmExtractor.Show()
    End Sub

    Private Sub JournalEntriesToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntriesToolStripMenuItem.Click
        If Not AccountRule.HasPrivilege("Journal Entry Generator") Then
            MsgBoxAuthoriation("You Don't have access to Journal Entry Generator.")
            Exit Sub
        End If

        frmExtractor.FormType = frmExtractor.ExtractType.JournalEntry
        frmExtractor.Show()
    End Sub
End Class