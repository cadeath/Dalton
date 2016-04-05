Public Class dev_report

    Private Sub dev_report_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim stDate As Date = GetFirstDate(Now)
        Dim enDate As Date = GetLastDate(Now)

        Dim mySql As String, ds As New DataSet, dsName As String, rptPath As String = "Reports\d_Remittance.rdlc"
        dsName = "dsRemit"
        mySql = "SELECT * FROM MONEY_TRANSFER"
        'mySql &= String.Format(" WHERE TransDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)

        'frmReport.ReportInit(mySql, dsName, rptPath, , False)
        'frmReport.Show()
        'Me.ReportViewer1.RefreshReport()

        Graph_Report()
    End Sub

    Private Sub Graph_Report()
        Dim cur As Date = "4/3/2015"

        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsHourly"
        rptPath = "Reports\rptd_graph.rdlc"

        mySql = "SELECT EXTRACT (HOUR from TIMELY) AS DT_HOUR, COUNT(TIMELY) AS DT_COUNT "
        mySql &= vbCrLf & "FROM TBL_DAILYTIMELOG "
        mySql &= vbCrLf & String.Format("WHERE TIMELY BETWEEN '{0} 0:0:0' AND '{1} 23:59:59' ", cur.ToShortDateString, cur.ToShortDateString)
        mySql &= vbCrLf & "GROUP BY EXTRACT (HOUR from TIMELY)"

        Dim ds As DataSet = LoadSQL(mySql)
        For Each dr As DataRow In ds.Tables(0).Rows
            Console.WriteLine(String.Format("Hour: {0} = {1}", dr("DT_HOUR"), dr("DT_COUNT")))
        Next

        frmReport.ReportInit(mySql, dsName, rptPath, , False)
        frmReport.Show()
    End Sub
End Class