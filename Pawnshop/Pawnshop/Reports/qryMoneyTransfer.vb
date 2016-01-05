Public Class qryMoneyTransfer

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If Not isValid() Then Exit Sub

        Dim reportType As String = ""
        If rbCebuana.Checked Then reportType = "Cebuana Llhuiller"
        If rbPeraPadala.Checked Then reportType = "Pera Padala"
        If rbWestern.Checked Then reportType = "Western Union"

        Dim fillData As String, mySql As String
        fillData = "MONEY_TRANSFER"
        mySql = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE TransDate BETWEEN '{0}' AND '{1}' ", _
                               GetFirstDate(monCal.SelectionRange.Start).ToShortDateString, _
                               GetLastDate(monCal.SelectionRange.End).ToShortDateString)
        mySql &= String.Format("AND ServiceType = '{0}' ", reportType)

        Console.WriteLine(mySql)

        'Parameters
        Dim rptPara As New Dictionary(Of String, String)
        rptPara.Add("txtMonth", "FOR THE MONTH OF " & monCal.SelectionRange.Start.ToString("MMMM").ToUpper & " " & monCal.SelectionRange.Start.ToString("yyyy"))
        rptPara.Add("branchName", branchName)

        frmReport.ReportInit(mySql, "dsMoneyTransfer", "Reports/rpt_moneyTransfer.rdlc", rptPara)
        frmReport.Show()
    End Sub

    Private Function isValid() As Boolean

        Return True
    End Function


    Private Sub qryMoneyTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        CheckNoUncheck()
    End Sub

    Private Sub CheckNoUncheck()
        If chkPay.Checked Then Exit Sub
        If chkSend.Checked Then Exit Sub

        chkPay.Checked = True
    End Sub

    Private Sub chkPay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkPay.CheckedChanged
        CheckNoUncheck()
    End Sub

    Private Sub chkSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSend.CheckedChanged
        CheckNoUncheck()
    End Sub

    Private Function GetFirstDate(ByVal curDate As Date) As Date
        Dim firstDay = DateSerial(curDate.Year, curDate.Month, 1)
        Return firstDay
    End Function

    Private Function GetLastDate(ByVal curDate As Date) As Date
        Dim original As DateTime = curDate  ' The date you want to get the last day of the month for
        Dim lastOfMonth As DateTime = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1)

        Return lastOfMonth
    End Function
End Class