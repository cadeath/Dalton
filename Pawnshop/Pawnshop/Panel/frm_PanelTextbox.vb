Public Class frm_PanelTextbox

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtSearch.Text
        With frmPawningItemNew.lvSpec
            .SelectedItems(0).SubItems(3).Text = tmpResult
        End With
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub frm_PanelTextbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Clear()
        txtSearch.Focus()
    End Sub
End Class