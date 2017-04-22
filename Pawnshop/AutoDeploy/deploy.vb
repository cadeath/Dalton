Imports System
Imports System.IO
Imports System.Net
Imports System.Xml

Module deploy

    Const DATABASE As String = "W3W1LH4CKU.FDB"     'DATABASE NAME
    Const CONFIG As String = "disconfig.xml"        'CONFIG FILE
    Const TMP As String = "tmp"                     'TEMPORARY FOLDER
    Const HOST As String = "http://192.164.0.118/"  'REMOTE HOST
    Const EXEFILE As String = "/pawnshop.exe"
    Const SYSLOG As String = "syslog.txt"
    Const BACKUPBAT As String = "backup.bat"

    Friend pbDownload As ProgressBar                ' Progress bar for effects
    Friend lblStatus As Label                       ' Display the status
    Friend btnOnHold As Button                      ' Buttong that will be HOLD while everything is not finish
    Friend dirdInstallPath As New FolderBrowserDialog ' Path where to be install

    Friend isFinished As Boolean = True
    Friend CurrentVersion As Version
    Private onDownload As Boolean = False
    Private installPath As String

    Private updateProcedure As Procedure
    Enum Procedure As Integer
        Idle = 0
        Installer = 1
        Patch = 2

        None = 9
    End Enum

    Private stablePath As String
    Private programPath As String
    Private configType As String
    Private url_hash As Hashtable
    Private mainDIR = Directory.GetCurrentDirectory

    Friend Sub Setup()

        btnOnHold.Enabled = False
        LoadPath()

        readConfig_v2(HOST & CONFIG)

        While Not isFinished
            Application.DoEvents()
        End While

        btnOnHold.Enabled = True
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Console.WriteLine("Path: " & readValue)

        ' REMOVE ON FINAL
        ' THIS IS TO TEST FRESH INSTALL
        ' AUTO UNINSTALL
        'If readValue <> "" Then
        '    UninstallTMP(readValue)
        '    readValue = ""
        'End If
        ' --END - ROF --

        If readValue = "" Then
            Console.WriteLine("No Value")
            updateProcedure = Procedure.Installer
        Else
            updateProcedure = Procedure.Idle
            programPath = readValue
        End If
    End Sub

    Private Sub UninstallTMP(src As String)
        ChDir(src)
        CommandPrompt("unins000.exe", "/SILENT")
        ResetDIR()
    End Sub

    Private Sub backup_Everything(Optional isRestore As Boolean = False)
        ChDir(programPath)
        If isRestore Then
            backupFile(DATABASE, True)
            backupFile(BACKUPBAT, True)
            backupFile(SYSLOG, True)
        Else
            backupFile(DATABASE)
            backupFile(BACKUPBAT)
            backupFile(SYSLOG)
        End If
        ResetDIR()
    End Sub

    Private Sub readConfig_v2(src As String)
        Dim m_xmld As New XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode

        Dim new_version As Version

        m_xmld = New XmlDocument
        Try
            m_xmld = New XmlDocument
            m_xmld.XmlResolver = Nothing
            m_xmld.Load(src)
        Catch ex As Exception
            If ex.ToString.Contains("Unable to connect to the remote server") Then
                Console.WriteLine("Server is down!")
            Else
                Console.WriteLine(ex.ToString)
            End If
            Exit Sub
        End Try

        m_nodelist = m_xmld.SelectNodes("/dis")
        stablePath = m_nodelist.Item(0).ChildNodes(1).InnerText
        new_version = Version.Parse(m_nodelist.Item(0).Attributes.GetNamedItem("version").Value)

        Console.WriteLine("Latest Version: " & stablePath)

        If updateProcedure = Procedure.Idle Then
            ' Execute Patch or Install

            Dim exe_path As String = programPath & EXEFILE
            Dim current_version As Version = GetExeVersion(exe_path)
            ' Version Checker
            Console.WriteLine("Exe Path: " & exe_path)
            Console.WriteLine("Exe Version: " & current_version.ToString)
            Console.WriteLine("New Version: " & new_version.ToString)
            Console.WriteLine("Compare: " & new_version.CompareTo(current_version))


            If new_version.CompareTo(current_version) > 0 Then
                ' Checking Procedure to be executed
                Dim version_found As Boolean = False
                Dim DISversions = m_nodelist.Item(0).ChildNodes(0).ChildNodes
                Dim disVersionFiles As XmlNode = Nothing

                For Each vr As XmlNode In DISversions
                    Console.WriteLine(String.Format("{0} - {1}", vr.Attributes.GetNamedItem("version").Value, vr.Attributes.GetNamedItem("type").Value))
                    Dim browse_version As Version = Version.Parse(vr.Attributes.GetNamedItem("version").Value)
                    If browse_version.CompareTo(current_version) = 0 Then
                        version_found = True
                        Select Case vr.Attributes.GetNamedItem("type").Value
                            Case "patch"
                                updateProcedure = Procedure.Patch
                                disVersionFiles = vr.Item(0)
                            Case "install"
                                updateProcedure = Procedure.Installer
                        End Select
                        Exit For
                    End If
                Next

                If Not version_found Then
                    MsgBox(String.Format("VERSION {0} IS NOT FOUND IN THE CONFIGURATION FILE", current_version.ToString) + vbCrLf + "CONTACT YOUR MIS DEPARTMENT", MsgBoxStyle.Critical, "PATCH ERROR")
                    Exit Sub
                End If

                ' FOR PATCH
                If updateProcedure = Procedure.Patch Then
                    For Each url As XmlNode In disVersionFiles
                        Console.WriteLine(url.LocalName & " - " & url.InnerText)
                    Next
                End If

                ' FOR INSTALL
                If updateProcedure = Procedure.Installer Then
                    Dim stable_exefilename As String = stablePath.Split("/")(stablePath.Split("/").Count - 1)

                    download_File(stablePath)

                    waitingToFinish_download()
                    backup_Everything()

                    ' UNINSTALLING
                    Console.WriteLine(programPath)
                    ChDir(programPath)
                    runInSilent("unins000.exe", , "UNINSTALLLOG.log")
                    ResetDIR()

                    While Not CleaningFolder(programPath)
                        Application.DoEvents()
                    End While

                    ' INSTALLING
                    ChDir(mainDIR & "/" & TMP)
                    runInSilent(stable_exefilename, programPath, "INSTALL.log")
                    ResetDIR()

                    backup_Everything(True)
                End If
            Else
                Console.WriteLine("SAME VERSION! NO NEW UPATES")
            End If
        ElseIf updateProcedure = Procedure.Installer Then
            ' Execute Fresh Install
            download_File(stablePath)

            dirdInstallPath.ShowDialog()
            installPath = dirdInstallPath.SelectedPath
        End If

        waitingToFinish_download()

        If updateProcedure = Procedure.Installer Then
            ChDir(TMP)
            runInSilent(stablePath.Split("/")(stablePath.Split("/").Count - 1), installPath, "INSTALL.log")
            ResetDIR()
        End If
    End Sub

    Private Sub download_File(src As String, Optional dst As String = "")
        If onDownload Then Exit Sub

        If Not System.IO.Directory.Exists(TMP) Then _
            System.IO.Directory.CreateDirectory(TMP)

        If dst = "" Then
            Dim cnt As Integer = src.Split("/").Count - 1
            dst = TMP & "/" & src.Split("/")(cnt)
        End If

        If System.IO.File.Exists(dst) Then _
            System.IO.File.Delete(dst)

        onDownload = True
        Try
            Dim dlFile As New WebClient

            If Not pbDownload Is Nothing Or Not lblStatus Is Nothing Then
                AddHandler dlFile.DownloadFileCompleted, AddressOf dlFile_DownloadFileCompleted
                AddHandler dlFile.DownloadProgressChanged, AddressOf dlFile_DownloadProgressChanged
            End If

            dlFile.DownloadFileAsync(New Uri(src), dst)

            displayStatus("Downloading " & src.Split("/")(src.Split("/").Count - 1) & "...")
        Catch ex As Exception
            onDownload = False
        End Try
    End Sub

    Private Sub dlFile_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        If pbDownload Is Nothing Then Exit Sub

        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString)
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString)
        Dim percentage As Double = bytesIn / totalBytes * 100

        pbDownload.Value = CInt(Math.Truncate(percentage).ToString)
    End Sub

    Private Sub dlFile_DownloadFileCompleted(sender As Object, e As ComponentModel.AsyncCompletedEventArgs)
        onDownload = False

        If e.Error Is Nothing Then
            displayStatus("Download Completed.")
            Console.WriteLine("Download Completed.")
        Else
            ' TODO
            ' Log Report to record possible errors
        End If
    End Sub

    Friend Function GetMainExe() As String
        If programPath = Nothing Then
            Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)
            programPath = readValue
        End If
        Return programPath & EXEFILE
    End Function

    Private Sub waitingToFinish_download()
        While onDownload
            Application.DoEvents()
        End While
    End Sub

    Private Sub ResetDIR()
        ChDir(mainDIR)
    End Sub
End Module