Module KYCConfig
    Friend phneCOUNT As Integer = 0
    Friend IDCOUNT As Integer = 0
    Dim kycCustomerGenerator = 0
    Dim kycIDCustomerGenerator = 0

    Friend LOAD_CACHE As Boolean = False
    Friend listBarangay As List(Of String)
    Friend listCity As List(Of String)
    Friend listProvince As List(Of String)
    Friend listZip As List(Of String)

    Friend Const CUSTOMER_TABLE As String = "KYC_CUSTOMERS"
    Friend Const CUSTOMER_ID As String = "KYC_ID"
    Friend Const CUSTOMER_PHONE As String = "KYC_PHONE"


    Dim mysql As String = String.Empty
    Dim oldClient As String = "TBLCLIENT"
    Dim oldiDentification As String = "TBLIDENTIFICATION"

    Private CustomerPhones As New ColMigrate_Phone
    Private CustomerIDs As New Migrate_ID

    Private PhoneCol As String()

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

    Private Function AddList(ByVal mySql As String, ByVal colName As String) As Array
        Dim lst As New List(Of String)
        Dim ds As DataSet

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return {""}

        For Each dr As DataRow In ds.Tables(0).Rows
            lst.Add(dr(colName))
        Next

        Return lst.ToArray
    End Function

    Private Sub Create_Tables()
        Dim mySql As String, primaryKey As String

        ' CUSTOMER TABLE
        mySql = "CREATE TABLE " & CUSTOMER_TABLE & " ("
        mySql &= vbCrLf & "  ID BIGINT NOT NULL,"
        mySql &= vbCrLf & "  FIRSTNAME VARCHAR(150),"
        mySql &= vbCrLf & "  MIDNAME VARCHAR(50) DEFAULT '' NOT NULL,"
        mySql &= vbCrLf & "  LASTNAME VARCHAR(50),"
        mySql &= vbCrLf & "  SUFFIX VARCHAR(5),"
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
        mySql &= vbCrLf & "  RANK SMALLINT DEFAULT '0' NOT NULL,"
        mySql &= vbCrLf & "  CLIENT_IMG VARCHAR(75));"
        primaryKey = "ALTER TABLE " & CUSTOMER_TABLE & " ADD PRIMARY KEY (ID);"

        RunCommand(mySql)
        AutoIncrement_ID(CUSTOMER_TABLE, "ID")

        ' PHONE ID
        mySql = "CREATE TABLE " & CUSTOMER_ID & " ("
        mySql &= vbCrLf & "  ID INTEGER NOT NULL,"
        mySql &= vbCrLf & "  CUSTID BIGINT DEFAULT '0' NOT NULL,"
        mySql &= vbCrLf & "  ID_TYPE VARCHAR(20),"
        mySql &= vbCrLf & "  ID_NUMBER VARCHAR(255),"
        mySql &= vbCrLf & "  ISPRIMARY SMALLINT DEFAULT '0' NOT NULL);"
        primaryKey = "ALTER TABLE KYC_ID ADD PRIMARY KEY (ID);"

        RunCommand(mySql)
        AutoIncrement_ID(CUSTOMER_ID, "ID")

        ' PHONE TABLE
        mySql = "CREATE TABLE " & CUSTOMER_PHONE & " ("
        mySql &= vbCrLf & "  PHONEID BIGINT NOT NULL,"
        mySql &= vbCrLf & "  CUSTID BIGINT DEFAULT '0' NOT NULL,"
        mySql &= vbCrLf & "  PHONENUMBER VARCHAR(20),"
        mySql &= vbCrLf & "  ISPRIMARY SMALLINT DEFAULT '0' NOT NULL);"
        primaryKey = "ALTER TABLE KYC_PHONE ADD PRIMARY KEY (PHONEID);"

        RunCommand(mySql)
        AutoIncrement_ID(CUSTOMER_PHONE, "PHONEID")

    End Sub


    Public Sub dirDB(Optional ByVal dbName As String = "W3W1LH4CKU.FDB")
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & dbName
        database.dbName = firebird

        frmClientMigrate.txtPath.Text = firebird
        frmClientMigrate.pBMigrate.Visible = False : frmClientMigrate.lblStatus.Visible = False
    End Sub

    ' TODO
    ' AutoMigrate information
    Private Sub MigrateClients_Info()

        diag_loading.ShowDialog()

        mysql = "SELECT * FROM " & oldClient & " ORDER BY CLIENTID ASC"
        Dim Clds As DataSet = LoadSQL(mysql, oldClient)

        If Clds.Tables(0).Rows.Count = 0 Then Exit Sub

        diag_loading.Set_Bar(Clds.Tables(0).Rows.Count)
        diag_loading.Reset_Bar()
        Dim kyc As New MigrateCustomer
        For Each clDR As DataRow In Clds.Tables(0).Rows
            CustomerPhones.Clear()
            CustomerIDs.Clear()

            With kyc
                .CustomerID = clDR.Item("CLIENTID")
                .FirstName = clDR.Item("FIRSTNAME")
                .MiddleName = clDR.Item("MIDDLENAME")
                .LastName = clDR.Item("LASTNAME")
                If IsDBNull(clDR.Item("SUFFIX")) Then
                    .Suffix = ""
                Else
                    .Suffix = clDR.Item("SUFFIX")
                End If


                '.Suffix = IIf(clDR.Item("SUFFIX") = "", clDR.Item("SUFFIX"), "")

                .PresentStreet = clDR.Item("ADDR_STREET")
                .PresentBarangay = clDR.Item("ADDR_BRGY")
                .PresentCity = clDR.Item("ADDR_CITY")
                .PresentProvince = clDR.Item("ADDR_PROVINCE")
                .PresentZipCode = clDR.Item("ADDR_ZIP")

                .Birthday = clDR.Item("BIRTHDAY")
                .Sex = IIf(clDR.Item("SEX") = "M", 1, 0)

                PhoneCol = {clDR.Item("PHONE1"), clDR.Item("PHONE2"), clDR.Item("PHONE3"), clDR.Item("PHONE_OTHERS")}

                Dim newPhone As New MigratePhoneNumber
                For Each phne In PhoneCol
                    If phne = "" Then
                        On Error Resume Next
                    Else
                        newPhone.PhoneNumber = phne
                        newPhone.CustomerID = clDR.Item("CLIENTID")
                        phneCOUNT += 1

                        CustomerPhones.Add(newPhone)
                    End If
                Next
                .CustomersPhone = CustomerPhones


                mysql = "SELECT * FROM " & oldiDentification & " WHERE CLIENTID = " & clDR.Item("CLIENTID")
                Dim dsID As DataSet = LoadSQL(mysql, oldiDentification)

                Dim newID As New MigrateIdentificationCard
                For Each drID As DataRow In dsID.Tables(0).Rows

                    newID.ID = drID.Item("ID")
                    newID.CustomerID = drID.Item("CLIENTID")
                    newID.IDType = drID.Item("IDTYPE")
                    newID.IDNumber = drID.Item("REFNUM")
                    IDCOUNT += 1

                    CustomerIDs.Add(newID)
                    kycIDCustomerGenerator = drID.Item("ID")
                Next
                .CustomersIDs = CustomerIDs

                .Save()

                kycCustomerGenerator = clDR.Item("CLIENTID")
                diag_loading.Add_Bar()
            End With
        Next

        diag_loading.Close()
        IDGerator(kycCustomerGenerator, kycIDCustomerGenerator)
    End Sub

    Private Sub IDGerator(ByVal ClientIDX As Integer, ByVal IDentification As Integer)
        mysql = "CREATE TRIGGER BI_KYC_CUSTOMERS_default_ID FOR KYC_CUSTOMERS_default "
        mysql &= vbCrLf & "ACTIVE BEFORE INSERT "
        mysql &= vbCrLf & "POSITION 0 "
        mysql &= vbCrLf & "AS "
        mysql &= vbCrLf & "BEGIN "
        mysql &= vbCrLf & "  IF (NEW.ID IS NULL) THEN "
        mysql &= vbCrLf & "      NEW.ID = GEN_ID(KYC_CUSTOMERS_default_ID_GEN, " & ClientIDX + 1 & "); "
        mysql &= vbCrLf & "END; "
        RunCommand(mysql)

        mysql = "CREATE TRIGGER BI_CUSTOMER_ID_default_ID FOR CUSTOMER_ID_default "
        mysql &= vbCrLf & "ACTIVE BEFORE INSERT "
        mysql &= vbCrLf & "POSITION 0 "
        mysql &= vbCrLf & "AS "
        mysql &= vbCrLf & "BEGIN "
        mysql &= vbCrLf & "  IF (NEW.ID IS NULL) THEN "
        mysql &= vbCrLf & "      NEW.ID = GEN_ID(CUSTOMER_ID_default_ID_GEN, " & IDentification + 1 & "); "
        mysql &= vbCrLf & "END; "
        RunCommand(mysql)
    End Sub
End Module
