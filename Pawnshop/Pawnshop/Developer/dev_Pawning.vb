Public Class dev_Pawning

    Private Sub btnCompute_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCompute.Click
        If txtMatu.Text = "" Then Exit Sub

        Dim daltonPawning As PawningDalton
        daltonPawning = New PawningDalton(CDbl(txtPrincipal.Text), cboType.Text, current.SelectionStart.Date, txtMatu.Text, rbDPJ.Checked, "")

        'txtPrincipal.Text = daltonPawning.Principal.ToString("Php #,##0.00")
        txtNetAmount.Text = daltonPawning.NetAmount.ToString("Php #,##0.00")
        txtDaysOver.Text = daltonPawning.DaysOverDue
        txtInt.Text = daltonPawning.Interest.ToString("#,##0.00")
        txtPenalty.Text = daltonPawning.Penalty.ToString("#,##0.00")
        txtSC.Text = daltonPawning.ServiceCharge.ToString("#,##0.00")
        txtAdvInt.Text = daltonPawning.AdvanceInterest.ToString("#,##0.00")
        txtRenewDue.Text = daltonPawning.RenewDue.ToString("#,##0.00")
        txtRedeemDue.Text = daltonPawning.RedeemDue.ToString("#,##0.00")
    End Sub

    Private Sub dev_Pawning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cboType.SelectedIndex = 0
    End Sub

    Private Sub loanDate_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles loanDate.MouseDown
        txtMatu.Text = loanDate.SelectionStart.Date.AddDays(29)
        Select Case cboType.Text
            Case "CEL"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = loanDate.SelectionStart.Date.AddDays(62).ToShortDateString
            Case Else
                txtExpiry.Text = loanDate.SelectionStart.Date.AddDays(119).ToShortDateString
                txtAuction.Text = loanDate.SelectionStart.Date.AddDays(152).ToShortDateString
        End Select
    End Sub

    Private Sub txtMatu_DoubleClick(sender As Object, e As System.EventArgs) Handles txtMatu.DoubleClick
        dev_Pawning2.Show()
    End Sub

End Class