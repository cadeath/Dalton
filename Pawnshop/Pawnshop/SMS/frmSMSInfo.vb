Public Class frmSMSInfo

    Private _sqlPrint As String = ""

    Private Sub txtPT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not IsNumeric(txtPT.Text) Then
            MsgBox("Please write down numeric values only", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim pawnTicket As Integer = txtPT.Text
        Dim mySql As String = "SELECT"
        mySql &= vbCrLf & "  SMSDATE, PAWNTICKET, C.FIRSTNAME, C.LASTNAME, SMS_MSG, USERNAME"
        mySql &= vbCrLf & "FROM"
        mySql &= vbCrLf & "  SMS"
        mySql &= vbCrLf & "INNER JOIN TBLCLIENT C"
        mySql &= vbCrLf & "  ON C.CLIENTID = SMS.CLIENTID"
        mySql &= vbCrLf & "INNER JOIN TBL_GAMIT USR"
        mySql &= vbCrLf & "  ON USR.USERID = SMS.SENT_BY"
        mySql &= vbCrLf & String.Format(" WHERE PAWNTICKET = {0}", pawnTicket)

        Console.WriteLine(mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox(String.Format("PT#{0} is either not expired or not yet texted.", pawnTicket), MsgBoxStyle.Information)
            Exit Sub
        End If

        _sqlPrint = mySql
        Dim ptDisplay As New PawnTicket2
        ptDisplay.Load_PawnTicket(pawnTicket)
        With ds.Tables(0).Rows(0)
            lblPawner.Text = String.Format("{0} {1}", .Item("FIRSTNAME"), .Item("LASTNAME"))
            lblLoan.Text = ptDisplay.LoanDate.ToString("M/d/yyyy")
            lblMatu.Text = ptDisplay.MaturityDate.ToString("M/d/yyyy")
            lblExpiry.Text = ptDisplay.ExpiryDate.ToString("M/d/yyyy")
            lblAuction.Text = ptDisplay.AuctionDate.ToString("M/d/yyyy")
            lblSMS.Text = .Item("SMS_MSG")
            lblSMSdate.Text = DateTime.Parse(.Item("SMSDATE")).ToString("MMMM d, yyyy")
        End With
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If _sqlPrint = "" Then Exit Sub

        frmReport.ReportInit(_sqlPrint, "dsSingle", "Reports\rpt_ExpirySingle.rdlc", , False)
        frmReport.Show()
    End Sub

    Private Sub frmSMSInfo_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPT.Text = ""
        lblPawner.Text = ""
        lblLoan.Text = ""
        lblMatu.Text = ""
        lblExpiry.Text = ""
        lblAuction.Text = ""
        lblSMS.Text = ""
        lblSMSdate.Text = ""
    End Sub
End Class