Public Class frmLogin
    Dim drag As Boolean
    Dim mousex As Integer
    Dim mousey As Integer

    Private Sub pbClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles pbClose.Click
        End
    End Sub
    ''' <summary>
    ''' This mouseDown will make the mouse cursor to fit in the textfield.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pbHeader_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbHeader.MouseDown
        drag = True
        mousex = Windows.Forms.Cursor.Position.X - Me.Left
        mousey = Windows.Forms.Cursor.Position.Y - Me.Top
    End Sub
    ''' <summary>
    ''' ' This mouseDown will make the mouse cursor to fit in the textfield.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub pbHeader_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbHeader.MouseMove
        If drag Then
            Me.Top = Windows.Forms.Cursor.Position.Y - mousey
            Me.Left = Windows.Forms.Cursor.Position.X - mousex
        End If
    End Sub

    Private Sub pbHeader_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles pbHeader.MouseUp
        drag = False
    End Sub
    ''' <summary>
    ''' Exit the applicatio.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        End
    End Sub
    ''' <summary>
    ''' call the checkUsers method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckUsers()
    End Sub
    ''' <summary>
    ''' This method call the createadministrator method from the class.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub CheckUsers()
        Dim newUser As New ComputerUser
        newUser.CreateAdministrator()
    End Sub
    ''' <summary>
    ''' This method will set the font size into regular in the userfield.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub UserFieldSelected() Handles txtUser.GotFocus
        With txtUser
            .Text = ""
            .ForeColor = System.Drawing.SystemColors.WindowText
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        End With
    End Sub
    ''' <summary>
    '''  This method will set the font size into regular in the passwordfield.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PasswordFieldSelected() Handles txtPassword.GotFocus
        With txtPassword
            .Text = ""
            .ForeColor = System.Drawing.SystemColors.WindowText
            .Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            .PasswordChar = "*"
        End With
    End Sub
    ''' <summary>
    ''' This button will perform login the account user.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Static wrongLogin As Integer

        Dim user As String = DreadKnight(txtUser.Text)
        'Dim user As String = txtUser.Text
        Dim pass As String = txtPassword.Text

        Dim loginUser As New ComputerUser
        If Not loginUser.LoginUser(user, pass) Then
            wrongLogin += 1
            If wrongLogin >= 3 Then
                MsgBox("You have reached the MAXIMUM logins. This is a recording.", MsgBoxStyle.Critical)
                End
            End If
            MsgBox("Invalid Username and password", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' Success!
        POSuser = loginUser
        POSuser.UpdateLogin()
        UserID = POSuser.UserID
        MsgBox("Welcome " & POSuser.FullName)

        frmMain.Show()
        frmMain.NotYetLogin(False)
        frmMain.CheckStoreStatus()
        Me.Close()
    End Sub
End Class