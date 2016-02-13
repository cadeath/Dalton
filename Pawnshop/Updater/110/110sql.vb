Module _110

    Sub Main()
        Alter_tblPawn()
        New_Pawning()
    End Sub

    'ALTER TABLE TBLPAWN ADD EARLYREDEEM NUMERIC(12, 2);

    Private Sub Alter_tblPawn()
        Dim mySql As String = _
            "ALTER TABLE TBLPAWN ADD EARLYREDEEM NUMERIC(12, 2) DEFAULT '0.0' NOT NULL;"
        RunCommand(mySql)
        Developers_Note("Add column successful")
    End Sub

    Private Sub New_Pawning()
        Dim drop_Pawning As String = _
            "DROP VIEW PAWNING"
        RunCommand(drop_Pawning)

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
        "  NETAMOUNT," & vbCrLf &
        "  RENEWDUE," & vbCrLf &
        "  REDEEMDUE," & vbCrLf &
        "  APPRAISAL," & vbCrLf &
        "  PRINCIPAL," & vbCrLf &
        "  INTEREST," & vbCrLf &
        "  ADVINT," & vbCrLf &
        "  ITEMTYPE," & vbCrLf &
        "  CATEGORY," & vbCrLf &
        "  GRAMS," & vbCrLf &
        "  KARAT," & vbCrLf &
        "  STATUS," & vbCrLf &
        "  PULLOUT," & vbCrLf &
        "  APPRAISER)" & vbCrLf &
        "AS" & vbCrLf &
        "SELECT " & vbCrLf &
        "	P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE , " & vbCrLf &
        "    C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT," & vbCrLf &
        "	C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_ZIP as FULLADDRESS," & vbCrLf &
        "    CASE " & vbCrLf &
        "    	WHEN P.ITEMTYPE = 'JWL' AND (P.DESCRIPTION = Null OR P.DESCRIPTION = '') THEN " & vbCrLf &
        "        	CLASS.CATEGORY || ' ' || ROUND(P.GRAMS,2) || 'G ' || P.KARAT || 'K'" & vbCrLf &
        "        ELSE P.DESCRIPTION" & vbCrLf &
        "    END AS Description, " & vbCrLf &
        "    P.ORNUM, P.ORDATE, P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL, P.PRINCIPAL, " & vbCrLf &
        "    P.INTEREST, P.ADVINT,P.ITEMTYPE, CLASS.CATEGORY, P.GRAMS, P.KARAT," & vbCrLf &
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

End Module
