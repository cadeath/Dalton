Public Class MoneyTransfer

    Private fillData As String = "tblMoneyTransfer"
    Private fillData1 As String = "tbl_DailyTimeLog"
    Private filldata2 As String = "tblJournal"

#Region "Variables"
    Private _id As Integer
    Private _ref As String
    Private _date As Date
    Private _serviceType As String
    Private _transType As Integer = 0
    Private _client1 As Customer 'Sender
    Private _client2 As Customer 'Receiver
    Private _amount As Double = 0
    Private _location As String
    Private _service As Double = 0
    Private _netAmount As Double = 0
    Private _encoderID As Integer
    Private _status As String
    Private _bracket As String
#End Region

#Region "Properties"
    Public Property ID As Integer
        Set(ByVal value As Integer)
            _id = value
        End Set
        Get
            Return _id
        End Get
    End Property

    Private _transID As Single
    Public Property TransactionID() As Single
        Get
            Return _transID
        End Get
        Set(ByVal value As Single)
            _transID = value
        End Set
    End Property

    Public Property ReferenceNumber As String
        Set(ByVal value As String)
            _ref = value
        End Set
        Get
            Return _ref
        End Get
    End Property

    Public Property TransactionDate As Date
        Set(ByVal value As Date)
            _date = value
        End Set
        Get
            Return _date
        End Get
    End Property

    Public Property ServiceType As String
        Get
            Return _serviceType
        End Get
        Set(ByVal value As String)
            _serviceType = value
        End Set
    End Property

    Public Property TransactionType As Integer
        Set(ByVal value As Integer)
            _transType = value
        End Set
        Get
            Return _transType
        End Get
    End Property

    Public Property Sender As Customer
        Set(ByVal value As Customer)
            _client1 = value
        End Set
        Get
            Return _client1
        End Get
    End Property

    Public Property Receiver As Customer
        Set(ByVal value As Customer)
            _client2 = value
        End Set
        Get
            Return _client2
        End Get
    End Property

    Public Property TransferAmount As Double
        Set(ByVal value As Double)
            _amount = value
        End Set
        Get
            Return _amount
        End Get
    End Property

    Public Property Location As String
        Get
            Return _location
        End Get
        Set(ByVal value As String)
            _location = value
        End Set
    End Property

    Public Property ServiceCharge As Double
        Set(ByVal value As Double)
            _service = value
        End Set
        Get
            Return _service
        End Get
    End Property

    Public Property NetAmount As Double
        Set(ByVal value As Double)
            _netAmount = value
        End Set
        Get
            Return _netAmount
        End Get
    End Property

    Public Property Status As String
        Set(ByVal value As String)
            _status = value
        End Set
        Get
            Return _status
        End Get
    End Property

    Private _commission As Double
    Public Property Commission() As Double
        Get
            Return _commission
        End Get
        Set(ByVal value As Double)
            _commission = value
        End Set
    End Property


    Public Property EncoderID As Integer
        Set(ByVal value As Integer)
            _encoderID = value
        End Set
        Get
            Return _encoderID
        End Get
    End Property

    Public Property Bracket As String
        Set(ByVal value As String)
            _bracket = value
        End Set
        Get
            Return _bracket
        End Get
    End Property
#End Region

