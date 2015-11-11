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

    Friend Sub LoadChild(ByVal frm As Form)
        frm.MdiParent = Me
        frm.TopMost = True
        frm.BringToFront()
        frm.Show()
    End Sub

    Friend Sub Alert()
        MsgBox("Alert", MsgBoxStyle.Critical)
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        End
    End Sub

    Private Sub SettingsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SettingsToolStripMenuItem.Click
        frmSettings.Show()
    End Sub

    Private Sub UserManagementToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UserManagementToolStripMenuItem.Click
        frmUserManagement.Show()
    End Sub

    Private Sub ExpiryGeneratorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExpiryGeneratorToolStripMenuItem.Click
        frmExtractor.FormType = frmExtractor.ExtractType.Expiry
        frmExtractor.Show()
    End Sub

    Private Sub JournalEntriesToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles JournalEntriesToolStripMenuItem.Click
        frmExtractor.FormType = frmExtractor.ExtractType.JournalEntry
        frmExtractor.Show()
    End Sub

    Private Sub btnMoneyTransfer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMoneyTransfer.Click
        frmMTlist.Show()
    End Sub

    Private Sub btnDollarBuying_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDollarBuying.Click
        frmDollar.Show()
    End Sub

    Private Sub btnCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCash.Click
        frmCashInOut.Show()
    End Sub

    Private Sub CloseOpenStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseOpenStore.Click
        frmOpenStore.Show()
    End Sub

    Private Sub btnClient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClient.Click
        frmClient.Show()
    End Sub

    Private Sub pbLogo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbLogo.Click

    End Sub

    Private Sub pbLogo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles pbLogo.DoubleClick
        devClient.Show()
    End Sub

    Private Sub btnPawning_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPawning.Click
        frmPawning.Show()
    End Sub

    Private Sub tmrCurrent_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrCurrent.Tick
        If dateSet Then tsCurrentDate.Text = CurrentDate.ToLongDateString & " " & Now.ToString("T")
    End Sub

    Private Sub btnBranch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBranch.Click
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
End Class
