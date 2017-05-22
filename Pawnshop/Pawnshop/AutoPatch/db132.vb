Module db132
    Const ALLOWABLE_VERSION As String = "1.3.2"
    Const LATEST_VERSION As String = "1.3.3"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            AddDailyFields()


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
        CreateView &= "D.SMARTMONEYCNT, D.SMARTWALLETCNT, D.ELOADCNT "
        CreateView &= "FROM tblDaily D "

        RunCommand(SmartMnyCnt)
        RunCommand(SmartWalletCnt)
        RunCommand(EloadCnt)

        RunCommand(DropView)
        RunCommand(CreateView)
    End Sub
End Module
