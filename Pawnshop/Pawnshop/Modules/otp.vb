Imports TOTP

Module otp

    Public tfa As New OneTimePassword

    Friend Function VerifyPIN(pin As String) As Boolean
        Dim isValid As Boolean = tfa.isCorrect(pin)

        Dim mySql As String = String.Format("SELECT * FROM TBLOTP WHERE PIN = '{0}'", pin)
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then


            Return True
        End If

        Return False
    End Function
End Module
