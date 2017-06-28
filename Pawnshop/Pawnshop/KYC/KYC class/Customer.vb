Imports System.IO

''' <summary>
''' This Class is made for the purpose of KYC Compliance
''' </summary>
''' <remarks></remarks>
Public Class Customer
    Private SRC As String = Application.StartupPath & "\ClientImage"
    Private SRCSignature As String = Application.StartupPath & "\Signature"
    Dim indexof As String
    Dim lastindexof As String

#Region "Properties"
    Private _id As Integer
    Public Property CustomerID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _firstName As String
    Public Property FirstName() As String
        Get
            Return _firstName
        End Get
        Set(ByVal value As String)
            _firstName = value
        End Set
    End Property

    Private _middleName As String
    Public Property MiddleName() As String
        Get
            Return _middleName
        End Get
        Set(ByVal value As String)
            _middleName = value
        End Set
    End Property

    Private _lastName As String
    Public Property LastName() As String
        Get
            Return _lastName
        End Get
        Set(ByVal value As String)
            _lastName = value
        End Set
    End Property

    Private _suffix As String
    Public Property Suffix() As String
        Get
            Return _suffix
        End Get
        Set(ByVal value As String)
            _suffix = value
        End Set
    End Property

    Private _addrStreet1 As String
    Public Property PresentStreet() As String
        Get
            Return _addrStreet1
        End Get
        Set(ByVal value As String)
            _addrStreet1 = value
        End Set
    End Property

    Private _addrBrgy1 As String
    Public Property PresentBarangay() As String
        Get
            Return _addrBrgy1
        End Get
        Set(ByVal value As String)
            _addrBrgy1 = value
        End Set
    End Property

    Private _addrCity1 As String
    Public Property PresentCity() As String
        Get
            Return _addrCity1
        End Get
        Set(ByVal value As String)
            _addrCity1 = value
        End Set
    End Property

    Private _addrProvince1 As String
    Public Property PresentProvince() As String
        Get
            Return _addrProvince1
        End Get
        Set(ByVal value As String)
            _addrProvince1 = value
        End Set
    End Property

    Private _addrZip1 As String
    Public Property PresentZipCode() As String
        Get
            Return _addrZip1
        End Get
        Set(ByVal value As String)
            _addrZip1 = value
        End Set
    End Property

    Private _addrStreet2 As String
    Public Property PermanentStreet() As String
        Get
            Return _addrStreet2
        End Get
        Set(ByVal value As String)
            _addrStreet2 = value
        End Set
    End Property

    Private _addrBrgy2 As String
    Public Property PermanentBarangay() As String
        Get
            Return _addrBrgy2
        End Get
        Set(ByVal value As String)
            _addrBrgy2 = value
        End Set
    End Property

    Private _addrCity2 As String
    Public Property PermanentCity() As String
        Get
            Return _addrCity2
        End Get
        Set(ByVal value As String)
            _addrCity2 = value
        End Set
    End Property

    Private _addrProvince2 As String
    Public Property PermanentProvince() As String
        Get
            Return _addrProvince2
        End Get
        Set(ByVal value As String)
            _addrProvince2 = value
        End Set
    End Property

    Private _addrZip2 As String
    Public Property PermanentZipCode() As String
        Get
            Return _addrZip2
        End Get
        Set(ByVal value As String)
            _addrZip2 = value
        End Set
    End Property

    Enum Gender As Integer
        Male = 1
        Female = 0
    End Enum

    Private _sex As Gender
    Public Property Sex() As Gender
        Get
            Return _sex
        End Get
        Set(ByVal value As Gender)
            _sex = value
        End Set
    End Property

    Private _birthday As Date
    Public Property Birthday() As Date
        Get
            Return _birthday
        End Get
        Set(ByVal value As Date)
            _birthday = value
        End Set
    End Property

    Private _birthplace As String
    Public Property BirthPlace() As String
        Get
            Return _birthplace
        End Get
        Set(ByVal value As String)
            _birthplace = value
        End Set
    End Property

    Private _nationality As String
    Public Property Nationality() As String
        Get
            Return _nationality
        End Get
        Set(ByVal value As String)
            _nationality = value
        End Set
    End Property

    Private _natureOfWork As String
    Public Property NatureOfWork() As String
        Get
            Return _natureOfWork
        End Get
        Set(ByVal value As String)
            _natureOfWork = value
        End Set
    End Property

    Private _businessNameOrEmployeer As String
    Public Property BusinessnameOrEmployeer() As String
        Get
            Return _businessNameOrEmployeer
        End Get
        Set(ByVal value As String)
            _businessNameOrEmployeer = value
        End Set
    End Property

    Private _sourceOfFund As String
    Public Property SourceOfFund() As String
        Get
            Return _sourceOfFund
        End Get
        Set(ByVal value As String)
            _sourceOfFund = value
        End Set
    End Property

    Enum RankNumber As Integer
        Low = 0
        Medium = 1
        High = 2
    End Enum
    Private _rank As RankNumber
    Public Property Rank() As RankNumber
        Get
            Return _rank
        End Get
        Set(ByVal value As RankNumber)
            _rank = value
        End Set
    End Property


    Private _custIDs As Collections_ID
    Public Property CustomersIDs() As Collections_ID
        Get
            Return _custIDs
        End Get
        Set(ByVal value As Collections_ID)
            _custIDs = value
        End Set
    End Property

    Private _custPhones As Collections_Phone
    Public Property CustomersPhone() As Collections_Phone
        Get
            Return _custPhones
        End Get
        Set(ByVal value As Collections_Phone)
            _custPhones = value
        End Set
    End Property

    Private _CImage As String
    Public Property CImage() As String
        Get
            Return _CImage
        End Get
        Set(ByVal value As String)
            _CImage = value
        End Set
    End Property

    Private _cPUREIMAGE As Image
    Public Property CPUREIMAGE As Image
        Get
            Return _cPUREIMAGE
        End Get
        Set(ByVal value As Image)
            _cPUREIMAGE = value
        End Set
    End Property

    Private _CSignature As String
    Public Property CSignature() As String
        Get
            Return _CSignature
        End Get
        Set(ByVal value As String)
            _CSignature = value
        End Set
    End Property

    Private _CSignaturePUre As Image
    Public Property CSignaturePUre As Image
        Get
            Return _CSignaturePUre
        End Get
        Set(ByVal value As Image)
            _CSignaturePUre = value
        End Set
    End Property

    Private _iSDumper As Boolean
    Public Property iSDumper() As Boolean
        Get
            Return _iSDumper
        End Get
        Set(ByVal value As Boolean)
            _iSDumper = value
        End Set
    End Property
