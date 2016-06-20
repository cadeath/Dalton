Imports System.Net
Imports System.IO
'Imports System.IO.Compression
'Imports System.Text
'Imports System
Imports Shell32
Public Class frmDownloadZip
    Private Sub Downloader()
        Dim ZipLocation As String = My.Application.Info.DirectoryPath & "\honor.zip"
        Dim ZipUrl As String = "C:\Users\MIS JunMar\Downloads\try\honor.zip"
        'sample url "https:\\www.colorado.edu/conflict/peace/download/peace.zip"
        Dim webUri = New Uri(ZipUrl)
        Using client As New WebClient
            ProgressBar1.Value = ProgressBar1.Minimum
            Try
                client.DownloadFile(webUri, ZipLocation)
                ProgressBar1.Value = ProgressBar1.Maximum
                MessageBox.Show("Zip file Downloaded Successfully")
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            client.Dispose()
        End Using
    End Sub
    Private Sub DOSCommandExtract()
        Dim ZipLocation2 As String = " ""C:\Users\MIS JunMar\Downloads\try\honor.zip"" "
        Dim ZipExtracted2 As String = " ""C:\Users\MIS JunMar\Downloads\try\nirc"" "
        Dim Zlocation As String = "C:\Program Files\WinRAR\winrar.exe"
        Using p1 As New Process
            p1.StartInfo.FileName = Zlocation
            p1.StartInfo.Arguments = " x " & ZipLocation2 & " *.* " & ZipExtracted2
            Try
                p1.Start()
            Catch ex As Exception
                MessageBox.Show(ex.Message)
            End Try
            'p1.WaitForExit()
        End Using
    End Sub
    'Private Sub Extractor()
    '    Dim ZipFile As String = My.Application.Info.DirectoryPath & "\honor.zip"
    '    Dim ZipLocation As String = My.Application.Info.DirectoryPath
    '    Dim Shell As Shell32.IShellDispatch
    '    Dim ShellFolder As Shell32.Folder

    '    If File.Exists(ZipFile) Then
    '        Shell = CType(CreateObject("Shell.Application"), IShellDispatch2)
    '        If Not Directory.Exists(ZipLocation) Then Directory.CreateDirectory(ZipLocation)
    '        ShellFolder = Shell.NameSpace(ZipLocation)
    '        If ShellFolder IsNot Nothing Then
    '            ShellFolder.CopyHere(Shell.NameSpace(ZipFile).Items)
    '        End If
    '        MessageBox.Show("Successfully Extracted")
    '    End If
    'End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Extractor()
        DOSCommandExtract()
        'Downloader()
    End Sub
End Class
