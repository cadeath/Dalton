Public Class LayAwayLines
    Dim mysql As String = String.Empty
    Dim fillData As String = "tlbLayLines"
    Dim ds As DataSet
#Region "Property"
    Private _layLinesID As Integer
    Public Property LayLinesID() As Integer
        Get
            Return _layLinesID
        End Get
        Set(ByVal value As Integer)
            _layLinesID = value
        End Set
    End Property

    Private _layID As Integer
    Public Property LayID() As Integer
        Get
            Return _layID
        End Get
        Set(ByVal value As Integer)
            _layID = value
        End Set
    End Property

    Private _amount As Integer
    Public Property Amount() As Integer
        Get
            Return _amount
        End Get
        Set(ByVal value As Integer)
            _amount = value
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

    Private _docDate As Date
    Public Property DocDate() As Date
        Get
            Return _docDate
        End Get
        Set(ByVal value As Date)
            _docDate = value
        End Set
    End Property

#End Region

#Region ""
    Private Sub SaveLayAwayLines()
        mysql = "Select * From tblLaylines Rows 1"
        ds = LoadSQL(mysql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("DocDate") = _docDate
            .Item("LayID") = _layID
            .Item("Amount") = _amount
            .Item("Balance") = _balance
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Private Sub LoadByID(ByVal ID As Integer)
        Dim mysql As String = "Select * From tblLayLines Where LayLinesID = '" & ID
        ds = LoadSQL(mysql, fillData)
        LoadRow(ds.Tables(0).Rows(0))
    End Sub

    Private Sub LoadRow(ByVal dr As DataRow)
        With dr
            _layLinesID = .Item("LayLinesID")
            _layID = .Item("LayID")
            _amount = .Item("Amount")
            _balance = .Item("Balance")
            _docDate = .Item("DocDate")
        End With

    End Sub
#End Region
End Class
