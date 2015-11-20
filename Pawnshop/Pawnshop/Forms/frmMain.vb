Public Class frmMain

    'NOTE
    ' NotYetLogin sub don't have REPORTS DISABLE YET
    ' Please add reports and add it also at NotYetLogin
    ' sub.

    Friend dateSet As Boolean = False

    Friend Sub NotYetLogin(Optional ByVal st As Boolean = True)
        pButton.Enabled = Not st

        'File
        CloseOpenStore.Enabled = Not st
        UserManagementToolStripMenuItem.Enabled = Not st
        UpdateToolStripMenuItem.Enabled = Not st
        SettingsToolStripMenuItem.Enabled = Not st
        If Not st Then
            LogOutToolStripMenuItem.Text = "&Log Out"
        Else
            LogOutToolStripMenuItem.Text = "&Login"
        End If

        'Tools
        ExpiryGeneratorToolStripMenuItem.Enabled = Not st
        JournalEntriesToolStripMenuItem.Enabled = Not st
        CashCountToolStripMenuItem.Enabled = Not st
        BackupToolStripMenuItem.Enabled = Not st

        If st Then
            tsUser.Text = "No User yet"
        Else
            tsUser.Text = "Greetings " & POSuser.FullName
        End If

        'Reports

    End Sub

    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
    End Sub

    Friend Sub CheckStoreStatus()
        mod_system.LoadCurrentDate()
        CloseOpenStore.Enabled = Not dateSet
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
        frmMIS.Show()
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        frmUserManagement.Show()
    End Sub

    Private Sub ExpiryGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryGeneratorToolStripMenuItem.Click
        If Not POSuser.canExpiryListGenerate Then
            MsgBoxAuthoriation("You don't have access to Expiry Generator")
            Exit Sub
        End If
        frmExtractor.FormType = frmExtractor.ExtractType.Expiry
        frmExtractor.Show()
    End Sub

    Private Sub JournalEntriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntriesToolStripMenuItem.Click
        If Not POSuser.canJournalEntryGenerate Then
            MsgBoxAuthoriation("You don't have access to Journal Entry Generator")
            Exit Sub
        End If
        frmExtractor.FormType = frmExtractor.ExtractType.JournalEntry
        frmExtractor.Show()
    End Sub

    Private Sub btnMoneyTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneyTransfer.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canMoneyTransfer Then
            MsgBoxAuthoriation("You don't have access to Money Transfer")
            Exit Sub
        End If
        frmMTlist.Show()
    End Sub

    Private Sub btnDollarBuying_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDollarBuying.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canDollarBuying Then
            MsgBoxAuthoriation("You don't have access to Dollar Buying")
            Exit Sub
        End If
        frmDollar.Show()
    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canCashInOut Then
            MsgBoxAuthoriation("You don't have access to Cash In/Out")
            Exit Sub
        End If
        frmCashInOut.Show()
    End Sub

    Private Sub CloseOpenStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseOpenStore.Click
        If Not POSuser.canOpenStore Then
            MsgBoxAuthoriation("You cannot Open a Store.")
            Exit Sub
        End If
        frmOpenStore.Show()
    End Sub

    Private Sub btnClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClient.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canClientManage Then
            MsgBoxAuthoriation("You don't have access to Client Management")
            Exit Sub
        End If
        frmClient.Show()
    End Sub

    Private Sub pbLogo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbLogo.DoubleClick
        devClient.Show()
    End Sub

    Private Sub btnPawning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPawning.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canPawn Then
            MsgBoxAuthoriation("You don't have access to pawning")
            Exit Sub
        End If
        frmPawning.Show()
    End Sub

    Private Sub tmrCurrent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrent.Tick
        If dateSet Then tsCurrentDate.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
    End Sub

    Private Sub btnBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBranch.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canBorrow Then
            MsgBoxAuthoriation("You don't have access to Borrowings")
            Exit Sub
        End If

        frmBorrowing.Show()
    End Sub

    Private Sub LogOutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogOutToolStripMenuItem.Click
        If LogOutToolStripMenuItem.Text = "&Login" Then
            frmLogin.Show()
        Else
            POSuser = Nothing
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

        If Not POSuser.canInsurance Then
            MsgBoxAuthoriation("You don't have access to insurance.")
            Exit Sub
        End If
        'Insurance show form
        frmInsurance.Show()
    End Sub

    Private Sub btnLayAway_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLayAway.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canLayAway Then
            MsgBoxAuthoriation("You don't have access to Lay away.")
            Exit Sub
        End If
    End Sub

    Private Sub btnPOS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPOS.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canPOS Then
            MsgBoxAuthoriation("You don't have access to POS")
            Exit Sub
        End If
    End Sub

    Private Sub CashCountToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CashCountToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub

        If Not POSuser.canCashCount Then
            MsgBoxAuthoriation("You don't have access to Cash Count")
            Exit Sub
        End If
    End Sub

    Private Sub BackupToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupToolStripMenuItem.Click
        If Not POSuser.canBackup Then
            MsgBoxAuthoriation("You don't have access to Backup")
            Exit Sub
        End If

        frmBackup.Show()
    End Sub

    Private Sub UpdateToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UpdateToolStripMenuItem.Click
        If Not dateSet Then MsgBox("Please Open the Store" & vbCrLf & "File > Open Store", MsgBoxStyle.Critical, "Store Closed") : Exit Sub
    End Sub
End Class
