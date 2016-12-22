Module Interest_Config

    Dim ConfigName As String = "Interest Scheme"

    Friend Sub Export_Config(ByVal url As String)
        Dim mySql As String = "SELECT * FROM TBLINTSCHEMES"
        Dim tblINt As DataSet = LoadSQL(mySql, "TBLINTSCHEMES")
        mySql = "SELECT * FROM TBLINTSCHEME_DETAILS"
        Dim tblIntSchDetails As DataSet = LoadSQL(mySql, "TBLINTSCHEME_DETAILS")

        Console.WriteLine("Count INT: " & tblINt.Tables(0).Rows.Count)
        Console.WriteLine("Count DET: " & tblIntSchDetails.Tables(0).Rows.Count)

        Dim otherTBL As New DataTable
        otherTBL = tblIntSchDetails.Tables("TBLINTSCHEME_DETAILS")
        tblINt.Tables.Add(otherTBL.Copy)

        ExportCIR(url, tblINt)
    End Sub

    Friend Sub Load_Config(ByVal url As String)
        Dim fs As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim serialDS As DataSet
        Try
            serialDS = bf.Deserialize(fs)
        Catch ex As Exception
            MsgBox("It seems the file is being tampered.", MsgBoxStyle.Critical)
            fs.Close()
            Exit Sub
        End Try
        fs.Close()

        Dim ds As DataSet = serialDS
        For Each tbl As DataTable In ds.Tables
            Console.WriteLine(String.Format("Name: {0} |Count: {1}", tbl.TableName, tbl.Rows.Count))
        Next
    End Sub

    Private Sub ExportCIR(ByVal url As String, ByVal serialDS As DataSet)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, serialDS)
        fsEsk.Close()
    End Sub


End Module
