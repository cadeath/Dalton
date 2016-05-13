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
        mySql &= vbCrLf & "    P.PAWNTICKET, P.CLIENT, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, "
        mySql &= vbCrLf & "    P.DESCRIPTION, P.APPRAISAL, P.PRINCIPAL, P.NETAMOUNT, "
        mySql &= vbCrLf & "    P.RENEWDUE + P2.RENEWDUE AS RENEWDUE, "
        mySql &= vbCrLf & "    P.INTEREST + P2.INTEREST AS INTEREST, P.PENALTY + P2.PENALTY AS PENALTY, "
        mySql &= vbCrLf & "    P.ADVINT, P.SERVICECHARGE, "
        mySql &= vbCrLf & "    CASE"
        mySql &= vbCrLf & "    	WHEN P.OLDTICKET = 0"
        mySql &= vbCrLf & "        THEN 'NEW'"
        mySql &= vbCrLf & "        ELSE 'RENEW'"
        mySql &= vbCrLf & "    END AS STATUS"
        mySql &= vbCrLf & "    , P2.PAWNTICKET AS NewPT, P.APPRAISER "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "	PAWNING P LEFT JOIN PAWNING P2 "
        mySql &= vbCrLf & "    ON P.OLDTICKET = P2.PAWNTICKET "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	P.LOANDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= vbCrLf & "    AND (P.OLDTICKET = 0 OR (P.OLDTICKET > 0 AND P.RENEWDUE + P2.RENEWDUE Is Not Null)) "
        mySql &= vbCrLf & " AND P.STATUS <> 'V'"

        Console.WriteLine(">>> " & mySql)
        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)

        Dim dsHit As DataSet, hitSql As String
        hitSql = String.Format("SELECT * FROM TBLHIT WHERE HIT_DATE = '{0}'", monCal.SelectionStart.ToShortDateString)

        dsHit = LoadSQL(hitSql)
        If dsHit.Tables(0).Rows.Count = 0 Then
            addParameter.Add("withSub", False)
            frmReport.ReportInit(mySql, fillData, "Reports\rpt_RegisterNewLoan.rdlc", addParameter)
        Else
            addParameter.Add("withSub", True)

            Dim MySqlDic As New Dictionary(Of String, String)
            MySqlDic.Add(fillData, mySql)
            Dim subSql As New Dictionary(Of String, String)
            subSql.Add(HitManagement.dsName, HitManagement.Generate_HitReport(monCal.SelectionStart.ToShortDateString))

            frmReport.MultiDbSetReport(MySqlDic, "Reports\rpt_RegisterNewLoan.rdlc", addParameter, True, subSql)
        End If

        frmReport.Show()
    End Sub

    Private Sub Generate_Redemption()
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsPawning"
        rptPath = "Reports\rpt_RegisterRedeem.rdlc"

        mySql = "SELECT "
        mySql &= vbCrLf & "    P.PAWNTICKET, P.ORNUM, P.ORDATE, P.CLIENT, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, "
        mySql &= vbCrLf & "    P.DESCRIPTION, P.APPRAISAL, P.PRINCIPAL, P.ITEMTYPE, "
        mySql &= vbCrLf & "    P.INTEREST, P.PENALTY, P.REDEEMDUE, "
        mySql &= vbCrLf & "    P.SERVICECHARGE, 'REDEEM' AS STATUS "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "	PAWNING P "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	P.ORDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= vbCrLf & "    AND P.REDEEMDUE <> 0 "
        mySql &= vbCrLf & "    AND P.STATUS <> 'V' "
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