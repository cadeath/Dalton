Public Class DollarTransaction

    Private fillData As String = "tblDollar"
    Private mySql As String, ds As DataSet

#Region "Properties and Variables"
    Private _dollarID As Integer
    Public Property DollarID() As Integer
        Get
            Return _dollarID
        End Get
        Set(ByVal value As Integer)
            _dollarID = value
        End Set
    End Property

    Private _pesoRate As Double
    Public Property CurrentRate() As Double
        Get
            Return _pesoRate
        End Get
        Set(ByVal value As Double)
            _pesoRate = value
        End Set
    End Property

    Private _transDate As Date
    Public Property TransactionDate() As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            _transDate = value
        End Set
    End Property

    Private _customer As Client
    Public Property Customer() As Client
        Get
            Return _customer
        End Get
        Set(ByVal value As Client)
            _customer = value
        End Set
    End Property

    Private _fullName As String
    Public Property CustomersName() As String
        Get
            Return _fullName
        End Get
        Set(ByVal value As String)
            _fullName = value
        End Set
    End Property

    Private _denomination As String
    Public Property Denomination() As String
        Get
            Return _denomination
        End Get
        Set(ByVal value As String)
            _denomination = value
        End Set
    End Property

    Private _serial As String
    Public Property Serial() As String
        Get
            Return _serial
        End Get
        Set(ByVal value As String)
            _serial = value
        End Set
    End Property

    Private _encoderID As Integer
    Public Property EncoderID() As Integer
        Get
            Return _encoderID
        End Get
        Set(ByVal value As Integer)
            _encoderID = value
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

    Private _status As String = "A"
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _netAmount As Double
    Public Property NetAmount() As Double
        Get
            Return _netAmount
        End Get
        Set(ByVal value As Double)
            _netAmount = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"
    Public Sub LoadDollar(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE DollarID = " & id
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            loadByRow(dr)
        Next
    End Sub

    Private Sub loadByRow(ByVal dr As DataRow)
        With dr
            _dollarID = .Item("DollarID")
            _transDate = .Item("TransDate")
            _pesoRate = .Item("PesoRate")
            If Not IsDBNull(.Item("ClientID")) Then
                Dim tmpClient As New Client
                tmpClient.LoadClient(.Item("ClientID"))
                _customer = tmpClient
                _fullName = String.Format("{0} {1}", tmpClient.FirstName, tmpClient.LastName)
            End If
            _denomination = .Item("Denomination")
            _netAmount = .Item("NetAmount")
            _status = .Item("Status")
            _serial = .Item("Serial")
            _remarks = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))
        End With
    End Sub

    Public Sub LoadDollarByRow(ByVal dr As DataRow)
        loadByRow(dr)
    End Sub

    Public Sub SaveDollar()
        mySql = "SELECT * FROM " & fillData
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("TransDate") = _transDate
            .Item("PesoRate") = _pesoRate
            If Not _customer Is Nothing Then
                .Item("ClientID") = _customer.ID
                .Item("FullName") = String.Format("{0} {1}", _customer.FirstName, _customer.LastName)
            End If
            .Item("Denomination") = _denomination
            .Item("Serial") = _serial
            .Item("Status") = _status
            .Item("NetAmount") = _netAmount
            .Item("UserID") = _encoderID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Sub VoidTransaction(ByVal reason As String)
        mySql = "SELECT * FROM " & fillData & " WHERE dollarID = " & _dollarID
        ds.Clear()

        ds = LoadSQL(mySql, fillData)
        If ds.Tables(0).Rows.Count <= 0 Then
            MsgBox("Transaction not found!", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ds.Tables(0).Rows(0).Item("Status") = "V"
        ds.Tables(0).Rows(0).Item("Remarks") = reason
        database.SaveEntry(ds, False)

        RemoveJournal("Ref# " & _dollarID)
        Console.WriteLine("Transaction #" & _dollarID & " void")
    End Sub

    Public Function LastIDNumber() As Single
        Dim mySql As String = "SELECT * FROM tblDollar ORDER BY DOLLARID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("DollarID")
    End Function
#End Region

End Class