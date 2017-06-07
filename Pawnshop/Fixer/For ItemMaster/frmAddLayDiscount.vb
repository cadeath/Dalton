Public Class frmAddLayDiscount
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub frmAddLayDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(0)
        Try
            Dim addLayDiscount As String = "ALTER TABLE ITEMMASTER ADD LAYDISCOUNT SMALLINT DEFAULT '0' NOT NULL;"

            RunCommand(addLayDiscount)
            MsgBox("Successfully Added")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(1)
    End Sub
End Class