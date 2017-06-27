Module db135
    Const ALLOWABLE_VERSION As String = "1.3.4"
    Const LATEST_VERSION As String = "1.3.5"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Modify_View_PawnList()
            Modify_LoanRegister()
            Modify_ExpiryList()

            Update_Maintenance()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Update_Maintenance()
        UpdateOptions("AccountExpiry", "30")
        UpdateOptions("PasswordExpiry", "90")
        UpdateOptions("FailedAttempt", "3")
        UpdateOptions("PolloutCount", "1")
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
        createView &= vbCrLf & "	ON CLASS.ITEMID = ITM.ITEMID LEFT JOIN TBL_USER_DEFAULT USR ON USR.USERID = P.APPRAISERID;	"


        RunCommand(dropView)
        RunCommand(createView)

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
        createLoanRegister &= vbCrLf & "INNER JOIN TBL_USER_DEFAULT U ON U.UserID = P.EncoderID; "

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
        createExpiryList &= vbCrLf & "	INNER JOIN TBL_USER_DEFAULT U on U.USERID = P.ENCODERID "
        createExpiryList &= vbCrLf & "	INNER JOIN tblClass CL ON CL.CLASSID = P.CATID	"
        createExpiryList &= vbCrLf & "	WHERE (P.Status = 'L' or P.Status = 'R'); "


        RunCommand(dropView)
        RunCommand(createExpiryList)

        Console.WriteLine("View Modified")
    End Sub

End Module
