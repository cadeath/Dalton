Imports System.IO

Module util

    Friend Const FILENAME As String = "Aerauxel.ini"

    ''' <summary>
    ''' This function has two arguments.
    ''' declaraton UseShellExecute as boolean and RedirectStandardOutput as boolean.
    ''' </summary>
    ''' <param name="app">app is the parameter that hold nonmodifiable value.</param>
    ''' <param name="args">args is the parameter that hold nonmodifiable value.</param>
    ''' <returns>return soutput after reading every transaction.</returns>
    ''' <remarks></remarks>
    Friend Function CommandPrompt(ByVal app As String, ByVal args As String) As String
        If Not System.IO.File.Exists(app) Then _
            Return Nothing

        Dim ext As String = app.Substring(app.Length - 3)
        If Not app.Substring(app.Length - 3).ToLower = "exe" Then
            Return Nothing
        End If

        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(app, args)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo
        'oProcess.StartInfo.Verb = "runas"

        oProcess.Start()
        oProcess.WaitForExit()
        Console.WriteLine("Command executed")

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

    Friend Sub runInSilent(cmd_file As String, Optional dest As String = "", Optional logFilename As String = "")
        Dim args As String = "/SILENT" & IIf(dest = "", "", " /DIR=""" & dest & """") & IIf(logFilename <> "", " /LOG=""" & logFilename & """", "")
        CommandPrompt(cmd_file, args)

        isFinished = True
        Console.WriteLine("Completed")
    End Sub

    Friend Sub backupFile(filename As String, Optional isRestore As Boolean = False)
        If isRestore Then
            If System.IO.File.Exists(filename) Then System.IO.File.Delete(filename)

            If System.IO.File.Exists("_" & filename) Then _
            My.Computer.FileSystem.RenameFile("_" & filename, filename)
        Else
            If System.IO.File.Exists("_" & filename) Then System.IO.File.Delete("_" & filename)

            If System.IO.File.Exists(filename) Then _
            My.Computer.FileSystem.RenameFile(filename, "_" & filename)
        End If
    End Sub

    Friend Function GetFilename_URL(str As String) As String
        Return str.Split("/")(str.Split("/").Count - 1)
    End Function

    Friend Function GetValue_Key(ht As Hashtable, key As String) As String
        For Each dt As DictionaryEntry In ht
            If dt.Key = key Then
                Return dt.Value
            End If
        Next

        Return Nothing
    End Function

    Friend Function PathOnly(str As String) As String
        Dim lastIdx As Integer = str.LastIndexOf("/")
        Return str.Substring(0, lastIdx)
    End Function

    Friend Sub SystemInitialization()
        Dim configFile As New IniFile

        If Not File.Exists(FILENAME) Then
            File.Create(FILENAME).Dispose()

            With configFile
                .Load(FILENAME)
                .AddSection("Server").AddKey("Host").Value = deploy.HOST
                .Save(FILENAME)
            End With
        Else
            configFile.Load(FILENAME)

            With configFile
                deploy.HOST = .GetSection("Server").GetKey("Host").Value
            End With
        End If
    End Sub

    Friend Sub Remove_Shortcut()
        Dim desktopPath As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim programPath As String = ""


        For Each Icon As String In Directory.GetFiles(desktopPath)
            If Icon.ToLower.EndsWith(".lnk") Then
                Dim lnkPath As String = GetTargetPath(Icon)
                Dim fileName As String = lnkPath.Split("\")(lnkPath.Split("\").Count - 1)
                If fileName = deploy.EXEFILE.Replace("/", "").Replace("\", "") Then
                    deleteFile(Icon)
                    Console.WriteLine("Icon deleted - " & Icon)
                End If
            End If
        Next

        desktopPath = System.Environment.GetFolderPath(Environment.SpecialFolder.CommonDesktopDirectory)
        For Each Icon As String In Directory.GetFiles(desktopPath)
            If Icon.ToLower.EndsWith(".lnk") Then
                Dim lnkPath As String = GetTargetPath(Icon)
                Dim fileName As String = lnkPath.Split("\")(lnkPath.Split("\").Count - 1)
                If fileName = deploy.EXEFILE.Replace("/", "").Replace("\", "") Then
                    deleteFile(Icon)
                    Console.WriteLine("Icon deleted - " & Icon)
                End If
            End If
        Next
    End Sub

    Private Sub deleteFile(fullPath As String)
        File.Delete(fullPath)
    End Sub

    Private Function GetTargetPath(ByVal FileName As String)
        Dim Obj As Object
        Obj = CreateObject("WScript.Shell")

        Dim Shortcut As Object
        Shortcut = Obj.CreateShortcut(FileName)
        GetTargetPath = Shortcut.TargetPath
    End Function

#Region "Log Module"
    Const LOG_FILE As String = "syslog.txt"
    Private Sub CreateLog()
        Dim fsEsk As New System.IO.FileStream(LOG_FILE, IO.FileMode.CreateNew)
        fsEsk.Close()
    End Sub

    Friend Sub Log_Report(ByVal str As String)
        If Not System.IO.File.Exists(LOG_FILE) Then CreateLog()

        Dim recorded_log As String = _
            String.Format("[{0}] ", Now.ToString("MM/dd/yyyy HH:mm:ss")) & str

        Dim fs As New System.IO.FileStream(LOG_FILE, IO.FileMode.Append, IO.FileAccess.Write)
        Dim fw As New System.IO.StreamWriter(fs)
        fw.WriteLine(recorded_log)
        fw.Close()
        fs.Close()
        Console.WriteLine("Recorded")
    End Sub
#End Region
End Module
