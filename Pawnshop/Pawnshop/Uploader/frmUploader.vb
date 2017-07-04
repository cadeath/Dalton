Imports Microsoft.Office.Interop

Public Class frmUploader
    Const INTEGRITY_CHECK As String = "6F5lEJWrAV8FBYhlSNPgDG5eTKHmboB6QC1pnWB0om4="

    Private Sub btnBrowseSMT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseSMT.Click
        ofdUploader.ShowDialog()

        Dim fileName As String = ofdUploader.FileName

        If fileName = "" Then Exit Sub
        txtPathSMT.Text = fileName
    End Sub

    Private Sub btnImportSMT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportSMT.Click
        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(txtPathSMT.Text)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        If Not TemplateCheck(checkHeaders) Then
            MsgBox("Wrong File or Template was tampered", MsgBoxStyle.Critical, "Error")
            GoTo unloadObj
        End If

        Me.Enabled = False
        For cnt = 2 To MaxEntries
            Dim SMTransfee As New SmartMoneyTransferFee
            With SMTransfee
                .SmtMin = oSheet.Cells(cnt, 1).Value
                .SmtMax = oSheet.Cells(cnt, 2).Value
                .SmtTransferFee = oSheet.Cells(cnt, 3).Value
                .SaveSMTFee()
            End With

        Next
        Me.Enabled = True
        MsgBox("Success", MsgBoxStyle.Information, "Upload")
unloadObj:
        'Memory Unload
        oSheet = Nothing
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing
    End Sub

    Private Function TemplateCheck(ByVal headers() As String) As Boolean
        Dim mergeHeaders As String = ""
        For Each head In headers
            mergeHeaders &= head
        Next
        Console.WriteLine("Template " & HashString(mergeHeaders))
        If HashString(mergeHeaders) = INTEGRITY_CHECK Then Return True
        Return False
    End Function
End Class