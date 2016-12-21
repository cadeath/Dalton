' VERSION 1.1
' NEW DALTON COMPUTATION CLASS

Public Class PawnCompute

    '===================== INPUT ====================='
    Private _principal As Double = 0
    Private _currentDate As Date
    Private _MatuDate As Date
    Private _isNew As Boolean
    Private _IntRate As New InterestScheme
    '====================== END ======================'

#Region "Properties"
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

    Private _isEarlyRedeem As Boolean = False
    Public ReadOnly Property isEarlyRedeem() As Boolean
        Get
            Return _isEarlyRedeem
        End Get
    End Property
    '====================== END ======================'
#End Region

#Region "Procedures and Functions"

    Public Sub New(ByVal Principal As Double, ByVal IntRate As InterestScheme, ByVal CurrentDate As Date, ByVal MaturityDate As Date, ByVal isNew As Boolean)
        _principal = Principal
        _IntRate = IntRate
        _currentDate = CurrentDate
        _MatuDate = MaturityDate

        _isNew = isNew

        Calculate()
    End Sub

    Private Sub Calculate()
        Dim earlyDays As Integer = 0
        Dim ItemInterest_percent As Double = 0, ItemPenalty_percent As Double = 0
        Dim Item_Interest As Double = 0, Item_Penalty As Double = 0, Delay_Interest As Double = 0

        Dim Item_Principal As Double = _principal

        'Validation
        Dim difDay = _currentDate.Date - _MatuDate.Date
        earlyDays = difDay.Days + 30
        _daysOver = If(earlyDays - 30 > 0, earlyDays - 30, 0)

        'Declaration
        ItemInterest_percent = Get_ItemInterest(earlyDays)
        ItemPenalty_percent = Get_ItemInterest(earlyDays, percentType.Penalty)
        _advInterest = Get_ItemInterest(30) * Item_Principal
        _srvChr = GetServiceCharge(Item_Principal)

        'Compute
        Delay_Interest = ItemInterest_percent * Item_Principal
        Item_Interest = ItemInterest_percent * Item_Principal
        Item_Penalty = ItemPenalty_percent * Item_Principal

        _int = IIf(_isNew, Item_Interest - _advInterest, Delay_Interest) 'What the heck is there for?
        _penalty = Item_Penalty

        _netAmount = Item_Principal - _advInterest - _srvChr
        If _isNew Then
            'Renew
            _renewDue = IIf(Item_Interest > _advInterest, Item_Interest, _advInterest) + Item_Penalty + _srvChr

            'Redemption
            _redeemDue = Item_Principal + Item_Interest + Item_Penalty - _advInterest
        Else
            _advInterest = 0
            _renewDue = Delay_Interest + _srvChr + Item_Penalty
            _redeemDue = Item_Principal + Item_Interest + _srvChr + Item_Penalty
        End If
    End Sub

    Enum percentType As Integer
        Interest = 0
        Penalty = 1
    End Enum

    Private Function Get_ItemInterest(ByVal days As Integer, Optional ByVal ret As percentType = 0) As Double
        Dim IntScheme As New InterestScheme
        IntScheme = _IntRate

        For Each Int As Scheme_Interest In IntScheme.SchemeDetails
            Select Case days
                Case Int.DayFrom To Int.DayTo
                    If ret = percentType.Interest Then
                        If Int.Remarks = "Early Redemption" Then _isEarlyRedeem = True
                        Return Int.Interest
                    End If

                    If ret = percentType.Penalty Then
                        If Int.Remarks = "Early Redemption" Then _isEarlyRedeem = True
                        Return Int.Penalty
                    End If

            End Select
        Next

        Return 0
    End Function

    Private Function GetServiceCharge(ByVal principal As Double) As Double
        Dim srvPrin As Double = principal
        Dim ret As Double = 0

        If srvPrin < 500 Then
            ret = srvPrin * 0.01
        Else
            ret = 5
        End If

        Return ret
    End Function

#End Region

End Class
