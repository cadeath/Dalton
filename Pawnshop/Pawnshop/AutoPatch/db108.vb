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

        BDO_ATM_CashOut()

        Database_Update(LATEST_VERSION)
        Log_Report("SYSTEM PATCHED UP FROM 1.0.7 TO 1.0.8")
    End Sub

    Private Sub BDO_ATM_CashOut()
        Try
            ' Adding BDOCommissionRate
            ' ----------------------------------------------------------
            Dim mySql As String, ds As DataSet
            Dim fillData As String = "tblMAINTENANCE"
            mySql = "SELECT * FROM " & fillData
            mySql &= " WHERE OPT_KEYS = 'BDOCommissionRate'"
            ds = LoadSQL(mySql, fillData)

            If ds.Tables(fillData).Rows.Count > 0 Then GoTo NextPhase_AddEntry

            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow

            With dsNewRow
                .Item("OPT_KEYS") = "BDOCommissionRate"
                .Item("OPT_VALUES") = 18
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)

            database.SaveEntry(ds)

            ' Adding new Entry
            ' ----------------------------------------------------------
NextPhase_AddEntry:
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