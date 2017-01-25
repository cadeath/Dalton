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

    Private _forfeitDate As Date
    Public Property ForfeitDate() As Date
        Get
            Return _forfeitDate
        End Get
        Set(ByVal value As Date)
            _forfeitDate = value
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

    Private _encoder As Integer
    Public Property Encoder() As Integer
        Get
            Return _encoder
        End Get
        Set(ByVal value As Integer)
            _encoder = value
        End Set
    End Property


#End Region

#Region "Procedures"
    Friend Sub SaveLayAway()
        Dim mysql As String = "Select * from tblLayAway Rows 1"
        Dim fillData As String = "tblLayAway"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("DocDate") = _docDate
            .Item("CustomerID") = _customerid
            .Item("ForfeitDate") = _forfeitDate
            .Item("ItemCode") = _itemCode
            .Item("Price") = _price
            .Item("Balance") = _balance
            .Item("Status") = _status
            .Item("Encoder") = _encoder
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Friend Sub LoadByID(ByVal ID As Integer)
        Dim mysql As String = "Select * From tblLayAway Where LayID = '" & ID & "'"
        Dim fillData As String = "tblLayAway"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        LoadLayAwayRow(ds.Tables(0).Rows(0))
    End Sub

    Private Sub LoadLayAwayRow(ByVal dr As DataRow)
        With dr
            _id = .Item("LayID")
            _docDate = .Item("DocDate")
            _forfeitDate = .Item("ForfeitDate")
            _customerid = .Item("CustomerID")
            _itemCode = .Item("ItemCode")
            _price = .Item("Price")
            _balance = .Item("Balance")
            _status = .Item("Status")
            _encoder = .Item("Encoder")
        End With
    End Sub

    Friend Function LayLastID()
        Dim mysql As String = "Select * From tblLayAway ORDER BY LayID DESC"
        Dim filldata As String = "tblLayAway"
        Dim ds As DataSet = LoadSQL(mysql, filldata)
        If ds.Tables(0).Rows().Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("LayID")
    End Function

    Friend Sub UpdateBalance(ByVal Balance As Integer)
        Dim mysql As String = "Select * From tblLayAway Where LayID = " & _id
        Dim ds As DataSet = LoadSQL(mysql, "tblLayAway")
        ds.Tables(0).Rows(0).Item("Balance") = Balance
        SaveEntry(ds, False)
    End Sub

    Friend Sub ItemOnLayMode(ByVal Code As String, Optional ByVal Status As Boolean = True)
        Dim mysql As String = "Select * From ItemMaster Where ItemCode = '" & Code & "'"
        Dim fillData As String = "ItemMaster"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        With ds.Tables(0).Rows(0)
            If Status = True Then .Item("OnLayAway") = 1
            If Status = False Then .Item("OnLayAway") = 0
        End With

        SaveEntry(ds, False)
    End Sub

    Friend Sub InActiveStatus()
        Try
            Dim mysql As String = "Select * From tblLayAway Where LayID = " & ID
            Dim fillData As String = "tblLayAway"
            Dim ds As DataSet = LoadSQL(mysql, fillData)
            ds.Tables(0).Rows(0).Item("Status") = 0
            SaveEntry(ds, False)

            mysql = "Select * From tblLayLines Where LayID = " & ID
            fillData = "tblLayLines"
            ds = LoadSQL(mysql, fillData)
            ds.Tables(0).Rows(0).Item("Status") = 0
            SaveEntry(ds, False)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

#End Region
End Class
