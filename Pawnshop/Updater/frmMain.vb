Public Class frmMain

    Private DB_PATH As String
    Friend ALLOW_DBVERSION As String = "1.0.6"
    Friend LATEST_DBVERSION As String = "1.0.7"

    Private Sub Special_Update()
        DB_PATH = txtURL.Text
        database.dbName = DB_PATH
        db_104to105.Main()

        MsgBox("Updated!")
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        DB_PATH = txtURL.Text
        If Not System.IO.File.Exists(DB_PATH) Then
            MsgBox("Database URL not found", MsgBoxStyle.Critical, "Failed")
            Exit Sub
        End If

        database.dbName = DB_PATH
        If Not isPatchable() Then
            MsgBox("Database Version didn't match" & vbCrLf & "Looking for v" & ALLOW_DBVERSION, MsgBoxStyle.Critical)
            Exit Sub
        End If

        If isUpdated() Then MsgBox("Database already been patched up", MsgBoxStyle.Information)
        Try
            db_106to107.do_fixing()
            Database_Update(LATEST_DBVERSION)
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

        Try
            If ds.Tables(0).Rows(0).Item("OPT_VALUES") = ALLOW_DBVERSION Then
                Return True
            Else
                Developers_Note("Database Version is " & ds.Tables(0).Rows(0).Item("OPT_VALUES"))
                Return False
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "ERROR PATCHING")
        End Try

        Return False
    End Function

    Private Sub txtURL_DoubleClick(sender As Object, e As System.EventArgs) Handles txtURL.DoubleClick
        ofdPatch_DB.ShowDialog()
    End Sub

    Private Sub ofdPatch_DB_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofdPatch_DB.FileOk
        txtURL.Text = ofdPatch_DB.FileName
    End Sub

    Private Sub frmMain_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        Special_Update()
        frmSrvUpdate.Show()
    End Sub

End Class
