Module db108

    Const ALLOWABLE_VERSION As String = "1.0.7"
    Const LATEST_VERSION As String = "1.0.8"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW PAWNING"
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
        Database_Update(LATEST_VERSION)
    End Sub

End Module