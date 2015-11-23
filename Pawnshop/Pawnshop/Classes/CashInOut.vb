Public Class CashInOut

    Private fillData As String = "tblCash"
    Private mySql As String, ds As DataSet

#Region "Variables and Procedures"

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
    Public Property TransactionName() As String
        Get
            Return _transName
        End Get
        Set(ByVal value As String)
            _transName = value
        End Set
    End Property


    Private _SAPaccnt As String
    Public Property SAPCode() As String
        Get
            Return _SAPaccnt
        End Get
        Set(ByVal value As String)
            _SAPaccnt = value
        End Set
    End Property

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

#End Region

    Public Sub LoadCashInOutInfo(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE CashID = " & id
        ds = LoadSQL(mySql, fillData)

    End Sub
End Class
