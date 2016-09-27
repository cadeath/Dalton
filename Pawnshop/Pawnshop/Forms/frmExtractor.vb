Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Public Class frmExtractor
    Enum ExtractType As Integer
        Expiry = 0
        JournalEntry = 1
        MoneyTransferBSP = 2
    End Enum
    Friend FormType As ExtractType = ExtractType.Expiry

    Private Sub txtPath_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPath.DoubleClick
        sfdPath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim result As DialogResult = sfdPath.ShowDialog

        If Not result = Windows.Forms.DialogResult.OK Then
            Return
        End If
        txtPath.Text = sfdPath.FileName
    End Sub

    Private Sub frmExtractor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        FormInit()
        'Load Path
        txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub
    ''' <summary>
    ''' this method will select what you want to extract.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub FormInit()
        Dim selectedDate As Date = MonCalendar.SelectionStart
        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", selectedDate.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
            Case ExtractType.MoneyTransferBSP
                Console.WriteLine("Money Transfer BSP Activated")
                sfdPath.FileName = String.Format("MTBSP{0}{1}.xls", selectedDate.ToString("yyyyMMM"), BranchCode) 'MTBSP + Date + BranchCode
                Me.Text &= " - BSP Report"
        End Select
    End Sub

    ''' <summary>
    ''' This button will extract the desired extract type.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If txtPath.Text = "" Then Exit Sub

        If FormType = ExtractType.Expiry Then
            btnExtract.Enabled = False
            ExtractExpiry()
        ElseIf FormType = ExtractType.MoneyTransferBSP Then
            btnExtract.Enabled = False
            MoneyTransferBSP()
        Else
            Dim ans As MsgBoxResult = _
                MsgBox("We will only use the Starting Date." & vbCrLf & "Do you want to continue?", _
                       vbYesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            btnExtract.Enabled = False
            If ans = MsgBoxResult.No Then btnExtract.Enabled = True : Exit Sub
            ExtractJournalEntry2()
        End If
        btnExtract.Enabled = True
    End Sub
    ''' <summary>
    ''' This method will extract journal entry and load the excel.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExtractJournalEntry()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim mySql As String = "SELECT SAPACCOUNT, DEBIT, CREDIT, CCNAME " & _
        "FROM JOURNAL_ENTRIES " & vbCrLf & _
        String.Format("WHERE TRANSDATE = '{0}' AND SAPACCOUNT <> 'null'", sd.ToShortDateString)

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

        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
        End Select

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

        MsgBox("Journal Entries Extracted", MsgBoxStyle.Information)
    End Sub
    Private Sub ExtractJournalEntry2()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String = "SELECT J.JRL_TRANSDATE as TRANSDATE, C.TRANSNAME, C.SAPACCOUNT, J.JRL_DEBIT AS DEBIT, J.JRL_CREDIT AS CREDIT, J.CCNAME, J.STATUS, J.TRANSTYPE " & _
        "FROM tblJournal AS J INNER JOIN tblCash AS C on C.CashID = J.JRL_TRANSID " & vbCrLf & _
        String.Format("WHERE J.JRL_TRANSDATE = '{0}' AND J.Status = 1 AND C.SAPACCOUNT <> 'null' AND J.TRANSTYPE is null ", sd.ToShortDateString)
        'mySql &= "ORDER BY J.TRANSTYPE"

        Dim mySql2 As String = "SELECT SAPACCOUNT, DEBIT, CREDIT, CCNAME " & _
       "FROM JOURNAL_SUMMARY " & vbCrLf & _
       String.Format("WHERE TRANSDATE = '{0}' AND SAPACCOUNT <> 'null' AND TRANSTYPE <> 'null' AND TRANSTYPE <> 'Receipt Fund from Head Office'", sd.ToShortDateString)
        mySql2 &= " ORDER BY TRANSTYPE, DEBIT DESC "

        Dim ds As DataSet = LoadSQL(mySql)
        Dim ds2 As DataSet = LoadSQL(mySql2)
        Dim MaxEntries As Integer = 0

        Dim MaxEntries2 As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count
        MaxEntries2 = ds2.Tables(0).Rows.Count

        Console.WriteLine("Executing SQL:")
        Console.WriteLine(mySql2, mySql)
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
        pbLoading.Maximum = MaxEntries2
        pbLoading.Value = 0

        Dim recCnt2 As Single = 0
        While recCnt2 < MaxEntries2
            With ds2.Tables(0).Rows(recCnt2)

                oSheet.Cells(lineNum + 3, 1) = 1 'ParentKey
                oSheet.Cells(lineNum + 3, 2) = lineNum 'LineNum
                oSheet.Cells(lineNum + 3, 4) = .Item("SAPACCOUNT").ToString 'AccountCode
                oSheet.Cells(lineNum + 3, 5) = .Item("DEBIT") 'Debit
                oSheet.Cells(lineNum + 3, 6) = .Item("CREDIT") 'Credit
                'oSheet.Cells(lineNum + 3, 4) = .Item("TRANSNAME")
                oSheet.Cells(lineNum + 3, 19) = AREACODE  'ProfitCode
                oSheet.Cells(lineNum + 3, 32) = BranchCode  'OcrCode2
                oSheet.Cells(lineNum + 3, 33) = "OPE" 'OcrCode3

                If IsDBNull(.Item("CCNAME")) Then
                    lineNum += 1
                Else
                    If (Not .Item("CCNAME") = "FUND REPLENISHMENT") Then lineNum += 1
                End If
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

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

        Select Case FormType
            Case ExtractType.Expiry
                Console.WriteLine("Expiry Type Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}{1}.xls", sd.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
        End Select

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

        MsgBox("Journal Entries Extracted", MsgBoxStyle.Information)
    End Sub
    ''' <summary>
    ''' This method will select between date range.
    ''' search the items by date
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub MoneyTransferBSP()
        Dim st As Date = GetFirstDate(MonCalendar.SelectionStart)
        Dim en As Date = GetLastDate(MonCalendar.SelectionStart)
        Dim mySql As String

        Dim listHeaders() As String = _
            {"BranchCode", "ServiceType", "TransDate", "MoneyTrans", "RefNum", _
             "Payout", "SendIn", "ServiceCharge", "Commission", _
             "NetAmount", "SenderName", "S_Addr", "ReceiverName", "R_Addr", "Location"}

        mySql = "SELECT '" + BranchCode + "' as BranchCode, MT.* FROM MONEY_TRANSFER MT WHERE TRANSDATE BETWEEN '" + st.ToShortDateString + "' AND '" + en.ToShortDateString + "'"
        Dim ds As DataSet = LoadSQL(mySql)
        Console.WriteLine(ds.Tables(0).Rows.Count & " items found!")
        pbLoading.Maximum = ds.Tables(0).Rows.Count
        pbLoading.Value = 0

        'Load Excel
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Return
        End If

        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oXL = CreateObject("Excel.Application")
        oXL.Visible = False

        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet
        oSheet.Name = "MONTHLY"

        ' HEADERS
        Dim cnt As Integer = 0
        For Each hr In listHeaders
            cnt += 1 : oSheet.Cells(1, cnt).value = hr
        Next

        ' EXTRACTING
        Dim rowCnt As Integer = 2
        For Each dr As DataRow In ds.Tables(0).Rows
            For colCnt As Integer = 0 To listHeaders.Count - 1
                oSheet.Cells(rowCnt, colCnt + 1).value = dr(colCnt)
            Next
            rowCnt += 1

            AddProgress()
            Application.DoEvents()
        Next

        ' SAVE
        Dim verified_url As String

        sfdPath.FileName = String.Format("MTBSP{0}{1}.xls", MonCalendar.SelectionStart.ToString("yyyyMMM"), BranchCode) 'MTBSP + Date + BranchCode
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

        MsgBox("Data Saved", MsgBoxStyle.Information)
    End Sub
    ''' <summary>
    ''' This method will extract the expiry date and then load the excel
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ExtractExpiry()
        Dim sd As Date = MonCalendar.SelectionStart
        Dim ed As Date = MonCalendar.SelectionEnd

        Dim mySql As String = "SELECT * FROM EXPIRY_LIST"
        mySql &= vbCr & " WHERE "
        mySql &= vbCr & String.Format("EXPIRYDATE BETWEEN '{0}' AND '{1}'", GetFirstDate(sd).ToShortDateString, GetLastDate(ed).ToShortDateString)

        Dim ds_expiry As DataSet = LoadSQL(mySql)

        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/ExpiryFormat.xls")
        oSheet = oWB.Worksheets(1)

        Console.WriteLine("Entry found " & ds_expiry.Tables(0).Rows.Count)
        Dim rid As Integer = 2

        pbLoading.Maximum = ds_expiry.Tables(0).Rows.Count
        pbLoading.Value = 0
        While rid < ds_expiry.Tables(0).Rows.Count
            With ds_expiry.Tables(0).Rows(rid)
                oSheet.Cells(rid, 1).value = .Item("PawnID").ToString
                oSheet.Cells(rid, 2).value = .Item("PawnTicket").ToString
                oSheet.Cells(rid, 3).value = .Item("LoanDate").ToString 'TransDate
                oSheet.Cells(rid, 4).value = .Item("FirstName").ToString & _
                    " " & .Item("LastName").ToString 'Pawner
                oSheet.Cells(rid, 5).value = ds_expiry.Tables(0).Rows(rid).Item("Addr_Street").ToString & _
                    " " & ds_expiry.Tables(0).Rows(rid).Item("Addr_Brgy").ToString 'Addr1
                oSheet.Cells(rid, 6).value = .Item("Addr_City").ToString 'Addr2
                oSheet.Cells(rid, 7).value = .Item("Addr_Province").ToString 'Addr3
                oSheet.Cells(rid, 8).value = .Item("Addr_Zip").ToString 'Zip
                oSheet.Cells(rid, 9).value = .Item("ItemType").ToString 'ItemType
                oSheet.Cells(rid, 10).value = .Item("Grams").ToString 'Grams
                oSheet.Cells(rid, 11).value = "1" 'NoPCS
                oSheet.Cells(rid, 12).value = .Item("Description").ToString 'DESC1
                'oSheet.Cells(rid, 13).value = .Item("PawnTicket").ToString 'DESC2
                'oSheet.Cells(rid, 14).value = .Item("PawnTicket").ToString 'DESC3
                'oSheet.Cells(rid, 15).value = .Item("PawnTicket").ToString 'DESC4
                oSheet.Cells(rid, 16).value = "0" 'NOMONTH
                oSheet.Cells(rid, 17).value = .Item("MATUDATE").ToString 'MATUDATE
                oSheet.Cells(rid, 18).value = .Item("EXPIRYDATE").ToString 'EXPIDATE
                oSheet.Cells(rid, 19).value = .Item("AUCTIONDATE").ToString 'AUCTDATE
                'oSheet.Cells(rid, 20).value = .Item("Interest").ToString 'INT_RATE
                oSheet.Cells(rid, 21).value = .Item("Appraisal").ToString 'APPRAISAL
                oSheet.Cells(rid, 22).value = .Item("Principal").ToString 'PRINCIPAL
                oSheet.Cells(rid, 23).value = .Item("Interest").ToString 'INT_AMOUNT
                oSheet.Cells(rid, 24).value = .Item("ServiceCharge").ToString 'SRV_CHARGE
                oSheet.Cells(rid, 25).value = .Item("Evat").ToString 'VAT
                'oSheet.Cells(rid, 26).value = .Item("PawnTicket").ToString 'DOC_STAMP
                oSheet.Cells(rid, 27).value = .Item("NetAmount").ToString 'NET_AMOUNT
                oSheet.Cells(rid, 28).value = .Item("Username").ToString 'USER
                oSheet.Cells(rid, 29).value = .Item("Status").ToString 'STATUS
                'oSheet.Cells(rid, 30).value = .Item("PawnTicket").ToString 'NEW NUM
                oSheet.Cells(rid, 31).value = .Item("OLDTICKET").ToString 'OLD NUM
                oSheet.Cells(rid, 32).value = .Item("ORNUM").ToString 'RCT NO
                'oSheet.Cells(rid, 33).value = .Item("PawnTicket").ToString 'CLOSE DATE
                'oSheet.Cells(rid, 34).value = .Item("PawnTicket").ToString 'TRANSFER_DATE
                'oSheet.Cells(rid, 35).value = .Item("PawnTicket").ToString 'DATE_CREATED
                'oSheet.Cells(rid, 36).value = .Item("PawnTicket").ToString 'CANCEL
                'oSheet.Cells(rid, 37).value = .Item("PawnTicket").ToString 'DATE CANCEL
                'oSheet.Cells(rid, 38).value = .Item("PawnTicket").ToString 'ISBEGBAL
                oSheet.Cells(rid, 39).value = "'" & .Item("PHONE1").ToString 'PHONE_NO
                oSheet.Cells(rid, 40).value = .Item("BIRTHDAY").ToString 'BIRTHDAY
                oSheet.Cells(rid, 41).value = .Item("SEX").ToString 'SEX
                oSheet.Cells(rid, 42).value = .Item("KARAT").ToString 'KARAT
                oSheet.Cells(rid, 43).value = .Item("KARAT").ToString 'KARAT1
                oSheet.Cells(rid, 44).value = .Item("GRAMS").ToString 'GRAMS1
                oSheet.Cells(rid, 45).value = .Item("APPRAISAL").ToString 'APPRAISAL1
                'oSheet.Cells(rid, 46).value = .Item("PawnTicket").ToString 'APPRAISEDBY1
                'oSheet.Cells(rid, 47).value = .Item("PawnTicket").ToString 'DATE_REAPPRAISAL1
                oSheet.Cells(rid, 48).value = .Item("Category").ToString 'ITEMDESC
                'oSheet.Cells(rid, 49).value = .Item("PawnTicket").ToString 'ESKIE
            End With

            rid += 1
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String
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

        MsgBox("Data Saved", MsgBoxStyle.Information)
        Me.Close()
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
End Class