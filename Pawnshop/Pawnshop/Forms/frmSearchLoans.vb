Public Class frmSearchLoans

    Private Sub lvClient_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvClient.SelectedIndexChanged

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmNewloan.Show()
        frmNewloan.lblTranstype.Text = "NEW LOAN"
        frmNewloan.btnVoid.Enabled = False
        frmNewloan.txtPawner.ReadOnly = False
        frmNewloan.txtDesc.ReadOnly = False
        frmNewloan.txtAppraisal.ReadOnly = False
        frmNewloan.btnSave.Enabled = True
        frmNewloan.ItemType.Enabled = True
        frmNewloan.Category.Enabled = True
        frmNewloan.Enabled = True
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        frmNewloan.Show()
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
    End Sub
End Class