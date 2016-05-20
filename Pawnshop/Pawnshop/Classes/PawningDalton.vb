Public Class PawningDalton

#Region "Public Variables"
    ' INPUTS
    '======================================================
    Private _currentDate As Date
    Public Property CurrentDate() As Date
        Get
            Return _currentDate
        End Get
        Set(ByVal value As Date)
            _currentDate = value
        End Set
    End Property

    Private _principal As Double
    Public Property Principal() As Double
        Get
            Return _principal
        End Get
        Set(ByVal value As Double)
            _principal = value
        End Set
    End Property

    Private _class As String
    Public Property ItemClass() As String
        Get
            Return _class
        End Get
        Set(ByVal value As String)
            _class = value
        End Set
    End Property

    Private _loanDate As Date
    Public Property LoanDate() As Date
        Get
            Return _loanDate
        End Get
        Set(ByVal value As Date)
            _loanDate = value
        End Set
    End Property

    Private _matuDate As Date
    Public Property MaturityDate() As Date
        Get
            Return _matuDate
        End Get
        Set(ByVal value As Date)
            _matuDate = value
        End Set
    End Property

    Private _isNewItem As Boolean = True
    Public Property isNewItem() As Boolean
        Get
            Return _isNewItem
        End Get
        Set(ByVal value As Boolean)
            _isNewItem = value
        End Set
    End Property

    Private _intHash As String
    Public Property INT_Hash() As String
        Get
            Return _intHash
        End Get
        Set(ByVal value As String)
            _intHash = value
        End Set
    End Property


    ' END - INPUTS
    '======================================================

    ' OUTPUTS
    '======================================================
    Private _renewDue As Double
    Public ReadOnly Property RenewDue() As Double
        Get
            Return _renewDue
        End Get
    End Property

    Private _redeemDue As Double
    Public ReadOnly Property RedeemDue() As Double
        Get
            Return _redeemDue
        End Get
    End Property

    Private _advInt As Double
    Public ReadOnly Property AdvanceInterest() As Double
        Get
            Return _advInt
        End Get
    End Property

    Private _daysOver As Integer
    Public ReadOnly Property DaysOverDue() As Integer
        Get
            Return _daysOver
        End Get
    End Property

    Private _int As Double
    Public ReadOnly Property Interest() As Double
        Get
            Return _int
        End Get
    End Property

    Private _penalty As Double
    Public ReadOnly Property Penalty() As Double
        Get
            Return _penalty
        End Get
    End Property

    Private _srvChr As Double
    Public ReadOnly Property ServiceCharge() As Double
        Get
            Return _srvChr
        End Get
    End Property

    Private _isEarlyRedeem As Boolean = False
    Public ReadOnly Property isEarlyRedeem() As Boolean
        Get
            Return _isEarlyRedeem
        End Get
    End Property

    Private _netAmount As Double
    Public ReadOnly Property NetAmount() As Double
        Get
            Return _netAmount
        End Get
    End Property


    '======================================================
    ' END - OUTPUTS
#End Region

    Public Sub New(ByVal prin As Double, ByVal itmClass As String, _
                   ByVal current As Date, ByVal matuDate As Date, _
                   ByVal isNew As Boolean, intHash As String)
        _principal = prin
        _class = itmClass
        _currentDate = current
        _matuDate = matuDate
        _isNewItem = isNew
        _intHash = intHash

        Main()
    End Sub

    Private Sub Main()
        Dim itemClass_Int As Double, itemClass_Penalty As Double
        Dim earlyDays As Integer
        Dim item_Interest As Double, item_Penalty As Double, Delay_Int As Double

        item_Interest = 0
        item_Penalty = 0

        'Validation
        Dim difDay = _currentDate.Date - _matuDate.Date
        earlyDays = difDay.Days + 30
        _daysOver = If(earlyDays - 30 > 0, earlyDays - 30, 0)
        itemClass_Int = GetInt(earlyDays)
        itemClass_Penalty = GetInt(earlyDays, "Penalty")
        _advInt = GetInt(30) * _principal
        _srvChr = GetServiceCharge(_principal)


        'Compute
        item_Interest = _principal * itemClass_Int
        item_Penalty = _principal * itemClass_Penalty
        Delay_Int = _principal * itemClass_Int
        _int = IIf(_isNewItem, item_Interest, Delay_Int)
        _penalty = item_Penalty

        _netAmount = _principal - _advInt - _srvChr
        If _isNewItem Then
            'Renew
            _renewDue = IIf(item_Interest > _advInt, item_Interest, _advInt) + item_Penalty + _srvChr

            If _isEarlyRedeem Then
                _redeemDue = _principal - _advInt + item_Interest
                '_redeemDue = _netAmount + item_Interest
            Else
                _redeemDue = _principal + item_Interest + item_Penalty - _advInt
            End If
        Else
            _advInt = 0
            _renewDue = Delay_Int + _srvChr + item_Penalty
            _redeemDue = _principal + item_Interest + _srvChr + item_Penalty
        End If
    End Sub

