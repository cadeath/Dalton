Module Void
    Friend Sub TransactionVoidSave(ByVal Mod_name As String, ByVal Encoder As Integer, ByVal Voidby As Integer, Optional ByVal Remarks As String = "")
        Dim tblName As String = "TBLVOID", mysql As String, ds As DataSet
        mysql = "SELECT * FROM " & tblName

        ds = LoadSQL(mysql, tblName)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(tblName).NewRow
        With dsNewRow
            .Item("MOD_NAME") = Mod_name
            .Item("REMARKS") = Remarks
            .Item("ENCODER") = Encoder
            .Item("VOIDED_BY") = Voidby
            .Item("TRANSDATE") = CurrentDate
        End With
        ds.Tables(tblName).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub
End Module
