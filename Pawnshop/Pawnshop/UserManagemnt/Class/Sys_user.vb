Imports DeathCodez.Security


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
    Public Sub CreateSuperAdministrator(Optional ByVal pass As String = "misAdmin2016")
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

    ''' <summary>
    ''' This function will save the user's information in the database.
    ''' </summary>
    ''' <param name="ISACCT_EXPIRE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function add_USER(Optional ByVal ISACCT_EXPIRE As Boolean = True) As Boolean
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERPASS = '{0}'", Encrypt(_USERPASS))
        Dim ds As DataSet = LoadSQL(mySql, maintable)


        If ds.Tables(maintable).Rows.Count > 0 Then
            MsgBox("The password you enter is already taken.", MsgBoxStyle.Exclamation, "Warning")
            Return False
        End If

        If Not Check_USERNAME_IfExists(_USERNAME, "SAVE") Then
            MsgBox("The username you've entered is already taken." & vbCrLf & _
                   "Please try again.", MsgBoxStyle.Critical, "Validate") : Return False
        End If



        Dim dsnewRow As DataRow
        dsnewRow = ds.Tables(maintable).NewRow
        With dsnewRow
            .Item("USERNAME") = _USERNAME
            .Item("FIRSTNAME") = _FIRSTNAME
            .Item("MIDDLENAME") = _MIDDLENAME
            .Item("LASTNAME") = _LASTNAME
            .Item("USERPASS") = Encrypt(_USERPASS)
            .Item("EMAIL_ADDRESS") = _EMAIL_ADDRESS
            .Item("CONTACTNO") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
            .Item("ENCODERID") = IIf(SystemUser.ID <> 0, SystemUser.ID, 0)
            .Item("LASTLOGIN") = Now

            If PASSWORD_AGE_COUNT = 0 Then
                .Item("PASSWORD_AGE") = "01/01/0001"
            Else
                .Item("PASSWORD_AGE") = Now.AddDays(PASSWORD_AGE_COUNT)
            End If

            .Item("SYSTEMINFO") = Now
            .Item("PASSWORD_EXPIRY") = IIf(ISACCT_EXPIRE, Now.AddDays(PASSWORD_EXPIRY_COUNT), "01/01/0001")
            .Item("ISEXPIRED") = _ISEXPIRED
            .Item("EXPIRY_COUNTER") = _COUNTER
            .Item("FAILEDATTEMPNUM") = _FAILEDATTEMPNUM
            .Item("FAILEDATTEMPSTAT") = _FAILEDATTEMPSTAT
            .Item("USERTYPE") = _USERTYPE
            .Item("STATUS") = 1
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

    ''' <summary>
    ''' This function will update the user's information in the database.
    ''' </summary>
    ''' <param name="ISACCT_EXPIRE"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Update_USER(Optional ByVal ISACCT_EXPIRE As Boolean = True) As Boolean
        Dim ISPASS_AGE_EXPIRE As Boolean = True

        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERID = '{0}'", _ID)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(maintable).Rows(0).Item("USERNAME") = USERNAME Then
            Console.WriteLine("cURRENT PASSWORD")
        End If

        If Not Check_USERNAME_IfExists(_USERNAME, , _ID) Then
            MsgBox("The username you've entered is already taken." & vbCrLf & _
                   "Please try again.", MsgBoxStyle.Critical, "Validate") : Return False
        End If

        If _USERPASS = "" Then
            Passwd_update = False : GoTo nextLINETODO
        Else
            If Not Check_Pass_IfExists(_ID, Encrypt(_USERPASS)) Then
                MsgBox("The password you've entered is already taken." & vbCrLf & _
                       "Please try again.", MsgBoxStyle.Critical, "Validate") : Return False
            End If
        End If


