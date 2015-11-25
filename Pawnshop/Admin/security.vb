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

    Friend Function BackupPassword(ByVal dt As Date, Optional ByVal salt As String = "220588") As String
        If Len(salt) < 6 Then MsgBox("Salt must be six digit", MsgBoxStyle.Critical) : Return "FAILED"

        Dim strDate As Double = dt.ToString("Mdyyyy")
        Dim curDay As Double = dt.ToString("dd")
        Dim code As String

        code = ((strDate + curDay) * 2) - salt

        Return code
    End Function

End Module
