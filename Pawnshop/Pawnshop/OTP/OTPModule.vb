Imports totp

Module OTPModule
    Friend OtpSettings As OneTimePassword

    Friend Sub OTPSettings_Initialization()

        SetOTP("Settings")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoiding_Initialization()

        SetOTP("Voiding")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPItemPullout_Initialization()

        SetOTP("Pullout")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPUser_Initialization()

        SetOTP("User Management")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub


    Friend Sub OTPStockOut_Initialization()

        SetOTP("Stockout")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPInventory_Initialization()

        SetOTP("Inventory")

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

    Private Sub SetOTP(ByVal Modname As String, Optional ByVal Email As String = "MIS@gmail.com")
        Try
            Dim mysql As String = "Select * From OTPControl Where ModName = '" & Modname & "'"
            Dim ds As DataSet = LoadSQL(mysql, "OTPControl")

            OtpSettings = New OneTimePassword
            With OtpSettings
                .Setup(Email)
                .AppName = ds.Tables(0).Rows(0).Item("Appname")
                .SecretCode = ds.Tables(0).Rows(0).Item("OTPCode")
            End With

            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        Catch ex As Exception
            Console.WriteLine(ex.Message)
            MsgBox(ex.Message, MsgBoxStyle.Critical, "OTP Error")
        End Try
    End Sub

End Module
