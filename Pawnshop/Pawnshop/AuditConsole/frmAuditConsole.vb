Public Class frmAuditConsole

    Private MEMO_MINIMUM As Double = 5000

    Private Sub btnVault_Click(sender As System.Object, e As System.EventArgs) Handles btnVault.Click
        Dim AMOUNT_MIN As Double
        AMOUNT_MIN = CDbl(txtPrincipal.Text)

        AuditReports.Min_Principal(AMOUNT_MIN, MonVault.SelectionRange.Start.ToShortDateString, cboType.Text)
    End Sub

    Private Sub Load_ItemType()
        Dim mySql As String = "SELECT DISTINCT ITEMCATEGORY FROM tblItem ORDER BY ITEMCATEGORY ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        cboType.Items.Clear()
        cboType.Items.Add("ALL")
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr("ITEMCATEGORY"))
        Next

        cboType.SelectedIndex = 0
    End Sub

    Private Sub frmAuditConsole_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        txtPrincipal.Text = MEMO_MINIMUM.ToString("0.00")
        Load_ItemType()

        OTP_Init()
    End Sub

    Private Sub OTP_Init()
        txtEmail.Text = ""
        txtQRURL.Text = ""
        txtManual.Text = ""
    End Sub

    Private Sub btnCashCount_Click_1(sender As System.Object, e As System.EventArgs) Handles btnCashCount.Click
        frmCashCountV2.isAuditing = True
        frmCashCountV2.Show()
    End Sub

    Private Sub btnCCSheet_Click(sender As System.Object, e As System.EventArgs) Handles btnCCSheet.Click
        qryDate.FormType = qryDate.ReportType.DailyCashCount
        qryDate.isAuditing = True
        qryDate.Show()
    End Sub

    Private Sub btnGenerate_Click(sender As System.Object, e As System.EventArgs) Handles btnGenerate.Click
        If txtEmail.Text = "" Then Exit Sub
        If Not (txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".")) Then Exit Sub

        AuditOTP.Setup(txtEmail.Text)
        txtManual.Text = AuditOTP.ManualCode
        txtQRURL.Text = AuditOTP.QRCode_URL
    End Sub
End Class