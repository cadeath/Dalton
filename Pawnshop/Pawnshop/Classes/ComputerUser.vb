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

#End Region

#Region "Privileges"

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

    Private Sub loadbyRow(ByVal dr As DataRow)
        On Error Resume Next

        With dr
            _userID = .Item("UserID")
            _userName = .Item("UserName")
            _password = .Item("UserPass")
            _fullName = .Item("FullName")
            _privilege = .Item("Privilege")
            _lastLogin = .Item("LastLogin")
        End With
    End Sub

    Public Sub LoadUser(ByVal id As Integer)
        mySql = "SELECT * FROM " & fillData & " WHERE UserID = " & id
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        loadbyRow(ds.Tables(0).Rows(0))
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
