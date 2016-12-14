Imports totp

Module OTPModule
    Friend OtpSettings As OneTimePassword

    Friend Sub OTP_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Settings"
        OtpSettings.SecretCode = "OTPSettings"

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub
End Module
