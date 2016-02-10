Public Class frmMain

    Private DB_PATH As String
    Friend LATEST_DBVERSION As String = "1.0.1"

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        DB_PATH = txtURL.Text
        If Not System.IO.File.Exists(DB_PATH) Then
            MsgBox("Database URL not found", MsgBoxStyle.Critical, "Failed")
            Exit Sub
        End If

        database.dbName = DB_PATH
        If isUpdated() Then MsgBox("Database already been patched up", MsgBoxStyle.Information)

        _101sql.Main()
        Database_Update(LATEST_DBVERSION)
        Developers_Note("Database Updated!")

        MsgBox("Database has been PATCHED UP!", MsgBoxStyle.Information)
    End Sub
End Class
