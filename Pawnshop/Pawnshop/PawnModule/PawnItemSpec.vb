Public Class PawnItemSpec
    Inherits ItemSpecs
    Private MainTable As String = "PI1"

#Region "Properties"
    Private _pawnSpecsID As Integer = 0
    Public Property PawnSpecsID() As Integer
        Get
            Return _pawnSpecsID
        End Get
        Set(ByVal value As Integer)
            _pawnSpecsID = value
        End Set
    End Property

    Private _PawnItemID As Integer
    Public Property PawnItemID() As Integer
        Get
            Return _PawnItemID
        End Get
        Set(ByVal value As Integer)
            _PawnItemID = value
        End Set
    End Property

    Private _specsValue As String
    Public Property SpecsValue() As String
        Get
            Return _specsValue
        End Get
        Set(ByVal value As String)
            _specsValue = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"
    Public Sub Save_PawnItemSpecs()
        Dim mySql As String = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)
        Dim isNew As Boolean = False

        If _pawnSpecsID = 0 Then
            isNew = True
        End If

        If isNew Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(MainTable).NewRow
            With dsNewRow
                .Item("UOM") = Me.UnitOfMeasure
                .Item("SPECSNAME") = Me.SpecName
                .Item("SPECSTYPE") = Me.SpecType
                .Item("SPECSVALUE") = _specsValue
                .Item("PAWNITEMID") = _PawnItemID
                .Item("ISREQUIRED") = Me.isRequired
            End With
            ds.Tables(MainTable).Rows.Add(dsNewRow)
        End If

        database.SaveEntry(ds, isNew)
    End Sub

    Public Sub Load_PawnItemSpec(id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE PawnSpecsID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql)

        Load_PawnItemSpec_row(ds.Tables(0).Rows(0))
    End Sub

    Public Sub Load_PawnItemSpec_row(dr As DataRow)
        With dr
            _pawnSpecsID = .Item("PAWNSPECSID")
            Me.UnitOfMeasure = .Item("UOM")
            Me.SpecName = .Item("SPECSNAME")
            Me.SpecType = .Item("SPECSTYPE")
            'Me.SpecLayout = .Item("SPECSLAYOUT")
            Me.SpecsValue = .Item("SPECSVALUE")
            Me.isRequired = .Item("ISREQUIRED")
            _PawnItemID = .Item("PAWNITEMID")
        End With
    End Sub
#End Region
End Class
