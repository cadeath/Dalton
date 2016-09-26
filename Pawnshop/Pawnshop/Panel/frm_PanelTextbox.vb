Public Class frm_PanelTextbox

    Private isNumber As Boolean

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtSearch.Text
        With frmPawningItemNew.lvSpec
            .SelectedItems(0).SubItems(4).Text = tmpResult
        End With
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isNumber Then DigitOnly(e)
        If isEnter(e) Then
            btnSubmit.PerformClick()
        End If
    End Sub

    Private Sub frm_PanelTextbox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Clear()
        txtSearch.Focus()
        If frmPawningItemNew.lvSpec.FocusedItem.SubItems(3).Text = "String" Then
            isNumber = False
        Else
            isNumber = True
        End If
    End Sub

End Class