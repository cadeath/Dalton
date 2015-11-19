Public Class frmInsurance
    Dim Holder As Client

    Private Sub frmInsurance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.Value = CurrentDate
        dtpExpiry.Enabled = False
        dtpExpiry.Value = dtpDate.Value.AddDays(120)
    End Sub

    Private Sub txtHolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHolder.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtHolder.ReadOnly = False
        btnNew.Enabled = False
        btnSave.Enabled = True
        btnBrowse.Enabled = False
        'txtAmount.ReadOnly = False
        btnSearch.Enabled = True
        txtCoi.Text = GetOption("InsuranceLastNum")
        txtAmount.Text = GetOption("InsuranceAmount")
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtHolder.Text, FormName.frmInsurance)
        frmClient.Show()
    End Sub
    Friend Sub LoadHolder(ByVal cl As Client)
        txtHolder.Text = String.Format("{0} {1} {2}", cl.FirstName, cl.LastName, cl.Suffix)
        txtSenderAddr.Text = String.Format("{0} {1} {2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBirthdate.Text = cl.Birthday.ToString("MMM dd, yyyy")

        txtSenderID.Text = cl.IDType
        txtSenderIDNum.Text = cl.IDNumber
        txtBirthdate.Text = cl.Birthday
        Holder = cl

        txtAmount.Focus()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Posting")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim newInsurance As New Insurance
        With newInsurance
            .COInumber = txtCoi.Text
            .TransactionDate = dtpDate.Value
            .ValidDate = dtpExpiry.Value
            .Amount = txtAmount.Text
            .Client = Holder
            .EncoderID = POSuser.UserID

            .SaveInsurance()
        End With

        UpdateOptions("InsuranceLastNum", CInt(txtCoi.Text) + 1)
        btnNew.PerformClick()
        MsgBox("Entry Saved", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmInsuranceList.Show()
    End Sub
End Class