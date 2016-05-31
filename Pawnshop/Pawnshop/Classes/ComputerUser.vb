Imports DeathCodez.Security

''' <summary>
''' NOTE: Privilege PDuNxp8S9q0= means SUPER USER
''' </summary>
''' <remarks>NOTE: Privilege PDuNxp8S9q0= means SUPER USER</remarks>
Public Class ComputerUser

    Private fillData As String = "tbl_Gamit"
    Private mySql As String = String.Empty

#Region "Properties"
    Private _userID As Integer
    Public Property UserID() As Integer
        Get
            Return _userID
        End Get
        Set(ByVal value As Integer)
            _userID = value
        End Set
    End Property

    Private _userName As String
    Public Property UserName() As String
        Get
            Return _userName
        End Get
        Set(ByVal value As String)
            _userName = value
        End Set
    End Property

    Private _password As String
    Public Property Password() As String
        Get
            Return _password
        End Get
        Set(ByVal value As String)
            _password = value
        End Set
    End Property

    Private _fullName As String
    Public Property FullName() As String
        Get
            Return _fullName
        End Get
        Set(ByVal value As String)
            _fullName = value
        End Set
    End Property

    Private _privilege As String
    Public Property Privilege() As String
        Get
            Return _privilege
        End Get
        Set(ByVal value As String)
            _privilege = value
        End Set
    End Property

    Private _lastLogin As Date
    Public Property LastLogin() As Date
        Get
            Return _lastLogin
        End Get
        Set(ByVal value As Date)
            _lastLogin = value
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

#End Region

