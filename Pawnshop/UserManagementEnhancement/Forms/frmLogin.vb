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

        If Not user_Login.chECK_If_SuperAdmin(uName) Then
            If Not user_Login.Check_username(uName) Then 'Check Username if Locked.
                Clearfield()
                MsgBox("This account has been locked. Please contact the Administrator for assistance.", MsgBoxStyle.Critical, "Validate") : Exit Sub
            End If

            Failed_attemp = user_Login.GET_FAILED_ATTEMP_NUM(uName) 'CHeck if has failed attemp.

            If Not user_Login.CheckPass_Age_Expiration(uName, pName) Then Exit Sub 'Maximum days expiration.
        End If


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
                user_Login.UPDATE_F_ATTMP(uName) 'Inactive the user account.
                End
            End If
            MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
        End If

        IDX = user_Login.ID
        MsgBox(String.Format("Welcome {0}, you login as {1}", UppercaseFirstLetter(user_Login.USERNAME), user_Login.USERTYPE & "", MsgBoxStyle.Information, "Login"))

        If Not user_Login.chECK_If_SuperAdmin(uName) Then
            If Not user_Login.Chk_Account_EXPIRY_COUNTDOWN(uName, pName) Then 'Minimum days expiration.
                user_Login.UPDATE_F_ATTMP(uName) 'Inactive the user account.
                Exit Sub
            Else
                user_Login.Back_to_max_if_Login(uName, pName, False) 'his/her minimum expiration will Back max date 
            End If
            Me.Close()
        End If

        user_Login.Back_to_max_if_Login(uName, pName) 'Update Super admin Last Login

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