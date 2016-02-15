Public Class dev_report

    Private Sub dev_report_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim stDate As Date = GetFirstDate(Now)
        Dim enDate As Date = GetLastDate(Now)

        Dim mySql As String, ds As New DataSet, dsName As String, rptPath As String = "Reports\rpt_CashInOutSummary.rdlc"
        dsName = "dsCIO"
        mySql = "SELECT * FROM TBLCASHTRANS"
        mySql &= String.Format(" WHERE TransDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)

        frmReport.ReportInit(mySql, dsName, rptPath, , False)
        frmReport.Show()
    End Sub
End Class