Module DailyTimeLog

    Const VERSION As String = "v1"
    Const TBL As String = "TBL_DAILYTIMELOG"

    ''' <summary>
    ''' This records every transactions in the system
    ''' </summary>
    ''' <param name="mod_name">Type: String
    ''' Act as Category of the report</param>
    ''' <param name="logs">Type: String
    ''' Logs the details of the report</param>
    ''' <param name="Amount">Type: Double [Optional = 0.00]
    ''' If any amount involve, write it here</param>
    ''' <param name="hasCustomer">Type: Boolean [Optional = True]
    ''' Identify if the reports has customer involved</param>
    ''' <param name="remarks">Type: String [Optional]
    ''' For any technical remarks only. Won't display on the reports.
    ''' </param>
    ''' <remarks></remarks>
    Friend Sub AddTimelyLogs(mod_name As String, logs As String, Optional Amount As Double = 0, Optional hasCustomer As Boolean = True, Optional remarks As String = "")
        Try
            Dim mySql As String = "SELECT * FROM " & TBL
            Dim ds As DataSet = LoadSQL(mySql, TBL)

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(TBL).NewRow
            With dsNewRow
                .Item("MOD_NAME") = mod_name
                .Item("LOG_REPORT") = logs
                If remarks <> "" Then .Item("REMARKS") = String.Format("[{0}] {1}", VERSION, remarks)
                If Not hasCustomer Then .Item("HASCUSTOMER") = 0
                'Added in db 1.0.12
                .Item("AMOUNT") = Amount
                .Item("USERID") = POSuser.UserID
            End With
            ds.Tables(TBL).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            Console.WriteLine(String.Format("{0} - {1} - {2}", mod_name, logs, Now()))
        Catch ex As Exception
            Log_Report(ex.Message.ToString)
        End Try
    End Sub

End Module
