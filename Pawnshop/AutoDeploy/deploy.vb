Imports System
Imports System.Net
Imports System.Xml

Module deploy

    Const DATABASE As String = "W3W1LH4CKU.FDB"
    Const PATH As String = "installer.xml"
    Const TMP As String = "tmp"

    Friend pbDownload As ProgressBar
    Friend lblStatus As Label

    Private onDownload As Boolean = False

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

    Private Function Get_DatabaseVersion() As String
        Dim myFileVersionInfo As FileVersionInfo = FileVersionInfo.GetVersionInfo(DATABASE)
        Return myFileVersionInfo.FileVersion
    End Function

    Friend Sub ReadingConfig(src As String)
        src = PATH

        'Try
        Dim m_xmld As XmlDocument
        Dim m_nodelist As XmlNodeList
        Dim m_node As XmlNode

        m_xmld = New XmlDocument
        m_xmld.Load(src)
        m_nodelist = m_xmld.SelectNodes("/dis")

        Dim m_version = m_nodelist.Item(0).Attributes.GetNamedItem("version").Value
        Dim m_type = m_nodelist.Item(0).ChildNodes.Item(0).Attributes.GetNamedItem("type").Value

        Console.WriteLine("Version: " & m_version)
        Console.WriteLine("Type: " & m_type)

        Select Case m_type
            Case "installer"
                m_node = m_nodelist.Item(0).ChildNodes(0)
                For Each url In m_node
                    While onDownload
                        Application.DoEvents()
                    End While

                    Dim str As String = "Download " & url.innerText & "..."
                    Console.WriteLine(str)

                    ' TODO
                    ' Download the URL installed
                    lblStatus.Text = str
                    download_File(url.innerText)
                Next
        End Select

        'Catch ex As Exception
        '    Console.WriteLine(ex.ToString)
        'End Try
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
            AddHandler dlFile.DownloadProgressChanged, AddressOf dlFile_DownloadProgressChanged
            AddHandler dlFile.DownloadFileCompleted, AddressOf dlFile_DownloadFileCompleted
            dlFile.DownloadFileAsync(New Uri(src), dst)

            lblStatus.Text = "Downloading " & src.Split("/")(src.Split("/").Count - 1) & "..."
        Catch ex As Exception
            onDownload = False
        End Try
    End Sub

    Private Sub dlFile_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs)
        Dim bytesIn As Double = Double.Parse(e.BytesReceived.ToString)
        Dim totalBytes As Double = Double.Parse(e.TotalBytesToReceive.ToString)
        Dim percentage As Double = bytesIn / totalBytes * 100

        pbDownload.Value = CInt(Math.Truncate(percentage).ToString)
    End Sub

    Private Sub dlFile_DownloadFileCompleted(sender As Object, e As DownloadDataCompletedEventArgs)
        onDownload = False
        lblStatus.Text = "Download Completed."
        Console.WriteLine("Download Completed.")
    End Sub
End Module