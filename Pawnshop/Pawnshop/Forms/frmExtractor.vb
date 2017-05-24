Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Imports System.IO

Public Class frmExtractor
    Enum ExtractType As Integer
        Expiry = 0
        JournalEntry = 1
        MoneyTransferBSP = 2
        PTUFile = 3
    End Enum

    Friend accessType As String = ""

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
        'Load Path
        txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        Select Case FormType
            Case ExtractType.Expiry
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Me.Text &= " - Journal Entry"
            Case ExtractType.MoneyTransferBSP
                Me.Text &= " - BSP Report"
            Case ExtractType.PTUFile
                sfdPath.Filter = "PTU File|*.ptu"
                sfdPath.DefaultExt = "ptu"

                Me.Text &= " - PTU File"
        End Select
        verification()
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

            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}{1}.xls", selectedDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode

            Case ExtractType.MoneyTransferBSP
                Console.WriteLine("Money Transfer BSP Activated")
                sfdPath.FileName = String.Format("MTBSP{0}{1}.xls", selectedDate.ToString("yyyyMMM"), BranchCode) 'MTBSP + Date + BranchCode

            Case ExtractType.PTUFile
                sfdPath.FileName = String.Format("{1}{0}.PTU", selectedDate.ToString("yyyyMMdd"), BranchCode) 'BranchCode + Date

        End Select
    End Sub

    Private Sub PTU_File()
        If FormType <> ExtractType.PTUFile Then Exit Sub

        If MonCalendar.SelectionRange.Start.ToShortDateString = CurrentDate.ToShortDateString Then
            If frmMain.dateSet Then
                MsgBox("Unable to Generate PTU File yet", MsgBoxStyle.Information, "System")
                Exit Sub
            End If
        End If

        Dim mySql As String, ds As DataSet
        Dim cd As Date = MonCalendar.SelectionRange.Start
        Dim CustomerCode As String = GetOption("CustomerCode")
        Dim header1() As String = {"RecordKey", "CardCode", "DocDate"}
        Dim header2() As String = {"RecordKey", "ItemCode", "ItemName", "Quantity", "Price", "Discount", "WhsCode", _
                                   "OcrCode", "OcrCode2", "OcrCode3", "OcrCode4", "OcrCode5", "TaxCode"}
        Dim header3() As String = {"RecordKey", "ItemCode", "Quantity", "WhsCode", "IntrSerial"}

        mySql = "SELECT T0.DOCDATE, T1.* FROM DOC T0 INNER JOIN DOCLINES T1 ON T0.DOCID = T1.DOCID "
        mySql &= String.Format("WHERE T0.DOCDATE = '{0}' AND T0.STATUS = '1' AND T1.ITEMCODE <> 'RECALL00' AND ", cd.ToString("MM/dd/yyyy"))
        mySql &= String.Format("(T0.DOCTYPE = 0 OR T0.DOCTYPE = 1) AND T0.STATUS <> 'V'", cd.ToString("MM/dd/yyyy"))
        ds = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        'Sheet 1
        Dim oXL As New Excel.Application
        If oXL Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Exit Sub
        End If

        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oXL = CreateObject("Excel.Application")
        oXL.Visible = False

        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet
        'oSheet.Name = ExtractDataFromDatabase.lbltransaction.Text 'Assuming its name is "Sheet 1"

        Dim col As Integer = 1
        For Each hd In header1
            oSheet.Cells(1, col).value = hd
            col += 1
        Next
        oSheet.Cells(2, 1).value = 1
        oSheet.Cells(2, 2).value = CustomerCode
        oSheet.Cells(2, 3).value = cd

        oSheet = oWB.Sheets(2)
        'Sheet 2
        For cnt As Integer = 0 To ds.Tables(0).Rows.Count
            If cnt = 0 Then
                col = 1
                For Each hd In header2
                    oSheet.Cells(cnt + 1, col).value = hd
                    col += 1
                Next
            Else
                With ds.Tables(0).Rows(cnt - 1)
                    oSheet.Cells(cnt + 1, 1).value = 1
                    oSheet.Cells(cnt + 1, 2).value = .Item("ITEMCODE")
                    oSheet.Cells(cnt + 1, 3).value = .Item("DESCRIPTION")
                    oSheet.Cells(cnt + 1, 4).value = .Item("QTY")
                    oSheet.Cells(cnt + 1, 5).value = .Item("SALEPRICE")
                    oSheet.Cells(cnt + 1, 6).value = 0
                    oSheet.Cells(cnt + 1, 7).value = BranchCode
                    oSheet.Cells(cnt + 1, 8).value = AREACODE
                    oSheet.Cells(cnt + 1, 9).value = BranchCode
                    oSheet.Cells(cnt + 1, 10).value = "OPE"
                    oSheet.Cells(cnt + 1, 13).value = "OVAT-E"
                End With
            End If
        Next

        oSheet = oWB.Sheets(3)
        'Sheet 3
        col = 1
        For Each hd In header3
            oSheet.Cells(1, col).value = hd
            col += 1
        Next

        FormInit()

        Dim verified_url As String
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

        Generate_HotCode(security.GetFileMD5(verified_url), True)
        MsgBox("Sales Extracted", MsgBoxStyle.Information)
    End Sub

    ''' <summary>
    ''' This button will extract the desired extract type.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If txtPath.Text = "" Then Exit Sub

        btnExtract.Enabled = False
        If FormType = ExtractType.Expiry Then
            ExtractExpiry()
        ElseIf FormType = ExtractType.MoneyTransferBSP Then
            MoneyTransferBSP()
        ElseIf FormType = ExtractType.PTUFile Then
            PTU_File()
        Else
            Dim ans As MsgBoxResult = _
                MsgBox("We will only use the Starting Date." & vbCrLf & "Do you want to continue?", _
                       vbYesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
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
                sfdPath.FileName = String.Format("{1}{0}.xls", CurrentDate.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Expiry"
            Case ExtractType.JournalEntry
                Console.WriteLine("Journal Entry Type Activated")
                sfdPath.FileName = String.Format("JRNL{0}{1}.xls", CurrentDate.ToString("yyyyMMdd"), BranchCode) 'JRNL + Date + BranchCode
                Me.Text &= " - Journal Entry"
            Case ExtractType.PTUFile
                sfdPath.FileName = String.Format("{0}{1}.PTU", CurrentDate.ToString("yyyyMMdd"), BranchCode) 'BranchCode + Date
                Me.Text &= " - PTU File"
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

        If MonCalendar.SelectionRange.Start.ToShortDateString = CurrentDate.ToShortDateString Then
            If frmMain.dateSet Then
                MsgBox("Unable to Generate Journal File yet", MsgBoxStyle.Information, "System")
                Exit Sub
            End If
        End If

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

        Generate_HotCode(security.GetFileMD5(verified_url))

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

        Dim mySql As String = "SELECT P.*, ITM.ITEMCATEGORY, PITM.ITEMCLASS, C.*, "
         mySql &= "	(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1		"
        mySql &= "	THEN PH.PHONENUMBER WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER		"
        mySql &= "	ELSE NULL END)AS CONTACTNUMBER FROM KYC_PHONE PH LEFT JOIN KYC_CUSTOMERS CC ON CC.ID = PH.CUSTID		"
        mySql &= "	WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' AND PH.ISPRIMARY = 1		"
        mySql &= "	OR CHAR_LENGTH(PH.PHONENUMBER)=11 AND PH.CUSTID =CC.ID ORDER BY PH.ISPRIMARY DESC ROWS 1),		"
        mySql &= "U.USERNAME FROM OPT P "
        mySql &= "INNER JOIN " & CUSTOMER_TABLE & " C on P.clientid = C.ID "
        mySql &= "INNER JOIN tbl_Gamit U on U.USERID = P.ENCODERID "
        mySql &= "INNER JOIN OPI PITM ON PITM.PAWNITEMID = P.PAWNITEMID "
        mySql &= "INNER JOIN TBLITEM ITM ON ITM.ITEMID = PITM.ITEMID "
        mySql &= "WHERE "
        mySql &= "(P.Status = 'L' or P.Status = 'R') AND "
        mySql &= vbCr & String.Format("EXPIRYDATE BETWEEN '{0}' AND '{1}'", GetFirstDate(sd).ToShortDateString, GetLastDate(ed).ToShortDateString)

        Dim ds_expiry As DataSet = LoadSQL(mySql)
        Console.Write(mySql)
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
        For i As Integer = 0 To ds_expiry.Tables(0).Rows.Count - 1
            With ds_expiry.Tables(0).Rows(i)
                oSheet.Cells(rid, 1).value = .Item("PawnID").ToString
                oSheet.Cells(rid, 2).value = .Item("PawnTicket").ToString
                oSheet.Cells(rid, 3).value = .Item("LoanDate").ToString 'TransDate
                oSheet.Cells(rid, 4).value = .Item("FirstName").ToString & _
                    " " & .Item("LastName").ToString 'Pawner
                oSheet.Cells(rid, 5).value = ds_expiry.Tables(0).Rows(i).Item("STREET1").ToString & _
                    " " & ds_expiry.Tables(0).Rows(i).Item("BRGY1").ToString 'Addr1
                oSheet.Cells(rid, 6).value = .Item("CITY1").ToString 'Addr2
                oSheet.Cells(rid, 7).value = .Item("PROVINCE1").ToString 'Addr3
                oSheet.Cells(rid, 8).value = .Item("ZIP1").ToString 'Zip
                oSheet.Cells(rid, 9).value = .Item("ItemCategory").ToString 'ItemCategory
                oSheet.Cells(rid, 11).value = "1" 'NoPCS
                oSheet.Cells(rid, 12).value = .Item("Description").ToString 'DESC1
                oSheet.Cells(rid, 16).value = "0" 'NOMONTH
                oSheet.Cells(rid, 17).value = .Item("MATUDATE").ToString 'MATUDATE
                oSheet.Cells(rid, 18).value = .Item("EXPIRYDATE").ToString 'EXPIDATE
                oSheet.Cells(rid, 19).value = .Item("AUCTIONDATE").ToString 'AUCTDATE
                oSheet.Cells(rid, 21).value = .Item("Appraisal").ToString 'APPRAISAL
                oSheet.Cells(rid, 22).value = .Item("Principal").ToString 'PRINCIPAL
                oSheet.Cells(rid, 23).value = .Item("DelayInterest").ToString 'INT_AMOUNT
                oSheet.Cells(rid, 24).value = .Item("ServiceCharge").ToString 'SRV_CHARGE
                oSheet.Cells(rid, 27).value = .Item("NetAmount").ToString 'NET_AMOUNT
                oSheet.Cells(rid, 28).value = .Item("Username").ToString 'USER
                oSheet.Cells(rid, 29).value = .Item("Status").ToString 'STATUS
                oSheet.Cells(rid, 31).value = .Item("OLDTICKET").ToString 'OLD NUM
                oSheet.Cells(rid, 32).value = .Item("ORNUM").ToString 'RCT NO
                oSheet.Cells(rid, 39).value = "'" & .Item("CONTACTNUMBER").ToString 'PHONE_NO
                oSheet.Cells(rid, 40).value = .Item("BIRTHDAY").ToString 'BIRTHDAY
                oSheet.Cells(rid, 41).value = .Item("GENDER").ToString 'SEX
                oSheet.Cells(rid, 45).value = .Item("APPRAISAL").ToString 'APPRAISAL1
                oSheet.Cells(rid, 48).value = .Item("ITEMCLASS").ToString 'ITEMDESC
            End With

            rid += 1
            AddProgress()
            Application.DoEvents()
        Next

        FormInit()

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

    Private Sub Generate_HotCode(ByVal Hash As String, Optional ByVal forPTU As Boolean = False)
        Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

        If Not File.Exists(path) Then
            ' Create a file to write to. 
            If Not forPTU Then
                Using sw As StreamWriter = File.CreateText(path & String.Format("\JRNL{0}{1}_HotCode.txt", MonCalendar.SelectionStart.ToString("yyyyMMdd"), BranchCode))
                    sw.WriteLine("HOT CODE")
                    sw.WriteLine(Hash)

                End Using
            Else
                Using sw As StreamWriter = File.CreateText(path & String.Format("\{1}{0}_HotCode.txt", MonCalendar.SelectionStart.ToString("yyyyMMdd"), BranchCode))
                    sw.WriteLine("HOT CODE")
                    sw.WriteLine(Hash)
                End Using
            End If
        End If
    End Sub

    Private Sub verification()
        If accessType = "Read Only" Then
            btnExtract.Enabled = False
        End If
    End Sub
End Class