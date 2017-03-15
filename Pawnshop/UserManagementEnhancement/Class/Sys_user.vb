﻿Imports DeathCodez.Security

''' <summary>
''' NOTE: Privilege PDuNxp8S9q0= means SUPER USER
''' </summary>
''' <remarks>NOTE: Privilege PDuNxp8S9q0= means SUPER USER</remarks>
Public Class Sys_user

    Private maintable As String = "tbl_user_default"
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

    Private _systeminfo As Date
    Public Property systeminfo() As Date
        Get
            Return _systeminfo
        End Get
        Set(ByVal value As Date)
            _systeminfo = value
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

    Private _DAYSCOUNT As Integer
    Public Property DAYSCOUNT() As Integer
        Get
            Return _DAYSCOUNT
        End Get
        Set(ByVal value As Integer)
            _DAYSCOUNT = value
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

    Private _COUNTER As Integer
    Public Property COUNTER() As Integer
        Get
            Return _COUNTER
        End Get
        Set(ByVal value As Integer)
            _COUNTER = value
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
#End Region

#Region "Procedures and Functions"

    Friend Function add_USER() As Boolean
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
            'Item("PRIVILEGE") = _privilege
            '.Item("LASTLOGIN") = _AGE
            '.Item("ENCODERID") = _encoderID
            .Item("EXPIRYDATE") = Now.AddDays(90)
            .Item("SYSTEMINFO") = Now.ToShortDateString
            .Item("DAYS_COUNT") = IsnotUsed
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
            .Item("COUNTER") = 1
            .Item("DATE_CREATED") = Now.ToShortDateString
        End With
        ds2.Tables(subTable).Rows.Add(dr)
        database.SaveEntry(ds2)

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

        Load_user_All_Rows(ds.Tables(0).Rows(0))
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
            _privilege = IIf(IsDBNull(.Item("PRIVILEGE")), "", .Item("PRIVILEGE"))
            _lastLogin = IIf(IsDBNull(.Item("LASTLOGIN")), "", .Item("LASTLOGIN"))
            _EXPIRYDATE = .Item("EXPIRYDATE")
            _systeminfo = .Item("SYSTEMINFO")
            _DAYSCOUNT = .Item("DAYS_COUNT")
            _UserStatus = .Item("STATUS")
        End With
    End Sub

    Friend Function CheckAccount_Expiration(ByVal u_PASS As String) As Boolean
        mySql = "SELECT * FROM " & maintable & " WHERE USERPASS = '" & EncryptString(u_PASS) & "'"
        Dim ds As DataSet = LoadSQL(mySql, maintable)

        With ds.Tables(0).Rows(0)
            If .Item("EXPIRYDATE") = Now.ToShortDateString Then
                MsgBox("Your account has been expired," & vbCrLf & _
                       "Please Contact MIS for assistance.", MsgBoxStyle.Exclamation, "Expiration")
                Return False
            End If
        End With
        Return True
    End Function

    Friend Sub Count_days()
        Dim ds As DataSet = dsUSEr()
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                .Item("DAYS_COUNT") = .Item("DAYS_COUNT") - 1
            End With
            database.SaveEntry(ds, False)
        Next
    End Sub

    Friend Function Count_LOCKDOWN(ByVal c As Integer) As Boolean
        Dim wrongLogin As Integer = c

        If wrongLogin = 3 Then
            Return False
        End If

        Return True
    End Function
#End Region
End Class