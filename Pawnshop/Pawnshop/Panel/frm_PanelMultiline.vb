Public Class frm_PanelMultiline

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtSearch.Text
            With frmPawningItemNew.lvSpec
            .SelectedItems(0).SubItems(4).Text = tmpResult
            End With
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub frm_PanelMultiline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Clear()
        txtSearch.Focus()
        txtSearch.ScrollBars = ScrollBars.Vertical
    End Sub
   
End Class