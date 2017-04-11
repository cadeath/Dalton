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
        Dim m_xmlr As XmlTextReader
        'Create the XML Reader
        m_xmlr = New XmlTextReader(src)
        'Disable whitespace so that you don't have to read over whitespaces
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None
        'read the xml declaration and advance to family tag
        m_xmlr.Read()
        'read the family tag
        m_xmlr.Read()
        'Load the Loop
        While Not m_xmlr.EOF
            'Go to the name tag
            m_xmlr.Read()
            'if not start element exit while loop
            If Not m_xmlr.IsStartElement() Then
                Exit While
            End If
            'Get the Gender Attribute Value
            Dim installType = m_xmlr.GetAttribute("type")
            'Read elements firstname and lastname
            m_xmlr.Read()
            'Get the firstName Element Value
            Dim fileVersion = m_xmlr.ReadElementString("version")
            'Write Result to the Console
            Console.WriteLine(String.Format("{0} - {1}", installType, fileVersion))
            Console.Write(vbCrLf)
        End While
        'close the reader
        m_xmlr.Close()
    End Sub
End Module