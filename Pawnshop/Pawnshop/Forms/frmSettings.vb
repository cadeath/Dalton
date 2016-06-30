Public Class frmSettings
    Private locked As Boolean = IIf(GetOption("LOCKED") = "YES", True, False)
    Private Sub frmSettings_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lblSAP01.Text = "SAP Code 01"
        ClearFields()
        PrinterSettings()
    End Sub

    Private Sub PrinterSettings()
        printerPT.Items.Clear()
        printerOR.Items.Clear()

        Dim tmpPrinterName As String
        For Each tmpPrinterName In Printing.PrinterSettings.InstalledPrinters
            printerOR.Items.Add(tmpPrinterName)
            printerPT.Items.Add(tmpPrinterName)
        Next

        printerPT.Text = GetOption("PrinterPT")
        printerOR.Text = GetOption("PrinterOR")
    End Sub

    Private Sub ClearFields()
        locked = IIf(GetOption("LOCKED") = "YES", True, False)
        'First
        txtCode.Text = GetOption("BranchCode")
        txtName.Text = GetOption("BranchName")
        txtArea.Text = GetOption("BranchArea")
        txtBal.Text = GetOption("MaintainingBalance")
        txtRevolving.Text = GetOption("RevolvingFund")
        txtCashInBank.Text = GetSAPAccount("Cash in Bank")

        If locked Then
            txtCode.Enabled = False
            txtName.Enabled = False
            txtArea.Enabled = False
            txtRevolving.Enabled = False
        End If

        'Second
        txtPawnTicket.Text = GetOption("PawnLastNum")
        txtOR.Text = GetOption("ORLastNum")
        txtBorrow.Text = GetOption("BorrowingLastNum")
        txtInsurance.Text = GetOption("InsuranceLastNum")
        txtMENum.Text = GetOption("MEnumLast")
        txtMRNum.Text = GetOption("MRNumLast")
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub InsertSAPCount(ByVal SAPCode As String)
        Dim mySql As String = "SELECT * FROM tblCash WHERE TRANSNAME = 'Revolving Fund'"
        Dim fillData As String = "tblCash"
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(0).Rows(0).Item("SAPACCOUNT") = SAPCode
        database.SaveEntry(ds, False)

        Console.WriteLine("Revolving Fund Added")
    End Sub
    Private Function CheckOTP() As Boolean
        diagOTP.Show()
        diagOTP.TopMost = True
        Return False
        Return True
    End Function
    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not CheckOTP() Then Exit Sub
    End Sub
    Friend Sub UpdateSetting()
        'First
        If Not locked Then
            UpdateOptions("BranchCode", txtCode.Text)
            UpdateOptions("BranchName", txtName.Text)
            UpdateOptions("BranchArea", txtArea.Text)
            UpdateOptions("RevolvingFund", txtRevolving.Text)
            UpdateOptions("LOCKED", "YES")
            InsertSAPCount(txtRevolving.Text)

            BranchCode = txtCode.Text
            branchName = txtName.Text
        End If
        UpdateOptions("MaintainingBalance", txtBal.Text)
        MaintainBal = txtBal.Text
        UpdateSAPAccount("Cash in Bank", txtCashInBank.Text)

        'Second
        UpdateOptions("PawnLastNum", txtPawnTicket.Text)
        UpdateOptions("ORLastNum", txtOR.Text)
        UpdateOptions("BorrowingLastNum", txtBorrow.Text)
        UpdateOptions("InsuranceLastNum", txtInsurance.Text)
        UpdateOptions("MEnumLast", txtMENum.Text)
        UpdateOptions("MRNumLast", txtMRNum.Text)

        'Third
        UpdateOptions("PrinterPT", printerPT.Text)
        UpdateOptions("PrinterOR", printerOR.Text)

        If Not locked Then
            MsgBox("New Branch has been setup", MsgBoxStyle.Information)
        Else
            MsgBox("Setup updated", MsgBoxStyle.Information)
        End If
        Me.Close()
    End Sub
    Private Sub UpdateDaily()
        Dim fillData As String = "tblDaily"
        Dim mySql As String = "SELECT * FROM tblDaily WHERE ID = " & dailyID
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        ds.Tables(fillData).Rows(0).Item("MaintainBal") = txtBal.Text
        SaveEntry(ds, False)
    End Sub
    Private Sub txtBal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBal.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtOR_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub txtBorrow_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub txtInsurance_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub


End Class