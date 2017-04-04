Public Class IdentificationCard

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

    Private _custID As Integer
    Public ReadOnly Property CustomerID() As Integer
        Get
            Return _custID
        End Get
    End Property

    Private _idType As String
    Public Property IDType() As String
        Get
            Return _idType
        End Get
        Set(ByVal value As String)
            _idType = value
        End Set
    End Property

    Private _idNumber As String
    Public Property IDNumber() As String
        Get
            Return _idNumber
        End Get
        Set(ByVal value As String)
            _idNumber = value
        End Set
    End Property

#End Region

End Class
