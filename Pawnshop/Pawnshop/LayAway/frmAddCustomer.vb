Public Class frmAddCustomer
    Dim Customer As Customer
    Friend retID As Integer = 0

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClientNew.SearchSelect(secured_str, FormName.layAwayExist)
        frmClientNew.Show()
    End Sub

    Friend Sub LoadClient(ByVal cus As Customer)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cus.Suffix <> "", "," & cus.Suffix, ""), cus.FirstName, cus.LastName)

        Customer = New Customer
        Customer = cus
    End Sub

    Private Sub txtCustomer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomer.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        If Customer Is Nothing Then Exit Sub
        frmUploadLay.DisplayValue(Customer.CustomerID, txtCustomer.Text, retID)
        Me.Close()
    End Sub
End Class