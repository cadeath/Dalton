Public Class frmMain

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        deploy.ParseXML("sample.xml")
    End Sub
End Class
