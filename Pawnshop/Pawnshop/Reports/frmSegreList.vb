Public Class frmSegreList

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Dim dsName As String = "dsSegre", mySql As String
        If Not POSuser.canSegregatedReport Then
            mySql = "SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER FROM PAWN_LIST WHERE Status = 'S' AND "
            mySql &= String.Format("EXPIRYDATE <= '{0}'", monCalendar.SelectionStart.ToShortDateString)

        Else
            mySql = "SELECT * FROM PAWN_LIST WHERE Status = 'S' AND "
            mySql &= String.Format("EXPIRYDATE <= '{0}'", monCalendar.SelectionStart.ToShortDateString)
        End If
        Dim ds As DataSet = LoadSQL(mySql)

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "AS OF " & monCalendar.SelectionStart.ToString("MMMM dd, yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Segregated.rdlc", rptPara)
        frmReport.Show()
    End Sub
End Class