Imports totp
Enum OTPType As Integer
    UserManagement = 0
    Settings = 1
End Enum
Public Class diagOTP
    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        If otp.VerifyPIN(txtPIN.Text) Then
            Me.Close()
            OTPGenerate()
        Else
            MsgBox("INVALID PIN", MsgBoxStyle.Critical)
        End If
    End Sub
    Friend FormType As OTPType
    Private Sub OTPGenerate()
         Select FormType
            Case OTPType.UserManagement
                frmUserManagement.AddUserManagement()
            Case OTPType.Settings
                frmSettings.UpdateSetting()
        End Select
    End Sub
    Private Sub diagOTP_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPIN.Text = ""
    End Sub

    Private Sub txtPIN_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPIN.KeyPress
        If isEnter(e) Then btnSubmit.PerformClick()
    End Sub
End Class