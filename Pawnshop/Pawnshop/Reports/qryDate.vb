Public Class qryDate

    Friend isAuditing As Boolean = False

    ' HOW TO ADD NEW REPORT
    ' 1. Create your Report Procedure (Sub)
    ' 2. Add ReportType
    ' 3. At the Generate Sub, include your 
    '    ReportType and your Procedure
    ' 4. If your report don't have DROP DOWN
    '    LIST, usually for Monthly Report, include
    '    it on NoFilter function
    ' 5. For Monthly Report, include in at the Drop
    '    Down by editing the menu list at the inter-
    '    face.
    ' 6. And include it at the Select Case in the
    '    Click Method.

    ' STEP 2
    Enum ReportType As Integer
        RedeemRenew = 0
        LoanRenew = 1
        DailyCashCount = 2
        Insurance = 3
        DollarBuying = 4
        BranchBorrowings = 5
        ItemPullOut = 6
        MoneyTransfer = 7
        Hourly = 8
        HourlySummary = 9
        DailyInsurance = 10
        LoanRenew2 = 11
        MoneyTransferBSP = 12
        DollarDaily = 13
        MonthlyTransactionCountSummary = 14
        MoneyTransferBracketing = 15
        RenewalBreakDown = 16
        VoidReportDaily = 17
        VoidReportMonthly = 18

    End Enum
    Friend FormType As ReportType = ReportType.RedeemRenew

    ' STEP 3
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
            Case ReportType.ItemPullOut
                Item_PullOut()
            Case ReportType.MoneyTransfer
                MoneyTransfer()
            Case ReportType.Hourly
                Generate_Hourly()
            Case ReportType.HourlySummary
                Hourly_Summary()
            Case ReportType.DailyInsurance
                DailyInsurance()
            Case ReportType.LoanRenew2
                LoanRenew2()
            Case ReportType.MoneyTransferBSP
                MoneyTransfer_BSP()
            Case ReportType.DollarDaily
                DailyDollar()
            Case ReportType.MonthlyTransactionCountSummary
                TransactionCount()
            Case ReportType.MoneyTransferBracketing
                MoneyTransferBracketing()
            Case ReportType.RenewalBreakDown
                monthlyRenewalBreakDown()
            Case ReportType.VoidReportDaily
                VoidReportDaily()
            Case ReportType.VoidReportMonthly
                VoidReportMonthly()
        End Select
    End Sub

    Private Sub MoneyTransfer_BSP()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionStart)

        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsMonthly"
        rptPath = "Reports\rpt_Monthly_BSP.rdlc"

        mySql = "SELECT * FROM MONEY_TRANSFER WHERE TRANSDATE BETWEEN '" + st.ToShortDateString + "' AND '" + en.ToShortDateString + "'"

        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " + st.ToString("MMMM yyyy"))
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara, True)
        frmReport.Show()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If cboReports.Text = "" And cboReports.Visible Then Exit Sub

        ' STEP 6
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
                Case "Loan Register - New Loan and Renewal 2"
                    FormType = ReportType.LoanRenew2
                Case "Money Transfer (BSP)"
                    FormType = ReportType.MoneyTransferBSP
                Case "Monthly Transaction Count Summary"
                    FormType = ReportType.MonthlyTransactionCountSummary
                Case "MoneyTransfer Bracketing"
                    FormType = ReportType.MoneyTransferBracketing
                Case "Monthly Renewal Break Down"
                    FormType = ReportType.RenewalBreakDown
                Case "Monthly Void Report"
                    FormType = ReportType.VoidReportMonthly

            End Select
        End If

        Generate()
    End Sub

    Private Sub Generate_Hourly()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsHourly2"
        rptPath = "Reports\rptd_graph.rdlc"

        mySql = "SELECT "
        mySql &= vbCrLf & "    EXTRACT(HOUR from TIMELY) AS DT_HOUR, "
        mySql &= vbCrLf & "    CASE "
        mySql &= vbCrLf & "        WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'NEW' THEN 'NEWLOAN' "
        mySql &= vbCrLf & "        WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'REN' THEN 'RENEW' "
        mySql &= vbCrLf & "        WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'RED' THEN 'REDEEM' "
        mySql &= vbCrLf & "        ELSE "
        mySql &= vbCrLf & "        MOD_NAME "
        mySql &= vbCrLf & "END AS ""MOD_TYPE"" "
        mySql &= vbCrLf & "FROM TBL_DAILYTIMELOG "
        mySql &= vbCrLf & "WHERE HASCUSTOMER = 1 AND MOD_NAME <> 'INSURANCE' AND "
        mySql &= vbCrLf & String.Format("    TIMELY BETWEEN '{0} 00:00:00' AND '{0} 23:59:59'", monCal.SelectionStart.ToShortDateString)

        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtAsOf", "Date: " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara, False)
        frmReport.Show()
    End Sub

    Private Sub Hourly_Summary()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsHrSummary"
        rptPath = "Reports\rpt_hourlySummary.rdlc"

        mySql = "SELECT D.*, "
        mySql &= vbCrLf & "  CASE "
        mySql &= vbCrLf & "    WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'NEW' THEN 'NEWLOAN' "
        mySql &= vbCrLf & "    WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'REN' THEN 'RENEW' "
        mySql &= vbCrLf & "    WHEN MOD_NAME = 'PAWNING' AND LEFT(LOG_REPORT,3) = 'RED' THEN 'REDEEM' "
        mySql &= vbCrLf & "    ELSE "
        mySql &= vbCrLf & "    MOD_NAME "
        mySql &= vbCrLf & "  END AS ""MOD_TYPE"" "
        mySql &= vbCrLf & "FROM TBL_DAILYTIMELOG D "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	TIMELY BETWEEN '{0} 00:00:00' AND '{0} 23:59:59'", monCal.SelectionStart.ToShortDateString)

        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtSubtitle", String.Format("{0} as of {1}", branchName, monCal.SelectionStart.ToShortDateString))

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

    Private Sub LoanRenew2()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)
        Dim mySql As String, dsName As String = "dsLoanRenew"
        Dim rptPath As String = "Reports/rpt_LoanRenew_Monthly2.rdlc"

        mySql = "SELECT "
        mySql &= vbCrLf & "    P.LOANDATE, SUM(P.PRINCIPAL) AS PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET = 0 THEN P.ADVINT ELSE 0 END) AS ADV_INT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET = 0 THEN P.NETAMOUNT ELSE 0 END) AS NET_AMOUNT, "
        mySql &= vbCrLf & "    SUM(P.SERVICECHARGE) AS SERVICECHARGE, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET > 0 THEN P.DELAYINTEREST + P2.DELAYINTEREST ELSE 0 END) AS RENEW_INT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET > 0 THEN P.PENALTY + P2.PENALTY ELSE 0 END) AS RENEW_PEN,    "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET > 0 THEN P.RENEWDUE + P2.RENEWDUE ELSE 0 END) AS RENEW_DUE, "
        mySql &= vbCrLf & "    COUNT(P.PAWNTICKET) AS PT_CNT "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "    PAWN_LIST P LEFT JOIN PAWN_LIST P2 "
        mySql &= vbCrLf & "    ON P.OLDTICKET = P2.PAWNTICKET "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("    P.LOANDATE BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "    AND (P.OLDTICKET = 0 OR (P.OLDTICKET > 0 AND P.RENEWDUE + P2.RENEWDUE Is Not Null)) "
        mySql &= vbCrLf & "     AND P.STATUS <> 'V' "
        mySql &= vbCrLf & "GROUP BY "
        mySql &= vbCrLf & "    P.LOANDATE"

        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("branchName", branchName)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & st.ToString("MMMM yyyy").ToUpper)


        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

    Private Sub MoneyTransfer()
        diagMT.st = GetFirstDate(monCal.SelectionStart)
        diagMT.en = GetLastDate(monCal.SelectionEnd)

        diagMT.Show()
    End Sub

    Private Sub InsuranceReport()
        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)
        Dim fillData As String = "dsInsurance", mySql As String

        mySql = "SELECT * FROM tblInsurance "
        mySql &= String.Format("WHERE transDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)
        mySql &= " AND STATUS <> 'V'"
        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDate.ToString("MMMM").ToUpper & " " & enDate.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Insurance.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub DailyInsurance()
        Dim fillData As String = "dsInsurance", mySql As String

        mySql = "SELECT * FROM tblInsurance "
        mySql &= String.Format("WHERE transDate = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= " AND STATUS <> 'V'"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & monCal.SelectionStart.ToString("MMM dd, yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Insurance.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub RedeemRenew()
        Dim selectedDate As Date = GetFirstDate(monCal.SelectionStart)
        Dim fillData As String
        fillData = "dsRedeemRenew"

        Dim mySql As String = "SELECT ORDATE, "
        mySql &= vbCrLf & "SUM(CASE WHEN STATUS = 'X' THEN 1 ELSE 0 END) AS COUNT_REDEEM, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN PRINCIPAL ELSE 0 END) AS PRINCIPAL_REDEEM, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN DELAYINTEREST ELSE 0 END) AS INTEREST_REDEEM, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN PENALTY ELSE 0 END) AS PENALTY_REDEEM, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN SERVICECHARGE ELSE 0 END) AS SC_REDEEM, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN 'X' THEN REDEEMDUE ELSE 0 END) as TOTAL_REDEEM, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN 1 WHEN 'R' THEN 1 ELSE 0 END) AS COUNT_RENEW, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN PRINCIPAL WHEN 'R' THEN PRINCIPAL ELSE 0 END) AS PRINCIPAL_RENEW, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN DELAYINTEREST + ADVINT WHEN 'R' THEN DELAYINTEREST ELSE 0 END) AS INTEREST_RENEW, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN PENALTY WHEN 'R' THEN PENALTY ELSE 0 END) AS PENALTY_RENEW, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN SERVICECHARGE ELSE 0 END) AS SC_RENEW, "
        mySql &= vbCrLf & "SUM(CASE STATUS WHEN '0' THEN RENEWDUE WHEN 'R' THEN RENEWDUE ELSE 0 END) AS TOTAL_RENEW "
        mySql &= vbCrLf & "FROM OPT "
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
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMCATEGORY = 'CEL' AND P.OLDTICKET = 0 THEN 1 ELSE 0 END) AS CEL_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMCATEGORY = 'CEL' AND P.OLDTICKET = 0 THEN P.PRINCIPAL ELSE 0 END) AS CEL_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMCATEGORY = 'JWL' AND P.OLDTICKET = 0 THEN 1 ELSE 0 END) AS JWL_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.ITEMCATEGORY = 'JWL' AND P.OLDTICKET = 0 THEN P.PRINCIPAL ELSE 0 END) AS JWL_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN (P.ITEMCATEGORY = 'APP' OR P.ITEMCLASS = 'BIG') AND P.OLDTICKET = 0 THEN 1 ELSE 0 END) AS APP_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN (P.ITEMCATEGORY = 'APP' OR P.ITEMCLASS = 'BIG') AND P.OLDTICKET = 0 THEN P.PRINCIPAL "
        mySql &= vbCrLf & "    WHEN P.ITEMCATEGORY = 'BIG' AND P.OLDTICKET = 0 THEN P.PRINCIPAL ELSE 0 END) AS APP_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE P.OLDTICKET WHEN 0 THEN 1 ELSE 0 END) AS LOAN_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE P.OLDTICKET WHEN 0 THEN P.PRINCIPAL ELSE 0 END) AS LOAN_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P2.RENEWDUE <> 0 THEN 1 ELSE 0 END) AS RENEW_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P2.RENEWDUE <> 0 THEN P2.PRINCIPAL ELSE 0 END) AS RENEW_PRINCIPAL "
        mySql &= vbCrLf & "FROM OPT P "
        mySql &= vbCrLf & "LEFT JOIN OTP P2 ON P.OLDTICKET = P2.PAWNTICKET "
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

    Private Sub Item_PullOut()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)

        Dim dsName As String = "dsPullOut", mySql As String = _
        "SELECT * FROM PAWN_LIST WHERE STATUS = 'W' AND "
        mySql &= String.Format("WITHDRAWDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMM yyyy").ToUpper)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_ItemPullout.rdlc", addParameters)
        frmReport.Show()
    End Sub

    Private Sub DailyCashCount_Audit()
        Dim mySql As String, ds As DataSet
        Dim latestCashCount As Integer

        ' Get the Latest Cash Count
        mySql = "SELECT D.CurrentDate, D.MAINTAINBAL, D.INITIALBAL, CC.DENOMINATION, CC.CNT, CC.TOTAL, CC.STATUS, CC.MONEYTYPE"
        mySql &= vbCrLf & " FROM"
        mySql &= vbCrLf & " tblCashCount CC"
        mySql &= vbCrLf & " RIGHT JOIN tblMaintenance M on M.OPT_KEYS = CC.DENOMINATION"
        mySql &= vbCrLf & " INNER JOIN tblDaily D on D.ID = CC.DailyID"
        ds = LoadSQL(mySql & " ORDER BY CC.STATUS DESC")

        Console.WriteLine("[DEBUG] " & mySql)
        latestCashCount = ds.Tables(0).Rows(0).Item("STATUS")

        Dim fillData As String, rptSQL As New Dictionary(Of String, String)
        Dim subReportSQL As New Dictionary(Of String, String)

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
        mySql = "SELECT D.CurrentDate, D.MAINTAINBAL, D.INITIALBAL, CC.DENOMINATION, CC.CNT, CC.TOTAL, CC.STATUS, CC.MONEYTYPE"
        mySql &= vbCrLf & " FROM"
        mySql &= vbCrLf & " tblCashCount CC"
        mySql &= vbCrLf & " RIGHT JOIN tblMaintenance M on M.OPT_KEYS = CC.DENOMINATION"
        mySql &= vbCrLf & " INNER JOIN tblDaily D on D.ID = CC.DailyID"
        mySql &= String.Format(" WHERE D.CURRENTDATE = '{0}' AND CC.STATUS = {1}", monCal.SelectionRange.Start.ToShortDateString, latestCashCount)
        subReportSQL.Add(fillData, mySql)

        fillData = "dsBill"
        subReportSQL.Add(fillData, mySql & " AND MONEYTYPE = 'COIN'")

        ' Parameters
        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtCurrentDate", monCal.SelectionRange.Start.ToShortDateString)
        rptPara.Add("branchName", branchName)

        frmReport.MultiDbSetReport(rptSQL, "Reports\rpt_CashCountSheet.rdlc", rptPara, 1, subReportSQL)
        frmReport.Show()
    End Sub

    Friend Sub AutoDisplay_CashCount(dt As Date)
        monCal.SetDate(dt)

        DailyCashCount_Audit()
    End Sub

    Private Sub DailyCashCount()

        If isAuditing Then
            DailyCashCount_Audit()
            Exit Sub
        End If

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
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN '{0}' AND '{1}' AND STATUS = 'A'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("BranchName", branchName)
        'rptPara.Add("txtUsername", "Blade")

        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransaction.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub DailyDollar()
        Dim fillData As String = "dsDollar"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE TRANSDATE = '{0}' AND STATUS ='A'", monCal.SelectionStart.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & monCal.SelectionStart.ToLongDateString)
        rptPara.Add("BranchName", "Bula-Road")
        ' rptPara.Add("txtUsername", "Blade")

        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransaction.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub Borrowings()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsBorrowings"
        Dim mySql As String = "SELECT * FROM BORROWINGS"
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " AND STATUS <> 'N/A'"
        mySql &= " ORDER BY TRANSDATE ASC, STATUS ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_Borrowings.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub TransactionCount()

        Dim StartDay = GetFirstDate(monCal.SelectionStart)
        Dim EndDay = GetLastDate(monCal.SelectionEnd)

        Dim filldata As String = "dsTransactionCount"
        Dim mySql As String = "SELECT LOGS_ID, MOD_NAME, CAST(TIMELY AS DATE)AS TIMELY FROM TBL_DAILYTIMELOG "
        mySql &= "WHERE HASCUSTOMER = '1' AND "
        mySql &= String.Format(" TIMELY BETWEEN '{0}' AND '{1}'", StartDay.ToShortDateString, EndDay.ToShortDateString)
        mySql &= " AND REMARKS NOT LIKE '%VOID%'"

        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthstart", "DATE: " & StartDay.ToShortDateString)
        addParameters.Add("txtMonthend", "DATE: " & EndDay.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, filldata, "Reports\rpt_MonthlyTransactionCount.rdlc", addParameters)
        frmReport.Show()
    End Sub
    Private Sub MoneyTransferBracketing()

        diagMoneyTransferBracketing.st = GetFirstDate(monCal.SelectionStart)
        diagMoneyTransferBracketing.en = GetLastDate(monCal.SelectionEnd)

        diagMoneyTransferBracketing.Show()
    End Sub

    Private Sub monthlyRenewalBreakDown()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsRenewalBreakDown", mySql As String

        mySql = "SELECT  COUNT(*), ITM.ITEMCATEGORY,P.ORDATE,P.PRINCIPAL "
        mySql &= "FROM OPT P INNER JOIN OPI I ON I.PAWNITEMID = P.PAWNITEMID "
        mySql &= "INNER JOIN TBLITEM ITM ON ITM.ITEMID = I.ITEMID "
        mySql &= "WHERE ORDate BETWEEN '" & stDay & "' AND '" & laDay & "' "
        mySql &= "AND P.STATUS = '0' GROUP BY ITM.ITEMCATEGORY,P.ORDATE,P.PRINCIPAL "
        mySql &= "ORDER BY P.ORDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\RenewalBreakDown.rdlc", rptPara)
        frmReport.Show()
    End Sub
    ' STEP 4
    Private Function NoFilter() As Boolean
        Select Case FormType
            Case ReportType.DailyCashCount
                Return True
            Case ReportType.ItemPullOut
                Return True
            Case ReportType.Insurance
                Return True
            Case ReportType.Hourly
                Return True
            Case ReportType.HourlySummary
                Return True
            Case ReportType.DailyInsurance
                Return True
            Case ReportType.DollarDaily
                Return True
            Case ReportType.VoidReportDaily
                Return True
            Case ReportType.VoidReportMonthly
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