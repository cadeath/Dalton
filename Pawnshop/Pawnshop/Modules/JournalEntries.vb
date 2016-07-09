Module JournalEntries
    ''' <summary>
    ''' This Procedure add Journal Entries
    ''' </summary>
    ''' <param name="Amt">Amount</param>
    ''' <param name="DebitCredit">Debit/Credit</param>
    ''' <param name="AccountName">TransName</param>
    ''' <param name="Remarks">Remarks</param>
    ''' <param name="cashCountName">Display on CashCount</param>
    ''' <param name="ToDisplay">ToDisplay on CashCount</param>
    ''' <param name="Category">Category</param>xgl
    ''' <remarks>This Procedure add Journal Entries</remarks>
    Friend Sub AddJournal(ByVal Amt As Double, ByVal DebitCredit As String, ByVal AccountName As String, _
                          Optional ByVal Remarks As String = "", Optional ByVal cashCountName As String = "", _
                          Optional ByVal ToDisplay As Boolean = True, Optional ByVal Category As String = "", Optional ByVal TransType As String = "", Optional ByVal TransID As String = "")
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
                Category = IIf(IsDBNull(.Rows(0).Item("Category")), "", .Rows(0).Item("Category"))
                transactionName = IIf(IsDBNull(.Rows(0).Item("TransName")), "", .Rows(0).Item("TransName"))
                SAPCode = IIf(IsDBNull(.Rows(0).Item("SAPAccount")), "", .Rows(0).Item("SAPAccount"))
                onHold = IIf(.Rows(0).Item("onHold") = 1, True, False)
                'TransType = IIf(IsDBNull(.Rows(0).Item("TRANSTYPE")), "", .Rows(0).Item("TRANSTYPE"))
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
            .Item("TRANSTYPE") = TransType
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
                '.Item("TRANSTYPE") = TransType
            End If
            If Not ToDisplay Then .Item("ToDisplay") = 0
            If Remarks <> "" Then .Item("Remarks") &= "| "
            .Item("Remarks") &= Remarks
            .Item("TRANSID") = TransID
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
    ''' <summary>
    ''' This method select all data from tblJournal where srcStr is the parameter
    ''' </summary>
    ''' <param name="srcStr">srcStr is the bases if what journal to display.</param>
    ''' <remarks></remarks>
    Friend Sub RemoveJournal(transID As Integer, Optional srcStr As String = "", Optional ByVal TransType As String = "")
        Dim i As Integer = 0
        Dim fillData As String = "tblJournal"
        Dim mySql As String = "SELECT * FROM tblJournal WHERE "
        mySql &= String.Format("TRANSID ='{0}' AND REMARKS LIKE '%{1}%' and TRANSTYPE='{2}'", transID, srcStr, TransType)

        Dim ds As DataSet = LoadSQL(mySql, fillData)
        If ds.Tables(fillData).Rows.Count = 0 Then MsgBox("JOURNAL ENTRIES NOT FOUND", MsgBoxStyle.Critical, "DEVELOPER WARNING") : Exit Sub

        For Each dr As DataRow In ds.Tables(fillData).Rows
            dr.Item("STATUS") = i
        Next

        database.SaveEntry(ds, False)
        Console.WriteLine(srcStr & " REMOVED FROM JOURNAL ENTRIES...")
    End Sub

   
    ''' <summary>
    ''' This function create accountName variable which the paremeter of tblcash.
    ''' </summary>
    ''' <param name="AccountName"></param>
    ''' <returns>return ds after reading data.</returns>
    ''' <remarks></remarks>
    Private Function GetTransID(ByVal AccountName As String) As Integer
        Dim mySql As String, tblName As String = "tblCash"
        mySql = "SELECT * FROM " & tblName & " WHERE TransName = '" & AccountName & "'"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("CashID")
    End Function

End Module
