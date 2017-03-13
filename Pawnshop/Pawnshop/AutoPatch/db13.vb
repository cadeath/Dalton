Module db13
    Const ALLOWABLE_VERSION As String = "1.2.3.2"
    Const LATEST_VERSION As String = "1.3"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Add_Field_Sent_Notice()
            Add_Table_SMS()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Add_Field_Sent_Notice()
        Dim mySql As String = "ALTER TABLE OPT ADD SENT_NOTICE SMALLINT DEFAULT '0' NOT NULL;"
        RunCommand(mySql)

        Console.WriteLine("OPT Updated")
    End Sub

    Private Sub Add_Table_SMS()
        Dim sms As String
        sms = "CREATE TABLE SMS ("
        sms &= vbCrLf & "  SMSID BIGINT NOT NULL,"
        sms &= vbCrLf & "  SMSDATE DATE NOT NULL,"
        sms &= vbCrLf & "  PAWNID BIGINT DEFAULT '0' NOT NULL,"
        sms &= vbCrLf & "  PAWNTICKET INTEGER DEFAULT '0' NOT NULL,"
        sms &= vbCrLf & "  CLIENTID INTEGER DEFAULT '0' NOT NULL,"
        sms &= vbCrLf & "  SMS_MSG VARCHAR(200),"
        sms &= vbCrLf & "  CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"

        RunCommand(sms)
        AutoIncrement_ID("SMS", "SMSID")

        Console.WriteLine("Table SMS Created")
    End Sub
End Module
