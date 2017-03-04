Public Class frmAddItemHistory
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub

    Private Sub frmAddItemHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        ItemHistory()
        Disable(0)
    End Sub

    Private Sub ItemHistory()
        Try
            Dim ItemTable As String = "CREATE TABLE ITEM_HISTORY ( "
            ItemTable &= "ID BIGINT NOT NULL, "
            ItemTable &= "ITEM_ID INTEGER NOT NULL, "
            ItemTable &= "REMARKS VARCHAR(50) CHARACTER SET NONE NOT NULL, "
            ItemTable &= "DATE_CREATED TIMESTAMP NOT NULL, "
            ItemTable &= "CREATED_BY VARCHAR(50) NOT NULL); "

            RunCommand(ItemTable)
            AutoIncrement_ID("ITEM_HISTORY", "ID")

            MsgBox("Succesfully Added", MsgBoxStyle.Information, "System New Update")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub
End Class