Public Class frmMain

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        deploy.pbDownload = pbUpdate
        deploy.lblStatus = lblUpdate
        deploy.btnOnHold = btnStart
        deploy.Setup()

        While Not deploy.isFinished
            Application.DoEvents()
        End While

        Dim app As String = GetMainExe()

        Process.Start(app)
        End
    End Sub
End Class
