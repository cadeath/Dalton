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

        'mySql = " SELECT LOGS_ID, MOD_NAME, "
        'mySql &= "(CASE WHEN MOD_NAME = 'INSURANCE' THEN LOGS_ID END) AS INSURANCE, "
        'mySql &= "(CASE WHEN MOD_NAME = 'MONEYTRANSFER' THEN LOGS_ID END) AS MONEYTRANSFER, "
        'mySql &= "(CASE WHEN MOD_NAME = 'CASHCOUNT' THEN LOGS_ID END) AS CASHCOUNT, "
        'mySql &= "(CASE WHEN MOD_NAME = 'CASH IN/OUT' THEN LOGS_ID END) AS CASHINOUT, "
        'mySql &= "(CASE WHEN MOD_NAME = 'NEW LOANS' THEN LOGS_ID END) AS NEWLOANS, "
        'mySql &= "(CASE WHEN MOD_NAME = 'SMARTMONEY IN' THEN LOGS_ID END) AS SMARTMONEYIN, "
        'mySql &= "(CASE WHEN MOD_NAME = 'BDO ATM' THEN LOGS_ID END) AS BDOATM, "
        'mySql &= "(CASE WHEN MOD_NAME = 'DOLLAR' THEN LOGS_ID END) AS DOLLAR "
        'mySql &= " FROM TBL_DAILYTIMELOG "
        'mySql &= String.Format(" WHERE TIMELY BETWEEN '{0}' AND '{1}' AND HASCUSTOMER = '1'", StartDay.ToShortDateString, EndDay.ToShortDateString)
        'mySql &= "GROUP BY MOD_NAME"

        Console.WriteLine(mySql)

        'Dim addParameters As New Dictionary(Of String, String)

        'addParameters.Add("txtMonthOf", "DATE: " & StartDay.ToShortDateString)
        'addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_MonthlyTransactionCount.rdlc")
        frmReport.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class