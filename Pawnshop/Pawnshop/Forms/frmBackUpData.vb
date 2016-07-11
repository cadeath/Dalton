Imports System.IO
Public Class frmBackUpData
    Const DBPATH As String = "\BackUp.bat"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtPath.Text = firebird
    End Sub

    Private Sub btnBrowseSavePath_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseSavePath.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub btnBrowseBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseBackup.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath2.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub btnbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        Dim path As String = txtPath.Text

        Using sw As StreamWriter = File.CreateText(path)
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - MANUAL BACKUP")
            sw.WriteLine("echo PLEASE CLOSE THE PAWNSHOP SYSTEM")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM IS BACKING UP")
            sw.WriteLine("rar a " & txtPath2.Text & "\" & txtBranchName.Text & ".rar -agMMddyyyy W3W1LH4CKU.FDB rar a -ep -hpMISJUNMAR -m0") 'Password = MISJUNMAR(uppercase) 
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")

        End Using
        ' End If
        MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub frmBackUpData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnStartBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartBackup.Click
        Process.Start(txtPath.Text)
    End Sub
End Class