Public Class frmMonthlyTransactionCount
    Dim dsName As String = "dsTransactionCount"
    Private mySql As String
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        TransactionCount()
    End Sub
    Private Sub TransactionCount()
        Dim StartDay = GetFirstDate(MonCal.SelectionStart)
        Dim EndDay = GetLastDate(MonCal.SelectionEnd)

        mySql = "SELECT COUNT(*) AS LOGS_ID, MOD_NAME FROM TBL_DAILYTIMELOG "
        mySql &= "WHERE HASCUSTOMER = '1' AND "
        mySql &= String.Format(" TIMELY BETWEEN '{0}' AND '{1}'", StartDay.ToShortDateString, EndDay.ToShortDateString)
        mySql &= "GROUP BY MOD_NAME"

        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthstart", "DATE: " & StartDay.ToShortDateString)
        addParameters.Add("txtMonthend", "DATE: " & EndDay.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_MonthlyTransactionCount.rdlc", addParameters)
        frmReport.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class