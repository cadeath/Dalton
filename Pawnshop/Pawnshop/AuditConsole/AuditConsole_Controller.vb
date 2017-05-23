Imports totp

Module AuditConsole_Controller

    Friend AuditOTP As OneTimePassword

    Friend Sub AuditModule_Initialization()

        AuditOTP = New OneTimePassword
        AuditOTP.AppName = "Dalton - Audit Console"
        AuditOTP.SecretCode = "AuditConsole"

        If DEV_MODE Then
            AuditOTP.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & AuditOTP.ManualCode)
            Console.WriteLine("QRCode URL: " & AuditOTP.QRCode_URL)
        End If
    End Sub

End Module
