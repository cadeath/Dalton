Imports System.Data.Odbc

Public Class frmmoneyexchange
    Friend SelectedCurrency As Currency 'Holds Currency
    Private isNew As Boolean = True
    Dim total As Integer
    Private MoneyExchange As Currency

    Dim fromOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName

    Private dollarClient As Client
    Private dollarEntry As DollarTransaction

    Private strRate As String = DollarAllRate
    Private MODULE_NAME As String = "DOLLAR"
    Private fillData As String = "TBLCURRENCY"
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
    End Sub

    Friend Sub Loadcurrencyy(ByVal tmpcurrency As Currency)
        With tmpcurrency
            txtCurrency.Text = .CURRENCY
            txtSymbol.Text = .SYMBOL
            txtDenomination.Text = .DENOMINATION
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

        Dim getAmount As Integer = txtDenomination1.Text
        Dim getRate As Double = CDbl(txtRate.Text)
        Console.WriteLine("Rate: " & getRate)
        Console.WriteLine("Amount: " & getAmount)
        txtTotal.Text = "Php " & getRate * getAmount
    End Sub
    Private Sub moneyexchange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearField()
        txtCurrency.Focus()
        txtRate.Text = strRate
    End Sub
    Private Function isValid() As Boolean
        If Not IsNumeric(txtRate.Text) Then txtRate.Focus() : Return False
        If txtTotal.Text = "" Then txtTotal.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False
        If dollarClient Is Nothing Then MsgBox("Please select your client at the Client Management", MsgBoxStyle.Information) : TxtName.Focus() : Return False
        Return True
    End Function
    Private Sub cboCurrency_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtDenomination.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        If Not isValid() Then Exit Sub
        If txtCurrency1.Text = "" Then Exit Sub
        If txtRate.Text = "" Then Exit Sub
        If TxtName.Text = "" Then
            MsgBox("Please enter customer.", MsgBoxStyle.Information, "Pawnshop")
        ElseIf txtTotal.Text = "" Then
            MsgBox("Please Calculate the Rate.", MsgBoxStyle.Information, "Pawsnhop")
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

                .SaveDollar()

                AddJournal(.NetAmount, "Debit", "Cash on Hand - Dollar", "Ref# " & .LastIDNumber)
                AddJournal(.NetAmount, "Credit", "Revolving Fund", "Ref# " & .LastIDNumber, "DOLLAR BUYING")


                AddTimelyLogs(MODULE_NAME, String.Format("{0} for Php {1} @ Php {2}", txtDenomination1.Text, .NetAmount, .CurrentRate), .NetAmount)
            End With
            MsgBox("Transaction Saved", MsgBoxStyle.Information)
            ClearField()
        End If

        '-------------------------------------------------------------------------------------
        If btnsave.Text = "&Save" Then
            Dim tmpCurrency As New Currency
            With tmpCurrency
                '.CURRENCY = txtCurrency1.Text
                '.SYMBOL = txtSymbol1.Text
                '.DENOMINATION = txtDenomination1.Text
                .RATE = CDbl(strRate)
                If isNew Then
                    .ModifyCurrency()
                    tmpCurrency.LoadLastEntrycurrency()
                Else
                    Exit Sub
                End If
            End With
            Exit Sub
        End If
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

    Private Sub txRate_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txRate.KeyPress
        DigitOnly(e)
    End Sub
    Friend Sub LoadCurrency(ByVal tmpCurrency As Currency)
        With tmpCurrency
            txtCurrency1.Text = .CURRENCY
            txtSymbol1.Text = .SYMBOL
            txtDenomination1.Text = .DENOMINATION
            txtRate.Text = .RATE
        End With
        btnsave.Enabled = False
        GroupBox1.Enabled = False
        TxtName.Enabled = False

        If tmpCurrency.Status = "V" Then
            Me.Text = "[VOID] " & Me.Text
        End If
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
        txtCurrency1.Text = String.Format(cl.CURRENCY)
        txtSymbol1.Text = String.Format(cl.SYMBOL)
        txtDenomination1.Text = String.Format(cl.DENOMINATION)
        txtRate.Text = String.Format(cl.RATE)
        MoneyExchange = cl
        btnsave.Focus()
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
        frmDollarList.Show()
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

    Private Sub btnCalculate_Click(sender As System.Object, e As System.EventArgs) Handles btnCalculate.Click
        ComputeTotalAmount()
    End Sub
    Friend Sub LoadClient(ByVal cl As Client)
        TxtName.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", ", " & cl.Suffix, ""), cl.FirstName, cl.LastName)

        dollarClient = cl
        btnsave.Focus()
    End Sub

    Private Sub txtCurrency1_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCurrency1.TextChanged
        con.Open()
        Dim dt As New DataTable
        Dim ds As New DataSet
        ds.Tables.Add(dt)
        Dim da As New OdbcDataAdapter("SELECT CURRENCY FROM TBLCURRENCY", con)
        da.Fill(dt)
        Dim r As DataRow
        txtCurrency1.AutoCompleteCustomSource.Clear()
        For Each r In dt.Rows
            txtCurrency1.AutoCompleteCustomSource.Add(r.Item(0).ToString)
        Next
        con.Close()
    End Sub


    Private Sub txtCurrency1_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCurrency1.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch1.PerformClick()
        End If
    End Sub

    Private Sub TxtName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnsearch.PerformClick()
        End If
    End Sub
End Class