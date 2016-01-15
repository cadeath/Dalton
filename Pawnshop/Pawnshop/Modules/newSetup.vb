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

        Return True
    End Function
End Module
