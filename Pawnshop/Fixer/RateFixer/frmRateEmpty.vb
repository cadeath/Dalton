Imports System.Data.Odbc

Public Class frmRateEmpty

    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub

    Private Sub btnFix_Click(sender As System.Object, e As System.EventArgs) Handles btnFix.Click
        database.dbName = txtDB.Text

        Dim delete_all As String = "DELETE FROM TBLINT WHERE INTID > 0"
        RunCommand(delete_all)

        Status_Display("RATE CLEANED")
        MsgBox("IT IS NOW READY TO CHANGE RATE")
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

    Private Sub frmRateEmpty_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub
End Class