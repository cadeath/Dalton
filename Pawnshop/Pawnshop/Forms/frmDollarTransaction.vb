Public Class DollarTransction
    Private mySql As String, fillData As String
    Private Daily As String = "Daily"
    Enum ReportType As Integer
        DollarBuying = 0
        DailyDollar = 1
        DollarMonthlyAllTransaction = 2
        DollarDailyAllTransaction = 3
    End Enum
    Friend FormType As ReportType = ReportType.DollarBuying

    Private Sub Generate()
        Select Case FormType
            Case ReportType.DollarBuying
                DollarBuying()
            Case ReportType.DailyDollar
                DailyDollar()
            Case ReportType.DollarMonthlyAllTransaction
                DollarMonthlyAllTransaction()
            Case ReportType.DollarDailyAllTransaction
                DollarDailyAllTransaction()
            Case ReportType.DollarBuying
                DollarBuying()
         
        End Select
    End Sub
    Private Sub DollarTransction_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        cbmCurrency.Focus()
        mySql = "SELECT DISTINCT CURRENCY FROM TBLDOLLAR"
        fillData = "TBLDOLLAR"

        Dim ds As DataSet = LoadSQL(mySql)

        cbmCurrency.Items.Clear()
        cbmCurrency.Items.Add("ALL")
        For Each dr As DataRow In ds.Tables(0).Rows
            cbmCurrency.Items.Add(dr.Item("CURRENCY"))
        Next
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If cbmCurrency.Text = cbmCurrency.Text And cboMonthlyDaily.Text = "Monthly" Then
            DollarBuying()
        ElseIf cbmCurrency.Text = cbmCurrency.Text And cboMonthlyDaily.Text = "Daily" Then
            DailyDollar()
        ElseIf cbmCurrency.Text = "ALL" Then
            DollarMonthlyAllTransaction()
        Else
            DollarDailyAllTransaction()
        End If
    End Sub
    Private Sub DollarBuying()

        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsDollar"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE CURRENCY= '" & cbmCurrency.Text & "' AND TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("BranchName", "BUla-Road")
        rptPara.Add("txtUsername", "Blade")
        rptPara.Add("CURRENCY", "Currency Name:  " & cbmCurrency.Text)
        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransaction.rdlc", rptPara)
        frmReport.Show()
    End Sub
    Private Sub DailyDollar()
        Dim fillData As String = "dsDollar"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE CURRENCY= '" & cbmCurrency.Text & "' AND TRANSDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "Date: " & monCal.SelectionStart.ToLongDateString)
        rptPara.Add("BranchName", "Bula-Road")
        rptPara.Add("txtUsername", "Blade")
        rptPara.Add("CURRENCY", "Currency Name:  " & cbmCurrency.Text)
        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransaction.rdlc", rptPara)
        frmReport.Show()
    End Sub
    Private Sub DollarMonthlyAllTransaction()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsDollartransAllCurrency"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE  TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("txtBranchName", "Bula-Road")
        rptPara.Add("txtUsername", "Blade")
        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransactionAllCurrency.rdlc", rptPara)
        frmReport.Show()
    End Sub
    Private Sub DollarDailyAllTransaction()
        Dim stDay = GetFirstDate(monCal.SelectionStart)
        Dim laDay = GetLastDate(monCal.SelectionEnd)
        Dim fillData As String = "dsDollartransAllCurrency"
        Dim mySql As String = "SELECT * FROM tblDollar"
        mySql &= String.Format(" WHERE TRANSDATE = '{0}'", monCal.SelectionStart.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"

        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonthOf", "FOR THE MONTH OF " & stDay.ToString("MMMM").ToUpper & " " & stDay.Year)
        rptPara.Add("txtBranchName", "Bula-Road")
        rptPara.Add("txtUsername", "Blade")
        frmReport.ReportInit(mySql, fillData, "Reports\rptDollarTransactionAllCurrency.rdlc", rptPara)
        frmReport.Show()
    End Sub
    Private Sub cbmCurrency_KeyDown(sender As System.Object, e As System.Windows.Forms.KeyEventArgs) Handles cbmCurrency.KeyDown
        If e.KeyCode = Keys.Enter Then
            cboMonthlyDaily.Focus()
        End If
    End Sub


    Private Sub cbmCurrency_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cbmCurrency.SelectedIndexChanged
        'If cbmCurrency.Text = "ALL" Then
        '    DollarMonthlyAllTransaction()
        'Else
        '    DollarDailyAllTransaction()
        'End If
    End Sub
End Class