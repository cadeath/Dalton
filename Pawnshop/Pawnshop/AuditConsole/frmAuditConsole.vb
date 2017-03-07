Imports Microsoft.Office.Interop
Public Class frmAuditConsole

    Private MEMO_MINIMUM As Double = 5000
    Const INTEGRITY_CHECK As String = "tk8Gi7kcqIdbdWq8mdFv1wWG5XwYy98lrnLcjMltIjCKoPcEu9xqIQ=="
    Private ItemHT As New Hashtable
    Private ORNUM As Double = GetOption("InvoiceNum")

    Private Sub btnVault_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVault.Click
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

    Private Sub frmAuditConsole_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPrincipal.Text = MEMO_MINIMUM.ToString("0.00")
        Load_ItemType()

        OTP_Init()
    End Sub

    Private Sub OTP_Init()
        txtEmail.Text = ""
        txtQRURL.Text = ""
        txtManual.Text = ""
    End Sub

    Private Sub btnCashCount_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashCount.Click
        frmCashCountV2.isAuditing = True
        frmCashCountV2.Show()
    End Sub

    Private Sub btnCCSheet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCSheet.Click
        qryDate.FormType = qryDate.ReportType.DailyCashCount
        qryDate.isAuditing = True
        qryDate.Show()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If txtEmail.Text = "" Then Exit Sub
        If Not (txtEmail.Text.Contains("@") And txtEmail.Text.Contains(".")) Then Exit Sub

        AuditOTP.Setup(txtEmail.Text)
        txtManual.Text = AuditOTP.ManualCode
        txtQRURL.Text = AuditOTP.QRCode_URL
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        ItemHT.Clear()
        Inv_adjustment()
    End Sub

    Private Sub Inv_adjustment()
        If txtPath.Text = "" Then Exit Sub

        If MsgBox("Do you want to import this adjustments?", _
                    MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = vbYesNo Then
            Exit Sub
        End If

        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(txtPath.Text)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        If Not TemplateIntegrityCheck(checkHeaders) Then
            MsgBox("Template was tampered", MsgBoxStyle.Critical)
            GoTo unloadObj
        End If

        Me.Enabled = False

        For cnt = 2 To MaxEntries
            ItemHT.Add(oSheet.Cells(cnt, 2).Value, oSheet.Cells(cnt, 4).Value)
            If Not CheckItemCode(oSheet.Cells(cnt, 2).Value) Then MsgBox("No ItemCode " & oSheet.Cells(cnt, 2).Value & " Found!", MsgBoxStyle.Critical, "Please Check ItemCode") : Exit Sub
        Next

        If chkZeroOut.Checked = True Then

            Dim mySql As String = "SELECT * FROM DOC ROWS 1"
            Dim fillData As String = "DOC"

            Dim ds As DataSet = LoadSQL(mySql, fillData)
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow

            With dsNewRow
                .Item("DOCTYPE") = 4
                .Item("CODE") = String.Format("{1}#{0:000000}", ORNUM, "STO")
                .Item("MOP") = "S"
                .Item("CUSTOMER") = "01"
                .Item("DOCDATE") = CurrentDate
                .Item("USERID") = POSuser.UserID
                .Item("REMARKS") = "Adjust"
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            Dim DOCID As Integer = 0
            mySql = "SELECT * FROM DOC ORDER BY DOCID DESC ROWS 1"
            ds = LoadSQL(mySql, fillData)
            DOCID = ds.Tables(fillData).Rows(0).Item("DOCID")

            Dim onHand As Double = 0

            For cnt = 2 To MaxEntries
                mySql = "Select * From ItemMaster Where ItemCode = '" & oSheet.Cells(cnt, 2).Value & "'"
                ds = LoadSQL(mySql, "ItemMaster")
                onHand = ds.Tables(0).Rows(0).Item("ONHAND")

                mySql = "SELECT * FROM DOCLINES ROWS 1"
                fillData = "DOCLINES"
                ds = LoadSQL(mySql, fillData)
                dsNewRow = ds.Tables(fillData).NewRow
                With dsNewRow
                    .Item("DOCID") = DOCID
                    .Item("ITEMCODE") = oSheet.Cells(cnt, 2).Value
                    .Item("DESCRIPTION") = oSheet.Cells(cnt, 3).Value
                    .Item("QTY") = onHand
                End With
                ds.Tables(fillData).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
                InventoryController.DeductInventory(oSheet.Cells(cnt, 2).Value, onHand)
            Next

            mySql = "SELECT * FROM INV ROWS 1"
            ds = LoadSQL(mySql, "INV")
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("DOCNUM") = CurrentDate.ToString("ddMMyyyy") 'Date number
                .Item("DOCDATE") = CurrentDate
                .Item("PARTNER") = "HEAD OFFICE"
                .Item("REFNUM") = CurrentDate.ToString("ddMMyyyy")
            End With
            ds.Tables("INV").Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            mySql = "SELECT * FROM INV ORDER BY DOCID DESC ROWS 1"
            ds = LoadSQL(mySql)
            DOCID = ds.Tables(0).Rows(0).Item("DOCID")

            For cnt = 2 To MaxEntries
                ' Add Document Lines
                mySql = "SELECT * FROM INVLINES ROWS 1"
                ds = LoadSQL(mySql, "INVLINES")
                dsNewRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("DOCID") = DOCID
                    .Item("ITEMCODE") = oSheet.Cells(cnt, 2).Value
                    .Item("DESCRIPTION") = oSheet.Cells(cnt, 3).Value
                    .Item("QTY") = oSheet.Cells(cnt, 4).Value
                    .Item("REMARKS") = "UPLOADED DATED " & CurrentDate
                End With
                ds.Tables("INVLINES").Rows.Add(dsNewRow)
                database.SaveEntry(ds)

                AddInventory(oSheet.Cells(cnt, 2).Value, oSheet.Cells(cnt, 4).Value)
            Next
        Else
            Dim mysql As String
            Dim ds As DataSet
            Dim dsNewRow As DataRow
            Dim DOCID As Integer
            mySql = "SELECT * FROM INV ROWS 1"
            ds = LoadSQL(mySql, "INV")
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("DOCNUM") = CurrentDate.ToString("ddMMyyyy") 'Date number
                .Item("DOCDATE") = CurrentDate
                .Item("PARTNER") = "HEAD OFFICE"
                .Item("REFNUM") = CurrentDate.ToString("ddMMyyyy")
            End With
            ds.Tables("INV").Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            mySql = "SELECT * FROM INV ORDER BY DOCID DESC ROWS 1"
            ds = LoadSQL(mySql)
            DOCID = ds.Tables(0).Rows(0).Item("DOCID")

            For cnt = 2 To MaxEntries
                ' Add Document Lines
                mySql = "SELECT * FROM INVLINES ROWS 1"
                ds = LoadSQL(mySql, "INVLINES")
                dsNewRow = ds.Tables(0).NewRow
                With dsNewRow
                    .Item("DOCID") = DOCID
                    .Item("ITEMCODE") = oSheet.Cells(cnt, 2).Value
                    .Item("DESCRIPTION") = oSheet.Cells(cnt, 3).Value
                    .Item("QTY") = oSheet.Cells(cnt, 4).Value
                    .Item("REMARKS") = "UPLOADED DATED " & CurrentDate
                End With
                ds.Tables("INVLINES").Rows.Add(dsNewRow)
                database.SaveEntry(ds)

                AddInventory(oSheet.Cells(cnt, 2).Value, oSheet.Cells(cnt, 4).Value)
            Next

        End If


        Me.Enabled = True

        txtPath.Text = ""

        MsgBox("Adjustments successfully imported.", MsgBoxStyle.Information, "Adjustment")

unloadObj:
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdINV_AD.ShowDialog()

        txtPath.Text = ofdINV_AD.FileName
    End Sub

    Friend Function TemplateIntegrityCheck(ByVal headers() As String) As Boolean
        Dim mergeHeaders As String = ""
        For Each head In headers
            mergeHeaders &= head
        Next

        Console.WriteLine("Header Check " & HashString(mergeHeaders))

        If HashString(mergeHeaders) = INTEGRITY_CHECK Then
            Return True
        End If

        Return False
    End Function

    Private Function CheckItemCode(ByVal itemCode As String) As Boolean
        Dim mysql As String = "SELECT * FROM ITEMMASTER WHERE ITEMCODE = '" & itemCode & "'"
        Dim ds As DataSet = LoadSQL(mysql, "ITEMMASTER")

        If ds.Tables(0).Rows.Count = 0 Then
            Return False
        End If
        Return True
    End Function
End Class