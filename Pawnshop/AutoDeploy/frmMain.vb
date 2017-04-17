Public Class frmMain

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        btnStart.Enabled = False
        deploy.pbDownload = pbUpdate
        deploy.lblStatus = lblUpdate
        'deploy.ReadingConfig("http://localhost/installer.xml")
        'deploy.ReadingConfig("http://localhost/patch.xml")
        deploy.ReadingConfig("http://localhost/disconfig.xml")

        While Not deploy.isFinished
            Application.DoEvents()
        End While

        btnStart.Enabled = True
    End Sub
End Class
