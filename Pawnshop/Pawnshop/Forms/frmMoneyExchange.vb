Public Class frmmoneyexchange
    Friend SelectedCurrency As Currency 'Holds Currency
    Private isNew As Boolean = True
    Dim total As Integer
    Private MoneyExchange As Currency


    Private lockForm As Boolean = False
    Dim fromOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName

    Private dollarClient As Client
    Private dollarEntry As DollarTransaction

    Private strRate As String = DollarAllRate
    Private fillData As String = "TBLCURRENCY"
    Private MODULE_NAME As String = "DOLLAR"

    Private Sub btnsearch_Click(sender As System.Object, e As System.EventArgs) Handles btnsearch.Click
        frmClient.SearchSelect(TxtName.Text, FormName.frmMoneyExchange)
        frmClient.Show()
    End Sub

    Private Sub ClearField()
        TxtName.Text = ""
        txtTotal.Text = ""
        txtCurrency1.Text = ""
        txtSymbol1.Text = ""
        txtRate.Text = ""
        txtDenomination1.Text = ""
        txtSerial.Text = ""
    End Sub


    Friend Sub Loadcurrencyy(ByVal tmpcurrency As Currency)
        With tmpcurrency
            txtCurrency.Text = .CURRENCY
            txtSymbol.Text = .SYMBOL
            txRate.Text = .RATE
        End With

        btnsave.Enabled = False
        GroupBox1.Enabled = False
        TxtName.Enabled = False

        If tmpcurrency.Status = "V" Then
            Me.Text = "[VOID] " & Me.Text
        End If
    End Sub

    Private Sub ComputeTotalAmount()
        If Not IsNumeric(txtRate.Text) Then Exit Sub
        If txtDenomination1.Text = "" Then Exit Sub
        Dim getAmount As Double = CDbl(txtDenomination1.Text)
        Dim getRate As Double = CDbl(txtRate.Text)
        Console.WriteLine("Rate: " & getRate)
        Console.WriteLine("Amount: " & getAmount)
        Dim amt As Double = getRate * getAmount
        txtTotal.Text = "Php " & String.Format("{0:#,##0.00}", amt)
    End Sub

    Private Sub moneyexchange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtCurrency1.Focus()

        ClearField()
        txtRate.Text = strRate
        If isReady() Then
            Console.WriteLine("Database connected")
        End If
        txtTotal.Text = "Php 0"
        txtDenomination1.Text = "0"
    End Sub

    Private Sub LockFields(ByVal st As Boolean)
        lockForm = st
        txtRate.ReadOnly = st
        If st Then
            btnModify.Text = "&Edit"
        Else
            btnModify.Text = "&Modify"
        End If
    End Sub
    ''' <summary>
    ''' Load currency to textbox
    ''' </summary>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
    Friend Sub LoadCurrencyList(ByVal cl As Currency)
        If cl.CURRENCY = "" Then Exit Sub
        ' Display select buttons
        txtCurrency1.Text = cl.CURRENCY
        txtSymbol1.Text = cl.SYMBOL
        txtRate.Text = cl.RATE
        txtCashID.Text = cl.CASHID

        SelectedCurrency = cl
        LockFields(True)
    End Sub
    ''' <summary>
    ''' Load Dollar transaction to textbox
    ''' </summary>
    ''' <param name="tmpDollar"></param>
    ''' <remarks></remarks>
    ''' 
    Friend Sub LoadTransDollar(ByVal tmpDollar As DollarTransaction)
        With tmpDollar

            txtDenomination1.Text = .Denomination
            txtTotal.Text = .NetAmount
            txtSerial.Text = .Serial
            txtCurrency1.Text = .CURRENCY
            txtRate.Text = .CurrentRate
            LoadClient(.Customer)
        End With

        btnBrowse.Enabled = False
        btnsave.Enabled = False
        GroupBox1.Enabled = False
        TxtName.Enabled = False
        txtCurrency1.Enabled = False

        txtSerial.Enabled = False
        txtDenomination1.Enabled = False
        btnModify.Enabled = False
        If tmpDollar.Status = "V" Then
            Me.Text = "[VOID] " & Me.Text
        End If
    End Sub

    Private Function isValid() As Boolean
        If Not IsNumeric(txtRate.Text) Then txtRate.Focus() : Return False
        If txtDenomination1.Text = "" Then txtDenomination1.Focus() : Return False
        If txtCurrency1.Text = "" Then txtCurrency1.Focus() : Return False
        If TxtName.Text = "" Then TxtName.Focus() : Return False
        If txtTotal.Text = "Php 0" Then txtTotal.Focus() : Return False
        If dollarClient Is Nothing Then MsgBox("Please select your client at the Client Management", MsgBoxStyle.Information) : TxtName.Focus() : Return False
        Return True
    End Function

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Not isValid() Then Exit Sub
        If txtSerial.Text = "" Then
            MsgBox("Please fill the Serial", MsgBoxStyle.Information, "Dollar")
            txtSerial.Focus()
        Else

            Dim ans As DialogResult = MsgBox("Do you want to save this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            dollarEntry = New DollarTransaction
            With dollarEntry
                .CurrentRate = CDbl(txtRate.Text)
                .TransactionDate = CurrentDate
                .Customer = dollarClient
                .Denomination = txtDenomination1.Text
                .Serial = txtSerial.Text
                .EncoderID = POSuser.EncoderID
                .NetAmount = txtTotal.Text.Substring(4)
                .CURRENCY = txtCurrency1.Text
                .SaveDollar()

                AddJournal(.NetAmount, "Debit", "Cash on Hand - Dollar", "Ref# " & .LastIDNumber, TransType:="DOLLAR BUYING")
                AddJournal(.NetAmount, "Credit", "Revolving Fund", "Ref# " & .LastIDNumber, "DOLLAR BUYING", TransType:="DOLLAR BUYING")

                AddTimelyLogs(MODULE_NAME, String.Format("{3} - {0} for Php {1} @ Php {2}", txtDenomination1.Text, .NetAmount, .CurrentRate, .CURRENCY), .NetAmount)
            End With
            MsgBox("Transaction Saved", MsgBoxStyle.Information)
            ClearField()
            txtCurrency1.Focus()
            txtTotal.Text = "Php 0"
        End If

    End Sub

    Friend Sub LoadCurrency(ByVal tmpCurrency As Currency)
        With tmpCurrency
            txtCurrency1.Text = .CURRENCY
            txtSymbol1.Text = .SYMBOL
            txtRate.Text = .RATE
        End With
        btnsave.Enabled = False
        GroupBox1.Enabled = False
        TxtName.Enabled = False
    End Sub

    Friend Sub LoadCurrencyall(ByVal cl As Currency)
        txtCurrency1.Text = String.Format(cl.CURRENCY)
        txtSymbol1.Text = String.Format(cl.SYMBOL)
        txtRate.Text = String.Format(cl.RATE)
        MoneyExchange = cl

    End Sub





    Private Sub txtTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal.TextChanged
        If IsNumeric(txtTotalAmount.Text) Then
            Dim temp As Double = txtTotalAmount.Text
            txtTotalAmount.Text = Format(temp, "N")
            txtTotalAmount.SelectionStart = txtTotalAmount.TextLength - 3
        End If
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        TxtName.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", ", " & cl.Suffix, ""), cl.FirstName, cl.LastName)

        dollarClient = cl
        btnsave.Focus()
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        frmDollarList.Show()
    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Hide()
        frmMain.Show()
    End Sub
    Private Sub txtRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub
    Private Sub TxtName_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz.-1234567890 "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
        If isEnter(e) Then
            btnsearch.PerformClick()
        End If
    End Sub


    Private Sub txtSerial_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerial.KeyPress
        If isEnter(e) Then
            btnsave.Focus()
        End If
    End Sub
    Private Sub txtCurrency1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch1.PerformClick()
        End If
    End Sub
    Private Sub TxtName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsearch.PerformClick()
        End If
    End Sub

    Private Sub btnModify_Click(sender As System.Object, e As System.EventArgs) Handles btnModify.Click
        If btnModify.Text = "&Edit" Then
            isNew = False
            LockFields(False)
            Exit Sub
        End If
    End Sub



    Private Sub btnSearch1_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch1.Click
        frmCurrencyList.SearchSelect(txtCurrency.Text, FormName.frmMoneyExchange)
        frmCurrencyList.Show()
        frmCurrencyList.txtSearch.Text = Me.txtCurrency1.Text.ToString
        frmCurrencyList.btnSearch.PerformClick()
    End Sub

    Private Sub txtDenomination1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDenomination1.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtRate_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtRate.TextChanged
        ComputeTotalAmount()
    End Sub

    Private Sub txtRate_KeyPress_1(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtDenomination1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDenomination1.TextChanged
        ComputeTotalAmount()
    End Sub

    Private Sub txtCurrency1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrency1.KeyPress
        If isEnter(e) Then
            btnSearch1.PerformClick()
        End If
    End Sub

End Class