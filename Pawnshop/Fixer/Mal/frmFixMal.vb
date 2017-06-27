Public Class frmFixMal
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub
    Private Sub frmFixMal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        UpdateOptions("BranchArea", "NOM")

        MsgBox("Successful", MsgBoxStyle.Information, "Fixer")
        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub
End Class