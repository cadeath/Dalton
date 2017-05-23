Module db124
    Const ALLOWABLE_VERSION As String = "1.2.3.2"
    Const LATEST_VERSION As String = "1.2.4"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            LayAway()
            LayAwayLines()
            AddItemMasterFields()

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.3.2 TO 1.2.4")
        Catch ex As Exception
            Log_Report("[1.2.4]" & ex.ToString)
        End Try
    End Sub

    Private Sub LayAway()
        Dim Lay As String = "CREATE TABLE TBLLAYAWAY ( "
        Lay &= "LAYID BIGINT NOT NULL, "
        Lay &= "DOCDATE DATE NOT NULL, "
        Lay &= "FORFEITDATE DATE NOT NULL, "
        Lay &= "CUSTOMERID BIGINT NOT NULL, "
        Lay &= "ITEMCODE VARCHAR(20) NOT NULL, "
        Lay &= "PRICE NUMERIC(12, 3) NOT NULL, "
        Lay &= "BALANCE NUMERIC(12, 3) NOT NULL, "
        Lay &= "STATUS VARCHAR(1) DEFAULT '1' NOT NULL, "
        Lay &= "ENCODER SMALLINT DEFAULT '0' NOT NULL); "

        RunCommand(Lay)
        AutoIncrement_ID("TBLLAYAWAY", "LAYID")
    End Sub

    Private Sub LayAwayLines()
        Dim LayLines As String = "CREATE TABLE TBLLAYLINES ( "
        LayLines &= "LINESID BIGINT NOT NULL, "
        LayLines &= "LAYID BIGINT NOT NULL, "
        LayLines &= "PAYMENTDATE DATE NOT NULL, "
        LayLines &= "CONTROLNUM VARCHAR(20), "
        LayLines &= "AMOUNT NUMERIC(12, 3) NOT NULL, "
        LayLines &= "PENALTY NUMERIC(12, 3) DEFAULT '0.0' NOT NULL, "
        LayLines &= "STATUS VARCHAR(1) DEFAULT '1' NOT NULL, "
        LayLines &= "PAYMENTENCODER SMALLINT DEFAULT '0' NOT NULL); "

        RunCommand(LayLines)
        AutoIncrement_ID("TBLLAYLINES", "LINESID")
    End Sub

    Private Sub AddItemMasterFields()
        Dim isLayAway As String = "ALTER TABLE ITEMMASTER ADD ISLAYAWAY CHAR(1) DEFAULT '0' NOT NULL;"
        Dim onLayAway As String = "ALTER TABLE ITEMMASTER ADD ONLAYAWAY CHAR(1) DEFAULT '0' NOT NULL;"

        RunCommand(isLayAway)
        RunCommand(onLayAway)
    End Sub
End Module
