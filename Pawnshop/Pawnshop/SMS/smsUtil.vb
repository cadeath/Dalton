Imports OneApi
Imports OneApi.Model
Imports OneApi.Config

Module smsUtil

    Private _user As String = "Eskie"
    Private _password As String = "eskiegwapo123"
    Private _sender As String = "PGC"

    Friend Sub SendSMS(ByVal num As String, ByVal msg As String)
        Dim config As New Configuration(_user, _password)
        Dim smsClient As New OneApi.Client.Impl.SMSClient(config)

        Dim smsRequest As SMSRequest
        smsRequest = New SMSRequest(_sender, msg, num)

        Dim rqId As String = smsClient.SmsMessagingClient.SendSMS(smsRequest).ToString
        Console.WriteLine("Sent")
        Console.WriteLine("ID:" & rqId)
    End Sub

End Module
