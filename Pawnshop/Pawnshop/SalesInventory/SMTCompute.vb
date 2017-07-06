Public Class SMTCompute
#Region "Properties"
    Private _totalAmount As Double
    Public Property TotalAmount() As Double
        Get
            Return _totalAmount
        End Get
        Set(ByVal value As Double)
            _totalAmount = value
        End Set
    End Property

    Private _transferFee As Double
    Public Property TransferFee() As Double
        Get
            Return _transferFee
        End Get
        Set(ByVal value As Double)
            _transferFee = value
        End Set
    End Property

    Private _SMTCollect As SMTCollection
    Public Property SMTCollect() As SMTCollection
        Get
            Return _SMTCollect
        End Get
        Set(ByVal value As SMTCollection)
            _SMTCollect = value
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

    Private _invDeduct As Double
    Public Property InvDeduct() As Double
        Get
            Return _invDeduct
        End Get
        Set(ByVal value As Double)
            _invDeduct = value
        End Set
    End Property

#End Region

#Region "Procedures"
    Friend Sub New(ByVal amt As Double)
        Dim mysql As String = "SELECT * FROM TBLSMTRANSFERFEE"
        Dim ds As DataSet = LoadSQL(mysql, "TBLSMTRANSFERFEE")

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("Invalid Transfer Fee", MsgBoxStyle.Critical, "Smart Money Padala") : Exit Sub

        _SMTCollect = New SMTCollection
        For Each dr In ds.Tables(0).Rows
            Dim SmTransferFee As New SmartMoneyTransferFee
            SmTransferFee.LoadSMT(dr.item("SMT_ID"))

            _SMTCollect.Add(SmTransferFee)
        Next

        _transferFee = GetSMTFee(amt)
        _invDeduct = amt + GetSMTFee(amt)


        Dim tmpinvDeduct As Double = 0
        Select Case amt
            Case 0.01 To 1000
                tmpinvDeduct = 20
            Case Else
                tmpinvDeduct = 20 + (amt * 0.01)
        End Select
        _totalAmount = amt + tmpinvDeduct
        _commission = _totalAmount - _invDeduct

        Console.WriteLine("Transfer Fee " & _transferFee)
        Console.WriteLine("Total Deduct " & _invDeduct)
        Console.WriteLine("Total Amount " & _totalAmount)
        Console.WriteLine("Total Commission " & _commission)

    End Sub

    Private Function GetSMTFee(ByVal amt As Double)
        For Each fee As SmartMoneyTransferFee In SMTCollect
            Select Case amt
                Case fee.SmtMin To fee.SmtMax
                    Return fee.SmtTransferFee
            End Select
        Next
        Return 0
    End Function
#End Region
End Class
