Imports Microsoft.Office.Interop
Public Class frmExtractor2
    Private Sub frmExtractor2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInit()
        'Load Path
        txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        transtype()
    End Sub
    Private Sub FormInit()
        Dim selectedDate As Date = MonCalendar.SelectionStart

        'If cboExtractType.Text = "" Then
        '    Console.WriteLine("Journal Entry Type Activated")
        '    sfdPath.FileName = String.Format("JRNLSUM{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
        '    Me.Text &= " - Journal Insurance"
        If cboExtractType.Text = "INSURANCE" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLINSUR{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal Insurance"
        ElseIf cboExtractType.Text = "NEW LOANS" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLNEWLOAN{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal NEW LOANS"
        ElseIf cboExtractType.Text = "RENEWALS" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLRENEW{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal RENEW"
        ElseIf cboExtractType.Text = "REDEMPTION" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLREDEMP{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal REDEMPTION"
        ElseIf cboExtractType.Text = "BORROWINGS" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLBORROW{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal BORROWINGS"
        ElseIf cboExtractType.Text = "PERA PADALA PMFTC- OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAPMFTCOUT{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA PMFTC - OUT"
        ElseIf cboExtractType.Text = "PERA PADALA PMFTC- IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAPMFTCIN{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA PMFTC - IN"
        ElseIf cboExtractType.Text = "PERA PADALA - OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAOUT{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA - OUT"
        ElseIf cboExtractType.Text = "PERA PADALA - IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAIN{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA - IN"
        ElseIf cboExtractType.Text = "GPRS - OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLGPRSOUT{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal GPRS - OUT"
        ElseIf cboExtractType.Text = "GPRS - IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLGPRSIN{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal GPRS - IN"
        ElseIf cboExtractType.Text = "PERA LINK- OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPERALINKOUT{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA LINK - OUT"
        ElseIf cboExtractType.Text = "PERA LINK- IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPERALINKIN{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA LINK - IN"
        ElseIf cboExtractType.Text = "WESTERN UNION - OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLWESTERNOUT{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal WESTERN UNION - OUT"
        ElseIf cboExtractType.Text = "WESTERN UNION - IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLWESTERNIN{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal WESTERN UNION - IN"
        ElseIf cboExtractType.Text = "DOLLAR" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLDOLLAR{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal DOLLAR"
        End If
    End Sub
    Public Sub transtype()
        Dim mysql As String = "SELECT DISTINCT TRANSTYPE FROM tblJournal WHERE Status = 1 AND TRANSTYPE <> 'null'"
        Dim filldata As String = "tblJournal"

        Dim ds As DataSet = LoadSQL(mysql)
        cboExtractType.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboExtractType.Items.Add(dr.Item("TRANSTYPE"))
        Next
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If txtPath.Text = "" And cboExtractType.Text = "" Then Exit Sub

        'If FormType = ExtractType.Expiry Then
        '    btnExtract.Enabled = False
        '    ExtractExpiry()
        'ElseIf FormType = ExtractType.MoneyTransferBSP Then
        '    btnExtract.Enabled = False
        '    MoneyTransferBSP()
        'Else
        '    Dim ans As MsgBoxResult = _
        '        MsgBox("We will only use the Starting Date." & vbCrLf & "Do you want to continue?", _
        '               vbYesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        '    btnExtract.Enabled = False
        '    If ans = MsgBoxResult.No Then btnExtract.Enabled = True : Exit Sub

        '    ExtractJournalEntry()
        'End If
        'btnExtract.Enabled = True
        'If cboExtractType.Text = "INSURANCE" Then
        '    INSURANCE()
        'ElseIf cboExtractType.Text = "NEW LOANS" Then
        '    NEWLOANS()
        INSURANCE()

    End Sub
    Private Sub INSURANCE()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim mysql As String = "SELECT  CATEGORY, JRL_TRANSDATE as TRANSDATE, TRANSNAME, SAPACCOUNT, JRL_DEBIT AS DEBIT," & _
        "JRL_CREDIT AS CREDIT, CCNAME, TODISPLAY, STATUS FROM tblJournal INNER JOIN tblCash  on CashID = JRL_TRANSID" & vbCrLf & _
        String.Format("WHERE Status = 1 AND TRANSTYPE ='" & cboExtractType.Text & "'", sd.ToShortDateString)

        Dim ds As DataSet = LoadSQL(mySql), MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count
        Console.WriteLine("Executing SQL:")
        Console.WriteLine(mySql)
        Console.WriteLine("Entries: " & MaxEntries)

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/JournalEntries.xls")
        oSheet = oWB.Worksheets(1)

        oSheet.Cells(3, 1).value = "1"
        oSheet.Cells(3, 2).value = sd.ToString("yyyyMMdd")
        oSheet.Cells(3, 8).value = sd.ToString("yyyyMMdd")
        oSheet.Cells(3, 10).value = "tNO"
        oSheet.Cells(3, 12).value = sd.ToString("yyyyMMdd")
        oSheet.Cells(3, 14).value = "tNO"

        oSheet = oWB.Worksheets(2)
        pbLoading.Maximum = MaxEntries
        pbLoading.Value = 0

        Dim recCnt As Single = 0
        While recCnt < MaxEntries
            With ds.Tables(0).Rows(recCnt)

                oSheet.Cells(lineNum + 3, 1) = 1 'ParentKey
                oSheet.Cells(lineNum + 3, 2) = lineNum 'LineNum
                oSheet.Cells(lineNum + 3, 4) = .Item("SAPACCOUNT").ToString 'AccountCode
                oSheet.Cells(lineNum + 3, 5) = .Item("Debit") 'Debit
                oSheet.Cells(lineNum + 3, 6) = .Item("Credit") 'Credit
                oSheet.Cells(lineNum + 3, 19) = AREACODE  'ProfitCode
                oSheet.Cells(lineNum + 3, 32) = BranchCode  'OcrCode2
                oSheet.Cells(lineNum + 3, 33) = "OPE" 'OcrCode3


                If IsDBNull(.Item("CCNAME")) Then
                    lineNum += 1
                Else
                    If (Not .Item("CCNAME") = "FUND REPLENISHMENT") Then lineNum += 1
                End If

                recCnt += 1
            End With

            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String
        'If cboExtractType.Text = "" Then
        '    Console.WriteLine("Journal Entry Type Activated")
        '    sfdPath.FileName = String.Format("JRNLSUM{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
        '    Me.Text &= " - Journal Insurance"
        If cboExtractType.Text = "INSURANCE" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLINSUR{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal Insurance"
        ElseIf cboExtractType.Text = "NEW LOANS" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLNEWLOAN{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal NEW LOANS"
        ElseIf cboExtractType.Text = "RENEWALS" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLRENEW{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal RENEW"
        ElseIf cboExtractType.Text = "REDEMPTION" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLREDEMP{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal REDEMPTION"
        ElseIf cboExtractType.Text = "BORROWINGS" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLBORROW{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal BORROWINGS"
        ElseIf cboExtractType.Text = "PERA PADALA PMFTC- OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAPMFTCOUT{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA PMFTC - OUT"
        ElseIf cboExtractType.Text = "PERA PADALA PMFTC- IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAPMFTCIN{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA PMFTC - IN"
        ElseIf cboExtractType.Text = "PERA PADALA - OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAOUT{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA - OUT"
        ElseIf cboExtractType.Text = "PERA PADALA - IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPADALAIN{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA PADALA - IN"
        ElseIf cboExtractType.Text = "GPRS - OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLGPRSOUT{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal GPRS - OUT"
        ElseIf cboExtractType.Text = "GPRS - IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLGPRSIN{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal GPRS - IN"
        ElseIf cboExtractType.Text = "PERA LINK- OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPERALINKOUT{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA LINK - OUT"
        ElseIf cboExtractType.Text = "PERA LINK- IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLPERALINKIN{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal PERA LINK - IN"
        ElseIf cboExtractType.Text = "WESTERN UNION - OUT" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLWESTERNOUT{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal WESTERN UNION - OUT"
        ElseIf cboExtractType.Text = "WESTERN UNION - IN" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLWESTERNIN{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal WESTERN UNION - IN"
        ElseIf cboExtractType.Text = "DOLLAR" Then
            Console.WriteLine("Journal Entry Type Activated")
            sfdPath.FileName = String.Format("JRNLDOLLAR{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
            Me.Text &= " - Journal DOLLAR"
        End If

        Console.WriteLine("Split Count: " & txtPath.Text.Split(".").Count)
        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName
        End If

        oWB.SaveAs(verified_url)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("Journal Entries for Insurance Extracted", MsgBoxStyle.Information)
    End Sub

    Private Sub AddProgress()
        pbLoading.Value += 1
    End Sub

    Private Function RandomString() As String
        Dim KeyGen As RandomKeyGenerator

        KeyGen = New RandomKeyGenerator
        KeyGen.KeyNumbers = "0123456789"
        KeyGen.KeyChars = 6

        Return KeyGen.Generate()
    End Function

    Private Sub txtPath_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPath.DoubleClick
        sfdPath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim result As DialogResult = sfdPath.ShowDialog

        If Not result = Windows.Forms.DialogResult.OK Then
            Return
        End If
        txtPath.Text = sfdPath.FileName
    End Sub
End Class