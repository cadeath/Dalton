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

    Private _Chargedetail As Charge_Details
    Public Property ChargeDetail() As Charge_Details
        Get
            Return _Chargedetail
        End Get
        Set(ByVal value As Charge_Details)
            _Chargedetail = value
        End Set
    End Property


#End Region

#Region "Procedures"
    Friend Sub LoadCharge(ByVal id As Integer)
        Dim mysql As String = "Select * From tblMtCharge Where CHR_ID = " & id
        Dim ds As DataSet = LoadSQL(mysql, "tblMtCharge")

        For Each dr In ds.Tables(0).Rows
            LoadbyDatarow(dr)
        Next

        mysql = "Select * From tblMTDetails Where Chr_ID = " & ChrID & " Order By ID"
        ds = LoadSQL(mysql, "tblMTDetails")

        _Chargedetail = New Charge_Details
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpDetails As New ChargeDetails
            tmpDetails.LoadbyDatarow(dr)

            _Chargedetail.Add(tmpDetails)
        Next
    End Sub

    Private Sub LoadbyDatarow(ByVal dr As DataRow)
        With dr
            _chrid = .Item("CHR_ID")
            _name = .Item("ChargeName")
            _description = .Item("Description")
        End With
    End Sub

#End Region

End Class
