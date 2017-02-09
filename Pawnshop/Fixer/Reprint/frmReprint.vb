Public Class frmReprint
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub frmReprint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub

    Private Sub Reprint()
        Dim Reprint As String = "CREATE TABLE TBLREPRINT ( "
        Reprint &= "REPRINTID BIGINT NOT NULL, "
        Reprint &= "PAWNTICKET VARCHAR(20) NOT NULL, "
        Reprint &= "TRANSNAME VARCHAR(50) NOT NULL, "
        Reprint &= "REPRINT_AT DATE NOT NULL, "
        Reprint &= "REPRINT_BY SMALLINT NOT NULL); "

        RunCommand(Reprint)
        AutoIncrement_ID("TBLREPRINT", "REPRINTID")
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Try
            Reprint()
            MsgBox("Success", MsgBoxStyle.Information, "Information")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub
End Class