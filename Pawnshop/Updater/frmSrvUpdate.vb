Public Class frmSrvUpdate

    Private Sub txtSrc_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrc.DoubleClick
        ofdSource.ShowDialog()
    End Sub

    Private Sub txtDest_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDest.DoubleClick
        ofdDest.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not System.IO.File.Exists(txtSrc.Text) Then Exit Sub
        If Not System.IO.File.Exists(txtDest.Text) Then Exit Sub

        Dim services As DataSet = ExtractServices2ds(txtSrc.Text)

        database.dbName = txtDest.Text
        Update_Services(services)

        MsgBox("Services sychronized.")
    End Sub

    Private Sub ofdSource_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdSource.FileOk
        txtSrc.Text = ofdSource.FileName
    End Sub

    Private Sub ofdDest_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdDest.FileOk
        txtDest.Text = ofdDest.FileName
    End Sub
End Class