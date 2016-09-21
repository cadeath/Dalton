Public Class Scheme_Interest

    Private MainTable As String = "TBLINTSCHEME_DETAILS"

#Region "Properties"
    Private _schemeINTid As Integer
    Public Property schemeInterestID() As Integer
        Get
            Return _schemeINTid
        End Get
        Set(ByVal value As Integer)
            _schemeINTid = value
        End Set
    End Property

    Private _schemeID As Integer
    Public Property SchemeID() As Integer
        Get
            Return _schemeID
        End Get
        Set(ByVal value As Integer)
            _schemeID = value
        End Set
    End Property

    Private _dayTo As Integer
    Public Property DayTo() As Integer
        Get
            Return _dayTo
        End Get
        Set(ByVal value As Integer)
            _dayTo = value
        End Set
    End Property

    Private _dayFrom As Integer
    Public Property DayFrom() As Integer
        Get
            Return _dayFrom
        End Get
        Set(ByVal value As Integer)
            _dayFrom = value
        End Set
    End Property

    Private _interest As Double
    Public Property Interest() As Double
        Get
            Return _interest
        End Get
        Set(ByVal value As Double)
            _interest = value
        End Set
    End Property

    Private _penalty As Double
    Public Property Penalty() As Double
        Get
            Return _penalty
        End Get
        Set(ByVal value As Double)
            _penalty = value
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

#Region "Procedures and Functions"
    Public Sub Load_SchemeDetails_row(dr As DataRow)
        With dr
            _schemeINTid = .Item("IS_ID")
            _schemeID = .Item("SchemeID")
            _dayFrom = .Item("DayFrom")
            _dayTo = .Item("DayTo")
            _interest = .Item("Interest")
            _penalty = .Item("Penalty")
            _remarks = .Item("Remarks")
        End With
    End Sub

    Public Sub Load_SchemeDetails(id As Integer)
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE IS_ID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <> 1 Then
            MsgBox("Unable to load Scheme Details", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Load_SchemeDetails_row(ds.Tables(MainTable).Rows(0))
    End Sub

    Public Sub Save_Details()
        Dim mySql As String = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("SchemeID") = _schemeID
            .Item("DayFrom") = _dayFrom
            .Item("DayTo") = _dayTo
            .Item("Interest") = _interest
            .Item("Penalty") = _penalty
            .Item("Remarks") = _remarks
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE SCHEMEID= {1} ", MainTable, _schemeINTid)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("DAYFROM") = _dayFrom
            .Item("DAYTO") = _dayTo
            .Item("INTEREST") = _interest
            .Item("PENALTY") = _penalty
            .Item("REMARKS") = _remarks
        End With
        database.SaveEntry(ds, False)
    End Sub

#End Region

End Class