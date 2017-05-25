Public Class frmChangeItemCodeDescription
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

    Private Sub frmChangeItemCodeDescription_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Try
            Dim mysql As String = "Select * From ItemMaster Where ItemCode = 'SMT 00003'"
            Dim fillData As String = "ItemMaster"
            Dim ds As DataSet = LoadSQL(mysql, fillData)

            If ds.Tables(0).Rows.Count = 0 Then MsgBox("No Description to Change", MsgBoxStyle.Critical, "Changer") : Disable(0) : Exit Sub
            With ds.Tables(0).Rows(0)
                .Item("DESCRIPTION") = "SMART BUDDY 100"
            End With
            SaveEntry(ds, False)

            MsgBox("Successfull", MsgBoxStyle.Information, "Changer")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(0)
    End Sub
End Class