Public Class frmLogin
    Dim user_Login As Sys_user
    Dim i As Integer = 0
    Dim Failed_attemp As Integer

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then Exit Sub
        Failed_attemp = GetOption("FailedAttempNum")

        Dim uName As String = txtUsername.Text
        Dim pName As String = txtPassword.Text

        user_Login = New Sys_user

        If Not user_Login.CheckAccount_Expiration(pName) Then
            Exit Sub
        End If

        If Not user_Login.LogUser(uName, pName) Then
            i += 1
            If i > Failed_attemp Then
                MsgBox("You reached the MAXIMUM attemp" & vbCrLf & "Your account temporarily disabled", MsgBoxStyle.Information, "")
            End If
            MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
        End If

        MsgBox("Welcome " & user_Login.USERNAME, "login successful")
    End Sub
End Class