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
        mySql &= " AND ("

        Dim joinStr As New List(Of String)

        If chbType.GetItemChecked(1) Then joinStr.Add("Status = 'L'")
        If chbType.GetItemChecked(2) Then joinStr.Add("Status = 'R'")
        If chbType.GetItemChecked(3) Then joinStr.Add("Status = 'X'")

        mySql &= String.Join(" OR ", joinStr)

        mySql &= ")"

        Dim title As String = String.Format("{0} {1} {2}", IIf(chbType.GetItemChecked(1), "LOAN", ""), IIf(chbType.GetItemChecked(2), "RENEW", ""), IIf(chbType.GetItemChecked(3), "REDEEM", ""))
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

    Private Sub chbType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chbType.SelectedIndexChanged
        For cnt As Integer = 0 To chbType.Items.Count - 1
            If chbType.SelectedIndex = 0 Then
                chbType.SetItemChecked(cnt, chbType.GetItemChecked(0))
            End If
        Next
    End Sub

    Private Sub qryLoan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        chbType.SetItemChecked(1, 1)
    End Sub
End Class