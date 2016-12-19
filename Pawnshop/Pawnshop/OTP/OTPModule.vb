Imports totp

Module OTPModule
    Friend OtpSettings As OneTimePassword

    Friend Sub OTPSettings_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Settings"
        OtpSettings.SecretCode = "OTPSettings"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoidPawning_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Void Pawning"
        OtpSettings.SecretCode = "OTPVoidPawning"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoidInsurance_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Void Insurance"
        OtpSettings.SecretCode = "OTPVoidInsurance"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoidBranch_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Void Branch To Branch"
        OtpSettings.SecretCode = "OTPVoidBranch"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoidMoneyTransfer_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Void Money Transfer"
        OtpSettings.SecretCode = "OTPVoidMoneyTransfer"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoidMoneyExchange_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Void Money Exchange"
        OtpSettings.SecretCode = "OTPVoidMoneyExchange"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoidCashInOut_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Void Cash In / Out"
        OtpSettings.SecretCode = "OTPVoidCashInOut"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPItemPullout_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Item PullOut"
        OtpSettings.SecretCode = "OTPItemPullOut"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPUser_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP User Management"
        OtpSettings.SecretCode = "OTPUser"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPStockOut_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Stock Out"
        OtpSettings.SecretCode = "OTPStockOut"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub
End Module
