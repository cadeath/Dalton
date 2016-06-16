Imports System.Net
Imports System.IO
Imports System.IO.Compression
Imports System.Text
Imports System
Imports Shell32
Public Class frmDownloadZip
    Private Sub Downloader()
        Dim ZipLocation As String = My.Application.Info.DirectoryPath & "\peace.zip"
        Dim ZipUrl As String = "C:\Users\MIS JunMar\Downloads\try\peace.zip"
        'sample url "https:\\www.colorado.edu/conflict/peace/download/peace.zip"
        Dim webUri = New Uri(ZipUrl)
        Using client As New WebClient
            ProgressBar1.Value = ProgressBar1.Minimum
            client.DownloadFile(webUri, ZipLocation)
        End Using
        ProgressBar1.Value = ProgressBar1.Maximum
        MessageBox.Show("Zip file Downloaded Successfully")
    End Sub
    Private Sub DOSCommand()
        ' Dim ipconfig As String = "ipconfig"
        'Dim cmdProcess As New Process
        'Process.Start(("cmd"), "cd \")
        Using p1 As New Process
            p1.StartInfo.FileName = "cmd.exe"
            p1.StartInfo.Arguments = "/k cd C:\Program Files\WinRAR"
            'p1.StartInfo.Arguments = "ipconfig"
            Try
                p1.Start()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            p1.WaitForExit()
        End Using
    End Sub
    Private Sub Extractor()
        Dim ZipFile As String = "C:\Users\MIS JunMar\Downloads\try\honor.zip"
        Dim ZipDir As String = "C:\Users\MIS JunMar\Downloads\try\nirc\"
        Dim Shell As Shell32.IShellDispatch
        Dim ShellFolder As Shell32.Folder

        If File.Exists(ZipFile) Then
            Shell = CType(CreateObject("Shell.Application"), IShellDispatch2)

            If Not Directory.Exists(ZipDir) Then Directory.CreateDirectory(ZipDir)
            ShellFolder = Shell.NameSpace(ZipDir)
            If ShellFolder IsNot Nothing Then
                ShellFolder.CopyHere(Shell.NameSpace(ZipFile).Items)
            End If
            MessageBox.Show("Successfully Extracted")
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Extractor()
        'DOSCommand()
        'Downloader()
    End Sub
End Class
