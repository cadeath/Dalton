Public Class MoneyTransfer

#Region "Variables"
    Private _id As Integer
    Private _ref As String
    Private _date As Date
    Private _type As String
    Private _client1 As Client
    Private _client2 As Client
    Private _amount As Double = 0
    Private _service As Double = 0
    Private _netAmount As Double = 0
#End Region

#Region "Properties"
    Public Property ID As Integer
        Set(ByVal value As Integer)
            _id = value
        End Set
        Get
            Return _id
        End Get
    End Property

    Public Property ReferenceNumber As String
        Set(ByVal value As String)
            _ref = value
        End Set
        Get
            Return _ref
        End Get
    End Property

    Public Property TransactionDate As Date
        Set(ByVal value As Date)
            _date = value
        End Set
        Get
            Return _date
        End Get
    End Property

    Public Property Sender As Client
        Set(ByVal value As Client)
            _client1 = value
        End Set
        Get
            Return _client1
        End Get
    End Property

    Public Property Receiver As Client
        Set(ByVal value As Client)
            _client2 = value
        End Set
        Get
            Return _client2
        End Get
    End Property

    Public Property TransferAmount As Double
        Set(ByVal value As Double)
            _amount = value
        End Set
        Get
            Return _amount
        End Get
    End Property

    Public Property ServiceCharge As Double
        Set(ByVal value As Double)
            _service = value
        End Set
        Get
            Return _service
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
#End Region



End Class
