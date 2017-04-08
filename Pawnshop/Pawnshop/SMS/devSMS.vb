Imports System
Imports OneApi
Imports OneApi.Model
Imports OneApi.Config

Public Class devSMS

    Dim reqID
    Dim smsClient

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Dim config As New Configuration(txtUser.Text, txtPassword.Text)
        Dim smsClient As New OneApi.Client.Impl.SMSClient(config)


        Dim smsRequest As SMSRequest
        smsRequest = New SMSRequest("PGC", txtMsg.Text, txtNumber.Text)
        Try
            smsClient.SmsMessagingClient.SendSMS(smsRequest)
            reqID = smsClient.SmsMessagingClient.GetDeliveryReports
        Catch ex As Exception
            reqID = ex.ToString
        End Try

        Console.WriteLine("Send ID: " & reqID.ToString)

        'SendSMS(txtNumber.Text, txtMsg.Text)
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        Dim deliveryInfoList As DeliveryInfoList
        deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus("PGC", reqID)

        Dim deliveryStatus As String
        deliveryStatus = deliveryInfoList.DeliveryInfos(0).DeliveryStatus
        Console.WriteLine(deliveryStatus)
    End Sub
End Class