Module db1224
    Const ALLOWABLE_VERSION As String = "1.2.2.3"
    Const LATEST_VERSION As String = "1.2.2.4"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try

            VoidReport()

            ColumnStatus()

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
        Dim VoidKey As String = "ALTER TABLE TBLVOID ADD PRIMARY KEY (VOID_ID);"

        RunCommand(mySql)
        RunCommand(VoidKey)
        AutoIncrement_ID("TBLVOID", "VOID_ID")
    End Sub
    Private Sub ColumnStatus()
        Dim mySql As String
        mySql = "ALTER TABLE TBL_GAMIT ADD STATUS VARCHAR(1);"

        Dim strStatus As String
        strStatus = "UPDATE TBL_GAMIT SET STATUS = '1'"

        RunCommand(mySql)
        RunCommand(strStatus)

    End Sub
End Module
