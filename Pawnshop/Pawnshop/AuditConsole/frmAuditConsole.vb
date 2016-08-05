Public Class frmAuditConsole

    Private Sub btnCashCount_Click(sender As System.Object, e As System.EventArgs) Handles btnCashCount.Click
        frmCashCountV2.isAuditing = True
        frmCashCountV2.Show()
    End Sub
End Class