Imports System.Data.Odbc

Public Class frmUpdate
    Const ALLOWABLE_VERSION As String = "1.2.2.4"
    Const LATEST_VERSION As String = "1.2.2.5"
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub ofdUpdate_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdUpdate.FileOk
        txtConfig.Text = ofdUpdate.FileName
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If Not System.IO.File.Exists(txtConfig.Text) Then Exit Sub

        Disable(1)
        updateRate.do_RateUpdate(txtConfig.Text)
        Disable(0)
        MsgBox("System Updated", MsgBoxStyle.Information)
        Me.Close()
    End Sub
    Private Sub Disable(ByVal st As Boolean)
        btnUpdate.Enabled = Not st
        btnBrowse.Enabled = Not st
        btnCancel.Enabled = Not st
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdUpdate.ShowDialog()
    End Sub

    Private Sub frmUpdate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try
            PatchTables()

            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.2.2.3 TO 1.2.2.4")
        Catch ex As Exception
            Log_Report("[1.2.2.4]" & ex.ToString)
        End Try
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

        'Create Tables
        RunCommand(TableScheme)
        RunCommand(TableSchemeDetail)
        RunCommand(TableOpi)
        RunCommand(TableOpt)
        RunCommand(TablePi1)
        RunCommand(TableItem)
        RunCommand(TableSpecs)

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
    Friend Sub RunCommand(ByVal sql As String)
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

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
    End Sub
End Class