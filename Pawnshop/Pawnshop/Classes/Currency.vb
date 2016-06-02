Imports System.Data.Odbc
Public Class Currency
    Private fillData As String = "TBLCURRENCY"
    Private mySql As String, ds As DataSet
    Private _id As Integer = 0

#Region "Properties and Variables"

    Public Property CURRENCYID As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property
    Private _CASHID As Integer
    Public Property CASHID As Integer
        Get
            Return _CASHID
        End Get
        Set(ByVal value As Integer)
            _CASHID = value
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
            _RATE = .Item("RATE")
            _CASHID = .Item("CASHID")
        End With
    End Sub

    Public Sub LoadCurrencyByRow(ByVal dr As DataRow)
        ByRow(dr)
    End Sub
    Public Sub SaveCurrency()
        database.SaveEntry(CreateDataSetCurrency)
    End Sub
    Public Sub ModifyCurrency()
        Dim mySql As String = "SELECT * FROM TBLCURRENCY WHERE CURRENCYID = " & _id
        Dim ds As DataSet = LoadSQL(mySql, "TBLCURRENCY")

        With ds.Tables(0).Rows(0)
            .Item("CURRENCY") = _CURRENCY
            .Item("SYMBOL") = _SYMBOL
            .Item("RATE") = _RATE
            .Item("CASHID") = _CASHID
        End With
        database.SaveEntry(ds, False)
    End Sub
    Private Sub PureModify()
        dbOpen()

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, mySql As String, fillData As String = "Modify"

        mySql = "SELECT * FROM TBLCURRENCY WHERE CURRENCYID = " & _id
        ds.Clear()

        da = New OdbcDataAdapter(mySql, con)
        da.Fill(ds, fillData)

        Console.WriteLine("Result: " & ds.Tables(fillData).Rows.Count)

        With ds.Tables(fillData).Rows(0)
            .Item("CURRENCY") = _CURRENCY
            .Item("SYMBOL") = _SYMBOL
            .Item("RATE") = _RATE
            .Item("CASHID") = _CASHID
        End With
        da.Update(ds, fillData)
        dbClose()
    End Sub
    Private Function CreateDataSetCurrency() As DataSet
        Dim ds As DataSet

        Dim mySql As String = "SELECT * FROM TBLCURRENCY"
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("CURRENCY") = _CURRENCY
            .Item("SYMBOL") = _SYMBOL
            .Item("RATE") = _RATE
            .Item("CASHID") = _CASHID
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        Return ds
    End Function
    Public Function LoadLastEntrycurrency() As Currency
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM " & fillData & " ORDER BY CURRENCYID ASC"
        ds = LoadSQL(mySql)

        Dim LastRow As Integer = ds.Tables(0).Rows.Count
        LoadCurrencydata(ds.Tables(0).Rows(LastRow - 1).Item("CURRENCYID"))

        Return Me
    End Function

    ''' <remarks>to be added by ID List</remarks>
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
