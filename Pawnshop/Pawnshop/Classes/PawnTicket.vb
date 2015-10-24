Public Class PawnTicket

#Region "Variables"
    Private _pawnid As Integer
    Private _pawnTicket As Integer
    Private _client As Client
    Private _loanDate As Date
    Private _matuDate As Date
    Private _expiryDate As Date
    Private _auctionDate As Date
    Private _itemType As ItemClass
    Public Enum ItemClass As Integer
        Jewel = 0 : Appliances = 1
        BigAppliances = 2 : Cellphone = 3
    End Enum
    Private _catID As Integer
    Private _description As String
    Private _karat As String
    Private _grams As Double
    Private _appraisal As Double
    Private _principal As Double
    Private _interest As Double
    Private _netAmount As Double
    Private _evat As Double
    Private _appraiserID As Integer

    Private _transType As String
    Private _newTicket As Integer
    Private _orNum As Integer
    Private _orDate As Date
    Private _lessPrincipal As Double
    Private _daysOverDue As Double
    Private _delayInt As Double
    Private _penalty As Double
    Private _serviceCharge As Double
    Private _renewDue As Double
    Private _redeemDue As Double

#End Region

#Region "Properties"
    Public ReadOnly Property PawnID As Integer
        Get
            Return _pawnid
        End Get
    End Property

    Public Property PawnTicket As Integer
        Set(ByVal value As Integer)
            _pawnTicket = value
        End Set
        Get
            Return _pawnTicket
        End Get
    End Property

    Public Property Pawner As Client
        Set(ByVal value As Client)
            _client = value
        End Set
        Get
            Return _client
        End Get
    End Property

    Public Property LoanDate As Date
        Set(ByVal value As Date)
            _loanDate = value
        End Set
        Get
            Return _loanDate
        End Get
    End Property

    Public Property MaturityDate As Date
        Set(ByVal value As Date)
            _matuDate = value
        End Set
        Get
            Return _matuDate
        End Get
    End Property

    Public Property ExpiryDate As Date
        Set(ByVal value As Date)
            _expiryDate = value
        End Set
        Get
            Return _expiryDate
        End Get
    End Property

    Public Property AuctionDate As Date
        Set(ByVal value As Date)
            _auctionDate = value
        End Set
        Get
            Return _auctionDate
        End Get
    End Property

    Public Property ItemType As ItemClass
        Set(ByVal value As ItemClass)
            _itemType = value
        End Set
        Get
            Return _itemType
        End Get
    End Property

    Public Property CategoryID As Integer
        Set(ByVal value As Integer)
            _catID = value
        End Set
        Get
            Return _catID
        End Get
    End Property

    Public Property Description As String
        Set(ByVal value As String)
            _description = value
        End Set
        Get
            Return _description
        End Get
    End Property

    Public Property Karat As String
        Set(ByVal value As String)
            _karat = value
        End Set
        Get
            Return _karat
        End Get
    End Property

    Public Property Grams As Double
        Set(ByVal value As Double)
            _grams = value
        End Set
        Get
            Return _grams
        End Get
    End Property

    Public Property Appraisal As Double
        Set(ByVal value As Double)
            _appraisal = value
        End Set
        Get
            Return _appraisal
        End Get
    End Property

    Public Property Principal As Double
        Set(ByVal value As Double)
            _principal = value
        End Set
        Get
            Return _principal
        End Get
    End Property

    Public Property Interest As Double
        Set(ByVal value As Double)
            _interest = value
        End Set
        Get
            Return _interest
        End Get
    End Property

    Public Property NetAmount As Double
        Set(ByVal value As Double)
            _netAmount = value
        End Set
        Get
            Return _netAmount
        End Get
    End Property

    Public Property EVAT As Double
        Set(ByVal value As Double)
            _evat = value
        End Set
        Get
            Return _evat
        End Get
    End Property

    Public Property AppraiserID As Integer
        Set(ByVal value As Integer)
            _appraiserID = value
        End Set
        Get
            Return _appraiserID
        End Get
    End Property

    Public Property TransactionType As String
        Get
            Return _transType
        End Get
        Set(ByVal value As String)
            _transType = value
        End Set
    End Property

    Public Property NewTicket As Integer
        Set(ByVal value As Integer)
            _newTicket = value
        End Set
        Get
            Return _newTicket
        End Get
    End Property

    Public Property OfficialReceiptNumber As Integer
        Set(ByVal value As Integer)
            _orNum = value
        End Set
        Get
            Return _orNum
        End Get
    End Property

    Public Property OfficialReceiptDate As Date
        Set(ByVal value As Date)
            _orDate = value
        End Set
        Get
            Return _orDate
        End Get
    End Property

    Public Property LessPrincipal As Double
        Set(ByVal value As Double)
            _lessPrincipal = value
        End Set
        Get
            Return _lessPrincipal
        End Get
    End Property

    Public Property DaysOverDue As Double
        Set(ByVal value As Double)
            _daysOverDue = value
        End Set
        Get
            Return _daysOverDue
        End Get
    End Property

    Public Property DelayInterest As Double
        Set(ByVal value As Double)
            _delayInt = value
        End Set
        Get
            Return _delayInt
        End Get
    End Property

    Public Property Penalty As Double
        Set(ByVal value As Double)
            _penalty = value
        End Set
        Get
            Return _penalty
        End Get
    End Property

    Public Property ServiceCharge As Double
        Set(ByVal value As Double)
            _serviceCharge = value
        End Set
        Get
            Return _serviceCharge
        End Get
    End Property

    Public Property RenewDue As Double
        Set(ByVal value As Double)
            _renewDue = value
        End Set
        Get
            Return _renewDue
        End Get
    End Property

    Public Property RedeemDue As Double
        Set(ByVal value As Double)
            _redeemDue = value
        End Set
        Get
            Return _redeemDue
        End Get
    End Property
