''' <summary>
''' This Class is made for the purpose of KYC Compliance
''' </summary>
''' <remarks></remarks>
Public Class Customer

    Const CUSTOMER_TABLE As String = "KYC_CUSTOMERS"
    Const CUSTOMER_ID As String = "KYC_ID"
    Const CUSTOMER_PHONE As String = "KYC_PHONE"

#Region "Properties"
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
    Public Property lastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
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
    Public Property PemanentStreet() As String
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

    Private _addrZipCode2 As String
    Public Property PermanentZipCode() As String
        Get
            Return _addrZipCode2
        End Get
        Set(ByVal value As String)
            _addrZipCode2 = value
        End Set
    End Property

    Private Enum Gender As Integer
        Male = 1
        Female = 0
    End Enum
    Private _gender As Integer
    Public Property Sex() As Integer
        Get
            Return _gender
        End Get
        Set(ByVal value As Integer)
            _gender = value
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

    ' PHONE HAS A DIFFERENT TABLE
    ' ID HAS A DIFFERENT TABLE

#End Region


End Class
