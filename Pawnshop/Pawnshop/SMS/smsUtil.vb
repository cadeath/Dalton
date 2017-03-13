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
        If Not isReady() Then
            MsgBox("SMS Initialization not yet ready", MsgBoxStyle.Critical)
            Exit Sub
        End If
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

    Friend Sub displayExpiry(ByVal lvExp As ListView, ByVal notiForm As Form)
        Dim mySql As String = _
            String.Format("SELECT * FROM PAWN_LIST WHERE EXPIRYDATE = '{0}' AND STATUS <> 'V'", CurrentDate)
        mySql &= vbCrLf & "ORDER BY LOANDATE ASC"
        Console.WriteLine(mySql)

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim ptExpired As New PawnTicket2
            ptExpired.Load_PTid(dr("PAWNID"))

            With ptExpired
                Dim lv As ListViewItem = lvExp.Items.Add(.PawnTicket)
                lv.SubItems.Add(String.Format("{0} {1}", .Pawner.FirstName, .Pawner.LastName))
                lv.SubItems.Add(cleanup_contact(ptExpired))
                lv.SubItems.Add(.PawnItem.ItemClass.ClassName)
                lv.SubItems.Add(.Principal.ToString("#,##0.00"))
            End With
        Next

        notiForm.Show()
    End Sub

    Private Function cleanup_contact(ByVal pt As PawnTicket2) As String
        Dim c1 As String, c2 As String, c3 As String

        'Validate Contact Numbers
        c1 = validate_cp(pt.Pawner.Cellphone1)
        c2 = validate_cp(pt.Pawner.Cellphone2)
        c3 = validate_cp(pt.Pawner.OtherNumber)

        If c1 = "INVALID" And c2 = "INVALID" And c3 = "INVALID" Then
            Return String.Format("INVALID>{0}|{1}|{2}", c1, c2, c3)
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


        Return "INVALID"
    End Function
End Module
