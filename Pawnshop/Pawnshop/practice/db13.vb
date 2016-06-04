Module db13
    Const ALLOWABLE_VERSION As String = "1.0.14"
    Const LATEST_VERSION As String = "1.0.13"
    Private TABLE_NAME As String = "TBLCURRENCY"

    Sub PatchUp()
        Try
            Dim mySql As String
            If Not ifTblExist(TABLE_NAME) Then
                mySql = "CREATE TABLE TBLCURRENCY ( "
                mySql &= vbCrLf & "CURRENCYID BIGINT NOT NULL, "
                mySql &= vbCrLf & " CURRENCY VARCHAR(30) NOT NUL, "
                mySql &= vbCrLf & "SYMBOL VARCHAR(20) NOT NULL, "
                mySql &= vbCrLf & " RATE NUMERIC(12, 2) NOT NULL, "
                mySql &= vbCrLf & " CASHID INTEGER NOT NULL); "
                RunCommand(mySql)

                mySql = "ALTER TABLE TBLDOLLAR ADD CURRENCY VARCHAR(30)NOT NULL;"
                RunCommand(mySql)

          mySql = "CREATE TRIGGER BI_TBL_DAILYTIMELOG_LOGS_ID FOR TBL_DAILYTIMELOG "
                mySql &= vbCrLf & "ACTIVE BEFORE INSERT "
                mySql &= vbCrLf & "POSITION 0 "
                mySql &= vbCrLf & "AS "
                mySql &= vbCrLf & "BEGIN "
                mySql &= vbCrLf & "  IF (NEW.LOGS_ID IS NULL) THEN "
                mySql &= vbCrLf & "      NEW.LOGS_ID = GEN_ID(TBL_DAILYTIMELOG_LOGS_ID_GEN, 1); "
                mySql &= vbCrLf & "END; "
                RunCommand(mySql)
            End If

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.8 TO 1.0.9")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.0.9]")
        End Try
    End Sub
End Module
