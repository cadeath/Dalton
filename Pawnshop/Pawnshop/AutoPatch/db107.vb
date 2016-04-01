Module db107

    Const ALLOWABLE_VERSION As String = "1.0.6"
    Const LATEST_VERSION As String = "1.0.7"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim mySql As String
        mySql = "ALTER TABLE TBLINSURANCE "
        mySql &= "ALTER COLUMN PAWNTICKET "
        mySql &= "TYPE VARCHAR(20);"

        RunCommand(mySql)

        Database_Update(LATEST_VERSION)
        Log_Report("SYSTEM PATCHED UP FROM 1.0.6 TO 1.0.7")
    End Sub

End Module