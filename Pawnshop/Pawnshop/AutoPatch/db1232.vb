Module db1232
    Const ALLOWABLE_VERSION As String = "1.2.2.5"
    Const LATEST_VERSION As String = "1.2.3.2"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try

            Table_Inventory()
            Fields_Added()
            Views_Adding()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Views_Adding()
        Console.WriteLine("Commencing adding views...")

        strSql = "CREATE VIEW STOCK_CARD("
        strSql &= vbCrLf & "  DOCTYPE, DOCDATE, REFNUM, ITEMCODE, DESCRIPTION, QTY)"
        strSql &= vbCrLf & "AS "
        strSql &= vbCrLf & "SELECT "
        strSql &= vbCrLf & " 'IN' AS DOCTYPE, I.DOCDATE, I.REFNUM, IL.ITEMCODE, IL.DESCRIPTION, IL.QTY "
        strSql &= vbCrLf & "FROM "
        strSql &= vbCrLf & " INVLINES IL "
        strSql &= vbCrLf & " INNER JOIN INV I "
        strSql &= vbCrLf & " ON I.DOCID = IL.DOCID "
        strSql &= vbCrLf & ""
        strSql &= vbCrLf & "UNION "
        strSql &= vbCrLf & "--OUT "
        strSql &= vbCrLf & "SELECT "
        strSql &= vbCrLf & " ( "
        strSql &= vbCrLf & "  CASE D.DOCTYPE  "
        strSql &= vbCrLf & "      WHEN 0 THEN 'SALES' "
        strSql &= vbCrLf & "        WHEN 1 THEN 'SALES' "
        strSql &= vbCrLf & "        WHEN 2 THEN 'RECALL' "
        strSql &= vbCrLf & "        WHEN 3 THEN 'RETURNS' "
        strSql &= vbCrLf & "        WHEN 4 THEN 'STOCKOUT' "
        strSql &= vbCrLf & "    END "
        strSql &= vbCrLf & " ) , D.DOCDATE, D.CODE AS REFNUM, DL.ITEMCODE, DL.DESCRIPTION, DL.QTY "
        strSql &= vbCrLf & "FROM "
        strSql &= vbCrLf & " DOCLINES DL "
        strSql &= vbCrLf & " INNER JOIN DOC D "
        strSql &= vbCrLf & " ON D.DOCID = DL.DOCID; "
        RunCommand(strSql)
    End Sub

    Private Sub Fields_Added()
        Dim mySql As String
        Console.WriteLine("Commencing adding fields...")

        'TBLMAINTENANCE
        UpdateOptions("InvoiceNum", 1)
        UpdateOptions("STONum", 1)
        UpdateOptions("SalesReturnNum", 1)
        UpdateOptions("CustomerCode", "CTDP 00001")

        'TBLITEM
        RunCommand("ALTER TABLE TBLITEM ADD SALESID SMALLINT DEFAULT '0' NOT NULL;")
        RunCommand("ALTER TABLE TBLITEM ADD COSTID SMALLINT DEFAULT '0' NOT NULL;")

        mySql = "ALTER TABLE TBLITEM"
        mySql &= vbCrLf & "ALTER COLUMN SALESID "
        mySql &= vbCrLf & "POSITION 4;"
        RunCommand(mySql)

        mySql = "ALTER TABLE TBLITEM"
        mySql &= vbCrLf & "ALTER COLUMN COSTID "
        mySql &= vbCrLf & "POSITION 5;"
        RunCommand(mySql)

        strSql = "UPDATE TBLCASH SET ONHOLD = 1 WHERE CATEGORY = 'AUCTION REDEEM'"
        RunCommand(strSql)
    End Sub

    Private Sub Table_Inventory()
        Dim itmMaster As String
        Dim inv As String, invlines As String
        Dim doc As String, docLines As String

        Console.WriteLine("Commencing adding tables...")

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
        invlines &= vbCrLf & "  QTY DECIMAL(12, 6) DEFAULT '0.0' NOT NULL,"
        invlines &= vbCrLf & "  UNITPRICE DECIMAL(12, 6) DEFAULT '0.0' NOT NULL,"
        invlines &= vbCrLf & "  SALEPRICE DECIMAL(12, 6) DEFAULT '0.0',"
        invlines &= vbCrLf & "  ROWTOTAL NUMERIC(12, 6) DEFAULT '0.0' NOT NULL,"
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
        docLines &= vbCrLf & "  QTY DECIMAL(12, 6) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  UNITPRICE DECIMAL(12, 6) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  SALEPRICE DECIMAL(12, 6) DEFAULT '0.0' NOT NULL,"
        docLines &= vbCrLf & "  ROWTOTAL NUMERIC(12, 6) DEFAULT '0.0' NOT NULL,"
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
