Public Class frmCIO_List
    Dim fillData As String = "tblCashTrans"

    Private Sub frmCIO_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        LoadActive()

        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ClearField()
        txtSearch.Text = ""
        lvCIO.Items.Clear()
    End Sub

    Private Sub LoadActive()
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= " WHERE Status = 1 ORDER BY TransID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each cio As DataRow In ds.Tables(0).Rows
            AddItem(cio)
        Next
    End Sub

    Private Sub AddItem(ByVal cio As DataRow)
        Dim tmpCIO As New CashInOutTransaction
        tmpCIO.LoadCashIObyRow(cio)

        Dim lv As ListViewItem = lvCIO.Items.Add(tmpCIO.TransactionID)
        lv.SubItems.Add(tmpCIO.Type)
        lv.SubItems.Add(tmpCIO.TransactionDate.ToString("MMM d, yyyy"))
        lv.SubItems.Add(tmpCIO.Category)
        lv.SubItems.Add(tmpCIO.Transaction)
        lv.SubItems.Add(tmpCIO.Amount)
        lv.SubItems.Add(tmpCIO.Particulars)
        lv.Tag = tmpCIO.TransactionID
        If tmpCIO.Status = 0 Then lv.BackColor = Color.LightGray

        Console.WriteLine(String.Format("{0}. {1} - {2} {3}", lv.Tag, tmpCIO.TransactionID, tmpCIO.Transaction, tmpCIO.Amount))
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE Category LIKE '%{0}%' OR TransName LIKE '%{0}%' OR Remarks LIKE '%{0}%'", txtSearch.Text)
        If IsNumeric(txtSearch.Text) Then mySql &= " OR Amount = " & txtSearch.Text
        mySql &= " ORDER BY TransID DESC"

        Dim ds As DataSet = LoadSQL(mySql)
        lvCIO.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            AddItem(dr)
        Next
    End Sub

    Private Sub VoidID(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE TransID = {1}", fillData, id)
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(fillData).Rows(0).Item("Status") = 0
        database.SaveEntry(ds, False)
        MsgBox("Transaction Voided", MsgBoxStyle.Information)
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvCIO.SelectedItems.Count <= 0 Then Exit Sub
        Dim idx As Integer = lvCIO.FocusedItem.Tag
        VoidID(idx)
        lvCIO.Items.Clear()
        LoadActive()
    End Sub
End Class