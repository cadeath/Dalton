Imports Microsoft.Office.Interop

Public Class frmUploadLay
    Private InvoiceNum As Double = GetOption("InvoiceNum")

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        lvLayAway.Items.Clear()
        ofdIMD.ShowDialog()

        Dim fileName As String = ofdIMD.FileName
        Dim isDone As Boolean = False

        If fileName = "" Then Exit Sub
        lblFilename.Text = fileName

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

        Me.Enabled = False
        For cnt = 2 To MaxEntries

            For Each itm As ListViewItem In lvLayAway.Items
                If itm.Text.Contains(oSheet.Cells(cnt, 1).Value) Then
                    'itm.Selected = True
                    MsgBox("Duplicate " & itm.Text, MsgBoxStyle.Critical, "Warning!")
                    btnImport.Enabled = False
                End If
            Next

            Dim lv As ListViewItem = lvLayAway.Items.Add(oSheet.Cells(cnt, 1).Value)
            lv.SubItems.Add(oSheet.Cells(cnt, 2).Value)
            lv.SubItems.Add(oSheet.Cells(cnt, 3).Value)
            lv.SubItems.Add(oSheet.Cells(cnt, 4).Value)
            lv.SubItems.Add(oSheet.Cells(cnt, 5).Value)
            lv.SubItems.Add("")
            lv.SubItems.Add("")

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

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        If lvLayAway.Items.Count = 0 Then Exit Sub

        Me.Enabled = False
        For Each lv As ListViewItem In lvLayAway.Items
            Dim lay As New LayAway
            With lay
                .ItemCode = lv.SubItems(0).Text
                .DocDate = lv.SubItems(1).Text
                .ForfeitDate = lv.SubItems(2).Text
                .Price = lv.SubItems(3).Text
                .Balance = lv.SubItems(4).Text
                .CustomerID = lv.SubItems(5).Text
                .SaveLayAway()
            End With

            Dim LayLines As New LayAwayLines
            With LayLines
                .LayID = lay.LayLastID
                .PaymentDate = lv.SubItems(0).Text
                .ControlNumber = String.Format("{1}#{0:000000}", InvoiceNum, "CI")
                .Amount = lv.SubItems(3).Text - lv.SubItems(4).Text
                .SaveLayAwayLines()
            End With

            InvoiceNum += 1
            UpdateOptions("InvoiceNum", InvoiceNum)
        Next
        Me.Enabled = True

        MsgBox("Exited LayAway imported", MsgBoxStyle.Information, "Succesful")
        lvLayAway.Items.Clear()
    End Sub

    Private Sub frmUploadLay_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvLayAway.Items.Clear()
    End Sub

    Private Sub btnAddCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCustomer.Click
        If lvLayAway.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvLayAway.FocusedItem.Index
        frmAddCustomer.retID = idx
        frmAddCustomer.Show()
    End Sub

    Friend Sub DisplayValue(ByVal CustomerID As Integer, ByVal CustomerName As String, ByVal id As Integer)
        lvLayAway.Items(id).SubItems(5).Text = CustomerID
        lvLayAway.Items(id).SubItems(6).Text = CustomerName
    End Sub

    Private Sub lvLayAway_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLayAway.DoubleClick
        btnAddCustomer.PerformClick()
    End Sub
End Class