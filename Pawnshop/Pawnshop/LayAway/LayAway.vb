Public Class LayAway

#Region "Property"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _docDate As Date
    Public Property DocDate() As Date
        Get
            Return _docDate
        End Get
        Set(ByVal value As Date)
            _docDate = value
        End Set
    End Property

    Private _customerid As Integer
    Public Property CustomerID() As Integer
        Get
            Return _customerid
        End Get
        Set(ByVal value As Integer)
            _customerid = value
        End Set
    End Property

    Private _itemCode As String
    Public Property ItemCode() As String
        Get
            Return _itemCode
        End Get
        Set(ByVal value As String)
            _itemCode = value
        End Set
    End Property

    Private _price As Integer
    Public Property Price() As Integer
        Get
            Return _price
        End Get
        Set(ByVal value As Integer)
            _price = value
        End Set
    End Property

    Private _balance As Integer
    Public Property Balance() As Integer
        Get
            Return _balance
        End Get
        Set(ByVal value As Integer)
            _balance = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Private Sub SaveLayAway()
        Dim mysql As String = "Select * from tblLayAway Rows 1"
        Dim fillData As String = "tblLayAway"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("DocDate") = _docDate
            .Item("CustomerID") = _customerid
            .Item("ItemCode") = _itemCode
            .Item("Price") = _price
            .Item("Balance") = _balance
            .Item("Status") = _status
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Private Sub LoadByID(ByVal ID As Integer)
        Dim mysql As String = "Select * From tblLayAway Where LayID = '" & ID & "'"
        Dim fillData As String = "tblLayAway"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        LoadLayAwayRow(ds.Tables(0).Rows(0))
    End Sub

    Private Sub LoadLayAwayRow(ByVal dr As DataRow)
        With dr
            _id = .Item("LayID")
            _docDate = .Item("DocDate")
            _customerid = .Item("CustomerID")
            _itemCode = .Item("ItemCode")
            _price = .Item("Price")
            _balance = .Item("Balance")
            _status = .Item("Status")
        End With
    End Sub
#End Region
End Class
