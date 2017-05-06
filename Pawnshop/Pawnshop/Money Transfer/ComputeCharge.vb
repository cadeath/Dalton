Public Class ComputeCharge

    Private _charge As Integer
    Public Property Charge() As Integer
        Get
            Return _charge
        End Get
        Set(ByVal value As Integer)
            _charge = value
        End Set
    End Property

    Private _commission As Integer
    Public Property Commision() As Integer
        Get
            Return _commission
        End Get
        Set(ByVal value As Integer)
            _commission = value
        End Set
    End Property

    Private _chargename As String
    Public Property ChargeName() As String
        Get
            Return _chargename
        End Get
        Set(ByVal value As String)
            _chargename = value
        End Set
    End Property

    Private _amt As Integer
    Public Property Amount() As Integer
        Get
            Return _amt
        End Get
        Set(ByVal value As Integer)
            _amt = value
        End Set
    End Property

    Private _chargedetail As ChargeName
    Public Property ChargeDetails() As ChargeName
        Get
            Return _chargedetail
        End Get
        Set(ByVal value As ChargeName)
            _chargedetail = value
        End Set
    End Property

    Friend Sub New(ByVal Chargename As String, ByVal amt As Integer)
        _chargename = Chargename
        _amt = amt

        Dim mysql As String = "Select * From tblMTCharge Where ChargeName = '" & Chargename & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        Dim chr As New ChargeName
        chr.LoadCharge(ds.Tables(0).Rows(0).Item("CHR_ID"))

        _chargedetail = chr
        _charge = GetItemCharge(0)
        _commission = GetItemCharge(1)
    End Sub
    Enum GetChargeType
        getcharge = 0
        getcommision = 1
    End Enum
    Private Function GetItemCharge(ByVal type As GetChargeType) As Double
        Dim Chrg As New ChargeName
        Chrg = _chargedetail

        For Each chrdetails As ChargeDetails In Chrg.ChargeDetail
            Select Case _amt
                Case chrdetails.AmountFrom To chrdetails.AmountTo
                    Select Case type
                        Case GetChargeType.getcharge
                            Return chrdetails.Charge
                        Case GetChargeType.getcommision
                            Return IIf(IsDBNull(chrdetails.Commision), 0, chrdetails.Commision)
                    End Select

            End Select
        Next

        Return 0
    End Function
End Class
