Public Class frmClientMigrate

    Private Sub btnMigrate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMigrate.Click
        pBMigrate.Visible = True
        lblStatus.Visible = True
        tmrMigrate.Start()
        tmrMigrate.Start()
    End Sub

    Private Sub bgMigrate_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgMigrate.DoWork
        KYC_Initialization()
    End Sub

    Private Sub frmClientMigrate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dirDB()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OFDMigrate.ShowDialog()
    End Sub

    Private Sub OFDMigrate_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OFDMigrate.FileOk
        database.dbName = OFDMigrate.FileName
    End Sub

    Private Sub bgMigrate_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgMigrate.RunWorkerCompleted
        MsgBox("Migration Completed", MsgBoxStyle.Information)
        pBMigrate.Visible = False
        lblStatus.Visible = False
    End Sub

    Private Sub tmrMigrate_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrMigrate.Tick
        tmrMigrate.Stop()
        bgMigrate.RunWorkerAsync()
    End Sub
End Class