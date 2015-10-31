Public Class PawnTicket

    Dim fillData As String = "tblPawn"

#Region "Variables"
    Private _pawnid As Integer
    Private _pawnTicket As Integer
    Private _client As Client
    Private _loanDate As Date
    Private _matuDate As Date
    Private _expiryDate As Date
    Private _auctionDate As Date
    Private _itemType As String
    Private _catID As Integer
    Private _description As String
    Private _karat As String
    Private _grams As Double
    Private _appraisal As Double
    Private _principal As Double
    Private _interest As Double
    Private _netAmount As Double
    Private _evat As Double
    Private _appraiserID As Integer

    Private _oldTicket As Integer
    Private _orNum As Integer
    Private _orDate As Date
    Private _lessPrincipal As Double
    Private _daysOverDue As Double
    Private _delayInt As Double
    Private _penalty As Double
    Private _serviceCharge As Double
    Private _renewDue As Double
    Private _redeemDue As Double
    Private _status As String

#End Region

#Region "Properties"
    Public ReadOnly Property PawnID As Integer
        Get
            Return _pawnid
        End Get
    End Property

    Public Property PawnTicket As Integer
        Set(ByVal value As Integer)
            _pawnTicket = value
        End Set
        Get
            Return _pawnTicket
        End Get
    End Property

    Public Property Pawner As Client
        Set(ByVal value As Client)
            _client = value
        End Set
        Get
            Return _client
        End Get
    End Property

    Public Property LoanDate As Date
        Set(ByVal value As Date)
            _loanDate = value
        End Set
        Get
            Return _loanDate
        End Get
    End Property

    Public Property MaturityDate As Date
        Set(ByVal value As Date)
            _matuDate = value
        End Set
        Get
            Return _matuDate
        End Get
    End Property

    Public Property ExpiryDate As Date
        Set(ByVal value As Date)
            _expiryDate = value
        End Set
        Get
            Return _expiryDate
        End Get
    End Property

    Public Property AuctionDate As Date
        Set(ByVal value As Date)
            _auctionDate = value
        End Set
        Get
            Return _auctionDate
        End Get
    End Property

    Public Property ItemType As String
        Set(ByVal value As String)
            _itemType = value
        End Set
        Get
            Return _itemType
        End Get
    End Property

    Public Property CategoryID As Integer
        Set(ByVal value As Integer)
            _catID = value
        End Set
        Get
            Return _catID
        End Get
    End Property

    Public Property Description As String
        Set(ByVal value As String)
            _description = value
        End Set
        Get
            Return _description
        End Get
    End Property

    Public Property Karat As String
        Set(ByVal value As String)
            _karat = value
        End Set
        Get
            Return _karat
        End Get
    End Property

    Public Property Grams As Double
        Set(ByVal value As Double)
            _grams = value
        End Set
        Get
            Return _grams
        End Get
    End Property

    Public Property Appraisal As Double
        Set(ByVal value As Double)
            _appraisal = value
        End Set
        Get
            Return _appraisal
        End Get
    End Property

    Public Property Principal As Double
        Set(ByVal value As Double)
            _principal = value
        End Set
        Get
            Return _principal
        End Get
    End Property

    Public Property Interest As Double
        Set(ByVal value As Double)
            _interest = value
        End Set
        Get
            Return _interest
        End Get
    End Property

    Public Property NetAmount As Double
        Set(ByVal value As Double)
            _netAmount = value
        End Set
        Get
            Return _netAmount
        End Get
    End Property

    Public Property EVAT As Double
        Set(ByVal value As Double)
            _evat = value
        End Set
        Get
            Return _evat
        End Get
    End Property

    Public Property AppraiserID As Integer
        Set(ByVal value As Integer)
            _appraiserID = value
        End Set
        Get
            Return _appraiserID
        End Get
    End Property

    Public Property Status As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Public Property OldTicket As Integer
        Set(ByVal value As Integer)
            _oldTicket = value
        End Set
        Get
            Return _oldTicket
        End Get
    End Property

    Public Property OfficialReceiptNumber As Integer
        Set(ByVal value As Integer)
            _orNum = value
        End Set
        Get
            Return _orNum
        End Get
    End Property

    Public Property OfficialReceiptDate As Date
        Set(ByVal value As Date)
            _orDate = value
        End Set
        Get
            If _orDate = #12:00:00 AM# Then
                _orDate = Nothing
            End If
            Return _orDate
        End Get
    End Property

    Public Property LessPrincipal As Double
        Set(ByVal value As Double)
            _lessPrincipal = value
        End Set
        Get
            Return _lessPrincipal
        End Get
    End Property

    Public Property DaysOverDue As Double
        Set(ByVal value As Double)
            _daysOverDue = value
        End Set
        Get
            Return _daysOverDue
        End Get
    End Property

    Public Property DelayInterest As Double
        Set(ByVal value As Double)
            _delayInt = value
        End Set
        Get
            Return _delayInt
        End Get
    End Property

    Public Property Penalty As Double
        Set(ByVal value As Double)
            _penalty = value
        End Set
        Get
            Return _penalty
        End Get
    End Property

    Public Property ServiceCharge As Double
        Set(ByVal value As Double)
            _serviceCharge = value
        End Set
        Get
            Return _serviceCharge
        End Get
    End Property

    Public Property RenewDue As Double
        Set(ByVal value As Double)
            _renewDue = value
        End Set
        Get
            Return _renewDue
        End Get
    End Property

    Public Property RedeemDue As Double
        Set(ByVal value As Double)
            _redeemDue = value
        End Set
        Get
            Return _redeemDue
        End Get
    End Property
