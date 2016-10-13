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

    Private _pawner As New Client
    Public Property Pawner() As Client
        Get
            Return _pawner
        End Get
        Set(ByVal value As Client)
            _pawner = value
        End Set
    End Property

    Private _pawnItem As New PawnItem
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

    Private _description As String
    Public Property Description() As String
        Get
            Return _description
        End Get
        Set(ByVal value As String)
            _description = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"
    Public Sub Save_PawnTicket()
        'Declaration
        Dim mySql As String
        Dim ds As DataSet

        'Save PawnedItem
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
            .Item("CLIENTID") = _pawner.ID
            .Item("PAWNITEMID") = _pawnItem.ID
            .Item("DESCRIPTION") = DescriptionBuilder()
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
            .Item("CREATED_AT") = Now.ToShortDateString
        End With

        ds.Tables(MainTable).Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Public Sub Update_PawnTicket()
        Dim mySql As String, ds As DataSet

        mySql = String.Format("SELECT * FROM {0} WHERE PAWNTICKET = {1}", MainTable, _ticket)
        ds = LoadSQL(mySql, MainTable)

        With ds.Tables(0).Rows(0)
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
            .Item("CLIENTID") = _pawner.ID
            .Item("PAWNITEMID") = _pawnItem.ID
            .Item("DESCRIPTION") = _description
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
            .Item("UPDATED_AT") = Now.ToShortDateString
        End With

        database.SaveEntry(ds, False)
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
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE PAWNTICKET = {1}", MainTable, ptnum)
        Dim ds As DataSet = LoadSQL(mySql)

        Load_PT_row(ds.Tables(0).Rows(0))
    End Sub

    Private Sub Load_PT_row(ByVal dr As DataRow)
        'On Error Resume Next

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
            _pawner.LoadClient(.Item("CLIENTID"))
            _description = .Item("DESCRIPTION")
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

            If Not IsDBNull(.Item("CREATED_AT")) Then _created_At = .Item("CREATED_AT")
            If Not IsDBNull(.Item("UPDATED_AT")) Then _updated_At = .Item("UPDATED_AT")

            _pawnItem.Load_PawnItem(.Item("PAWNITEMID"))
        End With
    End Sub

    Private Function DescriptionBuilder() As String
        Dim Description As String = ""
        Dim PrintLayout As String = _pawnItem.ItemClass.PrintLayout
        '[CLASSNAME][GRAMS][KARAT][DESCRIPTION]
        'FUNCTIONS:
        'CLASS - Display Item Class

        PrintLayout = PrintLayout.Replace("[CLASS]", _pawnItem.ItemClass.ClassName)

        For Each sc As PawnItemSpec In _pawnItem.PawnItemSpecs
            PrintLayout = PrintLayout.Replace(String.Format("[{0}]", GetShortCode(sc)), _
                                              String.Format("{0}{1}", sc.SpecsValue, sc.UnitOfMeasure))
        Next
        Description = PrintLayout

        Return Description
    End Function

    Private Function GetShortCode(ByVal ItemSpec As PawnItemSpec) As String
        For Each spec As ItemSpecs In _pawnItem.ItemClass.ItemSpecifications
            If spec.SpecName = ItemSpec.SpecName Then
                Return spec.ShortCode
            End If
        Next

        Return "N/A"
    End Function
#End Region

End Class