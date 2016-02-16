Module JournalEntries

    Friend Sub AddJournal(ByVal Amt As Double, ByVal DebitCredit As String, ByVal AccountName As String, _
                          Optional ByVal Remarks As String = "", Optional ByVal cashCountName As String = "", _
                          Optional ToDisplay As Boolean = True, Optional Category As String = "")
        If Amt = 0 Then Exit Sub
        Dim transactionName As String = "", SAPCode As String = "", onHold As Boolean = False
        Dim AccntID As Integer = 0
        Dim mySql As String = "SELECT * FROM tblCash WHERE "
        mySql &= String.Format("TRANSNAME = '{0}'", DreadKnight(AccountName))
        If Category <> "" Then mySql &= String.Format(" AND CATEGORY = '{0}'", Category)
        Dim ds As DataSet = LoadSQL(mySql), isRevolvingFund As Boolean = False

        If ds.Tables(0).Rows.Count > 1 Then Console.WriteLine("Multiple Account Code : " & AccountName)
        If AccountName = "Revolving Fund" Then
            AccntID = 0
            isRevolvingFund = True
        End If
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
            If isRevolvingFund Then
                If cashCountName = "" And isRevolvingFund Then MsgBox("No Cash Count Name for " & Remarks, MsgBoxStyle.Critical, "Developer WARNING")
                .Item("Remarks") = "Revolving Fund: " & REVOLVING_FUND
                .Item("CCName") = cashCountName
            End If
            If Not ToDisplay Then .Item("ToDisplay") = 0
            If Remarks <> "" Then .Item("Remarks") &= "| "
            .Item("Remarks") &= Remarks
        End With
        ds.Tables(tblName).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    'Friend Sub RemoveJournal(ByVal DebitCredit As String, ByVal Amt As Double, ByVal AccountName As String)
    '    Dim mySql As String, tblName As String = "tblJournal", TransID As Integer = GetTransID(AccountName)
    '    mySql = "SELECT * FROM " & tblName & " WHERE JRL_" & DebitCredit & " = " & Amt & " AND JRL_TransID = " & TransID
    '    Dim ds As DataSet = LoadSQL(mySql, tblName)

    '    ds.Tables(tblName).Rows(0).Item("STATUS") = 0
    '    database.SaveEntry(ds, False)
    'End Sub

    Friend Sub RemoveJournal(srcStr As String)
        Dim fillData As String = "tblJournal"
        Dim mySql As String = "SELECT * FROM tblJournal WHERE "
        mySql &= String.Format("REMARKS LIKE '%{0}%'", srcStr)

        Dim ds As DataSet = LoadSQL(mySql, fillData)
        If ds.Tables(fillData).Rows.Count = 0 Then MsgBox("JOURNAL ENTRIES NOT FOUND", MsgBoxStyle.Critical, "DEVELOPER WARNING") : Exit Sub

        For Each dr As DataRow In ds.Tables(fillData).Rows
            dr.Item("STATUS") = 0
        Next

        database.SaveEntry(ds, False)
        Console.WriteLine(srcStr & " REMOVED FROM JOURNAL ENTRIES...")
    End Sub

    Private Function GetTransID(ByVal AccountName As String) As Integer
        Dim mySql As String, tblName As String = "tblCash"
        mySql = "SELECT * FROM " & tblName & " WHERE TransName = '" & AccountName & "'"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("CashID")
    End Function

End Module
