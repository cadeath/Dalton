Module db1012
    Const ALLOWABLE_VERSION As String = "1.0.11"
    Const LATEST_VERSION As String = "1.0.12"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim ADD_AMOUNT As String, ADD_USERID As String, REMOVE_VIEW As String, ADD_VIEW As String
        ADD_AMOUNT = "ALTER TABLE TBL_DAILYTIMELOG ADD AMOUNT DECIMAL(12, 2) DEFAULT '0.0' NOT NULL;"
        ADD_USERID = "ALTER TABLE TBL_DAILYTIMELOG ADD USERID SMALLINT NOT NULL;"

        REMOVE_VIEW = "DROP VIEW MONEY_TRANSFER;"
        ADD_VIEW = "CREATE VIEW MONEY_TRANSFER("
        ADD_VIEW &= vbCrLf & "  SERVICETYPE,  TRANSDATE,  MONEYTRANS,"
        ADD_VIEW &= vbCrLf & "  REFNUM,  PAYOUT,  SENDOUT,  SERVICECHARGE,"
        ADD_VIEW &= vbCrLf & "  COMMISSION,  NETAMOUNT,  SENDERNAME,"
        ADD_VIEW &= vbCrLf & "  S_ADDR,  RECEIVERNAME,  R_ADDR,  LOCATION)"
        ADD_VIEW &= vbCrLf & "AS "
        ADD_VIEW &= vbCrLf & "SELECT "
        ADD_VIEW &= vbCrLf & "  MT.ServiceType, MT.TransDate,"
        ADD_VIEW &= vbCrLf & "    CASE MoneyTrans "
        ADD_VIEW &= vbCrLf & "      WHEN 1 THEN 'PAYOUT'"
        ADD_VIEW &= vbCrLf & "      WHEN 0 THEN 'SENDIN'"
        ADD_VIEW &= vbCrLf & "      ELSE 'NA'"
        ADD_VIEW &= vbCrLf & "    END AS MoneyTrans,"
        ADD_VIEW &= vbCrLf & "    CASE"
        ADD_VIEW &= vbCrLf & "      WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0"
        ADD_VIEW &= vbCrLf & "      THEN 'ME# ' || LPAD(TransID,5,0)"
        ADD_VIEW &= vbCrLf & "    WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1"
        ADD_VIEW &= vbCrLf & "      THEN 'MR# ' || LPAD(TransID,5,0)"
        ADD_VIEW &= vbCrLf & "      ELSE RefNum END as RefNum,"
        ADD_VIEW &= vbCrLf & "    CASE MoneyTrans"
        ADD_VIEW &= vbCrLf & "      WHEN 1 THEN AMOUNT "
        ADD_VIEW &= vbCrLf & "      ELSE 0 END AS PAYOUT,"
        ADD_VIEW &= vbCrLf & "    CASE MoneyTrans"
        ADD_VIEW &= vbCrLf & "      WHEN 0 THEN AMOUNT "
        ADD_VIEW &= vbCrLf & "      ELSE 0 END AS SENDOUT,"
        ADD_VIEW &= vbCrLf & "    MT.ServiceCharge,"
        ADD_VIEW &= vbCrLf & "    MT.Commission,"
        ADD_VIEW &= vbCrLf & "    MT.NETAMOUNT, MT.SENDERNAME, "
        ADD_VIEW &= vbCrLf & "    C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY AS S_ADDR, "
        ADD_VIEW &= vbCrLf & "    MT.RECEIVERNAME, "
        ADD_VIEW &= vbCrLf & "    R.ADDR_STREET || ' ' || R.ADDR_BRGY || ' ' || R.ADDR_CITY AS R_ADDR,"
        ADD_VIEW &= vbCrLf & "    MT.LOCATION"
        ADD_VIEW &= vbCrLf & "FROM "
        ADD_VIEW &= vbCrLf & "  TBLMONEYTRANSFER MT"
        ADD_VIEW &= vbCrLf & "  INNER JOIN TBLCLIENT C"
        ADD_VIEW &= vbCrLf & "  ON  MT.SENDERID = C.CLIENTID"
        ADD_VIEW &= vbCrLf & "  INNER JOIN TBLCLIENT R"
        ADD_VIEW &= vbCrLf & "  ON  MT.RECEIVERID = R.CLIENTID"
        ADD_VIEW &= vbCrLf & "WHERE "
        ADD_VIEW &= vbCrLf & "  Status = 'A';"

        Try
            RunCommand(ADD_AMOUNT)
            RunCommand(ADD_USERID)

            RunCommand(REMOVE_VIEW)
            RunCommand(ADD_VIEW)

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.11 TO 1.0.12")
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
    End Sub
End Module