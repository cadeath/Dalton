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

        mySql = "SELECT COUNT(ITM.ITEMCLASS) AS COUNTCATEGORY, P.LOANDATE, P.AUCTIONDATE, ITM.ITEMCLASS, "
        mySql &= "CLASS.ITEMCATEGORY, P.PRINCIPAL FROM OPT P "
        mySql &= "INNER JOIN OPI ITM ON ITM.PAWNITEMID = P.PAWNITEMID "
        mySql &= "INNER JOIN TBLITEM CLASS "
        mySql &= " ON CLASS.ITEMID = ITM.ITEMID "
        mySql &= String.Format("WHERE P.AUCTIONDATE BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= " AND P.STATUS <> '0' AND P.STATUS <> 'X' AND P.STATUS <> 'V' "
        mySql &= "GROUP BY ITM.ITEMCLASS, P.LOANDATE, P.AUCTIONDATE, CLASS.ITEMCATEGORY, P.PRINCIPAL "


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

        mySql = "SELECT P.LOANDATE, P.AUCTIONDATE, ITM.ITEMCLASS, CLASS.ITEMCATEGORY, 
        mySql &= "P.PRINCIPAL FROM OPT P INNER JOIN OPI ITM ON ITM.PAWNITEMID = P.PAWNITEMID "
        mySql &= "INNER JOIN TBLITEM CLASS  ON CLASS.ITEMID = ITM.ITEMID "
        mySql &= "WHERE CLASS.ITEMCATEGORY = 'JEWELRY' AND P.STATUS <> '0' AND P.STATUS <> 'X' AND P.STATUS <> 'V' "
        mySql &= String.Format("AND P.AUCTIONDATE BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= "GROUP BY ITM.ITEMCLASS, P.LOANDATE, P.AUCTIONDATE, CLASS.ITEMCATEGORY, P.PRINCIPAL "

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
        mySql &= vbCrLf & "FROM PAWN_LIST "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("AUCTIONDATE BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "AND STATUS <> '0' AND STATUS <> 'X' AND STATUS <> 'V'"

        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub
End Class