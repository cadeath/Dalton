Imports System.IO
Imports System.Net
Imports System.Text

Module MrFaust

    Friend Sub Ping()
        
    End Sub

    Private Function SendRequest(ByVal uri As Uri, ByVal jsonDataBytes As Byte(), ByVal contentType As String, ByVal method As String) As String
        Dim req As WebRequest = WebRequest.Create(uri)
        req.ContentType = contentType
        req.Method = method
        req.ContentLength = jsonDataBytes.Length


        Dim stream = req.GetRequestStream()
        stream.Write(jsonDataBytes, 0, jsonDataBytes.Length)
        stream.Close()

        Dim response = req.GetResponse().GetResponseStream()

        Dim reader As New StreamReader(response)
        Dim res = reader.ReadToEnd()
        reader.Close()
        response.Close()

        Return res
    End Function
End Module
