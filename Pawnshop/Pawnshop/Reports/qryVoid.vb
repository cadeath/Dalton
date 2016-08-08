Public Class qryVoid
    Enum VoidReport As Integer
        VoidDaily = 0
        VoidMonthly = 1
      
    End Enum
    Friend FormType As VoidReport = VoidReport.VoidDaily
    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Select Case FormType
            Case VoidReport.VoidDaily
                VoidReportDaily()
            Case VoidReport.VoidMonthly
                VoidReportMonthly()
        End Select
    End Sub
    Private Sub VoidReportDaily()
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
    Private Sub VoidReportMonthly()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)

        Dim mySql As String, dsName As String = "dsVoid"

        mySql = "SELECT V.VOID_ID, V.TRANSDATE, V.MOD_NAME, V.REMARKS, G.FULLNAME AS ENCODER, G2.FULLNAME AS VOIDED_BY "
        mySql &= "FROM TBLVOID V "
        mySql &= "INNER JOIN TBL_GAMIT G ON G.USERID = V.ENCODER "
        mySql &= "INNER JOIN TBL_GAMIT G2 ON G2.USERID=V.VOIDED_BY "
        mySql &= "WHERE V.TRANSDATE BETWEEN '" & st & "' AND '" & en & "'"

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthOf", "From: " & st.ToShortDateString & " To " & en.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rptVoidReport.rdlc", addParameters)
        frmReport.Show()
    End Sub
End Class