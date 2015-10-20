Public Class frmLoanlist
    Public Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmNewloan.Show()
        frmNewloan.txtPawner.ReadOnly = True
        frmNewloan.txtDesc.ReadOnly = True
        frmNewloan.cboItemtype.Enabled = False
        frmNewloan.cboCategory.Enabled = False
        frmNewloan.txtGrams.ReadOnly = True
        frmNewloan.cboKarat.Enabled = False
        frmNewloan.btnVoid.Enabled = True
        frmNewloan.btnSave.Enabled = False
        frmNewloan.txtAppraisal.ReadOnly = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub
End Class