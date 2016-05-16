Module db12
    Const LATEST_VERSION As String = "1.2"

    Sub PatchUp()
        Try
            Dim ADD_INTHIST As String
            ADD_INTHIST = "CREATE TABLE TBLINT_HISTORY ( "
            ADD_INTHIST &= vbCrLf & "  INTID BIGINT NOT NULL,"
            ADD_INTHIST &= vbCrLf & "  DAYFROM INTEGER DEFAULT '0' NOT NULL,"
            ADD_INTHIST &= vbCrLf & "  DAYTO SMALLINT DEFAULT '0' NOT NULL,"
            ADD_INTHIST &= vbCrLf & "  ITEMTYPE VARCHAR(3) DEFAULT '' NOT NULL,"
            ADD_INTHIST &= vbCrLf & "  INTEREST DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
            ADD_INTHIST &= vbCrLf & "  PENALTY DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
            ADD_INTHIST &= vbCrLf & "  REMARKS VARCHAR(100),"
            ADD_INTHIST &= vbCrLf & "  CHECKSUM VARCHAR(50) DEFAULT '' NOT NULL);"

            Dim ADD_HIT As String
            ADD_HIT = "CREATE TABLE TBLHIT ( "
            ADD_HIT &= vbCrLf & "  HITID BIGINT NOT NULL,"
            ADD_HIT &= vbCrLf & "  HIT_DATE DATE NOT NULL,"
            ADD_HIT &= vbCrLf & "  PAWNID BIGINT NOT NULL,"
            ADD_HIT &= vbCrLf & "  PAWNER VARCHAR(255) NOT NULL,"
            ADD_HIT &= vbCrLf & "  PT BIGINT NOT NULL);"

            If Not ifTblExist("TBLHIT") Then
                RunCommand(ADD_HIT)
                RunCommand("ALTER TABLE TBLHIT ADD PRIMARY KEY (HITID);")
            End If

            If Not ifTblExist("TBLINT_HISTORY") Then
                RunCommand(ADD_INTHIST)
                RunCommand("ALTER TABLE TBLINT_HISTORY ADD PRIMARY KEY (INTID);")
            End If

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP TO " & LATEST_VERSION)
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
    End Sub
End Module