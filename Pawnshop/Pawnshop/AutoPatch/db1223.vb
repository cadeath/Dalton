Module db1223
    ''' <summary>
    ''' Add Outstanding to Views
    ''' </summary>
    ''' <remarks></remarks>
    Const ALLOWABLE_VERSION As String = "1.2.2.2"
    Const LATEST_VERSION As String = "1.2.2.3"
    Sub patchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Dim strt As String 'OutstandingViews
            strt = "	CREATE VIEW OUTSTANDING(	"
            strt &= "	  ADVINT,	"
            strt &= "	  APPRAISAL,	"
            strt &= "	  APPRAISER,	"
            strt &= "	  AUCTIONDATE,	"
            strt &= "	  CATEGORY,	"
            strt &= "	  CLIENT,	"
            strt &= "	  DAYSOVERDUE,	"
            strt &= "	  DELAYINT,	"
            strt &= "	  DESCRIPTION,	"
            strt &= "	  EARLYREDEEM,	"
            strt &= "	  ENCODERID,	"
            strt &= "	  EVAT,	"
            strt &= "	  EXPIRYDATE,	"
            strt &= "	  GRAMS,	"
            strt &= "	  INTEREST,	"
            strt &= "	  ITEMTYPE,	"
            strt &= "	  KARAT,	"
            strt &= "	  LESSPRINCIPAL,	"
            strt &= "	  LOANDATE,	"
            strt &= "	  MATUDATE,	"
            strt &= "	  NETAMOUNT,	"
            strt &= "	  OLDTICKET,	"
            strt &= "	  ORDATE,	"
            strt &= "	  ORNUM,	"
            strt &= "	  PAWNID,	"
            strt &= "	  PAWNTICKET,	"
            strt &= "	  PENALTY,	"
            strt &= "	  PRINCIPAL,	"
            strt &= "	  PULLOUT,	"
            strt &= "	  REDEEMDUE,	"
            strt &= "	  RENEWDUE,	"
            strt &= "	  SERVICECHARGE,	"
            strt &= "	  STATUS)	"
            strt &= "	AS	"
            strt &= "	SELECT P.ADVINT,P.APPRAISAL,G.FULLNAME AS APPRAISER,	"
            strt &= "	    P.AUCTIONDATE,CLASS.CATEGORY,C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, 	"
            strt &= "	    P.DAYSOVERDUE, P.DELAYINT, P.DESCRIPTION,P.EARLYREDEEM ,P.ENCODERID, P.EVAT, 	"
            strt &= "	    P.EXPIRYDATE, P.GRAMS,P.INTEREST, P.ITEMTYPE, P.KARAT,	"
            strt &= "	    P.LESSPRINCIPAL, P.LOANDATE ,P.MATUDATE, P.NETAMOUNT,	"
            strt &= "	    P.OLDTICKET,	"
            strt &= "	      Case	"
            strt &= "	       WHEN P.ORDATE = '01/01/0001' THEN ''	"
            strt &= "	        ELSE P.ORDATE END AS ORDATE,	"
            strt &= "	     P.ORNUM, P.PAWNID, P.PAWNTICKET,	"
            strt &= "	    P.PENALTY, P.PRINCIPAL, P.PULLOUT, P.REDEEMDUE,P.RENEWDUE,	"
            strt &= "	    P.SERVICECHARGE,	"
            strt &= "	      CASE P.STATUS	"
            strt &= "	    WHEN '0' THEN 'RENEWED' WHEN 'R' THEN 'RENEW' 	"
            strt &= "	        WHEN 'L' THEN 'NEW' WHEN 'V' THEN 'VOID' WHEN 'W' THEN 'WITHDRAW' 	"
            strt &= "	        WHEN 'X' THEN 'REDEEM' WHEN 'S' THEN 'SEGRE' 	"
            strt &= "	        ELSE 'N/A' END AS STATUS	"
            strt &= "	FROM TBLPAWN P	"
            strt &= "	INNER JOIN TBLCLASS CLASS	"
            strt &= "	ON CLASS.CLASSID = P.CATID	"
            strt &= "	INNER JOIN TBL_GAMIT G	"
            strt &= "	ON G.USERID = P.APPRAISERID	"
            strt &= "	INNER JOIN TBLCLIENT C	"
            strt &= "	ON C.CLIENTID =P.CLIENTID	"
            strt &= "	ORDER BY P.LOANDATE ASC;	"

            RunCommand(strt)

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]", LATEST_VERSION) & ex.ToString)

        End Try
    End Sub
End Module
