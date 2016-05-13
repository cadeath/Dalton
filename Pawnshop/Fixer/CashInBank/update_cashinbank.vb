''' <summary>
''' MAY 11, 2016
''' Branches with different CASH IN BANK SAP CODE
''' should be updated using this patch program.
''' </summary>
''' <remarks></remarks>
Module update_cashinbank

    Private TBLNAME As String = "TBLCASH"
    Friend MOD_NAME As String = "Cash in Bank"

    Friend Sub UpdateCashInBank(sys As String, fdb As String)
        Dim mySql As String = _
            "SELECT * FROM " & TBLNAME
        Dim ds As DataSet

        database.dbName = fdb
        mySql &= " WHERE TRANSNAME = 'Cash in Bank'"
        Try
            ds = LoadSQL(mySql, TBLNAME)

            If ds.Tables(TBLNAME).Rows.Count = 0 Then MsgBox("Cannot find 'Cash in Bank'", MsgBoxStyle.Critical) : Exit Sub
            ds.Tables(TBLNAME).Rows(0).Item("SAPACCOUNT") = sys

            database.SaveEntry(ds, False)

            With frmMain2
                .pbLoading.Maximum = 1
                .pbLoading.Value = 1
                .SystemStat("Updated")
            End With
            MsgBox("System Updated!", MsgBoxStyle.Information)
        Catch ex As Exception
            frmMain2.SystemStat("PATCH FAILED...")
            MsgBox("Failed to update database", MsgBoxStyle.Critical, "F A I L E D")
        End Try
    End Sub

End Module