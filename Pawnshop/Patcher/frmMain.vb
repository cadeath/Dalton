Public Class frmMain

    Dim dbLoc As String = ""

    Private Sub btnPatch_Click(sender As System.Object, e As System.EventArgs) Handles btnPatch.Click
        If dbLoc = "" Then
            MsgBox("Double Click the FORM to select DB Location", MsgBoxStyle.Information)
            Exit Sub
        End If

        mod_system.dbName = dbLoc
        db_intHash.do_update()
    End Sub

    Private Sub frmMain_DoubleClick(sender As Object, e As System.EventArgs) Handles Me.DoubleClick
        ofdDBName.ShowDialog()
    End Sub

    Private Sub ofdDBName_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofdDBName.FileOk
        dbLoc = ofdDBName.FileName
    End Sub

    Friend Sub AddProgress()
        pb_load.Value += 1
        Application.DoEvents()
    End Sub
End Class
