Public Class frmMain

    Private DB_PATH As String
    Friend ALLOW_DBVERSION As String = "a1.0.18"
    Friend LATEST_DBVERSION As String = "1.0.3"

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        DB_PATH = txtURL.Text
        If Not System.IO.File.Exists(DB_PATH) Then
            MsgBox("Database URL not found", MsgBoxStyle.Critical, "Failed")
            Exit Sub
        End If

        If Not isPatchable() Then
            MsgBox("Database Version didn't match", MsgBoxStyle.Critical)
            Exit Sub
        End If

        database.dbName = DB_PATH
        If isUpdated() Then MsgBox("Database already been patched up", MsgBoxStyle.Information)
        Try
            _101sql.Main()
            _110.Main()
            Database_Update(LATEST_DBVERSION)
            Developers_Note("Database Updated!")

            MsgBox("Database has been PATCHED UP!", MsgBoxStyle.Information)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
        
    End Sub

    Private Function isPatchable() As Boolean
        Dim ds As DataSet, mySql As String
        mySql = "SELECT * FROM tblMAINTENANCE WHERE "
        mySql &= "OPT_KEYS = 'DBVersion'"
        ds = LoadSQL(mySql)

        If ds.Tables(0).Rows(0).Item("DBVersion") = ALLOW_DBVERSION Then
            Return True
        Else
            Developers_Note("Database Version is " & ds.Tables(0).Rows(0).Item("DBVersion"))
            Return False
        End If
    End Function

    Private Sub txtURL_DoubleClick(sender As Object, e As System.EventArgs) Handles txtURL.DoubleClick
        ofdPatch_DB.ShowDialog()
    End Sub

    Private Sub ofdPatch_DB_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofdPatch_DB.FileOk
        txtURL.Text = ofdPatch_DB.FileName
    End Sub
End Class
