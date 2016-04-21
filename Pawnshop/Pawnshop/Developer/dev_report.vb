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

        'Graph_Report()
        'CashInOut_Daily()
        'RedeemRegister()
        Monthly_NewLoanRenew()
    End Sub

    Private Sub RedeemRegister()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsPawning"
        rptPath = "Reports\rpt_RegisterRedeem.rdlc"
        Dim cur As Date = "4/1/2016"

        mySql = "SELECT "
        mySql &= vbCrLf & "     P.PAWNTICKET, P.ORNUM, P.ORDATE, P.CLIENT, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, "
        mySql &= vbCrLf & "    P.DESCRIPTION, P.APPRAISAL, P.PRINCIPAL, "
        mySql &= vbCrLf & "    P.INTEREST, P.PENALTY, P.REDEEMDUE, "
        mySql &= vbCrLf & "    P.SERVICECHARGE, 'REDEEM' AS STATUS "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "	PAWNING P "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	P.ORDATE = '{0}'", cur.ToShortDateString)
        mySql &= vbCrLf & "    AND P.REDEEMDUE <> 0 "
        mySql &= vbCrLf & "    ORDER BY ORNUM ASC"

        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", cur.ToLongDateString)
        addPara.Add("branchName", "Roxas")

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

    Private Sub CashInOut_Daily()
        Dim cur As Date = "4/1/2016"

        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsReports"
        rptPath = "Reports\rpt_CashInOut.rdlc"

        mySql = "SELECT EXTRACT (HOUR from TIMELY) AS DT_HOUR, COUNT(TIMELY) AS DT_COUNT "
        mySql &= vbCrLf & "FROM TBL_DAILYTIMELOG "
        mySql &= vbCrLf & String.Format("WHERE TIMELY BETWEEN '{0} 0:0:0' AND '{1} 23:59:59' ", cur.ToShortDateString, cur.ToShortDateString)
        mySql &= vbCrLf & "GROUP BY EXTRACT (HOUR from TIMELY)"

        mySql = "SELECT * FROM TBLCASHTRANS "
        mySql &= String.Format(" WHERE TRANSDATE = '{0}'", cur.ToShortDateString)

        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "AS OF " & cur.ToString("MMMM dd, yyyy"))
        addPara.Add("branchName", "ROX")

        frmReport.ReportInit(mySql, dsName, rptPath, addPara, False)
        frmReport.Show()
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

    Private Sub Monthly_NewLoanRenew()
        Dim st As Date = #4/1/2016#
        Dim en As Date = #4/30/2016#
        Dim mySql As String, dsName As String = "dsLoanRenew"
        Dim rptPath As String = "Reports/rpt_LoanRenew_Monthly2.rdlc"

        mySql = "SELECT "
        mySql &= vbCrLf & "    P.LOANDATE, SUM(P.PRINCIPAL) AS PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET = 0 THEN P.ADVINT ELSE 0 END) AS ADV_INT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET = 0 THEN P.NETAMOUNT ELSE 0 END) AS NET_AMOUNT, "
        mySql &= vbCrLf & "    SUM(P.SERVICECHARGE) AS SERVICECHARGE, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET > 0 THEN P.INTEREST + P2.INTEREST ELSE 0 END) AS RENEW_INT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET > 0 THEN P.PENALTY + P2.PENALTY ELSE 0 END) AS RENEW_PEN,    "
        mySql &= vbCrLf & "    SUM(CASE WHEN P.OLDTICKET > 0 THEN P.RENEWDUE + P2.RENEWDUE ELSE 0 END) AS RENEW_DUE, "
        mySql &= vbCrLf & "    COUNT(P.PAWNTICKET) AS PT_CNT "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "    PAWNING P LEFT JOIN PAWNING P2 "
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
End Class