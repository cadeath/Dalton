Public Class diagMoneyTransferBracketing
    Friend st As Date, en As Date
    Dim filldata As String = "dsMoneyTransferBracketing"

    Private Sub PeraPadala()

        Dim mySql As String, reportType As String = "", reportcharge As String = ""
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
        ElseIf rbGPRS.Checked Then
            reportType = "GPRS"
            reportcharge = "gprs"
        End If

        mySql = "SELECT MT.TRANSID,MT.SERVICETYPE, MT.MONEYTRANS, "
        mySql &= "MT.AMOUNT AS TRANSAMOUNT, ( SELECT C.AMOUNT AS BRACKET "
        mySql &= "FROM TBLCHARGE C WHERE MT.AMOUNT <= C.AMOUNT AND "
        If rbGPRS.Checked Then mySql &= "C.TYPE like '%" & reportcharge & "%' ROWS 1), MT.TRANSDATE "
        mySql &= "C.TYPE = '" & reportcharge & "' ROWS 1), MT.TRANSDATE "
        'mySql &= ",(SELECT C.CHARGE FROM TBLCHARGE C"
        'mySql &= "WHERE MT.AMOUNT <= C.AMOUNT AND C.TYPE = '" & reportcharge & "'"
        'mySql &= "ROWS 1)"
        mySql &= " FROM TBLMONEYTRANSFER MT "
        If rbGPRS.Checked Then mySql &= " WHERE MT.SERVICETYPE like '%" & reportType & "%' AND "
        mySql &= " WHERE MT.SERVICETYPE = '" & reportType & "' AND "
        mySql &= String.Format(" MT.TRANSDATE BETWEEN '{0}' AND '{1}'", st.ToShortDateString, en.ToShortDateString)

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