Imports System
Imports System.Net
Imports System.Xml

Module deploy

    Const DATABASE As String = "W3W1LH4CKU.FDB"     'DATABASE NAME
    Const CONFIG As String = "disconfig.xml"        'CONFIG FILE
    Const TMP As String = "tmp"                     'TEMPORARY FOLDER
    Const HOST As String = "http://localhost/"      'REMOTE HOST
    Const EXEFILE As String = "/pawnshop.exe"

    Friend pbDownload As ProgressBar
    Friend lblStatus As Label
    Friend btnOnHold As Button

    Friend isFinished As Boolean = True
    Friend CurrentVersion As Version
    Private onDownload As Boolean = False

    Private updateProcedure As Procedure
    Enum Procedure As Integer
        Idle = 0
        Installer = 1
        Patch = 2

        None = 9
    End Enum

    Private stablePath As String
    Private programPath As String
    Private url_hash As Hashtable

    Friend Sub Setup()
        LoadPath()

        readConfig_v2(HOST & CONFIG)
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Console.WriteLine("Path: " & readValue)
        If readValue = "" Then
            Console.WriteLine("No Value")
            updateProcedure = Procedure.Installer
        Else
            updateProcedure = Procedure.Idle
            programPath = readValue
        End If
    End Sub

    Private Sub backup_Database(Optional isRestore As Boolean = False)
        If isRestore Then
            If Not System.IO.File.Exists("_" & DATABASE) Then Exit Sub
            If System.IO.File.Exists(DATABASE) Then
                My.Computer.FileSystem.DeleteFile(DATABASE)
            End If
            My.Computer.FileSystem.RenameFile("_" & DATABASE, DATABASE)
        Else
            If Not System.IO.File.Exists(DATABASE) Then Exit Sub
            My.Computer.FileSystem.RenameFile(DATABASE, "_" & DATABASE)
        End If
    End Sub

    Private Function GetExeVersion(src As String) As Version
        If CurrentVersion Is Nothing Then _
            CurrentVersion = Version.Parse(FileVersionInfo.GetVersionInfo(src).FileVersion)

        Return CurrentVersion
    End Function

    Private Sub readConfig_v2(src As String)
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        'Dim m_node As XmlNode

        Dim new_version As Version

        m_xmld = New XmlDocument
        m_xmld.Load(src)
        m_nodelist = m_xmld.SelectNodes("/dis")

        stablePath = m_nodelist.Item(0).ChildNodes(1).InnerText
        new_version = Version.Parse(m_nodelist.Item(0).Attributes.GetNamedItem("version").Value)

        Console.WriteLine("Installer: " & stablePath)
        Console.WriteLine("Latest Version: " & stablePath)

        If updateProcedure = Procedure.Idle Then
            ' Execute Patch or Install

            Dim exe_path As String = programPath & EXEFILE
            ' Version Checker
            Console.WriteLine("Exe Path: " & exe_path)
            Console.WriteLine("Exe Version: " & GetExeVersion(exe_path).ToString)

            ' Loading Files
            downloading_data(m_nodelist)
        ElseIf updateProcedure = Procedure.Installer Then
            ' Execute Fresh Install

            download_File(stablePath)
        End If

        While onDownload
            Application.DoEvents()
        End While

        If updateProcedure = Procedure.Installer Then
            runInSilent(TMP & "/" & stablePath.Split("/")(stablePath.PadLeft("/").Count - 1))

        End If
    End Sub

    Private Sub downloading_data(xml As XmlNodeList)
        Dim configType = xml.Item(0).ChildNodes.Item(0).Attributes.GetNamedItem("type").Value
        Dim fileNode = xml.Item(0).ChildNodes.Item(0).ChildNodes

        Select Case configType
            Case "patch"
                updateProcedure = Procedure.Patch
            Case "installer"
                updateProcedure = Procedure.Installer
        End Select

        url_hash = New Hashtable

        Console.WriteLine("Config: " & configType)
        For Each nd As XmlNode In fileNode
            Console.WriteLine(String.Format("{0} > {1}", nd.LocalName, nd.InnerText))
            url_hash.Add(nd.LocalName, nd.InnerText)
            If Not nd.LocalName.Contains("dir") Then
                download_File(nd.InnerText)
            End If

            While onDownload
                Application.DoEvents()
            End While
        Next
    End Sub


    'Private Sub ReadingConfig(src As String)
    '    'src = PATH
    '    isFinished = False
    '    Try
    '        Dim str As String = ""
    '        Dim m_xmld As XmlDocument
    '        Dim m_nodelist As XmlNodeList
    '        Dim m_node As XmlNode

    '        m_xmld = New XmlDocument
    '        m_xmld.Load(src)
    '        m_nodelist = m_xmld.SelectNodes("/dis")

    '        Dim m_version = m_nodelist.Item(0).Attributes.GetNamedItem("version").Value
    '        Dim m_type = m_nodelist.Item(0).ChildNodes.Item(0).Attributes.GetNamedItem("type").Value

    '        Console.WriteLine("Version: " & m_version)
    '        Console.WriteLine("Type: " & m_type)

    '        If Version.Parse(m_version).CompareTo(GetExeVersion("AutoDeploy.exe")) <= 0 Then _
    '            Exit Sub

    '        Select Case m_type
    '            Case "installer"
    '                m_node = m_nodelist.Item(0).ChildNodes(0)

    '                For Each url In m_node
    '                    str = "Download " & url.innerText & "..."
    '                    Console.WriteLine(str)

    '                    displayStatus(str)
    '                    download_File(url.innerText)

    '                    ' One download at a time
    '                    While onDownload
    '                        Application.DoEvents()
    '                    End While
    '                Next

    '            Case "patch"
    '                'Redownload the xml
    '                download_File(src)
    '                m_node = m_nodelist.Item(0).ChildNodes(0)

    '                For Each url As XmlNode In m_node
    '                    If url.LocalName.Contains("-dir") Then
    '                        Dim fileName = url.Attributes.GetNamedItem("src").Value
    '                        Dim fSrc = url.Attributes.GetNamedItem("src").Value
    '                        Dim fDst = url.InnerText

    '                        fileName = fileName.Split("/")(fileName.Split("/").Count - 1)
    '                        If Not System.IO.File.Exists(TMP & "/" & fileName) Then _
    '                            download_File(fSrc, TMP & "/" & url.InnerText)

    '                        'Create DIR
    '                        Dim splitCnt As Integer = fDst.Split("/").Count - 1
    '                        Dim splitI As Integer = 0
    '                        For Each srcDir In fDst.Split("/")
    '                            If Not System.IO.Directory.Exists(srcDir) And splitI <> splitCnt Then _
    '                                System.IO.Directory.CreateDirectory(srcDir)

    '                            If splitI = splitCnt Then
    '                                System.IO.File.Move(TMP & "/" & fileName, fDst)
    '                            End If
    '                            splitI += 1
    '                        Next
    '                    Else
    '                        str = "Download " & url.InnerText & "..."
    '                        displayStatus(str)
    '                        download_File(url.InnerText)
    '                    End If

    '                    ' One download at a time
    '                    While onDownload
    '                        Application.DoEvents()
    '                    End While
    '                Next

    '        End Select

    '    Catch ex As Exception
    '        If ex.ToString.Contains("No connection could be made because the target machine actively refused") Then
    '            Console.WriteLine("Unable to connect to the remote server")
    '            Exit Sub
    '        End If

    '        Console.WriteLine(ex.ToString)
    '    End Try
    '    isFinished = True
    'End Sub

    Private Sub displayStatus(str As String)
        If lblStatus Is Nothing Then Exit Sub
        lblStatus.Text = str
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

    Private Sub runInSilent(cmd_file As String)
        CommandPrompt(cmd_file, "/LOG=""AutoLog.log"" /SILENT")
        isFinished = True
        Console.WriteLine("Completed")
    End Sub
End Module