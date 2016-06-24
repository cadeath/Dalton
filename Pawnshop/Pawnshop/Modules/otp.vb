Imports TOTP

Module otp

    Public tfa As New OneTimePassword

    Friend Function VerifyPIN(pin As String) As Boolean
        Dim isValid As Boolean = tfa.isCorrect(pin)

        Dim mySql As String = String.Format("SELECT * FROM TBLOTP WHERE PIN = '{0}'", pin)
        Dim ds As DataSet = LoadSQL(mySql), fillData As String = "tblOTP"

        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow

            Return True
        End If

        Return isValid
    End Function
End Module
