Imports System.Data.Odbc

Module autopatch

    Public Sub Patch_if_Patchable()
        db107.PatchUp()
        db108.PatchUp()
        db109.PatchUp()
        db1010.PatchUp()
        db1011.PatchUp()
        db1012.PatchUp()

        ' FOR v1.2
        db12.PatchUp()
    End Sub

    Friend Function isPatchable(ByVal allowVersion As String) As Boolean
        On Error GoTo err

        Dim mySql As String, ds As DataSet

        mySql = "SELECT * FROM TBLMAINTENANCE WHERE OPT_KEYS = 'DBVersion'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("PATCH PROBLEM", MsgBoxStyle.Critical) : Return False

        Return IIf(ds.Tables(0).Rows(0).Item("OPT_VALUES") = allowVersion, True, False)

err:
        MsgBox("PATCH PROBLEM UNKNOWN", MsgBoxStyle.Critical)
        Return False
    End Function

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

End Module
