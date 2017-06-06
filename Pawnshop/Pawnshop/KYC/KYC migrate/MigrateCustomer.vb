Imports System.IO

''' <summary>
''' This Class is made for the purpose of KYC Compliance
''' </summary>
''' <remarks></remarks>
Public Class MigrateCustomer
    Private SRC As String = Application.StartupPath & "\ClientImage"
    Dim indexof As String
    Dim lastindexof As String

#Region "Properties"
    Private _id As Integer
    Public Property CustomerID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _firstName As String
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    Private _middleName As String
    Public Property MiddleName() As String
        Get
            Return _middleName
        End Get
        Set(ByVal value As String)
            _middleName = value
        End Set
    End Property

    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Private _suffix As String
    Public Property Suffix() As String
        Get
            Return _suffix
        End Get
        Set(ByVal value As String)
            _suffix = value
        End Set
    End Property

    Private _addrStreet1 As String
    Public Property PresentStreet() As String
        Get
            Return _addrStreet1
        End Get
        Set(ByVal value As String)
            _addrStreet1 = value
        End Set
    End Property

    Private _addrBrgy1 As String
    Public Property PresentBarangay() As String
        Get
            Return _addrBrgy1
        End Get
        Set(ByVal value As String)
            _addrBrgy1 = value
        End Set
    End Property

    Private _addrCity1 As String
    Public Property PresentCity() As String
        Get
            Return _addrCity1
        End Get
        Set(ByVal value As String)
            _addrCity1 = value
        End Set
    End Property

    Private _addrProvince1 As String
    Public Property PresentProvince() As String
        Get
            Return _addrProvince1
        End Get
        Set(ByVal value As String)
            _addrProvince1 = value
        End Set
    End Property

    Private _addrZip1 As String
    Public Property PresentZipCode() As String
        Get
            Return _addrZip1
        End Get
        Set(ByVal value As String)
            _addrZip1 = value
        End Set
    End Property

    Private _addrStreet2 As String
    Public Property PermanentStreet() As String
        Get
            Return _addrStreet2
        End Get
        Set(ByVal value As String)
            _addrStreet2 = value
        End Set
    End Property

    Private _addrBrgy2 As String
    Public Property PermanentBarangay() As String
        Get
            Return _addrBrgy2
        End Get
        Set(ByVal value As String)
            _addrBrgy2 = value
        End Set
    End Property

    Private _addrCity2 As String
    Public Property PermanentCity() As String
        Get
            Return _addrCity2
        End Get
        Set(ByVal value As String)
            _addrCity2 = value
        End Set
    End Property

    Private _addrProvince2 As String
    Public Property PermanentProvince() As String
        Get
            Return _addrProvince2
        End Get
        Set(ByVal value As String)
            _addrProvince2 = value
        End Set
    End Property

    Private _addrZip2 As String
    Public Property PermanentZipCode() As String
        Get
            Return _addrZip2
        End Get
        Set(ByVal value As String)
            _addrZip2 = value
        End Set
    End Property

    Enum Gender As Integer
        Male = 1
        Female = 0
    End Enum

    Private _sex As Gender
    Public Property Sex() As Gender
        Get
            Return _sex
        End Get
        Set(ByVal value As Gender)
            _sex = value
        End Set
    End Property

    Private _birthday As Date
    Public Property Birthday() As Date
        Get
            Return _birthday
        End Get
        Set(ByVal value As Date)
            _birthday = value
        End Set
    End Property

    Private _birthplace As String
    Public Property BirthPlace() As String
        Get
            Return _birthplace
        End Get
        Set(ByVal value As String)
            _birthplace = value
        End Set
    End Property

    Private _nationality As String
    Public Property Nationality() As String
        Get
            Return _nationality
        End Get
        Set(ByVal value As String)
            _nationality = value
        End Set
    End Property

    Private _natureOfWork As String
    Public Property NatureOfWork() As String
        Get
            Return _natureOfWork
        End Get
        Set(ByVal value As String)
            _natureOfWork = value
        End Set
    End Property

    Private _businessNameOrEmployeer As String
    Public Property BusinessnameOrEmployeer() As String
        Get
            Return _businessNameOrEmployeer
        End Get
        Set(ByVal value As String)
            _businessNameOrEmployeer = value
        End Set
    End Property

    Private _sourceOfFund As String
    Public Property SourceOfFund() As String
        Get
            Return _sourceOfFund
        End Get
        Set(ByVal value As String)
            _sourceOfFund = value
        End Set
    End Property

    Enum RankNumber As Integer
        Low = 0
        Medium = 1
        High = 2
    End Enum
    Private _rank As RankNumber
    Public Property Rank() As RankNumber
        Get
            Return _rank
        End Get
        Set(ByVal value As RankNumber)
            _rank = value
        End Set
    End Property


    Private _custIDs As Migrate_ID
    Public Property CustomersIDs() As Migrate_ID
        Get
            Return _custIDs
        End Get
        Set(ByVal value As Migrate_ID)
            _custIDs = value
        End Set
    End Property

    Private _custPhones As ColMigrate_Phone
    Public Property CustomersPhone() As ColMigrate_Phone
        Get
            Return _custPhones
        End Get
        Set(ByVal value As ColMigrate_Phone)
            _custPhones = value
        End Set
    End Property

    Private _CImage As String
    Public Property CImage() As String
        Get
            Return _CImage
        End Get
        Set(ByVal value As String)
            _CImage = value
        End Set
    End Property

    Private _cPUREIMAGE As Image
    Public Property CPUREIMAGE As Image
        Get
            Return _cPUREIMAGE
        End Get
        Set(ByVal value As Image)
            _cPUREIMAGE = value
        End Set
    End Property

    Private _iSDumper As Boolean
    Public Property iSDumper() As Boolean
        Get
            Return _iSDumper
        End Get
        Set(ByVal value As Boolean)
            _iSDumper = value
        End Set
    End Property
