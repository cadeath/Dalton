Public Class frmRecompute

    Private Sub txtDB_DoubleClick(sender As Object, e As System.EventArgs) Handles txtDB.DoubleClick
        ofd_db.ShowDialog()
    End Sub

    Private Sub ofd_db_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofd_db.FileOk
        txtDB.Text = ofd_db.FileName
    End Sub

    Private Sub btnFix_Click(sender As System.Object, e As System.EventArgs) Handles btnFix.Click
        If txtDB.Text = "" Then Exit Sub

        Me.Enabled = False
        recompute.Validate()
        Me.Enabled = True
    End Sub
End Class