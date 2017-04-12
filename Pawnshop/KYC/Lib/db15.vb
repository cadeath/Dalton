Module db15
    Const ALLOWABLE_VERSION As String = "1.5.0.6"
    Const LATEST_VERSION As String = "1.5.0.7"

    Private strSql As String

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub
        Try

            Add_Table_KYC_CUSTOMERS()
            Add_Table_KYC_PHONE()
            Add_Table_KYC_ID()

            Database_Update(LATEST_VERSION)
            'Log_Report(String.Format("SYSTEM PATCHED UP FROM {0} TO {1}", ALLOWABLE_VERSION, LATEST_VERSION))
        Catch ex As Exception
            ' Log_Report(String.Format("[{0}]" & ex.ToString, LATEST_VERSION))
        End Try
    End Sub

    Private Sub Add_Table_KYC_CUSTOMERS()
        Dim kyc_Customer As String
        kyc_Customer = "CREATE TABLE KYC_CUSTOMERS ("
        kyc_Customer &= vbCrLf & "   ID BIGINT NOT NULL,"
        kyc_Customer &= vbCrLf & "   FIRSTNAME VARCHAR(150),"
        kyc_Customer &= vbCrLf & "   MIDNAME VARCHAR(50) DEFAULT '' NOT NULL,"
        kyc_Customer &= vbCrLf & "   LASTNAME VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   SUFFIX VARCHAR(5),"
        kyc_Customer &= vbCrLf & "   STREET1 VARCHAR(50) DEFAULT '' NOT NULL,"
        kyc_Customer &= vbCrLf & "   BRGY1 VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   CITY1 VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   PROVINCE1 VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   ZIP1 VARCHAR(4) DEFAULT '' NOT NULL,"
        kyc_Customer &= vbCrLf & "   STREET2 VARCHAR(50) DEFAULT '' NOT NULL,"
        kyc_Customer &= vbCrLf & "   BRGY2 VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   CITY2 VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   ZIP2 VARCHAR(4) DEFAULT '' NOT NULL,"
        kyc_Customer &= vbCrLf & "   BIRTHDAY DATE DEFAULT CURRENT_TIMESTAMP(0) NOT NULL,"
        kyc_Customer &= vbCrLf & "   BIRTHPLACE VARCHAR(255) DEFAULT '' NOT NULL,"
        kyc_Customer &= vbCrLf & "   NATUREOFWORK VARCHAR(100),"
        kyc_Customer &= vbCrLf & "   NATIONALITY VARCHAR(20),"
        kyc_Customer &= vbCrLf & "   GENDER VARCHAR(1) DEFAULT 'F' NOT NULL,"
        kyc_Customer &= vbCrLf & "   SRCFUND VARCHAR(50),"
        kyc_Customer &= vbCrLf & "   RANK SMALLINT DEFAULT '0' NOT NULL,"
        kyc_Customer &= vbCrLf & "   CLIENT_IMG VARCHAR(75) NOT NULL);"

        RunCommand(kyc_Customer)
        AutoIncrement_ID("KYC_CUSTOMERS", "ID")

        Console.WriteLine("Table KYC Created")
    End Sub

    Private Sub Add_Table_KYC_PHONE()
        Dim KYC_PHONE As String
        KYC_PHONE = "CREATE TABLE KYC_PHONE ("
        KYC_PHONE &= vbCrLf & "   PHONEID BIGINT NOT NULL,"
        KYC_PHONE &= vbCrLf & "   CUSTID BIGINT DEFAULT '0' NOT NULL,"
        KYC_PHONE &= vbCrLf & "  PHONENUMBER VARCHAR(20),"
        KYC_PHONE &= vbCrLf & "   ISPRIMARY SMALLINT DEFAULT '0' NOT NULL);"


        RunCommand(KYC_PHONE)
        AutoIncrement_ID("KYC_PHONE", "PHONEID")

        Console.WriteLine("Table KYC Phone Created")
    End Sub

    Private Sub Add_Table_KYC_ID()
        Dim KYC_PHONE As String
        KYC_PHONE = "CREATE TABLE KYC_ID ("
        KYC_PHONE &= vbCrLf & "  ID INTEGER NOT NULL,"
        KYC_PHONE &= vbCrLf & "  CUSTID BIGINT DEFAULT '0' NOT NULL,"
        KYC_PHONE &= vbCrLf & "  ID_TYPE VARCHAR(20),"
        KYC_PHONE &= vbCrLf & "  ID_NUMBER VARCHAR(255),"
        KYC_PHONE &= vbCrLf & "  ISPRIMARY SMALLINT DEFAULT '0' NOT NULL);"

        RunCommand(KYC_PHONE)
        AutoIncrement_ID("KYC_ID", "ID")

        Console.WriteLine("Table KYC_ID Created")
    End Sub
End Module
