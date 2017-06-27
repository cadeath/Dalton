Public Class PhoneNumber

    Private _id As Integer
    Public Property PhoneID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _custID As Integer
    Public Property CustomerID() As Integer
        Get
            Return _custID
        End Get
        Set(ByVal value As Integer)
            _custID = value
        End Set
    End Property

    Private _phone As String
    Public Property PhoneNumber() As String
        Get
            Return _phone
        End Get
        Set(ByVal value As String)
            _phone = value
        End Set
    End Property

    Private _isPrimary As Boolean
    Public Property isPrimary() As Boolean
        Get
            Return _isPrimary
        End Get
        Set(ByVal value As Boolean)
            _isPrimary = value
        End Set
    End Property

    Public Sub SetPrimary()
        _isPrimary = True
    End Sub

End Class
