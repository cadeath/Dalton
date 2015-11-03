Public Class frmMTlist

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMTlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadActive()
    End Sub

    Friend Sub LoadActive()
        Dim mySql As String = "SELECT * FROM tblMoneyTransfer WHERE Status = 'A' ORDER BY TransDate ASC"
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvMoneyTransfer.Items.Clear()
        Console.WriteLine("Record Found: " & ds.Tables(0).Rows.Count)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpMT As New MoneyTransfer
            tmpMT.LoadTransactionByRow(dr)
            AddItem(tmpMT)
        Next
    End Sub

    Private Sub AddItem(ByVal mt As MoneyTransfer)
        Dim lv As ListViewItem = lvMoneyTransfer.Items.Add(mt.ReferenceNumber)
        lv.SubItems.Add(mt.TransactionDate)
        lv.SubItems.Add(IIf(mt.TransactionType = 1, "In", "Out"))
        lv.SubItems.Add(mt.ServiceType)
        lv.SubItems.Add(String.Format("{0} {1}", mt.Sender.FirstName, mt.Sender.LastName))
        lv.SubItems.Add(String.Format("{0} {1}", mt.Receiver.FirstName, mt.Receiver.LastName))
        lv.SubItems.Add(mt.TransferAmount)
        If mt.Status = "V" Then lv.BackColor = Color.LightGray
        If mt.Status = "I" Then lv.BackColor = Color.Red
        lv.Tag = mt.ID
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        ' to be added more comprehensive searching
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblMoneyTransfer WHERE refNum LIKE '%" & txtSearch.Text & "%' "
        ds = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No result found", MsgBoxStyle.Information)
            Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpMT As New MoneyTransfer
            tmpMT.LoadTransactionByRow(dr)
            AddItem(tmpMT)
        Next

        MsgBox(ds.Tables(0).Rows.Count & " result found.", MsgBoxStyle.Information)
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmMoneyTransfer.Show()
    End Sub
End Class