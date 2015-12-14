Public Class qryLoan

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        Dim fillData As String = "LOAN_REGISTER"
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE LoanDate BETWEEN '{0}' AND '{1}'", monCal.SelectionStart.ToShortDateString, monCal.SelectionEnd.ToShortDateString)

        Console.WriteLine(mySql)
        frmReport.ReportInit(mySql, fillData, "Reports\rpt_LoanRegister.rdlc")
        frmReport.Show()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
End Class