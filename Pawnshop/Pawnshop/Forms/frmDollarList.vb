Public Class frmDollarList

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmDollarList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive()
        txtSearch.Focus()
    End Sub

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvDollar.Items.Clear()
    End Sub

    Friend Sub LoadActive()
        Dim mySql As String = "SELECT * FROM tblDollar WHERE status= 'A'"
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvDollar.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpDollar As New DollarTransaction
            tmpDollar.LoadDollarByRow(dr)

            AddItem(tmpDollar)
        Next
    End Sub

    Private Sub AddItem(ByVal dl As DollarTransaction)
        Dim lv As ListViewItem = lvDollar.Items.Add(dl.DollarID)
        lv.SubItems.Add(dl.TransactionDate)
        lv.SubItems.Add(dl.Denomination)
        lv.SubItems.Add(dl.CurrentRate)
        lv.SubItems.Add(dl.NetAmount)
        If Not dl.Customer Is Nothing Then
            lv.SubItems.Add(dl.CustomersName)
        End If

        lv.Tag = dl.DollarID
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvDollar.SelectedItems.Count = 0 Then Exit Sub

        Dim tmpLoad As New DollarTransaction
        Dim id As Integer = lvDollar.FocusedItem.Tag
        tmpLoad.LoadDollar(id)

        frmDollar.LoadDollar(tmpLoad)
        frmDollar.Show()

    End Sub

    Private Sub lvDollar_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvDollar.DoubleClick
        btnView.PerformClick()
    End Sub
End Class