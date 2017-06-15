Module db132
    Const ALLOWABLE_VERSION As String = "1.3.1"
    Const LATEST_VERSION As String = "1.3.2"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            AddDailyFields()
            Update_ItemMasterTbl()
            OTPControl()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub AddDailyFields()
        Dim SmartMnyCnt As String = "ALTER TABLE TBLDAILY ADD SMARTMONEYCNT NUMERIC(12, 2) DEFAULT '0.0' NOT NULL;"
        Dim SmartWalletCnt As String = "ALTER TABLE TBLDAILY ADD SMARTWALLETCNT NUMERIC(12, 2) DEFAULT '0.0' NOT NULL;"
        Dim EloadCnt As String = "ALTER TABLE TBLDAILY ADD ELOADCNT NUMERIC(12, 2) DEFAULT '0.0' NOT NULL;"

        Dim DropView As String = "DROP VIEW DAILY;"

        Dim CreateView As String = "CREATE VIEW DAILY( "
        CreateView &= "CURRENTDATE, "
        CreateView &= "MAINTAINBAL, "
        CreateView &= "INITIALBAL, "
        CreateView &= "CASHCOUNT, "
        CreateView &= "REMARKS, "
        CreateView &= "SMARTMONEYCNT, "
        CreateView &= "SMARTWALLETCNT, "
        CreateView &= "ELOADCNT) "
        CreateView &= "AS SELECT "
        CreateView &= "D.CurrentDate, D.MaintainBal, D.InitialBal,D.CashCount,D.Remarks, "
        CreateView &= vbCrLf & "D.SMARTMONEYCNT, D.SMARTWALLETCNT, D.ELOADCNT "
        CreateView &= vbCrLf & "FROM tblDaily D "

        RunCommand(SmartMnyCnt)
        RunCommand(SmartWalletCnt)
        RunCommand(EloadCnt)

        RunCommand(DropView)
        RunCommand(CreateView)
    End Sub

    Private Sub Update_ItemMasterTbl()
        Dim myql As String = "ALTER TABLE ITEMMASTER ADD DISCOUNT NUMERIC(12, 2) DEFAULT '0.0' NOT NULL;"
        RunCommand(myql)
    End Sub

    Private Sub OTPControl()
        Dim OTP As String = "CREATE TABLE OTPCONTROL ( "
        OTP &= "OTPID SMALLINT NOT NULL, "
        OTP &= "MODNAME VARCHAR(50) NOT NULL, "
        OTP &= "OTPCODE VARCHAR(20) NOT NULL, "
        OTP &= "APPNAME VARCHAR(150) NOT NULL, "
        OTP &= "STATUS SMALLINT DEFAULT '1' NOT NULL);"

        RunCommand(OTP)
        AutoIncrement_ID("OTPCONTROL", "OTPID")
    End Sub
End Module
