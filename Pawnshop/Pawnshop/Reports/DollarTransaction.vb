Public Class DollarTransction
    Private mySql As String, fillData As String
    Enum ReportType As Integer
        DollarBuying = 0
    End Enum
    Friend FormType As ReportType = ReportType.DollarBuying

    Private Sub Generate()
        Select Case FormType
            Case ReportType.DollarBuying
                DollarBuying()
        End Select
    End Sub

    Private Sub DollarTransction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        mySql = "SELECT DISTINCT CURRENCY FROM TBLDOLLAR"
        fillData = "TBLDOLLAR"

        Dim ds As DataSet = LoadSQL(mySql)

        cbmCurrency.Items.Clear()
        cbmCurrency.Items.Add("CURRENCYLIST")
        For Each dr As DataRow In ds.Tables(0).Rows
            cbmCurrency.Items.Add(dr.Item("CURRENCY"))
        Next
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If cbmCurrency.Text = "CURRENCYLIST" And cbmCurrency.Visible Then Exit Sub
        If cboMonthlyDaily.Text = "" And cboMonthlyDaily.Visible Then Exit Sub

        If cbmCurrency.Text = cbmCurrency.Text And cboMonthlyDaily.Text = "Monthly" Then
            DollarBuying()
        Else
            DailyDollar()
        End If
    End Sub
    Private Sub DollarBuying()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "Dataset1"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("BranchName", branchName)
        rptPara.Add("CURRENCY", cbmCurrency.Text)
        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransaction.rdlc", rptPara)
        frmReport.Show()
    End Sub
    Private Sub DailyDollar()
        Dim fillData As String = "Dataset1"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE TRANSDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & monCal.SelectionStart.ToLongDateString)
        rptPara.Add("branchName", branchName)
        rptPara.Add("CURRENCY", cbmCurrency.Text)
        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransaction.dlc", rptPara)
        frmReport.Show()
    End Sub
End Class