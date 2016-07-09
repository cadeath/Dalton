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
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub

        txtPath2.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click

        Dim path As String = txtPath.text

        ' This text is added only once to the file. 
        ' If Not File.Exists(path) Then
        ' Create a file to write to.
        Using sw As StreamWriter = File.CreateText(path)
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - MANUAL BACKUP")
            sw.WriteLine("echo PLEASE CLOSE THE PAWNSHOP SYSTEM")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM IS BACKING UP")
            sw.WriteLine("rar a " & txtPath2.Text & "\" & txtBranchName.Text & ".rar -agMMddyyyy W3W1LH4CKU.FDB rar a -ep -hpMISJUNMAR -m0")
            sw.WriteLine("cls ")
            'sw.WriteLine("echo %" & txtBranchName.Text)
            'sw.WriteLine("rar a -ep -hpPASSWORDGOESHERE -m0  %" & txtBranchName.Text & ".rar %" & txtBranchName.Text & "")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")

        End Using
        ' End If
        MessageBox.Show("Successful")
    End Sub

    Private Sub frmBackUpData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

End Class