#End Region

#Region "Procedures and Functions"
    Public Sub SaveTicket()
        Dim fillData As String = "tblPawn"
        Dim ds As DataSet, mySql As String = "SELECT * FROM " & fillData
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("PawnTicket") = _pawnTicket
            .Item("ClientID") = Pawner.ID
            .Item("LoanDate") = _loanDate
            .Item("MatuDate") = _matuDate
            .Item("ExpiryDate") = _expiryDate
            .Item("AuctionDate") = _auctionDate
            .Item("ItemType") = _itemType
            .Item("CatID") = _catID
            .Item("Description") = _description
            .Item("Karat") = _karat
            .Item("Grams") = _grams
            .Item("Appraisal") = _appraisal
            .Item("Principal") = _principal
            .Item("Interest") = _interest
            .Item("NetAmount") = _netAmount
            .Item("Evat") = _evat
            .Item("AppraiserID") = _appraiserID
            .Item("OldTicket") = _oldTicket
            .Item("ORNum") = _orNum
            .Item("ORDate") = _orDate
            .Item("LessPrincipal") = _lessPrincipal
            .Item("DaysOverDue") = _daysOverDue
            .Item("DelayInt") = _delayInt
            .Item("Penalty") = _penalty
            .Item("ServiceCharge") = _serviceCharge
            .Item("RenewDue") = _renewDue
            .Item("RedeemDue") = _redeemDue
            .Item("Status") = _status
            .Item("SystemInfo") = Now
            .Item("EncoderID") = UserID
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Sub LoadTicket(ByVal id As Integer, Optional ByVal col As String = "PAWNID")
        Dim mySql As String = "SELECT * FROM tblpawn WHERE " & col & " = " & id
        Dim ds As DataSet = LoadSQL(mySql)

        With ds.Tables(0).Rows(0)
            _pawnid = .Item("PawnID")
            _pawnTicket = .Item("PawnTicket")
            Dim tmpClient As New Client
            tmpClient.LoadClient(.Item("ClientID"))
            _client = tmpClient
            _loanDate = .Item("LoanDate")
            _matuDate = .Item("MatuDate")
            _expiryDate = .Item("ExpiryDate")
            _auctionDate = .Item("AuctionDate")
            _itemType = .Item("ItemType")
            _catID = .Item("CatID")
            _description = .Item("Description")
            _karat = .Item("Karat")
            _grams = .Item("Grams")
            _appraisal = .Item("Appraisal")
            _principal = .Item("Principal")
            _interest = .Item("Interest")
            _netAmount = .Item("NetAmount")
            _evat = .Item("Evat")
            _appraiserID = .Item("AppraiserID")
            _oldTicket = .Item("OldTicket")
            _orNum = .Item("ORNum")
            _orDate = .Item("ORDate")
            _lessPrincipal = .Item("LessPrincipal")
            _daysOverDue = .Item("DaysOverDue")
            _delayInt = .Item("DelayInt")
            _penalty = .Item("Penalty")
            _serviceCharge = .Item("ServiceCharge")
            _renewDue = .Item("RenewDue")
            _redeemDue = .Item("RedeemDue")
            _status = .Item("Status")
        End With
    End Sub

    Public Sub LoadTicketInRow(ByVal dr As DataRow)
        With dr
            _pawnid = .Item("PawnID")
            _pawnTicket = .Item("PawnTicket")
            Dim tmpClient As New Client
            tmpClient.LoadClient(.Item("ClientID"))
            _client = tmpClient
            _loanDate = .Item("LoanDate")
            _matuDate = .Item("MatuDate")
            _expiryDate = .Item("ExpiryDate")
            _auctionDate = .Item("AuctionDate")
            _itemType = .Item("ItemType")
            _catID = .Item("CatID")
            _description = .Item("Description")
            _karat = .Item("Karat")
            _grams = .Item("Grams")
            _appraisal = .Item("Appraisal")
            _principal = .Item("Principal")
            _interest = .Item("Interest")
            _netAmount = .Item("NetAmount")
            _evat = .Item("Evat")
            _appraiserID = .Item("AppraiserID")
            _oldTicket = .Item("OldTicket")
            _orNum = .Item("ORNum")
            _orDate = .Item("ORDate")
            _lessPrincipal = .Item("LessPrincipal")
            _daysOverDue = .Item("DaysOverDue")
            _delayInt = .Item("DelayInt")
            _penalty = .Item("Penalty")
            _serviceCharge = .Item("ServiceCharge")
            _renewDue = .Item("RenewDue")
            _redeemDue = .Item("RedeemDue")
            _status = .Item("Status")
        End With
    End Sub

    Public Sub CancelTicket()
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblPawn WHERE PawnTicket = " & _oldTicket
        ds = LoadSQL(mySql, "tblPawn")

        Me.LoadTicket(ds.Tables(0).Rows(0).Item("PawnID"))

        If _oldTicket <> Nothing Then
            _status = "R"
        Else
            _status = "L"
        End If

        ds.Tables(0).Rows(0).Item("status") = _status
        database.SaveEntry(ds)
    End Sub

    Public Sub RedeemTicket()
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM " & fillData & " WHERE PawnID = " & _pawnid
        ds = LoadSQL(mySql, fillData)
        Me.LoadTicket(ds.Tables(0).Rows(0).Item("PawnID"))


    End Sub
#End Region
End Class
