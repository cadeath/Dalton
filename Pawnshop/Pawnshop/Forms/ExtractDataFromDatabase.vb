Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Imports System.IO
Imports System.IO.Compression

Imports ICSharpCode.SharpZipLib.Core
Imports ICSharpCode.SharpZipLib.Zip


Public Class ExtractDataFromDatabase

    Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

    Enum ReportType As Integer
        Pawning = 0
        Moneytransfer = 1
        Insurance = 2
        Borrowing = 3
        DollarBuying = 4
    End Enum
    Friend FormType As ReportType = ReportType.Pawning
  
    Private Sub ExtractDataFromDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtPath1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        txtPath.Text =readValue
    End Sub

#Region "Extract Database Table"

    Private Sub PawningExtract()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        'Dim str As String = "Pawning"
        'sfdPath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
        Dim mySql As String
        mySql = " SELECT P.ADVINT,P.APPRAISAL,G.FULLNAME AS APPRAISER," & _
        vbCrLf & "P.AUCTIONDATE,CLASS.CATEGORY,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, " & _
        vbCrLf & " P.DAYSOVERDUE, P.DELAYINT, P.DESCRIPTION,P.EARLYREDEEM ,P.ENCODERID, P.EVAT, " & _
        vbCrLf & "P.EXPIRYDATE, P.GRAMS,P.INTEREST, P.ITEMTYPE, P.KARAT," & _
        vbCrLf & " P.LESSPRINCIPAL, P.LOANDATE ,P.MATUDATE, P.NETAMOUNT," & _
        vbCrLf & " P.OLDTICKET, P.ORDATE, P.ORNUM, P.PAWNID, P.PAWNTICKET,	" & _
        vbCrLf & " P.PENALTY, P.PRINCIPAL, P.PULLOUT, P.REDEEMDUE	,P.RENEWDUE," & _
        vbCrLf & " P.SERVICECHARGE," & _
        vbCrLf & "Case P.STATUS" & _
        vbCrLf & " WHEN '0' THEN 'RENEWED' WHEN 'R' THEN 'RENEW' " & _
        vbCrLf & "WHEN 'L' THEN 'NEW' WHEN 'V' THEN 'VOID' WHEN 'W' THEN 'WITHDRAW' " & _
        vbCrLf & "WHEN 'X' THEN 'REDEEM' WHEN 'S' THEN 'SEGRE' " & _
        vbCrLf & "ELSE 'N/A' END AS STATUS,P.SYSTEMINFO" & _
        vbCrLf & "FROM TBLPAWN P" & _
        vbCrLf & "INNER JOIN TBLCLASS CLASS" & _
        vbCrLf & "ON CLASS.CLASSID = P.CATID" & _
        vbCrLf & "INNER JOIN TBL_GAMIT G" & _
        vbCrLf & "ON G.USERID = P.APPRAISERID" & _
        vbCrLf & "INNER JOIN TBLCLIENT C" & _
        vbCrLf & "ON C.CLIENTID =P.CLIENTID" & _
        vbCrLf & String.Format(" WHERE LOANDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
        vbCrLf & "AND ORDATE <> '01/01/0001'" & _
        vbCrLf & "ORDER BY P.LOANDATE ASC;"

        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/PAWNING.xls")
        oSheet = oWB.Worksheets(1)


        oSheet = oWB.Worksheets(1)
        pbLoading.Maximum = MaxEntries
        pbLoading.Value = 0

        Dim recCnt2 As Single = 0
        While recCnt2 < MaxEntries
            With ds.Tables(0).Rows(recCnt2)

                oSheet.Cells(lineNum + 2, 1) = .Item("ADVINT").ToString
                oSheet.Cells(lineNum + 2, 2) = .Item("APPRAISAL")
                oSheet.Cells(lineNum + 2, 3) = .Item("APPRAISER")
                oSheet.Cells(lineNum + 2, 4) = .Item("AUCTIONDATE")
                oSheet.Cells(lineNum + 2, 5) = .Item("CATEGORY")
                oSheet.Cells(lineNum + 2, 6) = .Item("CLIENT")
                oSheet.Cells(lineNum + 2, 7) = .Item("DAYSOVERDUE")
                oSheet.Cells(lineNum + 2, 8) = .Item("DELAYINT")
                oSheet.Cells(lineNum + 2, 9) = .Item("DESCRIPTION")
                oSheet.Cells(lineNum + 2, 10) = .Item("EARLYREDEEM")
                oSheet.Cells(lineNum + 2, 11) = .Item("ENCODERID")
                oSheet.Cells(lineNum + 2, 12) = .Item("EVAT")
                oSheet.Cells(lineNum + 2, 13) = .Item("EXPIRYDATE")
                oSheet.Cells(lineNum + 2, 14) = .Item("GRAMS")
                oSheet.Cells(lineNum + 2, 15) = .Item("INTEREST")
                ' oSheet.Cells(lineNum + 2, 16) = .Item("INT_CHECKSUM")
                oSheet.Cells(lineNum + 2, 16) = .Item("ITEMTYPE")
                oSheet.Cells(lineNum + 2, 17) = .Item("KARAT")
                oSheet.Cells(lineNum + 2, 18) = .Item("LESSPRINCIPAL")
                oSheet.Cells(lineNum + 2, 19) = .Item("LOANDATE")
                oSheet.Cells(lineNum + 2, 20) = .Item("MATUDATE")
                oSheet.Cells(lineNum + 2, 21) = .Item("NETAMOUNT")
                oSheet.Cells(lineNum + 2, 22) = .Item("OLDTICKET")
                oSheet.Cells(lineNum + 2, 23) = .Item("ORDATE")
                oSheet.Cells(lineNum + 2, 24) = .Item("ORNUM")
                oSheet.Cells(lineNum + 2, 25) = .Item("PAWNID")
                oSheet.Cells(lineNum + 2, 26) = .Item("PAWNTICKET")
                oSheet.Cells(lineNum + 2, 27) = .Item("PENALTY")
                oSheet.Cells(lineNum + 2, 28) = .Item("PRINCIPAL")
                oSheet.Cells(lineNum + 2, 29) = .Item("PULLOUT")
                oSheet.Cells(lineNum + 2, 30) = .Item("REDEEMDUE")
                oSheet.Cells(lineNum + 2, 31) = .Item("RENEWDUE")
                oSheet.Cells(lineNum + 2, 32) = .Item("SERVICECHARGE")
                oSheet.Cells(lineNum + 2, 33) = .Item("STATUS")
                'oSheet.Cells(lineNum + 2, 35) = .Item("SYSTEMINFO")
                lineNum += 1
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String
        Console.WriteLine("Pawning Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, "Pawning")  'BranchCode + Date

        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName


            oWB.SaveAs(verified_url)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            txtpath1.Text = txtpath1.Text
            Using sw As StreamWriter = File.CreateText("Extract.bat")
                sw.WriteLine("@echo off")
                sw.WriteLine("title cdt-S0ft - Extract")
                sw.WriteLine("echo Extracting. . .")
                sw.WriteLine("pause")
                sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
                sw.WriteLine("rar a " & txtpath1.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " rar a -ep -hp" & BranchCode & "MIS -m0")
                sw.WriteLine("cls ")
                sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
                sw.WriteLine("pause")
                sw.WriteLine("exit")
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proc As Process = Nothing
            Try
                Dim batDir As String = String.Format(readValue)
                proc = New Process()
                proc.StartInfo.WorkingDirectory = batDir
                proc.StartInfo.FileName = "Extract.bat"
                proc.StartInfo.CreateNoWindow = False
                proc.Start()
                proc.WaitForExit()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace.ToString())
            End Try
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If System.IO.File.Exists(verified_url) = True Then
            System.IO.File.Delete(verified_url)
        End If
        MsgBox("Pawning Extracted", MsgBoxStyle.Information)
        MsgBox("Thank you. . .", MsgBoxStyle.Information)
    End Sub

    Private Sub DollarExtract()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)


        'sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date

        Dim mySql As String
        mySql = "SELECT D.CLIENTID,D.DENOMINATION,D.DOLLARID,D.FULLNAME," & _
        vbCrLf & "D.NETAMOUNT,D.PESORATE, D.REMARKS,D.SERIAL," & _
        vbCrLf & "Case D.STATUS" & _
        vbCrLf & "WHEN 'A' THEN 'ACTIVE'  WHEN 'V' THEN 'VOID'  ELSE 'N/A'  " & _
        vbCrLf & "END AS STATUS, D.SYSTEMINFO, D.TRANSDATE, D.USERID " & _
        vbCrLf & "FROM TBLDOLLAR D" & _
        vbCrLf & String.Format(" WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
        vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/DOLLAR.xls")
        oSheet = oWB.Worksheets(1)


        oSheet = oWB.Worksheets(1)
        pbLoading.Maximum = MaxEntries
        pbLoading.Value = 0

        Dim recCnt2 As Single = 0
        While recCnt2 < MaxEntries
            With ds.Tables(0).Rows(recCnt2)

                oSheet.Cells(lineNum + 2, 1) = .Item("CLIENTID").ToString
                oSheet.Cells(lineNum + 2, 2) = .Item("DENOMINATION")
                oSheet.Cells(lineNum + 2, 3) = .Item("DOLLARID")
                oSheet.Cells(lineNum + 2, 4) = .Item("FULLNAME")
                oSheet.Cells(lineNum + 2, 5) = .Item("NETAMOUNT")
                oSheet.Cells(lineNum + 2, 6) = .Item("PESORATE")
                oSheet.Cells(lineNum + 2, 7) = .Item("REMARKS")
                oSheet.Cells(lineNum + 2, 8) = .Item("SERIAL")
                oSheet.Cells(lineNum + 2, 9) = .Item("STATUS")
                oSheet.Cells(lineNum + 2, 10) = .Item("SYSTEMINFO")
                oSheet.Cells(lineNum + 2, 11) = .Item("TRANSDATE")
                oSheet.Cells(lineNum + 2, 12) = .Item("USERID")

                lineNum += 1
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String

        Dim str As String = "Dollar"
        Console.WriteLine("Dollar Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date


        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName


            oWB.SaveAs(verified_url)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            txtpath1.Text = txtpath1.Text
            Using sw As StreamWriter = File.CreateText("Extract.bat")
                sw.WriteLine("@echo off")
                sw.WriteLine("title cdt-S0ft - Extract")
                sw.WriteLine("echo Extracting. . .")
                sw.WriteLine("pause")
                sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
                sw.WriteLine("rar a " & txtpath1.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " rar a -ep -hp" & BranchCode & "MIS -m0")
                sw.WriteLine("cls ")
                sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
                sw.WriteLine("pause")
                sw.WriteLine("exit")
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proc As Process = Nothing
            Try
                Dim batDir As String = String.Format(readValue)
                proc = New Process()
                proc.StartInfo.WorkingDirectory = batDir
                proc.StartInfo.FileName = "Extract.bat"
                proc.StartInfo.CreateNoWindow = False
                proc.Start()
                proc.WaitForExit()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace.ToString())
            End Try
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If System.IO.File.Exists(verified_url) = True Then
            System.IO.File.Delete(verified_url)
        End If
        MsgBox("Dollar Extracted", MsgBoxStyle.Information)
        MsgBox("Thank you...", MsgBoxStyle.Information)
    End Sub

    Private Sub BorrowingExtract()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        'sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, Str)  'BranchCode + Date

        Dim mySql As String
        mySql = "SELECT B.AMOUNT, B.BRANCHCODE, B.BRANCHNAME, " & _
        vbCrLf & "B.BRWID,  G.FULLNAME,B.REASON,B.REFNUM, B.REMARKS," & _
        vbCrLf & " Case B.STATUS" & _
        vbCrLf & "WHEN 'C' THEN 'CASH-OUT'" & _
        vbCrLf & "WHEN 'D' THEN 'CASH-IN'" & _
        vbCrLf & "ELSE 'N/A' END AS STATUS, B.SYSTEMINFO, B.TRANSDATE" & _
        vbCrLf & "FROM TBLBORROW B" & _
        vbCrLf & "INNER JOIN TBL_GAMIT G ON G.ENCODERID = B.ENCODERID" & _
        vbCrLf & String.Format(" WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
        vbCrLf & "ORDER BY TRANSDATE ASC"


        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/BROWWINGS.xls")
        oSheet = oWB.Worksheets(1)


        oSheet = oWB.Worksheets(1)
        pbLoading.Maximum = MaxEntries
        pbLoading.Value = 0

        Dim recCnt2 As Single = 0
        While recCnt2 < MaxEntries
            With ds.Tables(0).Rows(recCnt2)
                oSheet.Cells(lineNum + 2, 1) = .Item("AMOUNT").ToString
                oSheet.Cells(lineNum + 2, 2) = .Item("BRANCHCODE")
                oSheet.Cells(lineNum + 2, 3) = .Item("BRANCHNAME")
                oSheet.Cells(lineNum + 2, 4) = .Item("BRWID")
                oSheet.Cells(lineNum + 2, 5) = .Item("FULLNAME")
                oSheet.Cells(lineNum + 2, 6) = .Item("REASON")
                oSheet.Cells(lineNum + 2, 7) = .Item("REFNUM")
                oSheet.Cells(lineNum + 2, 8) = .Item("REMARKS")
                oSheet.Cells(lineNum + 2, 9) = .Item("STATUS")
                oSheet.Cells(lineNum + 2, 10) = .Item("SYSTEMINFO")
                oSheet.Cells(lineNum + 2, 11) = .Item("TRANSDATE")

                lineNum += 1
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

        Dim str As String = "Borrowings"
        Dim verified_url As String
        Console.WriteLine("Borrowing Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        txtpath1.Text = txtpath1.Text

        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName


            oWB.SaveAs(verified_url)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing
            txtpath1.Text = txtpath1.Text
            Using sw As StreamWriter = File.CreateText("Extract.bat")
                sw.WriteLine("@echo off")
                sw.WriteLine("title cdt-S0ft - Extract")
                sw.WriteLine("echo Extracting. . .")
                sw.WriteLine("pause")
                sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
                sw.WriteLine("rar a " & txtpath1.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " rar a -ep -hp" & BranchCode & "MIS -m0")
                sw.WriteLine("cls ")
                sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
                sw.WriteLine("pause")
                sw.WriteLine("exit")
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proc As Process = Nothing
            Try
                Dim batDir As String = String.Format(readValue)
                proc = New Process()
                proc.StartInfo.WorkingDirectory = batDir
                proc.StartInfo.FileName = "Extract.bat"
                proc.StartInfo.CreateNoWindow = False
                proc.Start()
                proc.WaitForExit()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace.ToString())
            End Try
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If System.IO.File.Exists(verified_url) = True Then
            System.IO.File.Delete(verified_url)
        End If
        MsgBox("Borrowing Extracted", MsgBoxStyle.Information)
        MsgBox("Thank you. . .", MsgBoxStyle.Information)
    End Sub

    Private Sub InsuranceExtract()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        'sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date

        Dim mySql As String
        mySql = " SELECT I.AMOUNT, I.CLIENTID,I.CLIENTNAME, I.COINO, G.FULLNAME AS ENCODER, I.INSURANCEID,I.PAWNTICKET, " & _
            vbCrLf & "Case I.STATUS " & _
            vbCrLf & "WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' ELSE 'N/A'  END AS STATUS," & _
            vbCrLf & "I.SYSTEMINFO, I.TRANSDATE, I.VALIDDATE FROM TBLINSURANCE I" & _
            vbCrLf & "INNER JOIN TBL_GAMIT G ON G.ENCODERID = I.ENCODERID" & _
            vbCrLf & String.Format("WHERE I.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
            vbCrLf & "ORDER BY TRANSDATE ASC"


        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/INSURANCE.xls")
        oSheet = oWB.Worksheets(1)


        oSheet = oWB.Worksheets(1)
        pbLoading.Maximum = MaxEntries
        pbLoading.Value = 0

        Dim recCnt2 As Single = 0
        While recCnt2 < MaxEntries
            With ds.Tables(0).Rows(recCnt2)

                oSheet.Cells(lineNum + 2, 1) = .Item("AMOUNT").ToString
                oSheet.Cells(lineNum + 2, 2) = .Item("CLIENTID")
                oSheet.Cells(lineNum + 2, 3) = .Item("CLIENTNAME")
                oSheet.Cells(lineNum + 2, 4) = .Item("COINO")
                oSheet.Cells(lineNum + 2, 5) = .Item("ENCODER")
                oSheet.Cells(lineNum + 2, 6) = .Item("INSURANCEID")
                oSheet.Cells(lineNum + 2, 7) = .Item("PAWNTICKET")
                oSheet.Cells(lineNum + 2, 8) = .Item("STATUS")
                oSheet.Cells(lineNum + 2, 9) = .Item("SYSTEMINFO")
                oSheet.Cells(lineNum + 2, 10) = .Item("TRANSDATE")
                oSheet.Cells(lineNum + 2, 11) = .Item("VALIDDATE")

                lineNum += 1
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String
        Dim str As String = "Insurance"

        Console.WriteLine("Insurance Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        txtpath1.Text = txtpath1.Text

        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName


            oWB.SaveAs(verified_url)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            txtpath1.Text = txtpath1.Text
            Using sw As StreamWriter = File.CreateText("Extract.bat")
                sw.WriteLine("@echo off")
                sw.WriteLine("title cdt-S0ft - Extract")
                sw.WriteLine("echo Extracting. . .")
                sw.WriteLine("pause")
                sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
                sw.WriteLine("rar a " & txtpath1.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " rar a -ep -hp" & BranchCode & "MIS -m0")
                sw.WriteLine("cls ")
                sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
                sw.WriteLine("pause")
                sw.WriteLine("exit")
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proc As Process = Nothing
            Try
                Dim batDir As String = String.Format(readValue)
                proc = New Process()
                proc.StartInfo.WorkingDirectory = batDir
                proc.StartInfo.FileName = "Extract.bat"
                proc.StartInfo.CreateNoWindow = False
                proc.Start()
                proc.WaitForExit()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace.ToString())
            End Try
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If System.IO.File.Exists(verified_url) = True Then
            System.IO.File.Delete(verified_url)
        End If

        MsgBox("Insurance Extracted", MsgBoxStyle.Information)
        MsgBox("Thank you. . .", MsgBoxStyle.Information)
    End Sub

    Private Sub RemitanceExtract()
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        ' sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, srt)  'BranchCode + Date


        Dim mySql As String
        mySql = "SELECT M.AMOUNT, M.COMMISSION,G.FULLNAME AS ENCODER,M.ID, M.LOCATION," & _
        vbCrLf & "Case M.MONEYTRANS" & _
        vbCrLf & "WHEN 0 THEN 'SENDIN' WHEN 1 THEN 'PAYOUT' ELSE 'NA'" & _
        vbCrLf & "END AS MONEYTRANS,M.NETAMOUNT,M.RECEIVERID,M.RECEIVERNAME, " & _
        vbCrLf & "CASE WHEN M.ServiceType = 'Pera Padala' AND M.MoneyTrans = 0" & _
        vbCrLf & "THEN 'ME# ' || LPAD(M.TransID,5,0)" & _
        vbCrLf & "WHEN M.SERVICETYPE = 'Pera Padala' AND M.MONEYTRANS = 1" & _
        vbCrLf & "THEN 'MR# ' || LPAD(M.TRANSID,5,0)" & _
        vbCrLf & "ELSE RefNum END as RefNum," & _
        vbCrLf & "M.REMARKS," & _
        vbCrLf & " M.SENDERID,M.SENDERNAME,M.SERVICECHARGE, " & _
        vbCrLf & "M.SERVICETYPE, " & _
        vbCrLf & "Case M.STATUS" & _
        vbCrLf & "WHEN 'A' THEN 'ACTIVE'" & _
        vbCrLf & "  WHEN 'V' THEN 'VOID'" & _
        vbCrLf & " ELSE 'N/A'" & _
        vbCrLf & " END AS STATUS, M.SYSTEMINFO, M.TRANSDATE," & _
        vbCrLf & " M.TRANSID" & _
        vbCrLf & " FROM TBLMONEYTRANSFER M" & _
        vbCrLf & " INNER JOIN TBL_GAMIT G ON G.ENCODERID = M.ENCODERID" & _
        vbCrLf & "INNER JOIN TBLCLIENT C ON  M.SENDERID = C.CLIENTID" & _
        vbCrLf & "INNER JOIN TBLCLIENT R ON  M.RECEIVERID = R.CLIENTID" & _
        vbCrLf & String.Format("WHERE M.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
        vbCrLf & " ORDER BY M.TRANSDATE;"

        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/REMITTANCE.xls")
        oSheet = oWB.Worksheets(1)


        oSheet = oWB.Worksheets(1)
        pbLoading.Maximum = MaxEntries
        pbLoading.Value = 0

        Dim recCnt2 As Single = 0
        While recCnt2 < MaxEntries
            With ds.Tables(0).Rows(recCnt2)

                oSheet.Cells(lineNum + 2, 1) = .Item("AMOUNT").ToString
                oSheet.Cells(lineNum + 2, 2) = .Item("COMMISSION")
                oSheet.Cells(lineNum + 2, 3) = .Item("ENCODER")
                oSheet.Cells(lineNum + 2, 4) = .Item("ID")
                oSheet.Cells(lineNum + 2, 5) = .Item("LOCATION")
                oSheet.Cells(lineNum + 2, 6) = .Item("MONEYTRANS")
                oSheet.Cells(lineNum + 2, 7) = .Item("NETAMOUNT")
                oSheet.Cells(lineNum + 2, 8) = .Item("RECEIVERID")
                oSheet.Cells(lineNum + 2, 9) = .Item("RECEIVERNAME")
                oSheet.Cells(lineNum + 2, 10) = .Item("REFNUM")
                oSheet.Cells(lineNum + 2, 11) = .Item("REMARKS")
                oSheet.Cells(lineNum + 2, 12) = .Item("SENDERID")
                oSheet.Cells(lineNum + 2, 13) = .Item("SENDERNAME")
                oSheet.Cells(lineNum + 2, 14) = .Item("SERVICECHARGE")
                oSheet.Cells(lineNum + 2, 15) = .Item("SERVICETYPE")
                oSheet.Cells(lineNum + 2, 16) = .Item("STATUS")
                oSheet.Cells(lineNum + 2, 17) = .Item("SYSTEMINFO")
                oSheet.Cells(lineNum + 2, 18) = .Item("TRANSDATE")
                oSheet.Cells(lineNum + 2, 19) = .Item("TRANSID")
                lineNum += 1
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String
        Dim str As String = "Remitance"

        sfdPath.FileName = String.Format("{2}{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date

        If txtPath.Text.Split(".").Count > 1 Then
            If txtPath.Text.Split(".")(1).Length = 3 Then
                verified_url = txtPath.Text
            Else
                verified_url = txtPath.Text & "/" & sfdPath.FileName
            End If
        Else
            verified_url = txtPath.Text & "/" & sfdPath.FileName


            oWB.SaveAs(verified_url)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            txtpath1.Text = txtpath1.Text
            Using sw As StreamWriter = File.CreateText("Extract.bat")
                sw.WriteLine("@echo off")
                sw.WriteLine("title cdt-S0ft - Extract")
                sw.WriteLine("echo Extracting. . .")
                sw.WriteLine("pause")
                sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
                sw.WriteLine("rar a " & txtpath1.Text & "\" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " rar a -ep -hp" & BranchCode & "MIS -m0")
                sw.WriteLine("cls ")
                sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
                sw.WriteLine("pause")
                sw.WriteLine("exit")
            End Using
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
            Dim proc As Process = Nothing
            Try
                Dim batDir As String = String.Format(readValue)
                proc = New Process()
                proc.StartInfo.WorkingDirectory = batDir
                proc.StartInfo.FileName = "Extract.bat"
                proc.StartInfo.CreateNoWindow = False
                proc.Start()
                proc.WaitForExit()
            Catch ex As Exception
                Console.WriteLine(ex.StackTrace.ToString())
            End Try
        End If
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        If System.IO.File.Exists(verified_url) = True Then
            System.IO.File.Delete(verified_url)
        End If
        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        MsgBox("Remitance Extracted", MsgBoxStyle.Information)
        MsgBox("Thank you...", MsgBoxStyle.Information)
    End Sub
#End Region

    Private Sub AddProgress()
        pbLoading.Value += 1
    End Sub

    Private Sub txtPath_DoubleClick(sender As System.Object, e As System.EventArgs) Handles txtPath.DoubleClick
        sfdPath.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        Dim result As DialogResult = sfdPath.ShowDialog

        If Not result = Windows.Forms.DialogResult.OK Then
            Return
        End If
        txtPath.Text = sfdPath.FileName
    End Sub

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        If cboExtract.Text = "" And cboExtract.Visible Then Exit Sub

        If cboExtract.Visible Then
            Select Case cboExtract.Text
                Case "Pawning"
                    FormType = ReportType.Pawning
                Case "Dollar"
                    FormType = ReportType.DollarBuying
                Case "Borrowing"
                    FormType = ReportType.Insurance
                Case "Dollar Buying"
                    FormType = ReportType.DollarBuying
                Case "Branch Borrowings"
                    FormType = ReportType.Borrowing
                Case "Remitance"
                    FormType = ReportType.Moneytransfer
            End Select
        End If

        Generate()
    End Sub

    Private Sub Generate()
        Select Case FormType
            Case ReportType.Pawning
                PawningExtract()
            Case ReportType.DollarBuying
                DollarExtract()
            Case ReportType.Borrowing
                BorrowingExtract()
            Case ReportType.Insurance
                InsuranceExtract()
            Case ReportType.DollarBuying
                DollarExtract()
            Case ReportType.Moneytransfer
                RemitanceExtract()
        End Select
    End Sub
End Class