Public Class qrySequence

    Private ReportType As String = ""
    Private mySql As String
    Private fillData As String

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If rbBorrowing.Checked Then ReportType = "Borrowings"
        If rbInsurance.Checked Then ReportType = "Insurance"
        If rbMT.Checked Then ReportType = "MoneyTransfer"
        If rbPawning.Checked Then ReportType = "Pawning"

        Select Case ReportType
            Case "Pawning"
                PawningReport()
            Case "MoneyTransfer"
                MoneyTransferReport()
        End Select
    End Sub

    Private Sub MoneyTransferReport()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)

        fillData = "dsMoneyTransfer"
        mySql = "SELECT * FROM MONEY_TRANSFER "
        mySql &= String.Format("WHERE TransDate BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " AND ServiceType = 'Pera Padala'"

        Dim rptDic As New Dictionary(Of String, String)
        rptDic.Add("branchName", branchName)
        rptDic.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year.ToString)

        frmReport.ReportInit(mySql, fillData, "Reports\sq_MoneyTransfer.rdlc", rptDic)
        frmReport.Show()
    End Sub

    Private Sub PawningReport()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)

        fillData = "dsPawn"
        mySql = "SELECT "
        mySql &= vbCrLf & "	P.LOANDATE, P.PAWNTICKET, P2.ORNUM, P2.ORDATE, P.NETAMOUNT, P2.RENEWDUE, P.REDEEMDUE, "
        mySql &= vbCrLf & "    CASE P.STATUS"
        mySql &= vbCrLf & "    	WHEN '0' THEN 'RENEW' "
        mySql &= vbCrLf & "        WHEN 'R' THEN 'RENEWED' "
        mySql &= vbCrLf & "        WHEN 'L' THEN 'NEW' "
        mySql &= vbCrLf & "        WHEN 'V' THEN 'VOID' "
        mySql &= vbCrLf & "        WHEN 'W' THEN 'WITHDRAW' "
        mySql &= vbCrLf & "        WHEN 'X' THEN 'REDEEM' "
        mySql &= vbCrLf & "        WHEN 'S' THEN 'SEGRE' "
        mySql &= vbCrLf & "        ELSE 'N/A' "
        mySql &= vbCrLf & "    END AS STATUS, "
        mySql &= vbCrLf & " C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT "
        mySql &= vbCrLf & "FROM TBLPAWN P "
        mySql &= vbCrLf & "	LEFT JOIN TBLPAWN P2"
        mySql &= vbCrLf & "    ON P2.PAWNTICKET = P.OLDTICKET "
        mySql &= vbCrLf & " INNER JOIN TBLCLIENT C ON C.CLIENTID = P.CLIENTID "
        mySql &= String.Format("WHERE P.LoanDate BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY P.LOANDATE ASC"

        Dim rptDic As New Dictionary(Of String, String)
        rptDic.Add("branchName", branchName)
        rptDic.Add("txtMonth", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year.ToString)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_pawning.rdlc", rptDic)
        frmReport.Show()
    End Sub
End Class