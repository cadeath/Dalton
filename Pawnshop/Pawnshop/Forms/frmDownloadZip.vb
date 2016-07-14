Option Strict On
Imports System.Threading
Imports System.Net
Imports System.IO
Imports System.ComponentModel
Imports System.diagnosics

Public Class frmDownloadZip
   
    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click

        Dim DownloadedData As String = " ""C:\Users\MIS\Desktop\TransFerhere\syslogerror.rar"" "
        Dim ExtracedData As String = " ""C:\Users\MIS\Desktop\ExtractHere"" "
        Dim RarLocation As String = "C:\Program Files\WinRAR\WinRAR.exe"
        Using p1 As New Process
            p1.StartInfo.FileName = RarLocation
            p1.StartInfo.Arguments = " x " & DownloadedData & " *.* " & ExtracedData
            Try
                p1.Start()
                MsgBox("Successfully Extracted Data.", MsgBoxStyle.Information, "Pawnshop")
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
        ProgressBar1.Value = e.ProgressPercentage
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Button1.Enabled = False

        Dim _WebClient As New System.Net.WebClient()
        AddHandler _WebClient.DownloadFileCompleted, AddressOf _DownloadFileCompleted
        AddHandler _WebClient.DownloadProgressChanged, AddressOf _DownloadProgressChanged
        _WebClient.DownloadFileAsync(New Uri("http://localhost/syslogerror.rar"), "C:\Users\MIS\Desktop\TransFerhere\syslogerror.rar")

       
    End Sub
  

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click
        
        Dim dlg As SaveFileDialog = New SaveFileDialog

        System.IO.File.Delete("C:\Users\MIS\Desktop\ExtractHere\me.bat")

        dlg.Title = "Save"
        dlg.Filter = "Batch File (*.bat)|*.bat"
        Try
            If dlg.ShowDialog = System.Windows.Forms.DialogResult.OK Then
                RichTextBox1.SaveFile(dlg.FileName, RichTextBoxStreamType.PlainText)
                MsgBox("Successfully Saved", MsgBoxStyle.Information, "Pawnshop")

            End If
        Catch ex As Exception

        End Try


    End Sub
   

    Private Sub btnExecuteBatch_Click(sender As System.Object, e As System.EventArgs) Handles btnExecuteBatch.Click
        Dim proc As Process = Nothing
        Try
            Dim batDir As String = String.Format("C:\Users\MIS\Desktop\ExtractHere")
            proc = New Process()
            proc.StartInfo.WorkingDirectory = batDir
            proc.StartInfo.FileName = "me.bat"
            proc.StartInfo.CreateNoWindow = False
            proc.Start()
            proc.WaitForExit()
            MessageBox.Show("Bat file executed !!")
        Catch ex As Exception
            Console.WriteLine(ex.StackTrace.ToString())
        End Try
    End Sub


    '"""""""""""""""""""""""""""""""""""""""""""""
    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        If IsProcessRunning("notepad") = True Then
            MsgBox("This Application is Running")
        Else
            : DialogResult = MessageBox.Show("Do you want to open Notepad?", "Open Notepad?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
            If DialogResult = Windows.Forms.DialogResult.Yes Then
                Process.Start("C:\Windows\Notepad.exe")
            End If
        End If
    End Sub
    Public Function IsProcessRunning(ByVal name As String) As Boolean
        For Each clsProcess As Process In Process.GetProcesses()
            If clsProcess.ProcessName.StartsWith(name) Then
                Return True
            End If
        Next
        Return False
    End Function
    '"""""""""""""""""""""""""""""""""""""""""""""""""""
    Private Sub batchfile()
        Dim a As String = "') DO IF %%x == %EXE% goto FOUND "
        RichTextBox1.Text = "echo off " & _
        "SETLOCAL EnableExtensions " & _
        "EXE = Pawnshop.exe" & _
        "FOR /F %%x IN ('tasklist /NH /FI ""IMAGENAME eq %EXE%" & a & _
        " echo Not running " & _
       " pause " & _
        "GoTo FIN " & _
        ": FOUND" & _
       " echo Running" & _
        "Taskkill /F /IM pawnshop.exe" & _
        "pause" & _
        ": FIN"
    End Sub

    Private Sub frmDownloadZip_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        batchfile()
    End Sub
End Class
