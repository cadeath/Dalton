Module db1010
    Const ALLOWABLE_VERSION As String = "1.098"
    Const LATEST_VERSION As String = "1.0.10"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW PRINT_PAWNING;"
        Dim CREATE_NEW_PRINT_PAWNING As String

        Try

            RunCommand(DROP_VIEW)


            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.9 TO 1.0.10")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.0.9]")
        End Try
    End Sub
End Module
