Module db135
    Const ALLOWABLE_VERSION As String = "1.3.4"
    Const LATEST_VERSION As String = "1.3.5"
    Dim cstmr As Customer

    Private strSql As String
    Dim IDlist As String() = {"Passport", "Driver's License", "PRC ID", "NBI Clearance", "Police Clearance" & _
                                "Postal ID", "Voter's ID", "Brgy Certification", "TIN", "GSIS", "SSS", "Senior Citizen Card", "OWWA ID" & _
                                "OFW ID", "Seaman's Book", "Alien Cretification/Immigrant Certification of Registration" & _
                               "AFP ID", "HDMF ID", "NCWDP", "DSWD Certification", "Integrated Bar of the Philippines ID", "Company ID under BSP, SEC or IC"}

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        frmMain.Cursor = Cursors.WaitCursor
        Try
            Dim createView, primaryKey As String

            createView = "	CREATE TABLE KYC_IDLIST (IDENID INTEGER NOT NULL,IDTYPE VARCHAR(75) NOT NULL);"

            primaryKey = "ALTER TABLE KYC_IDLIST ADD PRIMARY KEY (IDENID);"

            Console.WriteLine("Start creating...")
            RunCommand(createView) : diag_loading.Add_Bar()
            AutoIncrement_ID("KYC_IDLIST", "IDENID")

            Database_Update(LATEST_VERSION)

            For Each IDX In IDlist
                cstmr = New Customer
                cstmr.AddIDentification(IDX)
            Next

            'Set Generator
            IDGerator()

        Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
        frmMain.Cursor = Cursors.Default
    End Sub

    Private Sub IDGerator()

        Dim mysql = "SELECT * FROM KYC_IDLIST"
        Dim ds As DataSet = LoadSQL(mysql, "KYC_IDLIST")
        Dim phROW As Integer = ds.Tables(0).Rows.Count

        Dim GENID As String = "SET GENERATOR " _
                                     & "KYC_IDLIST" & "_ID_GEN TO " _
                                     & phROW : RunCommand(GENID)
    End Sub

End Module
