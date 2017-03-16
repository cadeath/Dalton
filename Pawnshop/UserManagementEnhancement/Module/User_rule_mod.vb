Module User_rule_mod

    Friend Sub Create_User_Rule_Table()
        If ifTblExist("TBL_USERRULE") Then
            Exit Sub
        End If

        Dim TBL_USERRULE As String
        TBL_USERRULE = "CREATE TABLE TBL_USERRULE ("
        TBL_USERRULE &= vbCrLf & "  USERRULE_ID BIGINT NOT NULL,"
        TBL_USERRULE &= vbCrLf & "   PRIVILEGE_TYPE VARCHAR(50) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  ACCESS_TYPE VARCHAR(15) NOT NULL);"


        Try
            RunCommand(TBL_USERRULE)
            AutoIncrement_ID("TBL_USERRULE", "USERRULE_ID")
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
        TBL_USERRULE &= vbCrLf & " USERID BIGINT NOT NULL,USERNAME VARCHAR(100) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "FIRSTNAME VARCHAR(50) NOT NULL,MIDDLENAME VARCHAR(50),"
        TBL_USERRULE &= vbCrLf & " LASTNAME VARCHAR(60) NOT NULL, USERPASS VARCHAR(255) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  EMAIL_ADDRESS VARCHAR(255),CONTACTNO VARCHAR(11),"
        TBL_USERRULE &= vbCrLf & " BIRTHDAY DATE,GENDER VARCHAR(6) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  AGE INTEGER,PRIVILEGE VARCHAR(50),"
        TBL_USERRULE &= vbCrLf & " LASTLOGIN TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0),"
        TBL_USERRULE &= vbCrLf & " EXPIRYDATE DATE NOT NULL,SYSTEMINFO TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0),"
        TBL_USERRULE &= vbCrLf & " DAYS_COUNT INTEGER,"
        TBL_USERRULE &= vbCrLf & " STATUS VARCHAR(1) NOT NULL);"


        Try
            RunCommand(TBL_USERRULE)

            AutoIncrement_ID("TBL_USER_DEFAULT", "USERID")
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
        TBL_USERRULE &= vbCrLf & "  DATE_CREATED TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"

        Try
            RunCommand(TBL_USERRULE)

            AutoIncrement_ID("TBLUSER_HISTORY", "USER_HISTID")
        Catch ex As Exception
            Console.WriteLine("sql error")
        End Try
      
    End Sub
End Module
