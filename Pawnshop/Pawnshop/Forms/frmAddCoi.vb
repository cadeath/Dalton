Public Class frmAddCoi
    Private Ins As Insurance
    Friend Ticket As String
    Friend Client As String
    Private CollectCoi As New Hashtable
    Private Sub frmAddCoi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvCoi.Items.Clear()
        CollectCoi.Clear()
    End Sub

    Friend Sub LoadCoi(ByVal Coi As Insurance)
        If Coi.TicketNum <> Ticket Then
            If Coi.TicketNum <> Nothing Then
                If MsgBox("Coi Already Have Reference # " & vbCrLf & "Do you want yo Tag", MsgBoxStyle.YesNo, "Verification") = MsgBoxResult.No Then Exit Sub
                AddTimelyLogs("TAGGING COI", "New Ref. Num " & Ticket, , , "Old Ref. Num " & Coi.TicketNum, )
            End If
        End If

        If Coi.ClientName <> Client Then
            MsgBox("Invalid Customer ", MsgBoxStyle.Critical, "Warning!")
            Exit Sub
        End If

        For Each itm As ListViewItem In lvCoi.Items
            If itm.Text.Contains(Coi.COInumber) Then
                MsgBox("Duplicate Coi#: " & itm.Text, MsgBoxStyle.Critical, "Warning!")
                Exit Sub
            End If
        Next

        With Coi
            Dim lv As ListViewItem = lvCoi.Items.Add(.COInumber)
            lv.SubItems.Add(.ClientName)
            lv.Tag = .ID
        End With
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        frmInsuranceList.SearchSelect(secured_str, FormName.Coi)
        frmInsuranceList.Show()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If lvCoi.Items.Count = 0 Then Exit Sub
        'Ins = New Insurance
        For Each itm As ListViewItem In lvCoi.Items
            'With Ins
            '    .ID = itm.Tag
            '    .TicketNum = String.Format("PT#{0:000000}", Ticket)
            '    .UpdateInsurance()
            'End With
            CollectCoi.Add(itm.Tag, itm.SubItems(0).Text)
        Next
        MsgBox("Coi Successfully Tag", MsgBoxStyle.Information, "Information")
        frmPawningItemNew.Coi = CollectCoi
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        frmInsurance.Show()
        frmInsurance.isCoi = True
        frmInsurance.btnNew.PerformClick()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvCoi_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvCoi.KeyDown
        If lvCoi.SelectedItems.Count = 0 Then Exit Sub

        If e.KeyCode = Keys.Delete Then
            For Each itm As ListViewItem In lvCoi.SelectedItems
                lvCoi.Items.Remove(itm)
            Next

        End If
    End Sub
End Class