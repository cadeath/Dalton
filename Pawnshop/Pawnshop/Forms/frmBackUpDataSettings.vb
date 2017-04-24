Imports System.IO
Public Class frmBackUpDataSettings
    Const DBPATH As String = "\BackUp.bat"

    Private Sub btnBrowseBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseBackup.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtData.Text = fbdBackup.SelectedPath
        txtData.Focus()
    End Sub

    Private Sub btnbackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBackup.Click
        If txtData.Text = "" OrElse txtCompliance.Text = "" Then Exit Sub

        Using sw As StreamWriter = File.CreateText("backup.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - MANUAL BACKUP")
            sw.WriteLine("echo PLEASE CLOSE THE Dalton Integrated System")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM IS BACKING UP")
            sw.WriteLine("rar a " & txtData.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy W3W1LH4CKU.FDB -hp" _
                         & BranchCode & "MIS") 'Password = MISJUNMAR(uppercase)
            sw.WriteLine("rar a " & txtCompliance.Text & "\" & mod_system.BranchCode & "_COMP" & ".rar -agMMddyyyy ClientImage -hp" _
                        & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using

        MessageBox.Show("Successful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Me.Close()
    End Sub

    Private Sub txtPath2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtData.KeyPress
        If isEnter(e) Then
            btnBackup.PerformClick()
        End If
    End Sub

    Private Sub btnBrowseComp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseComp.Click
        If Not fbdComp.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtCompliance.Text = fbdComp.SelectedPath
        txtCompliance.Focus()
    End Sub
End Class