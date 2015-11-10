Public Class frmUserManagement

    Private Sub frmUserManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive()
    End Sub

    Private Sub LoadActive(Optional ByVal mySql As String = "SELECT * FROM tbl_gamit ORDER BY Username ASC")
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvUsers.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim posUser As New ComputerUser
            posUser.LoadUserByRow(dr)
            AddItem(posUser)
        Next
    End Sub

    Private Sub AddItem(ByVal usr As ComputerUser)
        Dim lv As ListViewItem = lvUsers.Items.Add(usr.UserName)
        lv.SubItems.Add(usr.FullName)
        lv.SubItems.Add(usr.Level)
        lv.Tag = usr.UserID
    End Sub

    Private Sub ClearFields()
        txtUser.Text = ""
        txtFullname.Text = ""
        txtPass1.Text = ""
        txtPass2.Text = ""
    End Sub

    Private Function Privileger() As String
        Dim priv As String = ""
        'Encoder
        priv &= IIf(chkPawn.Checked, 1, 0)
        priv &= IIf(chkCM.Checked, 1, 0)
        priv &= IIf(chkMT.Checked, 1, 0)
        priv &= IIf(chkIns.Checked, 1, 0)
        priv &= IIf(chkLay.Checked, 1, 0)
        priv &= IIf(chkDB.Checked, 1, 0)
        priv &= IIf(chkPOS.Checked, 1, 0)
        priv &= IIf(chkCIO.Checked, 1, 0)
        priv &= "|"

        'Supervisor
        Dim listChk() As CheckBox = {chkEL, chkJE, chkCC, chkBU, chkR1, chkR2, chkR3, chkR4, chkVUM, chkVR, chkOS}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)
        Next
        priv &= "|"

        'Manager
        listChk = {chkUM, chkUR, chkUS, chkBorrowings}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)
        Next
        priv &= "|"

        'Special
        listChk = {chkCashInBank, chkCashOutBank, chkVoid}
        For Each e In listChk
            priv &= IIf(e.Checked, 1, 0)
        Next

        Return priv
    End Function

#Region "SelectAll"

    Private Sub SelectAll(ByVal tab As TabPage)
        Dim tabStat As Boolean

        Console.WriteLine("Tab Selected: " & tab.Text)
        Select Case tab.Text
            Case "Encoder"
                tabStat = chkEnAll.Checked
                chkPawn.Checked = tabStat
                chkCM.Checked = tabStat
                chkMT.Checked = tabStat
                chkIns.Checked = tabStat
                chkLay.Checked = tabStat
                chkDB.Checked = tabStat
                chkPOS.Checked = tabStat
                chkCIO.Checked = tabStat
            Case "Supervisor"
                tabStat = chkSuAll.Checked
                chkEL.Checked = tabStat
                chkJE.Checked = tabStat
                chkCC.Checked = tabStat
                chkBU.Checked = tabStat
                chkVUM.Checked = tabStat
                chkVR.Checked = tabStat
                chkOS.Checked = tabStat
                chkR1.Checked = tabStat
                chkR2.Checked = tabStat
                chkR3.Checked = tabStat
                chkR4.Checked = tabStat
            Case "Manager"
                tabStat = chkMaAll.Checked
                chkUM.Checked = tabStat
                chkUR.Checked = tabStat
                chkUS.Checked = tabStat
                chkBorrowings.Checked = tabStat
            Case "Special"
                tabStat = chkSpAll.Checked
                chkCashInBank.Checked = tabStat
                chkCashOutBank.Checked = tabStat
                chkVoid.Checked = tabStat
        End Select
    End Sub

    Private Sub chkEnAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkEnAll.CheckedChanged
        SelectAll(tbEncoder)
    End Sub

    Private Sub chkSuAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSuAll.CheckedChanged
        SelectAll(tbSupervisor)
    End Sub

    Private Sub chkMaAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMaAll.CheckedChanged
        SelectAll(tbManager)
    End Sub

    Private Sub chkSpAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSpAll.CheckedChanged
        SelectAll(tbSpecial)
    End Sub
#End Region

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Console.WriteLine("Priv is " & Privileger())
        Dim tmpUser As New ComputerUser
        tmpUser.Privilege = Privileger()
        tmpUser.UpdatePrivilege()
    End Sub
End Class