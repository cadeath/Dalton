Imports System
Imports OneApi
Imports OneApi.Model
Imports OneApi.Config

Module smsUtil

    Private _smsUser As String = "Eskie"
    Private _smsPassword As String = "eskiegwapo123"
    Private _smsSender As String = "DALTON"
    Private smsReady As Boolean = False
    Private _initFile As String = "dalton.esk"
    Friend ExpiryList As New CollectionPawnTicket
    Friend ExpiryCache As New DataTable

    Friend Function SendSMS(ByVal num As String, ByVal msg As String) As String
        If Not isReady() Then
            MsgBox("SMS Initialization not yet ready", MsgBoxStyle.Critical)
            Return "FAILED"
        End If
        Dim config As New Configuration(_smsUser, _smsPassword)
        Dim smsClient As New OneApi.Client.Impl.SMSClient(config)

        Dim smsRequest As SMSRequest
        smsRequest = New SMSRequest(_smsSender, msg, num)

        Dim rqId As String = smsClient.SmsMessagingClient.SendSMS(smsRequest).ToString
        Console.WriteLine("Sent")
        Console.WriteLine("ID:" & rqId)

        Return rqId
    End Function

    Private Sub SMS_Init()
        Dim ini As New IniFile

        If System.IO.File.Exists(_initFile) Then
            ini.Load(_initFile)

            With ini.GetSection("ACCOUNT")
                _smsUser = .GetKey("User").Value
                _smsPassword = DecryptString(.GetKey("Password").Value)
            End With

            smsReady = True
        Else
            System.IO.File.Create(_initFile).Dispose()

            ini.Load(_initFile)
            With ini
                .AddSection("ACCOUNT").AddKey("User").Value = _smsUser
                .AddSection("ACCOUNT").AddKey("Password").Value = EncryptString(_smsPassword)
                .Save(_initFile)
            End With

            smsReady = True
        End If
    End Sub

    Friend Sub Load_Expiry(Optional ByVal frmNoti As Form = Nothing)
        Dim mySql As String = _
                String.Format("SELECT * FROM PAWN_LIST WHERE (EXPIRYDATE <= '{0}' AND AUCTIONDATE > '{0}') AND (STATUS = 'L' OR STATUS = 'R') AND SENT_NOTICE = 0", CurrentDate.ToString("M/d/yyyy"))
        mySql &= vbCrLf & "ORDER BY LOANDATE ASC"
        Console.WriteLine(mySql)

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        Console.WriteLine("Count: " & ds.Tables(0).Rows.Count)
        ExpiryCache = ds.Tables(0)

        If frmNoti Is Nothing Then Exit Sub
        frmNoti.Show()
    End Sub

    Friend Function cleanup_contact(ByVal cl As Client) As String
        Dim c1 As String, c2 As String, c3 As String

        'Validate Contact Numbers
        c1 = validate_cp(cl.Cellphone1)
        c2 = validate_cp(cl.Cellphone2)
        c3 = validate_cp(cl.OtherNumber)

        If c1 = "INVALID" And c2 = "INVALID" And c3 = "INVALID" Then
            Return String.Format("{0}|{1}|{2}", c1, c2, c3)
        End If

        If c1 <> "INVALID" Then
            Return c1
        End If
        If c2 <> "INVALID" Then
            Return c2
        End If
        If c3 <> "INVALID" Then
            Return c3
        End If

        Return "INVALID"
    End Function

    Private Function validate_cp(ByVal str As String) As String
        '+639257977559
        If str.Length = 13 Then
            If str.Substring(0, 4) = "+639" Then
                Return str
            End If
        End If

        '639257977559
        If str.Length = 12 Then
            If str.Substring(0, 3) = "639" Then
                Return "+" & str
            End If
        End If

        '09259797559
        If str.Length = 11 Then
            If str.Substring(0, 2) = "09" Then
                Return "+63" & str.Substring(1)
            End If
        End If

        '9257977559
        If str.Length = 10 Then
            If str.Substring(0, 1) = "9" Then
                Return "+63" & str
            End If
        End If


        Return "INV-" & str
    End Function

    Friend Function MessageBuilder(ByVal msg As String, ByVal dr As DataRow) As String
        For Each colName As DataColumn In dr.Table.Columns
            Dim sanitize As String

            If msg.Contains(String.Format("%{0}%", colName.ToString)) Then
                If colName.DataType = GetType(System.DateTime) Then
                    sanitize = dr(colName)
                Else
                    sanitize = dr(colName)
                End If

                msg = msg.Replace(String.Format("%{0}%", colName.ToString), sanitize)
            End If
        Next

        Return msg
    End Function
End Module
