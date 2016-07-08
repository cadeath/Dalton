Public Class diagMoneyTransferBracketing
    Friend st As Date, en As Date
    Dim filldata As String = "dsMoneyTransferBracketing"
    Dim mySql As String, reportType As String = "", reportcharge As String = ""
    Dim reportType2 As String = "", reportCharge2 As String = ""

    Private Sub rbGPRS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbGPRS.Click
            cboGrprs.Enabled = True
    End Sub
    Private Sub rbPeraPadala_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPeraPadala.Click, rbCebuana.Click, rbPeraPadalapmftc.Click, rbWestern.Click, rbWesternIntl.Click
        cboGrprs.Enabled = False
    End Sub
    Private Sub PeraPadala()

        If rbCebuana.Checked Then
            reportType = "Cebuana Llhuiller"
            reportcharge = "cebuana"

        ElseIf rbPeraPadalapmftc.Checked Then
            reportType = "Pera Padala - PMFTC"
            reportcharge = "perapadalapmftc"

        ElseIf rbPeraPadala.Checked Then
            reportType = "Pera Padala"
            reportcharge = "perapadala"

        ElseIf rbWestern.Checked Then
            reportType = "Western Union - Local"
            reportcharge = "western"

        ElseIf rbWesternIntl.Checked Then
            reportType = "Western Union - Intl"
            reportcharge = "western - intl"

        End If

        If cboGrprs.Text = "GPRS to Smart Money" Then
            reportType2 = "GPRS - GPRS to Smart Money"
            reportCharge2 = "gprs to smartmoney"

        ElseIf cboGrprs.Text = "GPRS to BANK (UCPB/PNB)" Then
            reportType2 = "GPRS - GPRS to BANK (UCPB/PNB)"
            reportCharge2 = "gprs to bank-ucpbpnb"

        ElseIf cboGrprs.Text = "GPRS to BANK (BDO/Chinabank)" Then
            reportType2 = "GPRS - GPRS to BANK (BDO/Chinabank)"
            reportCharge2 = "gprs to bank-bdochina"

        ElseIf cboGrprs.Text = "GPRS to BANK (DBP)" Then
            reportType2 = "GPRS - GPRS to BANK (DBP)"
            reportCharge2 = "gprs to dbp"

        ElseIf cboGrprs.Text = "GPRS to BANK (MetroBank)" Then
            reportType2 = "GPRS - GPRS to BANK (MetroBank)"
            reportCharge2 = "gprs to metrobank"

        ElseIf cboGrprs.Text = "GPRS to BANK (Maybank/LandBank)" Then
            reportType2 = "GPRS - GPRS to BANK (Maybank/LandBank)"
            reportCharge2 = "gprs to maylandbank"

        ElseIf cboGrprs.Text = "iREMIT to GPRS" Then
            reportType2 = "GPRS - iREMIT to GPRS"
            reportCharge2 = "iremit to gprs"

        ElseIf cboGrprs.Text = "NYBP/Transfast to GPRS" Then
            reportType2 = "GPRS - NYBP/Transfast to GPRS"
            reportCharge2 = "nybptransfast to gprs"

        ElseIf cboGrprs.Text = "GPRS to Moneygram" Then
            reportType2 = "GPRS - GPRS to Moneygram"
            reportCharge2 = "gprs to moneygram"

        ElseIf cboGrprs.Text = "GPRS to GPRS" Then
            reportType2 = "GPRS - GPRS to GPRS"
            reportCharge2 = "gprs to gprs"

        End If

        If rbGPRS.Checked Then
            mySql = "SELECT MT.ID, MT.SERVICETYPE, MT.MONEYTRANS, "
            mySql &= "MT.AMOUNT AS TRANSAMOUNT, ( SELECT C.AMOUNT AS BRACKET "
            mySql &= "FROM TBLCHARGE C WHERE MT.AMOUNT <= C.AMOUNT AND "
            mySql &= " C.TYPE = '" & reportCharge2 & "'  ORDER BY C.AMOUNT ASC ROWS 1), MT.TRANSDATE "
            mySql &= ",(SELECT C.CHARGE FROM TBLCHARGE C "
            mySql &= " WHERE MT.AMOUNT <= C.AMOUNT AND C.TYPE = '" & reportCharge2 & "' "
            mySql &= " ORDER BY C.AMOUNT ASC ROWS 1)"
            mySql &= " FROM TBLMONEYTRANSFER MT "
            mySql &= " WHERE MT.SERVICETYPE = '" & reportType2 & "' AND "
            mySql &= String.Format(" MT.TRANSDATE BETWEEN '{0}' AND '{1}'", st.ToShortDateString, en.ToShortDateString)
        Else
            mySql = "SELECT MT.ID, MT.SERVICETYPE, MT.MONEYTRANS, "
            mySql &= "MT.AMOUNT AS TRANSAMOUNT, ( SELECT C.AMOUNT AS BRACKET "
            mySql &= "FROM TBLCHARGE C WHERE MT.AMOUNT <= C.AMOUNT AND "
            mySql &= " C.TYPE = '" & reportcharge & "'  ORDER BY C.AMOUNT ASC ROWS 1), MT.TRANSDATE "
            mySql &= ",(SELECT C.CHARGE FROM TBLCHARGE C "
            mySql &= " WHERE MT.AMOUNT <= C.AMOUNT AND C.TYPE = '" & reportcharge & "' "
            mySql &= " ORDER BY C.AMOUNT ASC ROWS 1)"
            mySql &= " FROM TBLMONEYTRANSFER MT "
            mySql &= " WHERE MT.SERVICETYPE = '" & reportType & "' AND "
            mySql &= String.Format(" MT.TRANSDATE BETWEEN '{0}' AND '{1}'", st.ToShortDateString, en.ToShortDateString)

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