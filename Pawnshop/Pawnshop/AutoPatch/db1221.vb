Module db1221

    Const ALLOWABLE_VERSION As String = "1.2.2"
    Const LATEST_VERSION As String = "1.2.2.1"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try
            Dim mySql As String
            mySql = "CREATE TABLE TBLOTP ( "
            mySql &= vbCrLf & "  OTPID BIGINT NOT NULL, "
            mySql &= vbCrLf & "  PIN VARCHAR(15),"
            mySql &= vbCrLf & "  MOD_NAME VARCHAR(26) NOT NULL,"
            mySql &= vbCrLf & "  ADD_TIME TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
            mySql &= vbCrLf & "  USERID SMALLINT NOT NULL);"

            RunCommand(mySql)
            AutoIncrement_ID("TBLOTP", "OTPID")

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2 TO 1.2.2.1")
        Catch ex As Exception
            Log_Report("[1.2.2.1]" & ex.ToString)
        End Try
    End Sub
End Module
