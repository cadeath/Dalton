Module db134
    Const ALLOWABLE_VERSION As String = "1.3.3"
    Const LATEST_VERSION As String = "1.3.4"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        frmMain.Cursor = Cursors.WaitCursor
        Try
            UpdateOptions("PolloutCount", "1")

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
        frmMain.Cursor = Cursors.Default
    End Sub

End Module
