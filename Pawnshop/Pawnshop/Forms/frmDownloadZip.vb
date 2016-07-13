Imports System.Threading
Imports System.Net
Imports System.IO
Imports System.ComponentModel

Public Class frmDownloadZip
    Dim wc As System.Net.WebClient

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click

        Dim dest As String = "C:\Users\MIS\Desktop\New folder (2)\syslogerror.rar"
        Dim name As String = "https://us-mg6.mail.yahoo.com/neo/launch?.rand=0b562mq04194i#407331862/syslogerror.rar"

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
        MsgBox("Downloaded Successfully", MsgBoxStyle.Information, "Pawnshop")


    End Sub

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim ZipLocation2 As String = " ""C:\Users\MIS\Desktop\TransFerhere\syslogerror.rar"" "
        Dim ZipExtracted2 As String = " ""C:\Users\MIS\Desktop\ExtractHere"" "
        Dim Zlocation As String = "C:\Program Files\WinRAR\WinRAR.exe"
        Using p1 As New Process
            p1.StartInfo.FileName = Zlocation
            p1.StartInfo.Arguments = " x " & ZipLocation2 & " *.* " & ZipExtracted2
            Try
                p1.Start()
                '   MsgBox("Successfully Extracted Data.", MsgBoxStyle.Information, "Pawnshop")
            Catch ex As Exception
                MsgBox("File Type Cannot be supported", MsgBoxStyle.Exclamation, "Pawnshop")
            End Try
        End Using
    End Sub

    Public Sub DownloadFile(ByVal _URL As String, ByVal _SaveAs As String)
        Try
            Dim _WebClient As New System.Net.WebClient()
            ' Downloads the resource with the specified URI to a local file.
            _WebClient.DownloadFile("http://localhost/syslogerror.rar", "C:\Users\MIS\Desktop\TransFerhere\syslogerror.rar")
        Catch _Exception As Exception
            ' Error
            Console.WriteLine("Exception caught in process: {0}", _Exception.ToString())
        End Try
    End Sub

    Private Sub _DownloadFileCompleted(ByVal sender As Object, ByVal e As AsyncCompletedEventArgs)
        ' File download completed
        Button1.Enabled = Enabled
        MessageBox.Show("Download completed")
    End Sub

    Private Sub _DownloadProgressChanged(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs)
        ' Update progress bar
        progressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False

        Dim _WebClient As New System.Net.WebClient()
        AddHandler _WebClient.DownloadFileCompleted, AddressOf _DownloadFileCompleted
        AddHandler _WebClient.DownloadProgressChanged, AddressOf _DownloadProgressChanged
        _WebClient.DownloadFileAsync(New Uri("http://localhost/syslogerror.zip"), "C:\Users\MIS\Desktop\TransFerhere\syslogerror.zip")
    End Sub
End Class
