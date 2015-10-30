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

    Private Sub frmMoneyTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()

        MsgBox("This module is under construction", MsgBoxStyle.Information)
    End Sub

    Private Sub ClearField()
        rbSend.Checked = True
        cboType.SelectedIndex = 0

        txtSender.Text = "" : txtSenderAddr.Text = ""
        txtSenderID.Text = "" : txtSenderIDNum.Text = ""

        txtReceiver.Text = "" : txtReceiverAddr.Text = ""
        txtReceiverID.Text = "" : txtReceiverIDNum.Text = ""

        txtRefNum.Text = "" : txtAmount.Text = ""
        txtLocation.Text = ""
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim mtTrans As New MoneyTransfer
        With mtTrans
            .TransactionType = IIf(rbReceive.Checked, 1, 0)
            .ServiceType = cboType.Text
            
        End With
    End Sub

    Friend Sub LoadSenderInfo()

    End Sub

    Friend Sub LoadReceiverInfo()

    End Sub
End Class