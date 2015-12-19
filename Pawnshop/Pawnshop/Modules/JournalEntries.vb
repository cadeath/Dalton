Module JournalEntries

    Friend Sub AddJournal(ByVal Amt As Double, ByVal DebitCredit As String, ByVal AccountName As String)
        Dim category As String = "", transactionName As String = "", SAPCode As String = "", onHold As Boolean = False
        Dim mySql As String = "SELECT * FROM tblCash WHERE "
        mySql &= String.Format("TRANSNAME = '{0}'", transactionName)
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count > 0 Then Console.WriteLine("Double Account Code : " & transactionName)
        With ds.Tables(0)
            category = IIf(IsDBNull(.Rows(0).Item("Category")), "", .Rows(0).Item("Category"))
            transactionName = IIf(IsDBNull(.Rows(0).Item("TransName")), "", .Rows(0).Item("TransName"))
            SAPCode = IIf(IsDBNull(.Rows(0).Item("SAPAccount")), "", .Rows(0).Item("SAPAccount"))
            onHold = IIf(.Rows(0).Item("onHold") = 1, True, False)
        End With
        If onHold Then MsgBox("AccountCode " & transactionName & " is ON HOLD" & vbCrLf & "Contact your IT DEPARTMENT", MsgBoxStyle.Information)

        Dim tblName As String = "tblJournal"
    End Sub

End Module
