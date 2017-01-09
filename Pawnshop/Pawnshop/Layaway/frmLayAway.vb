Public Class frmLayAway
    Protected m_Customer As Integer = 0
    Protected m_ItemCode As String = ""
    Protected m_Amount As Integer = 0
    Friend Customer As Client

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub

    Private Sub frmLayAway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearText()
    End Sub

    Private Sub ClearText()
        txtAddress.Clear()
        txtCustomer.Clear()
        txtItemCode.Clear()
        txtDescription.Clear()
        txtAmount.Clear()
        lblContact.Text = ""
        lblDOB.Text = ""
        lblCost.Text = ""
        lblPenalty.Text = ""
        lblBalance.Text = ""
    End Sub

    Public Overloads Function ShowDialog(ByVal EnteredText() As String) As DialogResult
        Me.ShowDialog()

        EnteredText(0) = m_ItemCode
        EnteredText(1) = m_Customer
        EnteredText(2) = m_Amount

        Return Me.DialogResult
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.layAway)
        frmClient.Show()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddress.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        lblDOB.Text = cl.Birthday.ToString("MMM dd, yyyy")
        lblContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        Customer = New Client
        Customer = cl
        txtAmount.Focus()
    End Sub

    Friend Sub LoadItemEncode(ByVal Item As cItemData)
        txtItemCode.Text = Item.ItemCode
        txtDescription.Text = Item.Description
        lblCost.Text = Item.SalePrice

    End Sub

    Private Sub txtCustomer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomer.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
    End Sub
End Class