Module db123
    ' TODO: FINAL
    ' SET THE FINAL ALLOWABLE VERSION
    Const ALLOWABLE_VERSION As String = "1.2.2.2"
    Const LATEST_VERSION As String = "1.2.3"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try


            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2.2 TO 1.2.2.3")
        Catch ex As Exception
            Log_Report("[1.2.2.3]" & ex.ToString)
        End Try
    End Sub
End Module