Module db_intHash

    Sub do_update()
        ' Add INT_CHECK at TBLPAWN
        Dim INT_CHECK As String = _
            "ALTER TABLE TBLPAWN ADD INT_CHECKSUM VARCHAR(100);"

        RunCommand(INT_CHECK)
        SystemUpdate("INT_CHECKSUM INCLUDED")

        ' HASH table TBLINT
        Dim INT_HASH As String, ds As DataSet
        Dim mySql As String = "SELECT DAYFROM, DAYTO, ITEMTYPE, INTEREST, PENALTY, REMARKS FROM TBLINT"
        ds = LoadSQL(mySql)
        INT_HASH = GetMD5(ds)

        SystemUpdate("TABLE HASHED - UPDATING WHOLE TABLE")

        mySql = "SELECT * FROM TBLPAWN WHERE STATUS <> 'V'"
        Dim fillData As String = "TBLPAWN"
        ds = LoadSQL(mySql, fillData)

        frmMain.pb_load.Maximum = ds.Tables(0).Rows.Count
        frmMain.pb_load.Value = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            dr("INT_CHECKSUM") = INT_HASH

            Application.DoEvents()
            frmMain.AddProgress()
        Next
        mod_system.SaveEntry(ds, False)
        SystemUpdate("DATABASE UPDATED")
    End Sub

End Module
