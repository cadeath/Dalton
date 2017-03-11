Imports OneApi
Imports OneApi.Model
Imports OneApi.Config

Module smsUtil

    Private _smsUser As String = "Eskie"
    Private _smsPassword As String = "eskiegwapo"
    Private _smsSender As String = "DALTON"
    Private smsReady As Boolean = False
    Private _initFile As String = "dalton.esk"

    Friend Sub SendSMS(ByVal num As String, ByVal msg As String)
        Dim config As New Configuration(_smsUser, _smsPassword)
        Dim smsClient As New OneApi.Client.Impl.SMSClient(config)

        Dim smsRequest As SMSRequest
        smsRequest = New SMSRequest(_smsSender, msg, num)

        Dim rqId As String = smsClient.SmsMessagingClient.SendSMS(smsRequest).ToString
        Console.WriteLine("Sent")
        Console.WriteLine("ID:" & rqId)
    End Sub

    Private Sub SMS_Init()
        Dim ini As New IniFile

        If System.IO.File.Exists(_initFile) Then
            ini.Load(_initFile)

            With ini.GetSection("ACCOUNT")
                _smsUser = .GetKey("User").Value
                _smsPassword = DecryptString(.GetKey("Password").Value)
            End With

            smsReady = True
        End If
    End Sub

End Module
