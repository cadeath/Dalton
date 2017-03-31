Public Class frmSMSList

    Enum ReportType As Integer
        MonthlyExpiry = 0
        DailyExpiry = 1
    End Enum
    Friend FormType As ReportType = ReportType.DailyExpiry

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Select Case FormType
            Case ReportType.DailyExpiry
                DailyExpiryList()
            Case ReportType.MonthlyExpiry
                MonthlyExpiryList()
        End Select
    End Sub

    Private Sub MonthlyExpiryList()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)

        Dim mySql As String, dsName As String = "dsExpiryList"

        mySql = "Select M.SMSDATE, M.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, "
        mySql &= "C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
        mySql &= "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS PAWNER "
        mySql &= "From SMS M "
        mySql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = M.CLIENTID "
        mySql &= "INNER JOIN OPT P ON P.PAWNID = M.PAWNID "
        mySql &= "WHERE M.SMSDATE BETWEEN '" & st & "' AND '" & en & "'"

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthOf", "From: " & st.ToShortDateString & " To " & en.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_ExpiryList.rdlc", addParameters)
        frmReport.Show()
    End Sub

    Private Sub DailyExpiryList()
        Dim mySql As String, dsName As String = "dsExpiryList"

        mySql = "Select M.SMSDATE, M.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, "
        mySql &= "C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
        mySql &= "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS PAWNER "
        mySql &= "From SMS M "
        mySql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = M.CLIENTID "
        mySql &= "INNER JOIN OPT P ON P.PAWNID = M.PAWNID "
        mySql &= "WHERE M.SMSDATE = '" & monCal.SelectionStart.ToShortDateString & "'"

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthOf", "From: " & monCal.SelectionStart.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_ExpiryList.rdlc", addParameters)
        frmReport.Show()
    End Sub
End Class