Public Class frmDollar

    Dim currentRate As Double = GetOption("PesoRate")
    Dim customer As Client
    Dim isViewing As Boolean = False

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isvalid() Then Exit Sub

        Dim ReceiveDollar As New DollarTransaction
        With ReceiveDollar
            .TransactionDate = CurrentDate
            If Not customer Is Nothing Then
                .Customer = customer
                .CustomersName = String.Format("{0} {1}", customer.FirstName, customer.LastName)
            End If
            .Denomination = cboDenomination.Text
            .Serial = txtSerial.Text
            .CurrentRate = txtPesoRate.Text
            .EncoderID = UserID
            .NetAmount = txtNetAmount.Text

            .SaveDollar()
        End With

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Function isvalid() As Boolean
        If txtPesoRate.Text = "" Then txtPesoRate.Focus() : Return False
        If cboDenomination.Text = "" Then cboDenomination.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False

        Return True
    End Function

    Private Sub txtPesoRate_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPesoRate.KeyPress
        DigitOnly(e)
        currentRate = CDbl(txtPesoRate.Text)
    End Sub

    Private Sub frmDollar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        currentRate = GetOption("PesoRate")
        ClearFields()
    End Sub

    Private Sub ClearFields()
        cboCur1.Items.Clear()
        cboCur2.Items.Clear()

        cboCur2.Items.AddRange({"PHP", "USD"})
        cboCur2.SelectedIndex = 0
        cboCur1.Items.AddRange({"USD", "PHP"})
        cboCur1.SelectedIndex = 0

        txtCur1.Text = "1"
        Convert(txtCur1.Text)

        txtClient.Text = ""
        txtAddr.Text = ""
        txtNum.Text = ""
        txtNetAmount.Text = ""

        txtPesoRate.Text = currentRate
        txtSerial.Text = ""
        cboDenomination.SelectedIndex = 0
    End Sub

    Private Sub txtCur1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCur1.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtCur2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCur2.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub Convert(ByVal primary As Double)
        Dim display As TextBox, currency As String

        'Get Non Dominant
        If primary = CDbl(txtCur1.Text) Then
            display = txtCur2
            currency = cboCur1.Text
        Else
            display = txtCur1
            currency = cboCur2.Text
        End If

        If currency = "USD" Then
            display.Text = FormatNumber(primary * currentRate, 2)
        Else
            display.Text = FormatNumber(primary / currentRate, 2)
        End If
    End Sub

    Private Sub txtCur1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCur1.TextChanged
        If txtCur1.Text = "" Or txtCur1.Text = "0" Then Exit Sub

        Convert(CDbl(txtCur1.Text))
    End Sub

    Private Sub cboCur1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCur1.SelectedIndexChanged
        cboCur2.SelectedIndex = cboCur1.SelectedIndex
        Convert(CDbl(txtCur1.Text))
    End Sub

    Private Sub txtPesoRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPesoRate.LostFocus
        currentRate = CDbl(txtPesoRate.Text)
        Convert(CDbl(txtCur1.Text))
    End Sub

    Friend Sub LoadCustomer(ByVal cl As Client)
        On Error Resume Next

        txtClient.Text = String.Format("{0} {1}", cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1}, {2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtNum.Text = cl.Cellphone1

        customer = cl
        cboDenomination.Focus()
        'If Not isViewing Then cboDenomination.DroppedDown = True
    End Sub

    Private Sub txtClient_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClient.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtClient.Text = "" Then Exit Sub

        frmClient.SearchSelect(txtClient.Text, FormName.frmDollar)
        frmClient.Show()
    End Sub

    Private Sub txtNetAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNetAmount.KeyPress
        DigitOnly(e)
    End Sub

    Friend Sub LoadDollar(ByVal dl As DollarTransaction)
        LockFields(True)

        LoadCustomer(dl.Customer)
        txtPesoRate.Text = dl.CurrentRate
        cboDenomination.Text = dl.Denomination
        txtNetAmount.Text = dl.NetAmount
        txtSerial.Text = dl.Serial

        txtNetAmount.Focus()
        isViewing = True
        btnPost.Enabled = False
    End Sub

    Private Sub LockFields(ByVal st As Boolean)
        txtPesoRate.ReadOnly = st
        txtClient.ReadOnly = st
        btnSearch.Enabled = Not st
        cboDenomination.Enabled = Not st
        txtNetAmount.ReadOnly = st
        txtSerial.ReadOnly = st
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmDollarList.Show()
    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click
        If isViewing Then Exit Sub

        txtNetAmount.Text = txtCur2.Text
        cboDenomination.Focus()
        cboDenomination.DroppedDown = True
    End Sub
End Class