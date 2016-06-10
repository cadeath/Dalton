Public Class frmInsurance
    Dim Holder As Client
    Dim curInsurance As New Insurance
    Private currentInsuranceNum As Integer = GetOption("InsuranceLastNum")
    Dim MOD_NAME As String = "INSURANCE"

    Private Sub frmInsurance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()

        ClearFields()

        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub
    ''' <summary>
    ''' if you press enter it will go client information form.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtHolder_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHolder.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub
    ''' <summary>
    ''' This method will clear all text fields.
    ''' </summary>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' This button will enable some textfield that need to input data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ClearFields()
        If Not GenerateInsuranceNum() Then : Exit Sub
        End If

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
    ''' <summary>
    ''' This button will show the client information form. 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtHolder.Text, FormName.frmInsurance)
        frmClient.Show()
    End Sub
    ''' <summary>
    ''' This method will send client information to text fields.
    ''' </summary>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
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
    ''' <summary>
    ''' This keypress will allow digit only
    ''' iy you press enter it will save automatically.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub
    ''' <summary>
    ''' This method will load data into text fields.
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
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
        txtPT.Enabled = False
    End Sub
    ''' <summary>
    ''' This method will verify if txtholder has data.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValid() As Boolean
        If Holder Is Nothing Then txtHolder.Focus() : Return False
        'If Not IsNumeric(txtPT.Text) Then txtPT.Focus() : Return False

        Return True
    End Function
    ''' <summary>
    ''' This button will perform save the client information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not isValid() Then Exit Sub
       
        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Posting")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim newInsurance As New Insurance
        With newInsurance
            .COInumber = txtCoi.Text
            .TicketNum = txtPT.Text
            .TransactionDate = dtpDate.Value
            .ValidDate = dtpExpiry.Value
            .Amount = txtAmount.Text
            .Client = Holder
            .EncoderID = POSuser.UserID

            .SaveInsurance()

            AddJournal(.Amount, "Debit", "Revolving Fund", "COI# " & .COInumber, "INSURANCE", TransType:="INSURANCE")
            AddJournal(.Amount, "Credit", "Cash Offsetting Account", "COI# " & .COInumber, TransType:="INSURANCE")

            AddTimelyLogs(MOD_NAME, "COI# " & .COInumber.ToString("0000000"), .Amount, )
        End With

        UpdateOptions("InsuranceLastNum", CInt(txtCoi.Text) + 1)
        MsgBox("Entry Saved", MsgBoxStyle.Information)
        btnNew.PerformClick()

        Me.Close()
    End Sub

    Private Function GenerateInsuranceNum() As Boolean
        'Check InsuranceNum if existing
        Dim mySql As String, ds As DataSet
        mySql = "SELECT DISTINCT COINO FROM TBLINSURANCE "
        mySql &= "WHERE COINO = '" & currentInsuranceNum & "' "
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then : MsgBox("InsuranceNum # " & currentInsuranceNum & " already existed.", MsgBoxStyle.Critical) : Return False
        End If
        Return True
    End Function

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmInsuranceList.Show()
    End Sub
    ''' <summary>
    ''' This button will perform to void the transaction.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        Dim ans As DialogResult = MsgBox("Do you want to void this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        ' ISSUE: 0001
        ' Locking Insurance voiding exclusive for the same DATE
        If curInsurance.TransactionDate.Date <> CurrentDate.Date Then
            MsgBox("You cannot void transaction in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        curInsurance.VoidTransaction()
        MsgBox("Transaction VOIDED", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub txtPT_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPT.KeyPress
        'DigitOnly(e)
        If isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub

End Class