Public Class qryDate

    Enum ReportType As Integer
        RedeemRenew = 0
        LoanRenew = 1
        DailyCashCount = 2
        Insurance = 3
        DollarBuying = 4
        BranchBorrowings = 5
        OutStanding = 7
        ItemPullOut = 8
        MoneyTransfer = 9
        Hourly = 10
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
            Case ReportType.DollarBuying
                DollarBuying()
            Case ReportType.BranchBorrowings
                Borrowings()
            Case ReportType.OutStanding
                Outstanding_Loans()
            Case ReportType.ItemPullOut
                Item_PullOut()
            Case ReportType.MoneyTransfer
                MoneyTransfer()
            Case ReportType.Hourly
                Generate_Hourly()
        End Select
    End Sub

    Private Sub Generate_Hourly()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsHourly"
        rptPath = "Reports\rptd_graph.rdlc"

        mySql = "SELECT EXTRACT (HOUR from TIMELY) AS DT_HOUR, "
        mySql &= vbCrLf & " CASE"
        mySql &= vbCrLf & "  WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'NEW' THEN 'NEW LOAN' "
        mySql &= vbCrLf & "  WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'REN' THEN 'RENEW' "
        mySql &= vbCrLf & "  WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'RED' THEN 'REDEEM' "
        mySql &= vbCrLf & "   ELSE MOD_NAME "
        mySql &= vbCrLf & " END AS TYPE, "
        mySql &= vbCrLf & "COUNT(TIMELY) AS DT_COUNT "
        mySql &= vbCrLf & "FROM TBL_DAILYTIMELOG "
        mySql &= vbCrLf & String.Format("WHERE TIMELY BETWEEN '{0} 0:0:0' AND '{0} 23:59:59' ", monCal.SelectionStart.ToShortDateString)
        mySql &= vbCrLf & "GROUP BY EXTRACT (HOUR from TIMELY),TYPE"

        Dim ds As DataSet = LoadSQL(mySql)
        For Each dr As DataRow In ds.Tables(0).Rows
            Console.WriteLine(String.Format("Hour: {0} = {1}", dr("DT_HOUR"), dr("DT_COUNT")))
        Next

        frmReport.ReportInit(mySql, dsName, rptPath, , False)
        frmReport.Show()
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
                Case "Dollar Buying"
                    FormType = ReportType.DollarBuying
                Case "Branch Borrowings"
                    FormType = ReportType.BranchBorrowings
                Case "Money Transfer"
                    FormType = ReportType.MoneyTransfer
                Case "Item Pullout"
                    FormType = ReportType.ItemPullOut
            End Select
        End If

        Generate()
    End Sub

    Private Sub MoneyTransfer()
        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)
        Dim fillData As String = "dsMT", mySql As String

        mySql = "SELECT * FROM MONEY_TRANSFER "
        mySql &= String.Format("WHERE TRANSDATE BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDate.ToString("MMMM").ToUpper & " " & enDate.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Monthly_MT.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub InsuranceReport()
        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)
        Dim fillData As String = "dsInsurance", mySql As String

        mySql = "SELECT * FROM tblInsurance "
        mySql &= String.Format("WHERE transDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDate.ToString("MMMM").ToUpper & " " & enDate.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Insurance.rdlc", rptPara)
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
        mySql &= vbCrLf & String.Format("WHERE ORDATE BETWEEN '{0}' AND '{1}' ", selectedDate.Date.ToShortDateString, GetLastDate(selectedDate.Date).ToShortDateString)
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
        Dim fillData As String = "dsLoanRenew", mySql As String

        mySql = "SELECT P.LOANDATE, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMTYPE = 'CEL' AND P.OLDTICKET = 0 THEN 1 ELSE 0 END) AS CEL_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMTYPE = 'CEL' AND P.OLDTICKET = 0 THEN P.PRINCIPAL ELSE 0 END) AS CEL_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMTYPE = 'JWL' AND P.OLDTICKET = 0 THEN 1 ELSE 0 END) AS JWL_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMTYPE = 'JWL' AND P.OLDTICKET = 0 THEN P.PRINCIPAL ELSE 0 END) AS JWL_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMTYPE = 'APP' AND P.OLDTICKET = 0 THEN 1 ELSE 0 END) AS APP_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMTYPE = 'APP' AND P.OLDTICKET = 0 THEN P.PRINCIPAL "
        mySql &= vbCrLf & "    WHEN P.ITEMTYPE = 'BIG' AND P.OLDTICKET = 0 THEN P.PRINCIPAL ELSE 0 END) AS APP_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE P.OLDTICKET WHEN 0 THEN 1 ELSE 0 END) AS LOAN_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE P.OLDTICKET WHEN 0 THEN P.PRINCIPAL ELSE 0 END) AS LOAN_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P2.RENEWDUE <> 0 THEN 1 ELSE 0 END) AS RENEW_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P2.RENEWDUE <> 0 THEN P2.PRINCIPAL ELSE 0 END) AS RENEW_PRINCIPAL "
        mySql &= vbCrLf & "FROM TBLPAWN P "
        mySql &= vbCrLf & "LEFT JOIN TBLPAWN P2 ON P.OLDTICKET = P2.PAWNTICKET "
        mySql &= vbCrLf & "WHERE P.STATUS <> 'V' AND "
        mySql &= vbCrLf & String.Format("P.LOANDATE BETWEEN '{0}' AND '{1}' ", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= vbCrLf & "GROUP BY 1 "
        mySql &= vbCrLf & "ORDER BY P.LOANDATE ASC "

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_LoanRenew.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub Outstanding_Loans()
        Dim dsName As String = "dsOutstanding", mySql As String

        mySql = "SELECT * "
        mySql &= "FROM "
        mySql &= "( "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWNING "
        mySql &= "  WHERE (Status = 'NEW' OR Status = 'RENEW') "
        mySql &= "  AND LOANDATE <= '" & monCal.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWNING "
        mySql &= "  WHERE (Status = 'RENEWED') "
        mySql &= "  AND LOANDATE <= '" & monCal.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCal.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWNING "
        mySql &= "  WHERE (Status = 'REDEEM') "
        mySql &= "  AND LOANDATE <= '" & monCal.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCal.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWNING "
        mySql &= "  WHERE (Status = 'SEGRE') "
        mySql &= "  AND LOANDATE <= '" & monCal.SelectionStart.ToShortDateString & "' AND (PULLOUT > '" & monCal.SelectionStart.ToShortDateString & "' OR PULLOUT IS NULL) "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWNING "
        mySql &= "  WHERE (Status = 'WITHDRAW') "
        mySql &= "  AND LOANDATE <= '" & monCal.SelectionStart.ToShortDateString & "' AND PULLOUT > '" & monCal.SelectionStart.ToShortDateString & "' "
        mySql &= ") "
        mySql &= "ORDER BY PAWNTICKET ASC"

        Console.WriteLine(mySql)


        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtMonthOf", "DATE: " & monCal.SelectionStart.ToString("MMMM dd yyyy").ToUpper)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Outstanding.rdlc", addParameters)
        frmReport.Show()
    End Sub

    Private Sub Item_PullOut()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)

        Dim dsName As String = "dsPullOut", mySql As String = _
        "SELECT * FROM PAWNING WHERE STATUS = 'WITHDRAW' AND "
        mySql &= String.Format("PULLOUT BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMM yyyy").ToUpper)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_ItemPullout.rdlc", addParameters)
        frmReport.Show()
    End Sub

    Private Sub DailyCashCount()
        If monCal.SelectionRange.Start.ToShortDateString = CurrentDate.ToShortDateString Then
            If frmMain.dateSet Then
                MsgBox("Unable to Generate Cash Count Sheet yet", MsgBoxStyle.Information)
                Exit Sub
            End If
        End If

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
        mySql &= " AND DEBIT <> 0 AND TRANSNAME = 'Revolving Fund' AND TODISPLAY = 1 "
        mySql &= " GROUP BY TRANSDATE, TRANSNAME, CCNAME"
        rptSQL.Add(fillData, mySql)

        fillData = "dsCredit"
        mySql = "SELECT TRANSDATE, TRANSNAME, SUM(DEBIT) AS DEBIT, SUM(CREDIT) AS CREDIT, CCNAME "
        mySql &= "FROM JOURNAL_ENTRIES WHERE "
        mySql &= String.Format("TRANSDATE = '{0}'", monCal.SelectionRange.Start.ToShortDateString)
        mySql &= " AND CREDIT <> 0 AND TRANSNAME = 'Revolving Fund' AND TODISPLAY = 1 "
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
        rptPara.Add("txtCurrentDate", monCal.SelectionRange.Start.ToShortDateString)
        rptPara.Add("branchName", branchName)

        frmReport.MultiDbSetReport(rptSQL, "Reports\rpt_CashCountSheet.rdlc", rptPara, 1, subReportSQL)
        frmReport.Show()
    End Sub

    Private Sub DollarBuying()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsDollar"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Dollar.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub Borrowings()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsBorrowings"
        Dim mySql As String = "SELECT * FROM BORROWINGS"
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC, STATUS ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Borrowings.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Function NoFilter() As Boolean
        Select Case FormType
            Case ReportType.DailyCashCount
                Return True
            Case ReportType.OutStanding
                Return True
            Case ReportType.ItemPullOut
                Return True
            Case ReportType.Insurance
                Return True
            Case ReportType.Hourly
                Return True
        End Select

        Return False
    End Function

    Private Sub qryDate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If NoFilter() Then
            cboReports.Visible = False
        Else
            cboReports.Visible = True
        End If
    End Sub

End Class