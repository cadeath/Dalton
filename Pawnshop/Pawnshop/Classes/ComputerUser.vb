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
    Private _pawn As Boolean, _clientList As Boolean, _moneyTransfer As Boolean
    Private _insurance As Boolean, _layAway As Boolean, _dollarBuying As Boolean
    Private _pos As Boolean, _cio As Boolean

    'Supervisor
    Private _expiryList As Boolean, _journalEntries As Boolean, _cashCount As Boolean, _backUp As Boolean
    Private _viewUserManagement As Boolean, _viewRates As Boolean, _openStore As Boolean

    'Manager
    Private _userManagement As Boolean, _updateRates As Boolean, _settings As Boolean, _borrow As Boolean

    'Special
    Private _cashInBank As Boolean, _cashOutBank As Boolean, _void As Boolean
    Public Sub UpdatePrivilege()
        Dim parts() As String = _privilege.Split("|")
        Dim privList() As Boolean = {_pawn, _clientList, _moneyTransfer, _insurance, _layAway, _dollarBuying, _pos, _cio}
        Dim x As Integer, y As Integer
        'Encoder
        y = 0
        Console.WriteLine("Encoder : " & privList.Count & "| " & parts(y))
        For x = 0 To parts(y).Length - 1
            privList(x) = IIf(parts(y).Substring(x, 1) = "1", True, False)
            If privList(x) = "1" Then _level = "Encoder"
        Next

        'Supervisor
        y = 1
        privList = {_expiryList, _journalEntries, _cashCount, _backUp, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewUserManagement, _viewRates, _openStore}
        Console.WriteLine("Supervisor : " & privList.Count & "| " & parts(y))
        For x = 0 To parts(y).Length - 1
            privList(x) = IIf(parts(y).Substring(x, 1) = "1", True, False)
            If privList(x) = "1" Then _level = "Supervisor"
        Next

        'Manager
        y = 2
        privList = {_userManagement, _updateRates, _settings, _borrow}
        Console.WriteLine("Manager : " & privList.Count & "| " & parts(y))
        For x = 0 To parts(y).Length - 1
            privList(x) = IIf(parts(y).Substring(x, 1) = "1", True, False)
            If privList(x) = "1" Then _level = "Manager"
        Next


        'Special
        y = 3
        privList = {_cashInBank, _cashOutBank, _void}
        Console.WriteLine("Special : " & privList.Count & "| " & parts(y))
        For x = 0 To parts(y).Length - 1
            privList(x) = IIf(parts(y).Substring(x, 1) = "1", True, False)
        Next

        Console.WriteLine("Level is " & _level)
    End Sub

    Private Sub getPrivilege()
        Dim superAdmin As String = "PDuNxp8S9q0="
        'mySql = "SELECT * FROM " & fillData & " WHERE UserID = " & _userID
        'Dim ds As DataSet = LoadSQL(mySql)

        '_privilege = ds.Tables(0).Rows(0).Item("Privilege")
        If _privilege = superAdmin Then
            _level = "Super User"
        Else
            UpdatePrivilege()
        End If
    End Sub
#End Region

#Region "Procedures and Functions"
    Public Sub CreateAdministrator(Optional ByVal pass As String = "misAdmin2015")
        mySql = "SELECT * FROM " & fillData
        Dim user As String, fullname As String, ds As DataSet
        user = "POSadmin" : fullname = "IT Department"

        mySql &= String.Format(" WHERE Username = '{0}' AND UserPass = '{1}'", user, EncryptString(pass))

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

    Public Sub LoadUserByRow(ByVal dr As DataRow)
        On Error Resume Next

        With dr
            _userID = .Item("UserID")
            _userName = .Item("UserName")
            _password = .Item("UserPass")
            _fullName = .Item("FullName")
            _privilege = .Item("Privilege")
            _lastLogin = .Item("LastLogin")
        End With

        getPrivilege()
    End Sub

    Public Sub SaveUser()
        mySql = "SELECT * FROM " & fillData
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("Username") = _userName
            .Item("UserPass") = Encrypt(_password)
            .Item("FullName") = _fullName
            .Item("Privilege") = _privilege
            .Item("LastLogin") = _lastLogin
            .Item("EncoderID") = _encoderID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)
        database.SaveEntry(ds)

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
        mySql = "SELECT * FROM " & fillData
        mySql &= vbCrLf & String.Format("WHERE LOWER(Username) = LOWER('{0}') AND UserPass = '{1}'", user, Encrypt(password))
        Dim ds As DataSet

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Return False

        LoadUser(ds.Tables(0).Rows(0).Item("UserID"))

        Return True
    End Function
#End Region
End Class
