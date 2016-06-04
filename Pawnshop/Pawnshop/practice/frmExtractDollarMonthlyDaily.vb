Imports Microsoft.Office.Interop

Public Class frmExtractDollarMonthlyDaily
    Enum ExtractType As Integer
        Expiry = 0
        DollarTransaction = 1
        MoneyTransferBSP = 2
    End Enum
    Friend FormType As ExtractType = ExtractType.Expiry
    Private Sub frmExtractDollarMonthlyDaily_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormInitt()
        txtpath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub txtpath_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtpath.DoubleClick
        savepath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim result As DialogResult = savepath.ShowDialog

        If Not result = Windows.Forms.DialogResult.OK Then
            Return
        End If
        txtpath.Text = savepath.FileName
    End Sub
    Private Sub AddProgress()
        ProgressBar1.Value += 1
    End Sub
    Private Sub FormInitt()
        Dim selectedDate As Date = MonCalendar.SelectionStart

        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                savepath.FileName = String.Format("{1}{0}.xls", selectedDate.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.DollarTransaction
                Console.WriteLine("Dollar Transaction Entry Type Activated")
                savepath.FileName = String.Format("JRNL{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
            Case ExtractType.MoneyTransferBSP
                Console.WriteLine("Money Transfer BSP Activated")
                savepath.FileName = String.Format("MTBSP{0}{1}.xls", selectedDate.ToString("yyyyMMM"), BranchCode) 'MTBSP + Date + BranchCode
                Me.Text &= " - BSP Report"
        End Select
    End Sub

    Private Sub btnextract_Click(sender As System.Object, e As System.EventArgs) Handles btnextract.Click
        If txtpath.Text = "" Then Exit Sub
        If cboMonthlyDaily.Text = "Monthly" Then
            extractDollarTransactionMonthly()
        Else
            extractDollarTransactionDaily()
        End If
        btnextract.Enabled = True
    End Sub
    Private Sub extractDollarTransactionMonthly()
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim mySql As String = "SELECT TRANSDATE, DENOMINATION, PESORATE, NETAMOUNT, SERIAL, CURRENCY " & _
        "FROM DOLLAR_TRANSACTION " & vbCrLf & _
        String.Format("WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"
        Dim ds As DataSet = LoadSQL(mySql), MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count
        Console.WriteLine("Executing SQL:")
        Console.WriteLine(mySql)
        Console.WriteLine("Entries: " & MaxEntries)

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/Copy of DollarTransaction.xls")
        oSheet = oWB.Worksheets(1)

        'oSheet.Cells(3, 1).value = "1"
        'oSheet.Cells(3, 2).value = sd.ToString("yyyyMMdd")
        'oSheet.Cells(3, 8).value = sd.ToString("yyyyMMdd")
        'oSheet.Cells(3, 10).value = "tNO"
        'oSheet.Cells(3, 12).value = sd.ToString("yyyyMMdd")
        'oSheet.Cells(3, 14).value = "tNO"

        oSheet = oWB.Worksheets(1)
        ProgressBar1.Maximum = MaxEntries
        ProgressBar1.Value = 0

        Dim recCnt As Single = 0
        While recCnt < MaxEntries
            With ds.Tables(0).Rows(recCnt)
                oSheet.Cells(lineNum + 3, 1) = .Item("TRANSDATE").ToString
                oSheet.Cells(lineNum + 3, 2) = .Item("DENOMINATION")
                oSheet.Cells(lineNum + 3, 3) = .Item("PESORATE")
                oSheet.Cells(lineNum + 3, 4) = .Item("NETAMOUNT")
                oSheet.Cells(lineNum + 3, 5) = .Item("SERIAL")
                oSheet.Cells(lineNum + 3, 6) = .Item("CURRENCY")

                If IsDBNull(.Item("CURRENCY")) Then
                    lineNum += 1
                Else
                    If (Not .Item("CURRENCY") = "FUND REPLENISHMENT") Then lineNum += 1
                End If
                recCnt += 1
            End With

            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String

        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                savepath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.DollarTransaction
                Console.WriteLine("Journal Entry Type Activated")
                savepath.FileName = String.Format("JRNL{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
        End Select

        Console.WriteLine("Split Count: " & txtpath.Text.Split(".").Count)
        If txtpath.Text.Split(".").Count > 1 Then
            If txtpath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtpath.Text
            Else
                verified_url = txtpath.Text & "/" & savepath.FileName
            End If
        Else
            verified_url = txtpath.Text & "/" & savepath.FileName
        End If

        oWB.SaveAs(verified_url)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Dollar Transaction Entries Extracted", MsgBoxStyle.Information)
    End Sub
    Private Sub FormInit()
        Dim selectedDate As Date = MonCalendar.SelectionStart

        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                savepath.FileName = String.Format("{1}{0}.xls", selectedDate.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.DollarTransaction
                Console.WriteLine("Dollar Transaction Entry Type Activated")
                savepath.FileName = String.Format("JRNL{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
            Case ExtractType.MoneyTransferBSP
                Console.WriteLine("Money Transfer BSP Activated")
                savepath.FileName = String.Format("MTBSP{0}{1}.xls", selectedDate.ToString("yyyyMMM"), BranchCode) 'MTBSP + Date + BranchCode
                Me.Text &= " - BSP Report"
        End Select
    End Sub
    Private Sub extractDollarTransactionDaily()
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim mySql As String = "SELECT TRANSDATE, DENOMINATION, PESORATE, NETAMOUNT, SERIAL, CURRENCY " & _
        "FROM DOLLAR_TRANSACTION " & vbCrLf & _
        String.Format("WHERE TRANSDATE = '{0}'", MonCalendar.SelectionStart.ToShortDateString)
        mySql &= " ORDER BY TRANSDATE ASC"
        Dim ds As DataSet = LoadSQL(mySql), MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count
        Console.WriteLine("Executing SQL:")
        Console.WriteLine(mySql)
        Console.WriteLine("Entries: " & MaxEntries)

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/Copy of DollarTransaction.xls")
        oSheet = oWB.Worksheets(1)

        'oSheet.Cells(3, 1).value = "1"
        'oSheet.Cells(3, 2).value = sd.ToString("yyyyMMdd")
        'oSheet.Cells(3, 8).value = sd.ToString("yyyyMMdd")
        'oSheet.Cells(3, 10).value = "tNO"
        'oSheet.Cells(3, 12).value = sd.ToString("yyyyMMdd")
        'oSheet.Cells(3, 14).value = "tNO"

        oSheet = oWB.Worksheets(1)
        ProgressBar1.Maximum = MaxEntries
        ProgressBar1.Value = 0

        Dim recCnt As Single = 0
        While recCnt < MaxEntries
            With ds.Tables(0).Rows(recCnt)

                ''oSheet.Cells(lineNum + 3, 1) = 1 'ParentKey
                ''oSheet.Cells(lineNum + 3, 2) = lineNum 'LineNum
                oSheet.Cells(lineNum + 3, 1) = .Item("TRANSDATE").ToString 'AccountCode
                oSheet.Cells(lineNum + 3, 2) = .Item("DENOMINATION")
                oSheet.Cells(lineNum + 3, 3) = .Item("PESORATE")
                oSheet.Cells(lineNum + 3, 4) = .Item("NETAMOUNT")
                oSheet.Cells(lineNum + 3, 5) = .Item("SERIAL")
                oSheet.Cells(lineNum + 3, 6) = .Item("CURRENCY")

                If IsDBNull(.Item("CURRENCY")) Then
                    lineNum += 1
                Else
                    If (Not .Item("CURRENCY") = "FUND REPLENISHMENT") Then lineNum += 1
                End If
                recCnt += 1
            End With

            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String

        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                savepath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.DollarTransaction
                Console.WriteLine("Dollar Transaction Entry Type Activated")
                savepath.FileName = String.Format("JRNL{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
        End Select

        Console.WriteLine("Split Count: " & txtpath.Text.Split(".").Count)
        If txtpath.Text.Split(".").Count > 1 Then
            If txtpath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtpath.Text
            Else
                verified_url = txtpath.Text & "/" & savepath.FileName
            End If
        Else
            verified_url = txtpath.Text & "/" & savepath.FileName
        End If

        oWB.SaveAs(verified_url)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Dollar Transaction Entries Extracted", MsgBoxStyle.Information)
    End Sub
End Class