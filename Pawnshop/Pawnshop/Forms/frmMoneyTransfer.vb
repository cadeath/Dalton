Public Class frmMoneyTransfer

    Dim SelectedClient As Client

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSender.Click
        frmClient.SearchSelect(txtSender.Text, Me)
        frmClient.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSender.KeyPress
        If isEnter(e) Then
            btnSearchSender.PerformClick()
        End If
    End Sub

    Private Sub txtSender_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSender.TextChanged

    End Sub
End Class