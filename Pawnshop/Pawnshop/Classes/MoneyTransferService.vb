Public Class MoneyTransferService

#Region "Variables"
    Private _serviceCode As Integer
    Public Property Code() As Integer
        Get
            Return _serviceCode
        End Get
        Set(ByVal value As Integer)
            _serviceCode = value
        End Set
    End Property

    Private _serviceName As String
    Public Property ServiceName() As String
        Get
            Return _serviceName
        End Get
        Set(ByVal value As String)
            _serviceName = value
        End Set
    End Property

    Private _isSystemGen As Boolean
    ''' <summary>
    ''' isSystem Generated
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property isGenerated() As Boolean
        Get
            Return _isSystemGen
        End Get
        Set(ByVal value As Boolean)
            _isSystemGen = value
        End Set
    End Property

    Private _sendID As String
    Public Property KeySend() As String
        Get
            Return _sendID
        End Get
        Set(ByVal value As String)
            _sendID = value
        End Set
    End Property

    Private _receivedID As String
    Public Property KeyReceived() As String
        Get
            Return _receivedID
        End Get
        Set(ByVal value As String)
            _receivedID = value
        End Set
    End Property

    Private _accntCode As String
    Public Property AccountName() As String
        Get
            Return _accntCode
        End Get
        Set(ByVal value As String)
            _accntCode = value
        End Set
    End Property

    Private _chargeCode As String
    Public Property ChargeCode() As String
        Get
            Return _chargeCode
        End Get
        Set(ByVal value As String)
            _chargeCode = value
        End Set
    End Property

    Private _hasPayoutCommission As Boolean = False
    Public Property hasPayoutCommission() As Boolean
        Get
            Return _hasPayoutCommission
        End Get
        Set(ByVal value As Boolean)
            _hasPayoutCommission = value
        End Set
    End Property

    Private _sendOnly As Boolean = False
    Public Property SendOnly() As Boolean
        Get
            Return _sendOnly
        End Get
        Set(ByVal value As Boolean)
            _sendOnly = value
        End Set
    End Property

    Private _receiveOnly As Boolean = False
    Public Property ReceiveOnly() As Boolean
        Get
            Return _receiveOnly
        End Get
        Set(ByVal value As Boolean)
            _receiveOnly = value
        End Set
    End Property


#End Region

    Public Function GetSendLast() As String
        Return GetOption(_sendID)
    End Function

    Public Sub SetSendLast(ByVal num As Integer)
        UpdateOptions(_sendID, num)
    End Sub

    Public Function GetReceivedLast() As String
        Return GetOption(_receivedID)
    End Function

    Public Sub SetReceivedLast(ByVal num As Integer)
        UpdateOptions(_receivedID, num)
    End Sub

End Class
