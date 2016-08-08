Imports System.Data.Odbc
Public Class frmFixIntHistory
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
    Private Sub btnFix_Click(sender As System.Object, e As System.EventArgs) Handles btnFix.Click
        database.dbName = txtDB.Text
        Dim ALTER_TBLINTHISTORy_ADDCOLUMN As String = "alter table TBLINT_HISTORY add NINTEREST DECIMAL(12,3) not null"
        Dim ALTER_TBLINTHISTORY_COPYDATA As String = "Update TBLINT_HISTORY SET NINTEREST = INTEREST where INTID <> 0 "
        Dim ALTER_TBLINTHISTORY_DROPCOLUMN As String = "alter table TBLINT_HISTORY DROP INTEREST;"
        Dim ALTER_TBLINTHISTORY_RENAMECOLUMN As String = "alter table TBLINT_HISTORY alter column NINTEREST to INTEREST;"
        Dim ALTER_TBLINTHISTORY_vALUEiNTEREST As String = "UPDATE TBLINT_HISTORY set INTEREST = 0.025 where INTEREST = 0.02"
        Dim Alter_Pisition_column As String = " ALTER TABLE TBLINT_HISTORY ALTER COLUMN INTEREST POSITION 5;"

        RunCommand(ALTER_TBLINTHISTORy_ADDCOLUMN)
        RunCommand(ALTER_TBLINTHISTORY_COPYDATA)
        RunCommand(ALTER_TBLINTHISTORY_DROPCOLUMN)
        RunCommand(ALTER_TBLINTHISTORY_RENAMECOLUMN)
        RunCommand(ALTER_TBLINTHISTORY_vALUEiNTEREST) '0.25 to 0.025
        RunCommand(Alter_Pisition_column) 'Change Position Column
        Status_Display("MOD_NAME FIELD TYPE UPDATE")
        MsgBox("SUCCESSFUL")
    End Sub

    Private Sub frmFixIntHistory_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub
End Class