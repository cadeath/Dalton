''' <summary>
''' This Class is made for the purpose of KYC Compliance
''' </summary>
''' <remarks></remarks>
Public Class Customer

    Const CUSTOMER_TABLE As String = "KYC_CUSTOMERS"
    Const CUSTOMER_ID As String = "KYC_ID"
    Const CUSTOMER_PHONE As String = "KYC_PHONE"

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

    Private _rank As Integer
    Public Property Rank() As Integer
        Get
            Return _rank
        End Get
        Set(ByVal value As Integer)
            _rank = value
        End Set
    End Property

    ' PHONE HAS A DIFFERENT TABLE
    ' ID HAS A DIFFERENT TABLE
    Private _custIDs As Collections_ID
    Public Property CustomersIDs() As Collections_ID
        Get
            Return _custIDs
        End Get
        Set(ByVal value As Collections_ID)
            _custIDs = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Public Sub Save()
        Dim mySql As String = "SELECT * FROM " & CUSTOMER_TABLE & " WHERE ID = " & _id
        Dim ds As DataSet = LoadSQL(mySql, CUSTOMER_TABLE), isNew As Boolean = False

        ' PHASE 1
        ' SAVING CUSTOMER INFORMATION
        If _id = 0 Then
            'NEW
            isNew = True
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(CUSTOMER_TABLE).NewRow
            With dsNewRow
                .Item("FIRSTNAME") = _firstName
                .Item("MIDNAME") = _middleName
                .Item("LASTNAME") = _lastName
                .Item("STREET1") = _addrStreet1
                .Item("BRGY1") = _addrBrgy1
                .Item("CITY1") = _addrCity1
                .Item("PROVINCE1") = _addrProvince1
                .Item("ZIP1") = _addrZip1
                .Item("STREET2") = _addrStreet2
                .Item("BRGY2") = _addrBrgy2
                .Item("CITY2") = _addrCity2
                .Item("PROVINCE2") = _addrProvince2
                .Item("ZIP2") = _addrZip2

                .Item("BIRTHDAY") = _birthday
                .Item("BIRTHDAYPLACE") = _birthplace
                .Item("NATIONALITY") = _nationality
                .Item("GENDER") = _gender
                .Item("SRCFUND") = _sourceOfFund
                .Item("RANK") = _rank
            End With
            ds.Tables(CUSTOMER_TABLE).Rows.Add(dsNewRow)
        Else
            With ds.Tables(CUSTOMER_TABLE).Rows(0)
                .Item("FIRSTNAME") = _firstName
                .Item("MIDNAME") = _middleName
                .Item("LASTNAME") = _lastName
                .Item("STREET1") = _addrStreet1
                .Item("BRGY1") = _addrBrgy1
                .Item("CITY1") = _addrCity1
                .Item("PROVINCE1") = _addrProvince1
                .Item("ZIP1") = _addrZip1
                .Item("STREET2") = _addrStreet2
                .Item("BRGY2") = _addrBrgy2
                .Item("CITY2") = _addrCity2
                .Item("PROVINCE2") = _addrProvince2
                .Item("ZIP2") = _addrZip2

                .Item("BIRTHDAY") = _birthday
                .Item("BIRTHDAYPLACE") = _birthplace
                .Item("NATIONALITY") = _nationality
                .Item("GENDER") = _gender
                .Item("SRCFUND") = _sourceOfFund
                .Item("RANK") = _rank
            End With
        End If
        database.SaveEntry(ds, isNew)

        ' PHASE 2
        ' Saving the IDs and Phones

        ' TODO
        ' Include the Phones
        If _custIDs.Count <= 0 Then Exit Sub

        Dim lastCustomerID As Integer = 0
        mySql = "SELECT * FROM " & CUSTOMER_TABLE & " ORDER BY ID DESC ROWS 1"
        ds.Clear()
        ds = LoadSQL(mySql)
        lastCustomerID = ds.Tables(CUSTOMER_TABLE).Rows(0).Item("ID")

        If _custIDs.Count > 0 Then
            mySql = "SELECT * FROM " & CUSTOMER_ID & " WHERE CUSTID = " & lastCustomerID

            ' NEW IDs
            ds.Clear()
            ds = LoadSQL(mySql, CUSTOMER_ID)
            Dim dsNewRow As DataRow
            For Each id As IdentificationCard In _custIDs
                dsNewRow = ds.Tables(CUSTOMER_ID).NewRow
                With dsNewRow
                    .Item("CUSTID") = lastCustomerID
                    .Item("ID_TYPE") = id.IDType
                    .Item("ID_NUMBER") = id.IDNumber
                End With
                ds.Tables(CUSTOMER_ID).Rows.Add(dsNewRow)
            Next

            database.SaveEntry(ds)
        End If
    End Sub

#End Region

End Class
