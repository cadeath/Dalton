Public Class Item
    Private fillData As String = "TBL_ITEM"
    Private fillData1 As String = "TBL_SPECIFICATION"
    Private mySql As String, ds As DataSet

#Region "Properties and Variables"
    Private _itemID As Integer
    Public Property itemID() As Integer
        Get
            Return _itemID
        End Get
        Set(ByVal value As Integer)
            _itemID = value
        End Set
    End Property

    Private _Classification As String
    Public Property Classification() As String
        Get
            Return _Classification
        End Get
        Set(ByVal value As String)
            _Classification = value
        End Set
    End Property

    Private _Category As String
    Public Property Category() As String
        Get
            Return _Category
        End Get
        Set(ByVal value As String)
            _Category = value
        End Set
    End Property

    Private _Description As String
    Public Property Description() As String
        Get
            Return _Description
        End Get
        Set(ByVal value As String)
            _Description = value
        End Set
    End Property

    Private _status As String = "A"
    Public Property Status() As String
        Get
            Return _Status
        End Get
        Set(ByVal value As String)
            _Status = value
        End Set
    End Property


    Private _DateCreated As Date
    Public Property DateCreated() As Date
        Get
            Return _DateCreated
        End Get
        Set(ByVal value As Date)
            _DateCreated = value
        End Set
    End Property

    Private _DateUpdated As Date
    Public Property DateUpdated() As Date
        Get
            Return _DateUpdated
        End Get
        Set(ByVal value As Date)
            _DateUpdated = value
        End Set
    End Property

    Private _Renewable As Integer
    Public Property Renewable() As Integer
        Get
            Return _Renewable
        End Get
        Set(ByVal value As Integer)
            _Renewable = value
        End Set
    End Property

    Private _ConfigID As Integer
    Public Property ConfigID() As Integer
        Get
            Return _ConfigID
        End Get
        Set(ByVal value As Integer)
            _ConfigID = value
        End Set
    End Property

    Private _PrintLayout As String
    Public Property PrintLayout() As String
        Get
            Return _PrintLayout
        End Get
        Set(ByVal value As String)
            _PrintLayout = value
        End Set
    End Property
    '==============================================================
    Private _SpecID As Integer
    Public Property SpecID() As Integer
        Get
            Return _status
        End Get
        Set(ByVal value As Integer)
            _status = value
        End Set
    End Property


    Private _ShortCode As String
    Public Property ShortCode() As String
        Get
            Return _ShortCode
        End Get
        Set(ByVal value As String)
            _ShortCode = value
        End Set
    End Property

    Private _SpecName As String
    Public Property SpecName() As String
        Get
            Return _SpecName
        End Get
        Set(ByVal value As String)
            _SpecName = value
        End Set
    End Property

    Private _SpecType As String
    Public Property SpecType() As String
        Get
            Return _SpecType
        End Get
        Set(ByVal value As String)
            _SpecType = value
        End Set
    End Property

    Private _Layout As String
    Public Property Layout() As String
        Get
            Return _Layout
        End Get
        Set(ByVal value As String)
            _Layout = value
        End Set
    End Property

    Private _UnitofMeasure As String
    Public Property UnitofMeasure() As String
        Get
            Return _UnitofMeasure
        End Get
        Set(ByVal value As String)
            _UnitofMeasure = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"
    Public Sub LoadItem(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE ITEMID = " & id
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            loadByRow(dr)
        Next
    End Sub

    Private Sub loadByRow(ByVal dr As DataRow)
        With dr
            _itemID = .Item("ItemID")
            _Classification = .Item("ItemClass")
            _Category = .Item("ItemCategory")
         
            _Description = .Item("Description")
            _status = .Item("Status")
            _DateCreated = .Item("Date_CreatedAT")
            _DateUpdated = .Item("Date_UpdateAt")
            _Renewable = IIf(IsDBNull(.Item("Renewable")), "", .Item("Renewable"))
            ' .Item("ConfigID") = _ConfigID
            _PrintLayout = .Item("Print_layout")
        End With
    End Sub

    Public Sub LoadDollarByRow(ByVal dr As DataRow)
        loadByRow(dr)
    End Sub

    Public Sub ModifyItem()
        Dim mySql As String = "SELECT * FROM " & fillData & " WHERE ItemID = " & _itemID
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        With ds.Tables(0).Rows(0)
            .Item("ItemClass") = _Classification
            .Item("ItemCategory") = _Category
            .Item("Description") = _Description
            .Item("Status") = _status
            .Item("Date_createdat") = _
            .Item("Date_Updatedat") = _DateUpdated
            .Item("IsRenew") = _Renewable
            ' .Item("ConfigID") = _ConfigID
            .Item("Print_Layout") = _PrintLayout
        End With

        database.SaveEntry(ds, False)
    End Sub

    Public Sub ModifySpec()
        Dim mySql As String = "SELECT * FROM " & fillData1 & " WHERE SpecID = " & _SpecID
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        With ds.Tables(0).Rows(0)
            .Item("ItemID") = _Classification
            .Item("Short_Code") = _ShortCode
            .Item("SpecName") = _Category
            .Item("SpecType") = _Description
            .Item("SpecLayout") = _
            .Item("UOM") = _DateUpdated
        End With

        database.SaveEntry(ds, False)
    End Sub

    Public Sub SaveItem()
        mySql = "SELECT * FROM " & fillData
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow

        With dsNewRow
            .Item("ItemClass") = _Classification
            .Item("ItemCategory") = _Category
            .Item("Description") = _Description
            .Item("Status") = _status
            .Item("Date_CreatedAT") = _DateCreated
            '.Item("Date_Upated") = ""
            .Item("IsRenew") = _Renewable
            ' .Item("ConfigID") = _ConfigID
            .Item("Print_Layout") = _PrintLayout
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Sub SaveSpecification()
        mySql = "SELECT * FROM " & fillData1
        ds = LoadSQL(mySql, fillData1)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData1).NewRow

        With dsNewRow
            .Item("ItemID") = LastITEMID()
            .Item("Short_code") = _ShortCode
            .Item("specName") = _SpecName
            .Item("SpecType") = _SpecType
            .Item("SpecLayout") = _Layout
            .Item("UOM") = _UnitofMeasure
            ' .Item("ConfigID") = _ConfigID
        End With
        ds.Tables(fillData1).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Function LastITEMID() As Single
        Dim mySql As String = "SELECT * FROM " & fillData & " ORDER BY ITEMID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("ITEMID")
    End Function
#End Region

End Class
