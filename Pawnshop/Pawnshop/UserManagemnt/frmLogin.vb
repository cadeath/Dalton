Public Class frmLogin
    Dim user_Login As Sys_user
    Dim i As Integer = 0
    Dim Failed_attemp As Integer

    Dim UL_priv_acc As New User_Line_RULES

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUsername.Text = "" Or txtPassword.Text = "" Then Exit Sub

        Dim uName As String = txtUsername.Text
        Dim pName As String = txtPassword.Text

        user_Login = New Sys_user

        If Not user_Login.chECK_If_SuperAdmin(uName) Then
            If Not user_Login.Check_username(uName) Then 'Check Username if Locked.
                Clearfield()
                MsgBox("This account has been locked. " & vbCrLf & _
                       " contact the Administrator for assistance.", MsgBoxStyle.Critical, "Validate") : Exit Sub
            End If

            Failed_attemp = user_Login.GET_FAILED_ATTEMP_NUM(uName) 'Get Failed attemp.

            If Not user_Login.CheckPass_Age_Expiration(uName, pName) Then Exit Sub 'Maximum days expiration.

            'for User
            If Not user_Login.LogUser(uName, pName) Then
                i += 1
                If i > Failed_attemp Then

                    MsgBox("You reached the MAXIMUM logins this is a recording." & vbCrLf & vbCrLf & _
                           "Your account temporarily locked.", MsgBoxStyle.Critical, "Locked")

                    Clearfield()

                    If user_Login.ID = 0 Then Exit Sub
                    user_Login.LOCK_USER(uName) 'Inactive the user account.
                    End
                End If
                MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
            End If

            UType = user_Login.USERTYPE
            IDX = user_Login.ID
            FullName = user_Login.FIRSTNAME & " " & user_Login.LASTNAME
            MsgBox(String.Format("Welcome {0}, you login as {1}", UppercaseFirstLetter(user_Login.USERNAME), _
                                 user_Login.USERTYPE & "", MsgBoxStyle.Information, "Login"))


            If Not user_Login.Chk_Account_EXPIRY_COUNTDOWN(uName, pName) Then 'Minimum days expiration.
                user_Login.LOCK_USER(uName) : GoTo nextToline 'Inactive the user account. 
            Else
                user_Login.Back_to_max_if_Login(uName, pName) 'his/her minimum expiration will Back max date 
            End If : GoTo nextToline


            'For Admin
        Else

            Failed_attemp = user_Login.GET_FAILED_ATTEMP_NUM(uName) 'Get Failed attemp.
            If Not user_Login.LogUser(uName, pName) Then
                i += 1
                If i > 3 Then
                    MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                    Clearfield()
                    End
                End If
                MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Exit Sub
            End If

            UType = user_Login.USERTYPE
            IDX = user_Login.ID
            FullName = user_Login.FIRSTNAME & " " & user_Login.LASTNAME
            MsgBox(String.Format("Welcome {0}, you login as {1}", UppercaseFirstLetter(user_Login.USERNAME), user_Login.USERTYPE & "", MsgBoxStyle.Information, "Login"))

            user_Login.Back_to_max_if_Login(uName, pName) 'Update Back max date
        End If

nextToline:

        AccountRule.LOAD_USER_RULES()
        frmMain.Show()
        frmMain.NotYetLogin(False)
        frmMain.CheckStoreStatus()

        If user_Login.ChkIfUserProfileWasNotUpdate Then
            frmUserInfor.Show()
        End If

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