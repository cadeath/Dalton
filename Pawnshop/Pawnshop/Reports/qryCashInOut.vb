Public Class qryCashInOut

    Friend FormType As FormTrans
    Enum FormTrans As Integer
        Daily = 0
        Monthly = 1
    End Enum

    Private Sub qryCashInOut_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        LoadCategories()
        'Disable_Functions()
    End Sub

    Private Sub Disable_Functions()
        chkIN.Enabled = False
        chkOUT.Enabled = False
        cboCategory.Enabled = False
     
    End Sub

    Private Sub LoadCategories()
        Dim mySql As String, ds As DataSet
        mySql = "SELECT DISTINCT CATEGORY FROM tblCash WHERE TYPE <> 'null' ORDER BY CATEGORY ASC"
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
        Select Case FormType
            Case FormTrans.Daily
                CashInOut_Daily()
            Case FormTrans.Monthly
                CashInOut_Monthly()
        End Select
    End Sub

    Private Sub CashInOut_Monthly()
        If Not (chkIN.Checked Or chkOUT.Checked Or chkOther.Checked) Then Exit Sub

        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)

        Dim mySql As String, dsName As String, rptPath As String = "Reports\rpt_CashInOutSummary.rdlc"
        dsName = "dsCIO"
        mySql = "SELECT * FROM TBLCASHTRANS"
        mySql &= String.Format(" WHERE TransDate BETWEEN '{0}' AND '{1}'", stDate.ToShortDateString, enDate.ToShortDateString)
        If (chkIN.Checked Or chkOUT.Checked Or chkOther.Checked) Then
            mySql &= TypeFilter2()
        End If

        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("branchName", branchName)
        addParameter.Add("txtMonthOf", "FOR THE MONTH OF " & monCal.SelectionStart.ToString("MMMM yyyy").ToUpper)

        frmReport.ReportInit(mySql, dsName, rptPath, addParameter)
        frmReport.Show()
    End Sub

    Private Sub CashInOut_Daily()
        If Not (chkIN.Checked Or chkOUT.Checked Or chkOther.Checked) Then Exit Sub

        Dim cur As Date = monCal.SelectionStart

        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsReports"
        rptPath = "Reports\rpt_CashInOut.rdlc"

        mySql = "SELECT * FROM TBLCASHTRANS "
        mySql &= String.Format(" WHERE TRANSDATE = '{0}'", cur.ToShortDateString)
        If (chkIN.Checked Or chkOUT.Checked Or chkOther.Checked) Then
            mySql &= TypeFilter2()
        End If

        Dim addPara As New Dictionary(Of String, String)
        addPara.Add("txtMonthOf", "AS OF " & cur.ToString("MMMM dd, yyyy"))
        addPara.Add("branchName", "ROX")

        frmReport.ReportInit(mySql, dsName, rptPath, addPara)
        frmReport.Show()
    End Sub

    Private Function TypeFilter() As String
        Dim receipt As String = "1", disburse As String = "1", Other As String, tmp As String
        If chkIN.Checked Then receipt = "TYPE = 'Receipt'"
        If chkOUT.Checked Then disburse = "TYPE = 'Disbursement'"
       
        tmp = "("
        tmp &= IIf(chkIN.Checked, receipt, "")
        If chkIN.Checked And chkOUT.Checked Then tmp &= " OR "
        tmp &= IIf(chkOUT.Checked, disburse, "")
        tmp &= ")"

        'tmp = "(" & String.Join(" OR ", receipt, disburse) & ")"
        If cboCategory.Text <> "-ALL-" Then
            tmp &= String.Format(" AND CATEGORY = '{0}'", cboCategory.Text)
        End If

        Return String.Format(" AND ({0})", tmp)

    End Function
    Private Function TypeFilter2() As String
        Dim receipt As String, disburse As String, Other As String, tmp As String
        If chkIN.Checked Then receipt = "TYPE = 'Receipt'"
        If chkOUT.Checked Then disburse = "TYPE = 'Disbursement'"
        If chkOther.Checked Then Other = "(TYPE <> 'Receipt' AND TYPE <> 'Disbursement')"

        Dim filterSQL(2) As String
        filterSQL(0) = receipt
        filterSQL(1) = disburse
        filterSQL(2) = Other

        Dim strFilter As String
        strFilter = String.Join(" OR ", filterSQL.Where(Function(s) Not String.IsNullOrEmpty(s)))

        tmp = "("
        tmp &= strFilter
        tmp &= ")"

        'tmp = "(" & String.Join(" OR ", receipt, disburse, Other) & ")"
        If cboCategory.Text <> "-ALL-" Then
            tmp &= String.Format(" AND CATEGORY = '{0}'", cboCategory.Text)
        End If

        Return String.Format(" AND ({0})", tmp)
    End Function

End Class