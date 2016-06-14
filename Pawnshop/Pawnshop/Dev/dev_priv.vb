Public Class dev_priv


    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim x As New ComputerUser
        x.LoadUser(3)

        lblOutput.Text = x.Privilege.Split("|").Count
        'lblOutput.Text &= vbCrLf & "without AddPriv: " & x.Privilege
        'lblOutput.Text &= vbCrLf & "with AddPriv: " & x.AddPriv(ComputerUser.priv_set.Encoder)

    End Sub
End Class