Imports DeathCodez.Security

Module security

    Friend Function HashString(ByVal src As String) As String
        Return Encrypt(src)
    End Function

    Friend Function EncryptString(ByVal src As String) As String
        Return Encrypt(src)
    End Function

    Friend Function DecryptString(ByVal src As String) As String
        Return Decrypt(src)
    End Function

End Module
