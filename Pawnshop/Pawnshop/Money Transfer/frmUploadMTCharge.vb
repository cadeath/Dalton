Imports Microsoft.Office.Interop
Public Class frmUploadMTCharge
    Const INTEGRITY_CHECK As String = "SwKuUDj3dsORDPF45AuT8xxmf/JPU4GcMIDDncv6iYs9a7eK5E2zbvO8obGKIVgNDbKi9DXV0ncqlXOoeXpgo49c7qjqj509"
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdIMD.ShowDialog()

        txtPath.Text = ofdIMD.FileName
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        'Load Excel
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
            AddTimelyLogs("IMPORT MASTER DATA", "Template was tampered", , False, "IMD Template has been modify", )
            MsgBox("Template was tampered", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.Enabled = False

       
        For cnt = 2 To MaxEntries
            'Dim ImportedItem As New cItemData
            'With ImportedItem
            '    .ItemCode = oSheet.Cells(cnt, 1).Value
            '    .Load_ItemCode()

            '    .Description = oSheet.Cells(cnt, 2).Value
            '    .Barcode = oSheet.Cells(cnt, 3).Value
            '    .Category = oSheet.Cells(cnt, 4).Value
            '    .SubCategory = oSheet.Cells(cnt, 5).Value
            '    .UnitofMeasure = oSheet.Cells(cnt, 6).Value
            '    .UnitPrice = If(Not IsNumeric(oSheet.Cells(cnt, 7).Value), 0, oSheet.Cells(cnt, 7).Value)
            '    .SalePrice = If(Not IsNumeric(oSheet.Cells(cnt, 8).Value), 0, oSheet.Cells(cnt, 8).Value)
            '    'If isYesNo(oSheet.Cells(cnt, 9).value) Then .isSaleable = IIf(YesNo(oSheet.Cells(cnt, 9).value) = "Y", 1, 0)
            '    'If isYesNo(oSheet.Cells(cnt, 10).value) Then .isInventoriable = IIf(YesNo(oSheet.Cells(cnt, 10).value) = "Y", 1, 0)
            '    'If isYesNo(oSheet.Cells(cnt, 11).value) Then .onHold = IIf(YesNo(oSheet.Cells(cnt, 11).value) = "Y", 1, 0)
            '    'If isYesNo(oSheet.Cells(cnt, 12).value) Then .IsLayAway = IIf(YesNo(oSheet.Cells(cnt, 12).value) = "Y", 1, 0)
            '    .Discount = oSheet.Cells(cnt, 13).value

            'End With

            ' AddItems(ImportedItem)
            Dim tmpChargeDetails As New ChargeDetails
            With tmpChargeDetails
                .ChrID = oSheet.Cells(cnt, 1).Value
                .ID = oSheet.Cells(cnt, 2).Value
                .AmountFrom = oSheet.Cells(cnt, 4).Value
                .AmountTo = oSheet.Cells(cnt, 5).Value
                .Charge = oSheet.Cells(cnt, 6).Value
                .Commision = oSheet.Cells(cnt, 7).Value
                .Remarks = oSheet.Cells(cnt, 8).Value
                .SaveChargeDetails()
            End With
       
        Next

        Me.Enabled = True

        'Memory Unload
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Success")
    End Sub

    Private Function TemplateIntegrityCheck(ByVal headers() As String) As Boolean
        Dim mergeHeaders As String = ""
        For Each head In headers
            mergeHeaders &= head
        Next : If HashString(mergeHeaders) = INTEGRITY_CHECK Then Return True
        Return False
    End Function
End Class