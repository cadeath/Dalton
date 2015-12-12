Public Class frmMIS

    Private Sub frmMIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub AddReport(ByVal ln As Integer, ByVal desc As String)
        Dim lv As ListViewItem = lvImportResult.Items.Add(ln)
        lv.SubItems.Add(desc)
    End Sub

    Private Sub ofdImport_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdImport.FileOk
        txtImportPath.Text = ofdImport.FileName
    End Sub

    Private Sub btnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportBrowse.Click
        ofdImport.ShowDialog()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        ImportTemplate(txtImportPath.Text)
    End Sub

End Class