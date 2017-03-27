Module db131
    Const ALLOWABLE_VERSION As String = "1.3"
    Const LATEST_VERSION As String = "1.3.1"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Dim Doc As String = "CREATE TABLE PULLOUTDOC ( "
            Doc &= "DOCID BIGINT NOT NULL, "
            Doc &= "DOCDATE DATE NOT NULL, "
            Doc &= "CONTROLNUM SMALLINT NOT NULL, "
            Doc &= "PULLOUTBY VARCHAR(50) NOT NULL); "

            Dim Doclines As String = "CREATE TABLE PULLOUTLINES ( "
            Doclines &= "LINESID BIGINT NOT NULL, "
            Doclines &= "DOCID BIGINT NOT NULL, "
            Doclines &= "PAWNTICKET BIGINT NOT NULL, "
            Doclines &= "LOANDATE DATE NOT NULL, "
            Doclines &= "EXPIRYDATE DATE NOT NULL, "
            Doclines &= "DESCRIPTION VARCHAR(255) NOT NULL, "
            Doclines &= "PRINCIPAL NUMERIC(12, 2) NOT NULL, "
            Doclines &= "PAWNERNAME VARCHAR(150) NOT NULL, "
            Doclines &= "APPRAISER VARCHAR(50) NOT NULL); "

            RunCommand(Doc)
            RunCommand(Doclines)

            AutoIncrement_ID("PULLOUTDOC", "DOCID")
            AutoIncrement_ID("PULLOUTLINES", "LINESID")

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub
End Module