nextLINETODO:

        With ds.Tables(0).Rows(0)
            .Item("USERNAME") = _USERNAME
            .Item("FIRSTNAME") = _FIRSTNAME
            .Item("MIDDLENAME") = _MIDDLENAME
            .Item("LASTNAME") = _LASTNAME
            .Item("USERPASS") = IIf(Passwd_update, Encrypt(_USERPASS), tmpPassword)
            .Item("EMAIL_ADDRESS") = _EMAIL_ADDRESS
            .Item("CONTACTNO") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
            .Item("ENCODERID") = IIf(SystemUser.ID <> 0, SystemUser.ID, 0)
            .Item("LASTLOGIN") = Now

            If PASSWORD_AGE_COUNT = 0 Then
                .Item("PASSWORD_AGE") = "01/01/0001"
            Else
                .Item("PASSWORD_AGE") = Now.AddDays(PASSWORD_AGE_COUNT)
            End If

            ' .Item("SYSTEMINFO") = Now
            .Item("PASSWORD_EXPIRY") = IIf(ISACCT_EXPIRE, Now.AddDays(PASSWORD_EXPIRY_COUNT), "01/01/0001")
            .Item("ISEXPIRED") = ISEXPIRED
            .Item("EXPIRY_COUNTER") = _COUNTER
            .Item("FAILEDATTEMPNUM") = _FAILEDATTEMPNUM
            .Item("FAILEDATTEMPSTAT") = _FAILEDATTEMPSTAT
            .Item("STATUS") = _UserStatus
        End With
        database.SaveEntry(ds, False)

        mySql = String.Format("SELECT * FROM " & subTable & " WHERE USERPASS = '{0}'", Encrypt(_USERPASS))
        Dim ds1 As DataSet = LoadSQL(mySql, subTable)

        If ds1.Tables(0).Rows.Count > 0 Then
            With ds1.Tables(0).Rows(0)
                .Item("USERPASS") = Encrypt(_USERPASS)
                .Item("DATE_CREATED") = Now
            End With
            database.SaveEntry(ds1, False)

        Else
            Dim dr As DataRow
            dr = ds1.Tables(subTable).NewRow
            With dr
                .Item("USERID") = _ID
                .Item("USERPASS") = Encrypt(_USERPASS)
                .Item("DATE_CREATED") = Now
            End With
            ds1.Tables(subTable).Rows.Add(dr)
            database.SaveEntry(ds1)
        End If

        Return True
    End Function

    ''' <summary>
    ''' This function will update user's information after they login.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function UserProUpdate() As Boolean
       
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERID = '{0}'", UserIDX)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        With ds.Tables(0).Rows(0)
            .Item("FIRSTNAME") = _FIRSTNAME
            .Item("MIDDLENAME") = _MIDDLENAME
            .Item("LASTNAME") = _LASTNAME
            .Item("EMAIL_ADDRESS") = _EMAIL_ADDRESS
            .Item("CONTACTNO") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
        End With
        database.SaveEntry(ds, False)

        Return True
    End Function

    ''' <summary>
    ''' This function will check if password is already taken by other users.
    ''' </summary>
    ''' <param name="idx"></param>
    ''' <param name="passwd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Check_Pass_IfExists(ByVal idx As Integer, ByVal passwd As String) As Boolean

        mySql = "SELECT * FROM " & subTable & " WHERE USERID  = " & idx & " ORDER BY USER_HISTID"
        Dim ds As DataSet = LoadSQL(mySql, subTable)
        Dim u_pass As New List(Of String)()

        If ds.Tables(0).Rows.Count >= 5 Then
            For Each dr As DataRow In ds.Tables(0).Rows
                With dr
                    Console.WriteLine(.Item("USERPASS"))
                    u_pass.Add(.Item("USERPASS"))
                End With
            Next

            'selecting min and max string in the list
            Dim U_pass1 As New List(Of String)() 'Can Used
            Dim U_pass2 As New List(Of String)() 'Cannot used

            Dim count As Integer = 0
            For Each pass In u_pass
                count += 1
                If count = 1 Then
                    U_pass1.Add(pass)
                    Console.WriteLine(count & ":" & pass)
                ElseIf count = u_pass.Count Then
                    U_pass1.Add(pass)
                    Console.WriteLine(count & ":" & pass)
                Else
                    U_pass2.Add(pass)
                    Console.WriteLine(count & ":" & pass)
                End If
            Next
            'list of password Can used
            For Each pass1 In U_pass1
                If passwd = pass1 Then
                    Return True
                End If
            Next

            'list of password cannot used
            For Each pass2 In U_pass2
                If passwd = pass2 Then
                    Return False
                End If
            Next

            'Verifying password if already used by another user.
            For Each dr As DataRow In dsUSEr.Tables(0).Rows
                If passwd = dr.Item("USERPASS") Then
                    Return False
                End If
            Next
            Return True
        End If

        'Verifying password in his/her password if already exists.
        'Count password less than 5
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                If passwd = .Item("USERPASS") Then
                    Return False
                End If
            End With
        Next

        'Verifying password if already used by another user.
        For Each dr As DataRow In dsUSEr.Tables(0).Rows
            If passwd = dr.Item("USERPASS") Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' This function will check if username is already taken by other users.
    ''' </summary>
    ''' <param name="uNAME"></param>
    ''' <param name="isSave"></param>
    ''' <param name="idx"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Check_USERNAME_IfExists(ByVal uNAME As String, Optional ByVal isSave As String = "", Optional ByVal idx As Integer = 0) As Boolean
        Dim ds As DataSet

        If isSave = "SAVE" Then
            mySql = "SELECT * FROM " & maintable & " WHERE USERNAME = '" & uNAME & "'"
            ds = LoadSQL(mySql, maintable)
        Else
            mySql = "SELECT * FROM " & maintable & " WHERE USERID = '" & idx & "' AND USERNAME = '" & uNAME & "'"
            ds = LoadSQL(mySql, maintable)
        End If

        If isSave = "SAVE" Then
            If ds.Tables(0).Rows.Count > 0 Then
                Return False
            End If
        Else
            If ds.Tables(0).Rows.Count > 0 Then
                Return True
            End If

        End If


        For Each dr As DataRow In dsUSEr.Tables(0).Rows
            If uNAME = dr.Item("USERNAME") Then
                Return False
            End If
        Next
        Return True
    End Function

    ''' <summary>
    ''' This function will return all users from the database
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function dsUSEr() As DataSet
        Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USER_DEFAULT")
        Return ds
    End Function

    ''' <summary>
    ''' This function load user information base on ID
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Friend Sub Users(ByVal id As Integer)
        Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT WHERE USERID = '" & id & "'"
        Dim ds As DataSet = LoadSQL(mysql, maintable)

        Load_user_All_Rows(ds.Tables(maintable).Rows(0))
    End Sub

    ''' <summary>
    ''' This function will load user by row.
    ''' </summary>
    ''' <param name="dR"></param>
    ''' <remarks></remarks>
    Friend Sub Load_user_All_Rows(ByVal dR As DataRow)
        On Error Resume Next

        With dR
            _ID = .Item("USERID")
            _USERNAME = .Item("USERNAME")
            _FIRSTNAME = .Item("FIRSTNAME")
            _MIDDLENAME = IIf(IsDBNull(.Item("MIDDLENAME")), "", .Item("MIDDLENAME"))
            _LASTNAME = .Item("LASTNAME")
            _USERPASS = .Item("USERPASS")
            _EMAIL_ADDRESS = IIf(IsDBNull(.Item("EMAIL_ADDRESS")), "", .Item("EMAIL_ADDRESS"))
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

    ''' <summary>
    ''' This function will save the privilege of the user in each module either 'Full Access, No Access, Read only'
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub Save_Privilege()
        mySql = "SELECT * FROM " & MAIN_LINE
        Dim ds As DataSet = LoadSQL(mySql, MAIN_LINE)

        mySql = "SELECT * FROM " & maintable & " ORDER BY USERID DESC ROWS 1"
        Dim ds1 As DataSet = LoadSQL(mySql, maintable)
        _USERID = ds1.Tables(0).Rows(0).Item("USERID")

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

    ''' <summary>
    ''' This function will update the user's privileges
    ''' </summary>
    ''' <param name="ul_ID"></param>
    ''' <remarks></remarks>
    Friend Sub Update_Privilege(ByVal ul_ID As Integer)

        mySql = String.Format("SELECT * FROM " & MAIN_LINE & " WHERE USERLINE_ID = {0}", ul_ID)
        Dim ds As DataSet = LoadSQL(mySql, MAIN_LINE)

        If ds.Tables(0).Rows.Count = 0 Then
            Dim dsnewrow As DataRow
            dsnewrow = ds.Tables(MAIN_LINE).NewRow
            With dsnewrow
                .Item("USERID") = tmpIDx
                .Item("PRIVILEGE_TYPE") = _PRIVILEGE_TYPE
                .Item("ACCESS_TYPE") = _ACCESSTYPE
                .Item("DATE_CREATED_LINE") = Now.ToShortDateString
                .Item("DATE_UPDATED_LINE") = Now.ToShortDateString
            End With
            ds.Tables(MAIN_LINE).Rows.Add(dsnewrow)
            database.SaveEntry(ds, True)

        Else
            With ds.Tables(0).Rows(0)
                .Item("PRIVILEGE_TYPE") = _PRIVILEGE_TYPE
                .Item("ACCESS_TYPE") = _ACCESSTYPE
                .Item("DATE_UPDATED_LINE") = Now.ToShortDateString
            End With
            database.SaveEntry(ds, False)
        End If

    End Sub

    ''' <summary>
    ''' This function will load user privilege by ID
    ''' </summary>
    ''' <param name="IDX"></param>
    ''' <remarks></remarks>
    Friend Sub LOAD_USERLINE_ROWS(ByVal IDX As Integer)
        mySql = String.Format("SELECT * FROM " & MAIN_LINE & " WHERE USERID ={0}", IDX)
        Dim ds As DataSet = LoadSQL(mySql, MAIN_LINE)

        For Each dr As DataRow In ds.Tables(0).Rows
            Load_userLINE_BY_Rows(dr)
        Next
    End Sub

    ''' <summary>
    ''' This function load user privilege by row.
    ''' </summary>
    ''' <param name="dR"></param>
    ''' <remarks></remarks>
    Friend Sub Load_userLINE_BY_Rows(ByVal dR As DataRow)
        On Error Resume Next
        With dR
            _USERLINE_ID = .Item("USERLINE_ID")
            _USERID = .Item("USERID")
            _PRIVILEGE_TYPE = .Item("PRIVILEGE_TYPE")
            _ACCESSTYPE = .Item("ACCESS_TYPE")
            _DATE_UPDATED_LINE = .Item("DATE_CREATED_LINE")
            _DATE_CREATED_LINE = .Item("DATE_UPDATED_LINE")
        End With
        frmUserManagementNew.dgRulePrivilege.Rows.Add(_USERLINE_ID, _PRIVILEGE_TYPE, _ACCESSTYPE)
    End Sub

    Friend Sub LoadLastUser()
        mySql = "SELECT * FROM " & maintable & " ORDER BY USERID DESC ROWS 1"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        Load_user_All_Rows(ds.Tables(0).Rows(0))
    End Sub

    Friend Function GETUSERID() As Integer
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERPASS ='{0}'", tmpPassword)
        Dim ds As DataSet = LoadSQL(mySql, maintable)
        Return ds.Tables(0).Rows(0).Item("USERID")
    End Function
#End Region

#Region "Login functions"

    ''' <summary>
    ''' This function verify if username and password are corect
    ''' It will return true if account is correct
    ''' It will return false if account is not correct
    ''' </summary>
    ''' <param name="uName"></param>
    ''' <param name="pWrd"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function LogUser(ByVal uName As String, ByVal pWrd As String) As Boolean
        mySql = String.Format("SELECT USERID,USERNAME,USERPASS FROM " & maintable & " WHERE UPPER(USERNAME) =UPPER('{0}')" & _
                              "AND USERPASS = '{1}' AND STATUS = 1", uName, Encrypt(pWrd))
        Dim ds As DataSet = LoadSQL(mySql, maintable)
        Console.WriteLine(Encrypt(pWrd))
        If ds.Tables(0).Rows.Count = 0 Then Return False

        Users(ds.Tables(0).Rows(0).Item("USERID"))
        Return True
    End Function

    ''' <summary>
    ''' This Function will verify if username is already exists in the database.
    ''' </summary>
    ''' <param name="uName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Check_username(ByVal uName As String) As Boolean
        mySql = String.Format("SELECT USERID,USERNAME,USERPASS FROM " & maintable & " WHERE UPPER(USERNAME) =UPPER('{0}') AND STATUS ='0'", uName)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count > 0 Then
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' This function will check if the password reached the maximum days expiration.
    ''' </summary>
    ''' <param name="uNAME"></param>
    ''' <param name="u_PASS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function CheckPass_Age_Expiration(ByVal uNAME As String, ByVal u_PASS As String) As Boolean
        mySql = "SELECT * FROM " & maintable & " WHERE USERPASS = '" & Encrypt(u_PASS) & "'" & _
                "AND UPPER(USERNAME) = UPPER('" & uNAME & "')"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        End If

        With ds.Tables(0).Rows(0)

            If .Item("PASSWORD_AGE") = "01/01/0001" Then
                Return True
            End If

            If Now.ToShortDateString > .Item("PASSWORD_AGE") Then
                MsgBox("You reached the MAXIMUM DAYS account expiration," & vbCrLf & _
                       "Please Contact SYSTEM ADMINISTRATOR for assistance.", MsgBoxStyle.Exclamation, "Expiration")
                Return False
            End If
        End With
        Return True
    End Function

    ''' <summary>
    ''' This function check if the account reached the maximum days expiration.
    ''' </summary>
    ''' <param name="uNAME"></param>
    ''' <param name="u_PASS"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function Chk_Account_EXPIRY_COUNTDOWN(ByVal uNAME As String, ByVal u_PASS As String) As Boolean
        mySql = "SELECT * FROM " & maintable & " WHERE USERPASS = '" & Encrypt(u_PASS) & "'" & _
                 "AND UPPER(USERNAME) = UPPER('" & uNAME & "')"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        End If

        With ds.Tables(0).Rows(0)

            If .Item("PASSWORD_EXPIRY") = "01/01/0001" Then
                Return True
            End If

            Dim sysDate As Date = .Item("SYSTEMINFO")
            Dim p_Expiry As Date = .Item("PASSWORD_EXPIRY")

            If Now.ToShortDateString > p_Expiry Or Now.ToShortDateString < sysDate.ToShortDateString Then
                MsgBox("You reached MINIMUM DAYS account expiration," & vbCrLf & _
                       "Please Contact SYSTEM ADMINISTRATOR for assistance.", MsgBoxStyle.Exclamation, "Expiration")
                Return False
            End If
        End With
        Return True
    End Function

    ''' <summary>
    ''' This function get the number of failed attemp to enter his/her accounts.
    ''' </summary>
    ''' <param name="uNAME"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function GET_FAILED_ATTEMP_NUM(ByVal uNAME As String) As Integer
        mySql = "SELECT * FROM " & maintable & " WHERE UPPER(USERNAME) = UPPER('" & uNAME & "') AND STATUS <> '0'"
        Dim ds As DataSet = LoadSQL(mySql, maintable)
        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Users(ds.Tables(0).Rows(0).Item("USERID"))
        Return ds.Tables(0).Rows(0).Item("FAILEDATTEMPNUM")
    End Function

    ''' <summary>
    ''' This function will allow to disable the user's account.
    ''' </summary>
    ''' <param name="uNAME"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function LOCK_USER(ByVal uNAME As String) As Boolean
        mySql = "SELECT * FROM " & maintable & " WHERE UPPER(USERNAME) = UPPER('" & uNAME & "') AND STATUS <> '0'"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        With ds.Tables(0).Rows(0)
            .Item("LASTLOGIN") = Now
            .Item("STATUS") = "0"
        End With
        database.SaveEntry(ds, False)
        Return True
    End Function

    ''' <summary>
    ''' This function will return to max days expiration if the user 
    ''' used his/her account within 30 days.
    ''' </summary>
    ''' <param name="Uname"></param>
    ''' <param name="pNAME"></param>
    ''' <param name="isExpired"></param>
    ''' <remarks></remarks>
    Friend Sub Back_to_max_if_Login(ByVal Uname As String, ByVal pNAME As String, Optional ByVal isExpired As Boolean = True)
        mySql = "SELECT * FROM " & maintable & " WHERE USERPASS = '" & EncryptString(pNAME) & "'" & _
                 "AND UPPER(USERNAME) = UPPER('" & Uname & "')"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        With ds.Tables(0).Rows(0)
            .Item("LASTLOGIN") = Now
            .Item("PASSWORD_EXPIRY") = IIf(isExpired, Now.AddDays(.Item("EXPIRY_COUNTER")), "01/01/0001")
        End With
        database.SaveEntry(ds, False)
    End Sub

    ''' <summary>
    ''' This function only check if login user is admin.
    ''' </summary>
    ''' <param name="uName"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Friend Function chECK_If_SuperAdmin(ByVal uName As String) As Boolean
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE UPPER(USERNAME) =UPPER('{0}')", uName)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then Return False

        If ds.Tables(0).Rows(0).Item("USERTYPE") = "Admin" Then
            Return True
        Else
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' This function get the remaining days password expiration.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function Get_rem_PassExp() As Integer
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERID ={0}", UserIDX)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then Return 0

        Return Date_Calculation(ds.Tables(0).Rows(0).Item("PASSWORD_AGE")) + 1
    End Function

    ''' <summary>
    ''' This function check if user's information does'nt updated.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Function ChkUserUpdate() As Boolean
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERID ={0}", UserIDX)
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        With ds.Tables(0).Rows(0)
            If .Item("Lastname") = "Not define" And .Item("UserType") = "User" Then
                Return True
            End If
        End With

        Return False
    End Function

    Friend Function ChangePassword(ByVal newPass As String) As Boolean
        If Not Check_Pass_IfExists(UserIDX, Encrypt(newPass)) Then
            MsgBox("The password you've entered is already taken." & vbCrLf & _
                    "Please try again.", MsgBoxStyle.Critical, "Validate") : Return False
            Return False
        End If

        mySql = "SELECT * FROM " & maintable & " WHERE USERID = " & UserIDX
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        With ds.Tables(0).Rows(0)
            .Item("Userpass") = Encrypt(newPass)
            database.SaveEntry(ds, False)
        End With

        mySql = String.Format("SELECT * FROM " & subTable & " WHERE USERPASS = '{0}' AND USERID = " & UserIDX & "", Encrypt(newPass))
        Dim ds1 As DataSet = LoadSQL(mySql, subTable)

        If ds1.Tables(0).Rows.Count > 0 Then
            With ds1.Tables(0).Rows(0)
                .Item("USERPASS") = Encrypt(newPass)
                .Item("DATE_CREATED") = Now
            End With
            database.SaveEntry(ds1, False)

        Else
            Dim dr As DataRow
            dr = ds1.Tables(subTable).NewRow
            With dr
                .Item("USERID") = UserIDX
                .Item("USERPASS") = Encrypt(newPass)
                .Item("DATE_CREATED") = Now
            End With
            ds1.Tables(subTable).Rows.Add(dr)
            database.SaveEntry(ds1)
        End If
        Return True
    End Function
#End Region
End Class
