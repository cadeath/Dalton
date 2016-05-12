Public Class frmMain2

    Private Sub frmMain2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.Text &= " - " & update_cashinbank.MOD_NAME
    End Sub

    Private Sub txtDB_DoubleClick(sender As Object, e As System.EventArgs) Handles txtDB.DoubleClick
        ofd_db.ShowDialog()
    End Sub

    Private Sub ofd_db_FileOk(sender As System.Object, e As System.ComponentModel.CancelEventArgs) Handles ofd_db.FileOk
        txtDB.Text = ofd_db.FileName
    End Sub

    Private Sub btnFix_Click(sender As System.Object, e As System.EventArgs) Handles btnFix.Click
        If txtDB.Text = "" Then SystemStat("Nothing happened...") : Exit Sub
        SystemStat("Fixing...")
        UpdateCashInBank(txtSys.Text, txtDB.Text)
    End Sub

    Public Sub SystemStat(str As String)
        lblStatus.Text = str
        Application.DoEvents()
    End Sub
End Class