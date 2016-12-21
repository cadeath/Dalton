Public Class cItem
    Inherits cItemData

    Enum DocumentType As Integer
        Sales = 0
        GoodsReceipt = 1
        GoodsIssue = 2
    End Enum

    Private PRIID As Integer = 0
    Private TABLE As String = ""
    Private mySql As String = ""

#Region "Properties"
    Private _docLinesID As Integer
    Public Property DocLinesID() As Integer
        Get
            Return _docLinesID
        End Get
        Set(ByVal value As Integer)
            _docLinesID = value
        End Set
    End Property

    Private _docID As Integer
    Public Property DocID() As Integer
        Get
            Return _docID
        End Get
        Set(ByVal value As Integer)
            _docID = value
        End Set
    End Property

    Private _qty As Double
    Public Property Qty() As Double
        Get
            Return _qty
        End Get
        Set(ByVal value As Double)
            _qty = value
        End Set
    End Property

    Private _rowTotal As Double
    Public ReadOnly Property RowTotal() As Double
        Get
            Return _rowTotal
        End Get
    End Property

    Private _docType As DocumentType
    Public Property DocType() As DocumentType
        Get
            Return _docType
        End Get
        Set(ByVal value As DocumentType)
            _docType = value
        End Set
    End Property

    Private _remarks As String
    Public Property Remarks() As String
        Get
            Return _remarks
        End Get
        Set(ByVal value As String)
            _remarks = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Public Sub New(ByVal typ As DocumentType)
        _docType = typ
    End Sub

    Public Overrides Sub Save_ItemData()
        TABLE = If(_docType = DocumentType.Sales, "DOCLINES", "INVLINES")
        PRIID = If(_docType = DocumentType.Sales, "DLID", "INVID")
        mySql = String.Format("SELECT * FROM {0} WHERE {2} = {1}", TABLE, _docLinesID, PRIID)

        Dim isNew As Boolean = True
        Dim ds As DataSet = LoadSQL(mySql, TABLE)

        If _docLinesID = 0 Then
            'NEW ITEM
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(TABLE).NewRow
            With dsNewRow
                .Item("DOCID") = _docID
                .Item("ITEMCODE") = Me.ItemCode
                .Item("DESCRIPTION") = Me.Description
                .Item("QTY") = _qty
                .Item("UNITPRICE") = Me.UnitPrice
                .Item("SALEPRICE") = Me.SalePrice
                .Item("ROWTOTAL") = _rowTotal
                .Item("UOM") = Me.UnitofMeasure
                .Item("REMARKS") = _remarks
            End With
            ds.Tables(TABLE).Rows.Add(dsNewRow)
        Else
            'EDIT ITEMS
            With ds.Tables(TABLE).Rows(0)
                '.Item("DOCID") = _docID 'NO CHANGING OF DOCID
                '.Item("ITEMCODE") = Me.ItemCode 'NO CHANGING OF ITEMCODE
                .Item("DESCRIPTION") = Me.Description
                .Item("QTY") = _qty
                .Item("UNITPRICE") = Me.UnitPrice
                .Item("SALEPRICE") = Me.SalePrice
                .Item("ROWTOTAL") = _rowTotal
                .Item("UOM") = Me.UnitofMeasure
                .Item("REMARKS") = _remarks
            End With
            isNew = False
        End If

        database.SaveEntry(ds, isNew)
    End Sub

    Public Overloads Sub Load_Item()
        TABLE = If(_docType = DocumentType.Sales, "DOCLINES", "INVLINES")
        PRIID = If(_docType = DocumentType.Sales, "DLID", "INVID")
        mySql = String.Format("SELECT * FROM {0} WHERE {2} = {1}", TABLE, _docLinesID, PRIID)
        Dim ds As DataSet = LoadSQL(mySql, TABLE)

        With ds.Tables(TABLE).Rows(0)
            _docLinesID = .Item("DLID")
            _docID = .Item("DOCID")
            Me.ItemCode = .Item("ITEMCODE")
            Me.Description = .Item("DESCRIPTION")
            _qty = .Item("QTY")
            Me.UnitPrice = .Item("UNITPRICE")
            Me.SalePrice = .Item("SALEPRICE")
            _rowTotal = .Item("ROWTOTAL")
            Me.UnitofMeasure = .Item("UOM")
            _remarks = .Item("REMARKS")
        End With
    End Sub

#End Region

End Class
