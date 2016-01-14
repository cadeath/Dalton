Public Class qryDate

    Enum ReportType As Integer
        RedeemRenew = 0
        LoanRenew = 1
        DailyCashCount = 2
        Insurance = 3
    End Enum
    Friend FormType As ReportType = ReportType.RedeemRenew

    Private Sub Generate()
        Select Case FormType
            Case ReportType.RedeemRenew
                RedeemRenew()
            Case ReportType.LoanRenew
                LoanRenew()
            Case ReportType.DailyCashCount
                DailyCashCount()
            Case ReportType.Insurance
                InsuranceReport()
        End Select
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If cboReports.Text = "" And cboReports.Visible Then Exit Sub

        If cboReports.Visible Then
            Select Case cboReports.Text
                Case "Schedule of Redeem and Renewal"
                    FormType = ReportType.RedeemRenew
                Case "Schedule of Loan and Renewal"
                    FormType = ReportType.LoanRenew
                Case "Certificate of Insurance"
                    FormType = ReportType.Insurance
            End Select
        End If

        Generate()
    End Sub

    Private Sub InsuranceReport()
        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)
        Dim fillData As String = "dsInsurance", mySql As String

        mySql = "SELECT * FROM tblInsurance "
        mySql &= String.Format("WHERE transDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Insurance.rdlc", Nothing, 0)
        frmReport.Show()
    End Sub

    Private Sub RedeemRenew()
        Dim selectedDate As Date = GetFirstDate(monCal.SelectionStart)
        Dim fillData As String
        fillData = "dsRedeemRenew"

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

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_RedeemRenew.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub LoanRenew()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsLoanRenew"
        Dim mySql As String = "SELECT * FROM MONTHLY_LOANRENEW"
        mySql &= String.Format(" WHERE LOANDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY LOANDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_LoanRenew.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub DailyCashCount()
        Dim fillData As String, rptSQL As New Dictionary(Of String, String)
        Dim mySql As String, subReportSQL As New Dictionary(Of String, String)

        fillData = "dsDaily"
        mySql = "SELECT * FROM DAILY WHERE "
        mySql &= String.Format("CURRENTDATE = '{0}'", monCal.SelectionRange.Start.ToShortDateString)
        rptSQL.Add(fillData, mySql)

        fillData = "dsDebit"
        mySql = "SELECT TRANSDATE, TRANSNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, CCNAME "
        mySql &= "FROM JOURNAL_ENTRIES WHERE "
        mySql &= String.Format("TRANSDATE = '{0}'", monCal.SelectionRange.Start.ToShortDateString)
        mySql &= " AND DEBIT <> 0 AND TRANSNAME = 'Revolving Fund' "
        mySql &= " GROUP BY TRANSDATE, TRANSNAME, CCNAME"
        rptSQL.Add(fillData, mySql)

        fillData = "dsCredit"
        mySql = "SELECT TRANSDATE, TRANSNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, CCNAME "
        mySql &= "FROM JOURNAL_ENTRIES WHERE "
        mySql &= String.Format("TRANSDATE = '{0}'", monCal.SelectionRange.Start.ToShortDateString)
        mySql &= " AND CREDIT <> 0 AND TRANSNAME = 'Revolving Fund' "
        mySql &= " GROUP BY TRANSDATE, TRANSNAME, CCNAME"
        rptSQL.Add(fillData, mySql)

        'Sub Report
        fillData = "dsCoin"
        mySql = "SELECT * FROM CASH_COUNT WHERE "
        mySql &= String.Format("CURRENTDATE = '{0}'", monCal.SelectionRange.Start.ToShortDateString)
        mySql &= " AND MONEYTYPE = 'COIN'"
        subReportSQL.Add(fillData, mySql)

        fillData = "dsBill"
        mySql = "SELECT * FROM CASH_COUNT WHERE "
        mySql &= String.Format("CURRENTDATE = '{0}'", monCal.SelectionRange.Start.ToShortDateString)
        mySql &= " AND MONEYTYPE = 'BILL'"
        subReportSQL.Add(fillData, mySql)

        ' Parameters
        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtCurrentDate", CurrentDate)
        rptPara.Add("branchName", branchName)

        frmReport.MultiDbSetReport(rptSQL, "Reports\rpt_CashCountSheet.rdlc", rptPara, 1, subReportSQL)
        frmReport.Show()
    End Sub

    Private Sub qryDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If FormType = ReportType.DailyCashCount Then
            cboReports.Visible = False
        Else
            cboReports.Visible = True
        End If
    End Sub
End Class