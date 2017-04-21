Module db15
    Const ALLOWABLE_VERSION As String = "1.3"
    Const LATEST_VERSION As String = "1.3.1"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Modify_View_PawnList()
            Modify_MoneyTransfer()
            Modify_PrintPawning()
            Modify_LoanRegister()
            Modify_ExpiryList()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub



    Private Sub Modify_View_PawnList()
        Dim dropView As String = "DROP VIEW PAWN_LIST;"
        Dim createView As String

        createView = "CREATE VIEW PAWN_LIST("
        createView &= vbCrLf & " PAWNID,PAWNTICKET,LOANDATE,MATUDATE,EXPIRYDATE,AUCTIONDATE,CLIENTID,CLIENT,CONTACTNUMBER,"
        createView &= vbCrLf & " FULLADDRESS,ITEMCLASS,ITEMCATEGORY, DESCRIPTION,OLDTICKET,ORNUM,ORDATE,PRINCIPAL,DELAYINTEREST,"
        createView &= vbCrLf & "  ADVINT,SERVICECHARGE,NETAMOUNT,RENEWDUE,REDEEMDUE,APPRAISAL,PENALTY,STATUS,WITHDRAWDATE,APPRAISER,SENT_NOTICE) "
        createView &= vbCrLf & " AS "
        createView &= vbCrLf & " SELECT "
        createView &= vbCrLf & " P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE,"
        createView &= vbCrLf & " C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT,"
        createView &= vbCrLf & " (SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1 THEN PH.PHONENUMBER "
        createView &= vbCrLf & " WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER ELSE NULL END)AS CONTACTNUMBER FROM KYC_PHONE PH "
        createView &= vbCrLf & " LEFT JOIN KYC_CUSTOMERS CC ON CC.ID = PH.CUSTID WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' AND PH.CUSTID =CC.ID ROWS 1) "
        createView &= vbCrLf & " ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, "
        createView &= vbCrLf & " P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER, P.SENT_NOTICE "
        createView &= vbCrLf & " FROM OPT P INNER JOIN TBLCLIENT C ON P.CLIENTID = C.CLIENTID INNER JOIN OPI ITM ON ITM.PAWNITEMID = P.PAWNITEMID "
        createView &= vbCrLf & " INNER JOIN TBLITEM CLASS ON CLASS.ITEMID = ITM.ITEMID LEFT JOIN TBL_GAMIT USR ON USR.USERID = P.APPRAISERID;"


        'RunCommand(dropView)
        RunCommand(createView)

        Console.WriteLine("View Modified")
    End Sub

    Private Sub Modify_MoneyTransfer()
        Dim dropView As String = "DROP VIEW MONEY_TRANSFER;"
        Dim createMTView As String

        createMTView = "CREATE VIEW MONEY_TRANSFER("
        createMTView &= vbCrLf & "   SERVICETYPE,TRANSDATE,MONEYTRANS, REFNUM,PAYOUT,SENDOUT,SERVICECHARGE,COMMISSION,NETAMOUNT,"
        createMTView &= vbCrLf & "   SENDERNAME,S_ADDR,RECEIVERNAME,R_ADDR,LOCATION) "
        createMTView &= vbCrLf & "AS "
        createMTView &= vbCrLf & "SELECT "
        createMTView &= vbCrLf & "MT.ServiceType, MT.TransDate, "
        createMTView &= vbCrLf & "Case MoneyTrans WHEN 1 THEN 'PAYOUT' WHEN 0 THEN 'SENDIN' "
        createMTView &= vbCrLf & " ELSE 'NA' END AS MoneyTrans,"
        createMTView &= vbCrLf & " CASE WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0 THEN 'ME# ' || LPAD(TransID,5,0)"
        createMTView &= vbCrLf & "WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1 "
        createMTView &= vbCrLf & " THEN 'MR# ' || LPAD(TransID,5,0) ELSE RefNum END as RefNum, "
        createMTView &= vbCrLf & "Case MoneyTrans "
        createMTView &= vbCrLf & " WHEN 1 THEN AMOUNT ELSE 0 END AS PAYOUT,Case MoneyTrans "
        createMTView &= vbCrLf & " WHEN 0 THEN AMOUNT ELSE 0 END AS SENDOUT,"
        createMTView &= vbCrLf & "  MT.ServiceCharge, MT.Commission, MT.NETAMOUNT, MT.SENDERNAME,"
        createMTView &= vbCrLf & "C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY AS S_ADDR"
        createMTView &= vbCrLf & "MT.RECEIVERNAME,  "
        createMTView &= vbCrLf & " R.ADDR_STREET || ' ' || R.ADDR_BRGY || ' ' || R.ADDR_CITY AS R_ADDR, "
        createMTView &= vbCrLf & "MT.LOCATION FROM TBLMONEYTRANSFER MT "
        createMTView &= vbCrLf & "INNER JOIN TBLCLIENT C ON  MT.SENDERID = C.CLIENTID "
        createMTView &= vbCrLf & "INNER JOIN TBLCLIENT RON  MT.RECEIVERID = R.CLIENTID "
        createMTView &= vbCrLf & "WHERE Status = 'A'; "

        RunCommand(dropView)
        RunCommand(createMTView)

        Console.WriteLine("View Modified")
    End Sub

    Private Sub Modify_PrintPawning()
        Dim dropView As String = "DROP VIEW PRINT_PAWNING;"
        Dim createPawningPrint As String

        createPawningPrint = "CREATE VIEW PRINT_PAWNING("
        createPawningPrint &= vbCrLf & "  PAWNID,PAWNTICKET,LOANDATE,MATUDATE,EXPIRYDATE,ITEMTYPE,PAWNER,FULLADDRESS,PRINCIPAL,APPRAISAL,"
        createPawningPrint &= vbCrLf & " INTEREST,ADVINT,SERVICECHARGE,NETAMOUNT,DESCRIPTION,CONTACTNUMBER,ORNUM,ORDATE,PENALTY,RENEWDUE,REDEEMDUE) "
        createPawningPrint &= vbCrLf & "AS "
        createPawningPrint &= vbCrLf & "SELECT "
        createPawningPrint &= vbCrLf & " P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.ITEMTYPE,  "
        createPawningPrint &= vbCrLf & " C.FIRSTNAME || ' ' || C.LASTNAME AS PAWNER, "
        createPawningPrint &= vbCrLf & "C.STREET1 || ' ' || C.BRGY1 || ' ' || C.CITY1 AS FULLADDRESS,"
        createPawningPrint &= vbCrLf & "P.PRINCIPAL, P.APPRAISAL, P.INTEREST, P.ADVINT, P.SERVICECHARGE,"
        createPawningPrint &= vbCrLf & "P.NETAMOUNT, P.DESCRIPTION, "
        createPawningPrint &= vbCrLf & "(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1 THEN PH.PHONENUMBER "
        createPawningPrint &= vbCrLf & "WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER "
        createPawningPrint &= vbCrLf & " ELSE NULL END)AS CONTACTNUMBER "
        createPawningPrint &= vbCrLf & " FROM KYC_PHONE PH WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' ROWS 1), "
        createPawningPrint &= vbCrLf & " P.ORNUM, P.ORDATE, P.PENALTY, P.RENEWDUE, P.REDEEMDUE "
        createPawningPrint &= vbCrLf & "FROM TBLPAWN P INNER JOIN KYC_CUSTOMERS C ON C.ID = P.CLIENTID;"

        RunCommand(dropView)
        RunCommand(createPawningPrint)

        Console.WriteLine("View Modified")
    End Sub

    Private Sub Modify_LoanRegister()
        Dim dropView As String = "DROP VIEW LOAN_REGISTER;"
        Dim createLoanRegister As String

        createLoanRegister = "CREATE VIEW LOAN_REGISTER("
        createLoanRegister &= vbCrLf & "  AWNTICKET,PAWNER,ITEMTYPE,LOANDATE,MATUDATE,EXPIRYDATE,APPRAISAL,DESCRIPTION,PRINCIPAL,"
        createLoanRegister &= vbCrLf & " INTEREST,ADVINT,SERVICECHARGE,NETAMOUNT,RENEWDUE,REDEEMDUE, ORDATE,USERNAME,STATUS) "
        createLoanRegister &= vbCrLf & "AS "
        createLoanRegister &= vbCrLf & "SELECT "
        createLoanRegister &= vbCrLf & " P.PawnTicket,C.FIRSTNAME || ' ' || C.LASTNAME AS PAWNER,P.ITEMTYPE,P.LOANDATE,P.MATUDATE,P.EXPIRYDATE,  "
        createLoanRegister &= vbCrLf & " P.APPRAISAL,P.DESCRIPTION,P.PRINCIPAL,P.INTEREST,P.ADVINT,P.SERVICECHARGE,P.NETAMOUNT, "
        createLoanRegister &= vbCrLf & "P.RENEWDUE,P.REDEEMDUE,P.ORDATE,U.USERNAME,P.STATUS "
        createLoanRegister &= vbCrLf & "FROM tblPAWN P "
        createLoanRegister &= vbCrLf & "INNER JOIN KYC_CUSTOMERS C on C.ID = P.ClientID "
        createLoanRegister &= vbCrLf & "INNER JOIN tbl_Gamit U ON U.UserID = P.EncoderID; "

        RunCommand(dropView)
        RunCommand(createLoanRegister)

        Console.WriteLine("View Modified")
    End Sub


    Private Sub Modify_ExpiryList()
        Dim dropView As String = "DROP VIEW EXPIRY_LIST;"
        Dim createLoanRegister As String

        createLoanRegister = "CREATE VIEW EXPIRY_LIST("
        createLoanRegister &= vbCrLf & " PAWNID,PAWNTICKET,CLIENTID,LOANDATE,MATUDATE,EXPIRYDATE,AUCTIONDATE,ITEMTYPE, CATID,DESCRIPTION,"
        createLoanRegister &= vbCrLf & " KARAT,GRAMS,APPRAISAL,PRINCIPAL, INTEREST,NETAMOUNT,EVAT,APPRAISERID,OLDTICKET,ORNUM,ORDATE,LESSPRINCIPAL,"
        createLoanRegister &= vbCrLf & " DAYSOVERDUE,DELAYINT,PENALTY,SERVICECHARGE,RENEWDUE,REDEEMDUE,STATUS,PULLOUT,SYSTEMINFO,ENCODERID,ADVINT,CATEGORY,"
        createLoanRegister &= vbCrLf & " CLIENTID1,MIDDLENAME,ID,FIRSTNAME,MIDNAME,LASTNAME,ADDR_STREET,SUFFIX,STREET1,BRGY1,CITY1,PROVINCE1,ZIP1,STREET2,BRGY2,CITY2,PROVINCE2,"
        createLoanRegister &= vbCrLf & "ZIP2,BIRTHDAY,BIRTHPLACE,NATUREOFWORK,NATIONALITY,GENDER,SRCFUND,RANK,CLIENT_IMG,CONTACTNUMBER,USERNAME) "
        createLoanRegister &= vbCrLf & "AS "
        createLoanRegister &= vbCrLf & "SELECT "
        createLoanRegister &= vbCrLf & " P.*, CL.CATEGORY, C.*,  "
        createLoanRegister &= vbCrLf & " (SELECT (CASE  "
        createLoanRegister &= vbCrLf & "WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1 THEN PH.PHONENUMBER "
        createLoanRegister &= vbCrLf & "WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER "
        createLoanRegister &= vbCrLf & "ELSE NULL END)AS CONTACTNUMBER "
        createLoanRegister &= vbCrLf & "FROM KYC_PHONE PH LEFT JOIN KYC_CUSTOMERS CC ON CC.ID = PH.CUSTID "
        createLoanRegister &= vbCrLf & "WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' AND PH.CUSTID =CC.ID ROWS 1), "
        createLoanRegister &= vbCrLf & "U.USERNAME FROM tblPawn P "
        createLoanRegister &= vbCrLf & "INNER JOIN KYC_CUSTOMERS C on P.clientid = C.ID "
        createLoanRegister &= vbCrLf & "INNER JOIN tbl_Gamit U on U.USERID = P.ENCODERID "
        createLoanRegister &= vbCrLf & "INNER JOIN tblClass CL ON CL.CLASSID = P.CATID "
        createLoanRegister &= vbCrLf & "WHERE(P.Status = 'L' or P.Status = 'R'); "
        RunCommand(dropView)
        RunCommand(createLoanRegister)

        Console.WriteLine("View Modified")
    End Sub
