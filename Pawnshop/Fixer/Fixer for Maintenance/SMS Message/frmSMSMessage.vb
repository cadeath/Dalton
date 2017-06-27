Public Class frmSMSMessage
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub frmSMSMessage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(0)
        Try
            Dim strMessage As String = "%BRANCHNAME% Magandang Araw po ang inyung sangla na may PT#%PAWNTICKET% ay huling araw na po para irenew o tubusin.Last day po ay %AUCTIONDATE%.Salamat po"
            UpdateOptions("SMS_MSG", strMessage)

            MsgBox("Successfuly Updated", MsgBoxStyle.Information, "SMS Message")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(1)
    End Sub
End Class