Public Class frm_PanelMultiline

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtSearch.Text
        With dev_NewPawning.lvItem
            .SelectedItems(0).SubItems(3).Text = tmpResult
        End With
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub
End Class