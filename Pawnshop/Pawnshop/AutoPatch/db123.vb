''' <summary>
''' Modify Table tblPawn to include counter to allow ITEM TYPE CEL to be pawned for FOUR (4) MONTHS ONLY
''' </summary>
''' <remarks>Database Patch for tblPawn</remarks>
Module db123
    Const ALLOWABLE_VERSION As String = "1.2.2.1"
    Const LATEST_VERSION As String = "1.2.3"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try
            Dim mySql As String = "ALTER TABLE TBLPAWN ADD RENEWCNT SMALLINT DEFAULT '0' NOT NULL;"
            RunCommand(mySql)

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]", LATEST_VERSION) & ex.ToString)
        End Try
    End Sub
End Module
