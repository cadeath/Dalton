' VERSION 1.1
'  - Include GetFileMD5 for file integrity check

Imports DeathCodez.Security
Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Security.Cryptography

Module security

    Dim prng As New Random
    Const minCH As Integer = 15 'minimum chars in random string
    Const maxCH As Integer = 20 'maximum chars in random string

    Const randCH As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"


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

    Friend Function GetMD5(ds As DataSet) As String
        Dim serialize As DataContractSerializer = New DataContractSerializer(GetType(DataSet))
        Dim MemoryStream As New MemoryStream
        Dim xmlW As XmlDictionaryWriter
        xmlW = XmlDictionaryWriter.CreateBinaryWriter(MemoryStream)
        serialize.WriteObject(MemoryStream, ds)

        Dim sd As Byte() = MemoryStream.ToArray
        Dim MD5 As New MD5CryptoServiceProvider
        Dim md5Byte As Byte() = MD5.ComputeHash(sd)

        Return Convert.ToBase64String(md5Byte)
    End Function

    Friend Function GetFileMD5(ByVal url As String) As String
        Dim fileByte() As Byte
        Dim fs As FileStream = File.OpenRead(url)
        fs.Position = 0

        fileByte = MD5.Create.ComputeHash(fs)

        Return Convert.ToBase64String(fileByte)
    End Function


    Friend Function FileName() As String
        Dim sb As New System.Text.StringBuilder
        For i As Integer = 1 To prng.Next(minCH, maxCH + 1)
            sb.Append(randCH.Substring(prng.Next(0, randCH.Length), 1))
        Next
        Return sb.ToString()
    End Function
End Module
