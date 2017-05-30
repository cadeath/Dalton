Public Class ComputeCharge

    Private _charge As Double
    Public Property Charge() As Double
        Get
            Return _charge
        End Get
        Set(ByVal value As Double)
            _charge = value
        End Set
    End Property

    Private _commission As Double
    Public Property Commision() As Double
        Get
            Return _commission
        End Get
        Set(ByVal value As Double)
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

    Private _amt As Double
    Public Property Amount() As Double
        Get
            Return _amt
        End Get
        Set(ByVal value As Double)
            _amt = value
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

    Private _chargedetail As ChargeName
    Public Property ChargeDetails() As ChargeName
        Get
            Return _chargedetail
        End Get
        Set(ByVal value As ChargeName)
            _chargedetail = value
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

    Private _action_Type As Boolean
    Public Property Action_Type() As Boolean
        Get
            Return _action_Type
        End Get
        Set(ByVal value As Boolean)
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

    Private _isSend As Boolean
    Public Property isSend() As Boolean
        Get
            Return _isSend
        End Get
        Set(ByVal value As Boolean)
            _isSend = value
        End Set
    End Property

    Private _bracket As Integer
    Public Property Bracket() As Integer
        Get
            Return _bracket
        End Get
        Set(ByVal value As Integer)
            _bracket = value
        End Set
    End Property

    Enum Action
        Send = 0
        Receive = 1
    End Enum
    Friend Sub New(ByVal Chargename As String, ByVal amt As Integer, ByVal act As Action)
        _chargename = Chargename
        _amt = amt
        _isSend = IIf(act = Action.Send, True, False)

        Dim mysql As String = "Select * From tblMTCharge Where ChargeName = '" & Chargename & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        Dim chr As New ChargeName
        chr.LoadChargeCompute(ds.Tables(0).Rows(0).Item("CHR_ID"), act, GetValue(Chargename))

        _isGenerated = chr.isGenerated
        _action_Type = chr.Action_Type
        _hasPayoutCommission = chr.HasPayoutCommission

        _chargedetail = chr
        _charge = GetItemCharge(GetChargeType.getcharge)
        _commission = GetItemCharge(GetChargeType.getcommision)
        _netAmount = _amt + _charge
        _bracket = GetItemCharge(GetChargeType.getbracket)

    End Sub

    Private Function GetValue(ByVal tmpChargeName As String)
        Dim mysql As String = "Select * From tblMTCharge Where ChargeName = '" & tmpChargeName & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        Select Case ds.Tables(0).Rows(0).Item("HASPAYOUTCOMMISSION")
            Case 1
                Return True
            Case 0
                Return False
        End Select
        Return False
    End Function

    Enum GetChargeType
        getcharge = 0
        getcommision = 1
        getbracket = 2
    End Enum
    Private Function GetItemCharge(ByVal type As GetChargeType) As Double
        Dim Chrg As New ChargeName
        Chrg = _chargedetail

        For Each chrdetails As ChargeDetails In Chrg.ChargeDetail
            Dim tmpRemarks As String = String.Empty
            If Not chrdetails.Remarks Is Nothing Then tmpRemarks = chrdetails.Remarks
            Select Case _amt
                Case chrdetails.AmountFrom To chrdetails.AmountTo
                    Select Case type

                        Case GetChargeType.getcharge
                            Dim tmpSrvAmt As Double = 0, Chrge As Double
                            If isSend = False And HasPayoutCommission = False Then Return 0
                            If HasPayoutCommission = True Then
                                If tmpRemarks.Split("|").Count > 1 Then

                                    Select Case chrdetails.Remarks.Split("|")(1)
                                        Case "Percent"
                                            tmpSrvAmt = chrdetails.Charge / 100
                                            Chrge = _amt * tmpSrvAmt
                                        Case Else
                                            MsgBox("Remarks INVALID!" + vbCrLf + "No SERVICE CHARGE", vbCritical, "DEVELOPER Warning")
                                            Chrge = 0
                                    End Select
                                    Return Chrge

                                End If
                                Return chrdetails.Charge
                            Else
                                If tmpRemarks.Split("|").Count > 1 Then

                                    Select Case tmpRemarks.Split("|")(1)
                                        Case "Percent"
                                            tmpSrvAmt = chrdetails.Charge / 100
                                            Chrge = _amt * tmpSrvAmt
                                        Case Else
                                            MsgBox("Remarks INVALID!" + vbCrLf + "No SERVICE CHARGE", vbCritical, "DEVELOPER Warning")
                                            Chrge = 0
                                    End Select
                                    Return Chrge

                                End If
                                Return chrdetails.Charge
                            End If


                        Case GetChargeType.getcommision
                            Dim tmpSrvAmt As Double = 0, Chrge As Double
                            If HasPayoutCommission = True Then
                                Dim tmpcommission As Double
                                tmpcommission = IIf(IsDBNull(chrdetails.Commision), 0, chrdetails.Commision)
                                If tmpRemarks.Split("|").Count <= 2 Then Return tmpcommission
                                Select Case tmpRemarks.Split("|")(2)
                                    Case "SLC" 'ServiceCharge Less Charge
                                        tmpSrvAmt = chrdetails.Charge / 100
                                        Chrge = _amt * tmpSrvAmt
                                        tmpcommission = Chrge - tmpcommission
                                    Case Else
                                        MsgBox("Remarks INVALID!" + vbCrLf + "No COMMISSION", vbCritical, "DEVELOPER Warning")
                                        tmpcommission = 0
                                End Select
                                Return tmpcommission
                            Else
                                Return IIf(IsDBNull(chrdetails.Commision), 0, chrdetails.Commision)
                            End If

                        Case GetChargeType.getbracket
                            Return chrdetails.AmountTo
                    End Select

            End Select
        Next

        Return 0
    End Function
End Class
