Imports totp

Public Class diagOTP
    Private Sub btnSubmit_Click(sender As System.Object, e As System.EventArgs) Handles btnSubmit.Click
        If otp.VerifyPIN(txtPIN.Text) Then
            Me.Close()
            frmSettings.UpdateSetting()
        Else
            MsgBox("INVALID PIN", MsgBoxStyle.Critical)
        End If
    End Sub
    Private Sub diagOTP_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtPIN.Text = ""
    End Sub
End Class