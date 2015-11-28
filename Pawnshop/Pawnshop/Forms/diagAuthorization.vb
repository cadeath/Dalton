Public Class diagAuthorization

    Dim confirmUser As New ComputerUser
    Friend fromForm As Form

    Private Sub diagAuthorization_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub LoadUser(ByVal pos As ComputerUser)
        txtUser.Text = pos.UserName
        txtUser.ReadOnly = True
    End Sub

    Private Sub verify()
        Static err As Integer

        If confirmUser.LoginUser(txtUser.Text, txtPassword.Text) Then
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

    Private Sub btnAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAuthorize.Click
        verify()
    End Sub
End Class