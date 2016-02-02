Public Class qryLoan

    Private branchName As String = GetOption("BranchName")

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim isValid As Boolean = False
        For cnt = 0 To chbType.Items.Count - 1
            If chbType.GetItemChecked(cnt) Then
                isValid = True
                Exit For
            End If
        Next

        If Not isValid Then Exit Sub

        GenReport()
    End Sub

    Private Sub GenReport()
        Dim fillData As String = "LOAN_REGISTER"
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE LoanDate BETWEEN '{0}' AND '{1}'", monCal.SelectionStart.ToShortDateString, monCal.SelectionEnd.ToShortDateString)
        mySql &= " AND "

        mySql &= StatusParser()

        Dim title As String = String.Format("{0} {1} {2}", IIf(chbType.GetItemChecked(0), "LOAN", ""), IIf(chbType.GetItemChecked(1), "RENEW", ""), IIf(chbType.GetItemChecked(2), "REDEEM", ""))
        Dim loanPeriod As String = String.Format("{0} TO {1}", monCal.SelectionStart.ToShortDateString, monCal.SelectionEnd.ToShortDateString)
        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("Title", title)
        rptPara.Add("loanPeriod", loanPeriod)
        rptPara.Add("BranchName", branchName)

        Console.WriteLine(mySql)
        frmReport.ReportInit(mySql, fillData, "Reports\rpt_LoanRegister.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function StatusParser() As String
        Dim newLoan As Boolean, renew As Boolean, redeem As Boolean
        newLoan = chbType.GetItemChecked(0)
        renew = chbType.GetItemChecked(1)
        redeem = chbType.GetItemChecked(2)

        Dim tmpStr As String, tmpList As New List(Of String)
        tmpStr = "("


        If newLoan Then tmpList.Add("STATUS = 'L'")
        If renew Then tmpList.Add("STATUS = 'R'")
        If redeem Then tmpList.Add("STATUS = 'X'")

        tmpStr &= String.Join(" AND ", tmpList)

        tmpStr &= ")"

        Return tmpStr
    End Function
End Class