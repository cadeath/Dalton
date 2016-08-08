Public Class qryVoid

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        VoidReport()
    End Sub
    Private Sub VoidReport()
        Dim cur As Date = monCal.SelectionStart

        Dim mySql As String, dsName As String
        dsName = "dsVoid"
       
        mySql = "SELECT * FROM TBLCASHTRANS "
        mySql &= String.Format(" WHERE TRANSDATE = '{0}'", cur.ToShortDateString)
        mySql &= " AND STATUS <> '0' "
        
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "AS OF " & cur.ToString("MMMM dd, yyyy"))
        addPara.Add("branchName", "ROX")

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_CashInOut.rdlc", addPara)
        frmReport.Show()
    End Sub
End Class