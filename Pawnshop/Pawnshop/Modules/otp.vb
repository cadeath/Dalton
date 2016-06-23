Imports TOTP

Module otp

    Public tfa As EskieTOTP

    Friend Function VerifyPIN(pin As String) As Boolean
        Dim isValid As Boolean = tfa.isCorrect(pin)


        Return isValid
    End Function
End Module
