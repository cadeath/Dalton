Module updateTable

    Sub ExportConfig(url As String, serialDS As DataSet)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, serialDS)
        fsEsk.Close()
    End Sub

    Function FileChecker(url As String) As DataTable
        Dim fs As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim serialDS As DataSet
        Try
            serialDS = bf.Deserialize(fs)
        Catch ex As Exception
            MsgBox("It seems the file is being tampered.", MsgBoxStyle.Critical)
            fs.Close()
            Return Nothing
        End Try
        fs.Close()

        Return serialDS.Tables(0)
    End Function

End Module