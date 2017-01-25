Public Class LayAwayLines
    Dim mysql As String = String.Empty
    Dim fillData As String = "tblLayLines"
    Dim ds As DataSet
#Region "Property"
    Private _layLinesID As Integer
    Public Property LayLinesID() As Integer
        Get
            Return _layLinesID
        End Get
        Set(ByVal value As Integer)
            _layLinesID = value
        End Set
    End Property

    Private _layID As Integer
    Public Property LayID() As Integer
        Get
            Return _layID
        End Get
        Set(ByVal value As Integer)
            _layID = value
        End Set
    End Property

    Private _amount As Integer
    Public Property Amount() As Integer
        Get
            Return _amount
        End Get
        Set(ByVal value As Integer)
            _amount = value
        End Set
    End Property

    Private _paymentDate As Date
    Public Property PaymentDate() As Date
        Get
            Return _paymentDate
        End Get
        Set(ByVal value As Date)
            _paymentDate = value
        End Set
    End Property

    Private _lineStatus As String
    Public Property LineStatus() As String
        Get
            Return _lineStatus
        End Get
        Set(ByVal value As String)
            _lineStatus = value
        End Set
    End Property

    Private _penalty As Integer
    Public Property Penalty() As Integer
        Get
            Return _penalty
        End Get
        Set(ByVal value As Integer)
            _penalty = value
        End Set
    End Property

    Private _controlnum As String
    Public Property ControlNumber() As String
        Get
            Return _controlnum
        End Get
        Set(ByVal value As String)
            _controlnum = value
        End Set
    End Property

    Private _paymentEncoder As Integer
    Public Property PaymentEncoder() As Integer
        Get
            Return _paymentEncoder
        End Get
        Set(ByVal value As Integer)
            _paymentEncoder = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Friend Sub SaveLayAwayLines()
        mysql = "Select * From tblLaylines Rows 1"
        ds = LoadSQL(mysql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("PaymentDate") = _paymentDate
            .Item("LayID") = _layID
            .Item("ControlNum") = _controlnum
            .Item("Amount") = _amount
            .Item("Penalty") = _penalty
            .Item("PaymentEncoder") = _paymentEncoder
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Friend Sub LoadByID(ByVal ID As Integer)
        Dim mysql As String = "Select * From tblLayLines Where LinesID = " & ID
        Dim ds As DataSet = LoadSQL(mysql, "tblLayLines")
        LoadRow(ds.Tables(0).Rows(0))
    End Sub

    Friend Sub LoadByLayID(ByVal tmpID As Integer)
        Dim mysql As String = "Select * From tblLayLines Where LayID = " & tmpID
        Dim ds As DataSet = LoadSQL(mysql, "tblLayLines")
        LoadRow(ds.Tables(0).Rows(0))
    End Sub

    Private Sub LoadRow(ByVal dr As DataRow)
        With dr
            _layLinesID = .Item("LinesID")
            _layID = .Item("LayID")
            _controlnum = .Item("ControlNum")
            _amount = .Item("Amount")
            _penalty = .Item("Penalty")
            _paymentDate = .Item("PaymentDate")
            _lineStatus = .Item("Status")
            _paymentEncoder = .Item("PaymentEncoder")
        End With
    End Sub

    Friend Sub VoidLayPayment()
        Dim mysql As String = "Select * From tblLayLines Where LinesID =  " & _layLinesID
        Dim fillData As String = "tblLayLines"
        Dim ds As DataSet = LoadSQL(mysql, fillData)

        Dim AddAmt As Integer
        With ds.Tables(0).Rows(0)
            AddAmt = .Item("Amount")
        End With

        ds.Tables(0).Rows(0).Item("Status") = 0
        SaveEntry(ds, False)

        mysql = "Select * From tblLayAway Where LayID = " & _layID
        fillData = "tblLayAway"
        ds = LoadSQL(mysql, fillData)

        If ds.Tables(0).Rows(0).Item("Balance") = 0 Then
            Dim itemCode As String = ds.Tables(0).Rows(0).Item("ItemCode")
            Dim lay As New LayAway
            lay.ItemOnLayMode(itemCode)
            InventoryController.AddInventory(itemCode, 1)
        End If

        Dim layAway As New LayAway
        With layAway
            .LoadByID(_layID)
            .UpdateBalance(layAway.Balance + AddAmt)
        End With

    End Sub

    Friend Function LayLinesLastID()
        Dim mysql As String = "Select * From tblLayLines ORDER BY LinesID DESC"
        Dim filldata As String = "tblLayLines"
        Dim ds As DataSet = LoadSQL(mysql, filldata)
        If ds.Tables(0).Rows().Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("LinesID")
    End Function

    Friend Function GetSumPayments()
        Dim mysql As String = "Select Sum(amount) as Amount, SUM(PENALTY)AS Penalty "
        mysql &= "From tblLayLines Where Status <> 0 And LayID = '" & _layID & "'"
        Dim fillData As String = "tblLayLines"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        Dim Payments As Double = 0

        With ds.Tables(0).Rows(0)
            Payments = .Item("Amount")
        End With

        Return Payments
    End Function
#End Region
End Class
