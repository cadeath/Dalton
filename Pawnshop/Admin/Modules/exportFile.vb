Module exportFile

    Friend Sub ExportConfig(ByVal url As String, ByVal data As DataSet)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)
        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)

        data.Tables.Add(VerificationTable(data))

        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, data)
        fsEsk.Close()
    End Sub

    Friend Function ImportConfig(ByVal url As String) As DataSet
        If Not System.IO.File.Exists(url) Then Return Nothing

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

        Dim ds As New DataSet
        Try
            ds = bf.Deserialize(fsEsk)
        Catch ex As Exception
            Console.WriteLine("It seems the file is being tampered.")
            Return Nothing
        End Try
        fsEsk.Close()

        Return ds
    End Function

    Friend Function VerificationTable(ByVal ds As DataSet) As DataTable
        Dim tb As New DataTable
        tb = New DataTable("Verify")
        tb.Columns.Add("Key")
        tb.Columns.Add("Value")
        tb.Rows.Add("date", Now().Date)

        Dim st As New System.IO.MemoryStream
        Dim rFormat As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        rFormat.Serialize(st, ds)

        Dim s As String = System.Text.ASCIIEncoding.ASCII.GetString(st.GetBuffer)
        tb.Rows.Add("Eskie", security.HashString(s))

        Return tb
    End Function

    Friend Sub CreateEsk(ByVal url As String, ByVal data As Hashtable)
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.CreateNew)
        Dim refNum As String, transDate As String, branchCode As String, amount As Double, remarks As String
        Dim checkSum As String

        With data
            refNum = data(0) '0 - as RefNum
            transDate = data(1) 'transDate
            branchCode = data(2) 'branchCode
            amount = data(3) 'Amount
            remarks = data(4) 'Remarks
        End With
        checkSum = HashString(refNum & transDate & branchCode & amount & remarks)
        data.Add(5, checkSum) 'CheckSum

        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, data)
        fsEsk.Close()
    End Sub

    Friend Function LoadEsk(ByVal url) As Hashtable
        If Not System.IO.File.Exists(url) Then Return Nothing

        Dim fsEsk As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter

        Dim hashTable As New Hashtable
        Try
            hashTable = bf.Deserialize(fsEsk)
        Catch ex As Exception
            Console.WriteLine("It seems the file is being tampered.")
            Return Nothing
        End Try
        fsEsk.Close()

        Dim isValid As Boolean = False
        If hashTable(5) = security.HashString(hashTable(0) & hashTable(1) & hashTable(2) & hashTable(3) & hashTable(4)) Then
            isValid = True
        End If

        If isValid Then Return hashTable
        Return Nothing
    End Function
End Module
