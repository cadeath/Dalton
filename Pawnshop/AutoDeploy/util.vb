Module util
    ''' <summary>
    ''' This function has two arguments.
    ''' declaraton UseShellExecute as boolean and RedirectStandardOutput as boolean.
    ''' </summary>
    ''' <param name="app">app is the parameter that hold nonmodifiable value.</param>
    ''' <param name="args">args is the parameter that hold nonmodifiable value.</param>
    ''' <returns>return soutput after reading every transaction.</returns>
    ''' <remarks></remarks>
    Friend Function CommandPrompt(ByVal app As String, ByVal args As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(app, args)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo
        oProcess.StartInfo.Verb = "runas"

        oProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using

        Return sOutput
    End Function

    Friend Function GetExeVersion(src As String) As Version
        If CurrentVersion Is Nothing Then _
            CurrentVersion = Version.Parse(FileVersionInfo.GetVersionInfo(src).FileVersion)

        Return CurrentVersion
    End Function

    Friend Sub displayStatus(str As String)
        If lblStatus Is Nothing Then Exit Sub
        lblStatus.Text = str
    End Sub

    Friend Sub runInSilent(cmd_file As String)
        CommandPrompt(cmd_file, "/LOG=""AutoLog.log"" /SILENT")
        isFinished = True
        Console.WriteLine("Completed")
    End Sub
End Module
