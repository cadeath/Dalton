Imports System.IO
Public Class frmBackUpDataSettings
    Const DBPATH As String = "\BackUp.bat"

    Private Sub btnBrowseBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseBackup.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtPath2.Text = fbdBackup.SelectedPath
        txtPath2.Focus()
    End Sub

    Private Sub btnbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click

        Using sw As StreamWriter = File.CreateText("backup.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - MANUAL BACKUP")
            sw.WriteLine("echo PLEASE CLOSE THE PAWNSHOP SYSTEM")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM IS BACKING UP")
            sw.WriteLine("rar a " & txtPath2.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy W3W1LH4CKU.FDB rar a -ep -hp" _
                         & BranchCode & "MIS -m0") 'Password = MISJUNMAR(uppercase)
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using

        MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub
    Private Sub txtPath2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPath2.KeyPress
        If isEnter(e) Then
            btnBackup.PerformClick()
        End If
    End Sub
End Class