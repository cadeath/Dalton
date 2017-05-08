Imports System.Data.Odbc

Module autopatch


    Friend Sub RunCommand(ByVal sql As String)
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"
        con = New OdbcConnection(conStr)

        Dim cmd As OdbcCommand
        cmd = New OdbcCommand(sql, con)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Log_Report(String.Format("[{0}] - ", sql) & ex.ToString)
            con.Dispose()
            Exit Sub
        End Try

        System.Threading.Thread.Sleep(1000)
    End Sub

    Friend Sub Database_Update(ByVal str As String)
        Dim mySql As String = "UPDATE tblMaintenance"
        mySql &= String.Format(" SET OPT_VALUES = '{0}' ", str)
        mySql &= "WHERE OPT_KEYS = 'DBVersion'"

        RunCommand(mySql)
    End Sub

    Friend Function ifTblExist(ByVal tblName As String) As Boolean
        Dim mySql As String
        mySql = "SELECT * FROM rdb$relations "
        mySql &= "WHERE "
        mySql &= String.Format("rdb$relation_name = '{0}'", tblName)

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Friend Sub AutoIncrement_ID(tbl As String, id As String)
        Dim GENERATOR As String
        GENERATOR = String.Format("CREATE GENERATOR {0}_{1}_GEN; ", tbl, id)
        RunCommand(GENERATOR)

        GENERATOR = String.Format("SET GENERATOR ""{0}_{1}_GEN"" TO 0;", tbl, id)
        RunCommand(GENERATOR)

        GENERATOR = String.Format("CREATE TRIGGER ""{0}_{1}_TRG"" FOR ""{0}""", tbl, id)
        GENERATOR &= vbCrLf & "ACTIVE BEFORE INSERT POSITION 0 AS"
        GENERATOR &= vbCrLf & "BEGIN"
        GENERATOR &= vbCrLf & String.Format("IF (NEW.""{1}"" IS NULL) THEN NEW.""{1}"" = GEN_ID(""{0}_{1}_GEN"", 1);", tbl, id)
        GENERATOR &= vbCrLf & "END;"
        RunCommand(GENERATOR)

        GENERATOR = String.Format("ALTER TABLE {0} ADD PRIMARY KEY ({1});", tbl, id)
        RunCommand(GENERATOR) 'ADDING PRIMARY KEY
    End Sub
End Module
