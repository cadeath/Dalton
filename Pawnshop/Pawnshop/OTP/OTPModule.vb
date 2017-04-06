Imports totp

Module OTPModule
    Friend OtpSettings As OneTimePassword

    Friend Sub OTPSettings_Initialization()
        If OTPDisable Then Exit Sub

        SetOTP("Settings")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPVoiding_Initialization()
        If OTPDisable Then Exit Sub

        SetOTP("Voiding")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPItemPullout_Initialization()
        If OTPDisable Then Exit Sub
        SetOTP("Pullout")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPUser_Initialization()
        If OTPDisable Then Exit Sub

        SetOTP("User Management")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub


    Friend Sub OTPStockOut_Initialization()
        If OTPDisable Then Exit Sub

        SetOTP("Stockout")

        If DEV_MODE Then
            OtpSettings.Setup("eskie@pgc-itdept.org")
            Console.WriteLine("QRCode: " & OtpSettings.ManualCode)
            Console.WriteLine("QRCode URL: " & OtpSettings.QRCode_URL)
        End If
    End Sub

    Friend Sub OTPInventory_Initialization()
        If OTPDisable Then Exit Sub

        SetOTP("Inventory")

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
