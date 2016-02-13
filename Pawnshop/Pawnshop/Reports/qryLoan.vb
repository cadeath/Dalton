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
        mySql = "SELECT * FROM PAWNING WHERE "
        mySql &= String.Format("LoanDate = '{0}' AND (STATUS = 'NEW' OR STATUS = 'RENEW')", monCal.SelectionStart.ToString("MM/dd/yyyy"))

        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)

        frmReport.ReportInit(mySql, fillData, "Reports\rpt_RegisterNewLoan.rdlc", addParameter)
        frmReport.Show()
    End Sub

    Private Sub Generate_Redemption()
        Dim fillData As String = "dsPawning", mySql As String
        mySql = "SELECT * FROM PAWNING WHERE "
        mySql &= String.Format("ORDate = '{0}' AND STATUS = 'REDEEM'", monCal.SelectionStart.ToString("MM/dd/yyyy"))

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