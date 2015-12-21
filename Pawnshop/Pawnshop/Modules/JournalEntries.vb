Module JournalEntries

    Friend Sub AddJournal(ByVal Amt As Double, ByVal DebitCredit As String, ByVal AccountName As String, Optional ByVal Remarks As String = "")
        Dim category As String = "", transactionName As String = "", SAPCode As String = "", onHold As Boolean = False
        Dim AccntID As Integer = 0
        Dim mySql As String = "SELECT * FROM tblCash WHERE "
        mySql &= String.Format("TRANSNAME = '{0}'", AccountName)
        Dim ds As DataSet = LoadSQL(mySql), isRevolvingFund As Boolean = False

        If ds.Tables(0).Rows.Count > 1 Then Console.WriteLine("Multiple Account Code : " & AccountName)
        If ds.Tables(0).Rows.Count = 0 Then
            Console.WriteLine(AccountName & " cannot be found. Must be a REVOLVING FUND")
            If AccountName = "Revolving Fund" Then
                AccntID = 0
                isRevolvingFund = True
            Else
                Console.WriteLine("Unknown Code: " & AccountName)
                Exit Sub
            End If
        Else
            With ds.Tables(0)
                AccntID = ds.Tables(0).Rows(0).Item("CashID")
                category = IIf(IsDBNull(.Rows(0).Item("Category")), "", .Rows(0).Item("Category"))
                transactionName = IIf(IsDBNull(.Rows(0).Item("TransName")), "", .Rows(0).Item("TransName"))
                SAPCode = IIf(IsDBNull(.Rows(0).Item("SAPAccount")), "", .Rows(0).Item("SAPAccount"))
                onHold = IIf(.Rows(0).Item("onHold") = 1, True, False)
            End With
            If onHold Then MsgBox("AccountCode " & transactionName & " is ON HOLD" & vbCrLf & "Contact your IT DEPARTMENT", MsgBoxStyle.Information)
        End If

        Dim tblName As String = "tblJournal"
        mySql = "SELECT * FROM " & tblName
        ds.Clear()
        ds = LoadSQL(mySql, tblName)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(tblName).NewRow
        With dsNewRow
            Console.WriteLine("Time Check:" & Now.TimeOfDay.ToString)
            .Item("JRL_TRANSDATE") = CurrentDate
            .Item("JRL_TIME") = Now.TimeOfDay
            .Item("JRL_TRANSID") = AccntID
            Select Case DebitCredit
                Case "Debit"
                    .Item("JRL_Debit") = Amt
                Case "Credit"
                    .Item("JRL_Credit") = Amt
                Case Else
                    .Item("Remarks") = DebitCredit & " NOT FOUND."
            End Select
            If isRevolvingFund Then .Item("Remarks") = "Revolving Fund: " & REVOLVING_FUND
            If Remarks <> "" Then .Item("Remarks") &= "| "
            .Item("Remarks") &= Remarks
        End With
        ds.Tables(tblName).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Friend Sub RemoveJournal(ByVal DebitCredit As String, ByVal Amt As Double, ByVal AccountName As String)
        Dim mySql As String, tblName As String = "tblJournal", TransID As Integer = GetTransID(AccountName)
        mySql = "SELECT * FROM " & tblName & " WHERE JRL_" & DebitCredit & " = " & Amt & " AND JRL_TransID = " & TransID
        Dim ds As DataSet = LoadSQL(mySql, tblName)

        ds.Tables(tblName).Rows(0).Item("STATUS") = 0
        database.SaveEntry(ds, False)
    End Sub

    Private Function GetTransID(ByVal AccountName As String) As Integer
        Dim mySql As String, tblName As String = "tblCash"
        mySql = "SELECT * FROM " & tblName & " WHERE TransName = '" & AccountName & "'"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("CashID")
    End Function

End Module
