Public Class frmFixView
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub
    Private Sub frmFixView_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click

        Disable(1)
        Try

            ' Modify_View_PawnList()
            Modify_PawnListView_v3()

            MsgBox("Successful", MsgBoxStyle.Information, "Fixing . . ")

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        Disable(0)
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
        createView &= vbCrLf & "	C.STREET1 || ' '||C.BRGY1 ||' '|| C.CITY1 || ' ' || C.PROVINCE1 || ' ' || C.ZIP1 as FULLADDRESS, 	"
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

    Private Sub Modify_PawnListView_v3()
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
        createView &= vbCrLf & "	PH.PHONENUMBER AS CONTACTNUMBER, "
        createView &= vbCrLf & "	C.STREET1 || ' '||C.BRGY1 ||' '|| C.CITY1 || ' ' || C.PROVINCE1 || ' ' || C.ZIP1 as FULLADDRESS, 	"
        createView &= vbCrLf & "	ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, 	"
        createView &= vbCrLf & "	P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, 	"
        createView &= vbCrLf & "	P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, 	"
        createView &= vbCrLf & "	P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER, P.SENT_NOTICE 	"
        createView &= vbCrLf & "	FROM OPT P "
        createView &= vbCrLf & "    INNER JOIN KYC_CUSTOMERS C ON P.CLIENTID = C.ID "
        createView &= vbCrLf & "	INNER JOIN OPI ITM ON ITM.PAWNITEMID = P.PAWNITEMID "
        createView &= vbCrLf & "	INNER JOIN TBLITEM CLASS ON CLASS.ITEMID = ITM.ITEMID "
        createView &= vbCrLf & "    LEFT JOIN TBL_GAMIT USR ON USR.USERID = P.APPRAISERID "
        createView &= vbCrLf & "	INNER JOIN KYC_PHONE PH ON PH.CUSTID = C.ID "
        createView &= vbCrLf & "	WHERE PH.ISPRIMARY = 1;"


        RunCommand(dropView)
        RunCommand(createView)
    End Sub
    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

End Class