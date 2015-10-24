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
#End Region
End Class