End Module


'CREATE VIEW MONEY_TRANSFER(
'  SERVICETYPE,TRANSDATE,
'  MONEYTRANS,
'  REFNUM,
'  PAYOUT,
'  SENDOUT,
'  SERVICECHARGE,
'  COMMISSION,
'  NETAMOUNT,
'  SENDERNAME,
'  S_ADDR,
'  RECEIVERNAME,
'  R_ADDR,
'  LOCATION)
'AS
'SELECT 
'  MT.ServiceType, MT.TransDate,
'    CASE MoneyTrans WHEN 1 THEN 'PAYOUT' WHEN 0 THEN 'SENDIN' ELSE 'NA' END AS MoneyTrans,
'    CASE WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0 THEN 'ME# ' || LPAD(TransID,5,0)
'    WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1 THEN 'MR# ' || LPAD(TransID,5,0) ELSE RefNum END as RefNum,
'    CASE MoneyTrans WHEN 1 THEN AMOUNT ELSE 0 END AS PAYOUT,
'    CASE MoneyTrans WHEN 0 THEN AMOUNT ELSE 0 END AS SENDOUT,
'    MT.ServiceCharge,MT.Commission,MT.NETAMOUNT, MT.SENDERNAME, C.STREET1 || ' ' || C.BRGY1 || ' ' || C.CITY1 AS S_ADDR, 
'    MT.RECEIVERNAME, R.STREET2 || ' ' || R.BRGY2 || ' ' || R.CITY2 AS R_ADDR,MT.LOCATION
'FROM TBLMONEYTRANSFER MT INNER JOIN KYC_CUSTOMERS C
'  ON  MT.SENDERID = C.ID INNER JOIN KYC_CUSTOMERS R
'  ON  MT.RECEIVERID = R.ID WHERE Status = 'A';
