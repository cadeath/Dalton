Public Class dev_pawningItem

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

    End Sub

    Private Sub LoadInsurance()
        Dim mySql As String = "SELECT FIRST 50 * FROM tblInsurance WHERE Status LIKE 'A' ORDER BY TRANSDATE DESC"

        Dim ds As DataSet = LoadSQL(mySql)

        For Each ins In ds.Tables(0).Rows
            Dim loadInsu As New Insurance
            loadInsu.LoadByRow(ins)
            'AddItem(loadInsu)
        Next
    End Sub
  
End Class