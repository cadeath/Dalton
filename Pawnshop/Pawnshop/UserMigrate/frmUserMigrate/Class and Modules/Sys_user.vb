Public Class Sys_user

    Private maintable As String = "tbl_user_default"
    Private subTable As String = "tbluser_history"
    Private MAIN_LINE As String = "TBL_USERLINE"
    Private mySql As String = String.Empty
    Dim Passwd_update As Boolean = True

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

    Private _CONTACTNO As String
    Public Property CONTACTNO() As String
        Get
            Return _CONTACTNO
        End Get
        Set(ByVal value As String)
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

    Private _COUNTER As Integer
    Public Property COUNTER() As Integer
        Get
            Return _COUNTER
        End Get
        Set(ByVal value As Integer)
            _COUNTER = value
        End Set
    End Property

    Private _FAILEDATTEMPNUM As Integer
    Public Property FAILEDATTEMPNUM() As Integer
        Get
            Return _FAILEDATTEMPNUM
        End Get
        Set(ByVal value As Integer)
            _FAILEDATTEMPNUM = value
        End Set
    End Property

    Private _FAILEDATTEMPSTAT As String
    Public Property FAILEDATTEMPSTAT() As String
        Get
            Return _FAILEDATTEMPSTAT
        End Get
        Set(ByVal value As String)
            _FAILEDATTEMPSTAT = value
        End Set
    End Property

    Private _systeminfo As Date
    Public Property systeminfo() As Date
        Get
            Return _systeminfo
        End Get
        Set(ByVal value As Date)
            _systeminfo = value
        End Set
    End Property

    Private _PASSWORD_AGE As Date
    Public Property PASSWORD_AGE() As Date
        Get
            Return _PASSWORD_AGE
        End Get
        Set(ByVal value As Date)
            _PASSWORD_AGE = value
        End Set
    End Property

    Private _ISEXPIRED As Integer
    Public Property ISEXPIRED() As Integer
        Get
            Return _ISEXPIRED
        End Get
        Set(ByVal value As Integer)
            _ISEXPIRED = value
        End Set
    End Property

    Private _PASSWORD_EXPIRY As Date
    Public Property PASSWORD_EXPIRY() As Date
        Get
            Return _PASSWORD_EXPIRY
        End Get
        Set(ByVal value As Date)
            _PASSWORD_EXPIRY = value
        End Set
    End Property

    Private _USERTYPE As String
    Public Property USERTYPE() As String
        Get
            Return _USERTYPE
        End Get
        Set(ByVal value As String)
            _USERTYPE = value
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

    Private _DATE_CREATED As Date
    Public Property DATE_CREATED() As Date
        Get
            Return _DATE_CREATED
        End Get
        Set(ByVal value As Date)
            _DATE_CREATED = value
        End Set
    End Property
    '""""""""""""""""""""""""""""""""""""""""""""""""""""""""""user line"""""""""""""""""""'''''

    Private _USERLINE_ID As Integer
    Public Property USERLINE_ID() As Integer
        Get
            Return _USERLINE_ID
        End Get
        Set(ByVal value As Integer)
            _USERLINE_ID = value
        End Set
    End Property

    Private _USERID As Integer
    Public Property USERID() As Integer
        Get
            Return _USERID
        End Get
        Set(ByVal value As Integer)
            _USERID = value
        End Set
    End Property

    Private _PRIVILEGE_TYPE As String
    Public Property PRIVILEGE_TYPE() As String
        Get
            Return _PRIVILEGE_TYPE
        End Get
        Set(ByVal value As String)
            _PRIVILEGE_TYPE = value
        End Set
    End Property

    Private _ACCESSTYPE As String
    Public Property ACCESSTYPE() As String
        Get
            Return _ACCESSTYPE
        End Get
        Set(ByVal value As String)
            _ACCESSTYPE = value
        End Set
    End Property


    Private _DATE_CREATED_LINE As Date
    Public Property DATE_CREATED_LINE() As Date
        Get
            Return _DATE_CREATED_LINE
        End Get
        Set(ByVal value As Date)
            _DATE_CREATED_LINE = value
        End Set
    End Property

    Private _DATE_UPDATED_LINE As Date
    Public Property DATE_UPDATED_LINE() As Date
        Get
            Return _DATE_UPDATED_LINE
        End Get
        Set(ByVal value As Date)
            _DATE_UPDATED_LINE = value
        End Set
    End Property
#End Region

#Region "Procedures and Functions"
    Public Sub CreateAdministrator(Optional ByVal pass As String = "misAdmin2016")
        mySql = "SELECT * FROM " & maintable
        Dim user As String, Fname As String, Lname As String, ds As DataSet
        user = "POSadmin" : Fname = "IT" : Lname = " Department"

        mySql &= String.Format(" WHERE Username = '{0}'", user, EncryptString(pass))

        Console.WriteLine("Create SQL: " & mySql)

        ds = LoadSQL(mySql, maintable)
        If ds.Tables(maintable).Rows.Count > 0 Then Exit Sub

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(maintable).NewRow
        With dsNewRow
            .Item("USERNAME") = user
            .Item("FIRSTNAME") = Fname
            .Item("LASTNAME") = Lname
            .Item("USERPASS") = EncryptString(pass)
            .Item("GENDER") = "N/A"
            .Item("PASSWORD_AGE") = "01/01/0001"
            .Item("SYSTEMINFO") = Now

            .Item("PASSWORD_EXPIRY") = "01/01/0001"
            .Item("ISEXPIRED") = 0
            .Item("EXPIRY_COUNTER") = 0
            .Item("FAILEDATTEMPNUM") = 0
            .Item("FAILEDATTEMPSTAT") = "Enable"
            .Item("USERTYPE") = "Admin"
            .Item("STATUS") = 1
        End With
        ds.Tables(maintable).Rows.Add(dsNewRow)
        database.SaveEntry(ds, True)
    End Sub

    Friend Function add_USER() As Boolean
        mySql = "SELECT * FROM " & maintable
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        Dim dsnewRow As DataRow
        dsnewRow = ds.Tables(maintable).NewRow
        With dsnewRow
            .Item("USERID") = _ID
            .Item("USERNAME") = _USERNAME
            .Item("FIRSTNAME") = _FIRSTNAME
            .Item("MIDDLENAME") = _MIDDLENAME
            .Item("LASTNAME") = _LASTNAME
            .Item("USERPASS") = _USERPASS
            .Item("EMAIL_ADDRESS") = _EMAIL_ADDRESS
            .Item("CONTACTNO") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
            .Item("ENCODERID") = _encoderID
            .Item("LASTLOGIN") = Now


            .Item("PASSWORD_AGE") = _PASSWORD_AGE
            '"01/01/0001"

            .Item("SYSTEMINFO") = Now
            .Item("PASSWORD_EXPIRY") = _PASSWORD_EXPIRY
            .Item("ISEXPIRED") = _ISEXPIRED
            .Item("EXPIRY_COUNTER") = _COUNTER
            .Item("FAILEDATTEMPNUM") = _FAILEDATTEMPNUM
            .Item("FAILEDATTEMPSTAT") = _FAILEDATTEMPSTAT
            .Item("USERTYPE") = _USERTYPE
            .Item("STATUS") = _UserStatus
        End With
        ds.Tables(maintable).Rows.Add(dsnewRow)
        database.SaveEntry(ds)

        mySql = "SELECT * FROM " & maintable & " ORDER BY USERID DESC ROWS 1"
        Dim ds1 As DataSet = LoadSQL(mySql, maintable)
        _ID = ds1.Tables(0).Rows(0).Item("USERID")
        _USERPASS = ds1.Tables(0).Rows(0).Item("USERPASS")

        mySql = "SELECT * FROM " & subTable
        Dim ds2 As DataSet = LoadSQL(mySql, subTable)
        Dim dr As DataRow
        dr = ds2.Tables(subTable).NewRow
        With dr
            .Item("USERID") = _ID
            .Item("USERPASS") = _USERPASS
        End With
        ds2.Tables(subTable).Rows.Add(dr)
        database.SaveEntry(ds2)

        Return True
    End Function

    Friend Sub Users(ByVal id As Integer)
        Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT WHERE USERID = '" & id & "'"
        Dim ds As DataSet = LoadSQL(mysql, maintable)

        Load_user_All_Rows(ds.Tables(maintable).Rows(0))
    End Sub

    Friend Sub Load_user_All_Rows(ByVal dR As DataRow)
        On Error Resume Next

        With dR
            _ID = .Item("USERID")
            _USERNAME = .Item("USERNAME")
            _FIRSTNAME = .Item("FIRSTNAME")
            _MIDDLENAME = IIf(IsDBNull(.Item("MIDDLENAME")), "", .Item("MIDDLENAME"))
            _LASTNAME = .Item("LASTNAME")
            _USERPASS = .Item("USERPASS")
            _EMAIL_ADDRESS = .Item("EMAIL_ADDRESS")
            _CONTACTNO = .Item("CONTACTNO")
            _BIRTHDAY = .Item("BIRTHDAY")
            _GENDER = .Item("GENDER")
            _AGE = .Item("AGE")
            _encoderID = .Item("ENCODERID")
            _lastLogin = IIf(IsDBNull(.Item("LASTLOGIN")), "", .Item("LASTLOGIN"))
            _PASSWORD_AGE = .Item("PASSWORD_AGE")
            _systeminfo = .Item("SYSTEMINFO")
            _PASSWORD_EXPIRY = .Item("PASSWORD_EXPIRY")
            _ISEXPIRED = .Item("ISEXPIRED")
            _COUNTER = .Item("EXPIRY_COUNTER")
            _FAILEDATTEMPNUM = .Item("FAILEDATTEMPNUM")
            _FAILEDATTEMPSTAT = .Item("FAILEDATTEMPSTAT")
            _USERTYPE = .Item("USERTYPE")
            _UserStatus = .Item("STATUS")
        End With
    End Sub

    Friend Sub Save_Privilege(ByVal u_idx As Integer, Optional ByVal ISuPDATE As Boolean = True)

        If ISuPDATE Then
            mySql = "SELECT * FROM " & MAIN_LINE & " Where USERLINE_ID =" & u_idx & "ORDER BY USERLINE_ID ASC"
            Dim dsupDATE As DataSet = LoadSQL(mySql, MAIN_LINE)

            With dsupDATE.Tables(0).Rows(0)
                .Item("ACCESS_TYPE") = _ACCESSTYPE
            End With
            database.SaveEntry(dsupDATE, False)
            Exit Sub
        End If

        mySql = "SELECT * FROM " & MAIN_LINE
        Dim ds As DataSet = LoadSQL(mySql, MAIN_LINE)
        Dim dsnewrow As DataRow
        dsnewrow = ds.Tables(MAIN_LINE).NewRow
        With dsnewrow
            .Item("USERID") = _USERID
            .Item("PRIVILEGE_TYPE") = _PRIVILEGE_TYPE
            .Item("ACCESS_TYPE") = _ACCESSTYPE
            .Item("DATE_CREATED_LINE") = Now.ToShortDateString
            .Item("DATE_UPDATED_LINE") = Now.ToShortDateString
        End With
        ds.Tables(MAIN_LINE).Rows.Add(dsnewrow)
        database.SaveEntry(ds, True)
    End Sub
#End Region
End Class
