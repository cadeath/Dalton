Imports System.Data.Odbc

Public Class frmFixModname
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub
    Private Sub frmFixModname_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub
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

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        database.dbName = txtDB.Text
        Dim ADDCOLUMN As String = "ALTER TABLE TBL_DAILYTIMELOG ADD MOD_NAME2 VARCHAR(50);"
        Dim COPYDATA As String = "UPDATE TBL_DAILYTIMELOG  SET MOD_NAME2 = MOD_NAME WHERE LOGS_ID <> 0 AND USERID <> 0 "
        Dim DROPCOLUMN As String = "ALTER TABLE TBL_DAILYTIMELOG DROP MOD_NAME"
        Dim RENAMECOLUMN As String = "ALTER TABLE TBL_DAILYTIMELOG ALTER COLUMN MOD_NAME2 TO MOD_NAME"
        Dim POSITION As String = "ALTER TABLE TBL_DAILYTIMELOG ALTER COLUMN MOD_NAME POSITION 3"


        RunCommand(ADDCOLUMN)
        RunCommand(COPYDATA)
        RunCommand(DROPCOLUMN)
        RunCommand(RENAMECOLUMN)
        RunCommand(POSITION)
        Status_Display("MOD_NAME FIELD TYPE UPDATE")
        MsgBox("SUCCESSFUL")
    End Sub
End Class