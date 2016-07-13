Imports System.Data.Odbc
Public Class frmFixJournalAndDailyTimeLog

    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
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
    Private Sub frmFixJournalAndDailyTimeLog_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(sender As System.Object, e As System.EventArgs) Handles btnFix.Click
        database.dbName = txtDB.Text
        Dim ADDTransID_Journal As String = "ALTER TABLE TBLJOURNAL ADD TRANSID BIGINT;"
        Dim ADDDailyTimeLog As String = "ALTER TABLE TBL_DAILYTIMELOG ADD TRANSID BIGINT;"

        RunCommand(ADDTransID_Journal)
        RunCommand(ADDDailyTimeLog)
        Status_Display("Journal And Daily Time Log Cleaned")
        MsgBox("IT IS NOW READY TO Fix Journal And Daily Time ")
    End Sub
End Class