Imports System.Threading
Public Class frmDownloadZip
    Dim wc As System.Net.WebClient

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        wc = New System.Net.WebClient
        AddHandler wc.DownloadProgressChanged, AddressOf OnDownloadProgressChanged
        AddHandler wc.DownloadFileCompleted, AddressOf OnDownloadFileCompleted
        wc.DownloadFileAsync(New Uri("https://wwww.dropbox.com/s/i4gf4pz5ovzeker/Advanced%20Converter.rar?dl=1"), Application.StartupPath & "\ " & "Advanced Converter.rar")
    End Sub
    Private Sub OnDownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        Dim totalsize As Long = e.TotalBytesToReceive
        Dim downloadedBytes As Long = e.BytesReceived
        Dim percentage As Integer = e.ProgressPercentage
        ProgressBar1.Value = e.ProgressPercentage
        Label1.Text = "%" & ProgressBar1.Value
        Label2.Text = "File Size: " & totalsize / 1024 / 1000 & "Mb"
        Label3.Text = "Downloaded: " & downloadedBytes / 1024 / 1000 & "Mb" & " of " & totalsize / 1024 / 1000 & "Mb"
    End Sub

    Private Sub OnDownloadFileCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.AsyncCompletedEventArgs)
        If e.Cancelled Then
            MsgBox("Download Cancelled!", MsgBoxStyle.Information)
        Else
            MsgBox("Download Completed.", MsgBoxStyle.Information)
        End If

    End Sub


    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        wc.CancelAsync()
        MsgBox("Download Cancelled!", MsgBoxStyle.Information)
        Thread.Sleep("4000")
        My.Computer.FileSystem.DeleteFile("Advanced Converter.rar")
        Me.Close()
    End Sub

 
End Class
