Module db1224
    Const ALLOWABLE_VERSION As String = "1.2.2.3"
    Const LATEST_VERSION As String = "1.2.2.4"
    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            VoidReport()

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2.3 TO 1.2.2.4")
        Catch ex As Exception
            Log_Report("[1.2.2.4]" & ex.ToString)
        End Try
    End Sub
    Private Sub VoidReport()
        Dim mySql As String
        mySql = "CREATE TABLE TBLVOID (VOID_ID SMALLINT NOT NULL, "
        mySql &= "TRANSDATE DATE, MOD_NAME VARCHAR(100), REMARKS VARCHAR(255), "
        mySql &= "ENCODER SMALLINT, VOIDED_BY SMALLINT);"

        RunCommand(mySql)
        AutoIncrement_ID("TBLVOID", "VOID_ID")
    End Sub
End Module
