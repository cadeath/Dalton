Module DailyTimeLog

    Const TBL As String = "TBL_DAILYTIMELOG"

    Friend Sub AddTimelyLogs(mod_name As String, logs As String, Optional hasCustomer As Boolean = True, Optional remarks As String = "")
        Try
            Dim mySql As String = "SELECT * FROM " & TBL
            Dim ds As DataSet = LoadSQL(mySql, TBL)

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(TBL).NewRow
            With dsNewRow
                .Item("MOD_NAME") = mod_name
                .Item("LOG_REPORT") = logs
                If remarks <> "" Then .Item("REMARKS") = remarks
                If Not hasCustomer Then .Item("HASCUSTOMER") = 0
            End With
            ds.Tables(TBL).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            Console.WriteLine(String.Format("{0} - {1} - {2}", mod_name, logs, Now()))
        Catch ex As Exception
            Log_Report(ex.Message.ToString)
        End Try
    End Sub

End Module
