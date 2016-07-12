Public Class qryAuction
    Private ReportType As String = ""
    Private mySql As String
    Private fillData As String

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If rbJWL.Checked Then ReportType = "JEWELRIES"
        If rbALL.Checked Then ReportType = "ALL"
        If rbMonthly.Checked Then ReportType = "Auction Monthly Transaction Report"
        Select ReportType
            Case "ALL"
                AuctionMonthly_Category()
            Case "JEWELRIES"
                AuctionMonthly_CategoryJWLOnly()
            Case "Auction Monthly Transaction Report"
                AuctionMonthly()
        End Select
    End Sub

    Private Sub AuctionMonthly_Category()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsAuctionMonthly" : rptPath = "Reports\AuctionMonlyreport.rdlc"
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionStart)

        mySql = "select count(CATEGORY) as CountCategory,LOANDATE, AUCTIONDATE, CATEGORY, ITEMTYPE,PRINCIPAL"
        mySql &= vbCrLf & "from TBLPAWN"
        mySql &= vbCrLf & "inner join tblclass on TBLPAWN.CATID =  TBLCLASS.CLASSID"
        mySql &= vbCrLf & " where"
        mySql &= vbCrLf & String.Format("auctiondate BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "AND STATUS <> '0' AND STATUS <> 'X' AND STATUS <> 'V'"
        mySql &= vbCrLf & "GROUP BY CATEGORY, LOANDATE, AUCTIONDATE, ITEMTYPE, PRINCIPAL"
        mySql &= vbCrLf & "ORDER BY LOANDATE ASC"


        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

    Private Sub AuctionMonthly_CategoryJWLOnly()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsAuctionMonthlyJWL" : rptPath = "Reports\AuctionMonthlyReportJWL.rdlc"
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionStart)


        mySql = "SELECT P.AUCTIONDATE, C.CATEGORY, P.ITEMTYPE, P.PRINCIPAL,TYPE"
        mySql &= vbCrLf & "FROM TBLPAWN P "
        mySql &= vbCrLf & "  INNER JOIN TBLCLASS C"
        mySql &= vbCrLf & "  ON C.CLASSID = P.CATID"
        mySql &= vbCrLf & "WHERE"
        mySql &= vbCrLf & "  (P.STATUS = 'L' OR P.STATUS = 'W' OR P.STATUS = 'S')"
        mySql &= vbCrLf & "  AND TYPE = 'JWL'"
        mySql &= vbCrLf & String.Format("  AND P.AUCTIONDATE BETWEEN '{0}' AND '{1}'", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "GROUP BY P.AUCTIONDATE, C.CATEGORY, P.ITEMTYPE, P.PRINCIPAL,TYPE "
        mySql &= vbCrLf & "ORDER BY P.AUCTIONDATE ASC"


        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub


    Private Sub AuctionMonthly()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsAuction" : rptPath = "Reports\rpt_AuctionMonthly.rdlc"
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionStart)

        mySql = "SELECT * "
        mySql &= vbCrLf & "FROM PAWNING "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("AUCTIONDATE BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "AND STATUS <> 'RENEWED' AND STATUS <> 'REDEEM' AND STATUS <> 'VOID'"

        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub
End Class