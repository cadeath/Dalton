Public Class qryPullOut_List

    Enum DailyReport As Integer
        Outstanding = 0
        Pullout = 1
        AuditReport = 2
    End Enum
    Friend FormType As DailyReport = DailyReport.Outstanding
    Private mySql As String, fillData As String

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        Select Case FormType
            Case DailyReport.Outstanding
                Outstanding_Loans()
            Case DailyReport.Pullout
                Item_PullOut()
            Case DailyReport.AuditReport
                Audit_PrincipalMin()
        End Select

        'Item_PullOut()
    End Sub
    Private Sub Audit_PrincipalMin()
        Dim MINIMUM_PRINCIPAL As Double = 5000
        AuditReports.Min_Principal(MINIMUM_PRINCIPAL, monCalendar.SelectionStart.ToShortDateString, cboClass.Text)
    End Sub

    Private Sub qryPullOut_List_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mySql = "SELECT DISTINCT TYPE FROM tblClass"
        fillData = "tblClass"

        Dim ds As DataSet = LoadSQL(mySql)

        cboClass.Items.Clear()
        cboClass.Items.Add("ALL")
        For Each dr As DataRow In ds.Tables(0).Rows
            cboClass.Items.Add(dr.Item("Type"))
        Next
        cboClass.SelectedIndex = 0
    End Sub

    Private Sub Item_PullOut()
        Dim stDay = monCalendar.SelectionStart.ToShortDateString

        Dim dsName As String = "dsPullOut", mySql As String

        If Not POSuser.canItemPulloutReport Then
            mySql = "SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, PULLOUT, APPRAISER FROM PAWNING WHERE STATUS = 'WITHDRAW' AND "
            mySql &= String.Format("PULLOUT = '{0}'", monCalendar.SelectionStart.ToShortDateString)
        Else
            mySql = "SELECT * FROM PAWNING WHERE STATUS = 'WITHDRAW' AND "
            mySql &= String.Format("PULLOUT = '{0}'", monCalendar.SelectionStart.ToShortDateString)
        End If
       
        If cboClass.Text <> "ALL" Then
            mySql &= String.Format(" AND ITEMTYPE = '{0}'", cboClass.Text)
        End If
        Console.WriteLine(mySql)

        Dim addParameters As New Dictionary(Of String, String)
        
        addParameters.Add("txtMonthOf", "DATE: " & stDay)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_ItemPullout.rdlc", addParameters)
        frmReport.Show()
    End Sub
    Private Sub Outstanding_Loans()
        Dim dsName As String = "dsOutstanding"

        If Not POSuser.canOutstandingReport Then
            mySql = "SELECT * "
            mySql &= "FROM "
            mySql &= "( "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'NEW') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'RENEW') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'RENEWED') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'REDEEM') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'SEGRE') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND (WITHDRAWDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' OR WITHDRAWDATE IS NULL) "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, INTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMTYPE, CATEGORY, GRAMS, KARAT, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'WITHDRAW') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND WITHDRAWDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= ") "
            If cboClass.Text <> "ALL" Then
                mySql &= " WHERE ITEMTYPE = '" & cboClass.Text & "'"
            End If
            mySql &= "ORDER BY PAWNTICKET ASC"
        Else
            mySql = "SELECT * "
            mySql &= "FROM "
            mySql &= "( "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'NEW') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'RENEW') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'RENEWED') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'REDEEM') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'SEGRE') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND (WITHDRAWDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' OR WITHDRAWDATE IS NULL) "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'WITHDRAW') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND WITHDRAWDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= ") "
            If cboClass.Text <> "ALL" Then
                mySql &= " WHERE ITEMTYPE = '" & cboClass.Text & "'"
            End If
            mySql &= " ORDER BY PAWNTICKET ASC"
        End If
        Console.WriteLine(mySql)


        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtMonthOf", "DATE: " & monCalendar.SelectionStart.ToString("MMMM dd yyyy").ToUpper)
        addParameters.Add("branchName", branchName)
        addParameters.Add("ReportName", "OUTSTANDING REPORTS")

        frmReport.ReportInit(mySql, dsName, "Reports\rpt_Outstanding.rdlc", addParameters)
        frmReport.Show()
    End Sub
End Class