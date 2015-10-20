Public Class frmSearchLoans

    Private Sub lvClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvClient.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmNewloan.Show()
        frmNewloan.Text = "New Loan"
        frmNewloan.lblTranstype.Text = "NEW LOAN"
        frmNewloan.btnVoid.Enabled = False
        frmNewloan.txtPawner.ReadOnly = False
        frmNewloan.txtDesc.ReadOnly = False
        frmNewloan.txtAppraisal.ReadOnly = False
        frmNewloan.btnSave.Enabled = True
        frmNewloan.ItemType.Enabled = True
        frmNewloan.Category.Enabled = True
        frmNewloan.Enabled = True
        frmNewloan.lblNticket.Visible = False
        frmNewloan.txtNticket.Visible = False
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        frmNewloan.Show()
        frmNewloan.Text = "Loan Redemption"
        frmNewloan.lblTranstype.Text = "LOAN REDEMPTION"
        'frmNewloan.grpPawner.Enabled = False
        'frmNewloan.grpItem.Enabled = False
        'frmNewloan.grpTicket.Enabled = False
        frmNewloan.grpReceipt.Visible = True
        frmNewloan.btnSave.Text = "&Redeem"
        frmNewloan.btnSave.Enabled = True
        frmNewloan.txtRedeemDue.Visible = True
        frmNewloan.lblRedeemDue.Visible = True
        frmNewloan.btnSearch.Visible = False
        frmNewloan.txtTotal.Visible = False
        frmNewloan.lblNet.Visible = False
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        frmNewloan.Show()
        frmNewloan.Text = "Loan Renewal"
        frmNewloan.lblTranstype.Text = "LOAN RENEWAL"
        'frmNewloan.grpPawner.Enabled = False
        'frmNewloan.grpItem.Enabled = False
        'frmNewloan.grpTicket.Enabled = False
        frmNewloan.grpReceipt.Visible = True
        frmNewloan.btnSave.Text = "&Renew"
        frmNewloan.btnSave.Enabled = True
        frmNewloan.txtRenewDue.Visible = True
        frmNewloan.lblRenewDue.Visible = True
        frmNewloan.btnSearch.Visible = False
        frmNewloan.txtTotal.Visible = False
        frmNewloan.lblNet.Visible = False
        frmNewloan.btnLess.Visible = True
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        frmNewloan.Show()
        frmNewloan.Text = "Browse Loan"
        frmNewloan.lblTranstype.Text = ""
        'frmNewloan.grpPawner.Enabled = False
        'frmNewloan.grpItem.Enabled = False
        'frmNewloan.grpTicket.Enabled = False
        frmNewloan.grpReceipt.Visible = True
        frmNewloan.btnSave.Text = "Save"
        frmNewloan.btnSave.Enabled = False
        frmNewloan.btnVoid.Enabled = True
        frmNewloan.txtRedeemDue.Visible = True
        frmNewloan.lblRedeemDue.Visible = True
        frmNewloan.btnSearch.Visible = False
        frmNewloan.txtTotal.Visible = False
        frmNewloan.lblNet.Visible = False
    End Sub
End Class