#Region "Procedures and Functions"
    Public Sub LoadTransaction(ByVal id As Integer)
        Dim ds As DataSet, mySql As String
        mySql = "SELECT * FROM tblMoneyTransfer WHERE ID = " & id
        ds = LoadSQL(mySql)

        loadByRow(ds.Tables(0).Rows(0))
    End Sub

    Public Sub LoadTransactionByRow(ByVal dr As DataRow)
        loadByRow(dr)
    End Sub

    Private Sub loadByRow(ByVal dr As DataRow)
        With dr
            _id = .Item("ID")
            _transID = .Item("TransID")
            _transType = .Item("MoneyTrans")
            _serviceType = .Item("ServiceType")
            Dim tmpClient As New Customer
            tmpClient.Load_CustomerByID(.Item("SenderID"))
            _client1 = tmpClient
            Dim tmpClient2 As New Customer
            tmpClient2.Load_CustomerByID(.Item("ReceiverID"))
            _client2 = tmpClient2
            _ref = .Item("RefNum")
            _amount = .Item("Amount")
            _location = .Item("location")
            _date = .Item("TransDate")
            _service = .Item("ServiceCharge")
            _netAmount = .Item("NetAmount")
            _encoderID = .Item("EncoderID")
            _status = .Item("Status")
        End With
    End Sub

    Public Sub Save()
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblMoneyTransfer"
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("MoneyTrans") = _transType
            .Item("ServiceType") = _serviceType
            .Item("TransDate") = _date
            .Item("TransID") = _transID
            .Item("SenderID") = _client1.CustomerID
            .Item("SenderName") = String.Format("{0} {1}", _client1.FirstName, _client1.LastName)
            .Item("ReceiverID") = _client2.CustomerID
            .Item("ReceiverName") = String.Format("{0} {1}", _client2.FirstName, _client2.LastName)
            .Item("RefNum") = _ref
            .Item("Amount") = _amount
            .Item("Location") = _location
            .Item("ServiceCharge") = _service
            .Item("Commission") = _commission
            .Item("NetAmount") = _netAmount
            .Item("Status") = _status
            .Item("EncoderID") = _encoderID
            .Item("SystemInfo") = Now
            .Item("Bracket") = _bracket
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Sub VoidTransaction(ByVal reason As String)
        If reason = "" Then Exit Sub

        Dim mySql As String = "SELECT * FROM " & fillData & " WHERE ID = " & _id
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        ds.Tables(0).Rows(0).Item("Status") = "V"
        ds.Tables(0).Rows(0).Item("Remarks") = reason
        database.SaveEntry(ds, False)
        Dim tmpMoneyTransfer As Integer = ds.Tables(0).Rows(0).Item("ENCODERID")
    
        Dim MoneyTransID As Integer = frmMTlist.lvMoneyTransfer.FocusedItem.Tag
        LoadById(_id)
        Dim SrcStr As String = ""
        Select Case _serviceType
            Case "Pera Padala", "Pera Padala - PMFTC"
                If TransactionType = 0 Then
                    'Send
                    SrcStr = "ME# " & _transID
                Else
                    SrcStr = "MR# " & _transID
                End If
            Case "Western Union - Local", "Western Union - Intl"
                SrcStr = "WE|Ref# " & _ref
            Case "Cebuana Llhuiller"
                SrcStr = "CL|Ref# " & _ref
            Case "GPRS to GPRS"
                SrcStr = "G2G|Ref# " & _ref
            Case "GPRS to Smart Money", "GPRS to BANK (UCPB/PNB)", "GPRS to BANK (BDO/Chinabank)", _
                    "GPRS to BANK (DBP)", "GPRS to BANK (MetroBank)", "GPRS to BANK (Maybank/LandBank)", _
                    "iREMIT to GPRS", "NYBP/Transfast to GPRS", "GPRS to Moneygram"
                SrcStr = "GPRS|Ref# " & _ref
            Case "Smartmoney To GPRS", "Moneygram to GPRS"
                SrcStr = "GPRS_R|Ref# " & _ref
        End Select

        Dim strModname1 As String = String.Empty, strModname2 As String = String.Empty
        Dim tmpService As String = _serviceType + IIf(_transType = 0, " OUT", " IN")
        Select Case tmpService
            Case "Pera Padala OUT"
                strModname1 = "PERA PADALA OUT"
                strModname2 = strModname1
            Case "Pera Padala IN"
                strModname1 = "PERA PADALA IN"
                strModname2 = strModname1

            Case "Pera Padala - PMFTC OUT"
                strModname1 = "PERA PADALA OUT"
                strModname2 = "Pera Padala - PMFTC OUT"
            Case "Pera Padala - PMFTC IN"
                strModname1 = "PERA PADALA IN"
                strModname2 = "Pera Padala - PMFTC IN"

            Case "Western Union - Local OUT", "Western Union - Intl OUT"
                strModname1 = "WESTERN UNION OUT"
                strModname2 = strModname1
            Case "Western Union - Local IN", "Western Union - Intl IN"
                strModname1 = "WESTERN UNION IN"
                strModname2 = strModname1

            Case "Cebuana Llhuiller OUT"
                strModname1 = "Cebuana OUT"
                strModname2 = strModname1
            Case "Cebuana Llhuiller IN"
                strModname1 = "Cebuana IN"
                strModname2 = strModname1

            Case "GPRS to GPRS OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to GPRS OUT"
            Case "GPRS to GPRS IN"
                strModname1 = "GPRS IN"
                strModname2 = "GPRS to GPRS IN"

            Case "GPRS to Smart Money OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to Smart Money OUT"
            
            Case "GPRS to BANK (UCPB/PNB) OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to BANK (UCPB/PNB) OUT"

            Case "GPRS to BANK (BDO/Chinabank) OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to BANK (BDO/Chinabank) OUT"

            Case "GPRS to BANK (DBP) OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to BANK (DBP) OUT"

            Case "GPRS to BANK (MetroBank) OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to BANK (MetroBank) OUT"

            Case "GPRS to BANK (Maybank/LandBank) OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to BANK (Maybank/LandBank) OUT"

            Case "iREMIT to GPRS IN"
                strModname1 = "GPRS IN"
                strModname2 = "iREMIT to GPRS IN"

            Case "NYBP/Transfast to GPRS IN"
                strModname1 = "GPRS IN"
                strModname2 = "NYBP/Transfast to GPRS IN"

            Case "GPRS to Moneygram OUT"
                strModname1 = "GPRS OUT"
                strModname2 = "GPRS to Moneygram OUT"

            Case "Smartmoney To GPRS IN"
                strModname1 = "GPRS IN"
                strModname2 = "Smartmoney To GPRS IN"

            Case "Moneygram to GPRS IN"
                strModname1 = "GPRS IN"
                strModname2 = "Moneygram to GPRS IN"

        End Select

        Dim NewOtp As New ClassOtp("VOID MONEYTRANSFE R", diagGeneralOTP.txtPIN.Text, SrcStr)
        TransactionVoidSave(strModname1, tmpMoneyTransfer, POSuser.UserID, SrcStr & " " & reason)

        RemoveJournal(MoneyTransID, , strModname2)
        RemoveDailyTimeLog(MoneyTransID, "1", strModname1)

        Console.WriteLine(String.Format("Transaction #{0} Void.", ds.Tables(0).Rows(0).Item("RefNum")))
    End Sub

    Public Sub LoadById(id As Integer)
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= " WHERE ID = " & id

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then _
            MsgBox("TRANSACTION NOT FOUND", MsgBoxStyle.Critical, "DEVELOPER WARNING") : Exit Sub

        Me.loadByRow(ds.Tables(0).Rows(0))
    End Sub

    Public Function LoadLastIDNumberMoneyTransfer() As Single
        Dim mySql As String = "SELECT * FROM TBLMONEYTRANSFER ORDER by ID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("ID")
    End Function

    'Public Function LoadServiceType() As String
    '    Dim mysql1 As String = "SELECT * FROM tblmoneytransfer WHERE ID =" & frmMTlist.Label2.Text

    '    Dim ds As DataSet = LoadSQL(mysql1, fillData)
    '    If ds.Tables(0).Rows.Count = 0 Then
    '        Return 0
    '    End If
    '    Return ds.Tables(0).Rows(0).Item("Servicetype")
    'End Function

    'Public Function LoadMoneyTrans() As String
    '    Dim mysql1 As String = "SELECT * "
    '    mysql1 &= "FROM tblmoneytransfer WHERE ID =" & frmMTlist.Label2.Text

    '    Dim ds As DataSet = LoadSQL(mysql1, fillData)
    '    If ds.Tables(0).Rows.Count = 0 Then
    '        Return 0
    '    End If
    '    Return ds.Tables(0).Rows(0).Item("MoneyTrans")
    'End Function

#End Region
End Class
