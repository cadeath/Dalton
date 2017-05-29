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

    Private _isGenerated As Boolean
    Public Property isGenerated() As Boolean
        Get
            Return _isGenerated
        End Get
        Set(ByVal value As Boolean)
            _isGenerated = value
        End Set
    End Property

    Private _action_Type As Integer
    Public Property Action_Type() As Integer
        Get
            Return _action_Type
        End Get
        Set(ByVal value As Integer)
            _action_Type = value
        End Set
    End Property

    Private _hasPayoutCommission As Boolean
    Public Property HasPayoutCommission() As Boolean
        Get
            Return _hasPayoutCommission
        End Get
        Set(ByVal value As Boolean)
            _hasPayoutCommission = value
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

            _isGenerated = IIf(.Item("isGenerated") = 1, True, False)
            If Not IsDBNull(.Item("Action_Type")) Then _action_Type = .Item("Action_Type")
            _hasPayoutCommission = IIf(.Item("HasPayoutCommission") = 1, True, False)
        End With
    End Sub

    Friend Sub SaveChargeName()
        Dim mysql As String = "Select * From tblMTCharge Where ChargeName = '" & _name & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(0).NewRow
            With dsNewRow
                .Item("ChargeName") = _name
                .Item("Description") = _description
                .Item("isGenerated") = IIf(_isGenerated = True, 1, 0)
                Select Case _action_Type
                    Case 1
                        .Item("Action_Type") = 1
                    Case 0
                        .Item("Action_Type") = 0
                    Case Else
                        IsDBNull(.Item("Action_Type"))
                End Select
                '.Item("Action_Type") = IIf(_action_Type = True, 1, 0)
                .Item("HasPayoutCommission") = IIf(_hasPayoutCommission = True, 1, 0)
          
            End With
            ds.Tables(0).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        Else
            With ds.Tables(0).Rows(0)
                .Item("ChargeName") = _name
                .Item("Description") = _description
                .Item("isGenerated") = IIf(_isGenerated = True, 1, 0)
                .Item("Action_Type") = IIf(_action_Type = True, 1, 0)
                .Item("HasPayoutCommission") = IIf(_hasPayoutCommission = True, 1, 0)
            End With
            database.SaveEntry(ds, False)
        End If
    End Sub

#End Region

End Class
