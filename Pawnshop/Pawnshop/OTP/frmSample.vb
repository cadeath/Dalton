Public Class frmSample

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        OTPSettings_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmSettings.Show()
            End If

        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmPawningItemNew.Show()
            End If

        End If
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmInsurance.Show()
            End If

        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmBorrowBrowse.Show()
            End If

        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmMoneyTransfer.Show()
            End If

        End If
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmmoneyexchange.Show()
            End If

        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmCashCountV2.Show()
            End If

        End If
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        OTPItemPullout_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                qryPullOut.Show()
            End If

        End If
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        OTPUser_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isCorrect Then
                Exit Sub
            Else
                frmUserManagement.Show()
            End If

        End If
    End Sub
End Class