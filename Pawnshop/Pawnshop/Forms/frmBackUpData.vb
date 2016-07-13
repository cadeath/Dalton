Public Class frmBackupData
    Const DBPATH As String = "\BackUp.bat"

    Private Sub frmBackupData_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        btnStartBackup.Focus()
    End Sub

    Private Sub btnStartBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStartBackup.Click
        Dim readValue = My.Computer.Registry.GetValue(
   "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        Dim strPath As String = firebird
        Process.Start(strPath)
    End Sub

    Private Sub btnSettings_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSettings.Click
        frmBackUpDataSettings.Show()
    End Sub
End Class