#End Region

#Region "Procedures and Functions"
    Public Sub SaveTicket()

    End Sub

    Private Function CreateDataSet() As DataSet
        Dim fillData As String = "tblPawn"
        'Creating Virtual Database
        Dim ds As New DataSet, dt As New DataTable(fillData)

        'Constructing Database
        ds.Tables.Add(dt)
        With ds.Tables(fillData).Columns
            .Add(New DataColumn("PawnID", GetType(Integer))) 'AutoIncrement
            .Add(New DataColumn("PawnTicket", GetType(Integer)))
            .Add(New DataColumn("ClientID", GetType(Integer)))
            .Add(New DataColumn("LoanDate", GetType(Date)))
            .Add(New DataColumn("MatuDate", GetType(Date)))
            .Add(New DataColumn("ExpiryDate", GetType(Date)))
            .Add(New DataColumn("AuctionDate", GetType(Date)))
            .Add(New DataColumn("ItemType", GetType(String)))
            .Add(New DataColumn("CatID", GetType(Integer)))
            .Add(New DataColumn("Description", GetType(String)))
            .Add(New DataColumn("Karat", GetType(String)))
            .Add(New DataColumn("Grams", GetType(Double)))
            .Add(New DataColumn("Appraisal", GetType(Double)))
            .Add(New DataColumn("Principal", GetType(Double)))
            .Add(New DataColumn("Interest", GetType(Double)))
            .Add(New DataColumn("NetAmount", GetType(Double)))
            .Add(New DataColumn("Evat", GetType(Double)))
            .Add(New DataColumn("AppraiserID", GetType(Integer)))
            .Add(New DataColumn("NewTicket", GetType(Integer)))
            .Add(New DataColumn("ORNum", GetType(Integer)))
            .Add(New DataColumn("ORDate", GetType(Date)))
            .Add(New DataColumn("LessPrincipal", GetType(Double)))
            .Add(New DataColumn("DaysOverDue", GetType(Double)))
            .Add(New DataColumn("DelayInt", GetType(Double)))
            .Add(New DataColumn("Penalty", GetType(Double)))
            .Add(New DataColumn("ServiceCharge", GetType(Double)))
            .Add(New DataColumn("RenewDue", GetType(Double)))
            .Add(New DataColumn("RedeemDue", GetType(Double)))
        End With

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            '.Item("FirstName") = _firstName
            '.Item("MiddleName") = _middleName
            '.Item("LastName") = _lastName
            '.Item("Suffix") = _suffixName
            '.Item("Addr_Street") = _addrSt
            '.Item("Addr_Brgy") = _addrBrgy
            '.Item("Addr_City") = _addrCity
            '.Item("Addr_Province") = _addrProvince
            '.Item("Addr_Zip") = _addrZip
            '.Item("Sex") = _gender
            '.Item("Birthday") = _bday
            '.Item("Phone1") = _cp1
            '.Item("Phone2") = _cp2
            '.Item("Phone3") = _phone
            '.Item("Phone_Others") = _otherNum
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        Return ds
    End Function
#End Region
End Class