#Region "Privileges"

    Private _level As String = String.Empty
    Public ReadOnly Property Level As String
        Get
            If _level = Nothing Then
                UpdatePrivilege()
            End If

            Return _level
        End Get
    End Property

    'Encoder
    Private _pawn As Boolean
    Public ReadOnly Property canPawn() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _pawn
        End Get
    End Property

    Private _clientList As Boolean
    Public ReadOnly Property canClientManage() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _clientList
        End Get
    End Property

    Private _moneyTransfer As Boolean
    Public ReadOnly Property canMoneyTransfer() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _moneyTransfer
        End Get
    End Property

    Private _insurance As Boolean
    Public ReadOnly Property canInsurance() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _insurance
        End Get
    End Property

    Private _layAway As Boolean
    Public ReadOnly Property canLayAway() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _layAway
        End Get
    End Property

    Private _dollarBuying As Boolean
    Public ReadOnly Property canDollarBuying() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _dollarBuying
        End Get
    End Property

    Private _pos As Boolean
    Public ReadOnly Property canPOS() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _pos
        End Get
    End Property

    Private _cio As Boolean
    Public ReadOnly Property canCashInOut() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _cio
        End Get
    End Property
    Private _appraiser As Boolean
    Public ReadOnly Property canAppraise() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _appraiser
        End Get
    End Property

    'Supervisor
    Private _expiryList As Boolean
    Public ReadOnly Property canExpiryListGenerate() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _expiryList
        End Get
    End Property

    Private _journalEntries As Boolean
    Public ReadOnly Property canJournalEntryGenerate() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _journalEntries
        End Get
    End Property

    Private _cashCount As Boolean
    Public ReadOnly Property canCashCount() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _cashCount
        End Get
    End Property

    Private _backUp As Boolean
    Public ReadOnly Property canBackup() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _backUp
        End Get
    End Property

    Private _viewUserManagement As Boolean
    Public ReadOnly Property canViewUserManage() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _viewUserManagement
        End Get
    End Property

    Private _viewRates As Boolean
    Public ReadOnly Property canViewRates() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _viewRates
        End Get
    End Property

    Private _openStore As Boolean
    Public ReadOnly Property canOpenStore() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _openStore
        End Get
    End Property

    'Manager
    Private _userManagement As Boolean
    Public ReadOnly Property canUserManage() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _userManagement
        End Get
    End Property

    Private _updateRates As Boolean
    Public ReadOnly Property canUpdateRates() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _updateRates
        End Get
    End Property

    Private _settings As Boolean
    Public ReadOnly Property canSettings() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _settings
        End Get
    End Property

    Private _borrow As Boolean
    Public ReadOnly Property canBorrow() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _borrow
        End Get
    End Property

    'Special
    Private _cashInBank As Boolean
    Public ReadOnly Property canCashInBank() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _cashInBank
        End Get
    End Property

    Private _cashOutBank As Boolean
    Public ReadOnly Property canCashOutBank() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _cashOutBank
        End Get
    End Property

    Private _void As Boolean
    Public ReadOnly Property canVoid() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _void
        End Get
    End Property

    Private _pullOut As Boolean
    Public ReadOnly Property canPullOut() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _pullOut
        End Get
    End Property

    Private _migrate As Boolean
    Public ReadOnly Property canMigrate() As Boolean
        Get
            If isSuperUser Then Return isSuperUser
            Return _migrate
        End Get
    End Property

    'Super User
    Private _superUser As Boolean
    Public ReadOnly Property isSuperUser() As Boolean
        Get
            Return _superUser
        End Get
    End Property

    Public Sub UpdatePrivilege()
        Dim parts() As String = _privilege.Split("|")
        Dim y As Integer
        'Encoder
        y = 0
        Dim privList() = {_pawn, _clientList, _moneyTransfer, _insurance, _layAway, _dollarBuying, _pos, _cio}
        _pawn = IIf(parts(y).Substring(0, 1) = "1", True, False)
        _clientList = IIf(parts(y).Substring(1, 1) = "1", True, False)
        _moneyTransfer = IIf(parts(y).Substring(2, 1) = "1", True, False)
        _insurance = IIf(parts(y).Substring(3, 1) = "1", True, False)
        _layAway = IIf(parts(y).Substring(4, 1) = "1", True, False)
        _dollarBuying = IIf(parts(y).Substring(5, 1) = "1", True, False)
        _pos = IIf(parts(y).Substring(6, 1) = "1", True, False)
        _cio = IIf(parts(y).Substring(7, 1) = "1", True, False)
        For Each var As Boolean In privList
            If var Then _level = "Encoder"
        Next

        'Supervisor
        y = 1
        _expiryList = IIf(parts(y).Substring(0, 1) = "1", True, False)
        _journalEntries = IIf(parts(y).Substring(1, 1) = "1", True, False)
        _cashCount = IIf(parts(y).Substring(2, 1) = "1", True, False)
        _backUp = IIf(parts(y).Substring(3, 1) = "1", True, False)
        _viewUserManagement = IIf(parts(y).Substring(8, 1) = "1", True, False)
        _viewRates = IIf(parts(y).Substring(9, 1) = "1", True, False)
        _openStore = IIf(parts(y).Substring(10, 1) = "1", True, False)

        privList = {_expiryList, _journalEntries, _cashCount, _backUp, _viewUserManagement, _
                    _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewRates, _openStore}
        For Each var As Boolean In privList
            If var Then _level = "Supervisor"
        Next

        'Manager
        y = 2
        _userManagement = IIf(parts(y).Substring(0, 1) = "1", True, False)
        _updateRates = IIf(parts(y).Substring(1, 1) = "1", True, False)
        _settings = IIf(parts(y).Substring(2, 1) = "1", True, False)
        _borrow = IIf(parts(y).Substring(3, 1) = "1", True, False)
        privList = {_userManagement, _updateRates, _settings, _borrow}
        For Each var As Boolean In privList
            If var Then _level = "Manager"
        Next

        'Special
        y = 3
        Console.WriteLine(parts(y))
        _cashInBank = IIf(parts(y).Substring(0, 1) = "1", True, False)
        _cashOutBank = IIf(parts(y).Substring(1, 1) = "1", True, False)
        _void = IIf(parts(y).Substring(2, 1) = "1", True, False)
        _pullOut = IIf(parts(y).Substring(3, 1) = "1", True, False)
        _migrate = IIf(parts(y).Substring(4, 1) = "1", True, False)
        privList = {_cashInBank, _cashOutBank, _void, _pullOut, _migrate}

        Console.WriteLine("Level is " & _level)
    End Sub

    Private Sub getPrivilege()
        Dim superAdmin As String = "PDuNxp8S9q0="
        If _privilege = superAdmin Then
            _level = "Super User"
            _superUser = True

            Dim TabCnt As Integer = 4
            Dim privList() As Boolean = {}

            For cnt As Integer = 0 To TabCnt - 1
                Select Case cnt
                    Case 0 : privList = {_pawn, _clientList, _moneyTransfer, _insurance, _layAway, _dollarBuying, _pos, _cio}
                    Case 1 : privList = {_expiryList, _journalEntries, _cashCount, _backUp, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewRates, _openStore}
                    Case 2 : privList = {_userManagement, _updateRates, _settings, _borrow}
                    Case 3 : privList = {_cashInBank, _cashOutBank, _void, _pullOut, _migrate}
                End Select

                For Each e In privList
                    e = True
                Next
            Next
        Else
            PriviledgeChecking()
            UpdatePrivilege()
        End If
    End Sub
#End Region

