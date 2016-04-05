Module db108

    Const ALLOWABLE_VERSION As String = "1.0.7"
    Const LATEST_VERSION As String = "1.0.8"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW MONTHLY_LOANRENEW"
        Try
            RunCommand(DROP_VIEW)
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try


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

        Try
            RunCommand(mySql)
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.0.8]")
        End Try

        Pawning_View()
        BDO_ATM_CashOut()

        Database_Update(LATEST_VERSION)
        Log_Report("SYSTEM PATCHED UP FROM 1.0.7 TO 1.0.8")
    End Sub

    Private Sub Pawning_View()
        Dim DROP_VIEW As String = "DROP VIEW PAWNING"
        Try
            RunCommand(DROP_VIEW)
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
        

        Dim mySql As String
        mySql = "CREATE VIEW PAWNING "
        mySql &= vbCrLf & "AS "
        mySql &= vbCrLf & "SELECT  "
        mySql &= vbCrLf & "	P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE,  "
        mySql &= vbCrLf & "    C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, "
        mySql &= vbCrLf & "	C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        mySql &= vbCrLf & "    CASE  "
        mySql &= vbCrLf & "    	WHEN P.ITEMTYPE = 'JWL' AND (P.DESCRIPTION = Null OR P.DESCRIPTION = '') THEN  "
        mySql &= vbCrLf & "        	CLASS.CATEGORY || ' ' || ROUND(P.GRAMS,2) || 'G ' || P.KARAT || 'K' "
        mySql &= vbCrLf & "        ELSE P.DESCRIPTION "
        mySql &= vbCrLf & "    END AS Description,  "
        mySql &= vbCrLf & "    P.ORNUM, P.ORDATE, P.OLDTICKET, P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL, P.PRINCIPAL,  "
        mySql &= vbCrLf & "    P.INTEREST, P.ADVINT, P.SERVICECHARGE,P.PENALTY, P.ITEMTYPE, CLASS.CATEGORY, P.GRAMS, P.KARAT, "
        mySql &= vbCrLf & "    CASE P.STATUS "
        mySql &= vbCrLf & "	    WHEN '0' THEN 'RENEWED' "
        mySql &= vbCrLf & "        WHEN 'R' THEN 'RENEW' "
        mySql &= vbCrLf & "        WHEN 'L' THEN 'NEW' "
        mySql &= vbCrLf & "        WHEN 'V' THEN 'VOID' "
        mySql &= vbCrLf & "        WHEN 'W' THEN 'WITHDRAW' "
        mySql &= vbCrLf & "        WHEN 'X' THEN 'REDEEM' "
        mySql &= vbCrLf & "        WHEN 'S' THEN 'SEGRE' "
        mySql &= vbCrLf & "        ELSE 'N/A' "
        mySql &= vbCrLf & "    END AS STATUS, P.PULLOUT , USR.USERNAME as APPRAISER "
        mySql &= vbCrLf & "FROM TBLPAWN P "
        mySql &= vbCrLf & "INNER JOIN TBLCLIENT C  "
        mySql &= vbCrLf & "	ON C.CLIENTID = P.CLIENTID "
        mySql &= vbCrLf & "LEFT JOIN TBLCLASS CLASS "
        mySql &= vbCrLf & "	ON CLASS.CLASSID = P.CATID "
        mySql &= vbCrLf & "LEFT JOIN tbl_Gamit USR "
        mySql &= vbCrLf & "    ON USR.USERID = P.APPRAISERID; "

        Try
            RunCommand(mySql)
        Catch ex As Exception
            Log_Report(ex.ToString)
        End Try
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