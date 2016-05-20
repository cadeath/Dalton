Imports System.Data.Odbc

Public Class frmmoneyexchange
    Dim total As Integer
    Private MoneyExchange As Currency

    Private dollarClient As Client
    Private dollarEntry As DollarTransaction

    Private strRate As String = DollarRate
    Private MODULE_NAME As String = "DOLLAR"
    Private fillData As String = "TBLCURRENCY"
    Private Sub btnsearch_Click(sender As System.Object, e As System.EventArgs) Handles btnsearch.Click
        frmClient.SearchSelect(TxtName.Text, FormName.frmMoneyExchange)
        frmClient.Show()
    End Sub
    Friend Sub LoadClient(ByVal cl As Client)
        txtName.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", ", " & cl.Suffix, ""), cl.FirstName, cl.LastName)
        dollarClient = cl
        btnSave.Focus()
    End Sub
    Private Sub ClearField()
        TxtName.Text = ""
        txtTotalAmount.Text = ""
        TxtName.Text = ""
        txtCurrency.Text = ""
        txtSymbol.Text = ""
        txRate.Text = ""
    End Sub

    Friend Sub Loadcurrencyy(ByVal tmpcurrency As Currency)
        With tmpcurrency
            txtCurrency.Text = .CURRENCY
            txtSymbol.Text = .SYMBOL
            txtDenomination.Text = .DENOMINATION
            txRate.Text = .RATE
            'LoadClient(.Customer)
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

        Dim getAmount As Integer = txtDenomination1.Text
        Dim getRate As Double = CDbl(txtRate.Text)
        Console.WriteLine("Rate: " & getRate)
        Console.WriteLine("Amount: " & getAmount)

        txtTotal.Text = "Php " & getRate * getAmount
    End Sub

    Private Sub txtTotalAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalAmount.TextChanged
       
        'Dim value As Decimal = txtTotalAmount.Text
        'txtTotalAmount.Text = (value.ToString("C2"))
    End Sub
    Private Sub moneyexchange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ClearField()
        txtCurrency.Focus()
    End Sub
    Private Sub cboCurrency_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDenomination.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
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

            .SaveDollar()

            AddJournal(.NetAmount, "Debit", "Cash on Hand - Dollar", "Ref# " & .LastIDNumber)
            AddJournal(.NetAmount, "Credit", "Revolving Fund", "Ref# " & .LastIDNumber, "DOLLAR BUYING")


            AddTimelyLogs(MODULE_NAME, String.Format("{0} for Php {1} @ Php {2}", txtDenomination1.Text, .NetAmount, .CurrentRate), .NetAmount)
        End With

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        Me.Close()

    End Sub
  
    Private Sub TxtName_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz.- "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub txRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txRate.KeyPress
        DigitOnly(e)
    End Sub



    Private Sub txtDenomination_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDenomination.TextChanged
        If txtCurrency.Text = "" Then
            MsgBox("Please choose curency!", MsgBoxStyle.Information, "Pawnshop")
        Else
            total = Val(txRate.Text) * Val(txtDenomination.Text)
            txtTotalAmount.Text = total
        End If
    End Sub

    Friend Sub LoadCurrencyall(ByVal cl As Currency)
        txtCurrency.Text = String.Format("{0}"(cl.CURRENCY))

        MoneyExchange = cl
        btnSave.Focus()
    End Sub
    

    Shared Sub LoadCurrencyall(cl As Client)
        Throw New NotImplementedException
    End Sub

    Shared Sub Loadcurrency(tmpLoadcur As Pawnshop.Currency)
        Throw New NotImplementedException
    End Sub

    Private Sub txtDenomination1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtDenomination1.TextChanged
        ComputeTotalAmount()
    End Sub

    Private Sub btnSearch1_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch1.Click
        frmCurrencyList.SearchSelect(txtCurrency.Text, FormName.frmMoneyExchange)
        frmCurrencyList.Show()
    End Sub

    Private Sub txtTotal_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotal.TextChanged
        If IsNumeric(txtTotalAmount.Text) Then
            Dim temp As Double = txtTotalAmount.Text
            txtTotalAmount.Text = Format(temp, "N")
            txtTotalAmount.SelectionStart = txtTotalAmount.TextLength - 3
        End If
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        frmCurrencyList.Show()
    End Sub

    Private Sub txtRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtRate.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtDenomination1_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtDenomination1.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtSerial_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSerial.KeyPress
        If isEnter(e) Then
            TxtName.Focus()
        End If
    End Sub
End Class