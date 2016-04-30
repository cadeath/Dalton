Imports DeathCodez.Security
Imports System.Security.Cryptography
Imports System.Text

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

    Friend Function GetMD5(obj As Object) As String
        Dim tmpFile As String = System.IO.Path.GetTempPath() & "eskiegwapo"
        If System.IO.File.Exists(tmpFile) Then System.IO.File.Delete(tmpFile)

        Dim fsEsk As New System.IO.FileStream(tmpFile, IO.FileMode.CreateNew)
        Dim esk As New Runtime.Serialization.Formatters.Binary.BinaryFormatter
        esk.Serialize(fsEsk, obj)

        fsEsk.Close()


        System.IO.File.Delete(tmpFile)
    End Function

End Module