#End Region

#Region "Procedures"
    Public Function Save() As Boolean
        If _id = 0 Then
            If Not ChkIfCustExists(_firstName, _lastName, _birthday, _middleName) Then Return False
        End If

        Dim mySql As String = "SELECT * FROM " & CUSTOMER_TABLE & " WHERE ID = " & _id
        Dim ds As DataSet = LoadSQL(mySql, CUSTOMER_TABLE), isNew As Boolean = False

        ' PHASE 1
        ' SAVING CUSTOMER INFORMATION
        If _id = 0 Then
            'NEW
            isNew = True
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(CUSTOMER_TABLE).NewRow
            With dsNewRow
                .Item("FIRSTNAME") = _firstName
                .Item("MIDNAME") = _middleName
                .Item("LASTNAME") = _lastName
                .Item("Suffix") = _suffix
                .Item("STREET1") = _addrStreet1
                .Item("BRGY1") = _addrBrgy1
                .Item("CITY1") = _addrCity1
                .Item("PROVINCE1") = _addrProvince1
                .Item("ZIP1") = _addrZip1
                .Item("STREET2") = _addrStreet2
                .Item("BRGY2") = _addrBrgy2
                .Item("CITY2") = _addrCity2
                .Item("PROVINCE2") = _addrProvince2
                .Item("ZIP2") = _addrZip2

                .Item("BIRTHDAY") = _birthday
                .Item("BIRTHPLACE") = _birthplace
                .Item("NATUREOFWORK") = _natureOfWork
                .Item("NATIONALITY") = _nationality
                .Item("GENDER") = IIf(_sex = Gender.Male, "M", "F")
                .Item("SRCFUND") = _sourceOfFund
                .Item("RANK") = _rank
                .Item("CLIENT_IMG") = _CImage
                .Item("CLIENT_SIGNATURE") = _CSignature
                .Item("IsDumper") = If(_iSDumper, 1, 0)
               
            End With
            ds.Tables(CUSTOMER_TABLE).Rows.Add(dsNewRow)
        Else
            With ds.Tables(CUSTOMER_TABLE).Rows(0)
                .Item("FIRSTNAME") = _firstName
                .Item("MIDNAME") = _middleName
                .Item("LASTNAME") = _lastName
                .Item("Suffix") = _suffix
                .Item("STREET1") = _addrStreet1
                .Item("BRGY1") = _addrBrgy1
                .Item("CITY1") = _addrCity1
                .Item("PROVINCE1") = _addrProvince1
                .Item("ZIP1") = _addrZip1
                .Item("STREET2") = _addrStreet2
                .Item("BRGY2") = _addrBrgy2
                .Item("CITY2") = _addrCity2
                .Item("PROVINCE2") = _addrProvince2
                .Item("ZIP2") = _addrZip2

                .Item("BIRTHDAY") = _birthday
                .Item("BIRTHPLACE") = _birthplace
                .Item("NATUREOFWORK") = _natureOfWork
                .Item("NATIONALITY") = _nationality
                .Item("GENDER") = IIf(_sex = Gender.Male, "M", "F")
                .Item("SRCFUND") = _sourceOfFund
                .Item("RANK") = _rank
                .Item("CLIENT_IMG") = _CImage
                .Item("CLIENT_SIGNATURE") = _CSignature
                .Item("IsDumper") = If(_iSDumper, 1, 0)

            End With
        End If
        database.SaveEntry(ds, isNew)

        ' PHASE 2
        ' Saving the IDs and Phones

        ' If _custIDs.Count <= 0 Then GoTo gOheRE

        Dim lastCustomerID As Integer = 0

        If _id = 0 Then
            mySql = "SELECT * FROM " & CUSTOMER_TABLE & " ORDER BY ID DESC ROWS 1"
        Else
            mySql = "SELECT * FROM " & CUSTOMER_TABLE & " WHERE ID = " & _id
        End If

        ds.Clear()
        ds = LoadSQL(mySql, CUSTOMER_TABLE)
        lastCustomerID = ds.Tables(CUSTOMER_TABLE).Rows(0).Item("ID")

        If _custIDs.Count > 0 Then
            mySql = "SELECT * FROM " & CUSTOMER_ID & " WHERE CUSTID = " & lastCustomerID

            ds.Clear()
            ds = LoadSQL(mySql, CUSTOMER_ID)

            Dim dsNewRow As DataRow
            For Each id As NewIdentificationCard In _custIDs
                If id.ID = 0 Then
                    ' NEW ENTRIES
                    dsNewRow = ds.Tables(CUSTOMER_ID).NewRow
                    With dsNewRow
                        .Item("CUSTID") = lastCustomerID
                        .Item("ID_TYPE") = id.IDType
                        .Item("ID_NUMBER") = id.IDNumber
                        .Item("ISPRIMARY") = IIf(id.isPrimary, 1, 0)
                    End With
                    ds.Tables(CUSTOMER_ID).Rows.Add(dsNewRow)
                Else
                    ' UPDATE/MODIFY ENTRIES
                    Dim row As DataRow
                    row = ds.Tables(CUSTOMER_ID).Select("ID = " & id.ID)(0)
                    row("ID_TYPE") = id.IDType
                    row("ID_NUMBER") = id.IDNumber
                    row("ISPRIMARY") = IIf(id.isPrimary, 1, 0)
                End If
            Next

            database.SaveEntry(ds)

        End If

