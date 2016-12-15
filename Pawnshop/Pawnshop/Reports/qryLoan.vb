Public Class qryLoan

    Private branchName As String = GetOption("BranchName")

    Private Function isValid() As Boolean
        If lstRegister.SelectedItems.Count <= 0 Then
            Return False
        End If

        Return True
    End Function

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If Not isValid() Then Exit Sub

        If lstRegister.SelectedIndex = 0 Then
            Generate_NewLoanRenewal()
        Else
            Generate_Redemption()
        End If
    End Sub

    Private Sub Generate_NewLoanRenewal()
        Dim fillData As String = "dsPawning", mySql As String

        mySql = "SELECT "
        mySql &= vbCrLf & "P1.PAWNTICKET, P1.CLIENT, P1.LOANDATE, P1.MATUDATE, P1.EXPIRYDATE, P1.DESCRIPTION, "
        mySql &= vbCrLf & "P1.APPRAISAL, P1.PRINCIPAL, P1.NETAMOUNT, "
        mySql &= vbCrLf & "CASE WHEN P2.RENEWDUE is Null "
        mySql &= vbCrLf & "THEN 0 ELSE P2.RENEWDUE "
        mySql &= vbCrLf & "END AS RENEWDUE, "
        mySql &= vbCrLf & "P2.DELAYINTEREST + P1.DELAYINTEREST AS INTEREST, "
        mySql &= vbCrLf & "P1.PENALTY + P2.PENALTY AS PENALTY,P1.ADVINT, P1.SERVICECHARGE, "
        mySql &= vbCrLf & "CASE WHEN P1.OLDTICKET = 0 "
        mySql &= vbCrLf & "THEN 'NEW' ELSE 'RENEW' "
        mySql &= vbCrLf & "END AS STATUS, P2.PAWNTICKET AS NewPT, P1.APPRAISER "
        mySql &= vbCrLf & "FROM PAWN_LIST P1 "
        mySql &= vbCrLf & "LEFT JOIN OPT P2 "
        mySql &= vbCrLf & "ON P1.OLDTICKET = P2.PAWNTICKET "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	P1.LOANDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= vbCrLf & "    AND (P1.OLDTICKET = 0 OR (P1.OLDTICKET > 0 AND P1.RENEWDUE + P2.RENEWDUE Is Not Null)) "
        mySql &= vbCrLf & " AND (P1.STATUS = 'L' OR P1.STATUS = '0' OR P1.STATUS = 'R' OR P1.STATUS = 'X')"
        mySql &= vbCrLf & " ORDER BY P1.PAWNTICKET ASC"

        Console.WriteLine(">>> " & mySql)
        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)

        Dim MySqlDic As New Dictionary(Of String, String)
        MySqlDic.Add(fillData, mySql)
        Dim subSql As New Dictionary(Of String, String)
        subSql.Add("dsHit", HitManagement.Generate_HitReport(monCal.SelectionStart.ToShortDateString))

        frmReport.MultiDbSetReport(MySqlDic, "Reports\rpt_RegisterNewLoan.rdlc", addParameter, True, subSql)

        frmReport.Show()
    End Sub

    Private Sub Generate_Redemption()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsPawning"
        rptPath = "Reports\rpt_RegisterRedeem.rdlc"

        mySql = "SELECT "
        mySql &= vbCrLf & "    P.PAWNTICKET, P.ORNUM, P.ORDATE, P.CLIENT, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, "
        mySql &= vbCrLf & "    P.DESCRIPTION, P.APPRAISAL, P.PRINCIPAL, P.ITEMCLASS, "
        mySql &= vbCrLf & "    P.DELAYINTEREST, P.PENALTY, P.REDEEMDUE, "
        mySql &= vbCrLf & "    P.SERVICECHARGE, 'REDEEM' AS STATUS "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "	PAWN_LIST P "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	P.ORDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= vbCrLf & "    AND P.REDEEMDUE <> 0 "
        mySql &= vbCrLf & "    AND P.STATUS = 'X' "
        mySql &= vbCrLf & "    ORDER BY ORNUM ASC"

        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)

        frmReport.ReportInit(mySql, dsName, rptPath, addParameter)
        frmReport.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class