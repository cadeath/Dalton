Public Class PawnTicket2

    Private MainTable As String = "OPT"

#Region "Properties"
    Private _PawnID As Integer
    Public Property PawnID() As Integer
        Get
            Return _PawnID
        End Get
        Set(ByVal value As Integer)
            _PawnID = value
        End Set
    End Property

    Private _ticket As Integer
    Public Property PawnTicket() As Integer
        Get
            Return _ticket
        End Get
        Set(ByVal value As Integer)
            _ticket = value
        End Set
    End Property

    Private _oldPT As Integer
    Public Property OldTicket() As Integer
        Get
            Return _oldPT
        End Get
        Set(ByVal value As Integer)
            _oldPT = value
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

    Private _expiryDate As Date
    Public Property ExpiryDate() As Date
        Get
            Return _expiryDate
        End Get
        Set(ByVal value As Date)
            _expiryDate = value
        End Set
    End Property

    Private _auctionDate As Date
    Public Property AuctionDate() As Date
        Get
            Return _auctionDate
        End Get
        Set(ByVal value As Date)
            _auctionDate = value
        End Set
    End Property

    Private _appraisal As Double
    Public Property Appraisal() As Double
        Get
            Return _appraisal
        End Get
        Set(ByVal value As Double)
            _appraisal = value
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

    Private _netAmount As Double
    Public Property NetAmount() As Double
        Get
            Return _netAmount
        End Get
        Set(ByVal value As Double)
            _netAmount = value
        End Set
    End Property

    Private _appraiserID As Integer
    Public Property AppraiserID() As Integer
        Get
            Return _appraiserID
        End Get
        Set(ByVal value As Integer)
            _appraiserID = value
        End Set
    End Property

    Private _encoderID As Integer
    Public Property EncoderID() As Integer
        Get
            Return _encoderID
        End Get
        Set(ByVal value As Integer)
            _encoderID = value
        End Set
    End Property

    Private _claimerID As Integer
    Public Property ClaimerID() As Integer
        Get
            Return _claimerID
        End Get
        Set(ByVal value As Integer)
            _claimerID = value
        End Set
    End Property

    Private _clientID As Integer
    Public Property ClientID() As Integer
        Get
            Return _clientID
        End Get
        Set(ByVal value As Integer)
            _clientID = value
        End Set
    End Property

    Private _pawnItem As PawnItem
    Public Property PawnItem() As PawnItem
        Get
            Return _pawnItem
        End Get
        Set(ByVal value As PawnItem)
            _pawnItem = value
        End Set
    End Property

    Private _ORDate As Date
    Public Property ORDate() As Date
        Get
            Return _ORDate
        End Get
        Set(ByVal value As Date)
            _ORDate = value
        End Set
    End Property

    Private _ORNum As Integer
    Public Property ORNumber() As Integer
        Get
            Return _ORNum
        End Get
        Set(ByVal value As Integer)
            _ORNum = value
        End Set
    End Property

    Private _penalty As Double
    Public Property Penalty() As Double
        Get
            Return _penalty
        End Get
        Set(ByVal value As Double)
            _penalty = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _daysOverDue As Integer
    Public Property DaysOverDue() As Integer
        Get
            Return _daysOverDue
        End Get
        Set(ByVal value As Integer)
            _daysOverDue = value
        End Set
    End Property

    Private _earlyRedeem As Double
    Public Property EarlyReddem() As Double
        Get
            Return _earlyRedeem
        End Get
        Set(ByVal value As Double)
            _earlyRedeem = value
        End Set
    End Property

    Private _delayInt As Double
    Public Property DelayInterest() As Double
        Get
            Return _delayInt
        End Get
        Set(ByVal value As Double)
            _delayInt = value
        End Set
    End Property

    Private _advInt As Double
    Public Property AdvanceInterest() As Double
        Get
            Return _advInt
        End Get
        Set(ByVal value As Double)
            _advInt = value
        End Set
    End Property

    Private _renewDue As Double
    Public Property RenewDue() As Double
        Get
            Return _renewDue
        End Get
        Set(ByVal value As Double)
            _renewDue = value
        End Set
    End Property

    Private _redeemDue As Double
    Public Property RedeemDue() As Double
        Get
            Return _redeemDue
        End Get
        Set(ByVal value As Double)
            _redeemDue = value
        End Set
    End Property

    Private _serviceCharge As Double
    Public Property ServiceCharge() As Double
        Get
            Return _serviceCharge
        End Get
        Set(ByVal value As Double)
            _serviceCharge = value
        End Set
    End Property

    Private _created_At As Date
    Public Property Created_At() As String
        Get
            Return _created_At
        End Get
        Set(ByVal value As String)
            _created_At = value
        End Set
    End Property

    Private _updated_At As Date
    Public Property Updated_At() As Date
        Get
            Return _updated_At
        End Get
        Set(ByVal value As Date)
            _updated_At = value
        End Set
    End Property
