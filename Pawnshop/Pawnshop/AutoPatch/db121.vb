Module db121
    Const ALLOWABLE_VERSION As String = "1.2"
    Const LATEST_VERSION As String = "1.2.1"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim TBL_CURRENCY As String
        TBL_CURRENCY = "CREATE TABLE TBLCURRENCY ("
        TBL_CURRENCY &= vbCrLf & "  CURRENCYID INTEGER NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  CURRENCY VARCHAR(30) NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  SYMBOL VARCHAR(20) NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  RATE NUMERIC(12, 2) NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  CASHID INTEGER NOT NULL);"

        Try
            RunCommand(TBL_CURRENCY)

            AutoIncrement_ID("TBLCURRENCY", "CURRENCYID")

            RunCommand("ALTER TABLE TBLDOLLAR ADD CURRENCY VARCHAR(30) NOT NULL;")

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2 TO 1.2.1")
            MsgBox("SUCCESS!!!", MsgBoxStyle.Information)
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.2.1]")
        End Try
    End Sub
End Module
