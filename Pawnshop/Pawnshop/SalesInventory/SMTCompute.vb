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

#End Region
#Region "Procedures"
    Friend Sub New(ByVal amt As Double)
        Dim mysql As String = "SELECT * FROM TBLSMTRANSFERFEE"
        Dim ds As DataSet = LoadSQL(mysql, "TBLSMTRANSFERFEE")

        _SMTCollect = New SMTCollection
        For Each dr In ds.Tables(0).Rows
            Dim SmTransferFee As New SmartMoneyTransferFee
            SmTransferFee.LoadSMT(dr.item("SMT_ID"))

            _SMTCollect.Add(SmTransferFee)
        Next

        For Each fee As SmartMoneyTransferFee In SMTCollect
            Select Case amt
                Case fee.SmtMin To fee.SmtMax
                    _transferFee = fee.SmtTransferFee
                    _totalAmount = amt + fee.SmtTransferFee
                    Console.WriteLine("Transfer Fee " & _transferFee)
                    Console.WriteLine("Total Amount " & _totalAmount)
            End Select
        Next
    End Sub
#End Region
End Class