#End Region

#Region "Procedures and Functions"
    Public Sub Save_PawnTicket()
        'Declaration
        Dim mySql As String
        Dim ds As DataSet

        'Save the PawnItem
        _pawnItem.Save_PawnItem()

        'Save PawnTicket
        mySql = String.Format("SELECT * FROM {0} ROWS 1", MainTable)
        ds = LoadSQL(mySql, MainTable)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(MainTable).NewRow
        With dsNewRow
            .Item("PAWNTICKET") = _ticket
            .Item("OLDTICKET") = _oldPT
            .Item("LOANDATE") = _loanDate
            .Item("MATUDATE") = _matuDate
            .Item("EXPIRYDATE") = _expiryDate
            .Item("AUCTIONDATE") = _auctionDate
            .Item("APPRAISAL") = _appraisal
            .Item("PRINCIPAL") = _principal
            .Item("NETAMOUNT") = _netAmount
            .Item("APPRAISERID") = _appraiserID
            .Item("ENCODERID") = _encoderID
            .Item("CLAIMERID") = _claimerID
            .Item("CLIENTID") = _clientID
            .Item("PAWNITEMID") = _pawnItem.ID
            .Item("ORDATE") = _ORDate
            .Item("ORNUM") = _ORNum
            .Item("PENALTY") = _penalty
            .Item("STATUS") = _status
            .Item("DAYSOVERDUE") = _daysOverDue
            .Item("EARLYREDEEM") = _earlyRedeem
            .Item("DELAYINTEREST") = _delayInt
            .Item("ADVINT") = _advInt
            .Item("RENEWDUE") = _renewDue
            .Item("REDEEMDUE") = _redeemDue
            .Item("SERVICECHARGE") = _serviceCharge
            .Item("CREATED_AT") = _created_At
        End With
        ds.Tables(MainTable).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Load_PTid(ByVal id As Integer)
        Dim mySql As String = String.Format("SELECT * {0} WHERE PAWNID = {1}", MainTable, id)
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count <> 1 Then
            MsgBox("Unable to load information", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Load_PT_row(ds.Tables(0).Rows(0))
    End Sub

    Public Sub Load_PawnTicket(ByVal ptnum As Integer)
        Dim mySql As String = String.Format("SELECT * {0} WHERE PAWNTICKET = {1}", MainTable, ptnum)
        Dim ds As DataSet = LoadSQL(mySql)

        Load_PT_row(ds.Tables(0).Rows(0))
    End Sub

    Private Sub Load_PT_row(ByVal dr As DataRow)
        With dr
            _PawnID = .Item("PAWNID")
            _ticket = .Item("PAWNTICKET")
            _oldPT = .Item("OLDTICKET")
            _loanDate = .Item("LOANDATE")
            _matuDate = .Item("MATUDATE")
            _expiryDate = .Item("EXPIRYDATE")
            _auctionDate = .Item("AUCTIONDATE")
            _appraisal = .Item("APPRAISAL")
            _principal = .Item("PRINCIPAL")
            _netAmount = .Item("NETAMOUNT")
            _appraiserID = .Item("APPRAISERID")
            _encoderID = .Item("ENCODERID")
            _claimerID = .Item("CLAIMERID")
            _clientID = .Item("CLIENTID")
            _ORDate = .Item("ORDATE")
            _ORNum = .Item("ORNUM")
            _penalty = .Item("PENALTY")
            _status = .Item("STATUS")
            _daysOverDue = .Item("DAYSOVERDUE")
            _earlyRedeem = .Item("EARLYREDEEM")
            _delayInt = .Item("DELAYINTEREST")
            _advInt = .Item("ADVINT")
            _renewDue = .Item("RENEWDUE")
            _redeemDue = .Item("REDEEMDUE")
            _serviceCharge = .Item("SERVICECHARGE")
            _created_At = .Item("CREATED_AT")
            _updated_At = .Item("UPDATED_AT")

            _pawnItem.Load_PawnItem(.Item("PAWNITEMID"))
        End With
    End Sub
#End Region

End Class