Public Class qryCashInOut

    Private Sub qryCashInOut_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
        Disable_Functions()
    End Sub

    Private Sub Disable_Functions()
        chkIN.Enabled = False
        chkOUT.Enabled = False
        cboCategory.Enabled = False
    End Sub

    Private Sub LoadCategories()
        Dim mySql As String, ds As DataSet
        mySql = "SELECT DISTINCT Category FROM tblCash WHERE TYPE <> '' ORDER BY Category ASC"
        ds = LoadSQL(mySql)
        Console.WriteLine(mySql)

        cboCategory.Items.Clear()
        cboCategory.Items.Add("-ALL-")
        For Each dr As DataRow In ds.Tables(0).Rows
            cboCategory.Items.Add(dr.Item("CATEGORY"))
        Next

        cboCategory.SelectedIndex = 0
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If Not (chkIN.Checked Or chkOUT.Checked) Then Exit Sub

        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)

        Dim mySql As String, dsName As String, rptPath As String = "Reports\rpt_CashInOutSummary.rdlc"
        dsName = "dsCIO"
        mySql = "SELECT * FROM TBLCASHTRANS"
        mySql &= String.Format(" WHERE TransDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)

        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("branchName", branchName)
        addParameter.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)

        frmReport.ReportInit(mySql, dsName, rptPath, addParameter)
        frmReport.Show()
    End Sub
End Class