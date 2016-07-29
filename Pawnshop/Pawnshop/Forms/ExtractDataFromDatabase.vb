Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Imports System.IO
Imports System.IO.Compression


Public Class ExtractDataFromDatabase
    Dim ExtractType As String
    Const batch As String = "\Extract.bat"
    Dim result As String = Path.GetTempPath()
    Dim appPath As String = Application.StartupPath
    Dim verified_url As String

    Private Sub ExtractDataFromDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpath1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        lblTransactioName.Visible = False
    End Sub

#Region "Extract Database Table Monthly"

    Private Sub PawningExtract()

        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = " SELECT P.ADVINT,P.APPRAISAL,G.FULLNAME AS APPRAISER,"
        mySql &= "P.AUCTIONDATE,CLASS.CATEGORY,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, "
        mySql &= " P.DAYSOVERDUE, P.DELAYINT, P.DESCRIPTION,P.EARLYREDEEM ,P.ENCODERID, P.EVAT, "
        mySql &= "P.EXPIRYDATE, P.GRAMS,P.INTEREST, P.ITEMTYPE, P.KARAT,"
        mySql &= " P.LESSPRINCIPAL, P.LOANDATE ,P.MATUDATE, P.NETAMOUNT, "
        mySql &= "Case "
        mySql &= "WHEN P.ORDATE = '01/01/0001' THEN ''"
        mySql &= "ELSE P.ORDATE END AS ORDATE,"
        mySql &= " P.ORNUM, P.PAWNID, P.PAWNTICKET,	"
        mySql &= " P.PENALTY, P.PRINCIPAL, P.PULLOUT, P.REDEEMDUE	,P.RENEWDUE,"
        mySql &= " P.SERVICECHARGE,"
        mySql &= "Case P.STATUS"
        mySql &= " WHEN '0' THEN 'RENEWED' WHEN 'R' THEN 'RENEW' "
        mySql &= "WHEN 'L' THEN 'NEW' WHEN 'V' THEN 'VOID' WHEN 'W' THEN 'WITHDRAW' "
        mySql &= "WHEN 'X' THEN 'REDEEM' WHEN 'S' THEN 'SEGRE' "
        mySql &= "ELSE 'N/A' END AS STATUS,P.SYSTEMINFO "
        mySql &= "FROM TBLPAWN P "
        mySql &= "INNER JOIN TBLCLASS CLASS "
        mySql &= "ON CLASS.CLASSID = P.CATID "
        mySql &= "LEFT JOIN TBL_GAMIT G "
        mySql &= "ON G.USERID = P.APPRAISERID "
        mySql &= "INNER JOIN TBLCLIENT C "
        mySql &= "ON C.CLIENTID =P.CLIENTID "
        mySql &= String.Format(" WHERE LOANDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= "ORDER BY P.LOANDATE ASC;"

        Dim headers() As String = _
           {"ADVINT", "APPRAISAL", "APPRAISER", "AUCTIONDATE", "CATEGORY", "CLIENT", "DAYSOVERDUE", _
            "DELAYINT", "DESCRIPTION", "EARLYREDEEM", "ENCODERID", "EVAT", "EXPIRYDATE", "GRAMS", "INTEREST", "ITEMTYPE", _
            "KARAT", "LESSPRINCIPAL", "LOANDATE", "MATUDATE", "NETAMOUNT", "OLDTICKET", "ORDATE", "ORNUM", "PAWNID", _
            "PAWNTICKET", "PENALTY", "PRINCIPAL", "PULLOUT", "REDEEMDUE", "RENEWDUE", "SERVICECHARGE", "STATUS"}



        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, "Pawning")  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using

        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

    End Sub

    Private Sub DollarExtract()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT D.CLIENTID,D.DENOMINATION,D.DOLLARID,D.FULLNAME,"
        mySql &= "D.NETAMOUNT,D.PESORATE, D.REMARKS,D.SERIAL, "
        mySql &= "Case D.STATUS "
        mySql &= "WHEN 'A' THEN 'ACTIVE'  WHEN 'V' THEN 'VOID'  ELSE 'N/A'  "
        mySql &= "END AS STATUS, D.SYSTEMINFO, D.TRANSDATE, D.USERID "
        mySql &= "FROM TBLDOLLAR D "
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
       {"CLIENTID", "DENOMINATION", "FULLNAME", " NETAMOUNT", " PESORATE", "CLIENT", "REMARKS", _
        "STATUS", " SYSTEMINFO", "TRANSDATE", "USERID"}

        Dim verified_url As String
        Dim str As String = "Dollar"
        Console.WriteLine("Dollar Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using

        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub BorrowingExtract()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT B.AMOUNT, B.BRANCHCODE, B.BRANCHNAME, "
        mySql &= "B.BRWID,  G.FULLNAME,B.REASON,B.REFNUM, B.REMARKS,"
        mySql &= " Case B.STATUS "
        mySql &= "WHEN 'C' THEN 'CASH-OUT' "
        mySql &= "WHEN 'D' THEN 'CASH-IN' "
        mySql &= "ELSE 'N/A' END AS STATUS, B.SYSTEMINFO, B.TRANSDATE "
        mySql &= "FROM TBLBORROW B "
        mySql &= "LEFT JOIN TBL_GAMIT G ON G.ENCODERID = B.ENCODERID"
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
    {"AMOUNT", "BRANCHCODE", "BRANCHNAME", " BRWID", " FULLNAME", "REASON", " REFNUM", _
     "REMARKS", " STATUS", " SYSTEMINFO", " TRANSDATE"}

        Dim verified_url As String
        Dim str As String = "Borrowings"
        Console.WriteLine("Borrowing Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using

        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub InsuranceExtract()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)


        Dim mySql As String
        mySql = " SELECT I.AMOUNT, I.CLIENTID,I.CLIENTNAME, I.COINO, G.FULLNAME AS ENCODER, I.INSURANCEID,I.PAWNTICKET, " & _
            vbCrLf & "Case I.STATUS " & _
            vbCrLf & "WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' ELSE 'N/A'  END AS STATUS," & _
            vbCrLf & "I.SYSTEMINFO, I.TRANSDATE, I.VALIDDATE FROM TBLINSURANCE I" & _
            vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.ENCODERID = I.ENCODERID" & _
            vbCrLf & String.Format("WHERE I.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
            vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
  {"AMOUNT", "CLIENTID", " CLIENTNAME", " COINO", "  ENCODER", "INSURANCEID", " PAWNTICKET", _
   "STATUS", "  SYSTEMINFO", " TRANSDATE", " T VALIDDATE"}

        Dim verified_url As String
        Dim str As String = "Insurance"
        Console.WriteLine("Insurance Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

    End Sub

    Private Sub RemitanceExtract()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT M.AMOUNT, M.COMMISSION,G.FULLNAME AS ENCODER,M.ID, M.LOCATION," & _
        vbCrLf & "Case M.MONEYTRANS" & _
        vbCrLf & "WHEN 0 THEN 'SENDIN' WHEN 1 THEN 'PAYOUT' ELSE 'NA'" & _
        vbCrLf & "END AS MONEYTRANS,M.NETAMOUNT,M.RECEIVERNAME, " & _
        vbCrLf & "CASE WHEN M.ServiceType = 'Pera Padala' AND M.MoneyTrans = 0" & _
        vbCrLf & "THEN 'ME# ' || LPAD(M.TransID,5,0)" & _
        vbCrLf & "WHEN M.SERVICETYPE = 'Pera Padala' AND M.MONEYTRANS = 1" & _
        vbCrLf & "THEN 'MR# ' || LPAD(M.TRANSID,5,0)" & _
        vbCrLf & "ELSE RefNum END as RefNum," & _
        vbCrLf & "M.REMARKS," & _
        vbCrLf & "M.SENDERNAME,M.SERVICECHARGE, " & _
        vbCrLf & "M.SERVICETYPE, " & _
        vbCrLf & "Case M.STATUS" & _
        vbCrLf & "WHEN 'A' THEN 'ACTIVE'" & _
        vbCrLf & "  WHEN 'V' THEN 'VOID'" & _
        vbCrLf & " ELSE 'N/A'" & _
        vbCrLf & " END AS STATUS, M.SYSTEMINFO, M.TRANSDATE," & _
        vbCrLf & " M.TRANSID" & _
        vbCrLf & " FROM TBLMONEYTRANSFER M" & _
        vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.ENCODERID = M.ENCODERID" & _
        vbCrLf & "INNER JOIN TBLCLIENT C ON  M.SENDERID = C.CLIENTID" & _
        vbCrLf & "INNER JOIN TBLCLIENT R ON  M.RECEIVERID = R.CLIENTID" & _
        vbCrLf & String.Format("WHERE M.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
        vbCrLf & " ORDER BY M.TRANSDATE;"

        Dim headers() As String = _
  {"AMOUNT", "COMMISSION", " ENCODER", " ID", "   LOCATION", " MONEYTRANS", " NETAMOUNT", _
   "RECEIVERNAME", "   REFNUM", " REMARKS", "SENDERNAME", "SERVICECHARGE", "SERVICETYPE", "STATUS", "SYSTEMINFO", _
    "TRANSDATE", "TRANSID"}

        Dim verified_url As String
        Dim str As String = "Remitance"
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using

        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

    End Sub
#End Region

#Region "Extract Database Table Daily"

    Private Sub PawningExtractDaily()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String
        mySql = " SELECT P.ADVINT,P.APPRAISAL,G.FULLNAME AS APPRAISER," & _
        vbCrLf & "P.AUCTIONDATE,CLASS.CATEGORY,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, " & _
        vbCrLf & " P.DAYSOVERDUE, P.DELAYINT, P.DESCRIPTION,P.EARLYREDEEM ,P.ENCODERID, P.EVAT, " & _
        vbCrLf & "P.EXPIRYDATE, P.GRAMS,P.INTEREST, P.ITEMTYPE, P.KARAT," & _
        vbCrLf & " P.LESSPRINCIPAL, P.LOANDATE ,P.MATUDATE, P.NETAMOUNT," & _
        vbCrLf & " P.OLDTICKET," & _
        vbCrLf & "Case" & _
        vbCrLf & "WHEN P.ORDATE = '01/01/0001' THEN ''" & _
        vbCrLf & "ELSE P.ORDATE END AS ORDATE," & _
        vbCrLf & " P.ORNUM, P.PAWNID, P.PAWNTICKET,	" & _
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
        vbCrLf & "LEFT JOIN TBL_GAMIT G" & _
        vbCrLf & "ON G.USERID = P.APPRAISERID" & _
        vbCrLf & "INNER JOIN TBLCLIENT C" & _
        vbCrLf & "ON C.CLIENTID =P.CLIENTID" & _
        vbCrLf & String.Format(" WHERE LOANDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
        vbCrLf & "ORDER BY P.LOANDATE ASC;"

        Dim headers() As String = _
           {"ADVINT", "APPRAISAL", "APPRAISER", "AUCTIONDATE", "CATEGORY", "CLIENT", "DAYSOVERDUE", _
            "DELAYINT", "DESCRIPTION", "EARLYREDEEM", "ENCODERID", "EVAT", "EXPIRYDATE", "GRAMS", "INTEREST", "ITEMTYPE", _
            "KARAT", "LESSPRINCIPAL", "LOANDATE", "MATUDATE", "NETAMOUNT", "OLDTICKET", "ORDATE", "ORNUM", "PAWNID", _
            "PAWNTICKET", "PENALTY", "PRINCIPAL", "PULLOUT", "REDEEMDUE", "RENEWDUE", "SERVICECHARGE", "STATUS"}


        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, "Pawning")  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''  
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DollarExtractDaily()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT D.CLIENTID,D.DENOMINATION,D.DOLLARID,D.FULLNAME," & _
        vbCrLf & "D.NETAMOUNT,D.PESORATE, D.REMARKS,D.SERIAL," & _
        vbCrLf & "Case D.STATUS" & _
        vbCrLf & "WHEN 'A' THEN 'ACTIVE'  WHEN 'V' THEN 'VOID'  ELSE 'N/A'  " & _
        vbCrLf & "END AS STATUS, D.SYSTEMINFO, D.TRANSDATE, D.USERID " & _
        vbCrLf & "FROM TBLDOLLAR D" & _
        vbCrLf & String.Format(" WHERE TRANSDATE ='{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
        vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
       {"CLIENTID", "DENOMINATION", "FULLNAME", " NETAMOUNT", " PESORATE", "CLIENT", "REMARKS", _
        "STATUS", " SYSTEMINFO", "TRANSDATE", "USERID"}


        Dim str As String = "Dollar"
        Console.WriteLine("Dollar Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

        '''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub BorrowingExtractDaily()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT B.AMOUNT, B.BRANCHCODE, B.BRANCHNAME, " & _
        vbCrLf & "B.BRWID,  G.FULLNAME,B.REASON,B.REFNUM, B.REMARKS," & _
        vbCrLf & " Case B.STATUS" & _
        vbCrLf & "WHEN 'C' THEN 'CASH-OUT' " & _
        vbCrLf & "WHEN 'D' THEN 'CASH-IN' " & _
        vbCrLf & "ELSE 'N/A' END AS STATUS, B.SYSTEMINFO, B.TRANSDATE" & _
        vbCrLf & "FROM TBLBORROW B" & _
        vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.ENCODERID = B.ENCODERID" & _
        vbCrLf & String.Format(" WHERE TRANSDATE ='{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
        vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
   {"AMOUNT", "BRANCHCODE", "BRANCHNAME", " BRWID", " FULLNAME", "REASON", " REFNUM", _
    "REMARKS", " STATUS", " SYSTEMINFO", " TRANSDATE"}

        Dim verified_url As String
        Dim str As String = "Borrowings"
        Console.WriteLine("Borrowing Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)


        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)
    End Sub

    Private Sub InsuranceExtractDaily()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = " SELECT I.AMOUNT, I.CLIENTID,I.CLIENTNAME, I.COINO, G.FULLNAME AS ENCODER, I.INSURANCEID,I.PAWNTICKET, " & _
            vbCrLf & "Case I.STATUS " & _
            vbCrLf & "WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' ELSE 'N/A'  END AS STATUS," & _
            vbCrLf & "I.SYSTEMINFO, I.TRANSDATE, I.VALIDDATE FROM TBLINSURANCE I" & _
            vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.ENCODERID = I.ENCODERID" & _
            vbCrLf & String.Format("WHERE I.TRANSDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
            vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
  {"AMOUNT", "CLIENTID", " CLIENTNAME", " COINO", "  ENCODER", "INSURANCEID", " PAWNTICKET", _
   "STATUS", "  SYSTEMINFO", " TRANSDATE", " T VALIDDATE"}

        Dim verified_url As String
        Dim str As String = "Insurance"
        Console.WriteLine("Insurance Activated")
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)


        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)
    End Sub

    Private Sub RemitanceExtractDaily()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

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
        vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.ENCODERID = M.ENCODERID" & _
        vbCrLf & "INNER JOIN TBLCLIENT C ON  M.SENDERID = C.CLIENTID" & _
        vbCrLf & "INNER JOIN TBLCLIENT R ON  M.RECEIVERID = R.CLIENTID" & _
        vbCrLf & String.Format("WHERE M.TRANSDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
        vbCrLf & " ORDER BY M.TRANSDATE;"

        Dim headers() As String = _
  {"AMOUNT", "COMMISSION", " ENCODER", " ID", "   LOCATION", " MONEYTRANS", " NETAMOUNT", _
   "RECEIVERNAME", "   REFNUM", " REMARKS", "SENDERNAME", "SERVICECHARGE", "SERVICETYPE", "STATUS", "SYSTEMINFO", _
    "TRANSDATE", "TRANSID"}

        Dim verified_url As String
        Dim str As String = "Remitance"
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub OutstandingExtract()
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String = "SELECT * FROM (   SELECT *   FROM PAWNING   WHERE (Status = 'NEW' OR Status = 'RENEW')   AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'RENEWED')   AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & MonCalendar.SelectionStart.ToShortDateString & "'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'REDEEM')   AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & MonCalendar.SelectionStart.ToShortDateString & "'   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'SEGRE')   AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND (PULLOUT > '" & MonCalendar.SelectionStart.ToShortDateString & "' OR PULLOUT IS NULL)   UNION   SELECT *   FROM PAWNING   WHERE (Status = 'WITHDRAW')   AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND PULLOUT > '" & MonCalendar.SelectionStart.ToShortDateString & "' ) ORDER BY PAWNTICKET ASC"


        Dim headers() As String = _
            {"PAWNTICKET", "LOANDATE", "MATUDATE", "EXPIRYDATE", "AUCTIONDATE", "CLIENT", "FULLADDRESS", _
             "DESCRIPTION", "ORNUM", "ORDATE", "OLDTICKET", "NETAMOUNT", "RENEWDUE", "REDEEMDUE", "APPRAISAL", "PRINCIPAL", _
             "INTEREST", "ADVINT", "SERVICECHARGE", "PENALTY", "ITEMTYPE", "CATEGORY", "GRAMS", "KARAT", "STATUS", _
             "PULLOUT", "APPRAISER"}

        Dim verified_url As String
        Dim str As String = "Outstanding"
        sfdPath.FileName = String.Format("{2}{1}{0}.xlsx", sd.ToString("MMddyyyy"), BranchCode, str)  'BranchCode + Date
        verified_url = appPath & "\" & sfdPath.FileName
        ExtractToExcel(headers, mySql, verified_url)

        txtpath1.Text = txtpath1.Text
        Using sw As StreamWriter = File.CreateText("Extract.bat")
            sw.WriteLine("@echo off")
            sw.WriteLine("title cdt-S0ft - Extract")
            sw.WriteLine("echo Extracting. . .")
            sw.WriteLine("pause")
            sw.WriteLine("echo PLEASE WAIT WHILE SYSTEM Extracting...")
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar -agMMddyyyy " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)
    End Sub

#End Region

    Private Sub ExtractALLMonthly()
        PawningExtract()
        DollarExtract()
        BorrowingExtract()
        InsuranceExtract()
        RemitanceExtract()
    End Sub

    Private Sub ExtractAllDaily()
        PawningExtractDaily()
        DollarExtractDaily()
        InsuranceExtractDaily()
        BorrowingExtractDaily()
        RemitanceExtractDaily()
        OutstandingExtract()
    End Sub

    Private Sub btnExtract_Click(sender As System.Object, e As System.EventArgs) Handles btnExtract.Click
        btnExtract.Enabled = False
        lblTransactioName.Visible = True
        If rbDaily.Checked Then ExtractType = "Daily"
        If rbmonthly.Checked Then ExtractType = "Monthly"

        Select Case ExtractType
            Case "Daily"
                ExtractAllDaily()

                MsgBox("Data Extracted...", MsgBoxStyle.Information)
                MsgBox("Thank you...", MsgBoxStyle.Information)
                btnExtract.Enabled = True

            Case "Monthly"
                ExtractALLMonthly()
                MsgBox("Data Extracted...", MsgBoxStyle.Information)
                MsgBox("Thank you...", MsgBoxStyle.Information)
                btnExtract.Enabled = True

        End Select

        Dim myFile As String
        Dim mydir As String = Application.StartupPath
        'readValue()
        For Each myFile In Directory.GetFiles(mydir, "*.xlsx")
            File.Delete(myFile)
        Next
        lblTransactioName.Visible = False
    End Sub

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

    End Sub
End Class