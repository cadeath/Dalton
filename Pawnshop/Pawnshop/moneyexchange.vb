Public Class moneyexchange
    Dim total As Integer
    Private Sub btnsearch_Click(sender As System.Object, e As System.EventArgs) Handles btnsearch.Click
        frmClient.SearchSelect(TxtName.Text, FormName.frmDollarSimple)
        frmClient.Show()
    End Sub
    Private Sub ClearField()
        TxtName.Text = ""
        txtTotalAmount.Text = ""
        TxtName.Text = ""
        cboCurrency.SelectedItem = -1
        txtCurrencyAmount.Text = ""
        txtSymbol.Text = ""
        txRate.Text = ""
    End Sub
    Private Sub cboCurrency_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboCurrency.SelectedIndexChanged
        currency()
    End Sub
    Private Sub txtCurrencyAmount_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtCurrencyAmount.KeyPress
        DigitOnly(e)
    End Sub
#Region "currency"

    Public Sub currency()
        If cboCurrency.Text = "US Dollar" Then
            txtSymbol.Text = "USD"
            txRate.Text = "46.51"
            Label5.Text = cboCurrency.Text
        ElseIf cboCurrency.Text = "Japanese Yen" Then
            txtSymbol.Text = "JPY"
            txRate.Text = "0.43"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "UK Pound" Then
            txtSymbol.Text = "GBP"
            txRate.Text = "67.0153"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "HK Dollar" Then
            txtSymbol.Text = "HKD"
            txRate.Text = "5.9923"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Swiss Franc" Then
            txtSymbol.Text = "CHK"
            txRate.Text = "47.5995"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Canadian Dollar" Then
            txtSymbol.Text = "CAD"
            txRate.Text = "36.0808"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Singaporean Dollar" Then
            txtSymbol.Text = "SGD"
            txRate.Text = "33.9753"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Austrilian Dollar" Then
            txtSymbol.Text = "AUD"
            txRate.Text = "33.8984"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Bahrain Dinar" Then
            txtSymbol.Text = "BHD"
            txRate.Text = "123.451"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Saudi Arabian Rial" Then
            txtSymbol.Text = "SAR"
            txRate.Text = "12.4081"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Brunie Dollar" Then
            txtSymbol.Text = "BND"
            txRate.Text = "33.8517"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Indonesian Rupiah" Then
            txtSymbol.Text = "IDR"
            txRate.Text = "0.0035"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Thai Baht" Then
            txtSymbol.Text = "THB"
            txRate.Text = "1.316"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "UAE Dirham" Then
            txtSymbol.Text = "AED"
            txRate.Text = "12.6665"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Chinese Yuan" Then
            txtSymbol.Text = "CNY"
            txRate.Text = "7.1348"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Korean Won" Then
            txtSymbol.Text = "KRW"
            txRate.Text = "0.0395"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "European Monetary Union Euro" Then
            txtSymbol.Text = "EUR"
            txRate.Text = "52.6735"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Argentinian Peso" Then
            txtSymbol.Text = "ARS"
            txRate.Text = "3.2931"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Brazilian Real" Then
            txtSymbol.Text = "BRL"
            txRate.Text = "13.2957"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Danish Kroner" Then
            txtSymbol.Text = "DKK"
            txRate.Text = "7.0799"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Indian Rupee" Then
            txtSymbol.Text = "INR"
            txRate.Text = "0.696"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Malaysian Ringgit" Then
            txtSymbol.Text = "MYR"
            txRate.Text = "11.5575"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Mexican New Peso" Then
            txtSymbol.Text = "MXN"
            txRate.Text = "2.5427"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "New Zealand Dollar" Then
            txtSymbol.Text = "NZD"
            txRate.Text = "31.5771"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Norwegian Kroner" Then
            txtSymbol.Text = "NOK"
            txRate.Text = "5.6965"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Pakistan Rupee " Then
            txtSymbol.Text = "PKR"
            txRate.Text = "0.445"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "South African Rand" Then
            txtSymbol.Text = "ZAR"
            txRate.Text = "2.9729"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Swedish Kroner" Then
            txtSymbol.Text = "SEK"
            txRate.Text = "5.6316"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Syrian Pound" Then
            txtSymbol.Text = "SYP"
            txRate.Text = "0.2129"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Taiwanese NT Dollar" Then
            txtSymbol.Text = "TWD"
            txRate.Text = "1.4246"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
            txtCurrencyAmount.Text = ""
        ElseIf cboCurrency.Text = "Venezuelan Boliver" Then
            txtSymbol.Text = "VEB"
            txRate.Text = "4.6636"
            Label5.Text = cboCurrency.Text
            txtCurrencyAmount.Text = ""
        End If

    End Sub
    Private Sub txtCurrencyAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtCurrencyAmount.TextChanged
        If cboCurrency.Text = "" Then
            MsgBox("Please choose curency!", MsgBoxStyle.Information, "Pawnshop")
        Else
            total = Val(txRate.Text) * Val(txtCurrencyAmount.Text)
            txtTotalAmount.Text = total
        End If
    End Sub
#End Region

    Private Sub txtTotalAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalAmount.TextChanged
        If IsNumeric(txtTotalAmount.Text) Then
            Dim temp As Double = txtTotalAmount.Text
            txtTotalAmount.Text = Format(temp, "N")
            txtTotalAmount.SelectionStart = txtTotalAmount.TextLength - 3
        End If
    End Sub

    Private Sub moneyexchange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ClearField()
        cboCurrency.Focus()
    End Sub
    Private Sub cboCurrency_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cboCurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            txtCurrencyAmount.Focus()
        End If
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Application.Exit()
    End Sub

    Private Sub btnsave_Click(sender As System.Object, e As System.EventArgs) Handles btnsave.Click
        save()
    End Sub
    Private Sub save()
        If TxtName.Text = "" Then
            MsgBox("Please choose client name :)", MsgBoxStyle.Information, "Pawnshop")
        ElseIf cboCurrency.Text = "" Then
            MsgBox("Please Choose Currency :)", MsgBoxStyle.Information, "Pawnshop")
        ElseIf txRate.Text = "" Then
            MsgBox("Please enter rate")
        Else
            Dim lv As ListViewItem = ListView1.Items.Add(TxtName.Text)
            lv.SubItems.Add(cboCurrency.Text)
            lv.SubItems.Add(txtSymbol.Text)
            lv.SubItems.Add(txRate.Text)
            lv.SubItems.Add(txtCurrencyAmount.Text)
            lv.SubItems.Add(txtTotalAmount.Text)
            ClearField()
        End If
    End Sub
    
    Private Sub TxtName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
           save()
            End If

    End Sub

    Private Sub txtCurrencyAmount_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCurrencyAmount.KeyDown
        If e.KeyCode = Keys.Enter Then
            TxtName.Focus()
        End If
    End Sub

    Private Sub TxtName_KeyPress(sender As System.Object, e As System.Windows.Forms.KeyPressEventArgs) Handles TxtName.KeyPress
        If Not (Asc(e.KeyChar) = 8) Then
            Dim allowedChars As String = "abcdefghijklmnopqrstuvwxyz "
            If Not allowedChars.Contains(e.KeyChar.ToString.ToLower) Then
                e.KeyChar = ChrW(0)
                e.Handled = True
            End If
        End If
    End Sub
End Class