'Form Designed by Eskie Maquilang, C)PEH
Public Class frmMoneyTransfer

    Private Sub frmMoneyTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInit()
        cboType.Focus()
    End Sub

    Private Sub FormInit()
        ClearField()

        'Transaction Type Initialization
        cboType.DropDownStyle = ComboBoxStyle.DropDownList
        cboType.DroppedDown = True
        '001-load Money Transfer Services
        '--This segment loads all money transfer
        '--services.
        cboType.Items.Add("Pera Padala")
        cboType.Items.Add("Western Union")
        'END - 001

        cboType.SelectedIndex = 0
    End Sub

    Private Sub ClearField()
        cboType.Text = ""
        'Sender
        txtSender.Text = ""
        txtSenderAddr.Text = ""
        txtSenderAddr.ReadOnly = True
        txtSenderID.Text = ""
        txtSenderID.ReadOnly = True
        txtSenderIDNum.Text = ""
        txtSenderIDNum.ReadOnly = True
        'Recipient
        txtRecipient.Text = ""
        txtRecipientAddr.Text = ""
        txtRecipientAddr.ReadOnly = True
        'Transaction
        txtReceipt.Text = ""
        txtAmount.Text = ""
        txtServiceFee.Text = ""
        txtServiceFee.ReadOnly = True 'Editable?
        txtTotal.Text = ""
        txtTotal.ReadOnly = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboType.KeyPress
        If isEnter(e) Then
            txtSender.Focus()
        End If
    End Sub

    Private Sub txtSender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSender.KeyPress
        If isEnter(e) Then
            btnSearchSender.PerformClick()
        End If
    End Sub

    Private Sub ComputeServiceAndTotal()
        If Not IsNumeric(txtAmount.Text) Then
            If txtAmount.Text = "" Then
                Return
            End If
            txtServiceFee.Text = "N/A"
            txtTotal.Text = "N/A"
            Return
        End If

        'Load Service Charge
        Dim serviceCharge As Double = GetCharge(txtAmount.Text)
        txtServiceFee.Text = serviceCharge
        If Not IsNumeric(txtServiceFee.Text) Then
            txtTotal.Text = "N/A"
            Return
        End If
        txtTotal.Text = CDbl(txtAmount.Text) + CDbl(txtServiceFee.Text)
    End Sub

    ''' <summary>
    ''' Get Charge Table the corresponding charges for the specific amount
    ''' </summary>
    ''' <param name="amount">Money</param>
    ''' <returns>Money</returns>
    Private Function GetCharge(ByVal amount As Double) As Double
        'Sample Returns
        'No Table no database yet
        If amount > 100 Then
            Return 100
        Else
            Return 50
        End If
    End Function

    ''' <summary>
    ''' Identify if the KeyPress is enter
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <returns>Boolean</returns>
    Private Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSender.Click
        Console.WriteLine("Searching Performed")
        'Auto Search in the frmClient
    End Sub

    Private Sub txtRecipient_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecipient.KeyPress
        If isEnter(e) Then
            btnSearchRecipient.PerformClick()
        End If
    End Sub

    Private Sub btnSearchRecipient_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchRecipient.Click
        Console.WriteLine("Searching Performed")
        'Auto Search in the frmClient
    End Sub

    Private Sub cboType_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboType.LostFocus
        If cboType.Text = "" Then
            cboType.SelectedIndex = 0
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        If isEnter(e) Then
            If txtAmount.Text = "" Then
                MsgBox("Please enter Amount", MsgBoxStyle.Information)
                Return
            End If
            ComputeServiceAndTotal()

            txtServiceFee.Focus()
        End If
    End Sub

    Private Sub txtServiceFee_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtServiceFee.LostFocus
        'ComputeServiceAndTotal()
    End Sub

    Private Sub txtSenderAddr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSenderAddr.KeyPress
        If isEnter(e) Then
            txtSenderID.Focus()
        End If
    End Sub

    Private Sub txtSenderID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSenderID.KeyPress
        If isEnter(e) Then
            txtSenderIDNum.Focus()
        End If
    End Sub

    Private Sub txtSenderIDNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSenderIDNum.KeyPress
        If isEnter(e) Then
            txtRecipient.Focus()
        End If
    End Sub

    Private Sub txtRecipientAddr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRecipientAddr.KeyPress
        If isEnter(e) Then
            txtReceipt.Focus()
        End If
    End Sub

    Private Sub txtReceipt_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtReceipt.GotFocus
        Dim lastNum As Single
        'Get Last Number
        lastNum = 1012
        txtReceipt.Text = String.Format("{0:0000}", lastNum + 1)
    End Sub

    Private Sub txtReceipt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceipt.KeyPress
        
    End Sub

    Private Sub txtReceipt_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtReceipt.TextChanged

    End Sub

    Private Sub btnCharges_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCharges.Click
        Console.WriteLine("Open Service Charges")
    End Sub

    Private Sub txtRecipientAddr_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRecipientAddr.TextChanged

    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged

    End Sub
End Class