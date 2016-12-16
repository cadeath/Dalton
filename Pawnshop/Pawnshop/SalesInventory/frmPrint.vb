Imports Microsoft.Reporting.WinForms

Public Class frmPrint
    Private PRINTER_Sales As String = GetOption("PrinterPT")

    Private Sub LoadReceipt()
        Dim mySql As String = "SELECT FIRST 50 * FROM DOC ORDER BY DOCDate DESC"

        Dim ds As DataSet = LoadSQL(mySql)
        lvReceipt.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvReceipt.Items.Add(dr.Item("Code"))
            lv.SubItems.Add(dr.Item("Customer"))
            lv.SubItems.Add(dr.Item("DocDate"))
            lv.Tag = dr.Item("DocID")
        Next
    End Sub
    Private Sub frmPrint_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadReceipt()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim mySql As String = "SELECT * FROM DOC WHERE CODE LIKE '" & secured_str & "' OR UPPER(CUSTOMER) LIKE UPPER('%" & secured_str & "%')"

        Dim ds As DataSet = LoadSQL(mySql)
        lvReceipt.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim lv As ListViewItem = lvReceipt.Items.Add(dr.Item("Code"))
            lv.SubItems.Add(dr.Item("Customer"))
            lv.SubItems.Add(dr.Item("DocDate"))
            lv.Tag = dr.Item("DocID")
        Next
        MsgBox(ds.Tables(0).Rows.Count & " found!", MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub btnReprint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReprint.Click
        If lvReceipt.SelectedItems.Count <= 0 Then Exit Sub
        Dim idx As Integer = CInt(lvReceipt.FocusedItem.Tag)

        Dim ans As DialogResult = _
           MsgBox("Do you want to print?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "Print")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim autoPrintPT As Reporting
        'On Error Resume Next

        Dim printerName As String = PRINTER_Sales
        If Not canPrint(printerName) Then Exit Sub

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String, dsName As String = "dsReceipt"
        mySql = "SELECT D.*, DL.ITEMCODE, DL.DESCRIPTION, DL.QTY, DL.UNITPRICE, DL.SALEPRICE "
        mySql &= "FROM DOC D "
        mySql &= "INNER JOIN DOCLINES DL ON DL.DOCID = D.DOCID "
        mySql &= "WHERE D.DOCID = '" & idx & "'"
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        report.ReportPath = "Reports\rptReceipt.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("branchName", branchName)
        addParameters.Add("txtUsername", POSuser.UserName)

        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        If DEV_MODE Then
            frmReport.ReportInit(mySql, dsName, report.ReportPath, addParameters, False)
            frmReport.Show()
        Else
            autoPrintPT.Export(report)
            autoPrintPT.m_currentPageIndex = 0
            autoPrintPT.Print(printerName)
        End If

        Me.Focus()
    End Sub

    Private Function canPrint(ByVal printerName As String) As Boolean
        Try
            Dim printDocument As Drawing.Printing.PrintDocument = New Drawing.Printing.PrintDocument
            printDocument.PrinterSettings.PrinterName = printerName
            Return printDocument.PrinterSettings.IsValid
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvReceipt_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvReceipt.DoubleClick
        btnReprint.PerformClick()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.VoidSales
            If Not CheckOTP() Then Exit Sub
        Else
            Void()
        End If
    End Sub

    Friend Sub Void()
        Dim ans As DialogResult = MsgBox("Do you want to void this transaction? Sure Ba", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub
        Dim idx As String = lvReceipt.FocusedItem.Tag
        Dim mysql As String = "SELECT * FROM DOC WHERE DOCID = '" & idx & "'"
        Dim ds As DataSet = LoadSQL(mysql)
        Dim DocDate As Date = ds.Tables(0).Rows(0).Item("DOCDATE")
        If DocDate <> CurrentDate.Date Then
            MsgBox("You cannot void transaction in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim strDocID As String = ds.Tables(0).Rows(0).Item("DOCID")
        Dim InsuranceID As Integer
        Dim TransactionName As String = "Sales"
        InsuranceID = frmInsurance.lbltransid.Text

        ds.Tables(0).Rows(0).Item("STATUS") = "V"
        database.SaveEntry(ds, False)

        Dim NewOtp As New ClassOtp("VOID SALES", diagOTP.txtPIN.Text, strDocID)
        TransactionVoidSave(TransactionName, ds.Tables(0).Rows(0).Item("USERID"), POSuser.UserID, strDocID)
        RemoveJournal(strDocID, , TransactionName)
        RemoveDailyTimeLog(strDocID, "1", TransactionName)

        MsgBox("Transaction VOIDED", MsgBoxStyle.Information)
        Me.Close()
    End Sub


End Class