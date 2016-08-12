Module db1224
    Const ALLOWABLE_VERSION As String = "1.2.2.3"
    Const LATEST_VERSION As String = "1.2.2.4"
    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Dim mySql As String
            mySql = "ALTER TABLE TBL_GAMIT ADD STATUS VARCHAR(1);"

            Dim strStatus As String
            strStatus = "UPDATE TBL_GAMIT SET STATUS = '1'"

            RunCommand(mySql)
            RunCommand(strStatus)

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2.3 TO 1.2.2.4")
        Catch ex As Exception
            Log_Report("[1.2.2.4]" & ex.ToString)
        End Try
    End Sub
End Module
