Public Class diagAuthorization

    Dim confirmUser As New Sys_user
    Friend fromForm As Form

    Private Sub diagAuthorization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
    ''' <summary>
    ''' to load the username to textbox
    ''' </summary>
    ''' <param name="pos"></param>
    ''' <remarks></remarks>
    Friend Sub LoadUser(ByVal pos As Sys_user)
        txtUser.Text = pos.USERNAME
        txtUser.ReadOnly = True
    End Sub
    ''' <summary>
    ''' to confirm the authorization of the user
    ''' to check the password if correct
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub verify()
        Static err As Integer

        If confirmUser.LogUser(txtUser.Text, txtPassword.Text) Then
            fromForm.Show()
            mod_system.isAuthorized = True
            err = 0
            Me.Close()
        Else
            If err >= 3 Then
                MsgBox("You failed to authorize", MsgBoxStyle.Critical)
                Me.Close()
            End If
            err += 1
            MsgBox("Invalid username and password", MsgBoxStyle.Critical)
        End If
    End Sub
    ''' <summary>
    ''' click button to load verify method
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        verify()
    End Sub
End Class