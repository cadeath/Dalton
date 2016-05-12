Module db1012
    Const ALLOWABLE_VERSION As String = "1.0.11"
    Const LATEST_VERSION As String = "1.0.12"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim ADD_AMOUNT As String, ADD_USERID As String
        ADD_AMOUNT = "ALTER TABLE TBL_DAILYTIMELOG ADD AMOUNT DECIMAL(12, 2) DEFAULT '0.0' NOT NULL;"
        ADD_USERID = "ALTER TABLE TBL_DAILYTIMELOG ADD USERID SMALLINT NOT NULL;"

        Try
            RunCommand(ADD_AMOUNT)
            RunCommand(ADD_USERID)

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.11 TO 1.0.12")
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
    End Sub
End Module
