Public Class InterestScheme

    Private MainTable As String = "TBLINTSCHEMES"
    Private SubTable As String = "TBLINTSCHEME_DETAILS"

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

    Private _SchemeDetails As IntScheme_Lines
    Public Property SchemeDetails() As IntScheme_Lines
        Get
            Return _SchemeDetails
        End Get
        Set(ByVal value As IntScheme_Lines)
            _SchemeDetails = value
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

        LoadScheme_row(ds.Tables(MainTable).Rows(0))

        mySql = String.Format("SELECT * FROM {0} WHERE SchemeID = {1} ORDER BY IS_ID", SubTable, _schemeID)
        ds.Clear()
        ds = LoadSQL(mySql, SubTable)

        Console.WriteLine("Loading Scheme Details")
        _SchemeDetails = New IntScheme_Lines
        For Each dr As DataRow In ds.Tables(SubTable).Rows
            Dim tmpDetails As New Scheme_Interest
            tmpDetails.Load_SchemeDetails_row(dr)

            _SchemeDetails.Add(tmpDetails)
        Next

        isLoaded = True
    End Sub

    Public Sub LoadScheme_row(dr As DataRow)
        With dr
            _schemeID = .Item("SchemeID")
            _schemeName = .Item("SchemeName")
            _desc = .Item("Description")
        End With
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

        mySql = String.Format("SELECT * FROM {0} ORDER BY SCHEMEID DESC ROWS 1", MainTable)
        ds = LoadSQL(mySql, MainTable)
        _schemeID = ds.Tables(0).Rows(0).Item("SchemeID")

        For Each IntDetails As Scheme_Interest In _SchemeDetails
            IntDetails.SchemeID = _schemeID
            IntDetails.Save_Details()
        Next
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

        For Each detail As Scheme_Interest In _SchemeDetails
            detail.Update()
        Next
        database.SaveEntry(ds, False)

        Refresh()
    End Sub
#End Region

End Class
