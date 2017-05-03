Public Class ChargeName

#Region "Properties"
    Private _chrid As Integer
    Public Property ChrID() As Integer
        Get
            Return _chrid
        End Get
        Set(ByVal value As Integer)
            _chrid = value
        End Set
    End Property

    Private _name As String
    Public Property Name() As String
        Get
            Return _name
        End Get
        Set(ByVal value As String)
            _name = value
        End Set
    End Property

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Private Sub LoadCharge(ByVal id As Integer)
        Dim mysql As String = "Select * From tblChargeName Where CHR_ID = " & id
        Dim ds As DataSet = LoadSQL(mysql, "tblChargeName")

        For Each dr In ds.Tables(0).Rows
            LoadbyDatarow(dr)
        Next
    End Sub

    Private Sub LoadbyDatarow(ByVal dr As DataRow)
        With dr
            _id = .Item("CHR_ID")
            _name = .Item("Name")
            _description = .Item("Description")
        End With
    End Sub

#End Region

End Class