#Region "System Functions"
    Private Function GetInt(ByVal days As Integer, Optional ByVal tbl As String = "Interest") As Double
        Dim mySql As String = "SELECT DAYFROM, DAYTO, ITEMTYPE, INTEREST, PENALTY, REMARKS "
        mySql &= "FROM TBLINT"

        If HAS_THE_SAME_HASH(_intHash) Then
            mySql = "SELECT * FROM tblInt WHERE ItemType = '" & _class & "' AND STATUS = 0"
        Else
            mySql = "SELECT * FROM TBLINT_HISTORY WHERE ItemType = '" & _class & String.Format("' AND CHECKSUM = '{0}'", _intHash)
        End If

        Dim ds As DataSet = LoadSQL(mySql), TypeInt As Double

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim min As Integer = 0, max As Integer = 0
            min = dr.Item("DayFrom") : max = dr.Item("DayTo")

            Select Case days
                Case min To max
                    TypeInt = dr.Item(tbl)
                    If dr.Item("Remarks") = "Early Redemption" Then
                        _isEarlyRedeem = True
                    End If
                    Return TypeInt
            End Select
        Next

        Return 0
    End Function

    Private Function GetServiceCharge(ByVal principal As Double) As Double
        Dim srvPrin As Double = principal
        Dim ret As Double = 0

        If srvPrin < 500 Then
            ret = srvPrin * 0.01
        Else
            ret = 5
        End If

        Return ret
    End Function

    Private Function HAS_THE_SAME_HASH(str As String) As Boolean
        Dim ds As DataSet, ds1 As DataSet
        Dim mySql As String = "SELECT DAYFROM, DAYTO, ITEMTYPE, INTEREST, PENALTY, REMARKS FROM TBLINT"

        If TBLINT_HASH = "" Then
            ds = LoadSQL(mySql)
            TBLINT_HASH = GetMD5(ds)
            Console.WriteLine("Table INT Hash is >>>> " & TBLINT_HASH)

            Dim fillData As String = "tblInt_History"
            mySql = "SELECT * "
            mySql &= "FROM TBLINT_HISTORY "
            mySql &= String.Format("WHERE CHECKSUM = '{0}'", TBLINT_HASH)
            ds1 = LoadSQL(mySql, fillData)

            If ds1.Tables(0).Rows.Count = 0 Then

                For Each dr As DataRow In ds.Tables(0).Rows
                    Dim dsNewRow As DataRow
                    dsNewRow = ds1.Tables(fillData).NewRow
                    With dsNewRow
                        .Item("DAYFROM") = dr("DAYFROM")
                        .Item("DAYTO") = dr("DAYTO")
                        .Item("ITEMTYPE") = dr("ITEMTYPE")
                        .Item("INTEREST") = dr("INTEREST")
                        .Item("PENALTY") = dr("PENALTY")
                        .Item("REMARKS") = dr("REMARKS")
                        .Item("CHECKSUM") = TBLINT_HASH
                    End With
                    ds1.Tables(fillData).Rows.Add(dsNewRow)
                Next
                database.SaveEntry(ds1)
            End If
        End If

        Console.WriteLine(str)
        Console.WriteLine(TBLINT_HASH)
        Console.WriteLine("Answer: " & str <> TBLINT_HASH)

        If str.Length <= 5 Then Log_Report("[LENGTH 5 AND BELOW] HASH is " & str)

        If str = "" Then Return True
        If str <> TBLINT_HASH Then

            mySql = "SELECT * FROM TBLINT_HISTORY WHERE "
            mySql &= String.Format("CHECKSUM = '{0}'", str)

            ds = LoadSQL(mySql)
            If ds.Tables(0).Rows.Count = 0 Then
                Log_Report("Cannot find Hash from TBLINT_History HASH: " & str)
                MsgBox("INTEREST CANNOT BE FOUND" + vbCrLf + "Please contact the IT Department", MsgBoxStyle.Critical, _
                       "ERROR [COMPUTE]")
            End If

            Return False
        End If

        Return True
    End Function
#End Region

End Class