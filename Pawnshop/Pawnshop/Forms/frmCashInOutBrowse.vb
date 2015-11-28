Public Class frmCashInOutBrowse

    Private fillData As String = "tblCashTrans"

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmCashInOutBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadTransaction()
    End Sub

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvList.Items.Clear()
    End Sub

    Private Sub LoadTransaction()
        Dim mySql As String, fillData As String = "tblCashTrans"
        mySql = "SELECT * FROM " & fillData & " ORDER BY TransDate DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpCIO As New CashInOutTransaction
            tmpCIO.LoadCashIObyRow(dr)
            AddItem(tmpCIO)
        Next
    End Sub

    Private Sub AddItem(ByVal coi As CashInOutTransaction)
        Dim lv As ListViewItem = lvList.Items.Add(coi.Type)
        lv.SubItems.Add(coi.TransactionDate)
        lv.SubItems.Add(coi.Transaction)
        lv.SubItems.Add(coi.Amount)
        lv.SubItems.Add(coi.Particulars)
        If coi.Status = 0 Then lv.BackColor = Color.LightGray 'Void
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        Dim srcStr As String = String.Format("%{0}%", txtSearch.Text)
        lvList.Items.Clear()

        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE LOWER(transname) LIKE '{0}' OR ", srcStr)
        mySql &= String.Format("LOWER(Remarks) LIKE '{0}'", srcStr)
        If IsNumeric(txtSearch.Text) Then mySql &= String.Format(" OR Amount = {0}", srcStr)
        mySql &= " ORDER BY TransDate DESC"

        Dim ds As DataSet = LoadSQL(mySql)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpCIO As New CashInOutTransaction
            tmpCIO.LoadCashIObyRow(dr)
            AddItem(tmpCIO)
        Next
    End Sub
End Class