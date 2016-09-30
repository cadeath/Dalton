Public Class frm_PanelMultiline
    Private isNumber As Boolean
    Friend retID As Integer = 0

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtSearch.Text

        tmpResult = tmpResult.Replace(vbCr, " ").Replace(vbLf, " ")
            
        frmPawningItemNew.DisplayValue(tmpResult, retID)
        Me.Close()
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        'If isEnter(e) Then
        '    btnSubmit.PerformClick()
        'End If
    End Sub

    Private Sub frm_PanelMultiline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Clear()
        txtSearch.Focus()
        txtSearch.ScrollBars = ScrollBars.Vertical
    End Sub

End Class