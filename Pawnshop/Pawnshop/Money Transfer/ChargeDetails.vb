Public Class ChargeDetails

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

    Private _chrid As Integer
    Public Property ChrID() As Integer
        Get
            Return _chrid
        End Get
        Set(ByVal value As Integer)
            _chrid = value
        End Set
    End Property

    Private _amountfrom As Double
    Public Property AmountFrom() As Double
        Get
            Return _amountfrom
        End Get
        Set(ByVal value As Double)
            _amountfrom = value
        End Set
    End Property

    Private _amountto As Double
    Public Property AmountTo() As Double
        Get
            Return _amountto
        End Get
        Set(ByVal value As Double)
            _amountto = value
        End Set
    End Property

    Private _charge As Double
    Public Property Charge() As Double
        Get
            Return _charge
        End Get
        Set(ByVal value As Double)
            _charge = value
        End Set
    End Property

    Private _commision As Double
    Public Property Commision() As Double
        Get
            Return _commision
        End Get
        Set(ByVal value As Double)
            _commision = value
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

#Region "Procedures"
    Friend Sub LoadChargeDetails(ByVal Chr_ID As Integer)
        Dim mysql As String = "Select * From tblChargeDetails Where Chr_ID = " & Chr_ID
        Dim ds As DataSet = LoadSQL(mysql, "tblChargeDetails")

        For Each dr In ds.Tables(0).Rows
            LoadbyDatarow(dr)
        Next

    End Sub

    Private Sub LoadbyDatarow(ByVal dr As DataRow)
        With dr
            _id = .Item("ID")
            _chrid = .Item("CHR_ID")
            _amountfrom = .Item("AmountFrom")
            _amountto = .Item("AmountTo")
            _charge = .Item("Charge")
            _commision = .Item("Commision")
            _remarks = .Item("Remarks")
        End With
    End Sub
#End Region
End Class
