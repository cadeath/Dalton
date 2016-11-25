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
        mySql = "SELECT DISTINCT ITEMCATEGORY FROM tblITEM"
        fillData = "tblITEM"

        Dim ds As DataSet = LoadSQL(mySql)

        cboClass.Items.Clear()
        cboClass.Items.Add("ALL")
        For Each dr As DataRow In ds.Tables(0).Rows
            cboClass.Items.Add(dr.Item("ITEMCATEGORY"))
        Next
        cboClass.SelectedIndex = 0

        Select Case FormType
            Case DailyReport.Outstanding
                Me.Text = "Oustanding"
            Case DailyReport.Pullout
                Me.Text = "Item PullOut"
            Case DailyReport.AuditReport
                Me.Text = "Audit Report"
        End Select
    End Sub

    Private Sub Item_PullOut()
        Dim stDay = monCalendar.SelectionStart.ToShortDateString

        Dim dsName As String = "dsPullOut", mySql As String

        If Not POSuser.canItemPulloutReport Then
            mySql = "SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER FROM PAWN_LIST WHERE STATUS = 'W' AND "
            mySql &= String.Format("WITHDRAWDATE = '{0}'", monCalendar.SelectionStart.ToShortDateString)
        Else
            mySql = "SELECT * FROM PAWN_LIST WHERE STATUS = 'W' AND "
            mySql &= String.Format("WITHDRAWDATE = '{0}'", monCalendar.SelectionStart.ToShortDateString)
        End If
       
        If cboClass.Text <> "ALL" Then
            mySql &= String.Format(" AND ITEMCATEGORY = '{0}'", cboClass.Text)
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
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'L') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'R') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = '0') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'X') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'S') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "'"

            mySql &= "  UNION "
            mySql &= "  SELECT PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, AUCTIONDATE, CLIENT, FULLADDRESS, DESCRIPTION, ORNUM, ORDATE, OLDTICKET, "
            mySql &= "NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, DELAYINTEREST, ADVINT, SERVICECHARGE, PENALTY, "
            mySql &= "ITEMCLASS, ITEMCATEGORY, STATUS, WITHDRAWDATE, APPRAISER "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'W') "
            mySql &= "  AND WITHDRAWDATE >= '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= ") "
            If cboClass.Text <> "ALL" Then
                mySql &= " WHERE ITEMCATEGORY = '" & cboClass.Text & "'"
            End If
            mySql &= "ORDER BY PAWNTICKET ASC"
        Else
            mySql = "SELECT * "
            mySql &= "FROM "
            mySql &= "( "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'L') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'R') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = '0') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'X') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'S') "
            mySql &= "  AND LOANDATE <= '" & monCalendar.SelectionStart.ToShortDateString & "'"
            mySql &= "  UNION "
            mySql &= "  SELECT * "
            mySql &= "  FROM PAWN_LIST "
            mySql &= "  WHERE (Status = 'W') "
            mySql &= "   AND WITHDRAWDATE >= '" & monCalendar.SelectionStart.ToShortDateString & "' "
            mySql &= ") "
            If cboClass.Text <> "ALL" Then
                mySql &= " WHERE ITEMCATEGORY = '" & cboClass.Text & "'"
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