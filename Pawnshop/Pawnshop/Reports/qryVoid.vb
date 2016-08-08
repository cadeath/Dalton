Public Class qryVoid

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        VoidReport()
    End Sub
    Private Sub VoidReport()
        Dim cur As Date = monCal.SelectionStart

        Dim mySql As String, dsName As String = "dsVoid"

        mySql = "SELECT V.VOID_ID, V.TRANSDATE, V.MOD_NAME, V.REMARKS, G.FULLNAME AS ENCODER, G2.FULLNAME AS VOIDED_BY "
        mySql &= "FROM TBLVOID V "
        mySql &= "INNER JOIN TBL_GAMIT G ON G.USERID = V.ENCODER "
        mySql &= "INNER JOIN TBL_GAMIT G2 ON G2.USERID=V.VOIDED_BY "
        mySql &= "WHERE V.TRANSDATE = '" & cur & "'"

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthOf", "DATE: " & cur.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rptVoidReport.rdlc", addParameters)
        frmReport.Show()
    End Sub
End Class