gOheRE:
        If _custPhones.Count > 0 Then
            mySql = "SELECT * FROM " & CUSTOMER_PHONE & " WHERE CUSTID = " & lastCustomerID

            ds.Clear()
            ds = LoadSQL(mySql, CUSTOMER_PHONE)
            Dim dsNewRow As DataRow
            For Each ph As PhoneNumber In _custPhones

                If ph.PhoneID = 0 Then
                    ' NEW ENTRIES
                    dsNewRow = ds.Tables(CUSTOMER_PHONE).NewRow
                    With dsNewRow
                        .Item("CUSTID") = lastCustomerID
                        .Item("PHONENUMBER") = ph.PhoneNumber
                        .Item("ISPRIMARY") = IIf(ph.isPrimary, 1, 0)
                    End With
                    ds.Tables(CUSTOMER_PHONE).Rows.Add(dsNewRow)
                Else
                    ' UPDATE/MODIFY ENTRIES
                    Dim row As DataRow
                    row = ds.Tables(CUSTOMER_PHONE).Select("PHONEID = " & ph.PhoneID)(0)
                    row("PHONENUMBER") = ph.PhoneNumber
                    row("ISPRIMARY") = IIf(ph.isPrimary, 1, 0)
                End If

            Next

            database.SaveEntry(ds)
        End If
        Return True
    End Function

    Public Sub Load_CustomerByID(Optional ByVal id As Integer = 0)
        If id = 0 Then id = _id

        Dim mySql As String = "SELECT * FROM " & CUSTOMER_TABLE & " WHERE ID = " & id
        Dim ds As DataSet = LoadSQL(mySql, CUSTOMER_TABLE)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        With ds.Tables(0).Rows(0)
            _id = .Item("ID")
            _firstName = .Item("FIRSTNAME")
            _middleName = .Item("MIDNAME")
            _lastName = .Item("LASTNAME")
            _suffix = IIf(IsDBNull(.Item("Suffix")), "", .Item("Suffix"))
            _addrStreet1 = .Item("STREET1")
            _addrBrgy1 = .Item("BRGY1")
            _addrCity1 = .Item("CITY1")
            _addrProvince1 = .Item("PROVINCE1")
            _addrZip1 = .Item("ZIP1")
            _addrStreet2 = IIf(IsDBNull(.Item("STREET2")), "", .Item("STREET2"))
            _addrBrgy2 = IIf(IsDBNull(.Item("BRGY2")), "", .Item("BRGY2"))
            _addrCity2 = IIf(IsDBNull(.Item("CITY2")), "", .Item("CITY2"))
            _addrProvince2 = IIf(IsDBNull(.Item("PROVINCE2")), "", .Item("PROVINCE2"))
            _addrZip2 = IIf(IsDBNull(.Item("ZIP2")), "", .Item("ZIP2"))

            _birthday = .Item("BIRTHDAY")
            _birthplace = .Item("BIRTHPLACE")
            _natureOfWork = IIf(IsDBNull(.Item("NATUREOFWORK")), "", .Item("NATUREOFWORK"))
            _nationality = IIf(IsDBNull(.Item("NATIONALITY")), "", .Item("NATIONALITY"))
            _sex = IIf(.Item("GENDER") = "M", 1, 0)
            _sourceOfFund = IIf(IsDBNull(.Item("SRCFUND")), "", .Item("SRCFUND"))
            _rank = IIf(IsDBNull(.Item("RANK")), "", .Item("RANK"))
            _CSignature = IIf(IsDBNull(.Item("CLIENT_SIGNATURE")), "", .Item("CLIENT_SIGNATURE"))
            _CImage = IIf(IsDBNull(.Item("CLIENT_IMG")), "", .Item("CLIENT_IMG"))

            If Not IsDBNull(.Item("IsDumper")) Then
                If .Item("IsDumper") = 1 Then
                    _iSDumper = True
                Else : _iSDumper = False : End If
            Else : _iSDumper = False : End If

            If _CImage = "" Then GoTo NEXTLINE

            indexof = SRC & "\" & _CImage.Substring(0, _CImage.IndexOf("|"c))
            lastindexof = _CImage.Substring(_CImage.LastIndexOf("|"c)).Trim("|")

            If File.Exists(indexof) Then
                If ChkFileIntegrity(lastindexof, indexof) Then
                    _cPUREIMAGE = Image.FromFile(indexof)
                Else
                    MsgBox("Invalid image, Please contact MIS Department.", MsgBoxStyle.Critical, "Error")
                    AddTimelyLogs("Client Management2", "Hash Code is not equal in the database.")
                    _CImage = "IMGNOTFOUND"
                End If
            Else
                MsgBox("Invalid image, Please contact MIS Department.", MsgBoxStyle.Critical, "Error")
                AddTimelyLogs("Client Management2", "Random string Already Exists.")
                _CImage = "IMGNOTFOUND"
            End If


