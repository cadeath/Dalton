Public Class InterestScheme

    Private MainTable As String = ""
    Private SubTable As String = ""

    Private SchemeDetails As IntScheme_Lines
    Private isLoaded As Boolean = False

#Region "Properties"
    Private _schemeID As Integer
    Public Property SchemeID() As Integer
        Get
            Return _schemeID
        End Get
        Set(ByVal value As Integer)
            _schemeID = value
        End Set
    End Property

    Private _schemeName As String
    Public Property SchemeName() As String
        Get
            Return _schemeName
        End Get
        Set(ByVal value As String)
            _schemeName = value
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
#End Region

#Region "Functions and Procedures"
    Public Sub LoadScheme(id As Integer)
        If isLoaded Then Exit Sub

        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE SchemeID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <> 1 Then
            MsgBox("Unable to load Scheme", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            _schemeID = .Item("SchemeID")
            _schemeName = .Item("SchemeName")
            _desc = .Item("Description")
        End With

        isLoaded = True
    End Sub

    Private Sub Refresh()
        isLoaded = False
        LoadScheme(_schemeID)
    End Sub

    Public Sub SaveScheme()
        Dim mySql As String = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("SchemeName") = _schemeName
            .Item("Description") = _desc
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

        mySql = String.Format("SELECT * FROM {0} ORDER BY SCHEMEID DESC ROWS 1")
        ds = LoadSQL(mySql, MainTable)
        _schemeID = ds.Tables(0).Rows(0).Item("SchemeID")

        'For Each detail As Scheme_Interest In IntScheme_Lines

        'Next

    End Sub

    Public Sub Update()
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE IS_ID = {1}", MainTable, _schemeID)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)

        If ds.Tables(MainTable).Rows.Count <> 1 Then
            MsgBox("Unable to update record", MsgBoxStyle.Critical)
            Exit Sub
        End If

        With ds.Tables(MainTable).Rows(0)
            .Item("SchemeName") = _schemeName
            .Item("Description") = _desc
        End With
    End Sub
#End Region

End Class
