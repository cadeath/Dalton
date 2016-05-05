Imports System
Imports System.IO
Imports System.Xml
Imports System.Xml.Linq
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Security.Cryptography

Module update_interest

    Private mySql As String
    Private fillData As String
    Private ds As DataSet

    Friend Sub doPatchDB(url As String)
        database.dbName = url

        mySql = "SELECT DAYFROM, DAYTO, ITEMTYPE, INTEREST, PENALTY FROM TBLINT WHERE STATUS = 0"
    End Sub

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
End Module
