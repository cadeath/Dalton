Public Class InterestScheme

    Private MainTable As String = ""
    Private SubTable As String = ""

    Private SchemeDetails As IntScheme_Lines

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
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE SchemeID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql, MainTable)



    End Sub
#End Region

End Class
