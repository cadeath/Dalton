Imports System
Imports System.Xml

Module deploy

    Const DATABASE As String = "W3W1LH4CKU.FDB"

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

    Friend Sub ParseXML(src As String)
        Try
            Dim m_xmld As XmlDocument
            Dim m_nodelist As XmlNodeList
            Dim m_node As XmlNode

            m_xmld = New XmlDocument
            m_xmld.Load(src)
            m_nodelist = m_xmld.SelectNodes("/dis")

            For Each m_node In m_nodelist
                Dim file_version = m_node.Attributes.GetNamedItem("version").Value
                Dim file_type = m_node.ChildNodes.Item(0).Attributes("type").Value
                Dim url = m_node.SelectNodes("file").Item(0).Value

                Console.WriteLine("Version: " & file_version)
                Console.WriteLine("Type: " & file_type)
                Console.WriteLine("URL: " & url)
            Next
        Catch ex As Exception
            Console.WriteLine(ex.ToString)
        End Try
    End Sub
End Module