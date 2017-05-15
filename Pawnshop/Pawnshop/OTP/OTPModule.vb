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

    Friend Sub OTPVoiding_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - OTP Voiding"
        OtpSettings.SecretCode = "OTPVoiding"
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
        OtpSettings.AppName = "Dalton - Stock Out"
        OtpSettings.SecretCode = "OTPStockOut"
        OtpSettings.Setup("ecjmaquic@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPInventory_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - Inventory"
        OtpSettings.SecretCode = "OTPInventory"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPDiscount_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - Discount"
        OtpSettings.SecretCode = "OTPDiscount"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPCustomPrice_Initialization()
        If OTPDisable Then Exit Sub

        OtpSettings = New OneTimePassword
        OtpSettings.AppName = "Dalton - Custom Price"
        OtpSettings.SecretCode = "OTPCustomerPrice"
        OtpSettings.Setup("marzxxx90@gmail.com")
        Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub
End Module
