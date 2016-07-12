Public Class qryAuction
    Private ReportType As String = ""
    Private mySql As String
    Private fillData As String

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If rbJWL.Checked Then ReportType = "JEWELRIES"
        If rbALL.Checked Then ReportType = "ALL"

        Select ReportType
            Case "ALL"
                AuctionMonthly_Category()
            Case "JEWELRIES"
                AuctionMonthly_CategoryJWLOnly()
        End Select
    End Sub

    Private Sub AuctionMonthly_Category()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsAuctionMonthly" : rptPath = "Reports\AuctionMonlyreport.rdlc"
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionStart)

        mySql = "select count(category) as CountCategory,loandate, auctiondate, category, itemtype,principal"
        mySql &= vbCrLf & "from TBLPAWN"
        mySql &= vbCrLf & "inner join tblclass on TBLPAWN.CATID =  TBLCLASS.CLASSID"
        mySql &= vbCrLf & " where"
        mySql &= vbCrLf & String.Format("auctiondate BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "group by category,loandate, auctiondate, itemtype,principal"
        mySql &= vbCrLf & "order by loandate asc"


        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

    Private Sub AuctionMonthly_CategoryJWLOnly()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsAuctionMonthly" : rptPath = "Reports\AuctionMonlyreport.rdlc"
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionStart)

        mySql = "select count(category) as CountCategory,loandate, auctiondate, category, itemtype,principal"
        mySql &= vbCrLf & "from TBLPAWN"
        mySql &= vbCrLf & "inner join tblclass on TBLPAWN.CATID =  TBLCLASS.CLASSID"
        mySql &= vbCrLf & " where"
        mySql &= vbCrLf & "STATUS <> '0' AND STATUS <> 'X' AND STATUS <> 'V'"
        mySql &= vbCrLf & String.Format("AND itemtype = 'JWL' and auctiondate BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
        mySql &= vbCrLf & "group by category,loandate, auctiondate, itemtype,principal"
        mySql &= vbCrLf & "order by loandate asc"


        Dim ds As DataSet = LoadSQL(mySql)
        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)
        addPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

End Class