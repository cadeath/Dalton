Public Class frmInvStock
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub frmInvStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Disable(1)
        Try
            FixInventory()

            MsgBox("Succesful Updated", MsgBoxStyle.Information, "System")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub FixInventory()
        Dim fix As String = "Update ItemMaster set onHand = 1 Where onHand >= 2 And "
        fix &= "ItemCode Not Like '%SMT%' "
        fix &= "And ItemCode Not Like '%IND%' "

        RunCommand(fix)

    End Sub

End Class