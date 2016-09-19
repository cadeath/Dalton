Public Class ItemClass
    Private MainTable As String = "tblItem"
    Private SubTable As String = "tblSpecs"

#Region "Properties"
    Private _itemID As Double
    Public Property ID() As Double
        Get
            Return _itemID
        End Get
        Set(ByVal value As Double)
            _itemID = value
        End Set
    End Property

    Private _itemClass As String
    Public Property ItemClass() As String
        Get
            Return _itemClass
        End Get
        Set(ByVal value As String)
            _itemClass = value
        End Set
    End Property

    Private _category As String
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property

    Private _desc As String
    Public Property Description() As String
        Get
            Return _desc
        End Get
        Set(ByVal value As String)
            _desc = value
        End Set
    End Property

    Private _intRate As Double
    Public Property InterestRate() As Double
        Get
            Return _intRate
        End Get
        Set(ByVal value As Double)
            _intRate = value
        End Set
    End Property

    Private _isRenew As Boolean
    Public Property isRenewable() As Boolean
        Get
            Return _isRenew
        End Get
        Set(ByVal value As Boolean)
            _isRenew = value
        End Set
    End Property

    Private _onHold As Boolean
    Public Property onHold() As Boolean
        Get
            Return _onHold
        End Get
        Set(ByVal value As Boolean)
            _onHold = value
        End Set
    End Property

    Private _printLayout As String
    Public Property PrintLayout() As String
        Get
            Return _printLayout
        End Get
        Set(ByVal value As String)
            _printLayout = value
        End Set
    End Property

    Private _created As Date
    Public Property created_at() As Date
        Get
            Return _created
        End Get
        Set(ByVal value As Date)
            _created = value
        End Set
    End Property

    Private _updated As Date
    Public Property updated_at() As Date
        Get
            Return _updated
        End Get
        Set(ByVal value As Date)
            _updated = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"
    Public Sub LoadItem(id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM tblItem WHERE ItemID = {0}", _itemID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(0).Rows.Count <> 0 Then
            MsgBox("Failed to load Item", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _itemID = .Item("ItemID")
            _itemClass = .Item("ItemClass")
            _category = .Item("ItemCategory")
            _desc = .Item("Description")
            _isRenew = If(.Item("isRenew") = 1, True, False)
            _onHold = If(.Item("onHold") = 1, True, False)
            _printLayout = .Item("Print_Layout")
            _created = .Item("Created_At")
            _updated = .Item("Updated_At")
        End With
    End Sub

    Public Sub SaveItem()
        Dim mySql As String = String.Format("SELECT * FROM tblItem WHERE ItemClass = '%{0}%'", _itemClass)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("ItemClass") = _itemClass
            .Item("ItemCategory") = _category
            .Item("Description") = _desc
            .Item("isRenew") = IIf(_isRenew, 1, 0)
            .Item("onHold") = IIf(_onHold, 1, 0)
            .Item("Print_Layout") = _printLayout
            .Item("Created_At") = Now
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub
#End Region

End Class
