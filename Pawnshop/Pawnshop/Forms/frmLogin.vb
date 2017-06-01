Public Class frmLogin1
    Dim user_Login As Sys_user
    Dim i As Integer = 0
    Dim Failed_attemp As Integer

    Dim UL_priv_acc As New User_Line_RULES

    'Dim drag As Boolean
    'Dim mousex As Integer
    'Dim mousey As Integer

    'Private Sub pbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    End
    'End Sub
    ' ''' <summary>
    ' ''' This mouseDown will make the mouse cursor to fit in the textfield.
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub pbHeader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    drag = True
    '    mousex = Windows.Forms.Cursor.Position.X - Me.Left
    '    mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    'End Sub
    ' ''' <summary>
    ' ''' ' This mouseDown will make the mouse cursor to fit in the textfield.
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub pbHeader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    If drag Then
    '        Me.Top = Windows.Forms.Cursor.Position.Y - mousey
    '        Me.Left = Windows.Forms.Cursor.Position.X - mousex
    '    End If
    'End Sub

    'Private Sub pbHeader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
    '    drag = False
    'End Sub
    ' ''' <summary>
    ' ''' Exit the applicatio.
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    End
    'End Sub
    ' ''' <summary>
    ' ''' call the checkUsers method.
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    txtUser.Focus()
    '    CheckUsers()
    'End Sub
    ' ''' <summary>
    ' ''' This method call the createadministrator method from the class.
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub CheckUsers()
    '    Dim newUser As New ComputerUser
    '    newUser.CreateAdministrator()
    'End Sub
    ' ''' <summary>
    ' ''' This method will set the font size into regular in the userfield.
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub UserFieldSelected() Handles txtUser.GotFocus
    '    With txtUser
    '        .Text = ""
    '        .ForeColor = System.Drawing.SystemColors.WindowText
    '        .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '    End With
    'End Sub
    ' ''' <summary>
    ' '''  This method will set the font size into regular in the passwordfield.
    ' ''' </summary>
    ' ''' <remarks></remarks>
    'Private Sub PasswordFieldSelected() Handles txtPassword.GotFocus
    '    With txtPassword
    '        .Text = ""
    '        .ForeColor = System.Drawing.SystemColors.WindowText
    '        .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    '        .PasswordChar = "*"
    '    End With
    'End Sub
    ' ''' <summary>
    ' ''' This button will perform login the account user.
    ' ''' </summary>
    ' ''' <param name="sender"></param>
    ' ''' <param name="e"></param>
    ' ''' <remarks></remarks>
    'Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
    '    Static wrongLogin As Integer

    '    Dim user As String = DreadKnight(txtUser.Text)
    '    ' Dim user As String = txtUser.Text
    '    Dim pass As String = txtPassword.Text

    '    Dim loginUser As New ComputerUser
    '    If Not loginUser.LoginUser(user, pass) Then
    '        wrongLogin += 1
    '        If wrongLogin >= 3 Then
    '            MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
    '            End
    '        End If
    '        MsgBox("Invalid Username and password", MsgBoxStyle.Critical)
    '        Exit Sub
    '    End If

    '    'Success!()
    '    POSuser = loginUser
    '    POSuser.UpdateLogin()
    '    UserID = POSuser.UserID
    '    MsgBox("Welcome " & POSuser.FullName)

    '    frmMain.Show()
    '    frmMain.NotYetLogin(False)
    '    frmMain.CheckStoreStatus()
    '    Me.Close()
    'End Sub

    'Private Sub btnExit_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
    '    End
    'End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        If txtUser.Text = "" Or txtPassword.Text = "" Then Exit Sub

        Dim uName As String = DreadKnight(txtUser.Text)
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
                'Username not register
                If Failed_attemp = 0 Then
                    i += 1
                    If i >= 3 Then
                        MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                        Clearfield()
                        End
                    End If
                    MsgBox("This account doesn't exists!", MsgBoxStyle.Exclamation, "Invalid") : Clearfield() : Exit Sub
                End If

                i += 1
                If i >= Failed_attemp Then

                    MsgBox("You reached the MAXIMUM logins this is a recording." & vbCrLf & vbCrLf & _
                           "Your account temporarily locked.", MsgBoxStyle.Critical, "Locked")

                    Clearfield()

                    If user_Login.ID = 0 Then Exit Sub
                    user_Login.LOCK_USER(uName) 'Inactive the user account.
                    End
                End If
                MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Clearfield() : Exit Sub
            End If

            SystemUser = user_Login
            UType = user_Login.USERTYPE
            UserIDX = user_Login.ID
            FullName = user_Login.FIRSTNAME & " " & user_Login.LASTNAME

            AccountRule.LOAD_USER_RULES()

            MsgBox(String.Format("Welcome {0}, you login as {1}", UppercaseFirstLetter(user_Login.USERNAME), _
                                 user_Login.USERTYPE & "", MsgBoxStyle.Information, "Login"))
            MsgBox(user_Login.Get_rem_PassExp)
            If user_Login.Get_rem_PassExp <= 7 Then
                MsgBox(user_Login.Get_rem_PassExp & " days remaining password expiration...", MsgBoxStyle.Exclamation, "Validation")
            End If

            If Not user_Login.Chk_Account_EXPIRY_COUNTDOWN(uName, pName) Then 'Minimum days expiration.
                user_Login.LOCK_USER(uName) : GoTo nextToline 'Inactive the user account. 
            Else
                user_Login.Back_to_max_if_Login(uName, pName) 'his/her minimum expiration will Back max date 
            End If : GoTo nextToline


            'For Admin
        Else
            If Not user_Login.LogUser(uName, pName) Then
                i += 1
                If i >= 3 Then
                    MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                    Clearfield()
                    End
                End If
                MsgBox("Invalid username or password!", MsgBoxStyle.Exclamation, "Invalid") : Clearfield() : Exit Sub
            End If

            SystemUser = user_Login
            UType = user_Login.USERTYPE
            UserIDX = user_Login.ID
            FullName = user_Login.FIRSTNAME & " " & user_Login.LASTNAME
            MsgBox(String.Format("Welcome {0}, you login as {1}", UppercaseFirstLetter(user_Login.USERNAME), _
                                 user_Login.USERTYPE & "", MsgBoxStyle.Information, "Login"))

            ' user_Login.Back_to_max_if_Login(uName, pName) 'Update Back max date
        End If

nextToline:

        frmMain.Show()
        frmMain.NotYetLogin(False)
        frmMain.CheckStoreStatus()
        ' frmMain.tmrForPasswordExpiry.Start()

        If user_Login.ChkUserUpdate Then
            frmUserInfor.Show()
        End If

        Me.Close()
    End Sub


    Private Sub Clearfield()
        txtUser.Text = ""
        txtPassword.Text = ""
        txtUser.Focus()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub

    Private Sub frmLogin1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        user_Login = New Sys_user
        user_Login.CreateSuperAdministrator()
    End Sub

    Private Sub pbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClose.Click
        End
    End Sub

    Private Sub txtPassword_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPassword.KeyPress
        If isEnter(e) Then btnLogin.PerformClick()
    End Sub

    Private Sub txtUser_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUser.KeyPress
        If isEnter(e) Then txtPassword.Focus()
    End Sub
End Class