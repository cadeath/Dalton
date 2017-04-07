Module KYCConfig

    Friend LOAD_CACHE As Boolean = False
    Friend listBarangay As List(Of String)
    Friend listCity As List(Of String)
    Friend listProvince As List(Of String)
    Friend listZip As List(Of String)

    Friend Const CUSTOMER_TABLE As String = "KYC_CUSTOMERS"
    Friend Const CUSTOMER_ID As String = "KYC_ID"
    Friend Const CUSTOMER_PHONE As String = "KYC_PHONE"

    Friend Sub KYC_Initialization()
        Create_Tables()
        MigrateClients_Info()
    End Sub

    Friend Sub CACHE_MANAGEMENT()
        If LOAD_CACHE Then Exit Sub
        Dim mySql As String

        mySql = "SELECT DISTINCT BRGY1 AS ""BRGY"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT BRGY2 FROM KYC_CUSTOMERS"
        listBarangay = New List(Of String)
        listBarangay.AddRange(AddList(mySql, "BRGY"))

        mySql = "SELECT DISTINCT CITY1 AS ""CITY"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT CITY2 FROM KYC_CUSTOMERS"
        listCity = New List(Of String)
        listCity.AddRange(AddList(mySql, "CITY"))

        mySql = "SELECT DISTINCT PROVINCE1 AS ""PROVINCE"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT PROVINCE2 FROM KYC_CUSTOMERS"
        listProvince = New List(Of String)
        listProvince.AddRange(AddList(mySql, "PROVINCE"))

        mySql = "SELECT DISTINCT ZIP1 AS ""ZIP"" FROM KYC_CUSTOMERS "
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT DISTINCT ZIP2 FROM KYC_CUSTOMERS"
        listZip = New List(Of String)
        listZip.AddRange(AddList(mySql, "ZIP"))

        LOAD_CACHE = True
        Console.WriteLine("Cache already loaded...")
    End Sub

    Private Function AddList(mySql As String, colName As String) As Array
        Dim lst As New List(Of String)
        Dim ds As DataSet

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return {""}

        For Each dr As DataRow In ds.Tables(0).Rows
            lst.Add(dr(colName))
        Next

        Return lst.ToArray
    End Function

    ' TODO
    ' AutoPatch to Create Tables for this Branch
    Private Sub Create_Tables()
        Dim mySql As String, primaryKey As String

        ' CUSTOMER TABLE
        mySql = "CREATE TABLE " & CUSTOMER_TABLE & " ("
        mySql &= vbCrLf & "  ID BIGINT NOT NULL,"
        mySql &= vbCrLf & "  FIRSTNAME VARCHAR(150),"
        mySql &= vbCrLf & "  MIDNAME VARCHAR(50) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  LASTNAME VARCHAR(50),"
        mySql &= vbCrLf & "  STREET1 VARCHAR(50) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  BRGY1 VARCHAR(50),"
        mySql &= vbCrLf & "  CITY1 VARCHAR(50),"
        mySql &= vbCrLf & "  PROVINCE1 VARCHAR(50),"
        mySql &= vbCrLf & "  ZIP1 VARCHAR(4) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  STREET2 VARCHAR(50) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  BRGY2 VARCHAR(50),"
        mySql &= vbCrLf & "  CITY2 VARCHAR(50),"
        mySql &= vbCrLf & "  PROVINCE2 VARCHAR(50),"
        mySql &= vbCrLf & "  ZIP2 VARCHAR(4) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  BIRTHDAY DATE DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
        mySql &= vbCrLf & "  BIRTHPLACE VARCHAR(255) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  NATUREOFWORK VARCHAR(100),"
        mySql &= vbCrLf & "  NATIONALITY VARCHAR(20),"
        mySql &= vbCrLf & "  GENDER VARCHAR(1) DEFAULT 'F' NOT NULL,"
        mySql &= vbCrLf & "  SRCFUND VARCHAR(50),"
        mySql &= vbCrLf & "  RANK SMALLINT DEFAULT '0' NOT NULL);"
        primaryKey = "ALTER TABLE " & CUSTOMER_TABLE & " ADD PRIMARY KEY (ID);"

        ' PHONE ID
        mySql = "CREATE TABLE KYC_ID ("
        mySql &= vbCrLf & "  ID INTEGER NOT NULL,"
        mySql &= vbCrLf & "  CUSTID BIGINT DEFAULT '0' NOT NULL,"
        mySql &= vbCrLf & "  ID_TYPE VARCHAR(20),"
        mySql &= vbCrLf & "  ID_NUMBER VARCHAR(255),"
        mySql &= vbCrLf & "  ISPRIMARY SMALLINT DEFAULT '0' NOT NULL);"
        primaryKey = "ALTER TABLE KYC_ID ADD PRIMARY KEY (ID);"

        ' PHONE TABLE
        mySql = "CREATE TABLE KYC_PHONE ("
        mySql &= vbCrLf & "  PHONEID BIGINT NOT NULL,"
        mySql &= vbCrLf & "  CUSTID BIGINT DEFAULT '0' NOT NULL,"
        mySql &= vbCrLf & "  PHONENUMBER VARCHAR(20),"
        mySql &= vbCrLf & "  ISPRIMARY SMALLINT DEFAULT '0' NOT NULL);"
        primaryKey = "ALTER TABLE KYC_PHONE ADD PRIMARY KEY (PHONEID);"


    End Sub

    ' TODO
    ' AutoMigrate information
    Private Sub MigrateClients_Info()

    End Sub

End Module
