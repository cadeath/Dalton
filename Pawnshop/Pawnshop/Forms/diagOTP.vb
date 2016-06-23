Public Class diagOTP

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        If otp.VerifyPIN(txtPIN.Text) Then
            Me.Close()
        Else
            MsgBox("INVALID PIN", MsgBoxStyle.Critical)
        End If
    End Sub
End Class