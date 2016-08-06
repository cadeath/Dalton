Module AuditReports

    Friend Sub Min_Principal(ByVal min As Double, ByVal dt As Date, ByVal type As String)
        Dim mySql As String
        mySql = "SELECT * "
        mySql &= vbCrLf & "FROM ("
        mySql &= vbCrLf & "	SELECT *   "
        mySql &= vbCrLf & "	FROM PAWNING   "
        mySql &= vbCrLf & "	WHERE "
        mySql &= vbCrLf & "		(Status = 'NEW' OR Status = 'RENEW') "
        mySql &= vbCrLf & String.Format("		AND LOANDATE <= '{0}' AND PRINCIPAL >= {1}", dt.ToShortDateString, min)
        mySql &= vbCrLf & ""
        mySql &= vbCrLf & "	UNION"
        mySql &= vbCrLf & "	SELECT *   "
        mySql &= vbCrLf & "	FROM PAWNING   "
        mySql &= vbCrLf & "	WHERE "
        mySql &= vbCrLf & "		(Status = 'RENEWED')   "
        mySql &= vbCrLf & String.Format("		AND LOANDATE <= '{0}' AND ORDATE > '{0}' AND PRINCIPAL >= {1}", dt.ToShortDateString, min)
        mySql &= vbCrLf & ""
        mySql &= vbCrLf & "	UNION   "
        mySql &= vbCrLf & "	SELECT *   "
        mySql &= vbCrLf & "	FROM PAWNING   "
        mySql &= vbCrLf & "	WHERE "
        mySql &= vbCrLf & "		(Status = 'REDEEM')"
        mySql &= vbCrLf & String.Format("		AND LOANDATE <= '{0}' AND ORDATE > '{0}'  AND PRINCIPAL >= {1}", dt.ToShortDateString, min)
        mySql &= vbCrLf & ""
        mySql &= vbCrLf & "	UNION   "
        mySql &= vbCrLf & "	SELECT *   "
        mySql &= vbCrLf & "	FROM PAWNING  "
        mySql &= vbCrLf & "	WHERE "
        mySql &= vbCrLf & "		(Status = 'SEGRE')   "
        mySql &= vbCrLf & String.Format("		AND LOANDATE <= '{0}' AND (PULLOUT > '{0}' OR PULLOUT IS NULL) ", dt.ToShortDateString)
        mySql &= vbCrLf & String.Format("		AND PRINCIPAL >= {0}", min)
        mySql &= vbCrLf & ""
        mySql &= vbCrLf & "	UNION   "
        mySql &= vbCrLf & "	SELECT *   "
        mySql &= vbCrLf & "	FROM PAWNING   "
        mySql &= vbCrLf & "	WHERE "
        mySql &= vbCrLf & "		(Status = 'WITHDRAW')   "
        mySql &= vbCrLf & String.Format("		AND LOANDATE <= '{0}' AND PULLOUT > '{0}' AND PRINCIPAL >= {1}", dt.ToShortDateString, min)
        mySql &= vbCrLf & "	)"
        If type <> "ALL" Then
            mySql &= " WHERE ITEMTYPE = '" & type & "'"
        End If
        mySql &= vbCrLf & "ORDER BY PAWNTICKET ASC"

        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtMonthOf", "DATE: " & dt.ToString("MMMM dd yyyy").ToUpper)
        addParameters.Add("branchName", branchName)
        addParameters.Add("ReportName", "AUDIT REPORTS")

        frmReport.ReportInit(mySql, "dsOutstanding", "Reports\rpt_Outstanding.rdlc", addParameters)
        frmReport.Show()
    End Sub

End Module
