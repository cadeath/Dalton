Public Class frmAddItemMasterCOI
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

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Try
            Dim mysql As String = "Select * From ItemMaster Where ItemCode = 'IND 00001'"
            Dim fillData As String = "ItemMaster"
            Dim ds As DataSet = LoadSQL(mysql, fillData)
            If ds.Tables(0).Rows().Count = 1 Then
                With ds.Tables(0).Rows(0)
                    .Item("ITEMCODE") = "IND 00001"
                    .Item("DESCRIPTION") = "DALTON INSURANCE 25"
                End With
                SaveEntry(ds, False)
            Else
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("ITEMCODE") = "IND 00001"
                    .Item("DESCRIPTION") = "DALTON INSURANCE 25"
                End With
                ds.Tables(0).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            End If
           
            MsgBox("Successfull", MsgBoxStyle.Information, "Fixer")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(0)
    End Sub

    Private Sub frmAddItemMasterCOI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

End Class