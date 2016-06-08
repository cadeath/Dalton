Module db122
    Const ALLOWABLE_VERSION As String = "1.2.1"
    Const LATEST_VERSION As String = "1.2.2"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim ALTER_TBLJOURNAL As String = "ALTER TABLE TBLJOURNAL ADD TRANSTYPE VARCHAR(50);"
        Dim JRL_VIEW As String
        JRL_VIEW = "CREATE VIEW JOURNAL_SUMMARY("
        JRL_VIEW &= vbCrLf & "  SAPACCOUNT,"
        JRL_VIEW &= vbCrLf & "  DEBIT,"
        JRL_VIEW &= vbCrLf & "  CREDIT,"
        JRL_VIEW &= vbCrLf & "  TRANSTYPE,"
        JRL_VIEW &= vbCrLf & "  TRANSDATE,"
        JRL_VIEW &= vbCrLf & "  CCNAME)"
        JRL_VIEW &= vbCrLf & "AS "
        JRL_VIEW &= vbCrLf & "SELECT SAPACCOUNT,SUM (JRL_DEBIT) AS DEBIT, "
        JRL_VIEW &= vbCrLf & "SUM (JRL_CREDIT) AS CREDIT, TRANSTYPE, "
        JRL_VIEW &= vbCrLf & "JRL_TRANSDATE AS TRANSDATE, CCNAME "
        JRL_VIEW &= vbCrLf & "FROM tblJournal INNER JOIN tblCash on CashID = JRL_TRANSID "
        JRL_VIEW &= vbCrLf & "WHERE Status = 1 "
        JRL_VIEW &= vbCrLf & "GROUP BY TRANSTYPE, SAPACCOUNT, JRL_TRANSDATE, CCNAME "
        JRL_VIEW &= vbCrLf & "ORDER BY TRANSTYPE;"

        Try
            RunCommand(ALTER_TBLJOURNAL)

            RunCommand(JRL_VIEW)

            Dim CashInBank As String = GetOption("BranchBank")
            If CashInBank = 0 Then
                Dim cashinBankSql As String = "SELECT * FROM TBLCASH WHERE TRANSNAME = 'Cash in Bank'"
                Dim ds As DataSet = LoadSQL(cashinBankSql)
                CashInBank = ds.Tables(0).Rows(0).Item("SAPACCOUNT")
                UpdateOptions("BranchBank", CashInBank)
                Console.WriteLine("Branch Bank Updated")
            End If

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.1 TO 1.2.2")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.2.2]")
        End Try
    End Sub
End Module
