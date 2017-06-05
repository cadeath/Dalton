Imports DeathCodez.Security
Public Class frmChangePasswordNew
    Dim chngePass As New Sys_user
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
        If Not isvalid() Then Exit Sub
        If Not chngePass.ChangePassword(txtNewPassword.Text) Then Exit Sub
        MsgBox(SystemUser.USERNAME & " Updated ", MsgBoxStyle.Information)
        Clear()

        AddTimelyLogs("CHANGE PASSWORD", "Change Password from: " & Encrypt(txtOldPassword.Text) & " to: " & _
                      Encrypt(txtNewPassword.Text), , False, "By: " & SystemUser.USERNAME, 0)

    End Sub

    Private Function isvalid() As Boolean
        If txtNewPassword.Text.Length < 6 Then
            MsgBox("Password atleast 6 character or above combinations.", _
                MsgBoxStyle.Critical, "Error") : Return False
        End If
        If txtOldPassword.Text = "" Then txtOldPassword.Focus() : Return False
        If Encrypt(txtOldPassword.Text) <> SystemUser.USERPASS Then
            MsgBox("Old password not MATCHED", MsgBoxStyle.Critical, "Change Password")
            txtOldPassword.Focus() : Return False
        End If

        If txtNewPassword.Text <> txtConfirmPassword.Text And Not txtConfirmPassword.Text = "" Then
            MsgBox("Password is not MATCHED", MsgBoxStyle.Critical, "Change Password")
            txtNewPassword.Focus() : Return False
        End If

        Return True
    End Function

    Private Sub Clear()
        txtOldPassword.Text = ""
        txtConfirmPassword.Text = ""
        txtNewPassword.Text = ""
    End Sub
End Class