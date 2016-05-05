Module db1011
    Const ALLOWABLE_VERSION As String = "1.0.10"
    Const LATEST_VERSION As String = "1.0.11"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW MONEY_TRANSFER;"
        Dim CREATE_NEW_PRINT_PAWNING As String
        Dim mySql As String
        mySql = "CREATE VIEW MONEY_TRANSFER("
        mySql &= vbCrLf & "  SERVICETYPE, TRANSDATE, MONEYTRANS, REFNUM,"
        mySql &= vbCrLf & "  PAYOUT, SENDOUT, SERVICECHARGE, COMMISSION, NETAMOUNT, "
        mySql &= vbCrLf & "  SENDERNAME, S_ADDR, RECEIVERNAME, R_ADDR, LOCATION)"
        mySql &= vbCrLf & "AS "
        mySql &= vbCrLf & "SELECT "
        mySql &= vbCrLf & "  MT.ServiceType, MT.TransDate,"
        mySql &= vbCrLf & "    CASE MoneyTrans "
        mySql &= vbCrLf & "      WHEN 0 THEN 'PAYOUT'"
        mySql &= vbCrLf & "      WHEN 1 THEN 'SENDIN'"
        mySql &= vbCrLf & "      ELSE 'NA'"
        mySql &= vbCrLf & "    END AS MoneyTrans,"
        mySql &= vbCrLf & "    CASE"
        mySql &= vbCrLf & "      WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0"
        mySql &= vbCrLf & "      THEN 'ME# ' || LPAD(TransID,5,0)"
        mySql &= vbCrLf & "    WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1"
        mySql &= vbCrLf & "      THEN 'MR# ' || LPAD(TransID,5,0)"
        mySql &= vbCrLf & "      ELSE RefNum END as RefNum,"
        mySql &= vbCrLf & "    CASE MoneyTrans"
        mySql &= vbCrLf & "      WHEN 0 THEN AMOUNT "
        mySql &= vbCrLf & "      ELSE 0 END AS PAYOUT,"
        mySql &= vbCrLf & "    CASE MoneyTrans"
        mySql &= vbCrLf & "      WHEN 1 THEN AMOUNT "
        mySql &= vbCrLf & "      ELSE 0 END AS SENDOUT,"
        mySql &= vbCrLf & "    MT.ServiceCharge,"
        mySql &= vbCrLf & "    MT.Commission,"
        mySql &= vbCrLf & "    MT.NETAMOUNT, MT.SENDERNAME, "
        mySql &= vbCrLf & "    C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY AS S_ADDR, "
        mySql &= vbCrLf & "    MT.RECEIVERNAME, "
        mySql &= vbCrLf & "    R.ADDR_STREET || ' ' || R.ADDR_BRGY || ' ' || R.ADDR_CITY AS R_ADDR,"
        mySql &= vbCrLf & "    MT.LOCATION"
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "  TBLMONEYTRANSFER MT"
        mySql &= vbCrLf & "  INNER JOIN TBLCLIENT C"
        mySql &= vbCrLf & "  ON  MT.SENDERID = C.CLIENTID"
        mySql &= vbCrLf & "  INNER JOIN TBLCLIENT R"
        mySql &= vbCrLf & "  ON  MT.RECEIVERID = R.CLIENTID"
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & "  Status = 'A';"

        CREATE_NEW_PRINT_PAWNING = mySql
        Console.WriteLine(mySql)

        Try

            ' REMOVE VIEW
            RunCommand(DROP_VIEW)

            ' CREATE VIEW
            RunCommand(CREATE_NEW_PRINT_PAWNING)


            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.10 TO 1.0.11")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.0.11]")
        End Try
    End Sub
End Module
