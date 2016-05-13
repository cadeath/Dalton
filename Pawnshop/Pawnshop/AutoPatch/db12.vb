Module db12
    Const LATEST_VERSION As String = "1.2"

    Sub PatchUp()
        Try
            If ifTblExist("TBLHIT") Then Exit Sub

            Dim ADD_HIT As String
            ADD_HIT = "CREATE TABLE TBLHIT ( "
            ADD_HIT &= vbCrLf & "  HITID BIGINT NOT NULL,"
            ADD_HIT &= vbCrLf & "  HIT_DATE DATE NOT NULL,"
            ADD_HIT &= vbCrLf & "  PAWNID BIGINT NOT NULL,"
            ADD_HIT &= vbCrLf & "  PAWNER VARCHAR(255) NOT NULL,"
            ADD_HIT &= vbCrLf & "  PT BIGINT NOT NULL);"

            RunCommand(ADD_HIT)
            RunCommand("ALTER TABLE TBLHIT ADD PRIMARY KEY (HITID);")

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP TO " & LATEST_VERSION)
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
    End Sub
End Module
