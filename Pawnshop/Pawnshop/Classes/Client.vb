Public Class Client

#Region "Variables"
    Enum Gender As Integer : Male = 1 : Female = 0 : End Enum

    Private _firstName As String = String.Empty
    Private _middleName As String = String.Empty
    Private _lastName As String = String.Empty
    Private _suffixName As String = String.Empty

    Private _addrSt As String = String.Empty
    Private _addrBrgy As String = String.Empty
    Private _addrCity As String = String.Empty
    Private _addrProvince As String = String.Empty
    Private _addrZip As String = String.Empty

    Private _gender As Gender = Gender.Male
    Private _bday As Date

    Private _cp1 As String = String.Empty
    Private _cp2 As String = String.Empty
    Private _phone As String = String.Empty
    Private _otherNum As String = String.Empty
#End Region

#Region "Properties"
    Public Property FirstName As String
        Set(ByVal value As String)
            _firstName = value
        End Set
        Get
            Return _firstName
        End Get
    End Property

    Public Property MiddleName As String
        Set(ByVal value As String)
            _middleName = value
        End Set
        Get
            Return _middleName
        End Get
    End Property

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Public Property Suffix As String
        Set(ByVal value As String)
            _suffixName = value
        End Set
        Get
            Return _suffixName
        End Get
    End Property

    Public Property AddressSt As String
        Set(ByVal value As String)
            _addrSt = value
        End Set
        Get
            Return _addrSt
        End Get
    End Property

    Public Property AddressBrgy As String
        Get
            Return _addrBrgy
        End Get
        Set(ByVal value As String)
            _addrBrgy = value
        End Set
    End Property

    Public Property AddressCity As String
        Get
            Return _addrCity
        End Get
        Set(ByVal value As String)
            _addrCity = value
        End Set
    End Property

    Public Property Sex As Gender
        Set(ByVal value As Gender)
            _gender = value
        End Set
        Get
            Return _gender
        End Get
    End Property

    Public Property Birthday As Date
        Set(ByVal value As Date)
            _bday = value
        End Set
        Get
            Return _bday
        End Get
    End Property

    Public Property Cellphone1 As String
        Set(ByVal value As String)
            _cp1 = DreadKnight(value, "-")
        End Set
        Get
            Return _cp1
        End Get
    End Property

    Public Property Cellphone2 As String
        Set(ByVal value As String)
            _cp2 = DreadKnight(value, "-")
        End Set
        Get
            Return _cp2
        End Get
    End Property

    Public Property Telephone As String
        Set(ByVal value As String)
            _phone = DreadKnight(value, "-")
        End Set
        Get
            Return _phone
        End Get
    End Property

    Public Property OtherNumber As String
        Set(ByVal value As String)
            _otherNum = DreadKnight(value)
        End Set
        Get
            Return _otherNum
        End Get
    End Property
#End Region

    Private Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "\'")
        str = str.Replace("""", "\""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function
End Class
