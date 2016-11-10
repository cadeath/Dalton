Public Class frmLoading

    Friend Sub Process(ByVal text As String)
        Application.DoEvents()
        lblProcess.Text = text
    End Sub

    Private Sub frmLoading_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class