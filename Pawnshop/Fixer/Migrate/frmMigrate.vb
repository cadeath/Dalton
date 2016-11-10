Imports System.Data.Odbc

Public Class frmMigrate
    Const ALLOWABLE_VERSION As String = "1.2.2.4"
    Const LATEST_VERSION As String = "1.2.2.5"
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub Migrate()
        'Try
        Dim mysql As String = "SELECT  P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, P.CLIENTID, "
        mysql &= "CASE  WHEN P.ITEMTYPE = 'JWL' AND (P.DESCRIPTION = Null OR P.DESCRIPTION = '') THEN  "
        mysql &= "CLASS.CATEGORY || ' ' || ROUND(P.GRAMS,2) || 'G ' || P.KARAT || 'K' "
        mysql &= " ELSE P.DESCRIPTION END AS Description, P.ENCODERID, P.APPRAISERID, P.DAYSOVERDUE, "
        mysql &= "P.ORNUM, P.ORDATE, P.OLDTICKET, P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL, P.PRINCIPAL,  "
        mysql &= "P.INTEREST, P.ADVINT, P.SERVICECHARGE,P.PENALTY, P.ITEMTYPE, CLASS.CATEGORY, P.GRAMS, P.KARAT, "
        mysql &= "P.STATUS, P.PULLOUT, P.INT_CHECKSUM, P.KARAT AS PAWNKARAT, P.GRAMS AS PAWNGRAMS, P.RENEWALCNT, "
        mysql &= "P.EARLYREDEEM "
        mysql &= "FROM TBLPAWN P LEFT JOIN TBLCLASS CLASS ON CLASS.CLASSID = P.CATID "
        Dim ds As DataSet = LoadSQL(mysql)

        For Each dr As DataRow In ds.Tables(0).Rows
            'Migrate Data
            Dim MigPt As Integer = dr.Item("PawnTicket")
            Dim MigOldPt As Integer = dr.Item("OldTicket")
            Dim MigLoanDate As Date = dr.Item("LoanDate")
            Dim MigMaturityDate As Date = dr.Item("Matudate")
            Dim MigExpiryDate As Date = dr.Item("ExpiryDate")
            Dim MigAuctionDate As Date = dr.Item("AuctionDate")
            Dim MigAppraiserID As Integer = dr.Item("AppraiserID")
            Dim MigEncoderID As Integer = dr.Item("EncoderID")
            Dim MigClientID As Integer = dr.Item("ClientID")
            Dim MigOrNum As Integer = dr.Item("OrNum")
            Dim MigOrDate As Date = dr.Item("ORDate")
            Dim MigNetAount As Integer = dr.Item("NetAmount")
            Dim MigRenewDue As Integer = dr.Item("RenewDue")
            Dim MigRedeemDue As Integer = dr.Item("RedeemDue")
            Dim MigAppraisal As Integer = dr.Item("Appraisal")
            Dim MigPrincipal As Integer = dr.Item("Principal")
            Dim MigInterest As Integer
            If Not IsDBNull(dr.Item("Interest")) Then MigInterest = dr.Item("Interest")
            Dim MigAdvInt As Integer = dr.Item("AdvInt")
            Dim MigServiceCharge As Integer = dr.Item("ServiceCharge")
            Dim MigPenalty As Integer = dr.Item("Penalty")
            Dim MigPullout As Date
            If Not IsDBNull(dr.Item("PullOut")) Then MigPullout = dr.Item("PullOut")
            Dim MigCategory As String = dr.Item("Category")
            Dim MigItemType As String = dr.Item("ItemType")
            Dim MigKarat As String = dr.Item("PAWNKARAT")
            Dim MigGrams As String = dr.Item("PAWNGRAMS")
            Dim MigDiscription As String = dr.Item("Description")
            Dim MigStatus As String = dr.Item("Status")
            Dim MigEarlyRedeem As Integer = dr.Item("EarlyRedeem")
            Dim MigDayOverDue As Integer = dr.Item("DaysOverDue")
            Dim MigRenewCount As Integer = dr.Item("RenewalCnt")
            Dim MigCheckSum As String
            If Not IsDBNull(dr.Item("int_checksum")) Then MigCheckSum = dr.Item("int_checksum")

            'Search OldTicket in OPT
            Dim sqlOpt As String = "Select * from OPT where Pawnticket = " & MigOldPt
            Dim DsOpt As DataSet = LoadSQL(sqlOpt, "OPT")

            If DsOpt.Tables(0).Rows.Count > 0 Then
                Dim PawnItemID As Integer = DsOpt.Tables(0).Rows(0).Item("PawnItemID")
                sqlOpt = "Select * from OPT"
                DsOpt.Clear()
                DsOpt = LoadSQL(sqlOpt, "OPT")
                Dim dsNewRow As DataRow
                dsNewRow = DsOpt.Tables("OPT").NewRow
                With dsNewRow
                    .Item("PawnTicket") = MigPt
                    .Item("OldTicket") = MigOldPt
                    .Item("LoanDate") = MigLoanDate
                    .Item("Matudate") = MigMaturityDate
                    .Item("ExpiryDate") = MigExpiryDate
                    .Item("AuctionDate") = MigAuctionDate
                    .Item("Appraisal") = MigAppraisal
                    .Item("Principal") = MigPrincipal
                    .Item("NetAmount") = MigNetAount
                    .Item("AppraiserID") = MigAppraiserID
                    .Item("EncoderID") = MigEncoderID
                    .Item("ClaimerID") = MigClientID
                    .Item("ClientID") = MigClientID
                    .Item("PawnItemID") = PawnItemID
                    .Item("Description") = MigDiscription
                    .Item("ORNum") = MigOrNum
                    .Item("ORDate") = MigOrDate
                    .Item("Penalty") = MigPenalty
                    .Item("Status") = MigStatus
                    .Item("DaysOverDue") = MigDayOverDue
                    .Item("EarlyRedeem") = MigEarlyRedeem
                    .Item("DelayInterest") = MigInterest
                    .Item("AdvInt") = MigAdvInt
                    .Item("RenewDue") = MigRenewDue
                    .Item("RedeemDue") = MigRedeemDue
                    .Item("ServiceCharge") = MigServiceCharge
                    .Item("Created_at") = Now
                End With
                DsOpt.Tables("OPT").Rows.Add(dsNewRow)
                database.SaveEntry(DsOpt)

            Else
                Dim sqlOpi As String = "Select * from OPI"
                Dim DsOpi As DataSet = LoadSQL(sqlOpi, "OPI")

                Dim dsNewRow As DataRow
                dsNewRow = DsOpi.Tables("OPI").NewRow
                With dsNewRow
                    .Item("ItemID") = GetClass(MigCategory, ItemClass.ID)
                    .Item("ItemClass") = GetClass(MigCategory, ItemClass.Name)
                    .Item("Scheme_ID") = GetInt(MigItemType, MigCheckSum)
                    .Item("WithDrawDate") = MigPullout
                    Select Case MigStatus
                        Case "L", "0", "R"
                            .Item("Status") = "A"
                        Case Else
                            .Item("Status") = MigStatus
                    End Select
                    .Item("RenewalCnt") = MigRenewCount
                    .Item("Created_at") = Now
                End With
                DsOpi.Tables("OPI").Rows.Add(dsNewRow)
                database.SaveEntry(DsOpi)

                Dim sqlPi1 As String = "Select * from PI1"
                Dim DsPi1 As DataSet = LoadSQL(sqlPi1, "PI1")
                dsNewRow = DsPi1.Tables("PI1").NewRow

                Dim specsName As String() = {"GRAMS", "KARAT", "DESCRIPTION"}
                Dim specsType As String() = {"INTEGER", "INTEGER", "STRING"}
                If MigItemType = "JWL" Then
                    For i As Integer = 0 To 2
                        With dsNewRow
                            .Item("SpecsName") = specsName(i)
                            .Item("SpecsType") = specsType(i)
                            If "GRAMS" = specsName(i) Then
                                .Item("SpecsValue") = MigGrams
                                .Item("UOM") = "G"
                            ElseIf "KARAT" = specsName(i) Then
                                .Item("SpecsValue") = MigKarat
                                .Item("UOM") = "K"
                            Else
                                .Item("SpecsValue") = MigDiscription
                            End If
                            .Item("PawnItemID") = GetLastID()
                            DsPi1.Tables("PI1").Rows.Add(dsNewRow)
                        End With
                        database.SaveEntry(DsPi1)
                        DsPi1.Clear()
                    Next
                Else
                    With dsNewRow
                        .Item("SpecsName") = specsName(2)
                        .Item("SpecsType") = specsType(2)
                        .Item("SpecsValue") = MigDiscription
                        .Item("PawnItemID") = GetLastID()
                        DsPi1.Tables("PI1").Rows.Add(dsNewRow)
                    End With
                    database.SaveEntry(DsPi1)
                End If

                sqlOpt = "Select * from OPT"
                DsOpt.Clear()
                DsOpt = LoadSQL(sqlOpt, "OPT")

                dsNewRow = DsOpt.Tables("OPT").NewRow
                With dsNewRow
                    .Item("PAWNTICKET") = MigPt
                    .Item("OldTicket") = MigOldPt
                    .Item("LoanDate") = MigLoanDate
                    .Item("Matudate") = MigMaturityDate
                    .Item("ExpiryDate") = MigExpiryDate
                    .Item("AuctionDate") = MigAuctionDate
                    .Item("Appraisal") = MigAppraisal
                    .Item("Principal") = MigPrincipal
                    .Item("NetAmount") = MigNetAount
                    .Item("AppraiserID") = MigAppraiserID
                    .Item("EncoderID") = MigEncoderID
                    .Item("ClaimerID") = MigClientID
                    .Item("ClientID") = MigClientID
                    .Item("PawnItemID") = GetLastID()
                    .Item("Description") = MigDiscription
                    .Item("ORNum") = MigOrNum
                    .Item("ORDate") = MigOrDate
                    .Item("Penalty") = MigPenalty
                    .Item("Status") = MigStatus
                    .Item("DaysOverDue") = MigDayOverDue
                    .Item("EarlyRedeem") = MigEarlyRedeem
                    .Item("DelayInterest") = MigInterest
                    .Item("AdvInt") = MigAdvInt
                    .Item("RenewDue") = MigRenewDue
                    .Item("RedeemDue") = MigRedeemDue
                    .Item("ServiceCharge") = MigServiceCharge
                    .Item("Created_at") = Now
                End With
                DsOpt.Tables("OPT").Rows.Add(dsNewRow)
                database.SaveEntry(DsOpt)
            End If


            pbProgressBar.Value = pbProgressBar.Value + 1
            Application.DoEvents()
            lblPercent.Text = String.Format("{0}%", ((pbProgressBar.Value / pbProgressBar.Maximum) * 100).ToString("F2"))
        Next
        If MsgBox("Successful", MsgBoxStyle.OkOnly + MsgBoxStyle.Information, _
             "Migrating...") = MsgBoxResult.Ok Then pbProgressBar.Minimum = 0 : pbProgressBar.Value = 0 : lblPercent.Text = "0.00%"
        'Catch ex As Exception
        '    MsgBox(ex.Message, MsgBoxStyle.Critical)
        'End Try
    End Sub

    Private Sub PatchTables()

        'Scheme
        Dim TableScheme As String = "CREATE TABLE TBLINTSCHEMES ("
        TableScheme &= "SCHEMEID INTEGER NOT NULL, "
        TableScheme &= "SCHEMENAME VARCHAR(50) NOT NULL, "
        TableScheme &= "DESCRIPTION VARCHAR(255));"
        Dim SchemeKey As String = "ALTER TABLE TBLINTSCHEMES ADD PRIMARY KEY (SCHEMEID);"

        Dim TableSchemeDetail As String = "CREATE TABLE TBLINTSCHEME_DETAILS ("
        TableSchemeDetail &= "IS_ID INTEGER NOT NULL, "
        TableSchemeDetail &= "SCHEMEID INTEGER DEFAULT '0' NOT NULL, "
        TableSchemeDetail &= "DAYFROM SMALLINT DEFAULT '0' NOT NULL, "
        TableSchemeDetail &= "DAYTO SMALLINT DEFAULT '0' NOT NULL, "
        TableSchemeDetail &= "INTEREST DECIMAL(12, 3) DEFAULT '0.0' NOT NULL, "
        TableSchemeDetail &= "PENALTY DECIMAL(12, 3) DEFAULT '0.0' NOT NULL, "
        TableSchemeDetail &= "REMARKS VARCHAR(255));"
        Dim SchemeDetailKey As String = "ALTER TABLE TBLINTSCHEME_DETAILS ADD PRIMARY KEY (IS_ID);"

        'PawnItem
        Dim TableOpi As String = "CREATE TABLE OPI ("
        TableOpi &= "PAWNITEMID BIGINT NOT NULL, "
        TableOpi &= "ITEMID INTEGER DEFAULT '0' NOT NULL, "
        TableOpi &= "ITEMCLASS VARCHAR(50) NOT NULL, "
        TableOpi &= "SCHEME_ID INTEGER DEFAULT '0' NOT NULL, "
        TableOpi &= "WITHDRAWDATE DATE, "
        TableOpi &= "STATUS VARCHAR(1) DEFAULT 'A' NOT NULL, "
        TableOpi &= "RENEWALCNT SMALLINT DEFAULT '0' NOT NULL, "
        TableOpi &= "CREATED_AT DATE NOT NULL, "
        TableOpi &= "UPDATED_AT DATE DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"
        Dim OpiKey As String = "ALTER TABLE OPI ADD PRIMARY KEY (PAWNITEMID);"

        'PawnTicket
        Dim TableOpt As String = "CREATE TABLE OPT ("
        TableOpt &= "PAWNID BIGINT NOT NULL, "
        TableOpt &= "PAWNTICKET BIGINT DEFAULT '0' NOT NULL, "
        TableOpt &= "OLDTICKET BIGINT DEFAULT '0' NOT NULL, "
        TableOpt &= "LOANDATE DATE NOT NULL, "
        TableOpt &= " MATUDATE DATE, "
        TableOpt &= " EXPIRYDATE DATE, "
        TableOpt &= " AUCTIONDATE DATE, "
        TableOpt &= " APPRAISAL NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= " PRINCIPAL NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= " NETAMOUNT NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= " APPRAISERID SMALLINT DEFAULT '0' NOT NULL, "
        TableOpt &= " ENCODERID SMALLINT DEFAULT '0' NOT NULL, "
        TableOpt &= " CLAIMERID BIGINT DEFAULT '0' NOT NULL, "
        TableOpt &= " CLIENTID BIGINT DEFAULT '0' NOT NULL, "
        TableOpt &= " PAWNITEMID BIGINT DEFAULT '0' NOT NULL, "
        TableOpt &= " DESCRIPTION VARCHAR(255), "
        TableOpt &= " ORDATE DATE, "
        TableOpt &= " ORNUM BIGINT DEFAULT '0' NOT NULL, "
        TableOpt &= " PENALTY NUMERIC(12, 2), "
        TableOpt &= " STATUS VARCHAR(1) DEFAULT 'L' NOT NULL, "
        TableOpt &= " DAYSOVERDUE SMALLINT DEFAULT '0' NOT NULL, "
        TableOpt &= " EARLYREDEEM NUMERIC(12, 2) DEFAULT '0.0', "
        TableOpt &= " DELAYINTEREST NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= " ADVINT NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= " RENEWDUE NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= " REDEEMDUE NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= "SERVICECHARGE NUMERIC(12, 2) DEFAULT '0.0' NOT NULL, "
        TableOpt &= "CREATED_AT DATE, "
        TableOpt &= " UPDATED_AT DATE);"
        Dim OptKey As String = "ALTER TABLE OPT ADD PRIMARY KEY (PAWNID);"

        'PawnItem Specs and Value
        Dim TablePi1 As String = "CREATE TABLE PI1 ("
        TablePi1 &= "PAWNSPECSID BIGINT NOT NULL, "
        TablePi1 &= "UOM VARCHAR(100), "
        TablePi1 &= "SPECSNAME VARCHAR(50) NOT NULL, "
        TablePi1 &= "SPECSTYPE VARCHAR(50) NOT NULL, "
        TablePi1 &= "SPECSVALUE VARCHAR(50), "
        TablePi1 &= "ISREQUIRED SMALLINT DEFAULT '0' NOT NULL, "
        TablePi1 &= "PAWNITEMID BIGINT DEFAULT '0' NOT NULL);"
        Dim Pi1Key As String = "ALTER TABLE PI1 ADD PRIMARY KEY (PAWNSPECSID);"

        'Item
        Dim TableItem As String = "CREATE TABLE TBLITEM ("
        TableItem &= "ITEMID BIGINT NOT NULL, "
        TableItem &= "ITEMCLASS VARCHAR(50) DEFAULT 'NONE' NOT NULL, "
        TableItem &= "ITEMCATEGORY VARCHAR(50) DEFAULT 'N/A' NOT NULL, "
        TableItem &= " DESCRIPTION VARCHAR(255), "
        TableItem &= " ISRENEW SMALLINT DEFAULT '0' NOT NULL, "
        TableItem &= " ONHOLD SMALLINT DEFAULT '0', "
        TableItem &= " PRINT_LAYOUT VARCHAR(100), "
        TableItem &= " RENEWAL_CNT SMALLINT DEFAULT '0' NOT NULL, "
        TableItem &= " CREATED_AT DATE NOT NULL, "
        TableItem &= " UPDATED_AT DATE DEFAULT CURRENT_TIMESTAMP    NOT NULL, "
        TableItem &= " SCHEME_ID BIGINT DEFAULT '0' NOT NULL);"
        Dim ItemKey As String = "ALTER TABLE TBLITEM ADD PRIMARY KEY (ITEMID);"

        'Specs
        Dim TableSpecs As String = "CREATE TABLE TBLSPECS ("
        TableSpecs &= "SPECSID BIGINT NOT NULL,"
        TableSpecs &= "ITEMID BIGINT NOT NULL,"
        TableSpecs &= "SPECSNAME VARCHAR(50) NOT NULL,"
        TableSpecs &= " SPECTYPE VARCHAR(50),"
        TableSpecs &= " UOM VARCHAR(10),"
        TableSpecs &= " ONHOLD SMALLINT DEFAULT '0' NOT NULL,"
        TableSpecs &= " SPECLAYOUT VARCHAR(100) NOT NULL,"
        TableSpecs &= " SHORTCODE VARCHAR(50),"
        TableSpecs &= " ISREQUIRED SMALLINT DEFAULT '0' NOT NULL,"
        TableSpecs &= " CREATED_AT DATE NOT NULL,"
        TableSpecs &= " UPDATED_AT DATE DEFAULT CURRENT_TIMESTAMP(0) NOT NULL);"
        Dim SpecsKey As String = "ALTER TABLE TBLSPECS ADD PRIMARY KEY (SPECSID);"

        Dim Pawn_List As String
        Pawn_List = "CREATE VIEW PAWN_LIST("
        Pawn_List &= vbCrLf & "PAWNID, "
        Pawn_List &= vbCrLf & "PAWNTICKET, "
        Pawn_List &= vbCrLf & "LOANDATE, "
        Pawn_List &= vbCrLf & "MATUDATE, "
        Pawn_List &= vbCrLf & "EXPIRYDATE, "
        Pawn_List &= vbCrLf & "AUCTIONDATE, "
        Pawn_List &= vbCrLf & "CLIENT, "
        Pawn_List &= vbCrLf & "CONTACTNUMBER, "
        Pawn_List &= vbCrLf & "FULLADDRESS, "
        Pawn_List &= vbCrLf & "ITEMCLASS, "
        Pawn_List &= vbCrLf & "ITEMCATEGORY, "
        Pawn_List &= vbCrLf & "DESCRIPTION, "
        Pawn_List &= vbCrLf & "OLDTICKET, "
        Pawn_List &= vbCrLf & "ORNUM, "
        Pawn_List &= vbCrLf & "ORDATE, "
        Pawn_List &= vbCrLf & "PRINCIPAL, "
        Pawn_List &= vbCrLf & "DELAYINTEREST, "
        Pawn_List &= vbCrLf & "ADVINT, "
        Pawn_List &= vbCrLf & "SERVICECHARGE, "
        Pawn_List &= vbCrLf & "NETAMOUNT, "
        Pawn_List &= vbCrLf & "RENEWDUE, "
        Pawn_List &= vbCrLf & "REDEEMDUE, "
        Pawn_List &= vbCrLf & "APPRAISAL, "
        Pawn_List &= vbCrLf & "PENALTY, "
        Pawn_List &= vbCrLf & "STATUS, "
        Pawn_List &= vbCrLf & "WITHDRAWDATE, "
        Pawn_List &= vbCrLf & "APPRAISER) "
        Pawn_List &= vbCrLf & "AS "
        Pawn_List &= vbCrLf & "SELECT "
        Pawn_List &= vbCrLf & "P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.AUCTIONDATE, "
        Pawn_List &= vbCrLf & "C.FIRSTNAME || ' ' || C.LASTNAME AS CLIENT, C.PHONE1 AS CONTACTNUMBER, "
        Pawn_List &= vbCrLf & "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        Pawn_List &= vbCrLf & "ITM.ITEMCLASS, CLASS.ITEMCATEGORY, P.DESCRIPTION, "
        Pawn_List &= vbCrLf & "P.OLDTICKET, P.ORNUM, P.ORDATE, P.PRINCIPAL, P.DELAYINTEREST, P.ADVINT, P.SERVICECHARGE, "
        Pawn_List &= vbCrLf & "P.NETAMOUNT, P.RENEWDUE, P.REDEEMDUE, P.APPRAISAL,P.PENALTY, "
        Pawn_List &= vbCrLf & "P.STATUS, ITM.WITHDRAWDATE, USR.USERNAME AS APPRAISER "
        Pawn_List &= vbCrLf & "FROM OPT P "
        Pawn_List &= vbCrLf & "INNER JOIN TBLCLIENT C "
        Pawn_List &= vbCrLf & "ON P.CLIENTID = C.CLIENTID "
        Pawn_List &= vbCrLf & "INNER JOIN OPI ITM "
        Pawn_List &= vbCrLf & "ON ITM.PAWNITEMID = P.PAWNITEMID "
        Pawn_List &= vbCrLf & "INNER JOIN TBLITEM CLASS "
        Pawn_List &= vbCrLf & "ON CLASS.ITEMID = ITM.ITEMID "
        Pawn_List &= vbCrLf & "INNER JOIN TBL_GAMIT USR "
        Pawn_List &= vbCrLf & "ON USR.USERID = P.APPRAISERID "

        'Create Tables
        RunCommand(TableScheme)
        RunCommand(TableSchemeDetail)
        RunCommand(TableOpi)
        RunCommand(TableOpt)
        RunCommand(TablePi1)
        RunCommand(TableItem)
        RunCommand(TableSpecs)
        RunCommand(Pawn_List)

        'Add Primary Key to Tables
        RunCommand(SchemeKey)
        RunCommand(SchemeDetailKey)
        RunCommand(OpiKey)
        RunCommand(OptKey)
        RunCommand(Pi1Key)
        RunCommand(ItemKey)
        RunCommand(SpecsKey)


        'Add AutoIncrement to Tables
        AutoIncrement_ID("TBLINTSCHEMES", "SCHEMEID")
        AutoIncrement_ID("TBLINTSCHEME_DETAILS", "IS_ID")
        AutoIncrement_ID("OPI", "PAWNITEMID")
        AutoIncrement_ID("OPT", "PAWNID")
        AutoIncrement_ID("PI1", "PAWNSPECSID")
        AutoIncrement_ID("TBLITEM", "ITEMID")
        AutoIncrement_ID("TBLSPECS", "SPECSID")

    End Sub

    Enum ItemClass As Integer
        ID = 0
        Name = 1
    End Enum

    Private Function GetClass(ByVal Item As String, ByVal TYPE As ItemClass)
        Dim strItem As String, mysql As String, ds As DataSet
        If Item = "HOME APP-SMALL" Then
            strItem = "HOME APPLIANCES"
        ElseIf Item = "MOTORCYCLE" Then
            strItem = "MOTOR"
        ElseIf Item = "HOME APP-BIG" Then
            strItem = "BIG APPLIANCES"
        ElseIf Item = "CAMERA" Then
            strItem = "COMPACT CAMERA"
        Else
            strItem = Item
        End If
        mysql = "Select * from tblItem where ItemCLass = '" & strItem & "'"
        ds = LoadSQL(mysql, "tblItem")
        Select Case TYPE
            Case ItemClass.ID
                Return ds.Tables(0).Rows(0).Item("ItemID")

            Case ItemClass.Name
                Return ds.Tables(0).Rows(0).Item("ItemClass")

        End Select
        Return strItem
    End Function

    Private Function GetLastID() As Single
        Dim mySql As String = "SELECT * FROM OPI ORDER BY PawnItemID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("PawnItemID")
    End Function

    Private Function GetInt(ByVal ItemType As String, ByVal CheckSum As String)

        Dim mySql As String = "Select * from tblint_history where checksum = '" & CheckSum & "' and itemtype = '" & ItemType & "' and dayfrom = '34'"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Dim tmpInt As String = ds.Tables(0).Rows(0).Item("Interest")
        tmpInt = tmpInt / 2
        Return GetScheme(tmpInt, CheckSum, ItemType)

    End Function

    Private Function GetScheme(ByVal Int As String, ByVal checksum As String, ByVal ItemType As String)
        Dim mySql As String
        mySql = "Select * from tblint_history where checksum = '" & checksum & "' and Itemtype = '" & ItemType & "' Rows 1"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim isEarlyRedeem As Boolean = False
        Dim tmpID As String

        If ds.Tables(0).Rows(0).Item("Remarks") = "Early Redemption" Then isEarlyRedeem = True
        If isEarlyRedeem = True Then
            mySql = "SELECT  I.SCHEMEID, I.SCHEMENAME, I.DESCRIPTION, D.DAYFROM, D.DAYTO, "
            mySql &= "D.INTEREST, D.PENALTY, D.REMARKS "
            mySql &= "FROM TBLINTSCHEMES I INNER JOIN TBLINTSCHEME_DETAILS D ON I.SCHEMEID = D.SCHEMEID "
            mySql &= "Where UPPER(I.DESCRIPTION) LIKE UPPER('%Early Redemption%') AND DAYTO = 33 AND D.INTEREST = " & Int
        Else
            mySql = "SELECT  I.SCHEMEID, I.SCHEMENAME, I.DESCRIPTION, D.DAYFROM, D.DAYTO, "
            mySql &= "D.INTEREST, D.PENALTY, D.REMARKS "
            mySql &= "FROM TBLINTSCHEMES I INNER JOIN TBLINTSCHEME_DETAILS D ON I.SCHEMEID = D.SCHEMEID "
            mySql &= "Where UPPER(I.DESCRIPTION) NOT LIKE UPPER('%Early Redemption%') AND DAYTO = 33 AND D.INTEREST = " & Int
        End If

        Dim dsScheme As DataSet = LoadSQL(mySql)
        tmpID = dsScheme.Tables(0).Rows(0).Item("SCHEMEID")
        Return tmpID
    End Function

    Private Sub frmMigrate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            PatchTables()
            Database_Update(LATEST_VERSION)

            Dim mysql As String = "Select * from tblPawn"
            Dim filldata As String = "tblPawn"
            Dim ds As DataSet = LoadSQL(mysql, filldata)
            If ds.Tables(0).Rows.Count = 0 Then MsgBox("No Data Found!", MsgBoxStyle.Critical, "Check Your Database") : Me.Close()
            Dim tmpMax As Integer = ds.Tables(0).Rows.Count
            pbProgressBar.Minimum = 0
            pbProgressBar.Maximum = tmpMax

        Catch ex As Exception
            Log_Report("[1.2.2.5]" & ex.ToString)
        End Try
        Try
            updateRate.do_RateUpdate(My.Application.Info.DirectoryPath & "\Migrate\Interest.cir")
            updateRate.do_RateUpdate(My.Application.Info.DirectoryPath & "\Migrate\Item.cir")
        Catch ex As Exception
            MsgBox("Please Check Cir Path!", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Migrate()
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub

    Private Sub AutoIncrement_ID(ByVal tbl As String, ByVal id As String)
        Dim GENERATOR As String
        GENERATOR = String.Format("CREATE GENERATOR {0}_{1}_GEN; ", tbl, id)
        RunCommand(GENERATOR)

        GENERATOR = String.Format("SET GENERATOR ""{0}_{1}_GEN"" TO 0;", tbl, id)
        RunCommand(GENERATOR)

        GENERATOR = String.Format("CREATE TRIGGER ""{0}_{1}_TRG"" FOR ""{0}""", tbl, id)
        GENERATOR &= vbCrLf & "ACTIVE BEFORE INSERT POSITION 0 AS"
        GENERATOR &= vbCrLf & "BEGIN"
        GENERATOR &= vbCrLf & String.Format("IF (NEW.""{1}"" IS NULL) THEN NEW.""{1}"" = GEN_ID(""{0}_{1}_GEN"", 1);", tbl, id)
        GENERATOR &= vbCrLf & "END;"
        RunCommand(GENERATOR)
    End Sub

    Private Function isPatchable(ByVal allowVersion As String) As Boolean
        On Error GoTo err
        Dim mySql As String, ds As DataSet

        mySql = "SELECT * FROM TBLMAINTENANCE WHERE OPT_KEYS = 'DBVersion'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("PATCH PROBLEM", MsgBoxStyle.Critical) : Return False

        Console.WriteLine(ds.Tables(0).Rows(0).Item("OPT_VALUES"))
        Return IIf(ds.Tables(0).Rows(0).Item("OPT_VALUES") = allowVersion, True, False)

err:
        MsgBox("PATCH PROBLEM UNKNOWN", MsgBoxStyle.Critical)
        Return False
    End Function

    Friend Sub Database_Update(ByVal str As String)
        Dim mySql As String = "UPDATE tblMaintenance"
        mySql &= String.Format(" SET OPT_VALUES = '{0}' ", str)
        mySql &= "WHERE OPT_KEYS = 'DBVersion'"

        RunCommand(mySql)
    End Sub

    Private Sub RunCommand(ByVal sql As String)
        conStr = "DRIVER=Firebird/InterBase(r) driver;User=" & fbUser & ";Password=" & fbPass & ";Database=" & dbName & ";"
        con = New OdbcConnection(conStr)

        Dim cmd As OdbcCommand
        cmd = New OdbcCommand(sql, con)

        Try
            con.Open()
            cmd.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
            Log_Report(String.Format("[{0}] - ", sql) & ex.ToString)
            con.Dispose()
            Exit Sub
        End Try

        System.Threading.Thread.Sleep(1000)
    End Sub
End Class