#Region "Procedures and Functions"
    Public Sub CreateAdministrator(Optional ByVal pass As String = "misAdmin2016")
        mySql = "SELECT * FROM " & fillData
        Dim user As String, fullname As String, ds As DataSet
        user = "POSadmin" : fullname = "IT Department"

        mySql &= String.Format(" WHERE Username = '{0}'", user, EncryptString(pass))

        Console.WriteLine("Create SQL: " & mySql)

        ds = LoadSQL(mySql, fillData)
        If ds.Tables(fillData).Rows.Count > 0 Then Exit Sub

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("Username") = user
            .Item("UserPass") = Encrypt(pass)
            .Item("Fullname") = fullname
            .Item("privilege") = "PDuNxp8S9q0="
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds, True)
    End Sub

    ''' <summary>
    ''' For Adding Priviledge
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub PriviledgeChecking()
        Dim privList() As Boolean = {}
        Dim privChunk As String = _privilege
        Dim finalChunk As String = ""
        Dim y As Integer = 0

        For cnt As Integer = 0 To 3
            Select Case cnt
                Case 0
                    privList = {_pawn, _clientList, _moneyTransfer, _insurance, _layAway, _dollarBuying, _pos, _cio}
                    finalChunk &= privChunk.Split("|")(cnt)
                    For y = privChunk.Split("|")(cnt).Length To privList.Length - 1
                        finalChunk &= "0"
                    Next
                    finalChunk &= "|"
                Case 1 : privList = {_expiryList, _journalEntries, _cashCount, _backUp, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewRates, _openStore}
                    finalChunk &= privChunk.Split("|")(cnt)
                    For y = privChunk.Split("|")(cnt).Length To privList.Length - 1
                        finalChunk &= "0"
                    Next
                    finalChunk &= "|"
                Case 2 : privList = {_userManagement, _updateRates, _settings, _borrow}
                    finalChunk &= privChunk.Split("|")(cnt)
                    For y = privChunk.Split("|")(cnt).Length To privList.Length - 1
                        finalChunk &= "0"
                    Next
                    finalChunk &= "|"
                Case 3 : privList = {_cashInBank, _cashOutBank, _void, _pullOut, _migrate}
                    finalChunk &= privChunk.Split("|")(cnt)
                    For y = privChunk.Split("|")(cnt).Length To privList.Length - 1
                        finalChunk &= "0"
                    Next
            End Select
        Next
        _privilege = finalChunk
    End Sub

    Public Sub LoadUserByRow(ByVal dr As DataRow)
        'On Error Resume Next

        With dr
            _userID = .Item("UserID")
            _userName = .Item("UserName")
            _password = .Item("UserPass")
            _fullName = .Item("FullName")
            _privilege = .Item("Privilege")
            If Not IsDBNull(.Item("LastLogin")) Then _lastLogin = .Item("LastLogin")
        End With

        getPrivilege()
    End Sub

    Public Sub SaveUser(Optional ByVal isNew As Boolean = True)
        mySql = "SELECT * FROM " & fillData
        If Not isNew Then mySql &= " WHERE UserID = " & _userID

        Dim ds As DataSet = LoadSQL(mySql, fillData)
        If isNew Then
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("Username") = _userName
                .Item("UserPass") = Encrypt(_password)
                .Item("FullName") = _fullName
                .Item("Privilege") = _privilege
                '.Item("LastLogin") = _lastLogin 'First Login no Last Login
                .Item("EncoderID") = _encoderID
                .Item("SystemInfo") = Now.Date
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
        Else
            With ds.Tables(0).Rows(0)
                .Item("Username") = _userName
                .Item("UserPass") = Encrypt(_password)
                .Item("FullName") = _fullName
                .Item("Privilege") = _privilege
            End With
        End If

        database.SaveEntry(ds, isNew)
        Console.WriteLine(_userName & " saved.")
    End Sub

    Public Sub LoadUser(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE UserID = " & id
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        LoadUserByRow(ds.Tables(0).Rows(0))
        Console.WriteLine(String.Format("[ComputerUser] UserID {0} - {1} Loaded", _userID, _userName))
    End Sub

    Public Function LoginUser(ByVal user As String, ByVal password As String) As Boolean
        mySql = "SELECT UserID, LOWER(Username) FROM " & fillData
        mySql &= vbCrLf & String.Format(" WHERE LOWER(Username) = LOWER('{0}') AND UserPass = '{1}'", user, Encrypt(password))
        Dim ds As DataSet

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        LoadUser(ds.Tables(0).Rows(0).Item("UserID"))

        Return True
    End Function

    Public Sub UpdateLogin()
        mySql = "SELECT * FROM " & fillData & " WHERE UserID = " & _userID
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(0).Rows(0).Item("LastLogin") = Now
        database.SaveEntry(ds, False)
        Console.WriteLine("Login Saved")
    End Sub
#End Region
End Class
