Imports Microsoft.Office.Interop

Public Class frmUploadLay
    Private InvoiceNum As Double = GetOption("InvoiceNum")
    Const INTEGRITY_CHECK As String = "9nKFB3fmcquH6o6jI4BvqCce/N3Zbdt1BZ0Tgt3nUMQwuaS4Cd3etV0JbvO6jHFN"


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

        If Not TemplateCheck(checkHeaders) Then
            MsgBox("Wrong File or Template was tampered", MsgBoxStyle.Critical, "Error")
            GoTo unloadObj
        End If

        Me.Enabled = False
        For cnt = 2 To MaxEntries

            For Each itm As ListViewItem In lvLayAway.Items
                If itm.Text.Contains(oSheet.Cells(cnt, 1).Value) Then
                    MsgBox("Duplicate ItemCode: " & itm.Text, MsgBoxStyle.Critical, "Warning!")
                    itm.BackColor = Color.Red
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
        If Not isValid() Then Exit Sub

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
                .Encoder = UserID
                .SaveLayAway()
                .ItemOnLayMode(lv.SubItems(0).Text)
            End With

            'Dim LayLines As New LayAwayLines
            'With LayLines
            '    .LayID = lay.LayLastID
            '    .PaymentDate = lv.SubItems(1).Text
            '    .ControlNumber = String.Format("{1}#{0:000000}", InvoiceNum, "CI")
            '    .Amount = lv.SubItems(3).Text - lv.SubItems(4).Text
            '    .PaymentEncoder = UserID
            '    .SaveLayAwayLines()
            'End With

            'InvoiceNum += 1
            'UpdateOptions("InvoiceNum", InvoiceNum)
        Next
        Me.Enabled = True

        MsgBox("LayAway imported", MsgBoxStyle.Information, "Succesful")
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
        lvLayAway.Items(id).BackColor = Nothing
    End Sub

    Private Sub lvLayAway_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvLayAway.DoubleClick
        btnAddCustomer.PerformClick()
    End Sub

    Private Function isValid() As Boolean

        For Each lv As ListViewItem In lvLayAway.Items

            If lv.SubItems(5).Text = "" Then
                MsgBox("No Customer Selected", MsgBoxStyle.Critical, "Error")
                lv.BackColor = Color.Yellow
                Return False
            End If

            Dim mysql As String = "Select * From ItemMaster Where OnLayAway <> 1 AND ItemCode = '" & lv.SubItems(0).Text & "'"
            Dim fillData As String = "ItemMaster"
            Dim ds As DataSet = LoadSQL(mysql, fillData)

            If ds.Tables(0).Rows.Count = 0 Then MsgBox("No ItemCode " & lv.SubItems(0).Text & " Found!", MsgBoxStyle.Critical, "Error") : Return False
        Next

        Return True
    End Function

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