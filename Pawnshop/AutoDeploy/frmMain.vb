Public Class frmMain

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False
        deploy.pbDownload = pbUpdate
        deploy.lblStatus = Label1
        'deploy.ReadingConfig("http://localhost/installer.xml")
        deploy.ReadingConfig("http://localhost/patch.xml")

        Button1.Enabled = True
    End Sub
End Class
