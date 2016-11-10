Public Class frmLoading

    Friend Sub Process(ByVal text As String)
        Application.DoEvents()
        lblProcess.Text = text
    End Sub
End Class