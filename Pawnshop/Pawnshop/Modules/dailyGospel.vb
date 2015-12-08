Imports System.Text
Imports System.Net
Imports System.IO
Imports System.Text.RegularExpressions

Module dailyGospel

    Private Sub Scrape()
        Try
            Dim url As String = "http://dailygospel.org/M/AM/"
            Dim strOutput As String
            Dim netResponse As WebResponse
            Dim netRequest As WebRequest = HttpWebRequest.Create(url)
            Console.WriteLine("Extracting...")

            netResponse = netRequest.GetResponse
            Using sr As New StreamReader(netResponse.GetResponseStream)
                strOutput = sr.ReadToEnd
                sr.Close()
            End Using

        Catch ex As Exception

        End Try
    End Sub

End Module
