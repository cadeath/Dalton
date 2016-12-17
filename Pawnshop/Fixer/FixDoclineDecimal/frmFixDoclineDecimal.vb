Public Class frmFixDoclineDecimal
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub frmFixDoclineDecimal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Try
            RunCommand("")
            MsgBox("Succesful")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
    End Sub

End Class