Imports totp

Public Class diagOTPv2

    Friend GeneralOTP As OneTimePassword
    Friend isCorrect As Boolean = False

    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        If GeneralOTP.isCorrect(txtPIN.Text) Then
            isCorrect = True
        Else
            MsgBox("Invalid PIN", MsgBoxStyle.Information)
            Exit Sub
        End If

        Me.Close()
    End Sub

    Private Sub diagOTPv2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtPIN.Text = ""
    End Sub
End Class