Option Strict On
Imports System.Threading
Imports System.Net
Imports System.IO
Imports System.ComponentModel
Imports System.diagnosics
Imports System.Net.Sockets
Imports System.Text

Public Class frmDownloadZip
    Dim clientSocket As New System.Net.Sockets.TcpClient()
    Dim serverStream As NetworkStream
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
        batchfile()
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
        If IsProcessRunning("pawnshop") = True Then
            MsgBox("This Application is Running")
            : DialogResult = MessageBox.Show("You Should Close Pawnshop application for update?", "Pawnshop?", MessageBoxButtons.OKCancel, MessageBoxIcon.Information)
            If DialogResult = Windows.Forms.DialogResult.OK Then
                Process.Start("me.bat")
            Else
                Exit Sub
            End If
        Else
            : DialogResult = MessageBox.Show("Do you want to open Pawnshop Application?", "Open Pawnshop?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
            If DialogResult = Windows.Forms.DialogResult.Yes Then
                Process.Start("C:\Program Files (x86)\cdt-S0ft\Dalton Pawnshop\pawnshop.exe")
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
        Try
            DialogResult = MessageBox.Show("Do you want to execute?", "Pawnshop?", MessageBoxButtons.YesNo, MessageBoxIcon.Hand)
            If DialogResult = Windows.Forms.DialogResult.Yes Then
                Dim path As String = "C:\Users\MIS\Desktop\ExtractHere\me.bat"
                Dim a As String = "') DO IF %%x == %EXE% goto FOUND "
                Using sw As StreamWriter = File.CreateText(path)
                    sw.WriteLine("@echo off")
                    sw.WriteLine("SETLOCAL EnableExtensions")
                    sw.WriteLine("set EXE=pawnshop.exe")
                    sw.WriteLine("FOR /F %%x IN ('tasklist /NH /FI ""IMAGENAME eq %EXE%""" & a)
                    sw.WriteLine("echo Not running")
                    sw.WriteLine("pause")
                    sw.WriteLine("goto FIN ")
                    sw.WriteLine(":FOUND")
                    sw.WriteLine("echo Running")
                    sw.WriteLine("Taskkill /F /IM pawnshop.exe")
                    sw.WriteLine("pause")
                    sw.WriteLine(":FINALIZE")
                End Using
                MessageBox.Show("Success", "I N F O R M A T I O N", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MsgBox("Cancelled Process...")
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    '""""""""""""""""""""""""""""""""""""""""""""""""""""""

  
    Private Sub frmDownloadZip_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        GetSystemInfo()
    End Sub

    Private Sub GetSystemInfo()
        Dim hostname As IPHostEntry = Dns.GetHostByName(txtIpAddress.Text)
        Dim ip As IPAddress() = hostname.AddressList
        txtIpAddress.Text = ip(0).ToString()
        txtBrancName.Text = branchName
        Version.Text = ProductVersion
    End Sub

    
End Class
