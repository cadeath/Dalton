Imports Microsoft.Office.Interop

Public Class dev_SMTCompute


    Private Sub GenerateSMt()

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/SMT.xls")
        oSheet = oWB.Worksheets(1)

        Dim rid As Integer = 2

        'For i As Integer = 0 To ds_expiry.Tables(0).Rows.Count - 1
        '    With ds_expiry.Tables(0).Rows(i)
        '        oSheet.Cells(rid, 1).value = .Item("PawnID").ToString
        '        oSheet.Cells(rid, 2).value = .Item("PawnTicket").ToString

        '    End With

        '    rid += 1

        '    Application.DoEvents()
        'Next

        Dim isFinish As Boolean = False
        Dim MinStart As Double = 0.01
        Dim MaxStart As Double = 1000
        Dim Fee As Double = 5

        While isFinish = False
            oSheet.Cells(rid, 1).value = MinStart
            oSheet.Cells(rid, 2).value = MaxStart
            oSheet.Cells(rid, 3).value = Fee

            If MaxStart = 50000 Then isFinish = True

            If MinStart = 0.01 Then
                MinStart += 1000
                MaxStart += 500
                Fee += 2.5
            Else
                MinStart += 500
                MaxStart += 500
                Fee += 2.5
            End If
            rid += 1



        End While

        Dim verified_url As String
        'If txtPath.Text.Split(".").Count > 1 Then
        '    If txtPath.Text.Split(".")(1).Length = 3 Then
        '        verified_url = txtPath.Text
        '    Else
        '        verified_url = txtPath.Text & "/" & sfdPath.FileName
        '    End If
        'Else
        '    verified_url = txtPath.Text & "/" & sfdPath.FileName
        'End If
        verified_url = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "/" & "SMTFee"

        oWB.SaveAs(verified_url)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Success", MsgBoxStyle.Information)
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        GenerateSMt()
    End Sub
End Class