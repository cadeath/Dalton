Public Class frmMain

    Private Sub btnStart_Click(sender As System.Object, e As System.EventArgs) Handles btnStart.Click
        ' Initialization
        deploy.pbDownload = pbUpdate
        deploy.lblStatus = lblUpdate
        deploy.btnOnHold = btnStart

        deploy.Setup()

        While Not deploy.isFinished
            Application.DoEvents()
        End While

        Dim app As String = GetMainExe()
        Dim lastFwdSl As Integer = app.LastIndexOf("/")
        Dim ch As String = app.Substring(0, lastFwdSl)
        Dim lastExe As String = app.Substring(lastFwdSl + 1)

        If ch = "" Then
            MsgBox("FAILED TO DOWNLOAD AND RUN APPLICATION", MsgBoxStyle.Critical, "ERROR 00000")
            Exit Sub
        End If
        ChDir(ch)
        Process.Start(lastExe)
        End
    End Sub

    Private Sub DirTest()
        Dim readValue = _
            My.Computer.Registry.GetValue( _
                "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", _
                "InstallPath", Nothing)

        If readValue = Nothing Then Exit Sub
        If Not System.IO.Directory.Exists(readValue & "/ESKIE/CIRRUS") Then
            System.IO.Directory.CreateDirectory(readValue & "/ESKIE/CIRRUS")
        End If
    End Sub
End Class
