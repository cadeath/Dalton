Module db134
    Const ALLOWABLE_VERSION As String = "1.3.3"
    Const LATEST_VERSION As String = "1.3.4"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        frmMain.Cursor = Cursors.WaitCursor
        Try
    
            NewMTCharges()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
        frmMain.Cursor = Cursors.Default
    End Sub

    Private Sub NewMTCharges()
        Dim MTChargeName As String = "CREATE TABLE TBLMTCHARGE ( "
        MTChargeName &= "CHR_ID SMALLINT NOT NULL, "
        MTChargeName &= "CHARGENAME VARCHAR(50) NOT NULL, "
        MTChargeName &= "DESCRIPTION VARCHAR(255), "
        MTChargeName &= "ISGENERATED SMALLINT NOT NULL, "
        MTChargeName &= "ACTION_TYPE SMALLINT, "
        MTChargeName &= "HASPAYOUTCOMMISSION SMALLINT NOT NULL);"

        Dim UpdateChargeName As String = "UPDATE RDB$RELATION_FIELDS SET "
        UpdateChargeName &= "RDB$DESCRIPTION = 'Receive = 1, Send = 0, Null equal Nothing' "
        UpdateChargeName &= "WHERE RDB$RELATION_NAME = 'TBLMTCHARGE' "
        UpdateChargeName &= "AND RDB$FIELD_NAME = 'ACTION_TYPE';"

        Dim MTChargeDetails As String = "CREATE TABLE TBLMTDETAILS ( "
        MTChargeDetails &= "ID SMALLINT NOT NULL, "
        MTChargeDetails &= "CHR_ID SMALLINT NOT NULL, "
        MTChargeDetails &= "AMOUNTFROM NUMERIC(12, 2) NOT NULL, "
        MTChargeDetails &= "AMOUNTTO NUMERIC(12, 2) NOT NULL, "
        MTChargeDetails &= "CHARGE NUMERIC(12, 2) NOT NULL, "
        MTChargeDetails &= "COMMISION NUMERIC(12, 2), "
        MTChargeDetails &= "REMARKS VARCHAR(255));"

        RunCommand(MTChargeName)
        RunCommand(UpdateChargeName)
        RunCommand(MTChargeDetails)

        AutoIncrement_ID("TBLMTCHARGE", "CHR_ID")
        AutoIncrement_ID("TBLMTDETAILS", "ID")
    End Sub
End Module
