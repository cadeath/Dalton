
Public Class frmRate2

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnBrowse_Click(sender As System.Object, e As System.EventArgs) Handles btnBrowse.Click
        ofdUpdate.ShowDialog()

    End Sub

    Private Sub ofdUpdate_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofdUpdate.FileOk
        txtConfig.Text = ofdUpdate.FileName
    End Sub

    Private Sub btnUpdate_Click(sender As System.Object, e As System.EventArgs) Handles btnUpdate.Click
        If Not System.IO.File.Exists(txtConfig.Text) Then Exit Sub

        Disable(1)
        updateRate.do_RateUpdate(txtConfig.Text)
        Disable(0)
        MsgBox("System Updated", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub Disable(st As Boolean)
        btnUpdate.Enabled = Not st
        btnBrowse.Enabled = Not st
        btnCancel.Enabled = Not st
    End Sub
End Class