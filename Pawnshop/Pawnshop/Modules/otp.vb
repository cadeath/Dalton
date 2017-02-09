Imports TOTP

Module otp

    Public tfa As New OneTimePassword

    Friend Function VerifyPIN(ByVal pin As String) As Boolean
        Dim isValid As Boolean = tfa.isCorrect(pin)
        If Not isValid Then Return False

        Dim mySql As String = String.Format("SELECT * FROM TBLOTP WHERE PIN = '{0}'", pin)
        Dim ds As DataSet = LoadSQL(mySql), fillData As String = "tblOTP"

        If ds.Tables(0).Rows.Count = 0 Then
            Return isValid
        End If

        Return False
    End Function
End Module
