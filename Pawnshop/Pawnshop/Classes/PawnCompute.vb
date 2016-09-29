Public Class PawnCompute

#Region "Properties"
    '===================== INPUT ====================='

    Private _pawnTicket As PawnTicket2
    Public Property PawnTicket() As PawnTicket2
        Get
            Return _pawnTicket
        End Get
        Set(ByVal value As PawnTicket2)
            _pawnTicket = value
        End Set
    End Property

    Private _currentDate As Date
    Public Property CurrentDate() As Date
        Get
            Return _currentDate
        End Get
        Set(ByVal value As Date)
            _currentDate = value
        End Set
    End Property

    '====================== END ======================'

    '===================== OUTPUT ====================='

    Private _netAmount As Double
    Public Property NetAmount() As Double
        Get
            Return _netAmount
        End Get
        Set(ByVal value As Double)
            _netAmount = value
        End Set
    End Property

    Private _renewDue As Double
    Public Property RenewDue() As Double
        Get
            Return _renewDue
        End Get
        Set(ByVal value As Double)
            _renewDue = value
        End Set
    End Property

    Private _redeemDue As Double
    Public Property RedeemDue() As Double
        Get
            Return _redeemDue
        End Get
        Set(ByVal value As Double)
            _redeemDue = value
        End Set
    End Property

    Private _advInterest As Double
    Public Property AdvanceInterest() As Double
        Get
            Return _advInterest
        End Get
        Set(ByVal value As Double)
            _advInterest = value
        End Set
    End Property

    Private _daysOver As Integer
    Public Property DaysOverDue() As Integer
        Get
            Return _daysOver
        End Get
        Set(ByVal value As Integer)
            _daysOver = value
        End Set
    End Property

    Private _int As Double
    Public Property Interest() As Double
        Get
            Return _int
        End Get
        Set(ByVal value As Double)
            _int = value
        End Set
    End Property

    Private _penalty As Double
    Public Property Penalty() As Double
        Get
            Return _penalty
        End Get
        Set(ByVal value As Double)
            _penalty = value
        End Set
    End Property

    Private _srvChr As Double
    Public Property ServiceCharge() As Double
        Get
            Return _srvChr
        End Get
        Set(ByVal value As Double)
            _srvChr = value
        End Set
    End Property

    '====================== END ======================'
#End Region

#Region "Procedures and Functions"

    Public Sub New(PT As PawnTicket2, currentDate As Date)
        _pawnTicket = PT
        _currentDate = currentDate

        Calculate()
    End Sub

    Private Sub Calculate()
        Dim earlyDays As Integer = 0
        Dim ItemInterest As Double = 0

        'Validation
        Dim difDay = _currentDate.Date - _pawnTicket.MaturityDate.Date
        earlyDays = difDay.Days + 30
        _daysOver = If(earlyDays - 30 > 0, earlyDays - 30, 0)

        'Declaration
        ItemInterest = Get_ItemInterest(earlyDays)
    End Sub

    Private Function Get_ItemInterest(days As Integer) As Double
        Dim IntScheme As InterestScheme
        IntScheme = _pawnTicket.PawnItem.InterestScheme

        For Each Int As IntScheme_Lines In IntScheme.SchemeDetails

        Next

        Return 0
    End Function

#End Region

End Class
