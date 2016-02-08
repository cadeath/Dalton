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
        mySql = "SELECT * FROM PAWNING "
        mySql &= String.Format("WHERE LoanDate BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY LOANDATE ASC"

        Dim rptDic As New Dictionary(Of String, String)
        rptDic.Add("branchName", branchName)
        rptDic.Add("txtMonth", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year.ToString)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_pawning.rdlc", rptDic)
        frmReport.Show()
    End Sub
End Class