Module db1231
    Const ALLOWABLE_VERSION As String = "1.2.2.5"
    Const LATEST_VERSION As String = "1.2.3.1"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try

            Table_Inventory()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Table_Inventory()
        Dim itmMaster As String
        Dim inv As String, invlines As String
        Dim doc As String, docLines As String

        itmMaster = "CREATE TABLE ITEMMASTER ("
        itmMaster &= vbCrLf & "  ITEMID BIGINT NOT NULL,"
        itmMaster &= vbCrLf & "  ITEMCODE VARCHAR(20),"
        itmMaster &= vbCrLf & "  DESCRIPTION VARCHAR(255),"
        itmMaster &= vbCrLf & "  BARCODE VARCHAR(25),"
        itmMaster &= vbCrLf & "  CATEGORIES VARCHAR(50),"
        itmMaster &= vbCrLf & "  SUBCAT VARCHAR(50),"
        itmMaster &= vbCrLf & "  UOM VARCHAR(20),"
        itmMaster &= vbCrLf & "  UNITPRICE NUMERIC(12, 3) DEFAULT '0.0' NOT NULL,"
        itmMaster &= vbCrLf & "  SALEPRICE NUMERIC(12, 3) DEFAULT '0.0' NOT NULL,"
        itmMaster &= vbCrLf & "  MINDEV DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        itmMaster &= vbCrLf & "  ISSALE SMALLINT DEFAULT '0' NOT NULL,"
        itmMaster &= vbCrLf & "  ISINV SMALLINT DEFAULT '1' NOT NULL,"
        itmMaster &= vbCrLf & "  ONHOLD SMALLINT DEFAULT '0' NOT NULL,"
        itmMaster &= vbCrLf & "  COMMENTS VARCHAR(255),"
        itmMaster &= vbCrLf & "  ONHAND DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        itmMaster &= vbCrLf & "  ADD_TIME TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
        itmMaster &= vbCrLf & "  UPDATE_TIME TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"
        RunCommand(itmMaster)

        inv = "CREATE TABLE INV ("
        inv &= vbCrLf & "  DOCID BIGINT NOT NULL,"
        inv &= vbCrLf & "  DOCNUM VARCHAR(20) NOT NULL,"
        inv &= vbCrLf & "  DOCDATE DATE,"
        inv &= vbCrLf & "  PARTNER VARCHAR(50) DEFAULT '' NOT NULL,"
        inv &= vbCrLf & "  GRANDTOTAL NUMERIC(12, 2) DEFAULT '0.0' NOT NULL,"
        inv &= vbCrLf & "  REMARKS VARCHAR(255),"
        inv &= vbCrLf & "  DOCSTATUS VARCHAR(20) DEFAULT '1' NOT NULL,"
        inv &= vbCrLf & "  REFNUM VARCHAR(20));"
        RunCommand(inv)

        invlines = "CREATE TABLE INVLINES ("
        invlines &= vbCrLf & "  INVID BIGINT NOT NULL,"
        invlines &= vbCrLf & "  DOCID BIGINT NOT NULL,"
        invlines &= vbCrLf & "  ITEMCODE VARCHAR(20),"
        invlines &= vbCrLf & "  DESCRIPTION VARCHAR(255),"
        invlines &= vbCrLf & "  QTY DECIMAL(12, 3) DEFAULT '0.0' NOT NULL,"
        invlines &= vbCrLf & "  UNITPRICE DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        invlines &= vbCrLf & "  SALEPRICE DECIMAL(12, 2) DEFAULT '0.0',"
        invlines &= vbCrLf & "  ROWTOTAL NUMERIC(12, 2) DEFAULT '0.0' NOT NULL,"
        invlines &= vbCrLf & "  UOM VARCHAR(20),"
        invlines &= vbCrLf & "  REMARKS VARCHAR(255));"
        RunCommand(invlines)

        doc = "CREATE TABLE DOC ("
        doc &= vbCrLf & "  DOCID BIGINT NOT NULL,"
        doc &= vbCrLf & "  DOCTYPE SMALLINT DEFAULT '0' NOT NULL,"
        doc &= vbCrLf & "  MOP VARCHAR(1) DEFAULT 'C' NOT NULL,"
        doc &= vbCrLf & "  CODE VARCHAR(20) NOT NULL,"
        doc &= vbCrLf & "  CUSTOMER VARCHAR(50) DEFAULT 'One-Time Customer',"
        doc &= vbCrLf & "  DOCDATE DATE DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
        doc &= vbCrLf & "  NOVAT NUMERIC(12, 2),"
        doc &= vbCrLf & "  VATRATE DECIMAL(12, 2),"
        doc &= vbCrLf & "  VATTOTAL NUMERIC(12, 2),"
        doc &= vbCrLf & "  DOCTOTAL DECIMAL(12, 3) DEFAULT '0.0' NOT NULL,"
        doc &= vbCrLf & "  STATUS VARCHAR(1) DEFAULT '1' NOT NULL,"
        doc &= vbCrLf & "  REMARKS VARCHAR(255),"
        doc &= vbCrLf & "  SYSTEMDATE DATE DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
        doc &= vbCrLf & "  USERID INTEGER DEFAULT '0' NOT NULL);"
        RunCommand(doc)

        docLines = "CREATE TABLE DOCLINES ("
        docLines &= vbCrLf & "  DLID BIGINT NOT NULL,"
        docLines &= vbCrLf & "  DOCID BIGINT DEFAULT '0' NOT NULL,"
        docLines &= vbCrLf & "  ITEMCODE VARCHAR(20) NOT NULL,"
        docLines &= vbCrLf & "  DESCRIPTION VARCHAR(255) NOT NULL,"
        docLines &= vbCrLf & "  QTY DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  UNITPRICE DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  SALEPRICE DECIMAL(12, 2) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  ROWTOTAL NUMERIC(12, 2) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  UOM VARCHAR(20),"
        docLines &= vbCrLf & "  REMARKS VARCHAR(255));"
        RunCommand(docLines)

        AutoIncrement_ID("ITEMMASTER", "ITEMID")
        AutoIncrement_ID("INV", "DOCID")
        AutoIncrement_ID("INVLINES", "INVID")
        AutoIncrement_ID("DOC", "DOCID")
        AutoIncrement_ID("DOCLINES", "DLID")
    End Sub
End Module
