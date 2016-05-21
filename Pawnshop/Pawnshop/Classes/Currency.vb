Imports System.Data.Odbc
Public Class Currency
    Private fillData As String = "TBLCURRENCY"
    Private mySql As String, ds As DataSet

#Region "Properties and Variables"
    Private _id As Integer
    Public Property CURRENCYID As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _CURRENCY As String
    Public Property CURRENCY As String
        Set(ByVal value As String)
            _CURRENCY = value
        End Set
        Get
            Return _CURRENCY
        End Get
    End Property
    Private _SYMBOL As String = String.Empty
    Public Property SYMBOL As String
        Set(ByVal value As String)
            _SYMBOL = value
        End Set
        Get
            Return _SYMBOL
        End Get
    End Property
    Private _DENOMINATION As String
    Public Property DENOMINATION As String
        Get
            Return _DENOMINATION
        End Get
        Set(ByVal value As String)
            _DENOMINATION = value
        End Set
    End Property
    Private _RATE As String = String.Empty
    Public Property RATE As String
        Get
            Return _RATE
        End Get
        Set(ByVal value As String)
            _RATE = value
        End Set
    End Property
    Private _FULLNAME As String = String.Empty
    Public Property CustomersName() As String
        Get
            Return _FULLNAME
        End Get
        Set(ByVal value As String)
            _FULLNAME = value
        End Set
    End Property
    Private _CUSTOMTER As Client
    Public Property Customer() As Client
        Get
            Return _CUSTOMTER
        End Get
        Set(ByVal value As Client)
            _CUSTOMTER = value
        End Set
    End Property
    Private _STATUS As String = "A"
    Public Property Status() As String
        Get
            Return _STATUS
        End Get
        Set(ByVal value As String)
            _STATUS = value
        End Set
    End Property
#End Region
#Region "LOADCURRENCY AND ENTRY"
    Public Sub LoadCurrencydata(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE CURRENCYID = " & id
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            ByRow(dr)
        Next
    End Sub

    Private Sub ByRow(ByVal dr As DataRow)
        With dr
            _id = .Item("CURRENCYID")
            _CURRENCY = .Item("CURRENCY")
            _SYMBOL = .Item("SYMBOL")
            _DENOMINATION = .Item("DENOMINATION")
            _RATE = .Item("RATE")
        End With
    End Sub

    Public Sub LoadCurrencyByRow(ByVal dr As DataRow)
        ByRow(dr)
    End Sub

    Public Function LastIDNumber() As Single
        Dim mySql As String = "SELECT * FROM TBLCURRENCY"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("CURRENCYID")
    End Function

    Private Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "''")
        str = str.Replace("""", """""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function
#End Region

End Class
