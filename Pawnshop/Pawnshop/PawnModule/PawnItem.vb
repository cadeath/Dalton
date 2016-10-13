Public Class PawnItem
    Private MainTable As String = "OPI"
    Private SubTable As String = "PI1"

#Region "Properties"
    Private _pawnItemID As Integer = 0
    Public Property ID() As Integer
        Get
            Return _pawnItemID
        End Get
        Set(ByVal value As Integer)
            _pawnItemID = value
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

    Private _withdrawDate As Date
    Public Property WithdrawDate() As Date
        Get
            Return _withdrawDate
        End Get
        Set(ByVal value As Date)
            _withdrawDate = value
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

    Private _renewalCnt As Integer
    Public Property RenewalCnt() As Integer
        Get
            Return _renewalCnt
        End Get
        Set(ByVal value As Integer)
            _renewalCnt = value
        End Set
    End Property

    Private _created_At As Date
    Public Property Created_At() As Date
        Get
            Return _created_At
        End Get
        Set(ByVal value As Date)
            _created_At = value
        End Set
    End Property

    Private _update_At As Date
    Public Property Updated_At() As Date
        Get
            Return _update_At
        End Get
        Set(ByVal value As Date)
            _update_At = value
        End Set
    End Property

    Private _pawnItemSpecs As New CollectionPawnItemSpecs
    Public Property PawnItemSpecs() As CollectionPawnItemSpecs
        Get
            Return _pawnItemSpecs
        End Get
        Set(ByVal value As CollectionPawnItemSpecs)
            _pawnItemSpecs = value
        End Set
    End Property

    Private _itemClass As New ItemClass
    Public Property ItemClass() As ItemClass
        Get
            Return _itemClass
        End Get
        Set(ByVal value As ItemClass)
            _itemClass = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"

    Public Sub Save_PawnItem()
        Dim mySql As String
        Dim ds As DataSet
        Dim isNew As Boolean = False

        Dim tmpScheme As InterestScheme

        '_itemClass.LoadItem(_itemID) ' Load ItemClass
        tmpScheme = _itemClass.InterestScheme

        ' Saving New PawnItem
        If _pawnItemID = 0 Then
            mySql = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
            isNew = True
        Else
            mySql = String.Format("SELECT * FROM {0} WHERE PAWNITEMID = {1}", MainTable, _pawnItemID)
        End If

        Dim dr As DataRow
        ds = LoadSQL(mySql, MainTable)
        If isNew Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(MainTable).NewRow
            dr = dsNewRow
        Else
            dr = ds.Tables(MainTable).Rows(0)
        End If

        With dr
            If isNew Then
                .Item("ITEMID") = _itemClass.ID
                .Item("ITEMCLASS") = _itemClass.ClassName
                .Item("SCHEME_ID") = tmpScheme.SchemeID
                .Item("RENEWALCNT") = _renewalCnt
                .Item("CREATED_AT") = Now.ToShortDateString
            Else
                .Item("RENEWALCNT") = _renewalCnt
                If Not _withdrawDate = Nothing Then .Item("WITHDRAWDATE") = _withdrawDate
                .Item("STATUS") = _status
                .Item("UPDATED_AT") = Now.ToShortDateString
            End If
        End With

        If isNew Then
            ds.Tables(MainTable).Rows.Add(dr)
        Else
            For cnt As Integer = 0 To ds.Tables(MainTable).Columns.Count - 1
                ds.Tables(MainTable).Rows(0).Item(cnt) = dr(cnt)
            Next
        End If
        database.SaveEntry(ds, isNew)

        If isNew Then
            mySql = String.Format("SELECT * FROM {0} ORDER BY PAWNITEMID DESC ROWS 1", MainTable)
            ds = LoadSQL(mySql)
            _pawnItemID = ds.Tables(0).Rows(0).Item("PAWNITEMID")

            For Each itmSpecs As PawnItemSpec In _pawnItemSpecs
                itmSpecs.PawnItemID = _pawnItemID
                itmSpecs.Save_PawnItemSpecs()
            Next
        End If
    End Sub

    Public Sub Load_PawnItem(id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE PAWNITEMID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to load Pawn Item", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(0).Rows(0)
            _pawnItemID = id
            _itemClass.LoadItem(.Item("ITEMID"))

            If Not IsDBNull(.Item("WITHDRAWDATE")) Then _withdrawDate = .Item("WITHDRAWDATE")
            _status = .Item("STATUS")
            _renewalCnt = .Item("RENEWALCNT")
            _created_At = .Item("CREATED_AT")
            _update_At = .Item("UPDATED_AT")
        End With

        'Loading PawnItemSpecs
        mySql = String.Format("SELECT * FROM {0} WHERE PAWNITEMID = {1}", SubTable, id)
        ds = LoadSQL(mySql)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpItemSpec As New PawnItemSpec
            tmpItemSpec.Load_PawnItemSpec_row(dr)

            _pawnItemSpecs.Add(tmpItemSpec)
        Next
    End Sub

    Public Function Get_PawnItemLastID() As Integer
        Dim mySql As String = String.Format("SELECT * FROM {0} ORDER BY PAWNITEMID DESC ROWS 1", MainTable)
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("PAWNITEMID")
    End Function

#End Region

End Class