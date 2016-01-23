Public Class frmSegreList

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Dim dsName As String = "dsSegre"
        Dim mySql As String = _
            "SELECT * FROM PAWNING WHERE Status = 'SEGRE' AND "
        mySql &= String.Format("EXPIRYDATE <= '{0}'", monCalendar.SelectionStart.ToShortDateString)
        Dim ds As DataSet = LoadSQL(mySql)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Segregated.rdlc", , False)
        frmReport.Show()
    End Sub
End Class