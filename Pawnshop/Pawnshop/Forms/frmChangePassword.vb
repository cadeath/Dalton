﻿Imports DeathCodez.Security
Public Class frmChangePassword
    Private selectedUser As New ComputerUser
    Private moduleName As String = "User Management"
    Private fillData As String = "tbl_Gamit"
    Private Function PasswordPolicy() As Boolean
        If txtNewPassword.Text.Length >= 4 And txtNewPassword.Text.Length <= 8 Then
            Return True
        End If
        MsgBox("Password must be atleast 4 characters but not more than 8 characters", MsgBoxStyle.Critical, moduleName)
        Return False
    End Function
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Not PasswordPolicy() Then Exit Sub
        If txtOldPassword.Text = "" Then Exit Sub
        If Encrypt(txtOldPassword.Text) <> POSuser.Password Then
            MsgBox("Previous password not MATCHED", MsgBoxStyle.Critical, "Change Password")
            txtOldPassword.Focus()
            Exit Sub
        End If
        If txtNewPassword.Text <> txtConfirmPassword.Text And Not txtConfirmPassword.Text = "" Then
            MsgBox("Password is not MATCHED", MsgBoxStyle.Critical, "Change Password")
            txtNewPassword.Focus()
            Exit Sub
        End If
        Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE USERID = " & POSuser.UserID
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        ds.Tables(fillData).Rows(0).Item("USERPASS") = Encrypt(txtNewPassword.Text)
        SaveEntry(ds, False)
        MsgBox(POSuser.UserName & " updated", MsgBoxStyle.Information)
        AddTimelyLogs(moduleName, "User " & POSuser.UserName & " Change Password", , , "By: " & POSuser.UserName)
        clearfields()
        Me.Close()
    End Sub
    Private Sub clearfields()
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()
        txtOldPassword.Clear()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        clearfields()
    End Sub
End Class