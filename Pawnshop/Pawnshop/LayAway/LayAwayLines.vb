Public Class LayAwayLines
    Dim mysql As String = String.Empty
    Dim fillData As String = "tblLayLines"
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

    Private _docDate As Date
    Public Property DocDate() As Date
        Get
            Return _docDate
        End Get
        Set(ByVal value As Date)
            _docDate = value
        End Set
    End Property

    Private _lineStatus As String
    Public Property LineStatus() As String
        Get
            Return _lineStatus
        End Get
        Set(ByVal value As String)
            _lineStatus = value
        End Set
    End Property

    Private _penalty As Integer
    Public Property Penalty() As Integer
        Get
            Return _penalty
        End Get
        Set(ByVal value As Integer)
            _penalty = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Friend Sub SaveLayAwayLines()
        mysql = "Select * From tblLaylines Rows 1"
        ds = LoadSQL(mysql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("DocDate") = _docDate
            .Item("LayID") = _layID
            .Item("Amount") = _amount
            .Item("Penalty") = _penalty
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
            _penalty = .Item("Penalty")
            _docDate = .Item("DocDate")
            _lineStatus = .Item("Status")
        End With

    End Sub
#End Region
End Class