#End Region

#Region "Procedures"
    Public Sub Save()
        Dim mySql As String = "SELECT * FROM " & CUSTOMER_TABLE
        Dim ds As DataSet = LoadSQL(mySql, CUSTOMER_TABLE)

       
        Dim dsNewRowc As DataRow
        dsNewRowc = ds.Tables(CUSTOMER_TABLE).NewRow
        With dsNewRowc
            .Item("ID") = _id
            .Item("FIRSTNAME") = _firstName
            .Item("MIDNAME") = _middleName
            .Item("LASTNAME") = _lastName
            .Item("Suffix") = _suffix

            .Item("STREET1") = _addrStreet1
            .Item("BRGY1") = _addrBrgy1
            .Item("CITY1") = _addrCity1
            .Item("PROVINCE1") = _addrProvince1
            .Item("ZIP1") = _addrZip1

            .Item("BIRTHDAY") = _birthday
            .Item("GENDER") = IIf(_sex = Gender.Male, "M", "F")
            .Item("IsDumper") = If(_iSDumper, 1, 0)
        End With
        ds.Tables(CUSTOMER_TABLE).Rows.Add(dsNewRowc)
        database.SaveEntry(ds)

        'SAVING IDS
        If KYCConfig.IDCOUNT <= 0 Then GoTo NEXTLINE
        mySql = "SELECT * FROM " & CUSTOMER_ID
        ds.Clear()
        ds = LoadSQL(mySql, CUSTOMER_ID)

        Dim dsNewRow As DataRow
        For Each id As MigrateIdentificationCard In _custIDs

            dsNewRow = ds.Tables(CUSTOMER_ID).NewRow
            With dsNewRow
                ' .Item("ID") = id.ID
                .Item("CUSTID") = id.CustomerID
                .Item("ID_TYPE") = id.IDType
                .Item("ID_NUMBER") = id.IDNumber
            End With
            ds.Tables(CUSTOMER_ID).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        Next

NEXTLINE:

        'SAVING PHONES
        If KYCConfig.phneCOUNT <= 0 Then Exit Sub

        mySql = "SELECT * FROM " & CUSTOMER_PHONE
        ds.Clear()
        ds = LoadSQL(mySql, CUSTOMER_PHONE)
        Dim dsNewRowPH As DataRow

        For Each ph As MigratePhoneNumber In _custPhones

            dsNewRowPH = ds.Tables(CUSTOMER_PHONE).NewRow
            With dsNewRowPH
                .Item("CUSTID") = ph.CustomerID
                .Item("PHONENUMBER") = ph.PhoneNumber
                .Item("ISPRIMARY") = IIf(ph.isPrimary, 1, 0)
            End With
            ds.Tables(CUSTOMER_PHONE).Rows.Add(dsNewRowPH)

            database.SaveEntry(ds)
        Next

    End Sub
#End Region

End Class