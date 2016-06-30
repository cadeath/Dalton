Imports totp

Public Class diagOTP

    Private Sub btnSubmit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubmit.Click
        Dim mod_name As String = ""
        If FormType = OTPType.UserManagement Then
            mod_name = "User Management"
        ElseIf FormType = OTPType.Settings Then
            mod_name = "Settings"
        End If
        If otp.VerifyPIN(txtPIN.Text, mod_name) Then
            Me.Close()
            OTPGenerate()
        Else
            MsgBox("INVALID PIN", MsgBoxStyle.Critical)
        End If
    End Sub

    Enum OTPType As Integer
        UserManagement = 0
        Settings = 1
    End Enum
    Friend FormType As OTPType = OTPType.UserManagement
    Friend Sub OTPGenerate()
        Select Case FormType
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