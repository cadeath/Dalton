Imports totp

Module AuditConsole_Controller

    Friend AuditOTP As OneTimePassword

    Friend Sub AuditModule_Initialization()
        If OTPDisable Then Exit Sub

        AuditOTP = New OneTimePassword
        AuditOTP.Setup("ecjmaquic@gmail.com")
        AuditOTP.SecretCode = "AuditConsole"

        If DEV_MODE Then Console.WriteLine("QRCode: " & AuditOTP.ManualCode)
    End Sub

End Module
