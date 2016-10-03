Public Class frm_PanelMultiline
    Private isNumber As Boolean
    Friend retID As Integer = 0


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim tmpResult As String = txtSearch.Text

        tmpResult = tmpResult.Replace(vbCr, " ").Replace(vbLf, " ")

        frmPawningItemNew.DisplayValue(tmpResult, retID)
        Me.Close()
    End Sub

    Friend Sub DisplaySpecs(str As String)
        GroupBox9.Text = str
    End Sub

    Private Sub frm_PanelMultiline_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearch.Clear()
        txtSearch.Focus()
        txtSearch.ScrollBars = ScrollBars.Vertical
    End Sub

End Class