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
    Friend Sub SaveChargeDetails()
        Dim mysql As String = "Select * From tblMtDetails Where ID = " & _id
        Dim ds As DataSet = LoadSQL(mysql, "tblMtDetails")

        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables("tblMTDetails").NewRow
            With dsNewRow
                .Item("CHR_ID") = _chrid
                .Item("AMOUNTFROM") = _amountfrom
                .Item("AMOUNTTO") = _amountto
                .Item("CHARGE") = _charge
                .Item("COMMISION") = _commision
                .Item("REMARKS") = _remarks
            End With
            ds.Tables("tblMTDetails").Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        Else
            With ds.Tables(0).Rows(0)
                .Item("CHR_ID") = _chrid
                .Item("AMOUNTFROM") = _amountfrom
                .Item("AMOUNTTO") = _amountto
                .Item("CHARGE") = _charge
                .Item("COMMISION") = _commision
                .Item("REMARKS") = _remarks
            End With
            database.SaveEntry(ds, False)
        End If

    End Sub

    Friend Sub LoadChargeDetails(ByVal Chr_ID As Integer)
        Dim mysql As String = "Select * From tblMtDetails Where Chr_ID = " & Chr_ID
        Dim ds As DataSet = LoadSQL(mysql, "tblMtDetails")

        For Each dr In ds.Tables(0).Rows
            LoadbyDatarow(dr)
        Next

    End Sub

    Friend Sub LoadbyDatarow(ByVal dr As DataRow)
        With dr
            _id = .Item("ID")
            _chrid = .Item("CHR_ID")
            _amountfrom = .Item("AmountFrom")
            _amountto = .Item("AmountTo")
            _charge = .Item("Charge")
            If Not IsDBNull(.Item("Commision")) Then _commision = .Item("Commision")
            If Not IsDBNull(.Item("Remarks")) Then _remarks = .Item("Remarks")
        End With
    End Sub
#End Region
End Class
