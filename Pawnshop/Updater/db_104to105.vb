Module db_104to105

    Private Sub Update_Pawning()
        RunCommand("DROP VIEW PAWNING")

        Dim sb As String
        sb = "CREATE VIEW PAWNING(" & vbCrLf &
        "  PAWNTICKET," & vbCrLf &
        "  LOANDATE," & vbCrLf &
        "  MATUDATE," & vbCrLf &
        "  EXPIRYDATE," & vbCrLf &
        "  CLIENT," & vbCrLf &
        "  FULLADDRESS," & vbCrLf &
        "  DESCRIPTION," & vbCrLf &
        "  ORNUM," & vbCrLf &
        "  ORDATE," & vbCrLf &
        "  OLDTICKET," & vbCrLf &
        "  NETAMOUNT," & vbCrLf &
        "  RENEWDUE," & vbCrLf &
        "  REDEEMDUE," & vbCrLf &
        "  APPRAISAL," & vbCrLf &
        "  PRINCIPAL," & vbCrLf &
        "  INTEREST," & vbCrLf &
        "  ADVINT," & vbCrLf &
        "  SERVICECHARGE," & vbCrLf &
        "  ITEMTYPE," & vbCrLf &
        "  CATEGORY," & vbCrLf &
        "  GRAMS," & vbCrLf &
        "  KARAT," & vbCrLf &
        "  STATUS," & vbCrLf &
        "  PULLOUT," & vbCrLf &
        "  APPRAISER)" & vbCrLf &
        "AS " & vbCrLf &
        "SELECT " & vbCrLf &
        "	P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE , " & vbCrLf &
        "    C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT," & vbCrLf &
        "	C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_ZIP as FULLADDRESS," & vbCrLf &
        "    CASE " & vbCrLf &
        "    	WHEN P.ITEMTYPE = 'JWL' AND (P.DESCRIPTION = Null OR P.DESCRIPTION = '') THEN " & vbCrLf &
        "        	CLASS.CATEGORY || ' ' || ROUND(P.GRAMS,2) || 'G ' || P.KARAT || 'K'" & vbCrLf &
        "        ELSE P.DESCRIPTION" & vbCrLf &
        "    END AS Description, " & vbCrLf &
        "    P.ORNUM, P.ORDATE, P.OLDTICKET, P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL, P.PRINCIPAL, " & vbCrLf &
        "    P.INTEREST, P.ADVINT, P.SERVICECHARGE, P.ITEMTYPE, CLASS.CATEGORY, P.GRAMS, P.KARAT," & vbCrLf &
        "    CASE P.STATUS" & vbCrLf &
        "	    WHEN '0' THEN 'RENEWED'" & vbCrLf &
        "        WHEN 'R' THEN 'RENEW'" & vbCrLf &
        "        WHEN 'L' THEN 'NEW'" & vbCrLf &
        "        WHEN 'V' THEN 'VOID'" & vbCrLf &
        "        WHEN 'W' THEN 'WITHDRAW'" & vbCrLf &
        "        WHEN 'X' THEN 'REDEEM'" & vbCrLf &
        "        WHEN 'S' THEN 'SEGRE'" & vbCrLf &
        "        ELSE 'N/A'" & vbCrLf &
        "    END AS STATUS, P.PULLOUT , USR.USERNAME as APPRAISER" & vbCrLf &
        "FROM TBLPAWN P" & vbCrLf &
        "INNER JOIN TBLCLIENT C " & vbCrLf &
        "	ON C.CLIENTID = P.CLIENTID" & vbCrLf &
        "LEFT JOIN TBLCLASS CLASS" & vbCrLf &
        "	ON CLASS.CLASSID = P.CATID" & vbCrLf &
        "LEFT JOIN tbl_Gamit USR" & vbCrLf &
        "    ON USR.USERID = P.APPRAISERID;"

        RunCommand(sb)
    End Sub

    Private Sub Update_MoneyTransfer()
        RunCommand("DROP VIEW MONEY_TRANSFER")

        Dim sb As String
        sb = "CREATE VIEW MONEY_TRANSFER(" & vbCrLf &
        "  SERVICETYPE," & vbCrLf &
        "  TRANSDATE," & vbCrLf &
        "  MONEYTRANS," & vbCrLf &
        "  REFNUM," & vbCrLf &
        "  PAYOUT," & vbCrLf &
        "  SENDOUT," & vbCrLf &
        "  SERVICECHARGE," & vbCrLf &
        "  COMMISSION," & vbCrLf &
        "  NETAMOUNT)" & vbCrLf &
        "AS " & vbCrLf &
        "SELECT " & vbCrLf &
        "	ServiceType, TransDate," & vbCrLf &
        "    CASE MoneyTrans " & vbCrLf &
        "      WHEN 0 THEN 'PAYOUT'" & vbCrLf &
        "      WHEN 1 THEN 'SENDOUT'" & vbCrLf &
        "      ELSE 'NA'" & vbCrLf &
        "    END AS MoneyTrans," & vbCrLf &
        "    CASE" & vbCrLf &
        "      WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0" & vbCrLf &
        "      THEN 'ME# ' || LPAD(TransID,5,0)" & vbCrLf &
        "	  WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1" & vbCrLf &
        "      THEN 'MR# ' || LPAD(TransID,5,0)" & vbCrLf &
        "      ELSE RefNum END as RefNum," & vbCrLf &
        "    CASE MoneyTrans" & vbCrLf &
        "      WHEN 0 THEN NETAMOUNT " & vbCrLf &
        "      ELSE 0 END AS PAYOUT," & vbCrLf &
        "    CASE MoneyTrans" & vbCrLf &
        "      WHEN 1 THEN NETAMOUNT " & vbCrLf &
        "      ELSE 0 END AS SENDOUT," & vbCrLf &
        "    ServiceCharge," & vbCrLf &
        "    Commission," & vbCrLf &
        "    NETAMOUNT" & vbCrLf &
        "FROM" & vbCrLf &
        "	TBLMONEYTRANSFER" & vbCrLf &
        "WHERE" & vbCrLf &
        "	Status = 'A';"

        RunCommand(sb)
    End Sub

    Sub Main()
        Update_Pawning()
        Developers_Note("Pawning updated")

        Update_MoneyTransfer()
        Developers_Note("MT updated")

        Database_Update("1.0.5")
    End Sub
End Module