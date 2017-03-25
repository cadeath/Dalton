Public Class frmLogin
    Dim user_Login As Sys_user
    Dim i As Integer = 0
    Dim Failed_attemp As Integer
    Dim isDisabled As String

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then Exit Sub

        Dim uName As String = txtUsername.Text
        Dim pName As String = txtPassword.Text

        user_Login = New Sys_user

        If Not user_Login.Check_username(uName) Then
            Clearfield()
            MsgBox("This account is either not register or locked.", MsgBoxStyle.Critical, "Validate") : Exit Sub
        End If


        Failed_attemp = user_Login.GET_FAILED_ATTEMP_NUM(uName)

        If Not user_Login.CheckAccount_Expiration(uName, pName) Then Exit Sub 'Maximum days expiration

        If Not user_Login.EXPIRY_COUNTDOWN(uName, pName) Then Exit Sub 'Minimum days expiration

        If Not user_Login.LogUser(uName, pName) Then

            If user_Login.USERTYPE = "Admin" Then
                i += 1
                If i > Failed_attemp Then
                    MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                    Clearfield()
                    End
                End If
                MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
            End If

            i += 1
            If i > Failed_attemp Then
                MsgBox("You reached the MAXIMUM logins this is a recording." & vbCrLf & vbCrLf & "Your account temporarily locked.", MsgBoxStyle.Critical, "Locked")
                Clearfield()
                user_Login.UPDATE_F_ATTMP(uName)
                End
            End If
            MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
        End If

        SYSTEM_USERIDX = user_Login.ID
        MsgBox(String.Format("Welcome {0}, you login as {1}", UppercaseFirstLetter(user_Login.USERNAME), user_Login.USERTYPE & "", MsgBoxStyle.Information, "Login"))
        Me.Close()
    End Sub


    Private Sub txtPassword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If isEnter(e) Then btnLogin.PerformClick()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub Clearfield()
        txtUsername.Text = ""
        txtPassword.Text = ""
    End Sub
End Class