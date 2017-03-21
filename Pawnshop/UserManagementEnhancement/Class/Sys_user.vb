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

    Friend Function add_USER(Optional ByVal IS_EXPIRE As Boolean = True) As Boolean
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERPASS = '{0}'", EncryptString(_USERPASS))
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
            .Item("EMAIL_ADDRESS") = _EMAIL_ADDRESS
            .Item("CONTACTNO") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
            .Item("LASTLOGIN") = Now
            '.Item("ENCODERID") = _encoderID
            .Item("PASSWORD_AGE") = Now.AddDays(PASSWORD_AGE_COUNT)
            .Item("SYSTEMINFO") = Now
            .Item("PASSWORD_EXPIRY") = IIf(IS_EXPIRE, Now.AddDays(PASSWORD_EXPIRY_COUNT), "01/01/0001")
            .Item("ISEXPIRED") = _ISEXPIRED
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

    Friend Function Update_USER(Optional ByVal IS_EXPIRE As Boolean = True) As Boolean


        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERID = '{0}'", _ID)
        Dim ds As DataSet = LoadSQL(mySql, maintable)


        If ds.Tables(0).Rows(0).Item("USERPASS") = EncryptString(_USERPASS) Then
            Console.WriteLine("cURRENT PASSWORD")
        End If

        If _USERPASS = "" Then
            Passwd_update = False
            GoTo nextLINETODO
        Else
            If Not Check_Pass_IfExists(_ID, EncryptString(_USERPASS)) Then
                MsgBox("The password you've entered is already taken." & vbCrLf & _
                       "Please try again.", MsgBoxStyle.Critical, "Validate")
                Return False
            End If
        End If


nextLINETODO:

        With ds.Tables(0).Rows(0)
            .Item("USERNAME") = _USERNAME
            .Item("FIRSTNAME") = _FIRSTNAME
            .Item("MIDDLENAME") = _MIDDLENAME
            .Item("LASTNAME") = _LASTNAME
            .Item("USERPASS") = IIf(Passwd_update, EncryptString(_USERPASS), tmpPassword)
            .Item("EMAIL_ADDRESS") = _EMAIL_ADDRESS
            .Item("CONTACTNO") = _CONTACTNO
            .Item("BIRTHDAY") = _BIRTHDAY
            .Item("GENDER") = _GENDER
            .Item("AGE") = _AGE
            .Item("LASTLOGIN") = Now
            .Item("PASSWORD_AGE") = Now.AddDays(90)
            ' .Item("SYSTEMINFO") = Now
            .Item("PASSWORD_EXPIRY") = IIf(IS_EXPIRE, Now.AddDays(PASSWORD_EXPIRY_COUNT), "01/01/0001")
            .Item("ISEXPIRED") = ISEXPIRED
            .Item("STATUS") = _UserStatus
        End With
        database.SaveEntry(ds, False)

        mySql = String.Format("SELECT * FROM " & subTable & " WHERE USERPASS = '{0}'", EncryptString(_USERPASS))
        Dim ds1 As DataSet = LoadSQL(mySql, subTable)
        Dim i As Integer = 0

        If ds1.Tables(0).Rows.Count > 0 Then
            With ds1.Tables(0).Rows(0)
                .Item("USERPASS") = EncryptString(_USERPASS)
                .Item("DATE_CREATED") = Now
            End With
            database.SaveEntry(ds1, False)

        Else
            Dim dr As DataRow
            dr = ds1.Tables(subTable).NewRow
            With dr
                .Item("USERID") = _ID
                .Item("USERPASS") = EncryptString(_USERPASS)
                .Item("DATE_CREATED") = Now
            End With
            ds1.Tables(subTable).Rows.Add(dr)
            database.SaveEntry(ds1)
        End If

        Return True
    End Function

    Friend Function Check_Pass_IfExists(ByVal idx As Integer, ByVal passwd As String) As Boolean

        mySql = "SELECT * FROM " & subTable & " WHERE USERID  = " & idx & ""
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
            Dim U_pass1 As New List(Of String)()
            Dim count As Integer = 0
            For Each pass In u_pass
                count += 1
                If count = 1 Then
                    U_pass1.Add(pass)
                ElseIf count = u_pass.Count Then
                    U_pass1.Add(pass)
                End If
            Next

            For Each pass1 In U_pass1
                If passwd = pass1 Then
                    Return True
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

    Friend Function dsUSEr() As DataSet
        Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USER_DEFAULT")
        Return ds
    End Function

    Friend Sub Users(ByVal id As Integer)
        Dim mysql As String = "SELECT * FROM TBL_USER_DEFAULT WHERE USERID = '" & id & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USER_DEFAULT")

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
            _lastLogin = IIf(IsDBNull(.Item("LASTLOGIN")), "", .Item("LASTLOGIN"))
            _PASSWORD_AGE = .Item("PASSWORD_AGE")
            _systeminfo = .Item("SYSTEMINFO")
            _PASSWORD_EXPIRY = .Item("PASSWORD_EXPIRY")
            _ISEXPIRED = .Item("ISEXPIRED")
            _UserStatus = .Item("STATUS")
        End With
    End Sub

    Friend Sub Save_Privilege(ByVal idx As Integer, ByVal isNew As Boolean)
        mySql = String.Format("SELECT * FROM " & MAIN_LINE & " WHERE USERLINE_ID = '{0}'", idx)
        Dim ds As DataSet = LoadSQL(mySql, MAIN_LINE)


        If isNew Then
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

        Else
            isNew = False
            With ds.Tables(MAIN_LINE).Rows(0)
                .Item("PRIVILEGE_TYPE") = _PRIVILEGE_TYPE
                .Item("ACCESS_TYPE") = _ACCESSTYPE
                .Item("DATE_UPDATED_LINE") = Now.ToShortDateString
            End With
        End If
        database.SaveEntry(ds, isNew)
    End Sub

    Friend Sub LOAD_USERLINE_ROWS(ByVal IDX As Integer)
        mySql = String.Format("SELECT * FROM " & MAIN_LINE & " WHERE USERID ={0}", IDX)
        Dim ds As DataSet = LoadSQL(mySql, MAIN_LINE)

        For Each dr As DataRow In ds.Tables(0).Rows
            Load_userLINE_BY_Rows(dr)
        Next
    End Sub

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
        frmUserManagement.dgRulePrivilege.Rows.Add(_USERLINE_ID, _PRIVILEGE_TYPE, _ACCESSTYPE)
    End Sub

    Friend Function GETUSERID() As Integer
        mySql = String.Format("SELECT * FROM " & maintable & " WHERE USERPASS ='{0}'", tmpPassword)
        Dim ds As DataSet = LoadSQL(mySql, maintable)
        Return ds.Tables(0).Rows(0).Item("USERID")
    End Function
