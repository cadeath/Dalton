Module db109

    Const ALLOWABLE_VERSION As String = "1.0.8"
    Const LATEST_VERSION As String = "1.0.9"

    Private TABLE_NAME As String = "TBL_DAILYTIMELOG"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try
            Dim mySql As String
            If Not ifTblExist(TABLE_NAME) Then
                mySql = "CREATE TABLE TBL_DAILYTIMELOG ( "
                mySql &= vbCrLf & "LOGS_ID BIGINT NOT NULL, "
                mySql &= vbCrLf & "MOD_NAME VARCHAR(20), "
                mySql &= vbCrLf & "TIMELY TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL, "
                mySql &= vbCrLf & "LOG_REPORT VARCHAR(255), "
                mySql &= vbCrLf & "REMARKS VARCHAR(255), "
                mySql &= vbCrLf & "HASCUSTOMER SMALLINT DEFAULT '1' NOT NULL); "
                RunCommand(mySql)

                mySql = "ALTER TABLE TBL_DAILYTIMELOG ADD PRIMARY KEY (LOGS_ID);"
                RunCommand(mySql)

                mySql = "CREATE GENERATOR TBL_DAILYTIMELOG_LOGS_ID_GEN; 
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
