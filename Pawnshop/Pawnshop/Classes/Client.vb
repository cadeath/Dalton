﻿Imports System.Data.Odbc
' Changelog
' v1.3 10/30/2015
'  - Load from View_Client
'  - Include the ID
' v1.2 10/29/15
'  - Simplify Codes
' v1.1.1 10/22/2015
'  - Change ZIP data type from Integer to String
' v1.1 10/21/2015
'  - LoadClient added

Public Class Client

#Region "Variables"
    Enum Gender As Integer : Male = 1 : Female = 0 : End Enum

    Private _id As Integer = 0
    Private _firstName As String = String.Empty
    Private _middleName As String = String.Empty
    Private _lastName As String = String.Empty
    Private _suffixName As String = String.Empty

    Private _addrSt As String = String.Empty
    Private _addrBrgy As String = String.Empty
    Private _addrCity As String = String.Empty
    Private _addrProvince As String = String.Empty
    Private _addrZip As String = String.Empty

    Private _gender As Gender = Gender.Male
    Private _bday As Date

    Private _cp1 As String = String.Empty
    Private _cp2 As String = String.Empty
    Private _phone As String = String.Empty
    Private _otherNum As String = String.Empty

    'ID
    Private _idType As String = String.Empty
    Private _idNum As String = String.Empty
    Private _remarks As String = String.Empty
    Private _IsDumper As Boolean

    'Database
    Private fillData As String = "tblClient"
#End Region

#Region "Properties"
    Public Property ID As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Public Property FirstName As String
        Set(ByVal value As String)
            _firstName = value
        End Set
        Get
            Return _firstName
        End Get
    End Property

    Public Property MiddleName As String
        Set(ByVal value As String)
            _middleName = value
        End Set
        Get
            Return _middleName
        End Get
    End Property

    Public Property LastName As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Public Property Suffix As String
        Set(ByVal value As String)
            _suffixName = value
        End Set
        Get
            Return _suffixName
        End Get
    End Property

    Public Property AddressSt As String
        Set(ByVal value As String)
            _addrSt = value
        End Set
        Get
            Return _addrSt
        End Get
    End Property

    Public Property AddressBrgy As String
        Get
            Return _addrBrgy
        End Get
        Set(ByVal value As String)
            _addrBrgy = value
        End Set
    End Property

    Public Property AddressCity As String
        Get
            Return _addrCity
        End Get
        Set(ByVal value As String)
            _addrCity = value
        End Set
    End Property

    Public Property AddressProvince As String
        Set(ByVal value As String)
            _addrProvince = value
        End Set
        Get
            Return _addrProvince
        End Get
    End Property

    Public Property ZipCode As String
        Set(ByVal value As String)
            _addrZip = value
        End Set
        Get
            Return _addrZip
        End Get
    End Property

    Public Property Sex As Gender
        Set(ByVal value As Gender)
            _gender = value
        End Set
        Get
            Return _gender
        End Get
    End Property

    Public Property Birthday As Date
        Set(ByVal value As Date)
            _bday = value.ToShortDateString
        End Set
        Get
            Return _bday
        End Get
    End Property

    Public Property Cellphone1 As String
        Set(ByVal value As String)
            _cp1 = DreadKnight(value, "-")
        End Set
        Get
            Return _cp1
        End Get
    End Property

    Public Property Cellphone2 As String
        Set(ByVal value As String)
            _cp2 = DreadKnight(value, "-")
        End Set
        Get
            Return _cp2
        End Get
    End Property

    Public Property Telephone As String
        Set(ByVal value As String)
            _phone = DreadKnight(value, "-")
        End Set
        Get
            Return _phone
        End Get
    End Property

    Public Property OtherNumber As String
        Set(ByVal value As String)
            _otherNum = DreadKnight(value)
        End Set
        Get
            Return _otherNum
        End Get
    End Property

    Public Property IDType As String
        Set(ByVal value As String)
            _idType = value
        End Set
        Get
            Return _idType
        End Get
    End Property

    Public Property IDNumber As String
        Set(ByVal value As String)
            _idNum = value
        End Set
        Get
            Return _idNum
        End Get
    End Property

    Public Property Remarks As String
        Set(ByVal value As String)
            _remarks = value
        End Set
        Get
            Return _remarks
        End Get
    End Property

    Public Property IsDumper As Boolean
        Set(ByVal value As Boolean)
            _IsDumper = value
        End Set
        Get
            Return _IsDumper
        End Get
    End Property
