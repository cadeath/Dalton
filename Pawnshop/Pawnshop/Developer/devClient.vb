Public Class devClient

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmClient.SearchSelect(txtSearch.Text, FormName.devForm)
        frmClient.Show()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnBrowse.PerformClick()
        End If
    End Sub

    Friend Sub LoadClientInfo(ByVal cl As Client)
        txtID.Text = cl.ID
        txtName.Text = cl.FirstName & " " & cl.LastName
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not IsNumeric(txtAmount.Text) Then Exit Sub

        Dim conv As New clsConversion
        Dim amt As Double = txtAmount.Text
        txtAmount.Text = conv.ConvertNumberToWords(amt)
    End Sub
End Class