Public Class frmSegreList

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Dim dsName As String = "dsSegre"
        Dim mySql As String = _
            "SELECT * FROM PAWNING WHERE Status = 'SEGRE' AND "
        mySql &= String.Format("EXPIRYDATE <= '{0}'", monCalendar.SelectionStart.ToShortDateString)
        Dim ds As DataSet = LoadSQL(mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "AS OF " & monCalendar.SelectionStart.ToString("MMMM dd, yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Segregated.rdlc", rptPara)
        frmReport.Show()
    End Sub
End Class