Imports Microsoft.Office.Interop
Imports System.Data.Odbc
Imports System.IO
Imports System.IO.Compression


' TODO: ELLIE
' PLEASE ARRANGE EVERYTHING! MAKE IT MORE UNDERSTANDBLE AND EASY TO SORT
' REMOVE ALL YOUR BRANCHNAME: <BRANCHNAME>, IT IS NO USE!
' DON'T MIND THE BRANCHCODE, I ALREADY INCLUDED IT WHEN EXTRACTED SO EXCLUDE IT

Public Class ExtractDataFromDatabase
    Dim ExtractType As String
    Const batch As String = "\Extract.bat"
    ' Dim result As String = Path.GetTempPath()
    Dim appPath As String = Application.StartupPath
    Dim verified_url As String

    Private Sub ExtractDataFromDatabase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtpath1.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
        lblTransactioName.Visible = False
    End Sub

#Region "Extract Database Table Monthly"

    Private Sub PawningExtract()
        lbltransaction.Text = "Pawning"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "	SELECT O.PAWNID,PAWNTICKET,OLDTICKET,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT,	" & _
          vbCrLf & "	CL.FIRSTNAME || ' ' || CL.LASTNAME AS CLAIMER,G.FULLNAME AS APPRAISER,	" & _
          vbCrLf & "	E.FULLNAME AS ENCODER,I.ITEMCLASS,O.APPRAISAL,O.PRINCIPAL,O.NETAMOUNT,	" & _
          vbCrLf & "	O.DESCRIPTION,O.DAYSOVERDUE,O.DELAYINTEREST,O.ADVINT,O.EARLYREDEEM,O.LOANDATE,	" & _
          vbCrLf & "	O.MATUDATE,O.EXPIRYDATE,O.AUCTIONDATE, " & _
          vbCrLf & "Case " & _
          vbCrLf & "WHEN O.ORDATE = '01/01/0001' THEN '' " & _
          vbCrLf & "ELSE O.ORDATE END AS ORDATE," & _
          vbCrLf & " O.ORNUM, O.PENALTY, " & _
          vbCrLf & "	Case O.STATUS	" & _
          vbCrLf & "	WHEN '0' THEN 'RENEWED' WHEN 'R' THEN 'RENEW' 	" & _
          vbCrLf & "	WHEN 'L' THEN 'NEW' WHEN 'V' THEN 'VOID' 	" & _
          vbCrLf & "	WHEN 'W' THEN 'WITHDRAW'WHEN 'X' THEN 'REDEEM'	" & _
          vbCrLf & "	 WHEN 'S' THEN 'SEGRE' ELSE 'N/A' END AS STATUS,	" & _
          vbCrLf & "	O.RENEWDUE,O.REDEEMDUE,I.WITHDRAWDATE,	" & _
          vbCrLf & "	Case I.STATUS	" & _
          vbCrLf & "	WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' 	" & _
          vbCrLf & "	WHEN 'S' THEN 'SEGRE' WHEN 'W' THEN 'WITHDRAW' 	" & _
          vbCrLf & "	WHEN 'X' THEN 'REDEEM' ELSE 'N/A' END AS ITEMSTATUS,	" & _
          vbCrLf & "	I.RENEWALCNT,	" & _
          vbCrLf & "	O.SERVICECHARGE,O.CREATED_AT,O.UPDATED_AT	" & _
          vbCrLf & "	FROM OPT O	" & _
          vbCrLf & "	INNER JOIN TBLCLIENT C	" & _
          vbCrLf & "	ON C.CLIENTID =O.CLIENTID	" & _
          vbCrLf & "	LEFT JOIN TBLCLIENT CL	" & _
          vbCrLf & "	ON CL.CLIENTID =O.CLAIMERID	" & _
          vbCrLf & "	LEFT JOIN TBL_GAMIT G	" & _
          vbCrLf & "	ON G.USERID = O.APPRAISERID	" & _
          vbCrLf & "	LEFT JOIN TBL_GAMIT E	" & _
          vbCrLf & "	ON E.USERID = O.ENCODERID	" & _
          vbCrLf & "	INNER JOIN OPI I	" & _
          vbCrLf & "	ON I.PAWNITEMID = O.PAWNITEMID	" & _
          vbCrLf & String.Format(" WHERE O.LOANDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
          vbCrLf & "ORDER BY O.LOANDATE ASC;"

        ' TODO: ELLIE
        ' PLEASE ARRANGE THIS HEADERS IN A MANNER THAT THE ACCOUNTING CAN EASILY READ
        ' IF YOU DONT UNDERSTAND, BETTER USE THE PAWNING VIEW FIELD ARRANGEMENT.
        Dim headers() As String = _
         {"PAWNID", "PAWNTICKET", "OLDTICKET", "CLIENTNAME", "CLAIMER", "APPRAISER", "ENCODER", "ITEMCLASS", _
          "APPRAISAL", "PRINCIPAL", "NETAMOUNT", "DESCRIPTION", "DAYSOVERDUE", "DELAYINTEREST", "ADVINT", _
          "EARLYREDEEM", "LOANDATE", "MATUDATE", "EXPIRYDATE", "AUCTIONDATE", "ORDATE", "ORNUM", _
          "PENALTY", "STATUS", "RENEWDUE", "REDEEMDUE", "WITHDRAWDATE", "ITEMSTATUS", "RENEWALCNT", _
           "SERVICECHARGE", "CREATED_AT", "UPDATE_AT"}


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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
            sw.WriteLine("cls ")
            sw.WriteLine("echo DONE!!! THANK YOU FOR WAITING")
            sw.WriteLine("pause")
            sw.WriteLine("exit")
        End Using
        'CommandPrompt(batch, appPath)
        Dim pro As New ProcessStartInfo(appPath & batch)
        pro.RedirectStandardError = True
        pro.RedirectStandardOutput = True
        pro.CreateNoWindow = False
        pro.WindowStyle = ProcessWindowStyle.Hidden
        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

    End Sub

    Private Sub DollarExtract()
        lbltransaction.Text = "Dollar"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT D.DOLLARID, D.CLIENTID,D.FULLNAME,D.DENOMINATION, "
        mySql &= "D.NETAMOUNT,D.PESORATE, D.TRANSDATE, D.REMARKS,D.SERIAL, "
        mySql &= "Case D.STATUS "
        mySql &= "WHEN 'A' THEN 'ACTIVE'  WHEN 'V' THEN 'VOID'  ELSE 'N/A'  "
        mySql &= "END AS STATUS,CURRENCY, D.SYSTEMINFO, D.USERID "
        mySql &= "FROM TBLDOLLAR D "
        mySql &= "LEFT JOIN TBL_GAMIT G ON G.USERID = D.USERID "
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= "ORDER BY TRANSDATE ASC"

        ' TODO: ELLIE
        ' WHERE IS THE CURRENCY SYMBOL OR THE IDENTIFICATION ON WHAT CURRENCY IS THE TRANSACTION?
        Dim headers() As String = _
       {"DOLLARID", "CLIENTID", "FULLNAME", "DENOMINATION", " NETAMOUNT", " PESORATE", "TRANSDATE", "REMARKS", "SERIAL", _
        "STATUS", "CURRENCY", " SYSTEMINFO", "USERID"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Borrowing"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT B.BRWID,  G.FULLNAME, B.BRANCHCODE, B.BRANCHNAME, B.AMOUNT, B.TRANSDATE, "
        mySql &= "B.REASON,B.REFNUM, B.REMARKS, "
        mySql &= " Case B.STATUS "
        mySql &= "WHEN 'C' THEN 'CASH-OUT' "
        mySql &= "WHEN 'D' THEN 'CASH-IN' "
        mySql &= "ELSE 'N/A' END AS STATUS, B.SYSTEMINFO "
        mySql &= "FROM TBLBORROW B "
        mySql &= "LEFT JOIN TBL_GAMIT G ON G.USERID = B.ENCODERID"
        mySql &= String.Format(" WHERE TRANSDATE BETWEEN'{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= "ORDER BY TRANSDATE ASC"

        ' TODO: ELLIE
        ' PLEASE ARRANGE
        Dim headers() As String = _
    {" BORROWINGID", " ENCODERNAME", "BRANCHCODE", "BRANCHNAME", "AMOUNT", "TRANSDATE", "REASON", " REFERENCENUM", _
      "REMARKS", " STATUS", " SYSTEMINFO"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Insurance"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)


        Dim mySql As String
        mySql = " SELECT  I.INSURANCEID, I.CLIENTID,I.CLIENTNAME,I.AMOUNT, I.COINO,I.TRANSDATE, I.VALIDDATE, G.FULLNAME AS ENCODER,I.PAWNTICKET, " & _
            vbCrLf & "Case I.STATUS " & _
            vbCrLf & "WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' ELSE 'N/A'  END AS STATUS," & _
            vbCrLf & "I.SYSTEMINFO FROM TBLINSURANCE I" & _
            vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.USERID = I.ENCODERID" & _
            vbCrLf & String.Format("WHERE I.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
            vbCrLf & "ORDER BY TRANSDATE ASC"

        ' TODO: ELLIE
        ' PLEASE ARRANGE
        ' WHAT IS "T VALIDDATE"?
        Dim headers() As String = _
  {"INSURANCEID", "CLIENTID", " CLIENTNAME", "AMOUNT", " COINO", " TRANSDATE", " VALIDDATE", "  ENCODER", " PAWNTICKET", _
   "STATUS", "  SYSTEMINFO"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Remitance"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "SELECT M.ID,M.RECEIVERID,M.RECEIVERNAME,M.SENDERID,M.SENDERNAME, M.AMOUNT, M.COMMISSION,G.FULLNAME AS ENCODER, M.LOCATION," & _
       vbCrLf & "Case M.MONEYTRANS" & _
       vbCrLf & "WHEN 0 THEN 'SENDIN' WHEN 1 THEN 'PAYOUT' ELSE 'NA'" & _
       vbCrLf & "END AS MONEYTRANS, M.TRANSDATE, " & _
        vbCrLf & " M.SERVICECHARGE, " & _
       vbCrLf & "M.SERVICETYPE, " & _
       vbCrLf & "Case M.STATUS" & _
         vbCrLf & "WHEN 'A' THEN 'ACTIVE'" & _
       vbCrLf & "  WHEN 'V' THEN 'VOID'" & _
       vbCrLf & " ELSE 'N/A'" & _
       vbCrLf & " END AS STATUS,M.NETAMOUNT," & _
       vbCrLf & "CASE WHEN M.ServiceType = 'Pera Padala' AND M.MoneyTrans = 0" & _
       vbCrLf & "THEN 'ME# ' || LPAD(M.TransID,5,0)" & _
       vbCrLf & "WHEN M.SERVICETYPE = 'Pera Padala' AND M.MONEYTRANS = 1" & _
       vbCrLf & "THEN 'MR# ' || LPAD(M.TRANSID,5,0)" & _
       vbCrLf & "ELSE RefNum END as RefNum," & _
       vbCrLf & "M.REMARKS," & _
       vbCrLf & " M.TRANSID," & _
     vbCrLf & "M.SYSTEMINFO" & _
       vbCrLf & " FROM TBLMONEYTRANSFER M" & _
       vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.USERID = M.ENCODERID" & _
       vbCrLf & "INNER JOIN TBLCLIENT C ON  M.SENDERID = C.CLIENTID" & _
       vbCrLf & "INNER JOIN TBLCLIENT R ON  M.RECEIVERID = R.CLIENTID" & _
        vbCrLf & String.Format("WHERE M.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString) & _
        vbCrLf & " ORDER BY M.TRANSDATE;"

        ' TODO: ELLIE
        ' PLEASE ARRANGE
        Dim headers() As String = _
  {" ID", "RECIEVERID", "RECEIVERNAME", "SENDERID", "SENDERNAME", "AMOUNT", "COMMISSION", " ENCODER", " LOCATION", " MONEYTRANS", _
    "TRANSDATE", "SERVICECHARGE", "SERVICETYPE", "STATUS", " NETAMOUNT", " REFNUM", " REMARKS", "TRANSACTIONID", "SYSTEMINFO"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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

    Private Sub CashInOUtExtract()
        lbltransaction.Text = "CASHINOUT"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        Dim stDay = GetFirstDate(MonCalendar.SelectionStart)
        Dim laDay = GetLastDate(MonCalendar.SelectionEnd)

        Dim mySql As String
        mySql = "	SELECT T.TRANSID,T.CASHID,G.FULLNAME AS ENCODERNAME,T.CATEGORY,T.TRANSNAME,T.TYPE,	"
        mySql &= "	T.AMOUNT,T.TRANSDATE,	"
        mySql &= "	CASE T.STATUS	"
        mySql &= "	WHEN  '1' THEN 'ACTIVE'	"
        mySql &= "	WHEN '0' THEN 'VOID'	"
        mySql &= "	ELSE 'N/A' END AS STATUS,T.REMARKS,T.SYSTEMINFO	"
        mySql &= "	FROM TBLCASHTRANS T	"
        mySql &= "	LEFT JOIN TBL_GAMIT G	"
        mySql &= "	ON G.USERID = T.ENCODERID	"
        mySql &= String.Format("WHERE T.TRANSDATE BETWEEN '{0}' AND '{1}'", stDay.ToShortDateString, laDay.ToShortDateString)
        mySql &= "	ORDER BY TRANSID	"


        Dim headers() As String = _
  {" TRANSACTIONID", "CASHID", "ENCODERNAME", "CATEGORY", "TRANSNAME", "TYPE", "AMOUNT", "TRANSDATE", "STATUS", "REMARKS", "SYSTEMINFO"}

        Dim verified_url As String
        Dim str As String = "CASHINOUT"
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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Monthly" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Pawning"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String
        mySql = "	SELECT O.PAWNID,PAWNTICKET,OLDTICKET,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT,	" & _
          vbCrLf & "	CL.FIRSTNAME || ' ' || CL.LASTNAME AS CLAIMER,G.FULLNAME AS APPRAISER,	" & _
          vbCrLf & "	E.FULLNAME AS ENCODER,I.ITEMCLASS,O.APPRAISAL,O.PRINCIPAL,O.NETAMOUNT,	" & _
          vbCrLf & "	O.DESCRIPTION,O.DAYSOVERDUE,O.DELAYINTEREST,O.ADVINT,O.EARLYREDEEM,O.LOANDATE,	" & _
          vbCrLf & "	O.MATUDATE,O.EXPIRYDATE,O.AUCTIONDATE, " & _
          vbCrLf & "Case " & _
          vbCrLf & "WHEN O.ORDATE = '01/01/0001' THEN '' " & _
          vbCrLf & "ELSE O.ORDATE END AS ORDATE," & _
          vbCrLf & " O.ORNUM, O.PENALTY, " & _
          vbCrLf & "	Case O.STATUS	" & _
          vbCrLf & "	WHEN '0' THEN 'RENEWED' WHEN 'R' THEN 'RENEW' 	" & _
          vbCrLf & "	WHEN 'L' THEN 'NEW' WHEN 'V' THEN 'VOID' 	" & _
          vbCrLf & "	WHEN 'W' THEN 'WITHDRAW'WHEN 'X' THEN 'REDEEM'	" & _
          vbCrLf & "	 WHEN 'S' THEN 'SEGRE' ELSE 'N/A' END AS STATUS,	" & _
          vbCrLf & "	O.RENEWDUE,O.REDEEMDUE,I.WITHDRAWDATE,	" & _
          vbCrLf & "	Case I.STATUS	" & _
          vbCrLf & "	WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' 	" & _
          vbCrLf & "	WHEN 'S' THEN 'SEGRE' WHEN 'W' THEN 'WITHDRAW' 	" & _
          vbCrLf & "	WHEN 'X' THEN 'REDEEM' ELSE 'N/A' END AS ITEMSTATUS,	" & _
          vbCrLf & "	I.RENEWALCNT,	" & _
          vbCrLf & "	O.SERVICECHARGE,O.CREATED_AT,O.UPDATED_AT	" & _
          vbCrLf & "	FROM OPT O	" & _
          vbCrLf & "	INNER JOIN TBLCLIENT C	" & _
          vbCrLf & "	ON C.CLIENTID =O.CLIENTID	" & _
          vbCrLf & "	LEFT JOIN TBLCLIENT CL	" & _
          vbCrLf & "	ON CL.CLIENTID =O.CLAIMERID	" & _
          vbCrLf & "	LEFT JOIN TBL_GAMIT G	" & _
          vbCrLf & "	ON G.USERID = O.APPRAISERID	" & _
          vbCrLf & "	LEFT JOIN TBL_GAMIT E	" & _
          vbCrLf & "	ON E.USERID = O.ENCODERID	" & _
          vbCrLf & "	INNER JOIN OPI I	" & _
          vbCrLf & "	ON I.PAWNITEMID = O.PAWNITEMID	" & _
          vbCrLf & String.Format(" WHERE LOANDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
          vbCrLf & "ORDER BY O.LOANDATE ASC;"

        ' TODO: ELLIE
        ' PLEASE ARRANGE THIS HEADERS IN A MANNER THAT THE ACCOUNTING CAN EASILY READ
        ' IF YOU DONT UNDERSTAND, BETTER USE THE PAWNING VIEW FIELD ARRANGEMENT.
        Dim headers() As String = _
         {"PAWNID", "PAWNTICKET", "OLDTICKET", "CLIENTNAME", "CLAIMER", "APPRAISER", "ENCODER", "ITEMCLASS", _
          "APPRAISAL", "PRINCIPAL", "NETAMOUNT", "DESCRIPTION", "DAYSOVERDUE", "DELAYINTEREST", "ADVINT", _
          "EARLYREDEEM", "LOANDATE", "MATUDATE", "EXPIRYDATE", "AUCTIONDATE", "ORDATE", "ORNUM", _
          "PENALTY", "STATUS", "RENEWDUE", "REDEEMDUE", "WITHDRAWDATE", "ITEMSTATUS", "RENEWALCNT", _
           "SERVICECHARGE", "CREATED_AT", "UPDATE_AT"}
        
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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        pro.WindowStyle = ProcessWindowStyle.Normal

        pro.UseShellExecute = False
        Dim process As Process = process.Start(pro)

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

    End Sub

    Private Sub DollarExtractDaily()
        lbltransaction.Text = "Dollar"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
     

        Dim mySql As String
        mySql = "SELECT D.DOLLARID, D.CLIENTID,D.FULLNAME,D.DENOMINATION, "
        mySql &= "D.NETAMOUNT,D.PESORATE, D.TRANSDATE, D.REMARKS,D.SERIAL, "
        mySql &= "Case D.STATUS "
        mySql &= "WHEN 'A' THEN 'ACTIVE'  WHEN 'V' THEN 'VOID'  ELSE 'N/A'  "
        mySql &= "END AS STATUS,CURRENCY, D.SYSTEMINFO, D.USERID "
        mySql &= "FROM TBLDOLLAR D "
        mySql &= "LEFT JOIN TBL_GAMIT G ON G.USERID = D.USERID "
        mySql &= String.Format(" WHERE TRANSDATE ='{0}'", MonCalendar.SelectionRange.Start.ToShortDateString)
        mySql &= "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
              {"DOLLARID", "CLIENTID", "FULLNAME", "DENOMINATION", " NETAMOUNT", " PESORATE", "TRANSDATE", "REMARKS", "SERIAL", _
               "STATUS", "CURRENCY", " SYSTEMINFO", "USERID"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Borrowing"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        

        Dim mySql As String
        mySql = "SELECT B.BRWID,  G.FULLNAME, B.BRANCHCODE, B.BRANCHNAME, B.AMOUNT, B.TRANSDATE, "
        mySql &= "B.REASON,B.REFNUM, B.REMARKS, "
        mySql &= " Case B.STATUS "
        mySql &= "WHEN 'C' THEN 'CASH-OUT' "
        mySql &= "WHEN 'D' THEN 'CASH-IN' "
        mySql &= "ELSE 'N/A' END AS STATUS, B.SYSTEMINFO "
        mySql &= "FROM TBLBORROW B "
        mySql &= "LEFT JOIN TBL_GAMIT G ON G.USERID = B.ENCODERID"
        mySql &= String.Format(" WHERE TRANSDATE ='{0}'", MonCalendar.SelectionRange.Start.ToShortDateString)
        mySql &= "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
                {" BORROWINGID", " ENCODERNAME", "BRANCHCODE", "BRANCHNAME", "AMOUNT", "TRANSDATE", "REASON", " REFERENCENUM", _
                  "REMARKS", " STATUS", " SYSTEMINFO"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Insurance"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
        

        Dim mySql As String
        mySql = " SELECT  I.INSURANCEID, I.CLIENTID,I.CLIENTNAME,I.AMOUNT, I.COINO,I.TRANSDATE, I.VALIDDATE, G.FULLNAME AS ENCODER,I.PAWNTICKET, " & _
            vbCrLf & "Case I.STATUS " & _
            vbCrLf & "WHEN 'A' THEN 'ACTIVE' WHEN 'V' THEN 'VOID' ELSE 'N/A'  END AS STATUS," & _
            vbCrLf & "I.SYSTEMINFO FROM TBLINSURANCE I" & _
            vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.USERID = I.ENCODERID" & _
            vbCrLf & String.Format("WHERE I.TRANSDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
           vbCrLf & "ORDER BY TRANSDATE ASC"

        Dim headers() As String = _
          {"INSURANCEID", "CLIENTID", " CLIENTNAME", "AMOUNT", " COINO", " TRANSDATE", " VALIDDATE", "  ENCODER", " PAWNTICKET", _
           "STATUS", "  SYSTEMINFO"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Remitance"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0
      
        Dim mySql As String
        mySql = "SELECT M.ID,M.RECEIVERID,M.RECEIVERNAME,M.SENDERID,M.SENDERNAME, M.AMOUNT, M.COMMISSION,G.FULLNAME AS ENCODER, M.LOCATION," & _
       vbCrLf & "Case M.MONEYTRANS" & _
       vbCrLf & "WHEN 0 THEN 'SENDIN' WHEN 1 THEN 'PAYOUT' ELSE 'NA'" & _
       vbCrLf & "END AS MONEYTRANS, M.TRANSDATE, " & _
       vbCrLf & " M.SERVICECHARGE, " & _
       vbCrLf & "M.SERVICETYPE, " & _
       vbCrLf & "Case M.STATUS" & _
       vbCrLf & "WHEN 'A' THEN 'ACTIVE'" & _
       vbCrLf & "  WHEN 'V' THEN 'VOID'" & _
       vbCrLf & " ELSE 'N/A'" & _
       vbCrLf & " END AS STATUS,M.NETAMOUNT," & _
       vbCrLf & "CASE WHEN M.ServiceType = 'Pera Padala' AND M.MoneyTrans = 0" & _
       vbCrLf & "THEN 'ME# ' || LPAD(M.TransID,5,0)" & _
       vbCrLf & "WHEN M.SERVICETYPE = 'Pera Padala' AND M.MONEYTRANS = 1" & _
       vbCrLf & "THEN 'MR# ' || LPAD(M.TRANSID,5,0)" & _
       vbCrLf & "ELSE RefNum END as RefNum," & _
       vbCrLf & "M.REMARKS," & _
       vbCrLf & " M.TRANSID," & _
       vbCrLf & "M.SYSTEMINFO" & _
       vbCrLf & " FROM TBLMONEYTRANSFER M" & _
       vbCrLf & "LEFT JOIN TBL_GAMIT G ON G.USERID = M.ENCODERID" & _
       vbCrLf & "INNER JOIN TBLCLIENT C ON  M.SENDERID = C.CLIENTID" & _
       vbCrLf & "INNER JOIN TBLCLIENT R ON  M.RECEIVERID = R.CLIENTID" & _
       vbCrLf & String.Format("WHERE M.TRANSDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString) & _
       vbCrLf & " ORDER BY M.TRANSDATE;"

        Dim headers() As String = _
{" ID", "RECIEVERID", "RECEIVERNAME", "SENDERID", "SENDERNAME", "AMOUNT", "COMMISSION", " ENCODER", " LOCATION", " MONEYTRANS", _
"TRANSDATE", "SERVICECHARGE", "SERVICETYPE", "STATUS", " NETAMOUNT", " REFNUM", " REMARKS", "TRANSACTIONID", "SYSTEMINFO"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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
        lbltransaction.Text = "Outstanding"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String
        mySql = "	SELECT PAWNTICKET,LOANDATE,MATUDATE,EXPIRYDATE,	"
        mySql &= "	AUCTIONDATE,CLIENT,FULLADDRESS,	DESCRIPTION, ORNUM, "
        mySql &= "	  CASE WHEN ORDATE = '01/01/0001' THEN ''	"
        mySql &= "	  ELSE ORDATE END AS ORDATE,OLDTICKET,NETAMOUNT,	"
        mySql &= "	  RENEWDUE,REDEEMDUE,APPRAISAL,PRINCIPAL,	"
        mySql &= "	  DELAYINTEREST,ADVINT,SERVICECHARGE,	"
        mySql &= "	  PENALTY,ITEMCATEGORY,ITEMCLASS,	"
        mySql &= "	  Case STATUS	"
        mySql &= "	WHEN '0' THEN 'RENEWED' WHEN 'R' THEN 'RENEW' 	"
        mySql &= "	WHEN 'L' THEN 'NEW' WHEN 'V' THEN 'VOID' 	"
        mySql &= "	WHEN 'W' THEN 'WITHDRAW'WHEN 'X' THEN 'REDEEM'	"
        mySql &= "	 WHEN 'S' THEN 'SEGRE' ELSE 'N/A' END AS STATUS,	"
        mySql &= "	WITHDRAWDATE,APPRAISER	"
        mySql &= "FROM "
        mySql &= "( "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWN_LIST "
        mySql &= "  WHERE (Status = 'L') "
        mySql &= "  AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWN_LIST "
        mySql &= "  WHERE (Status = 'R') "
        mySql &= "  AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWN_LIST "
        mySql &= "  WHERE (Status = '0') "
        mySql &= "  AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & MonCalendar.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWN_LIST "
        mySql &= "  WHERE (Status = 'X') "
        mySql &= "  AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND ORDATE > '" & MonCalendar.SelectionStart.ToShortDateString & "' "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWN_LIST "
        mySql &= "  WHERE (Status = 'S') "
        mySql &= "  AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND (WITHDRAWDATE > '" & MonCalendar.SelectionStart.ToShortDateString & "' OR WITHDRAWDATE IS NULL) "
        mySql &= "  UNION "
        mySql &= "  SELECT * "
        mySql &= "  FROM PAWN_LIST "
        mySql &= "  WHERE (Status = 'W') "
        mySql &= "  AND LOANDATE <= '" & MonCalendar.SelectionStart.ToShortDateString & "' AND WITHDRAWDATE > '" & MonCalendar.SelectionStart.ToShortDateString & "' "
        mySql &= ") "

        Dim headers() As String = _
            {"PAWNTICKET", "LOANDATE", "MATUDATE", "EXPIRYDATE", "AUCTIONDATE", "CLIENTNAME", "FULLADDRESS", _
             "DESCRIPTION", "ORNUM", "ORDATE", "OLDTICKET", "NETAMOUNT", "RENEWDUE", "REDEEMDUE", "APPRAISAL", "PRINCIPAL", _
             "DELAYINTEREST", "ADVINT", "SERVICECHARGE", "PENALTY", "ITEMCATEGORY", "ITEMCLASS", "STATUS", _
             "WITHDRAWDATE", "APPRAISER"}

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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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

    Private Sub CashInOUtExtractDaily()
        lbltransaction.Text = "CASHINOUT"
        lblTransactioName.Text = "Wait While Data is Extracting . . ."
        Dim sd As Date = MonCalendar.SelectionStart, lineNum As Integer = 0

        Dim mySql As String
        mySql = "	SELECT T.TRANSID,T.CASHID,G.FULLNAME AS ENCODERNAME,T.CATEGORY,T.TRANSNAME,T.TYPE,	"
        mySql &= "	T.AMOUNT,T.TRANSDATE,	"
        mySql &= "	CASE T.STATUS	"
        mySql &= "	WHEN  '1' THEN 'ACTIVE'	"
        mySql &= "	WHEN '0' THEN 'VOID'	"
        mySql &= "	ELSE 'N/A' END AS STATUS,T.REMARKS,T.SYSTEMINFO	"
        mySql &= "	FROM TBLCASHTRANS T	"
        mySql &= "	LEFT JOIN TBL_GAMIT G	"
        mySql &= "	ON G.USERID = T.ENCODERID	"
        mySql &= String.Format("WHERE T.TRANSDATE = '{0}'", MonCalendar.SelectionRange.Start.ToShortDateString)
        mySql &= "	ORDER BY TRANSID	"

        Dim headers() As String = _
  {" TRANSACTIONID", "CASHID", "ENCODERNAME", "CATEGORY", "TRANSNAME", "TYPE", "AMOUNT", "TRANSDATE", "STATUS", "REMARKS", "SYSTEMINFO"}


        Dim verified_url As String
        Dim str As String = "CASHINOUT"
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
            sw.WriteLine("rar a " & txtpath1.Text & "\" & "Daily" & mod_system.BranchCode & ".rar " & sfdPath.FileName & " -hp" & BranchCode & "MIS")
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

    Private Sub ExtractALLMonthly()
        PawningExtract()
        DollarExtract()
        BorrowingExtract()
        InsuranceExtract()
        RemitanceExtract()
        CashInOUtExtract()
    End Sub

    Private Sub ExtractAllDaily()
        PawningExtractDaily()
        DollarExtractDaily()
        InsuranceExtractDaily()
        BorrowingExtractDaily()
        RemitanceExtractDaily()
        OutstandingExtract()
        CashInOUtExtractDaily()
    End Sub


    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click

        Dim sd As Date = MonCalendar.SelectionStart
        Dim str As String = sd
        Dim filename As String = str.Replace("/"c, "_"c)

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

                Dim tmp_path1 As String = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Daily" & mod_system.BranchCode & "" & filename & ".rar")

                If My.Computer.FileSystem.FileExists(tmp_path1) Then
                    My.Computer.FileSystem.DeleteFile(tmp_path1)
                End If

                My.Computer.FileSystem.RenameFile(txtpath1.Text & "\Daily" & mod_system.BranchCode & ".rar", "Daily" & mod_system.BranchCode & "" & filename & ".rar")

            Case "Monthly"
                ExtractALLMonthly()
                MsgBox("Data Extracted...", MsgBoxStyle.Information)
                MsgBox("Thank you...", MsgBoxStyle.Information)
                btnExtract.Enabled = True

                Dim tmp_path As String = (Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\Monthly" & mod_system.BranchCode & "" & filename & ".rar")


                If My.Computer.FileSystem.FileExists(tmp_path) Then
                    My.Computer.FileSystem.DeleteFile(tmp_path)
                End If

                My.Computer.FileSystem.RenameFile(txtpath1.Text & "\Monthly" & mod_system.BranchCode & ".rar", "Monthly" & mod_system.BranchCode & "" & filename & ".rar")

        End Select
        Dim myFile As String
        Dim mydir As String = Application.StartupPath
        'readValue()
        For Each myFile In Directory.GetFiles(mydir, "*.xlsx")
            File.Delete(myFile)
        Next
        lblTransactioName.Visible = False

    End Sub
End Class