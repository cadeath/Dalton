''' <summary>
''' Modify Table tblPawn to include RENEWAL COUNTER
''' Modify Table tblClass to include RENEWAL COUNTER
''' </summary>
''' <remarks>Database Patch for tblPawn</remarks>
Module db1222
    Const ALLOWABLE_VERSION As String = "1.2.2.1"
    Const LATEST_VERSION As String = "1.2.2.2"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Try
            Dim mySql As String = "ALTER TABLE TBLPAWN ADD RENEWALCNT SMALLINT DEFAULT '0' NOT NULL;"
            RunCommand(mySql) 'TBLPAWN RENEWAL COUNT

            mySql = "ALTER TABLE TBLCLASS ADD RENEWLIMIT SMALLINT DEFAULT '0' NOT NULL;"
            RunCommand(mySql) 'TBLCLASS RENEWAL LIMIT

            If DEV_MODE Then
                mySql = "UPDATE TBLCLASS SET RENEWLIMIT = 5 WHERE TYPE='CEL'"
                RunCommand(mySql)
            End If

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]", LATEST_VERSION) & ex.ToString)
        End Try
    End Sub
End Module
