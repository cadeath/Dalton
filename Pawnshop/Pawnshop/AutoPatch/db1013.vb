Module db1013
    Const ALLOWABLE_VERSION As String = "1.0.12"
    Const LATEST_VERSION As String = "1.0.13"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try
            ' Add INT_CHECK at TBLPAWN
            Dim INT_CHECK As String = _
                "ALTER TABLE TBLPAWN ADD INT_CHECKSUM VARCHAR(100);"

            RunCommand(INT_CHECK)

            ' HASH table TBLINT
            Dim INT_HASH As String, ds As DataSet
            Dim mySql As String = "SELECT DAYFROM, DAYTO, ITEMTYPE, INTEREST, PENALTY, REMARKS FROM TBLINT"
            ds = LoadSQL(mySql)
            INT_HASH = GetMD5(ds)

            mySql = "SELECT * FROM TBLPAWN WHERE STATUS <> 'V'"
            Dim fillData As String = "TBLPAWN"
            ds = LoadSQL(mySql, fillData)

            If ds.Tables(0).Rows.Count > 0 Then
                For Each dr As DataRow In ds.Tables(fillData).Rows
                    dr("INT_CHECKSUM") = INT_HASH

                Next
                database.SaveEntry(ds, False)
            End If
        Catch ex As Exception
            Log_Report("[HASHING] " & ex.ToString)
        End Try

        Do_IntHistory() 'Update Database - INTEREST HISTORY
        Do_HitManagement() 'Update Database - HIT MANAGEMENT

        Database_Update(LATEST_VERSION)
        Log_Report("DATABASE UPDATED - V1.0.13")
        MsgBox("Database Patched")
    End Sub

    Private Sub Do_IntHistory()
        Dim ADD_INTHIST As String
        ADD_INTHIST = "CREATE TABLE TBLINT_HISTORY ("
        ADD_INTHIST &= vbCrLf & "  INTID BIGINT NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  DAYFROM INTEGER DEFAULT '0' NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  DAYTO SMALLINT DEFAULT '0' NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  ITEMTYPE VARCHAR(3) DEFAULT '' NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  INTEREST DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  PENALTY DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  REMARKS VARCHAR(100),"
        ADD_INTHIST &= vbCrLf & "  CHECKSUM VARCHAR(50) DEFAULT '' NOT NULL,"
        ADD_INTHIST &= vbCrLf & "  UPDATE_DATE DATE);"

        RunCommand(ADD_INTHIST)
        RunCommand("ALTER TABLE TBLINT_HISTORY ADD PRIMARY KEY (INTID);")

        AutoIncrement_ID("TBLINT_HISTORY", "INTID")
    End Sub

    Private Sub Do_HitManagement()
        Dim ADD_HIT As String
        ADD_HIT = "CREATE TABLE TBLHIT ( "
        ADD_HIT &= vbCrLf & "  HITID BIGINT NOT NULL,"
        ADD_HIT &= vbCrLf & "  HIT_DATE DATE NOT NULL,"
        ADD_HIT &= vbCrLf & "  PAWNID BIGINT NOT NULL,"
        ADD_HIT &= vbCrLf & "  PAWNER VARCHAR(255) NOT NULL,"
        ADD_HIT &= vbCrLf & "  PT BIGINT NOT NULL);"

        RunCommand(ADD_HIT)
        RunCommand("ALTER TABLE TBLHIT ADD PRIMARY KEY (HITID);")

        AutoIncrement_ID("TBLHIT", "HITID")
    End Sub
End Module
