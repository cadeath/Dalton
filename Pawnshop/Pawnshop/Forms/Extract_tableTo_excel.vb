Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Public Class Extract_tableTo_excel
    Enum ExtractType As Integer
        Pawn = 0
        Dollar = 1
        Borrowing = 2

    End Enum
    Friend FormType As ExtractType = ExtractType.Pawn

    Private Sub Extract_tableTo_excel_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        FormInit()
        txtPath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub FormInit()
        Dim selectedDate As Date = MonCalendar.SelectionStart
        Select Case FormType
            Case ExtractType.Pawn
                Console.WriteLine("Pawning Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", selectedDate.ToString("MMddyyyy"), "Pawn")  'BranchCode + Date
                Me.Text &= " - Pawning"
            Case ExtractType.Dollar
                Console.WriteLine("Dollar Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", selectedDate.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Dollar"
            Case ExtractType.Dollar
                Console.WriteLine("Borrowing Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", selectedDate.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Borrowing"
        End Select
    End Sub

    Private Sub btnPawnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnPawnExtract.Click
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)
        Dim mySql As String
        mySql = " SELECT P.ADVINT,P.APPRAISAL,G.FULLNAME AS APPRAISER," & _
    vbCrLf & "P.AUCTIONDATE,CLASS.CATEGORY,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, " & _
    vbCrLf & " P.DAYSOVERDUE, P.DELAYINT, P.DESCRIPTION,P.EARLYREDEEM ,P.ENCODERID, P.EVAT, " & _
     vbCrLf & "P.EXPIRYDATE, P.GRAMS,P.INTEREST,P.INT_CHECKSUM, P.ITEMTYPE, P.KARAT," & _
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
                oSheet.Cells(lineNum + 2, 16) = .Item("INT_CHECKSUM")
                oSheet.Cells(lineNum + 2, 17) = .Item("ITEMTYPE")
                oSheet.Cells(lineNum + 2, 18) = .Item("KARAT")
                oSheet.Cells(lineNum + 2, 19) = .Item("LESSPRINCIPAL")
                oSheet.Cells(lineNum + 2, 20) = .Item("LOANDATE")
                oSheet.Cells(lineNum + 2, 21) = .Item("MATUDATE")
                oSheet.Cells(lineNum + 2, 22) = .Item("NETAMOUNT")
                oSheet.Cells(lineNum + 2, 23) = .Item("OLDTICKET")
                oSheet.Cells(lineNum + 2, 24) = .Item("ORDATE")
                oSheet.Cells(lineNum + 2, 25) = .Item("ORNUM")
                oSheet.Cells(lineNum + 2, 26) = .Item("PAWNID")
                oSheet.Cells(lineNum + 2, 27) = .Item("PAWNTICKET")
                oSheet.Cells(lineNum + 2, 28) = .Item("PENALTY")
                oSheet.Cells(lineNum + 2, 29) = .Item("PRINCIPAL")
                oSheet.Cells(lineNum + 2, 30) = .Item("PULLOUT")
                oSheet.Cells(lineNum + 2, 31) = .Item("REDEEMDUE")
                oSheet.Cells(lineNum + 2, 32) = .Item("RENEWDUE")
                oSheet.Cells(lineNum + 2, 33) = .Item("SERVICECHARGE")
                oSheet.Cells(lineNum + 2, 34) = .Item("STATUS")
                oSheet.Cells(lineNum + 2, 35) = .Item("SYSTEMINFO")
                lineNum += 1
                recCnt2 += 1
            End With
            AddProgress()
            Application.DoEvents()
        End While

        Dim verified_url As String

        Select Case FormType
            Case ExtractType.Pawn
                Console.WriteLine("Pawning Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Pawning"
        End Select


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

        MsgBox("Pawning Extracted", MsgBoxStyle.Information)
    End Sub


        Private Sub AddProgress()
            pbLoading.Value += 1
        End Sub

    Private Sub btnDollarExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnDollarExtract.Click
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String
        mySql = "SELECT D.CLIENTID,D.DENOMINATION,D.DOLLARID,D.FULLNAME," & _
   vbCrLf & "D.NETAMOUNT,D.PESORATE, D.REMARKS,D.SERIAL," & _
            vbCrLf & "Case D.STATUS" & _
    vbCrLf & "WHEN 'A' THEN 'ACTIVE'  WHEN 'V' THEN 'VOID'  ELSE 'N/A'  " & _
    vbCrLf & "END AS STATUS, D.SYSTEMINFO, D.TRANSDATE, D.USERID " & _
    vbCrLf & "FROM TBLDOLLAR D" & _
    vbCrLf & String.Format(" WHERE TRANSDATE = '{0}'", MonCalendar.SelectionStart.ToShortDateString) & _
    vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxEntries As Integer = 0
        MaxEntries = ds.Tables(0).Rows.Count


        'Load Excel
        Dim oXL As New Excel.Application
        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/Dollar.xls")
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

        Select Case FormType
            Case ExtractType.Dollar
                Console.WriteLine("Dollar Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Pawning"

        End Select


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

        MsgBox("Dollar Extracted", MsgBoxStyle.Information)

    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String
        mySql = "SELECT B.AMOUNT, B.BRANCHCODE, B.BRANCHNAME, " & _
         vbCrLf & "B.BRWID,  G.FULLNAME,B.REASON,B.REFNUM, B.REMARKS," & _
             vbCrLf & " Case B.STATUS" & _
     vbCrLf & "WHEN 'C' THEN 'CASH-OUT'" & _
     vbCrLf & "WHEN 'D' THEN 'CASH-IN'" & _
     vbCrLf & "ELSE 'N/A' END AS STATUS, B.SYSTEMINFO, B.TRANSDATE" & _
     vbCrLf & "FROM TBLBORROW B" & _
    vbCrLf & "INNER JOIN TBL_GAMIT G ON G.ENCODERID = B.ENCODERID;"

                Dim ds As DataSet = LoadSQL(mySql)
                Dim MaxEntries As Integer = 0
                MaxEntries = ds.Tables(0).Rows.Count


                'Load Excel
                Dim oXL As New Excel.Application
                Dim oWB As Excel.Workbook
                Dim oSheet As Excel.Worksheet

                oWB = oXL.Workbooks.Open(Application.StartupPath & "/doc/Dollar.xls")
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

                Dim verified_url As String

                Select Case FormType
                    Case ExtractType.Dollar
                        Console.WriteLine("Borrowing Activated")
                sfdPath.FileName = String.Format("{1}{0}.xls", sd.ToString("MMddyyyy"), BranchCode)  'BranchCode + Date
                Me.Text &= " - Borrowing"

                End Select


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

                MsgBox("Borrowing Extracted", MsgBoxStyle.Information)

    End Sub
End Class