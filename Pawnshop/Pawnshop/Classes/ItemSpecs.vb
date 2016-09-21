Public Class ItemSpecs
    Private MainTable As String = "tblSpecs"

#Region "Properties"
    Private _specID As Integer
    Public Property SpecID() As Integer
        Get
            Return _specID
        End Get
        Set(ByVal value As Integer)
            _specID = value
        End Set
    End Property

    Private _itemID As Integer
    Public Property ItemID() As Integer
        Get
            Return _itemID
        End Get
        Set(ByVal value As Integer)
            _itemID = value
        End Set
    End Property

    Private _specName As String
    Public Property SpecName() As String
        Get
            Return _specName
        End Get
        Set(ByVal value As String)
            _specName = value
        End Set
    End Property

    Private _specType As String
    Public Property SpecType() As String
        Get
            Return _specType
        End Get
        Set(ByVal value As String)
            _specType = value
        End Set
    End Property

    Private _UoM As String
    Public Property UnitOfMeasure() As String
        Get
            Return _UoM
        End Get
        Set(ByVal value As String)
            _UoM = value
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

    Private _specLayout As String
    Public Property SpecLayout() As String
        Get
            Return _specLayout
        End Get
        Set(ByVal value As String)
            _specLayout = value
        End Set
    End Property

    Private _shortCode As String
    Public Property ShortCode() As String
        Get
            Return _shortCode
        End Get
        Set(ByVal value As String)
            _shortCode = value
        End Set
    End Property

    Private _isRequired As Boolean
    Public Property isRequired() As Boolean
        Get
            Return _isRequired
        End Get
        Set(ByVal value As Boolean)
            _isRequired = value
        End Set
    End Property

    Private _created As Date
    Public Property Created_At() As Date
        Get
            Return _created
        End Get
        Set(ByVal value As Date)
            _created = value
        End Set
    End Property

    Private _updated As Date
    Public Property Updated_At() As Date
        Get
            Return _updated
        End Get
        Set(ByVal value As Date)
            _updated = value
        End Set
    End Property

#End Region

#Region "Functions and Procedures"

    Public Sub LoadItemSpecs_row(dr As DataRow)
        With dr

            _specID = .Item("SpecsID")
            _itemID = .Item("ItemID")
            _specName = .Item("SpecsName")
            _specType = .Item("SpecType")

            If Not IsDBNull(.Item("UoM")) Then _UoM = .Item("UOM")

            _onHold = If(.Item("OnHold") = 1, True, False)
            _specLayout = .Item("SpecLayout")
            _shortCode = .Item("ShortCode")
            _isRequired = If(.Item("isRequired") = 1, True, False)
            '_created = .Item("Created_At")
            '_updated = .Item("Updated_At")
        End With
    End Sub

    Friend Sub LoadItemSpecs(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM TBLSPECS WHERE ItemID = " & id
        Dim ds As DataSet
        ds = LoadSQL(mySql, MainTable)

        'If ds.Tables(0).Rows.Count <> 0 Then
        '    MsgBox("Failed to load Item Specification", MsgBoxStyle.Critical)
        '    Exit Sub
        'End If

        For Each dr As DataRow In ds.Tables(0).Rows
            LoadItemSpecs_row(dr)
        Next

    End Sub

    Public Sub SaveSpecs()
        Dim mySql As String = "SELECT * FROM " & MainTable & " ROWS 1"
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(0).NewRow
        With dsNewRow
            .Item("ItemID") = _itemID
            .Item("SpecsName") = _specName
            .Item("SpecType") = _specType
            .Item("UOM") = _UoM
            .Item("onHold") = If(_onHold, 1, 0)
            .Item("SpecLayout") = _specLayout
            .Item("ShortCode") = _shortCode
            .Item("isRequired") = If(_isRequired, 1, 0)
            .Item("Created_At") = Now
        End With
        ds.Tables(0).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub


    Public Sub LoadByRow(ByVal dr As DataRow)
        With dr
            _specID = .Item("specsid")
            _itemID = .Item("itemid")
            _UoM = .Item("uom")
            _specName = .Item("specsname")
            _specType = .Item("spectype")
            _specLayout = .Item("speclayout")
            _shortCode = .Item("shortcode")
            _isRequired = .Item("isrequired")

        End With
    End Sub
#End Region


    Public Function LASTITEMID() As Single
        Dim mySql As String = "SELECT * FROM TBLSpecs ORDER BY ITEMID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("SpecsID")
    End Function
    '#End Region

    Public Sub UpdateSpecs()
        Dim mySql As String = "SELECT * FROM " & MainTable & " WHERE SpecsID = " & _specID
        Dim ds As DataSet
        ds = LoadSQL(mySql, MainTable)
        If ds.Tables(0).Rows.Count >= 1 Then
            With ds.Tables(0).Rows(0)
                .Item("SpecsName") = _specName
                .Item("SpecType") = _specType
                .Item("UoM") = _UoM
                .Item("onHold") = If(_onHold, 1, 0)
                .Item("SpecLayout") = _specLayout
                .Item("isRequired") = If(_isRequired, 1, 0)
                .Item("Updated_At") = Now
            End With
            database.SaveEntry(ds, False)
        Else
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("ItemID") = _itemID
                .Item("SpecsName") = _specName
                .Item("SpecType") = _specType
                .Item("UOM") = _UoM
                .Item("onHold") = If(_onHold, 1, 0)
                .Item("SpecLayout") = _specLayout
                .Item("ShortCode") = _shortCode
                .Item("isRequired") = If(_isRequired, 1, 0)
                .Item("Created_At") = Now
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        End If

    End Sub

End Class