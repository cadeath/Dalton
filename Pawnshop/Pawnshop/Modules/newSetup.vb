Module newSetup


    Friend Function CheckSystem() As Boolean
        If IsDBNull(GetOption("BranchCode")) Then Return False
        If GetOption("BranchCode") = "" Then Return False
        Return True
    End Function

    Friend Function ConfiguringDB() As Boolean
        If Not System.IO.File.Exists(dbName) Then
            dbName = "W3W1LH4CKU.FDB"
        End If

        Try
            Dim mySql As String = "SELECT * FROM TBL_GAMIT"
            Dim ds As DataSet = LoadSQL(mySql)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Connection Problem")
            Return False
        End Try

        Return True
    End Function
End Module
