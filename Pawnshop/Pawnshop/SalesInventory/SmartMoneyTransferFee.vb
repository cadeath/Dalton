Public Class SmartMoneyTransferFee

#Region "Properties"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _smtMin As Double
    Public Property SmtMin() As Double
        Get
            Return _smtMin
        End Get
        Set(ByVal value As Double)
            _smtMin = value
        End Set
    End Property

    Private _smtMax As Double
    Public Property SmtMax() As Double
        Get
            Return _smtMax
        End Get
        Set(ByVal value As Double)
            _smtMax = value
        End Set
    End Property

    Private _smtTransferFee As Double
    Public Property SmtTransferFee() As Double
        Get
            Return _smtTransferFee
        End Get
        Set(ByVal value As Double)
            _smtTransferFee = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Friend Sub SaveSMTFee()
        Dim mysql As String = "SELECT * FROM TBLSMTRANSFERFEE"
        Dim ds As DataSet = LoadSQL(mysql, "TBLSMTRANSFERFEE")

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables("TBLSMTRANSFERFEE").NewRow
        With dsNewRow
            .Item("SMT_MIN") = _smtMin
            .Item("SMT_MAX") = _smtMax
            .Item("SMT_FEE") = _smtTransferFee
        End With
        ds.Tables("TBLSMTRANSFERFEE").Rows.Add(dsNewRow)
        SaveEntry(ds)
    End Sub

    Friend Sub LoadSMT(Optional ByVal idx As Integer = 0)
        Dim mysql As String
        If idx = 0 Then
            mysql = "SELECT * FROM TBLSMTRANSFERFEE"
        Else
            mysql = "SELECT * FROM TBLSMTRANSFERFEE WHERE SMT_ID = " & idx
        End If

        Dim ds As DataSet = LoadSQL(mysql, "TBLSMTRANSFERFEE")

        For Each dr In ds.Tables(0).Rows
            LoadByRows(dr)
        Next
    End Sub

    Private Sub LoadByRows(ByVal dr As DataRow)
        With dr
            _id = .Item("SMT_ID")
            _smtMin = .Item("SMT_MIN")
            _smtMax = .Item("SMT_MAX")
            _smtTransferFee = .Item("SMT_FEE")
        End With
    End Sub
#End Region
End Class
