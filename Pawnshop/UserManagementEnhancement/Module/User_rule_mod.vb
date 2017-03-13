Module User_rule_mod

    Friend Sub Create_User_Rule_Table()
        If ifTblExist("TBL_USERRULE") Then
            Exit Sub
        End If

        Dim TBL_USERRULE As String
        TBL_USERRULE = "CREATE TABLE TBL_USERRULE ("
        TBL_USERRULE &= vbCrLf & "  USERRULE_ID BIGINT NOT NULL,"
        TBL_USERRULE &= vbCrLf & "   PRIVILEGE_TYPE VARCHAR(50) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  ACCESS_TYPE VARCHAR(1) NOT NULL);"
        RunCommand(TBL_USERRULE)

        Try
            TBL_USERRULE = "ALTER TABLE TBL_USERRULE ADD PRIMARY KEY (USERRULE_ID) USING INDEX RDB$PRIMARY109;"
            RunCommand(TBL_USERRULE)

            TBL_USERRULE = "CREATE TRIGGER BI_TBL_USERRULE_USERRULE_ID FOR TBL_USERRULE"
            TBL_USERRULE &= vbCrLf & "ACTIVE BEFORE INSERT "
            TBL_USERRULE &= vbCrLf & "POSITION 0 "
            TBL_USERRULE &= vbCrLf & "AS "
            TBL_USERRULE &= vbCrLf & "BEGIN "
            TBL_USERRULE &= vbCrLf & "IF (NEW.USERRULE_ID IS NULL) THEN "
            TBL_USERRULE &= vbCrLf & "NEW.USERRULE_ID = GEN_ID(TBL_USERRULE_USERRULE_ID_GEN2, 1); "
            TBL_USERRULE &= vbCrLf & "END "

            RunCommand(TBL_USERRULE)
        Catch ex As Exception
            Console.WriteLine("Sql error.")
            Exit Sub
        End Try

    End Sub

    Friend Sub Create_User_table()
        If ifTblExist("TBL_USER_DEFAULT") Then
            Exit Sub
        End If

        Dim TBL_USERRULE As String
        TBL_USERRULE = "CREATE TABLE TBL_USER_DEFAULT ("
        TBL_USERRULE &= vbCrLf & " USERID BIGINT NOT NULL,USERNAME VARCHAR(100),"
        TBL_USERRULE &= vbCrLf & "FIRSTNAME VARCHAR(50),MIDDLENAME VARCHAR(50),"
        TBL_USERRULE &= vbCrLf & " LASTNAME VARCHAR(60), USERPASS VARCHAR(255),"
        TBL_USERRULE &= vbCrLf & "  EMAIL_ADDRESS VARCHAR(255),CONTACTNO INTEGER,"
        TBL_USERRULE &= vbCrLf & " BIRTHDAY DATE,GENDER VARCHAR(6),"
        TBL_USERRULE &= vbCrLf & "  AGE INTEGER,PRIVILEGE VARCHAR(50),"
        TBL_USERRULE &= vbCrLf & " LASTLOGIN TIMESTAMP,ENCODERID SMALLINT,"
        TBL_USERRULE &= vbCrLf & " EXPIRYDATE DATE,SYSTEMINFO DATE,"
        TBL_USERRULE &= vbCrLf & " STATUS VARCHAR(1));"


        Try
            RunCommand(TBL_USERRULE)

            RunCommand("ALTER TABLE TBL_USER_DEFAULT ADD PRIMARY KEY (USERID) USING INDEX RDB$PRIMARY18;")

            TBL_USERRULE = "CREATE TRIGGER BI_TBL_USER_DEFAULT_USERID FOR TBL_USER_DEFAULT"
            TBL_USERRULE &= vbCrLf & "ACTIVE BEFORE INSERT "
            TBL_USERRULE &= vbCrLf & "POSITION 0 "
            TBL_USERRULE &= vbCrLf & "AS "
            TBL_USERRULE &= vbCrLf & "BEGIN "
            TBL_USERRULE &= vbCrLf & "IF (NEW.USERID IS NULL) THEN "
            TBL_USERRULE &= vbCrLf & "NEW.USERID = GEN_ID(TBL_USER_DEFAULT_USERID_GEN1, 1); "
            TBL_USERRULE &= vbCrLf & "END "

            RunCommand(TBL_USERRULE)
        Catch ex As Exception
            Console.WriteLine("Sql error.")
            Exit Sub
        End Try
    End Sub

    Friend Sub Create_User_history()
        If ifTblExist("TBLUSER_HISTORY") Then
            Exit Sub
        End If

        Dim TBL_USERRULE As String
        TBL_USERRULE = "CREATE TABLE TBLUSER_HISTORY ("
        TBL_USERRULE &= vbCrLf & "  USER_HISTID BIGINT NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  USERID SMALLINT NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  USERPASS VARCHAR(255) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  COUNTER VARCHAR(1) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  DATE_CREATED TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"
        RunCommand(TBL_USERRULE)

        Try
            TBL_USERRULE = "ALTER TABLE TBLUSER_HISTORY ADD PRIMARY KEY (USER_HISTID) USING INDEX RDB$PRIMARY110;"
            RunCommand(TBL_USERRULE)

            TBL_USERRULE = "CREATE TRIGGER BI_TBLUSER_HISTORY_USER_HISTID FOR TBLUSER_HISTORY"
            TBL_USERRULE &= vbCrLf & "ACTIVE BEFORE INSERT "
            TBL_USERRULE &= vbCrLf & "POSITION 0 "
            TBL_USERRULE &= vbCrLf & "AS "
            TBL_USERRULE &= vbCrLf & "BEGIN "
            TBL_USERRULE &= vbCrLf & "IF (NEW.USER_HISTID IS NULL) THEN "
            TBL_USERRULE &= vbCrLf & "NEW.USER_HISTID = GEN_ID(TBLUSER_HISTORY_USER_HISTID_GEN, 1); "
            TBL_USERRULE &= vbCrLf & "END "

            RunCommand(TBL_USERRULE)
        Catch ex As Exception
            Console.WriteLine("Sql error.")
            Exit Sub
        End Try

    End Sub
End Module
