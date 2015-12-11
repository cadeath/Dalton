Public Class frmInsurance
    Dim Holder As Client
    Dim curInsurance As New Insurance

    Private Sub frmInsurance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub txtHolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHolder.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    Private Sub ClearFields()
        txtHolder.Text = ""
        txtSenderAddr.Text = ""
        txtSenderID.Text = ""
        txtSenderIDNum.Text = ""
        txtBirthdate.Text = ""

        dtpDate.Value = CurrentDate
        dtpExpiry.Enabled = False
        dtpExpiry.Value = dtpDate.Value.AddDays(120)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearFields()

        txtHolder.ReadOnly = False
        btnNew.Enabled = False
        btnSave.Enabled = True
        btnBrowse.Enabled = False
        btnVoid.Enabled = False
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

        txtPT.Focus()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub

    Friend Sub LoadInsurance(ByVal id As Integer)
        Dim getInsurance As New Insurance
        getInsurance.LoadInsurance(id)

        LoadHolder(getInsurance.Client)
        txtCoi.Text = getInsurance.COInumber
        dtpDate.Value = getInsurance.TransactionDate
        dtpExpiry.Value = getInsurance.ValidDate
        txtAmount.Text = getInsurance.Amount

        curInsurance = getInsurance
        btnVoid.Enabled = True
        txtPT.Focus()
    End Sub

    Private Function isValid() As Boolean
        If Holder Is Nothing Then txtHolder.Focus() : Return False
        'If Not IsNumeric(txtPT.Text) Then txtPT.Focus() : Return False

        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub
        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Posting")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim newInsurance As New Insurance
        With newInsurance
            .COInumber = txtCoi.Text
            If IsNumeric(txtPT.Text) Then .TicketNum = txtPT.Text
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

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        Dim ans As DialogResult = MsgBox("Do you want to void this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        curInsurance.VoidTransaction()
        MsgBox("Transaction VOIDED", MsgBoxStyle.Information)
        Exit Sub
    End Sub

    Private Sub txtPT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPT.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub

End Class