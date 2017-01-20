Public Class frmAddCustomer
    Dim Customer As Client
    Friend retID As Integer = 0

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.layAwayExist)
        frmClient.Show()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
       
        Customer = New Client
        Customer = cl
    End Sub

    Private Sub txtCustomer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomer.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
        frmUploadLay.DisplayValue(Customer.ID, txtCustomer.Text, retID)
        Me.Close()
    End Sub
End Class