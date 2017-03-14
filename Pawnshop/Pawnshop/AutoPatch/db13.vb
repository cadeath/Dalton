Module db13
    Const ALLOWABLE_VERSION As String = "1.2.4"
    Const LATEST_VERSION As String = "1.3"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            Update_Maintenance()
            Modify_View_PawnList()
            Add_Field_Sent_Notice()
            Add_Table_SMS()

            Database_Update(LATEST_VERSION)
            Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Update_Maintenance()
        UpdateOptions("SMS_MSG", "HI %CLIENT%, YOUR PT#%PAWNTICKET% WILL BE AUCTION ON %AUCTIONDATE%. Please settle it before that date.")
    End Sub

    Private Sub Modify_View_PawnList()
        Dim dropView As String = "DROP VIEW PAWN_LIST;"
        Dim createView As String
        createView = "CREATE VIEW PAWN_LIST("
        createView &= vbCrLf & "  PAWNID,  PAWNTICKET,  LOANDATE,  MATUDATE,  EXPIRYDATE,  AUCTIONDATE,"
        createView &= vbCrLf & "  CLIENTID,  CLIENT,  CONTACTNUMBER,  FULLADDRESS,  ITEMCLASS,  ITEMCATEGORY,  DESCRIPTION,"
        createView &= vbCrLf & "  OLDTICKET,  ORNUM,  ORDATE,  PRINCIPAL,  DELAYINTEREST,  ADVINT,  SERVICECHARGE,  "
        createView &= vbCrLf & "  NETAMOUNT,  RENEWDUE,  REDEEMDUE,  APPRAISAL,  PENALTY,"
        createView &= vbCrLf & "  STATUS,  WITHDRAWDATE,  APPRAISER)"
        createView &= vbCrLf & "AS"
        createView &= vbCrLf & "SELECT "
        createView &= vbCrLf & "P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, "
        createView &= vbCrLf & "C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || "
        createView &= vbCrLf & "CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, C.PHONE1 AS CONTACTNUMBER, "
        createView &= vbCrLf & "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        createView &= vbCrLf & "ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, "
        createView &= vbCrLf & "P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, "
        createView &= vbCrLf & "P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, "
        createView &= vbCrLf & "P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER "
        createView &= vbCrLf & "FROM OPT P "
        createView &= vbCrLf & "INNER JOIN TBLCLIENT C "
        createView &= vbCrLf & "ON P.CLIENTID = C.CLIENTID "
        createView &= vbCrLf & "INNER JOIN OPI ITM "
        createView &= vbCrLf & "ON ITM.PAWNITEMID = P.PAWNITEMID "
        createView &= vbCrLf & "INNER JOIN TBLITEM CLASS "
        createView &= vbCrLf & "ON CLASS.ITEMID = ITM.ITEMID "
        createView &= vbCrLf & "LEFT JOIN TBL_GAMIT USR "
        createView &= vbCrLf & "ON USR.USERID = P.APPRAISERID;"

        RunCommand(dropView)
        RunCommand(createView)

        Console.WriteLine("View Modified")
    End Sub

    Private Sub Add_Field_Sent_Notice()
        Dim mySql As String = "ALTER TABLE OPT ADD SENT_NOTICE SMALLINT DEFAULT '0' NOT NULL;"
        RunCommand(mySql)

        Console.WriteLine("OPT Updated")
    End Sub

    Private Sub Add_Table_SMS()
        Dim sms As String
        sms = "CREATE TABLE SMS ("
        sms &= vbCrLf & "  SMSID BIGINT NOT NULL,"
        sms &= vbCrLf & "  SMSDATE DATE NOT NULL,"
        sms &= vbCrLf & "  PAWNID BIGINT DEFAULT '0' NOT NULL,"
        sms &= vbCrLf & "  PAWNTICKET INTEGER DEFAULT '0' NOT NULL,"
        sms &= vbCrLf & "  CLIENTID INTEGER DEFAULT '0' NOT NULL,"
        sms &= vbCrLf & "  SMS_MSG VARCHAR(200),"
        sms &= vbCrLf & "  SENT_BY SMALLINT,"
        sms &= vbCrLf & "  REMARKS VARCHAR(255),"
        sms &= vbCrLf & "  CREATED_AT TIMESTAMP DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"

        RunCommand(sms)
        AutoIncrement_ID("SMS", "SMSID")

        Console.WriteLine("Table SMS Created")
    End Sub
End Module
