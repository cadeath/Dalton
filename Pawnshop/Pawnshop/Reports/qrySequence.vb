Public Class qrySequence

    Private ReportType As String = ""

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If rbBorrowing.Checked Then ReportType = "Borrowings"
        If rbInsurance.Checked Then ReportType = "Insurance"
        If rbMT.Checked Then ReportType = "MoneyTransfer"
        If rbPawning.Checked Then ReportType = "Pawning"

        Select Case ReportType
            Case "Pawning"
                PawningReport()
        End Select
    End Sub

    Private Sub PawningReport()
        Dim mySql As String, fillData As String = "dsPawn"
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)

        mySql = "SELECT * FROM PAWNING "
        mySql &= String.Format("WHERE LoanDate BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY LOANDATE ASC"

        Dim rptDic As New Dictionary(Of String, String)
        rptDic.Add("branchName", branchName)
        rptDic.Add("txtMonth", "FOR THE MONTH OF " & stDay.Month.ToString("MMMM").ToUpper & " " & stDay.Year.ToString)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_pawning.rdlc", rptDic)
        frmReport.Show()
    End Sub
End Class