Public Class diagTime

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If rbHourly.Checked Then
            Generate_Hourly()
        Else

        End If
    End Sub

    Private Sub diagTime_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        monCal.SelectionStart = CurrentDate
    End Sub

    Private Sub Generate_Hourly()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsHourly"
        rptPath = "Reports\rptd_graph.rdlc"

        mySql = "SELECT EXTRACT (HOUR from TIMELY) AS DT_HOUR, COUNT(TIMELY) AS DT_COUNT "
        mySql &= vbCrLf & "FROM TBL_DAILYTIMELOG "
        mySql &= vbCrLf & String.Format("WHERE TIMELY BETWEEN '{0} 0:0:0' AND '{0} 23:59:59' ", monCal.SelectionStart.ToShortDateString)
        mySql &= vbCrLf & "GROUP BY EXTRACT (HOUR from TIMELY)"

        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("branchName", branchName)
        addPara.Add("txtCurDate", CurrentDate)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub
End Class