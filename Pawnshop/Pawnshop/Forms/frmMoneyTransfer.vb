Public Class frmMoneyTransfer

    Dim senderClient As Client
    Dim receiverClient As Client

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSender.Click
        frmClient.SearchSelect(txtSender.Text, FormName.frmMTSend)
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

    Private Sub frmMoneyTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        LockFields(True)

        MsgBox("This module is under construction", MsgBoxStyle.Information)
        rbSend.Focus()
    End Sub

    Private Sub ClearField()
        rbSend.Checked = True
        cboType.SelectedIndex = 0

        txtSender.Text = "" : txtSenderAddr.Text = ""
        txtSenderID.Text = "" : txtSenderIDNum.Text = ""

        txtReceiver.Text = "" : txtReceiverAddr.Text = ""
        txtReceiverID.Text = "" : txtReceiverIDNum.Text = ""

        txtRefNum.Text = "" : txtAmount.Text = ""
        txtCharge.Text = "" : txtNetAmount.Text = ""
        txtLocation.Text = ""
    End Sub

    Private Sub LockFields(ByVal st As Boolean)
        txtSenderAddr.ReadOnly = st
        txtSenderID.ReadOnly = st
        txtSenderIDNum.ReadOnly = st

        txtReceiverAddr.ReadOnly = st
        txtReceiverID.ReadOnly = st
        txtReceiverIDNum.ReadOnly = st

        txtCharge.ReadOnly = st
        txtNetAmount.ReadOnly = st
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        Dim mtTrans As New MoneyTransfer
        With mtTrans
            .TransactionType = IIf(rbReceive.Checked, 1, 0)
            .ServiceType = cboType.Text
            .TransactionDate = CurrentDate
            .Sender = senderClient
            .Receiver = receiverClient
            .ReferenceNumber = txtRefNum.Text
            .TransferAmount = txtAmount.Text
            .ServiceCharge = txtCharge.Text
            .NetAmount = txtNetAmount.Text
            .Location = txtLocation.Text

            .Save()
        End With
    End Sub

    Friend Sub LoadSenderInfo(ByVal cl As Client)
        txtSender.Text = String.Format("{0} {1}", cl.FirstName, cl.LastName)
        txtSenderAddr.Text = String.Format("{0} {1} {2} {3}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity, cl.AddressProvince)
        txtSenderID.Text = cl.IDType
        txtSenderIDNum.Text = cl.IDNumber
    End Sub

    Friend Sub LoadReceiverInfo(ByVal cl As Client)
        txtReceiver.Text = String.Format("{0} {1}", cl.FirstName, cl.LastName)
        txtReceiverAddr.Text = String.Format("{0} {1} {2} {3}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity, cl.AddressProvince)
        txtReceiverID.Text = cl.IDType
        txtReceiverIDNum.Text = cl.IDNumber
    End Sub

    Private Sub btnSearchReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchReceiver.Click
        frmClient.SearchSelect(txtReceiver.Text, FormName.frmMTReceive)
        frmClient.Show()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            txtLocation.Focus()
        End If
    End Sub

    Private Sub txtRefNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefNum.KeyPress
        If isEnter(e) Then
            txtAmount.Focus()
        End If
    End Sub
End Class