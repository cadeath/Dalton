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

        Dim CURRENCY_TRIGGER As String
        'CURRENCY_TRIGGER = "SET TERM ^ ;"
        CURRENCY_TRIGGER = ""
        CURRENCY_TRIGGER &= vbCrLf & "CREATE TRIGGER BI_TBLCURRENCY_CURRENCYID FOR TBLCURRENCY "
        CURRENCY_TRIGGER &= vbCrLf & "ACTIVE BEFORE INSERT "
        CURRENCY_TRIGGER &= vbCrLf & "POSITION 0 "
        CURRENCY_TRIGGER &= vbCrLf & "AS "
        CURRENCY_TRIGGER &= vbCrLf & "BEGIN "
        CURRENCY_TRIGGER &= vbCrLf & "  IF (NEW.CURRENCYID IS NULL) THEN"
        CURRENCY_TRIGGER &= vbCrLf & "      NEW.CURRENCYID = GEN_ID(TBLCURRENCY_CURRENCYID_GEN, 1);"
        CURRENCY_TRIGGER &= vbCrLf & "END" '^ WAS REMOVED
        CURRENCY_TRIGGER &= vbCrLf & ""
        'CURRENCY_TRIGGER &= vbCrLf & "SET TERM ; ^"

        Try
            RunCommand(TBL_CURRENCY)

            'RunCommand(CURRENCY_TRIGGER)


            Dim GENERATOR As String
            GENERATOR = "CREATE GENERATOR GEN_TBLCURRENCYS_CURRENCYID;"
            RunCommand(GENERATOR)

            GENERATOR = "CREATE TRIGGER BI_TBLCURRENCY_CURRENCYID FOR TBLCURRENCY "
            GENERATOR &= vbCrLf & "ACTIVE BEFORE INSERT "
            GENERATOR &= vbCrLf & "POSITION 0 "
            GENERATOR &= vbCrLf & "AS "
            GENERATOR &= vbCrLf & "BEGIN "
            GENERATOR &= vbCrLf & "  IF (NEW.CURRENCYID IS NULL) THEN"
            GENERATOR &= vbCrLf & "      NEW.CURRENCYID = GEN_ID(TBLCURRENCY_CURRENCYID_GEN, 1);"
            GENERATOR &= vbCrLf & "END "
            RunCommand(GENERATOR)

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2 TO 1.2.1")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.2.1]")
        End Try
    End Sub
End Module
