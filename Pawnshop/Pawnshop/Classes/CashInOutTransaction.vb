Public Class CashInOutTransaction

    Private fillData As String = "tblCashTrans"

#Region "Variables and Procedures"
    Private _transID As Integer
    Public Property TransactionID() As Integer
        Get
            Return _transID
        End Get
        Set(ByVal value As Integer)
            _transID = value
        End Set
    End Property

    Private _cashID As Integer
    Public Property CashID() As Integer
        Get
            Return _cashID
        End Get
        Set(ByVal value As Integer)
            _cashID = value
        End Set
    End Property

    Private _type As String
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _transName As String
    Public Property Transaction() As String
        Get
            Return _transName
        End Get
        Set(ByVal value As String)
            _transName = value
        End Set
    End Property

    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property

    Private _particulars As String
    Public Property Particulars() As String
        Get
            Return _particulars
        End Get
        Set(ByVal value As String)
            _particulars = value
        End Set
    End Property

    Private _status As Boolean
    Public Property Status() As Boolean
        Get
            Return _status
        End Get
        Set(ByVal value As Boolean)
            _status = value
        End Set
    End Property

    Private _transDate As Date
    Public Property TransactionDate() As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            _transDate = value
        End Set
    End Property

    Private _encoderID As Integer
    Public Property EncoderID() As Integer
        Get
            Return _encoderID
        End Get
        Set(ByVal value As Integer)
            _encoderID = value
        End Set
    End Property

#End Region

    Public Sub LoadCashIOTrans(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM " & fillData & " WHERE TransID = " & id
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        LoadCashIObyRow(ds.Tables(fillData).Rows(0))
    End Sub

    Public Sub LoadCashIObyRow(ByVal dr As DataRow)
        With dr
            _transID = .Item("TransID")
            _cashID = .Item("CashID")
            _type = .Item("Type")
            _transDate = .Item("TransDate")
            _transName = .Item("TransName")
            _status = .Item("Status")
            _amount = .Item("Amount")
            _particulars = .Item("Remarks")
        End With
    End Sub
End Class
