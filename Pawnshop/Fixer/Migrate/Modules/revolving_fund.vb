Module revolving_fund

    Dim mySql As String, fillData As String
    Dim ds As DataSet

    Friend Sub do_RevolvingFix(dbUrl As String)
        Dim RF_SAPCODE As String

        database.dbName = dbUrl
        RF_SAPCODE = GetRFCode()

        mySql = "SELECT * FROM TBLCASH WHERE CASHID = 0"
        fillData = "tblCash"

        ds = New DataSet
        ds = LoadSQL(mySql, fillData)

        ds.Tables(fillData).Rows(0).Item("SAPACCOUNT") = RF_SAPCODE
        SaveEntry(ds, False)

        MsgBox("RF CODE FIX!!!", MsgBoxStyle.Information, "RF NOT WORKING PROBLEM")
    End Sub

    Private Function GetRFCode() As String
        mySql = "SELECT * FROM tblMAINTENANCE WHERE OPT_KEYS = 'RevolvingFund'"
        ds = New DataSet
        ds = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("OPT_VALUES")
    End Function

End Module