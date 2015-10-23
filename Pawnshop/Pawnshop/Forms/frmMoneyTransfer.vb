Public Class frmMoneyTransfer

    Dim SelectedClient As Client

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSender.Click
        frmClient.SearchSelect(txtSender.Text, FormName.frmMT)
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

    Friend Sub LoadClient_Sender(ByVal cl As Client)
        txtSender.Text = String.Format("{0} {1} {2}", cl.FirstName, cl.LastName, cl.Suffix)
        txtSenderAddr.Text = String.Format("{0} {1} {2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
    End Sub
End Class