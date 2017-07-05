Imports Microsoft.Office.Interop
Public Class frmAuditConsole

    Private MEMO_MINIMUM As Double = 5000
    Const INTEGRITY_CHECK As String = "tk8Gi7kcqIdbdWq8mdFv1wWG5XwYy98lrnLcjMltIjBjURKuzj/j5maX2T5tuE6g"
    Private STONum As Double = GetOption("STONum")

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

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        btnImport.Enabled = False
        Inv_adjustment()
        btnImport.Enabled = True
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

        Dim RefNum As Integer
        For cnt = 2 To MaxEntries
            RefNum = oSheet.Cells(cnt, 5).Value
            If Not CheckSTO(RefNum) Then MsgBox("Please Check STO", MsgBoxStyle.Critical, "Error") : Exit Sub
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
                .Item("CODE") = String.Format("{1}#{0:000000}", STONum, "STO")
                .Item("MOP") = "S"
                .Item("CUSTOMER") = "01"
                .Item("DOCDATE") = CurrentDate
                .Item("USERID") = SystemUser.ID
                .Item("REMARKS") = "Adjust"
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            Dim DOCID As Integer = 0
            mySql = "SELECT * FROM DOC ORDER BY DOCID DESC ROWS 1"
            ds = LoadSQL(mySql, fillData)
            DOCID = ds.Tables(fillData).Rows(0).Item("DOCID")

            mySql = "SELECT * FROM ITEMMASTER"
            ds = LoadSQL(mySql, "ITEMMASTER")

            For Each dr As DataRow In ds.Tables(0).Rows
                mySql = "SELECT * FROM DOCLINES "
                ds = LoadSQL(mySql, "DOCLINES")
                dsNewRow = ds.Tables("DOCLINES").NewRow
                With dsNewRow
                    .Item("DOCID") = DOCID
                    .Item("ITEMCODE") = dr.Item("ItemCode")
                    .Item("DESCRIPTION") = dr.Item("Description")
                    .Item("QTY") = dr.Item("OnHand")
                End With
                ds.Tables("DOCLINES").Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            Next

            Dim sqlUpdate As String = "UPDATE ITEMMASTER SET ONHAND = 0"
            RunCommand(sqlUpdate)


            mySql = "SELECT * FROM INV ROWS 1"
            ds = LoadSQL(mySql, "INV")
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("DOCNUM") = RefNum
                .Item("DOCDATE") = CurrentDate
                .Item("PARTNER") = "HEAD OFFICE"
                .Item("REFNUM") = RefNum
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
            STONum += 1
            UpdateOptions("STONum", STONum)
        Else
            Dim mysql As String
            Dim ds As DataSet
            Dim dsNewRow As DataRow
            Dim DOCID As Integer
            mysql = "SELECT * FROM INV ROWS 1"
            ds = LoadSQL(mysql, "INV")
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("DOCNUM") = RefNum
                .Item("DOCDATE") = CurrentDate
                .Item("PARTNER") = "HEAD OFFICE"
                .Item("REFNUM") = RefNum
            End With
            ds.Tables("INV").Rows.Add(dsNewRow)
            database.SaveEntry(ds)

            mysql = "SELECT * FROM INV ORDER BY DOCID DESC ROWS 1"
            ds = LoadSQL(mysql)
            DOCID = ds.Tables(0).Rows(0).Item("DOCID")

            For cnt = 2 To MaxEntries
                ' Add Document Lines
                mysql = "SELECT * FROM INVLINES ROWS 1"
                ds = LoadSQL(mysql, "INVLINES")
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

    Private Function CheckSTO(ByVal DocNum As Integer) As Boolean
        Dim mysql As String = "Select * From Inv Where DocNum = '" & DocNum & "'"
        Dim fillData As String = "Inv"
        Dim ds As DataSet = LoadSQL(mysql, fillData)

        If ds.Tables(0).Rows.Count >= 1 Then Return False
        Return True
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim mysql As String = "Select DL.ItemCode, DL.Description, DL.SalePrice, DL.Qty, D.DocDate, D.Remarks, D.Code "
        mysql &= "From Doclines DL "
        mysql &= "Inner Join Doc D on D.DocID = DL.DocID "
        mysql &= "Where Upper(DL.ItemCode) = Upper('" & txtSearch.Text & "') OR Upper(D.Code) like Upper('%" & txtSearch.Text & "%')"
        Dim ds As DataSet = LoadSQL(mysql)

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("No " & txtSearch.Text & " Found!", MsgBoxStyle.Critical, "Error") : Exit Sub
        For Each dr In ds.Tables(0).Rows
            AddItem(dr)
        Next
    End Sub

    Private Sub AddItem(ByVal dr As DataRow)
        lvItem.Items.Clear()
        Dim lv As ListViewItem = lvItem.Items.Add(dr.Item("ItemCode"))

        lv.SubItems.Add(dr.Item("Description"))
        lv.SubItems.Add(dr.Item("DocDate"))
        lv.SubItems.Add(dr.Item("SalePrice"))
        lv.SubItems.Add(dr.Item("Qty"))
        lv.SubItems.Add(dr.Item("Code"))
        If Not IsDBNull(dr.Item("Remarks")) Then lv.SubItems.Add(dr.Item("Remarks"))
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class