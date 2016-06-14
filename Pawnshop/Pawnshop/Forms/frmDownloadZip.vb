Imports System.Net
Imports System.IO
Imports System.IO.Compression
Public Class frmDownloadZip
    Private Sub Downloader()
        Dim ZipLocation As String = My.Application.Info.DirectoryPath & "\peace.zip"
        Dim ZipUrl As String = "https:\\www.colorado.edu/conflict/peace/download/peace.zip"
        'sample url--https:\\www.colorado.edu/conflict/peace/download/peace.zip
        Dim webUri = New Uri(ZipUrl)
        MessageBox.Show("Downloading Please wait.....")
        Using client As New WebClient
            client.DownloadFile(webUri, ZipLocation)
        End Using
        MessageBox.Show("Zip file Downloaded Successfully")
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Downloader()
    End Sub
End Class