Imports Microsoft.Office.Interop

Public Class frmImport_IMD

    Dim ht_ImportedItems As New Hashtable
    Dim import_cnt As Integer = 0

    Private Sub ClearFields()
        ht_ImportedItems.Clear()
        lvIMD.Items.Clear()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdIMD.ShowDialog()

        Dim fileName As String = ofdIMD.FileName
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub
        lblFilename.Text = fileName
        ClearFields()

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(fileName)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        If Not TemplateIntegrityCheck(checkHeaders) Then
            AddTimelyLogs("IMPORT MASTER DATA", "Template was tampered", , False, "IMD Template has been modify", )
            MsgBox("Template was tampered", MsgBoxStyle.Critical)
            GoTo unloadObj
        End If

        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim ImportedItem As New cItemData
            With ImportedItem
                .ItemCode = oSheet.Cells(cnt, 1).Value
                .Load_ItemCode()

                .Description = oSheet.Cells(cnt, 2).Value
                .Barcode = oSheet.Cells(cnt, 3).Value
                .Category = oSheet.Cells(cnt, 4).Value
                .SubCategory = oSheet.Cells(cnt, 5).Value
                .UnitofMeasure = oSheet.Cells(cnt, 6).Value
                .UnitPrice = If(Not IsNumeric(oSheet.Cells(cnt, 7).Value), 0, oSheet.Cells(cnt, 7).Value)
                .SalePrice = If(Not IsNumeric(oSheet.Cells(cnt, 8).Value), 0, oSheet.Cells(cnt, 8).Value)
                If isYesNo(oSheet.Cells(cnt, 9).value) Then .isSaleable = IIf(YesNo(oSheet.Cells(cnt, 9).value) = "Y", 1, 0)
                If isYesNo(oSheet.Cells(cnt, 10).value) Then .isInventoriable = IIf(YesNo(oSheet.Cells(cnt, 10).value) = "Y", 1, 0)
                If isYesNo(oSheet.Cells(cnt, 11).value) Then .onHold = IIf(YesNo(oSheet.Cells(cnt, 11).value) = "Y", 1, 0)
                If isYesNo(oSheet.Cells(cnt, 12).value) Then .IsLayAway = IIf(YesNo(oSheet.Cells(cnt, 12).value) = "Y", 1, 0)
                .Discount = oSheet.Cells(cnt, 13).value

            End With

            AddItems(ImportedItem)
        Next
        Me.Enabled = True
        isDone = True


unloadObj:
        'Memory Unload
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        fileName = ""
        If isDone Then MsgBox("Item Loaded", MsgBoxStyle.Information)
    End Sub

    Private Sub AddItems(ByVal Item As cItemData)
        Dim lv As ListViewItem = lvIMD.Items.Add(Item.ItemCode)
        If Item.onHold Then
            lv.ForeColor = Color.White
            lv.BackColor = Color.Red
        End If

        lv.SubItems.Add(Item.Description)
        lv.SubItems.Add(Item.Barcode)
        lv.SubItems.Add(Item.Category)
        lv.SubItems.Add(Item.UnitofMeasure)
        lv.SubItems.Add(Item.UnitPrice.ToString("#,##0.00"))
        lv.SubItems.Add(Item.SalePrice.ToString("#,##0.00"))
        lv.SubItems.Add(If(Item.isSaleable, "Yes", "No"))
        lv.SubItems.Add(If(Item.isInventoriable, "Yes", "No"))
        lv.SubItems.Add(If(Item.onHold, "Yes", "No"))

        ht_ImportedItems.Add(import_cnt, Item)
        import_cnt += 1

        Console.WriteLine("Item No. " & import_cnt)
    End Sub

    Private Function isYesNo(ByVal str As String) As Boolean
        Dim acceptable() As String = {"Y", "N", "0", "1"}
        If acceptable.Contains(str.ToUpper) Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function YesNo(ByVal str As String) As String
        Dim ret As String

        Select Case str.ToUpper
            Case "1"
                ret = "Y"
            Case "0"
                ret = "N"
            Case Else
                ret = str.ToUpper
        End Select

        Return ret
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If lvIMD.Items.Count = 0 Then Exit Sub

        ' REMOVED due to redundancy on HOT CODE
        'If MsgBox("Do you want to imported everything?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information) = vbYesNo Then
        '    Exit Sub
        'End If

        ' Integrity Check
        Dim hash = InputBox("HOT CODE", "ENTER HOT CODE")
        If hash = "" Then Exit Sub
        If Not hash = security.GetFileMD5(lblFilename.Text) Then
            AddTimelyLogs("IMPORT MASTER DATA", "INVALID HOT CODE", , False, "HOT CODE: " & hash, )
            MsgBox("Invalid HOT CODE", MsgBoxStyle.Critical, "HOT CODE")
            Exit Sub
        End If

        Me.Enabled = False
        For Each ht As DictionaryEntry In ht_ImportedItems
            Dim itm As cItemData = ht.Value
            itm.Save_ItemData()
        Next
        Me.Enabled = True

        MsgBox("ItemData imported", MsgBoxStyle.Information)
        lvIMD.Items.Clear()
    End Sub

    Private Sub verification()
        If AccountRule.HasPrivilege("POS") = "Read Only" Then
            btnImport.Enabled = False
        End If
    End Sub

    Private Sub frmImport_IMD_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        verification()
    End Sub
End Class