Public Class devClient

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmClient.SearchSelect(txtSearch.Text, Me)
        frmClient.Show()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnBrowse.PerformClick()
        End If
    End Sub

    Friend Sub GetClient(ByVal cl As Client)
        txtID.Text = cl.ID
        txtName.Text = cl.FirstName
    End Sub

    Private Sub devClient_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not frmClient.GetClient Is Nothing Then
            GetClient(frmClient.GetClient)
        End If
    End Sub
End Class