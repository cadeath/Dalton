Imports Microsoft.Office.Interop
Public Class frmUploadMTCharge
    Const INTEGRITY_CHECK As String = "SwKuUDj3dsORDPF45AuT8xxmf/JPU4GcMIDDncv6iYs9a7eK5E2zbvO8obGKIVgNDbKi9DXV0ncqlXOoeXpgo49c7qjqj509"
    Const INTEGRITY_CHECK2 As String = "UMUV9D2cQNSaDoaRncZmrPt9TJFqMdsXbu3+GxxF0pi/dh8H8htGbgKOjSdnpIgx9D3lwzQAxoZwVGp1kn8S7WaX2T5tuE6g"
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

        If Not TemplateIntegrityCheck(checkHeaders, FileCheck.ChargeDetails) Then
            AddTimelyLogs("IMPORT MASTER DATA", "Template was tampered", , False, "IMD Template has been modify", )
            MsgBox("Template was tampered", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.Enabled = False


        For cnt = 2 To MaxEntries
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

    Enum FileCheck
        ChargeName = 0
        ChargeDetails = 1
    End Enum
    Private Function TemplateIntegrityCheck(ByVal headers() As String, ByVal tmpfile As FileCheck) As Boolean
        Dim mergeHeaders As String = ""
        For Each head In headers
            mergeHeaders &= head
        Next : If HashString(mergeHeaders) = IIf(tmpfile = FileCheck.ChargeDetails, INTEGRITY_CHECK, INTEGRITY_CHECK2) Then Return True
        Return False
    End Function

    Private Sub btnBrowseChargeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseChargeName.Click
        ofdIMD.ShowDialog()

        txtPathChargeName.Text = ofdIMD.FileName
    End Sub

    Private Sub btnOKChargeName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOKChargeName.Click
        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(txtPathChargeName.Text)
        oSheet = oWB.Worksheets(1)

        Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
        Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

        Dim checkHeaders(MaxColumn) As String
        For cnt As Integer = 0 To MaxColumn - 1
            checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
        Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

        If Not TemplateIntegrityCheck(checkHeaders, FileCheck.ChargeName) Then
            AddTimelyLogs("IMPORT MASTER DATA", "Template was tampered", , False, "IMD Template has been modify", )
            MsgBox("Template was tampered", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Me.Enabled = False


        For cnt = 2 To MaxEntries
            Dim tmpChargeName As New ChargeName
            With tmpChargeName
                .Name = oSheet.Cells(cnt, 1).Value
                .Description = oSheet.Cells(cnt, 2).Value
                .isGenerated = IIf(oSheet.Cells(cnt, 3).Value = "YES", True, False)
                Select Case oSheet.Cells(cnt, 4).Value
                    Case "RECEIVE"
                        .Action_Type = 1
                    Case "SEND"
                        .Action_Type = 0
                    Case Else
                        .Action_Type = 2
                End Select
                '.Action_Type = IIf(oSheet.Cells(cnt, 4).Value = "RECEIVE", True, False)
                .HasPayoutCommission = IIf(oSheet.Cells(cnt, 5).Value = "YES", True, False)
                .SaveChargeName()
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
End Class