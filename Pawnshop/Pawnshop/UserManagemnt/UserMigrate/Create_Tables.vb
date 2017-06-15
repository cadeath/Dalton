Module Create_Tables
    Dim mysql As String = String.Empty
    Dim s_USER As New Sys_user
    Dim save_Upriv As New User_rule

    Dim PRIVILEGE_FROM_OLD_TABLE As String

    Dim old_tabl As String = "tbl_gamit"
    Dim tbluserNEW As String = "tbl_user_default"
    Dim tbluserHist As String = "tbluser_history"

    Friend Sub Initialization() ''''
        PLoading.ShowDialog()

        Create_User_Rule_Table()
        Create_User_table()
        Create_User_history()
        Create_User_LINE()

        User_Migrate()
    End Sub


    Friend Sub Create_User_Rule_Table()
        If ifTblExist("TBL_USERRULE") Then
            Exit Sub
        End If

        Dim TBL_USERRULE As String
        TBL_USERRULE = "CREATE TABLE TBL_USERRULE ("
        TBL_USERRULE &= vbCrLf & "  USERRULE_ID BIGINT NOT NULL,"
        TBL_USERRULE &= vbCrLf & "   PRIVILEGE_TYPE VARCHAR(50) NOT NULL);"
        Try
            RunCommand(TBL_USERRULE)
            AutoIncrement_ID("TBL_USERRULE", "USERRULE_ID")
        Catch ex As Exception
            Console.WriteLine("Sql error.")
            Exit Sub
        End Try
    End Sub

    Friend Sub Create_User_LINE()
        If ifTblExist("TBL_USERLINE") Then
            Exit Sub
        End If

        Dim TBL_USERRULE As String
        TBL_USERRULE = "CREATE TABLE TBL_USERLINE ("
        TBL_USERRULE &= vbCrLf & "  USERLINE_ID BIGINT NOT NULL,"
        TBL_USERRULE &= vbCrLf & "   USERID INTEGER NOT NULL,"
        TBL_USERRULE &= vbCrLf & "   PRIVILEGE_TYPE VARCHAR(50) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  ACCESS_TYPE VARCHAR(15) NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  DATE_UPDATED_LINE DATE NOT NULL,"
        TBL_USERRULE &= vbCrLf & "  DATE_CREATED_LINE DATE NOT NULL);"

        Try
            RunCommand(TBL_USERRULE)
            AutoIncrement_ID("TBL_USERLINE", "USERLINE_ID")
        Catch ex As Exception
            Console.WriteLine("Sql error.")
            Exit Sub
        End Try

    End Sub
    'is expire field to be added
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
        TBL_USERRULE &= vbCrLf & "  AGE INTEGER,ENCODERID INTEGER,"
        TBL_USERRULE &= vbCrLf & " LASTLOGIN TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0),"
        TBL_USERRULE &= vbCrLf & " PASSWORD_AGE DATE NOT NULL,SYSTEMINFO TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0),"
        TBL_USERRULE &= vbCrLf & " PASSWORD_EXPIRY DATE,ISEXPIRED VARCHAR(1) NOT NULL,"
        TBL_USERRULE &= vbCrLf & " EXPIRY_COUNTER INTEGER,FAILEDATTEMPNUM INTEGER,FAILEDATTEMPSTAT VARCHAR(10),"
        TBL_USERRULE &= vbCrLf & " USERTYPE VARCHAR(15) NOT NULL,STATUS VARCHAR(1) NOT NULL);"


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


    Private Sub User_Migrate()
        mysql = "SELECT * FROM " & old_tabl & " ORDER BY USERID ASC"
        Dim ds As DataSet = LoadSQL(mysql, old_tabl)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        PLoading.Set_Bar(ds.Tables(0).Rows.Count)
        PLoading.Reset_Bar()

        Dim tblID As String = ""
        Dim privileges As String = ""
        Dim iCount As Integer = ds.Tables(0).Rows.Count
        For Each dr As DataRow In ds.Tables(0).Rows
            tblID = dr.Item("USERID")
            privileges = dr.Item("PRIVILEGE")
            With s_USER
                .ID = dr.Item("USERID")
                privileges = dr.Item("PRIVILEGE")

                .USERNAME = dr.Item("Username")

                .FIRSTNAME = dr.Item("Fullname")

                .LASTNAME = "Not define"

                .USERPASS = dr.Item("Userpass")

                .GENDER = "No Gen"

                .BIRTHDAY = "01/01/1992"

                If IsDBNull(dr.Item("EncoderID")) Then
                    .EncoderID = 0
                Else
                    .EncoderID = dr.Item("EncoderID")
                End If


                If IsDBNull(dr.Item("LastLogin")) Then
                    .LastLogin = "01/01/0001"
                Else
                    .LastLogin = dr.Item("LastLogin")
                End If

                .PASSWORD_AGE = "01/01/0001"
                .ISEXPIRED = 0

                .FAILEDATTEMPNUM = 3
                If dr.Item("Username") = "POSadmin" Then
                    .USERTYPE = "Admin"
                Else
                    .USERTYPE = "User"
                End If

                .UserStatus = dr.Item("Status")

                .add_USER()
            End With

            PRIVILEGE_FROM_OLD_TABLE = dr.Item("Privilege")

            PLoading.Add_Bar()
            Application.DoEvents()

        Next

        mysql = "CREATE TRIGGER BI_tbl_user_default_USERID FOR tbl_user_default "
        mysql &= vbCrLf & "ACTIVE BEFORE INSERT "
        mysql &= vbCrLf & "POSITION 0 "
        mysql &= vbCrLf & "AS "
        mysql &= vbCrLf & "BEGIN "
        mysql &= vbCrLf & "  IF (NEW.USERID IS NULL) THEN "
        mysql &= vbCrLf & "      NEW.USERID = GEN_ID(tbl_user_default_USERID_GEN, " & tblID + 1 & "); "
        mysql &= vbCrLf & "END; "
        RunCommand(mysql)


        If MsgBox("Successfully Migrated", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
            "Migrating...") = MsgBoxResult.Ok Then PLoading.pbLoading.Minimum = 0 : PLoading.pbLoading.Value = 0 : PLoading.lblStatus.Text = "0.00%"

    End Sub
End Module
