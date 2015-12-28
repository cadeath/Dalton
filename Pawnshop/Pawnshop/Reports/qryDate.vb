Public Class qryDate

    Private branchName As String = GetOption("BranchName")

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Generate()
    End Sub

    Private Sub Generate()
        Dim selectedDate As Date = GetFirstDate(monCal.SelectionStart)
        Dim fillData As String = "dsRedeemRenew"
        Console.WriteLine("Selected First: " & selectedDate.ToShortDateString)

        Dim mySql As String = "SELECT ORDATE,"
        mySql &= vbCrLf & "SUM(CASE WHEN STATUS = 'X' THEN 1 ELSE 0 END) AS COUNT_REDEEM,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN PRINCIPAL ELSE 0 END) AS PRINCIPAL_REDEEM,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN INTEREST + PENALTY ELSE 0 END) AS INTEREST_REDEEM,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN SERVICECHARGE ELSE 0 END) AS SC_REDEEM,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN PRINCIPAL + INTEREST + PENALTY + SERVICECHARGE ELSE 0 END) as TOTAL_REDEEM,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN 1 WHEN 'R' THEN 1 ELSE 0 END) AS COUNT_RENEW,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN PRINCIPAL WHEN 'R' THEN PRINCIPAL ELSE 0 END) AS PRINCIPAL_RENEW,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN INTEREST + PENALTY WHEN 'R' THEN INTEREST + PENALTY ELSE 0 END) AS INTEREST_RENEW,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN SERVICECHARGE ELSE 0 END) AS SC_RENEW,"
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN PRINCIPAL + INTEREST + PENALTY + SERVICECHARGE "
        mySql &= vbCrLf & "	WHEN 'R' THEN PRINCIPAL + INTEREST + PENALTY + SERVICECHARGE ELSE 0 END) as TOTAL_RENEW"
        mySql &= vbCrLf & "FROM TBLPAWN"
        mySql &= vbCrLf & String.Format("WHERE ORDATE BETWEEN '{0}' AND '{1}'", selectedDate.Date.ToShortDateString, GetLastDate(selectedDate.Date).ToShortDateString)
        mySql &= vbCrLf & "GROUP BY 1"

        Console.WriteLine("REPORT SQL: ")
        Console.WriteLine(mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & selectedDate.ToString("MMMM").ToUpper & " " & selectedDate.Year)
        rptPara.Add("branchName", branchName)

        Console.WriteLine(mySql)
        frmReport.ReportInit(mySql, fillData, "Reports\rpt_RedeemRenew.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Function GetFirstDate(ByVal curDate As Date) As Date
        Dim firstDay = DateSerial(curDate.Year, curDate.Month, 1)
        Return firstDay
    End Function

    Private Function GetLastDate(ByVal curDate As Date) As Date
        Dim original As DateTime = curDate  ' The date you want to get the last day of the month for
        Dim lastOfMonth As DateTime = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1)

        Return lastOfMonth
    End Function
End Class