Imports System.Data.Odbc

Public Class frmmoneyexchange
    Dim total As Integer
    Private MoneyExchange As Currency

    Private Sub btnsearch_Click(sender As System.Object, e As System.EventArgs) Handles btnsearch.Click
        frmClient.SearchSelect(TxtName.Text, FormName.frmDollarSimple)
        frmClient.Show()
    End Sub
    Private Sub ClearField()
        TxtName.Text = ""
        txtTotalAmount.Text = ""
        TxtName.Text = ""
        txtCurrency.Text = ""
        txtSymbol.Text = ""
        txRate.Text = ""
    End Sub


#Region "currency"

    Public Sub currency()

    End Sub
#End Region

    Private Sub txtTotalAmount_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtTotalAmount.TextChanged
        If IsNumeric(txtTotalAmount.Text) Then
            Dim temp As Double = txtTotalAmount.Text
            txtTotalAmount.Text = Format(temp, "N")
            txtTotalAmount.SelectionStart = txtTotalAmount.TextLength - 3
        End If
        'Dim value As Decimal = txtTotalAmount.Text
        'txtTotalAmount.Text = (value.ToString("C2"))
    End Sub
    Private Sub moneyexchange_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        ClearField()
        txtCurrency.Focus()
    End Sub
    Friend Sub LoadCurrency(ByVal id As Integer)
        Dim getCurrency As New Currency
        getCurrency.LoadCurrency(id)
        txtCurrency.Text = getCurrency.Currency
        txtSymbol.Text = getCurrency.Symbol
        txtDenomination.Text = getCurrency.Denomination
        txRate.Text = getCurrency.Rate
  
    End Sub
    Private Sub loadCurrency(ByVal currency As String)
        Dim mySql As String = "SELECT * FROM TBLCURRENCY"
        Dim fillData As String = "tblCash"
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(0).Rows(0).Item("SAPACCOUNT") = currency
        database.SaveEntry(ds, False)

        Console.WriteLine("Revolving Fund Added")
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
        save()
    End Sub
    Private Sub save()
        If TxtName.Text = "" Then
            MsgBox("Please choose client name :)", MsgBoxStyle.Information, "Pawnshop")
        ElseIf txtCurrency.Text = "" Then
            MsgBox("Please Choose Currency :)", MsgBoxStyle.Information, "Pawnshop")
        ElseIf txRate.Text = "" Then
            MsgBox("Please enter rate")
        Else
            Dim lv As ListViewItem = ListView1.Items.Add(TxtName.Text)
            lv.SubItems.Add(txtCurrency.Text)
            lv.SubItems.Add(txtSymbol.Text)
            lv.SubItems.Add(txRate.Text)
            lv.SubItems.Add(txtDenomination.Text)
            lv.SubItems.Add(txtTotalAmount.Text)
            ClearField()
        End If
    End Sub
#Region "validation"

    Private Sub TxtName_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles TxtName.KeyDown
        If e.KeyCode = Keys.Enter Then
            save()
        End If

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
#End Region
    Friend Sub LoadClient(ByVal cl As Client)
        TxtName.Text = String.Format("{0}"(cl.Suffix), cl.Suffix)

        ' MoneyExchange = cl
    End Sub
    Private Sub buttonSearch_Click(sender As System.Object, e As System.EventArgs) Handles buttonSearch.Click
        frmClient.SearchSelect(txtCurrency.Text, FormName.frmInsurance)
        frmClient.Show()
    End Sub
End Class