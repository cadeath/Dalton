Public Class CashInOut

    Private fillData As String = "tblCash"
    Private mySql As String

#Region "Variables and Procedures"

    Private _cashID As Integer
    Public Property CashID() As Integer
        Get
            Return _cashID
        End Get
        Set(ByVal value As Integer)
            _cashID = value
        End Set
    End Property

    Private _type As String
    Public Property Type() As String
        Get
            Return _type
        End Get
        Set(ByVal value As String)
            _type = value
        End Set
    End Property

    Private _category As String
    Public Property Category() As String
        Get
            Return _category
        End Get
        Set(ByVal value As String)
            _category = value
        End Set
    End Property


    Private _transName As String
    Public Property TransactionName() As String
        Get
            Return _transName
        End Get
        Set(ByVal value As String)
            _transName = value
        End Set
    End Property


    Private _SAPaccnt As String
    Public Property SAPCode() As String
        Get
            Return _SAPaccnt
        End Get
        Set(ByVal value As String)
            _SAPaccnt = value
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

    Private _onHold As Boolean
    Public Property onHold() As Boolean
        Get
            Return _onHold
        End Get
        Set(ByVal value As Boolean)
            _onHold = value
        End Set
    End Property


#End Region

    Public Sub LoadCashInOutInfo(ByVal id As Integer)
        Dim ds As New DataSet
        mySql = "SELECT * FROM " & fillData & " WHERE CashID = " & id
        ds.Clear()
        ds = LoadSQL(mySql, fillData)

        LoadCashInOutByRow(ds.Tables(0).Rows(0))
    End Sub

    Public Sub LoadCashInOutByRow(ByVal dr As DataRow)
        With dr
            _cashID = .Item("CashID")
            _type = .Item("Type")
            _category = .Item("Category")
            _transName = .Item("TransName")
            _SAPaccnt = IIf(IsDBNull(.Item("SAPAccount")), "", .Item("SAPAccount"))
            _remarks = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))
            _onHold = .Item("onHold")
        End With
        Console.WriteLine("CashID " & _cashID & " loaded")
    End Sub

    Public Sub Save()
        Dim mySql As String = "SELECT * FROM " & fillData
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("Type") = _type
            .Item("Category") = _category
            .Item("TransName") = _transName
            .Item("SAPaccount") = _SAPaccnt
            .Item("Remarks") = _remarks
            .Item("onHold") = _onHold
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Update()
        Dim mySql As String = "SELECT * FROM " & fillData & _
            " WHERE CashID = " & _cashID
        Dim ds As New DataSet
        ds = LoadSQL(mySql, fillData)
        With ds.Tables(fillData).Rows(0)
            .Item("Type") = _type
            .Item("Category") = _category
            .Item("TransName") = _transName
            .Item("SAPaccount") = _SAPaccnt
            .Item("Remarks") = _remarks
            .Item("onHold") = _onHold
        End With
        database.SaveEntry(ds, False)
    End Sub
End Class