NEXTLINE:   If _CSignature = "" Then GoTo COntinues
            indexof = SRCSignature & "\" & _CSignature.Substring(0, _CSignature.IndexOf("|"c))
            lastindexof = _CSignature.Substring(_CSignature.LastIndexOf("|"c)).Trim("|")

            If File.Exists(indexof) Then
                If ChkFileIntegrity(lastindexof, indexof) Then
                    _CSignaturePUre = Image.FromFile(indexof)
                Else
                    MsgBox("Invalid image, Please contact MIS Department.", MsgBoxStyle.Critical, "Error")
                    AddTimelyLogs("Client Management2", "Hash Code is not equal in the database.")
                    _CSignature = "IMGNOTFOUND"
                End If
            Else
                MsgBox("Invalid image, Please contact MIS Department.", MsgBoxStyle.Critical, "Error")
                AddTimelyLogs("Client Management2", "Random string Already Exists.")
                _CSignature = "IMGNOTFOUND"
            End If
        End With

COntinues:
        ' Loading Collections
        mySql = "SELECT * FROM " & CUSTOMER_PHONE & " WHERE CUSTID = " & _id
        mySql &= " ORDER BY PHONEID ASC"
        ds = LoadSQL(mySql)

        _custPhones = New Collections_Phone
        For Each cp As DataRow In ds.Tables(0).Rows
            Dim tmpCP As New PhoneNumber
            tmpCP.PhoneID = cp("PHONEID")
            tmpCP.CustomerID = cp("CUSTID")
            tmpCP.PhoneNumber = cp("PHONENUMBER")
            tmpCP.isPrimary = IIf(cp("ISPRIMARY") > 0, True, False)
            _custPhones.Add(tmpCP)
        Next

        mySql = "SELECT * FROM " & CUSTOMER_ID & " WHERE CUSTID = " & _id
        mySql &= " ORDER BY ID ASC"
        ds = LoadSQL(mySql)

        _custIDs = New Collections_ID
        For Each cID As DataRow In ds.Tables(0).Rows
            Dim tmpID As New NewIdentificationCard
            tmpID.ID = cID("ID")
            tmpID.CustomerID = cID("CUSTID")
            tmpID.IDType = cID("ID_TYPE")
            tmpID.IDNumber = cID("ID_NUMBER")
            tmpID.isPrimary = IIf(cID("ISPRIMARY") > 0, True, False)
            _custIDs.Add(tmpID)
        Next

        Console.WriteLine(String.Format("CustomerID: {0} is loaded.", id))
    End Sub


    Public Function FindCustomerByName(ByVal str As String) As DataSet
        Dim ds As DataSet
        Dim mySql As String = "SELECT * FROM " & CUSTOMER_TABLE
        mySql &= String.Format(" WHERE FIRSTNAME LIKE '%{0}%' OR MIDNAME LIKE '%{0}%' OR LASTNAME LIKE '%{0}%'", str)
        mySql &= " ORDER BY ID ASC"

        ds = LoadSQL(mySql, CUSTOMER_TABLE)
        If ds.Tables(0).Rows.Count = 1 Then _
            _id = ds.Tables(0).Rows(0).Item("ID")

        Return ds
    End Function

    Private Function ChkIfCustExists(ByVal fname As String, ByVal lname As String, ByVal bday As Date, Optional ByVal mname As String = "") As Boolean
        Dim mySql As String = String.Format("SELECT * FROM " & CUSTOMER_TABLE & " WHERE FIRSTNAME = '{0}' AND MIDNAME = '{1}' " _
                                           & "AND LASTNAME ='{2}' AND BIRTHDAY = '{3}'", fname, mname, lname, bday.ToShortDateString)
        Dim ds As DataSet = LoadSQL(mySql, CUSTOMER_TABLE)

        If ds.Tables(0).Rows.Count = 0 Then
            Dim mySql1 As String = String.Format("SELECT * FROM " & CUSTOMER_TABLE & " WHERE FIRSTNAME = '{0}' " _
                                         & "AND LASTNAME ='{1}' AND BIRTHDAY = '{2}'", fname, lname, bday.ToShortDateString)
            Dim ds1 As DataSet = LoadSQL(mySql1, CUSTOMER_TABLE)

            If ds1.Tables(0).Rows.Count >= 1 Then
                MsgBox("This customer was already registered" & vbCrLf & _
                       "Please try to search this customer!", MsgBoxStyle.Critical, "Error") : Return False
            End If
        End If

        If ds.Tables(0).Rows.Count >= 1 Then
            MsgBox("This customer was already registered" & vbCrLf & _
                   "Please try to search this customer!", MsgBoxStyle.Critical, "Error") : Return False
        End If
        Return True
    End Function

    Friend Function FindRanStrIfExists(ByVal randstr As String) As Boolean

        For Each LogFile In Directory.GetFiles(SRC)
            If LogFile = randstr Then
                Log_Report(String.Format("FileName already Exists for customer image: {0}.", randstr))
                Return False
            End If
        Next

        Return True
    End Function

    Friend Function FndRndmStrSignature(ByVal randstr As String) As Boolean

        For Each LogFile In Directory.GetFiles(SRCSignature)
            If LogFile = randstr Then
                Log_Report(String.Format("FileName already Exists for customer signature: {0}.", randstr))
                Return False
            End If
        Next

        Return True
    End Function

    Private Function ChkFileIntegrity(ByVal srcDB As String, ByVal srcFolder As String) As Boolean
        Dim srcIMG As String = GetFileMD5(srcFolder)

        If srcIMG <> srcDB Then
            Return False
        Else
            Return True
        End If
        Return True
    End Function

    Friend Sub UpdatePhone(ByVal ph As String)
        Dim mysql As String = "SELECT * FROM " & CUSTOMER_PHONE & " WHERE CUSTID = " & _id
        Dim ds As DataSet = LoadSQL(mysql, CUSTOMER_PHONE)

        If ds.Tables(0).Rows.Count = 0 Then Exit Sub

        ds.Tables(0).Rows(0).Item("PhoneNumber") = ph
        ds.Tables(0).Rows(0).Item("Isprimary") = 1
        database.SaveEntry(ds, False)
    End Sub


    Public Function LoadLastEntry() As Customer
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM " & CUSTOMER_TABLE & " ORDER BY ID ASC"
        ds = LoadSQL(mySql)

        Dim LastRow As Integer = ds.Tables(0).Rows.Count
        Load_CustomerByID(ds.Tables(0).Rows(LastRow - 1).Item("ID"))

        Return Me
    End Function

    Friend Sub AddIDentification(ByVal IDType As String)
        Dim mysql As String = "SELECT * FROM KYC_IDLIST WHERE IDTYPE = '" & IDType.ToString & "'"
        Dim ds As DataSet = LoadSQL(mysql, "KYC_IDLIST")

        If ds.Tables(0).Rows.Count = 0 Then

            Dim dsNewrow As DataRow
            dsNewrow = ds.Tables("KYC_IDLIST").NewRow

            With dsNewrow
                .Item("IDTYPE") = IDType
            End With
            ds.Tables("KYC_IDLIST").Rows.Add(dsNewrow)
            database.SaveEntry(ds)
        Else
            With ds.Tables(0).Rows(0)
                .Item("IDTYPE") = IDType
            End With
            database.SaveEntry(ds, False)
        End If
       
    End Sub
#End Region

End Class