Module db133
    Const ALLOWABLE_VERSION As String = "1.3.2"
    Const LATEST_VERSION As String = "1.3.3"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        frmMainV2.Cursor = Cursors.WaitCursor
        Try
            Modify_View_PawnList()
            Modify_MoneyTransfer()
            Modify_PrintPawning()
            Modify_LoanRegister()
            Modify_ExpiryList()
            Create_CustomerVIEW()

            Add_IsKYCRequired()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
        frmMainV2.Cursor = Cursors.Default
    End Sub

    Private Sub Modify_View_PawnList()
        Dim dropView As String = "DROP VIEW PAWN_LIST;"
        Dim createView As String

        createView = "	CREATE VIEW PAWN_LIST(	"
        createView &= vbCrLf & "	  PAWNID,	"
        createView &= vbCrLf & "	  PAWNTICKET,	"
        createView &= vbCrLf & "	  LOANDATE,	"
        createView &= vbCrLf & "	  MATUDATE,	"
        createView &= vbCrLf & "	  EXPIRYDATE,	"
        createView &= vbCrLf & "	  AUCTIONDATE,	"
        createView &= vbCrLf & "	  ID,	"
        createView &= vbCrLf & "	  CLIENT,	"
        createView &= vbCrLf & "	  CONTACTNUMBER,	"
        createView &= vbCrLf & "	  FULLADDRESS,	"
        createView &= vbCrLf & "	  ITEMCLASS,	"
        createView &= vbCrLf & "	  ITEMCATEGORY,	"
        createView &= vbCrLf & "	  DESCRIPTION,	"
        createView &= vbCrLf & "	  OLDTICKET,	"
        createView &= vbCrLf & "	  ORNUM,	"
        createView &= vbCrLf & "	  ORDATE,	"
        createView &= vbCrLf & "	  PRINCIPAL,	"
        createView &= vbCrLf & "	  DELAYINTEREST,	"
        createView &= vbCrLf & "	  ADVINT,	"
        createView &= vbCrLf & "	  SERVICECHARGE,	"
        createView &= vbCrLf & "	  NETAMOUNT,	"
        createView &= vbCrLf & "	  RENEWDUE,	"
        createView &= vbCrLf & "	  REDEEMDUE,	"
        createView &= vbCrLf & "	  APPRAISAL,	"
        createView &= vbCrLf & "	  PENALTY,	"
        createView &= vbCrLf & "	  STATUS,	"
        createView &= vbCrLf & "	  WITHDRAWDATE,	"
        createView &= vbCrLf & "	  APPRAISER,	"
        createView &= vbCrLf & "	  SENT_NOTICE)	"
        createView &= vbCrLf & "	AS	"
        createView &= vbCrLf & "	SELECT 	"
        createView &= vbCrLf & "	P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, 	"
        createView &= vbCrLf & "	C.ID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || 	"
        createView &= vbCrLf & "	CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, 	"
        createView &= vbCrLf & "	(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1	"
        createView &= vbCrLf & "	THEN PH.PHONENUMBER WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER	"
        createView &= vbCrLf & "	ELSE PH.PHONENUMBER END)AS CONTACTNUMBER FROM KYC_PHONE PH  	"
        createView &= vbCrLf & "	 WHERE 	"
        createView &= vbCrLf & "	    C.ID = PH.CUSTID 	"
        createView &= vbCrLf & "	    ORDER BY PH.ISPRIMARY DESC ROWS 1),	"
        createView &= vbCrLf & "	C.STREET1 || ' ' || C.CITY1 || ' ' || C.PROVINCE1 || ' ' || C.ZIP1 as FULLADDRESS, 	"
        createView &= vbCrLf & "	ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, 	"
        createView &= vbCrLf & "	P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, 	"
        createView &= vbCrLf & "	P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, 	"
        createView &= vbCrLf & "	P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER, P.SENT_NOTICE 	"
        createView &= vbCrLf & "	FROM OPT P INNER JOIN KYC_CUSTOMERS C 	"
        createView &= vbCrLf & "	ON P.CLIENTID = C.ID INNER JOIN OPI ITM 	"
        createView &= vbCrLf & "	ON ITM.PAWNITEMID = P.PAWNITEMID INNER JOIN TBLITEM CLASS 	"
        createView &= vbCrLf & "	ON CLASS.ITEMID = ITM.ITEMID LEFT JOIN TBL_GAMIT USR ON USR.USERID = P.APPRAISERID;	"

        RunCommand(dropView)
        RunCommand(createView)

        Console.WriteLine("View Modified")
    End Sub

    Private Sub Modify_MoneyTransfer()
        Dim dropView As String = "DROP VIEW MONEY_TRANSFER;"
        Dim createMTView As String

        createMTView = "	CREATE VIEW MONEY_TRANSFER(	"
        createMTView &= vbCrLf & "	  SERVICETYPE,TRANSDATE,MONEYTRANS,REFNUM,PAYOUT,SENDOUT,SERVICECHARGE,COMMISSION,	"
        createMTView &= vbCrLf & "	  NETAMOUNT,SENDERNAME,S_ADDR,RECEIVERNAME,R_ADDR,LOCATION)	"
        createMTView &= vbCrLf & "	AS	"
        createMTView &= vbCrLf & "	SELECT 	"
        createMTView &= vbCrLf & "	MT.ServiceType, MT.TransDate,"
        createMTView &= vbCrLf & "	CASE MoneyTrans "
        createMTView &= vbCrLf & "	WHEN 0 THEN 'SENDIN'	"
        createMTView &= vbCrLf & "	WHEN 1 THEN 'PAYOUT' "
        createMTView &= vbCrLf & "	ELSE 'NA' "
        createMTView &= vbCrLf & "	END AS MoneyTrans,	"
        createMTView &= vbCrLf & "	CASE		"
        createMTView &= vbCrLf & "	WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0		"
        createMTView &= vbCrLf & "	THEN 'ME# ' || LPAD(TransID,5,0)		"
        createMTView &= vbCrLf & "	WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1		"
        createMTView &= vbCrLf & "	THEN 'MR# ' || LPAD(TransID,5,0)		"
        createMTView &= vbCrLf & "	ELSE RefNum END as RefNum,		"
        createMTView &= vbCrLf & "	CASE MoneyTrans		"
        createMTView &= vbCrLf & "	WHEN 1 THEN AMOUNT 		"
        createMTView &= vbCrLf & "	ELSE 0 END AS PAYOUT,		"
        createMTView &= vbCrLf & "	CASE MoneyTrans		"
        createMTView &= vbCrLf & "	WHEN 0 THEN AMOUNT 		"
        createMTView &= vbCrLf & "	ELSE 0 END AS SENDOUT,		"
        createMTView &= vbCrLf & "	MT.ServiceCharge,		"
        createMTView &= vbCrLf & "	MT.Commission,		"
        createMTView &= vbCrLf & "	MT.NETAMOUNT, MT.SENDERNAME, 		"
        createMTView &= vbCrLf & "	C.STREET1 || ' ' || C.BRGY1 || ' ' || C.CITY1 AS S_ADDR, "
        createMTView &= vbCrLf & "	MT.RECEIVERNAME, 		"
        createMTView &= vbCrLf & "	R.STREET1 || ' ' || R.BRGY1 || ' ' || R.CITY1 AS R_ADDR,"
        createMTView &= vbCrLf & "	MT.LOCATION	"
        createMTView &= vbCrLf & "	FROM "
        createMTView &= vbCrLf & "	TBLMONEYTRANSFER MT	"
        createMTView &= vbCrLf & "	INNER JOIN KYC_CUSTOMERS C	"
        createMTView &= vbCrLf & "	ON  MT.SENDERID = C.ID	"
        createMTView &= vbCrLf & "	INNER JOIN KYC_CUSTOMERS R	"
        createMTView &= vbCrLf & "	ON  MT.RECEIVERID = R.ID	"
        createMTView &= vbCrLf & "	WHERE "
        createMTView &= vbCrLf & "	Status = 'A';"


        RunCommand(dropView)
        RunCommand(createMTView)

        Console.WriteLine("View Modified")
    End Sub

    Private Sub Modify_PrintPawning()
        Dim dropView As String = "DROP VIEW PRINT_PAWNING;"
        Dim createPawningPrint As String

        createPawningPrint = "	CREATE VIEW PRINT_PAWNING( "
        createPawningPrint &= vbCrLf & "	PAWNID,PAWNTICKET,LOANDATE,MATUDATE,EXPIRYDATE,ITEMTYPE,PAWNER,FULLADDRESS,PRINCIPAL,"
        createPawningPrint &= vbCrLf & "	APPRAISAL,INTEREST,ADVINT,SERVICECHARGE,NETAMOUNT, DESCRIPTION,CONTACTNUMBER,ORNUM,ORDATE,"
        createPawningPrint &= vbCrLf & "	PENALTY,RENEWDUE,REDEEMDUE)	"
        createPawningPrint &= vbCrLf & "	AS	"
        createPawningPrint &= vbCrLf & "	SELECT 	"
        createPawningPrint &= vbCrLf & "	P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.ITEMTYPE, "
        createPawningPrint &= vbCrLf & "	C.FIRSTNAME || ' ' || C.LASTNAME AS PAWNER, 		"
        createPawningPrint &= vbCrLf & "	C.STREET1 || ' ' || C.BRGY1 || ' ' || C.CITY1 AS FULLADDRESS,"
        createPawningPrint &= vbCrLf & "	P.PRINCIPAL, P.APPRAISAL, P.INTEREST, P.ADVINT, P.SERVICECHARGE,"
        createPawningPrint &= vbCrLf & "	P.NETAMOUNT, P.DESCRIPTION, 		"
        createPawningPrint &= vbCrLf & "	(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1	"
        createPawningPrint &= vbCrLf & "	THEN PH.PHONENUMBER WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER "
        createPawningPrint &= vbCrLf & "	ELSE NULL END)AS CONTACTNUMBER FROM KYC_PHONE PH LEFT JOIN KYC_CUSTOMERS CC ON CC.ID = PH.CUSTID "
        createPawningPrint &= vbCrLf & "	WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' AND PH.ISPRIMARY = 1	"
        createPawningPrint &= vbCrLf & "	OR CHAR_LENGTH(PH.PHONENUMBER)=11 AND PH.CUSTID =CC.ID ORDER BY PH.ISPRIMARY DESC ROWS 1),"
        createPawningPrint &= vbCrLf & "	P.ORNUM, P.ORDATE, P.PENALTY, P.RENEWDUE, P.REDEEMDUE "
        createPawningPrint &= vbCrLf & "	FROM TBLPAWN P 	"
        createPawningPrint &= vbCrLf & "	INNER JOIN KYC_CUSTOMERS C ON C.ID = P.CLIENTID; "


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
        Dim createExpiryList As String

        createExpiryList = "	CREATE VIEW EXPIRY_LIST(		"
        createExpiryList &= vbCrLf & "	PAWNID,PAWNTICKET,CLIENTID,LOANDATE,MATUDATE,EXPIRYDATE,AUCTIONDATE,ITEMTYPE,CATID,DESCRIPTION,KARAT,	"
        createExpiryList &= vbCrLf & "	GRAMS,APPRAISAL,PRINCIPAL,INTEREST,NETAMOUNT,EVAT,APPRAISERID,OLDTICKET,ORNUM,ORDATE,LESSPRINCIPAL,	"
        createExpiryList &= vbCrLf & "	DAYSOVERDUE,DELAYINT,PENALTY,SERVICECHARGE,RENEWDUE,REDEEMDUE,STATUS,PULLOUT,SYSTEMINFO,ENCODERID,ADVINT,	"
        createExpiryList &= vbCrLf & "	CATEGORY,CLIENTID1,MIDDLENAME,ID,FIRSTNAME,MIDNAME,LASTNAME,ADDR_STREET,SUFFIX,STREET1,BRGY1,CITY1,PROVINCE1,	"
        createExpiryList &= vbCrLf & "	ZIP1,STREET2,BRGY2,CITY2,PROVINCE2,ZIP2,BIRTHDAY,BIRTHPLACE,NATUREOFWORK,NATIONALITY,GENDER,SRCFUND,RANK,	"
        createExpiryList &= vbCrLf & "	CLIENT_SIGNATURE,CLIENT_IMG,IsDumper,CONTACTNUMBER,USERNAME)	"
        createExpiryList &= vbCrLf & "	AS		"
        createExpiryList &= vbCrLf & "	SELECT P.*, CL.CATEGORY, C.*,		"
        createExpiryList &= vbCrLf & "	(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1 "
        createExpiryList &= vbCrLf & "	THEN PH.PHONENUMBER WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER	"
        createExpiryList &= vbCrLf & "	ELSE PH.PHONENUMBER END)AS CONTACTNUMBER FROM KYC_PHONE PH 	"
        createExpiryList &= vbCrLf & "	WHERE C.ID = PH.CUSTID ORDER BY PH.ISPRIMARY DESC ROWS 1), "
        createExpiryList &= vbCrLf & "	U.USERNAME FROM tblPawn P		"
        createExpiryList &= vbCrLf & "	INNER JOIN KYC_CUSTOMERS C on P.clientid = C.ID	"
        createExpiryList &= vbCrLf & "	INNER JOIN tbl_Gamit U on U.USERID = P.ENCODERID "
        createExpiryList &= vbCrLf & "	INNER JOIN tblClass CL ON CL.CLASSID = P.CATID	"
        createExpiryList &= vbCrLf & "	WHERE (P.Status = 'L' or P.Status = 'R'); "


        RunCommand(dropView)
        RunCommand(createExpiryList)

        Console.WriteLine("View Modified")
    End Sub


    Private Sub Create_CustomerVIEW()
        Dim createCustView As String

        createCustView = "	CREATE VIEW CUSTOMER_VIEW(	"
        createCustView &= vbCrLf & " ID,FIRSTNAME,MIDNAME,LASTNAME,SUFFIX,STREET1, BRGY1,CITY1,PROVINCE1,ZIP1,STREET2,	"
        createCustView &= vbCrLf & " BRGY2,CITY2,PROVINCE2,ZIP2,BIRTHDAY,BIRTHPLACE,NATUREOFWORK,NATIONALITY,	"
        createCustView &= vbCrLf & " GENDER,SRCFUND,RANK,CLIENT_SIGNATURE,CLIENT_IMG,IsDumper)	"
        createCustView &= vbCrLf & " AS	"
        createCustView &= vbCrLf & " SELECT cl.* FROM KYC_CUSTOMERS cl;	"

        RunCommand(createCustView)

        Console.WriteLine("View Modified")
    End Sub


    Private Sub Add_IsKYCRequired()
        UpdateOptions("KYCRequired", "No")
    End Sub
End Module
