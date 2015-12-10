Module newSetup


    Friend Function CheckSystem() As Boolean
        If IsDBNull(GetOption("BranchCode")) Then Return False
        If GetOption("BranchCode") = "" Then Return False
        Return True
    End Function

End Module
