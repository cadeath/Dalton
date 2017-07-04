Public Class SmartMoneyTransferFee

#Region "Properties"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _smtMin As Double
    Public Property SmtMix() As Double
        Get
            Return _smtMin
        End Get
        Set(ByVal value As Double)
            _smtMin = value
        End Set
    End Property

    Private _smtMax As Double
    Public Property SmtMax() As Double
        Get
            Return _smtMax
        End Get
        Set(ByVal value As Double)
            _smtMax = value
        End Set
    End Property

    Private _smtTransferFee As Double
    Public Property SmtTransferFee() As Double
        Get
            Return _smtTransferFee
        End Get
        Set(ByVal value As Double)
            _smtTransferFee = value
        End Set
    End Property

#End Region

#Region "Procedures"

#End Region
End Class
