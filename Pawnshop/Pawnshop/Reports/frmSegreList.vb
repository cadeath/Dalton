Public Class frmSegreList
    Enum SegreReport As Integer
        Daily = 0
        Monthly = 1
    End Enum
    Friend FormType As SegreReport = SegreReport.Daily

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Select Case FormType
            Case SegreReport.Daily
                DailySegre()
            Case SegreReport.Monthly
                MonthlySegre()
        End Select

    End Sub

    Private Sub DailySegre()
        Dim dsName As String = "dsSegre", mySql As String
        If Not POSuser.canSegregatedReport Then
            mySql = "SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER FROM PAWN_LIST WHERE  (STATUS = 'S' OR STATUS = 'W') AND "
            mySql &= String.Format("AUCTIONDATE = '{0}'", monCalendar.SelectionStart.AddDays(-1).ToShortDateString)

        Else
            mySql = "SELECT * FROM PAWN_LIST WHERE (STATUS = 'S' OR STATUS = 'W') AND "
            mySql &= String.Format("AUCTIONDATE = '{0}'", monCalendar.SelectionStart.AddDays(-1).ToShortDateString)
        End If
        Dim ds As DataSet = LoadSQL(mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "AS OF " & monCalendar.SelectionStart.ToString("MMMM dd, yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Segregated.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub MonthlySegre()
        Dim st As Date = GetFirstDate(monCalendar.SelectionStart)
        Dim en As Date = GetLastDate(monCalendar.SelectionEnd)
        Dim dsName As String = "dsSegre", mySql As String
        If Not POSuser.canSegregatedReport Then
            mySql = "SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER FROM PAWN_LIST WHERE  (STATUS = 'S' OR STATUS = 'W') AND "
            mySql &= String.Format("AUCTIONDATE BETWEEN '{0}' AND '{1}'", st.AddDays(-1).ToShortDateString, en.AddDays(-1).ToShortDateString)

        Else
            mySql = "SELECT * FROM PAWN_LIST WHERE (STATUS = 'S' OR STATUS = 'W') AND "
            mySql &= String.Format("AUCTIONDATE BETWEEN '{0}' AND '{1}'", st.AddDays(-1).ToShortDateString, en.AddDays(-1).ToShortDateString)
        End If
        Dim ds As DataSet = LoadSQL(mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " + st.ToString("MMMM yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Segregated.rdlc", rptPara)
        frmReport.Show()
    End Sub

End Class