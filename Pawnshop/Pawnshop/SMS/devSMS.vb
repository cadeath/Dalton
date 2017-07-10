Imports System
Imports OneApi
Imports OneApi.Model
Imports OneApi.Config

' TODO
' If possible use DeliveryInfoList and its delivery reports
' DeliveredToTerminal, DeliveryUncertain, DeliveryImpossible, MessageWaiting and DeliveredToNetwork
' ref: https://github.com/infobip/oneapi-dot-net
' Failed due, cannot retrieve RequestID

Public Class devSMS

    Dim reqID
    Dim smsClient As OneApi.Client.Impl.SMSClient
    Dim senderAddr As String = "PGC"

    Private Sub btnSend_Click(sender As System.Object, e As System.EventArgs) Handles btnSend.Click
        Dim config As New Configuration(txtUser.Text, txtPassword.Text)
        smsClient = New OneApi.Client.Impl.SMSClient(config)
        Dim TextMessage As String = GetOption("SMS_MSG")
        'Dim dr As DataRow = ExpiryCache.Select("PAWNTICKET = " & txtMsg.Text)(0)
        Dim mysql As String = "Select * From OPT"
        Dim ds As DataSet = LoadSQL(mysql, "OPT")
        Dim dr As DataRow = ds.Tables(0).Rows(0)
        Dim text_msg As String = MessageBuilder(TextMessage, dr)

        Console.WriteLine("Text Message: " & text_msg.Length)
        Dim smsRequest As SMSRequest
        smsRequest = New SMSRequest(senderAddr, text_msg, txtNumber.Text)
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
        Dim deliveryInfoList As New DeliveryInfoList
        deliveryInfoList = smsClient.SmsMessagingClient.QueryDeliveryStatus(senderAddr, reqID.ToString)

        Dim deliveryStatus As String
        deliveryStatus = deliveryInfoList.DeliveryInfos(0).DeliveryStatus
        Console.WriteLine(deliveryStatus)
    End Sub
End Class