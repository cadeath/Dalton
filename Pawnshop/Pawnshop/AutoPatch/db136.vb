Module db136
    Const ALLOWABLE_VERSION As String = "1.3.5"
    Const LATEST_VERSION As String = "1.3.6"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            AddSMT()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
        frmMain.Cursor = Cursors.Default
        Console.WriteLine("Patch completed...")
    End Sub

    Private Sub AddSMT()
        Dim addTable As String = "CREATE TABLE TBLSMTRANSFERFEE ( "
        addTable &= "SMT_ID SMALLINT NOT NULL, "
        addTable &= "SMT_MIN NUMERIC(12, 2) NOT NULL, "
        addTable &= "SMT_MAX NUMERIC(12, 2) NOT NULL, "
        addTable &= "SMT_FEE NUMERIC(12, 2) NOT NULL); "

        RunCommand(addTable)
        AutoIncrement_ID("TBLSMTRANSFERFEE", "SMT_ID")
    End Sub
End Module
