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
        mySql &= vbCrLf & "    	WHEN (P.RENEWDUE + P2.RENEWDUE) is Null"
        mySql &= vbCrLf & "        THEN 'NEW'"
        mySql &= vbCrLf & "        ELSE 'RENEW'"
        mySql &= vbCrLf & "    END AS STATUS"
        mySql &= vbCrLf & "    , P2.PAWNTICKET AS NewPT, P.APPRAISER "
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "	PAWNING P LEFT JOIN PAWNING P2 "
        mySql &= vbCrLf & "    ON P.OLDTICKET = P2.PAWNTICKET "
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format("	P.LOANDATE = '{0}'", monCal.SelectionStart.ToShortDateString)

        Console.WriteLine(">>> " & mySql)
        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_RegisterNewLoan.rdlc", addParameter)
        frmReport.Show()
    End Sub

    Private Sub Generate_Redemption()
        Dim fillData As String = "dsPawning", mySql As String
        mySql = "SELECT * FROM PAWNING WHERE "
        mySql &= String.Format("ORDate = '{0}' AND STATUS = 'REDEEM' ", monCal.SelectionStart.ToString("MM/dd/yyyy"))
        mySql &= "ORDER BY ORNUM ASC"

        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_RegisterRedeem.rdlc", addParameter)
        frmReport.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class