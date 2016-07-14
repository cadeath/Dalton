Module DailyTimeLog

    Const VERSION As String = "v1.1"
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


    Friend Sub AddTimelyLogs(mod_name As String, logs As String, Optional Amount As Double = 0, Optional hasCustomer As Boolean = True, Optional remarks As String = "", Optional ByVal transid As String = "")

        Try
            Dim mySql As String = "SELECT * FROM " & TBL
            Dim ds As DataSet = LoadSQL(mySql, TBL)
            ds.Clear()
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(TBL).NewRow
            With dsNewRow
                .Item("MOD_NAME") = mod_name
                .Item("LOG_REPORT") = logs
                .Item("REMARKS") = String.Format("[{0}] {1}", VERSION, remarks)
                If Not hasCustomer Then .Item("HASCUSTOMER") = 0
                'Added in db 1.0.12
                .Item("AMOUNT") = Amount
                .Item("USERID") = POSuser.UserID
                .Item("TRANSID") = transid
            End With
            ds.Tables(TBL).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            Console.WriteLine(String.Format("{0} - {1} - {2}", mod_name, logs, Now()))

        Catch ex As Exception
            Log_Report(ex.Message.ToString)
        End Try

    End Sub

    Friend Sub RemoveDailyTimeLog(ByVal srcStr As Integer, ByVal ModName As String)
        'Void transaction in Daily Time Log = remarks
        Dim void As String = String.Format("VOID")

        Dim TBL As String = "TBL_DAILYTIMELOG"
        Dim mySql As String = "SELECT * FROM TBL_DAILYTIMELOG WHERE HASCUSTOMER = '1' AND "
        mySql &= "TRANSID = '" & srcStr & "' AND MOD_NAME = '" & ModName & "'"

        Dim ds As DataSet = LoadSQL(mySql, TBL)
        If ds.Tables(TBL).Rows.Count = 0 Then
            Log_Report("[RemoveLog] " & String.Format("{0} with ID {1} cannot be found in tbl_dailytimelog", ModName, srcStr))
            MsgBox("Daily Time Log ENTRIES NOT FOUND", MsgBoxStyle.Critical, "DEVELOPER WARNING") : Exit Sub
        End If

        For Each dr As DataRow In ds.Tables(TBL).Rows
            dr.Item("REMARKS") = String.Format("[{0}] {1}", VERSION, void)
        Next

        database.SaveEntry(ds, False)
        Console.WriteLine(srcStr & ModName & " REMOVED FROM Daily Time Log ENTRIES...")
    End Sub

  
End Module
