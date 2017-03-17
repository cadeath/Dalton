Public Class qryPullOut

    Private fillData As String = "OPT"
    Private mySql As String = ""

    Private Sub frmPullOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadSegregated()

        'Current Date
        lblCurrentDate.Text = "Today is " & CurrentDate.ToLongDateString
    End Sub

    Private Sub ClearFields()
        lvPullOut.Items.Clear()
        lvSeg.Items.Clear()
        txtSearch.Text = ""
    End Sub

    Private Sub LoadSegregated()
        mySql = "SELECT * FROM " & fillData
        mySql &= " WHERE STATUS = 'S' ORDER BY PawnID DESC"

        Dim ds As New DataSet
        ds = LoadSQL(mySql, fillData)

        lvSeg.Items.Clear()
        For Each dr As DataRow In ds.Tables(fillData).Rows
            Dim tmpPawnItem As New PawnTicket2
            tmpPawnItem.Load_PT_row(dr)
            AddItemSeg(tmpPawnItem)
        Next
    End Sub

    Private Sub AddItemSeg(ByVal pt As PawnTicket2)
        Dim lv As ListViewItem = lvSeg.Items.Add(pt.PawnTicket)
        lv.SubItems.Add(String.Format("{0} {1}{2}", pt.Pawner.FirstName, pt.Pawner.LastName, IIf(pt.Pawner.Suffix <> "", "," & pt.Pawner.Suffix, "")))
        lv.SubItems.Add(pt.PawnItem.ItemClass.Category)
        lv.SubItems.Add(pt.LoanDate)
        lv.SubItems.Add(pt.AuctionDate)

        If pt.Status <> "S" Then lv.BackColor = Color.OrangeRed
        lv.Tag = pt.PawnID
    End Sub

    Private Sub AddItemPull(ByVal pt As PawnTicket2)
        Dim lv As ListViewItem = lvPullOut.Items.Add(pt.PawnTicket)
        lv.SubItems.Add(String.Format("{0} {1}{2}", pt.Pawner.FirstName, pt.Pawner.LastName, IIf(pt.Pawner.Suffix <> "", "," & pt.Pawner.Suffix, "")))
        lv.SubItems.Add(pt.PawnItem.ItemClass.Category)
        lv.SubItems.Add(pt.LoanDate)
        lv.SubItems.Add(pt.AuctionDate)

        lv.Tag = pt.PawnID
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub
        If Not IsNumeric(txtSearch.Text) Then Exit Sub


        SelectPT(txtSearch.Text)

        'mySql = "SELECT * FROM " & fillData
        'mySql &= " WHERE PawnTicket LIKE '%" & txtSearch.Text & "%' AND STATUS = 'S'"
        'Dim ds As DataSet = LoadSQL(mySql)

        'lvSeg.Items.Clear()
        'For Each dr As DataRow In ds.Tables(0).Rows
        '    Dim tmpDr As New PawnTicket2
        '    tmpDr.Load_PT_row(dr)
        '    AddItemSeg(tmpDr)
        'Next
    End Sub

    Private Sub SelectPT(ByVal pt As String)

        For Each itm As ListViewItem In lvSeg.Items
            If itm.Text.Contains(pt) Then
                itm.Selected = True
                Exit For
            End If
        Next
        lvSeg.Select()
        lvSeg.SelectedItems.Item(0).EnsureVisible()
    End Sub

    Private Sub btnOnePull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnePull.Click
        If lvSeg.SelectedItems.Count <= 0 Then Exit Sub

        Dim idx As Integer = lvSeg.FocusedItem.Tag
        Dim pullPT As New PawnTicket2
        pullPT.Load_PTid(idx)
        AddItemPull(pullPT)
        lvSeg.Items.RemoveAt(lvSeg.FocusedItem.Index)
    End Sub

    Private Sub btnGetPull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetPull.Click
        If lvPullOut.items.Count <= 0 Then Exit Sub

        Dim idx As Integer = lvPullOut.FocusedItem.Tag
        Dim segPT As New PawnTicket2
        segPT.Load_PTid(idx)
        AddItemSeg(segPT)
        lvPullOut.Items.RemoveAt(lvPullOut.FocusedItem.Index)
    End Sub

    Private Sub btnAllPull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllPull.Click
        If lvSeg.Items.Count <= 0 Then Exit Sub

        For Each itm As ListViewItem In lvSeg.Items
            Dim tmp As New PawnTicket2
            tmp.Load_PTid(itm.Tag)
            AddItemPull(tmp)
        Next
        lvSeg.Items.Clear()
    End Sub

    Private Sub btnGetAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGetAll.Click
        If lvPullOut.SelectedItems.Count <= 0 Then Exit Sub

        For Each itm As ListViewItem In lvPullOut.Items
            Dim tmp As New PawnTicket2
            tmp.Load_PTid(itm.Tag)
            AddItemSeg(tmp)
        Next
        lvPullOut.Items.Clear()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If lvPullOut.Items.Count <= 0 Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to post this transactions?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        mySql = "Select * From PulloutDoc"
        fillData = "PulloutDoc"
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("DocDate") = CurrentDate
            .Item("ControlNum") = GetOption("PulloutNum")
            .Item("Pulloutby") = UserID
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds, True)

        mySql = "Select * From PulloutDoc Order By DocID ASC"
        ds = LoadSQL(mySql, fillData)
        Dim LastID As Integer = ds.Tables(0).Rows(0).Item("DocID")

        For Each itm As ListViewItem In lvPullOut.Items
            Dim pt As New PawnTicket2
            pt.Load_PTid(itm.Tag)
            pt.PullOut(CurrentDate)

            mySql = "Select * From PulloutLines"
            fillData = "PulloutLines"
            ds = LoadSQL(mySql, fillData)
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("DocID") = LastID
                .Item("Pawnticket") = pt.PawnTicket
                .Item("loandate") = pt.LoanDate
                .Item("ExpiryDate") = pt.ExpiryDate
                .Item("Description") = pt.Description
                .Item("Principal") = pt.Principal
                .Item("PawnerName") = String.Format("{0} {1}" & IIf(pt.Pawner.Suffix <> "", "," & pt.Pawner.Suffix, ""), pt.Pawner.FirstName, pt.Pawner.LastName)
                .Item("Appraiser") = GetAppraiserName(pt.AppraiserID)
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            database.SaveEntry(ds, True)
        Next

        MsgBox("Items has been pull out", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub lvSeg_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvSeg.DoubleClick
        Dim idx As Integer = lvSeg.FocusedItem.Tag
        Dim pt As New PawnTicket
        pt.LoadTicket(idx)
        ViewPT(pt)
    End Sub

    Private Sub lvPullOut_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPullOut.DoubleClick
        Dim idx As Integer = lvPullOut.FocusedItem.Tag
        Dim pt As New PawnTicket
        pt.LoadTicket(idx)
        ViewPT(pt)
    End Sub

    Private Sub ViewPT(ByVal pt As PawnTicket)
        frmPawnItem.Show()
        frmPawnItem.LoadPawnTicket(pt, pt.Status)
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Function GetAppraiserName(ByVal ID As Integer) As String
        mySql = "Select * From tbl_gamit Where UserID = " & ID
        fillData = "tbl_gamit"
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Return ds.Tables(0).Rows(0).Item("FullName")
    End Function
End Class