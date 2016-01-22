Imports Microsoft.Reporting.WinForms

Public Class dev_ORview

    Private Sub dev_ORview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.rv_display.RefreshReport()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If Not IsNumeric(txtPAWNID.Text) Then Exit Sub

        Dim mySql As String
        mySql = "SELECT * FROM PRINT_PAWNING WHERE PAWNID = " & txtPAWNID.Text
        Dim dsName As String = "dsOR"
        Dim ds As DataSet = LoadSQL(mySql, dsName)
        Dim PawnItem As New PawnTicket, paymentStr As String
        Dim rptPath As String = "Reports\layout05.rdlc"
        Dim addParameters As New Dictionary(Of String, String)

        PawnItem.LoadTicket(txtPAWNID.Text)

        paymentStr = _
        String.Format("PT# {0:000000} with a payment amount of Php {1:#,##0.00}", PawnItem.PawnTicket, PawnItem.RenewDue)
        addParameters.Add("secPayments", paymentStr)
        addParameters.Add("secDescription", PawnItem.Description)
        addParameters.Add("dblTotalDue", IIf(PawnItem.RenewDue = 0, PawnItem.RedeemDue, PawnItem.RenewDue))
        addParameters.Add("dblInterest", PawnItem.Interest)
        addParameters.Add("dblServiceCharge", PawnItem.ServiceCharge)
        addParameters.Add("dblPenalty", PawnItem.Penalty)
        addParameters.Add("secORnumber", String.Format("OR# {0:00000}", PawnItem.OfficialReceiptNumber))
        addParameters.Add("dblPrincipal", 0)

        frmReport.ReportInit(mySql, dsName, rptPath, addParameters, False)
        frmReport.Show()

        'With rv_display
        '    .LocalReport.ReportPath = "Reports\layout05.rdlc"
        '    .LocalReport.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        '    PawnItem.LoadTicket(txtPAWNID.Text)

        '    paymentStr = _
        '    String.Format("PT# {0:000000} with a payment amount of Php {1:#,##0.00}", PawnItem.PawnTicket, PawnItem.RenewDue)
        '    addParameters.Add("txtPayment", paymentStr)
        '    addParameters.Add("txtDescription", PawnItem.Description)
        '    addParameters.Add("dblTotalDue", IIf(PawnItem.RenewDue = 0, PawnItem.RedeemDue, PawnItem.RenewDue))
        '    addParameters.Add("dblInterest", PawnItem.Interest)
        '    addParameters.Add("dblServiceCharge", PawnItem.ServiceCharge)
        '    addParameters.Add("dblPenalty", PawnItem.Penalty)
        '    addParameters.Add("txtOR", PawnItem.OfficialReceiptNumber)
        '    addParameters.Add("dblPrincipal", 0)

        '    If Not addParameters Is Nothing Then
        '        For Each nPara In addParameters
        '            Dim tmpPara As New ReportParameter
        '            tmpPara.Name = nPara.Key
        '            tmpPara.Values.Add(nPara.Value)
        '            .LocalReport.SetParameters(New ReportParameter() {tmpPara})
        '        Next
        '    End If

        '    .RefreshReport()
        'End With
    End Sub
End Class