#End Region

#Region "Login functions"
    Friend Function LogUser(ByVal uName As String, ByVal pWrd As String) As Boolean
        mySql = String.Format("SELECT USERID,USERNAME,USERPASS FROM " & maintable & " WHERE USERNAME ='{0}'" & _
                              "AND USERPASS = '{1}'", uName, EncryptString(pWrd))
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then Return False

        Users(ds.Tables(0).Rows(0).Item("USERID"))
        Return True
    End Function


    Friend Function CheckAccount_Expiration(ByVal uNAME As String, ByVal u_PASS As String) As Boolean
        mySql = "SELECT * FROM " & maintable & " WHERE USERPASS = '" & EncryptString(u_PASS) & "'" & _
                "AND UPPER(USERNAME) = UPPER('" & uNAME & "')"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        End If

        With ds.Tables(0).Rows(0)
            If Now.ToShortDateString > .Item("PASSWORD_AGE") Then
                MsgBox("You reached the MAXIMUM DAYS account expiration," & vbCrLf & _
                       "Please Contact SYSYTEM ADMINISTRATOR for assistance.", MsgBoxStyle.Exclamation, "Expiration")
                Return False
            End If
        End With
        Return True
    End Function

    Friend Function EXPIRY_COUNTDOWN(ByVal uNAME As String, ByVal u_PASS As String) As Boolean
        mySql = "SELECT * FROM " & maintable & " WHERE USERPASS = '" & EncryptString(u_PASS) & "'" & _
                 "AND UPPER(USERNAME) = UPPER('" & uNAME & "')"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        If ds.Tables(0).Rows.Count = 0 Then
            Return True
        End If

        With ds.Tables(0).Rows(0)
            If Now.ToShortDateString > .Item("PASSWORD_EXPIRY") Then
                MsgBox("You reached MINIMUM DAYS account expiration," & vbCrLf & _
                       "Please Contact SYSTEM ADMINISTRATOR for assistance.", MsgBoxStyle.Exclamation, "Expiration")
                Return False
            End If
        End With
        Return True
    End Function

    Friend Sub Populate_Failed_Attemp()
        Dim opt_keys As String() = {"FailedAttempNum", "IsFailedAtemp"}

        For Each itm In opt_keys

            Dim mysql As String = "SELECT * FROM TBLMAINTENANCE WHERE OPT_KEYS ='" & itm & "'"
            Dim ds As DataSet = LoadSQL(mysql, "TBLMAINTENANCE")

            If ds.Tables(0).Rows.Count = 0 Then
                Dim dsnewrow As DataRow
                dsnewrow = ds.Tables(0).NewRow
                dsnewrow.Item("OPT_KEYS") = itm
                ds.Tables(0).Rows.Add(dsnewrow)
                database.SaveEntry(ds)
            Else
                With ds.Tables(0).Rows(0)
                    .Item("OPT_KEYS") = itm
                End With
                database.SaveEntry(ds, False)
            End If
        Next
    End Sub

    Friend Sub Load_Failed_attemp()
        Dim opt_keys As String() = {"FailedAttempNum", "IsFailedAtemp"}
        For Each ITM In opt_keys
            mySql = "SELECT * FROM TBLMAINTENANCE WHERE OPT_KEYS = '" & ITM & "'"
            Dim ds As DataSet = LoadSQL(mySql, "TBLMAINTENANCE")

            If ds.Tables(0).Rows.Count = 0 Then Exit Sub

            If ITM = "FailedAttempNum" Then
                With ds.Tables(0).Rows(0)
                    frmUserManagement.txtFailedAttemp.Text = .Item("OPT_VALUES")
                End With
            Else
                With ds.Tables(0).Rows(0)
                    If .Item("OPT_VALUES") = "Disable" Then
                        frmUserManagement.rbDisable.Checked = True
                    Else
                        frmUserManagement.rbEnable.Checked = True
                    End If

                End With
            End If
        Next
    End Sub
#End Region
End Class
