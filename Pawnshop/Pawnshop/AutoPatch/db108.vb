Module db108

    Const ALLOWABLE_VERSION As String = "1.0.7"
    Const LATEST_VERSION As String = "1.0.8"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW MONTHLY_LOANRENEW"
        RunCommand(DROP_VIEW)

        Dim mySql As String
        mySql = "CREATE VIEW MONTHLY_LOANRENEW( "
        mySql &= vbCrLf & "  LOANDATE, "
        mySql &= vbCrLf & "  CEL_COUNT, "
        mySql &= vbCrLf & "  CEL_PRINCIPAL, "
        mySql &= vbCrLf & "  JWL_COUNT, "
        mySql &= vbCrLf & "  JWL_PRINCIPAL, "
        mySql &= vbCrLf & "  APP_COUNT, "
        mySql &= vbCrLf & "  APP_PRINCIPAL, "
        mySql &= vbCrLf & "  LOAN_COUNT, "
        mySql &= vbCrLf & "  LOAN_PRINCIPAL, "
        mySql &= vbCrLf & "  RENEW_COUNT, "
        mySql &= vbCrLf & "  RENEW_PRINCIPAL) "
        mySql &= vbCrLf & "AS "
        mySql &= vbCrLf & "SELECT LOANDATE,  "
        mySql &= vbCrLf & "	SUM(CASE WHEN ITEMTYPE = 'CEL' AND STATUS = 'L' THEN 1 ELSE 0 END) AS CEL_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN ITEMTYPE = 'CEL' AND STATUS = 'L' THEN PRINCIPAL ELSE 0 END) AS CEL_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN ITEMTYPE = 'JWL' AND STATUS = 'L' THEN 1 ELSE 0 END) AS JWL_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN ITEMTYPE = 'JWL' AND STATUS = 'L' THEN PRINCIPAL ELSE 0 END) AS JWL_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE WHEN ITEMTYPE = 'APP' AND STATUS = 'L' THEN 1 ELSE 0 END) AS APP_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE WHEN ITEMTYPE = 'APP' AND STATUS = 'L' THEN PRINCIPAL "
        mySql &= vbCrLf & "    WHEN ITEMTYPE = 'BIG' AND STATUS = 'L' THEN PRINCIPAL ELSE 0 END) AS APP_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE STATUS WHEN 'L' THEN 1 ELSE 0 END) AS LOAN_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE STATUS WHEN 'L' THEN PRINCIPAL ELSE 0 END) AS LOAN_PRINCIPAL, "
        mySql &= vbCrLf & "    SUM(CASE STATUS WHEN '0' THEN 1 WHEN 'R' THEN 1 ELSE 0 END) AS RENEW_COUNT, "
        mySql &= vbCrLf & "    SUM(CASE STATUS WHEN '0' THEN PRINCIPAL "
        mySql &= vbCrLf & "    WHEN 'R' THEN PRINCIPAL ELSE 0 END) AS RENEW_PRINCIPAL "
        mySql &= vbCrLf & "FROM TBLPAWN "
        mySql &= vbCrLf & "WHERE (STATUS = 'L' OR STATUS = '0' OR STATUS = 'R') "
        mySql &= vbCrLf & "GROUP BY 1"

        RunCommand(mySql)

        Pawning_View()
        BDO_ATM_CashOut()

        Database_Update(LATEST_VERSION)
        Log_Report("SYSTEM PATCHED UP FROM 1.0.7 TO 1.0.8")
    End Sub

    Private Sub Pawning_View()
        Dim DROP_VIEW As String = "DROP VIEW PAWNING"
        RunCommand(DROP_VIEW)

        Dim mySql As String
        mySql = "CREATE VIEW PAWNING( "
        mySql &= "  PAWNTICKET, LOANDATE, MATUDATE, EXPIRYDATE, CLIENT, FULLADDRESS, DESCRIPTION, "
        mySql &= "  ORNUM, ORDATE, OLDTICKET, NETAMOUNT, RENEWDUE, REDEEMDUE, APPRAISAL, PRINCIPAL, "
        mySql &= "  INTEREST, ADVINT, SERVICECHARGE, PENALTY, ITEMTYPE, CATEGORY, GRAMS, KARAT, "
        mySql &= "  STATUS, PULLOUT, APPRAISER) "
        mySql &= "AS "
        mySql &= "SELECT  "
        mySql &= "	P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE ,  "
        mySql &= "    C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, "
        mySql &= "	C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        mySql &= "    CASE  "
        mySql &= "    	WHEN P.ITEMTYPE = 'JWL' AND (P.DESCRIPTION = Null OR P.DESCRIPTION = '') THEN  "
        mySql &= "        	CLASS.CATEGORY || ' ' || ROUND(P.GRAMS,2) || 'G ' || P.KARAT || 'K' "
        mySql &= "        ELSE P.DESCRIPTION "
        mySql &= "    END AS Description,  "
        mySql &= "    P.ORNUM, P.ORDATE, P.OLDTICKET, P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL, P.PRINCIPAL,  "
        mySql &= "    P.INTEREST, P.ADVINT, P.SERVICECHARGE,P.PENALTY, P.ITEMTYPE, CLASS.CATEGORY, P.GRAMS, P.KARAT, "
        mySql &= "    CASE P.STATUS "
        mySql &= "	    WHEN '0' THEN 'RENEWED' "
        mySql &= "        WHEN 'R' THEN 'RENEW' "
        mySql &= "        WHEN 'L' THEN 'NEW' "
        mySql &= "        WHEN 'V' THEN 'VOID' "
        mySql &= "        WHEN 'W' THEN 'WITHDRAW' "
        mySql &= "        WHEN 'X' THEN 'REDEEM' "
        mySql &= "        WHEN 'S' THEN 'SEGRE' "
        mySql &= "        ELSE 'N/A' "
        mySql &= "    END AS STATUS, P.PULLOUT , USR.USERNAME as APPRAISER  "
        mySql &= "FROM TBLPAWN P "
        mySql &= "INNER JOIN TBLCLIENT C  "
        mySql &= "	ON C.CLIENTID = P.CLIENTID "
        mySql &= "LEFT JOIN TBLCLASS CLASS "
        mySql &= "	ON CLASS.CLASSID = P.CATID "
        mySql &= "LEFT JOIN tbl_Gamit USR "
        mySql &= "    ON USR.USERID = P.APPRAISERID;"

        RunCommand(mySql)
    End Sub

    Private Sub Add_Option(ByVal key As String, ByVal val As String)
        ' Adding BDOCommissionRate
        ' ----------------------------------------------------------
        Dim mySql As String, ds As DataSet
        Dim fillData As String = "tblMAINTENANCE"
        mySql = "SELECT * FROM " & fillData
        mySql &= " WHERE OPT_KEYS = '" & key & "'"
        ds = LoadSQL(mySql, fillData)

        If ds.Tables(fillData).Rows.Count > 0 Then Exit Sub

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow

        With dsNewRow
            .Item("OPT_KEYS") = key
            .Item("OPT_VALUES") = val
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Private Sub BDO_ATM_CashOut()
        Try
            Dim mySql As String, ds As DataSet
            Dim fillData As String, dsNewRow As DataRow

            ' Adding BDOCommissionRate
            ' ----------------------------------------------------------
            Add_Option("BDOCommissionRate", 18)

            ' Adding new Entry - Income from BDO ATM CashOut
            ' ----------------------------------------------------------
            mySql = "SELECT * FROM " : fillData = "TBLCASH"
            mySql &= fillData & String.Format(" WHERE TRANSNAME = 'Income from BDO ATM CashOut'")
            ds = LoadSQL(mySql, fillData)
            If ds.Tables(fillData).Rows.Count > 0 Then GoTo LastPhase

            dsNewRow = ds.Tables(fillData).NewRow

            With dsNewRow
                .Item("TYPE") = ""
                .Item("Category") = "BDO ATM CASHOUT"
                .Item("Transname") = "Income from BDO ATM CashOut"
                .Item("SAPACCOUNT") = "_SYS00000001042"
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)

LastPhase:
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "PATCHING DATABASE")
            Log_Report(ex.ToString)
        End Try
    End Sub

End Module