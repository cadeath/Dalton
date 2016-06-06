Module db121
    Const ALLOWABLE_VERSION As String = "1.2"
    Const LATEST_VERSION As String = "1.2.1"

    Sub PatchUp()
        If ifTblExist("TBLCURRENCY") Then
            Populate_CurrencyDB()
        End If
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim TBL_CURRENCY As String
        TBL_CURRENCY = "CREATE TABLE TBLCURRENCY ("
        TBL_CURRENCY &= vbCrLf & "  CURRENCYID INTEGER NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  CURRENCY VARCHAR(30) NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  SYMBOL VARCHAR(20) NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  RATE NUMERIC(12, 2) NOT NULL,"
        TBL_CURRENCY &= vbCrLf & "  CASHID INTEGER NOT NULL);"

        Dim INSERT_USD As String
        INSERT_USD = "INSERT INTO TBLCURRENCY (CURRENCY,SYMBOL,RATE,CASHID) VALUES ('US DOLLAR','USD',46,45);"

        Try
            RunCommand(TBL_CURRENCY)
            RunCommand("ALTER TABLE TBLCURRENCY ADD PRIMARY KEY (CURRENCYID);")

            AutoIncrement_ID("TBLCURRENCY", "CURRENCYID")

            RunCommand("ALTER TABLE TBLDOLLAR ADD CURRENCY VARCHAR(30) NOT NULL;")

            RunCommand(INSERT_USD)

            Populate_DollarDB()

            MoneyTransfer_View()

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2 TO 1.2.1")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.2.1]")
        End Try
    End Sub

    Private Sub Populate_CurrencyDB()
        Dim mySql As String = "SELECT * FROM TBLCURRENCY"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Dim INSERT_USD As String
            INSERT_USD = "INSERT INTO TBLCURRENCY (CURRENCY,SYMBOL,RATE,CASHID) VALUES ('US DOLLAR','USD',46,45);"

            RunCommand(INSERT_USD)
        End If
    End Sub

    Private Sub Populate_DollarDB()
        Dim POPDB As String
        POPDB = "UPDATE TBLDOLLAR "
        POPDB &= vbCrLf & "SET CURRENCY = 'US DOLLAR'"
        POPDB &= vbCrLf & "WHERE CURRENCY is Null;"

        RunCommand(POPDB)
    End Sub

    Private Sub MoneyTransfer_View()
        Dim MT_VIEW As String
        MT_VIEW = "CREATE VIEW MONEY_TRANSFER( "
        MT_VIEW &= vbCrLf & "  SERVICETYPE,"
        MT_VIEW &= vbCrLf & "  TRANSDATE,"
        MT_VIEW &= vbCrLf & "  MONEYTRANS,"
        MT_VIEW &= vbCrLf & "  REFNUM,"
        MT_VIEW &= vbCrLf & "  PAYOUT,"
        MT_VIEW &= vbCrLf & "  SENDOUT,"
        MT_VIEW &= vbCrLf & "  SERVICECHARGE,"
        MT_VIEW &= vbCrLf & "  COMMISSION,"
        MT_VIEW &= vbCrLf & "  NETAMOUNT,"
        MT_VIEW &= vbCrLf & "  SENDERNAME,"
        MT_VIEW &= vbCrLf & "  S_ADDR,"
        MT_VIEW &= vbCrLf & "  RECEIVERNAME,"
        MT_VIEW &= vbCrLf & "  R_ADDR,"
        MT_VIEW &= vbCrLf & "  LOCATION)"
        MT_VIEW &= vbCrLf & "AS "
        MT_VIEW &= vbCrLf & "SELECT "
        MT_VIEW &= vbCrLf & "  MT.ServiceType, MT.TransDate,"
        MT_VIEW &= vbCrLf & "    CASE MoneyTrans "
        MT_VIEW &= vbCrLf & "      WHEN 0 THEN 'SENDIN'"
        MT_VIEW &= vbCrLf & "      WHEN 1 THEN 'PAYOUT'"
        MT_VIEW &= vbCrLf & "      ELSE 'NA'"
        MT_VIEW &= vbCrLf & "    END AS MoneyTrans,"
        MT_VIEW &= vbCrLf & "    CASE"
        MT_VIEW &= vbCrLf & "      WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0"
        MT_VIEW &= vbCrLf & "      THEN 'ME# ' || LPAD(TransID,5,0)"
        MT_VIEW &= vbCrLf & "    WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1"
        MT_VIEW &= vbCrLf & "      THEN 'MR# ' || LPAD(TransID,5,0)"
        MT_VIEW &= vbCrLf & "      ELSE RefNum END as RefNum,"
        MT_VIEW &= vbCrLf & "    CASE MoneyTrans"
        MT_VIEW &= vbCrLf & "      WHEN 1 THEN AMOUNT "
        MT_VIEW &= vbCrLf & "      ELSE 0 END AS PAYOUT,"
        MT_VIEW &= vbCrLf & "    CASE MoneyTrans"
        MT_VIEW &= vbCrLf & "      WHEN 0 THEN AMOUNT "
        MT_VIEW &= vbCrLf & "      ELSE 0 END AS SENDOUT,"
        MT_VIEW &= vbCrLf & "    MT.ServiceCharge,"
        MT_VIEW &= vbCrLf & "    MT.Commission,"
        MT_VIEW &= vbCrLf & "    MT.NETAMOUNT, MT.SENDERNAME, "
        MT_VIEW &= vbCrLf & "    C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY AS S_ADDR, "
        MT_VIEW &= vbCrLf & "    MT.RECEIVERNAME, "
        MT_VIEW &= vbCrLf & "    R.ADDR_STREET || ' ' || R.ADDR_BRGY || ' ' || R.ADDR_CITY AS R_ADDR,"
        MT_VIEW &= vbCrLf & "    MT.LOCATION"
        MT_VIEW &= vbCrLf & "FROM "
        MT_VIEW &= vbCrLf & "  TBLMONEYTRANSFER MT"
        MT_VIEW &= vbCrLf & "  INNER JOIN TBLCLIENT C"
        MT_VIEW &= vbCrLf & "  ON  MT.SENDERID = C.CLIENTID"
        MT_VIEW &= vbCrLf & "  INNER JOIN TBLCLIENT R"
        MT_VIEW &= vbCrLf & "  ON  MT.RECEIVERID = R.CLIENTID"
        MT_VIEW &= vbCrLf & "WHERE "
        MT_VIEW &= vbCrLf & "  Status = 'A';"

        RunCommand("DROP VIEW MONEY_TRANSFER;")
        RunCommand(MT_VIEW)
    End Sub
End Module
