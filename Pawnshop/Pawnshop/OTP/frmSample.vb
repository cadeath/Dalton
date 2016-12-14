Public Class frmSample

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OTP_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = AuditOTP
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmAuditConsole.Show()
            End If

        End If
    End Sub
End Class