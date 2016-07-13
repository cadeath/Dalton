Public Class diagMoneyTransferBracketing
    Friend st As Date, en As Date
    Dim filldata As String = "dsMoneyTransferBracketing"
    Dim mySql As String, reportType As String = ""
    Dim reportType2 As String = ""

    Private Sub rbGPRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGPRS.Click
            cboGrprs.Enabled = True
    End Sub
    Private Sub rbPeraPadala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeraPadala.Click, rbCebuana.Click, rbPeraPadalapmftc.Click, rbWestern.Click, rbWesternIntl.Click
        cboGrprs.Enabled = False
    End Sub
    Private Sub PeraPadala()

        If rbCebuana.Checked Then
            reportType = "Cebuana Llhuiller"

        ElseIf rbPeraPadalapmftc.Checked Then
            reportType = "Pera Padala - PMFTC"

        ElseIf rbPeraPadala.Checked Then
            reportType = "Pera Padala"

        ElseIf rbWestern.Checked Then
            reportType = "Western Union - Local"

        ElseIf rbWesternIntl.Checked Then
            reportType = "Western Union - Intl"

        End If

        If cboGrprs.Text = "GPRS to Smart Money" Then
            reportType2 = "GPRS - GPRS to Smart Money"

        ElseIf cboGrprs.Text = "GPRS to BANK (UCPB/PNB)" Then
            reportType2 = "GPRS - GPRS to BANK (UCPB/PNB)"

        ElseIf cboGrprs.Text = "GPRS to BANK (BDO/Chinabank)" Then
            reportType2 = "GPRS - GPRS to BANK (BDO/Chinabank)"

        ElseIf cboGrprs.Text = "GPRS to BANK (DBP)" Then
            reportType2 = "GPRS - GPRS to BANK (DBP)"

        ElseIf cboGrprs.Text = "GPRS to BANK (MetroBank)" Then
            reportType2 = "GPRS - GPRS to BANK (MetroBank)"

        ElseIf cboGrprs.Text = "GPRS to BANK (Maybank/LandBank)" Then
            reportType2 = "GPRS - GPRS to BANK (Maybank/LandBank)"

        ElseIf cboGrprs.Text = "iREMIT to GPRS" Then
            reportType2 = "GPRS - iREMIT to GPRS"

        ElseIf cboGrprs.Text = "NYBP/Transfast to GPRS" Then
            reportType2 = "GPRS - NYBP/Transfast to GPRS"

        ElseIf cboGrprs.Text = "GPRS to Moneygram" Then
            reportType2 = "GPRS - GPRS to Moneygram"

        ElseIf cboGrprs.Text = "GPRS to GPRS" Then
            reportType2 = "GPRS - GPRS to GPRS"

        End If

        If rbGPRS.Checked Then
            mySql = "SELECT ID, SERVICETYPE, MONEYTRANS, AMOUNT, BRACKET, TRANSDATE "
            mySql &= "FROM TBLMONEYTRANSFER "
            mySql &= "WHERE SERVICETYPE = '" & reportType2 & "' AND "
            mySql &= String.Format(" TRANSDATE BETWEEN '{0}' AND '{1}' ", st.ToShortDateString, en.ToShortDateString)
            mySql &= "ORDER BY BRACKET ASC"
        Else
             mySql = "SELECT ID, SERVICETYPE, MONEYTRANS, AMOUNT, BRACKET, TRANSDATE "
            mySql &= "FROM TBLMONEYTRANSFER "
            mySql &= "WHERE SERVICETYPE = '" & reportType & "' AND "
            mySql &= String.Format(" TRANSDATE BETWEEN '{0}' AND '{1}'", st.ToShortDateString, en.ToShortDateString)
            mySql &= "ORDER BY BRACKET ASC"
        End If

        Dim addParameters As New Dictionary(Of String, String)

        addParameters.Add("txtMonthstart", "DATE: " & st.ToShortDateString)
        addParameters.Add("txtMonthend", "DATE: " & en.ToShortDateString)
        addParameters.Add("branchName", branchName)

        frmReport.ReportInit(mySql, filldata, "Reports\rpt_MoneyTransferBracketing.rdlc", addParameters)
        frmReport.Show()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        PeraPadala()
    End Sub
End Class