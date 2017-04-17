Imports System
Imports System.Net
Imports System.Xml

Module deploy

    Const DATABASE As String = "W3W1LH4CKU.FDB"
    Const PATH As String = "installer.xml"
    Const TMP As String = "tmp"

    Friend pbDownload As ProgressBar
    Friend lblStatus As Label

    Friend isFinished As Boolean = True
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
        'src = PATH
        isFinished = False
        Try
            Dim str As String = ""
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
                        str = "Download " & url.innerText & "..."
                        Console.WriteLine(str)

                        displayStatus(str)
                        download_File(url.innerText)

                        ' One download at a time
                        While onDownload
                            Application.DoEvents()
                        End While
                    Next

                Case "patch"
                    'Redownload the xml
                    download_File(src)
                    m_node = m_nodelist.Item(0).ChildNodes(0)

                    'Dim url = m_node.ChildNodes(0).InnerText
                    'download_File(url)

                    ' TODO
                    ' Identify if it is for download only or Include Parent DIR

                    For Each url As XmlNode In m_node
                        If url.LocalName.Contains("-dir") Then
                            Dim fileName = url.Attributes.GetNamedItem("src").Value
                            Dim fSrc = url.Attributes.GetNamedItem("src").Value
                            Dim fDst = url.InnerText

                            fileName = fileName.Split("/")(fileName.Split("/").Count - 1)
                            If Not System.IO.File.Exists(TMP & "/" & fileName) Then _
                                download_File(fSrc, TMP & "/" & url.InnerText)

                            'Create DIR
                            Dim splitCnt As Integer = fDst.Split("/").Count - 1
                            Dim splitI As Integer = 0
                            For Each srcDir In fDst.Split("/")
                                If Not System.IO.Directory.Exists(srcDir) And splitI <> splitCnt Then _
                                    System.IO.Directory.CreateDirectory(srcDir)

                                If splitI = splitCnt Then
                                    System.IO.File.Move(TMP & "/" & fileName, fDst)
                                End If
                                splitI += 1
                            Next
                        Else
                            str = "Download " & url.InnerText & "..."
                            displayStatus(str)
                            download_File(url.InnerText)
                        End If

                        ' One download at a time
                        While onDownload
                            Application.DoEvents()
                        End While
                    Next

                    'For Each url In m_node
                    '    While onDownload
                    '        Application.DoEvents()
                    '    End While


                    '    Dim str As String = "Download " & url.innerText & "..."
                    '    Console.WriteLine(str)

                    '    displayStatus(str)
                    '    'download_File(url.innerText)
                    'Next
            End Select

        Catch ex As Exception
            If ex.ToString.Contains("No connection could be made because the target machine actively refused") Then
                Console.WriteLine("Unable to connect to the remote server")
                Exit Sub
            End If

            Console.WriteLine(ex.ToString)
        End Try
        isFinished = True
    End Sub

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
End Module