#End Region

    Public Sub SaveClient()
        database.SaveEntry(CreateDataSet)
    End Sub

    Public Sub ModifyClient()
        Dim mySql As String = "SELECT * FROM TBLCLIENT WHERE ClientID = " & _id
        Dim ds As DataSet = LoadSQL(mySql, "TBLCLIENT")

        With ds.Tables(0).Rows(0)
            .Item("FirstName") = _firstName
            .Item("MiddleName") = _middleName
            .Item("LastName") = _lastName
            .Item("Suffix") = _suffixName
            .Item("Addr_Street") = _addrSt
            .Item("Addr_Brgy") = _addrBrgy
            .Item("Addr_City") = _addrCity
            .Item("Addr_Province") = _addrProvince
            .Item("Addr_Zip") = _addrZip
            .Item("Sex") = _gender
            .Item("Birthday") = _bday
            .Item("Phone1") = _cp1
            .Item("Phone2") = _cp2
            .Item("Phone3") = _phone
            .Item("Phone_Others") = _otherNum
            .Item("IsDumper") = If(_IsDumper, 1, 0)
        End With

        database.SaveEntry(ds, False)
        'PureModify()
    End Sub

    Private Sub PureModify()
        dbOpen()

        Dim da As OdbcDataAdapter
        Dim ds As New DataSet, mySql As String, fillData As String = "Modify"

        mySql = "SELECT * FROM tblClient WHERE clientID = " & _id
        ds.Clear()

        da = New OdbcDataAdapter(mySql, con)
        da.Fill(ds, fillData)

        Console.WriteLine("Result: " & ds.Tables(fillData).Rows.Count)

        With ds.Tables(fillData).Rows(0)
            .Item("FirstName") = _firstName
            .Item("MiddleName") = _middleName
            .Item("LastName") = _lastName
            .Item("Suffix") = _suffixName
            .Item("Addr_Street") = _addrSt
            .Item("Addr_Brgy") = _addrBrgy
            .Item("Addr_City") = _addrCity
            .Item("Addr_Province") = _addrProvince
            .Item("Addr_Zip") = _addrZip
            .Item("Sex") = _gender
            .Item("Birthday") = _bday
            .Item("Phone1") = _cp1
            .Item("Phone2") = _cp2
            .Item("Phone3") = _phone
            .Item("Phone_Others") = _otherNum
            .Item("IsDumper") = If(_IsDumper, 1, 0)
        End With
        da.Update(ds, fillData)

        dbClose()
    End Sub

    Private Function CreateDataSet() As DataSet
        Dim ds As DataSet

        Dim mySql As String = "SELECT * FROM tblClient"
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("FirstName") = _firstName
            .Item("MiddleName") = _middleName
            .Item("LastName") = _lastName
            .Item("Suffix") = _suffixName
            .Item("Addr_Street") = _addrSt
            .Item("Addr_Brgy") = _addrBrgy
            .Item("Addr_City") = _addrCity
            .Item("Addr_Province") = _addrProvince
            .Item("Addr_Zip") = _addrZip
            .Item("Sex") = _gender
            .Item("Birthday") = _bday
            .Item("Phone1") = _cp1
            .Item("Phone2") = _cp2
            .Item("Phone3") = _phone
            .Item("Phone_Others") = _otherNum
            .Item("IsDumper") = If(_IsDumper, 1, 0)
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        Return ds
    End Function

    ' Client 001 - LoadClient
    ''' <summary>
    ''' This is use to load Client information
    ''' </summary>
    ''' <param name="id">ClientID</param>
    ''' <remarks>to be added by ID List</remarks>
    Public Sub LoadClient(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM VIEW_CLIENT WHERE ClientID = " & id
        Dim ds As DataSet = LoadSQL(mySql)

        If IsNothing(ds) Then
            MsgBox("[Client 001 - LoadClient] Failed to Load Client Information", MsgBoxStyle.Critical, "Information Not Found")
            Exit Sub
        End If

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("Client Info Failed", MsgBoxStyle.Critical) : Exit Sub
        loadClientInfoByRow(ds.Tables(0).Rows(0))

        Console.WriteLine("[LoadClient] Client ID " & id & " is loaded.")
    End Sub

    Private Sub loadClientinfoByDataReader(reader As OdbcDataReader)
        With reader
            _id = .Item("ClientID")
            _firstName = IIf(IsDBNull(.Item("FirstName")), "", .Item("FirstName"))
            _middleName = IIf(IsDBNull(.Item("MiddleName")), "", .Item("MiddleName"))
            _lastName = IIf(IsDBNull(.Item("LastName")), "", .Item("LastName"))
            _suffixName = IIf(IsDBNull(.Item("Suffix")), "", .Item("Suffix"))

            _addrSt = .Item("Addr_Street")
            _addrBrgy = .Item("Addr_Brgy")
            _addrCity = .Item("Addr_City")
            _addrProvince = .Item("Addr_Province")
            _addrZip = .Item("Addr_Zip")

            _gender = IIf(.Item("Sex") = "M", 1, 0)
            _bday = .Item("Birthday")

            _cp1 = .Item("Phone1").ToString
            _cp2 = .Item("Phone2").ToString
            _phone = .Item("Phone3").ToString
            _otherNum = .Item("Phone_Others").ToString

            'ID
            _idType = IIf(IsDBNull(.Item("IDType")), "", .Item("IDType"))
            _idNum = IIf(IsDBNull(.Item("RefNum")), "", .Item("RefNum"))
            _remarks = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))

            If Not IsDBNull(.Item("IsDumper")) Then
                If .Item("IsDumper") = 1 Then
                    _IsDumper = True
                Else : _IsDumper = False : End If
            Else : _IsDumper = False : End If

        End With
    End Sub

    Private Sub loadClientInfoByRow(ByVal dr As DataRow)
        With dr
            _id = .Item("ClientID")
            _firstName = IIf(IsDBNull(.Item("FirstName")), "", .Item("FirstName"))
            _middleName = IIf(IsDBNull(.Item("MiddleName")), "", .Item("MiddleName"))
            _lastName = IIf(IsDBNull(.Item("LastName")), "", .Item("LastName"))
            _suffixName = IIf(IsDBNull(.Item("Suffix")), "", .Item("Suffix"))

            _addrSt = .Item("Addr_Street")
            _addrBrgy = .Item("Addr_Brgy")
            _addrCity = .Item("Addr_City")
            _addrProvince = .Item("Addr_Province")
            _addrZip = .Item("Addr_Zip")

            _gender = IIf(.Item("Sex") = "M", 1, 0)
            _bday = .Item("Birthday")

            _cp1 = .Item("Phone1").ToString
            _cp2 = .Item("Phone2").ToString
            _phone = .Item("Phone3").ToString
            _otherNum = .Item("Phone_Others").ToString

            'ID
            _idType = IIf(IsDBNull(.Item("IDType")), "", .Item("IDType"))
            _idNum = IIf(IsDBNull(.Item("RefNum")), "", .Item("RefNum"))
            _remarks = IIf(IsDBNull(.Item("Remarks")), "", .Item("Remarks"))
            If Not IsDBNull(.Item("IsDumper")) Then
                If .Item("IsDumper") = 1 Then
                    _IsDumper = True
                Else : _IsDumper = False : End If
            Else : _IsDumper = False : End If
        End With
    End Sub

    Public Sub LoadClientByRow(ByVal dr As DataRow)
        With dr
            _id = .Item("ClientID")
            _firstName = .Item("FirstName")
            _middleName = .Item("MiddleName")
            _lastName = .Item("LastName")
            _suffixName = IIf(IsDBNull(.Item("Suffix")), "", .Item("Suffix"))

            _addrSt = .Item("Addr_Street")
            _addrBrgy = .Item("Addr_Brgy")
            _addrCity = .Item("Addr_City")
            _addrProvince = .Item("Addr_Province")
            _addrZip = .Item("Addr_Zip")

            _gender = IIf(.Item("Sex") = "M", 1, 0)
            _bday = .Item("Birthday")

            _cp1 = .Item("Phone1").ToString
            _cp2 = .Item("Phone2").ToString
            _phone = .Item("Phone3").ToString
            _otherNum = .Item("Phone_Others").ToString
            If Not IsDBNull(.Item("IsDumper")) Then
                If .Item("IsDumper") = 1 Then
                    _IsDumper = True
                Else : _IsDumper = False : End If
            Else : _IsDumper = False : End If
        End With
        Console.WriteLine("[LoadClientByRow] Client information Loaded.")
    End Sub

    Public Function LoadLastEntry() As Client
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM " & fillData & " ORDER BY ClientID ASC"
        ds = LoadSQL(mySql)

        Dim LastRow As Integer = ds.Tables(0).Rows.Count
        LoadClient(ds.Tables(0).Rows(LastRow - 1).Item("ClientID"))

        Return Me
    End Function

    Private Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "''")
        str = str.Replace("""", """""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function

    Friend Function tagDumper(ByVal cltid As Integer) As Boolean
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM " & fillData & " WHERE ClientID = " & cltid
        ds = LoadSQL(mySql, fillData)

        If ds.Tables(0).Rows.Count = 0 Then Return False

        With ds.Tables(0).Rows(0)
            .Item("ISDUMPER") = 1
        End With
        database.SaveEntry(ds, False)
        Return True
    End Function

End Class
