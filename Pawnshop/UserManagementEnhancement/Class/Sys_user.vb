Imports DeathCodez.Security

''' <summary>
''' NOTE: Privilege PDuNxp8S9q0= means SUPER USER
''' </summary>
''' <remarks>NOTE: Privilege PDuNxp8S9q0= means SUPER USER</remarks>
Public Class Sys_user

    Private maintable As String = "tbl_users"
    Private subTable As String = "tbluser_history"
    Private mySql As String = String.Empty

#Region "Properties"
    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _USERNAME As String
    Public Property USERNAME() As String
        Get
            Return _USERNAME
        End Get
        Set(ByVal value As String)
            _USERNAME = value
        End Set
    End Property

    Private _FIRSTNAME As String
    Public Property FIRSTNAME() As String
        Get
            Return _FIRSTNAME
        End Get
        Set(ByVal value As String)
            _FIRSTNAME = value
        End Set
    End Property

    Private _MIDDLENAME As String
    Public Property MIDDLENAME() As String
        Get
            Return _MIDDLENAME
        End Get
        Set(ByVal value As String)
            _MIDDLENAME = value
        End Set
    End Property

    Private _LASTNAME As String
    Public Property LASTNAME() As String
        Get
            Return _LASTNAME
        End Get
        Set(ByVal value As String)
            _LASTNAME = value
        End Set
    End Property

    Private _USERPASS As String
    Public Property USERPASS() As String
        Get
            Return _USERPASS
        End Get
        Set(ByVal value As String)
            _USERPASS = value
        End Set
    End Property

    Private _EMAIL_ADDRESS As String
    Public Property EMAIL_ADDRESS() As String
        Get
            Return _EMAIL_ADDRESS
        End Get
        Set(ByVal value As String)
            _EMAIL_ADDRESS = value
        End Set
    End Property

    Private _CONTACTNO As Integer
    Public Property CONTACTNO() As Integer
        Get
            Return _CONTACTNO
        End Get
        Set(ByVal value As Integer)
            _CONTACTNO = value
        End Set
    End Property


    Private _BIRTHDAY As Date
    Public Property BIRTHDAY() As Date
        Get
            Return _BIRTHDAY
        End Get
        Set(ByVal value As Date)
            _BIRTHDAY = value
        End Set
    End Property

    Private _GENDER As String
    Public Property GENDER() As String
        Get
            Return _GENDER
        End Get
        Set(ByVal value As String)
            _GENDER = value
        End Set
    End Property

    Private _AGE As Integer
    Public Property AGE() As Integer
        Get
            Return _AGE
        End Get
        Set(ByVal value As Integer)
            _AGE = value
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

    Private _UserStatus As Integer
    Public Property UserStatus() As Integer
        Get
            Return _UserStatus
        End Get
        Set(ByVal value As Integer)
            _UserStatus = value
        End Set
    End Property

    Private _EXPIRYDATE As Date
    Public Property EXPIRYDATE() As Date
        Get
            Return _EXPIRYDATE
        End Get
        Set(ByVal value As Date)
            _EXPIRYDATE = value
        End Set
    End Property

  

    '""""""""""""""""""""""""""""""''''''''''''''''''Subtable''''''''""""""""""""""""

    Private _USER_HISTORYID As Integer
    Public Property USER_HISTORYID() As Integer
        Get
            Return _USER_HISTORYID
        End Get
        Set(ByVal value As Integer)
            _USER_HISTORYID = value
        End Set
    End Property



#End Region




#Region "Procedures and Functions"

    Friend Function add_USER() As Boolean
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE PRIVILEGE_TYPE = '{0}'", _USERPASS)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(maintable).Rows.Count > 0 Then
            MsgBox("The password you enter is already taken.", MsgBoxStyle.Exclamation, "Warning")
            Return False
        End If

        Dim dsnewRow As DataRow
        dsnewRow = ds.Tables(maintable).NewRow
        With dsnewRow
            .Item("USERNAME") = _USERNAME
            .Item("FIRSTNAME") = _FIRSTNAME
            .Item("MIDDLENAME") = _MIDDLENAME
            .Item("LASTNAME") = _LASTNAME
            .Item("USERPASS") = EncryptString(_USERPASS)
            .Item("EMAIL_ADDRESS") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
            .Item("PRIVILEGE") = _privilege
            .Item("LASTLOGIN") = _AGE
            .Item("ENCODERID") = _encoderID
            .Item("EXPIRYDATE") = _EXPIRYDATE
            .Item("SYSTEMINFO") = Now
            .Item("STATUS") = _UserStatus
        End With
        ds.Tables(maintable).Rows.Add(dsnewRow)
        database.SaveEntry(ds)

        mySql = "SELECT * FROM " & subTable
        Dim ds1 As DataSet = LoadSQL(mySql, subTable)

        Dim dr As DataRow
        dr = ds.Tables(subTable).NewRow
        With dr

        End With

        Return True
    End Function

#End Region
End Class
