Imports System.Data.Odbc
Public Class Currency
    Private fillData As String = "TBLCURRENCY"
    Private mySql As String = "SELECT * FROM "
    Private _Curreny2 As String = String.Empty
#Region "Properties and Variables"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _CURRENCY As Integer
    Public Property Currency() As Integer
        Get
            Return _CURRENCY
        End Get
        Set(ByVal value As Integer)
            _CURRENCY = value
        End Set
    End Property

    Public Property Currency1 As String
        Set(ByVal value As String)
            _Curreny2 = value
        End Set
        Get
            Return _Curreny2
        End Get
    End Property
    Private _SYMBOL As String
    Public Property Symbol() As String
        Get
            Return _SYMBOL
        End Get
        Set(ByVal value As String)
            _SYMBOL = value
        End Set
    End Property
    Private _DENOMINATION As String
    Public Property Denomination() As String
        Get
            Return _DENOMINATION
        End Get
        Set(ByVal value As String)
            _DENOMINATION = value
        End Set
    End Property
    Private _RATE As String
    Public Property Rate() As String
        Get
            Return _RATE
        End Get
        Set(ByVal value As String)
            _RATE = value
        End Set
    End Property
#End Region
    Public Sub LoadCurrency(ByVal id As String)
        mySql = "SELECT * FROM " & fillData & " WHERE CURRENCYID = " & id
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        LoadByRow(ds.Tables(fillData).Rows(0))
    End Sub
    Public Sub LoadByRow(ByVal dr As DataRow)
        With dr
            _id = .Item("CURRENCYID")
            _CURRENCY = .Item("CURRENCY")
            _SYMBOL = .Item("SYMBOL")
            _DENOMINATION = .Item("DENOMINATION")
            _RATE = .Item("DENOMINATION")

        End With
    End Sub
End Class
