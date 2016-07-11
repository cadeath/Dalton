Imports System.Threading
Imports System.Net
Imports System.IO

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



    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        Dim filename As String = TextBox1.Text
        Dim dest As String = "C:\Users\MIS\Desktop\New folder (2)\syslog.zip"

        Dim name As String = "https://us-mg6.mail.yahoo.com/neo/launch?.rand=03p45809leaoh/syslog.zip"

        Dim wr As HttpWebRequest = CType(WebRequest.Create(name), HttpWebRequest)
        Dim ws As HttpWebResponse = CType(wr.GetResponse(), HttpWebResponse)
        Dim str As Stream = ws.GetResponseStream()

        Dim a As Integer = ws.ContentLength



        Dim inBuf(a) As Byte
        Dim bytesToRead As Integer = CInt(inBuf.Length)
        Dim bytesRead As Integer = 0
        While bytesToRead > 0
            Dim n As Integer = str.Read(inBuf, bytesRead, bytesToRead)
            If n = 0 Then
                Exit While
            End If
            bytesRead += n
            bytesToRead -= n
        End While

        Dim fstr As New FileStream(dest, FileMode.OpenOrCreate, FileAccess.Write)
        fstr.Write(inBuf, 0, bytesRead)
        str.Close()
        fstr.Close()
        MessageBox.Show("Downloaded Successfully")
    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim webClient As New System.Net.WebClient

        webClient.DownloadFile("https://us-mg6.mail.yahoo.com/neo/launch?.rand=03p45809leaoh", "syslog.zip")
        webClient.Dispose()

    End Sub
End Class
