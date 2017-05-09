Module db15
    Const ALLOWABLE_VERSION As String = "1.3"
    Const LATEST_VERSION As String = "1.3.1"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Update_Maintenance()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Update_Maintenance()
        UpdateOptions("AccountExpiry", "30")
        UpdateOptions("PasswordExpiry", "90")
        UpdateOptions("FailedAttempt", "3")
    End Sub
End Module
