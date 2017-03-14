Imports System.Data.Odbc

Public Class Insurance

    Private fillData As String = "tblInsurance"
    Private mySql As String = "SELECT * FROM "
    Const TBL As String = "TBL_DAILYTIMELOG"

#Region "Properties and Variables"
    Private _id As Integer
    Public Property ID() As Integer
        Get
            Return _id
        End Get
        Set(ByVal value As Integer)
            _id = value
        End Set
    End Property

    Private _coiNo As Integer
    Public Property COInumber() As Integer
        Get
            Return _coiNo
        End Get
        Set(ByVal value As Integer)
            _coiNo = value
        End Set
    End Property

    Private _refNum As String
    Public Property TicketNum() As String
        Get
            Return _refNum
        End Get
        Set(ByVal value As String)
            _refNum = value
        End Set
    End Property

    Private _client As Client
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
            _fullName = String.Format("{0} {1}", _client.FirstName, _client.LastName)
        End Set
    End Property

    Private _fullName As String
    Public Property ClientName() As String
        Get
            Return _fullName
        End Get
        Set(ByVal value As String)
            _fullName = value
        End Set
    End Property

    Private _transDate As Date
    Public Property TransactionDate() As Date
        Get
            Return _transDate
        End Get
        Set(ByVal value As Date)
            _transDate = value
        End Set
    End Property

    Private _amount As Double
    Public Property Amount() As Double
        Get
            Return _amount
        End Get
        Set(ByVal value As Double)
            _amount = value
        End Set
    End Property

    Private _status As String
    Public Property Status() As String
        Get
            Return _status
        End Get
        Set(ByVal value As String)
            _status = value
        End Set
    End Property

    Private _validity As Date
    Public Property ValidDate() As Date
        Get
            Return _validity
        End Get
        Set(ByVal value As Date)
            _validity = value
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
    Private _modname As String
    Public Property Modname() As Integer
        Get
            Return _modname
        End Get
        Set(ByVal value As Integer)
            _modname = value
        End Set
    End Property

#End Region

#Region "Procedures"
    
    Public Sub SaveInsurance()
        Dim ds As DataSet = LoadSQL(mySql & fillData, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("CoiNo") = _coiNo
            .Item("PawnTicket") = _refNum
            .Item("ClientID") = _client.ID
            .Item("ClientName") = _fullName
            .Item("TransDate") = _transDate
            .Item("Amount") = _amount
            .Item("ValidDate") = _validity
            .Item("Status") = "A"
            .Item("EncoderID") = _encoderID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Sub LoadInsurance(ByVal id As String)
        mySql = "SELECT * FROM " & fillData & " WHERE InsuranceID = " & id
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        LoadByRow(ds.Tables(fillData).Rows(0))
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        With dr
            _id = .Item("InsuranceID")
            _coiNo = .Item("CoiNo")
            _refNum = .Item("PawnTicket")
            Dim tmpC As New Client
            tmpC.LoadClient(.Item("ClientID"))
            _client = tmpC
            _fullName = String.Format("{0} {1}", _client.FirstName, _client.LastName)
            _transDate = .Item("TransDate")
            _amount = .Item("Amount")
            _status = .Item("Status")
            _validity = .Item("ValidDate")
            _encoderID = .Item("EncoderID")
        End With
    End Sub

    Public Sub VoidTransaction()
        _status = "V"
        ' Dim COINum As String = String.Format("{000000}", Me.COInumber)
        mySql = "SELECT * FROM " & fillData & " WHERE InsuranceID = " & _id
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim InsuranceID As Integer
        Dim TransactionName As String = "INSURANCE"
        InsuranceID = frmInsurance.lbltransid.Text

        ds.Tables(fillData).Rows(0).Item("Status") = _status
        SaveEntry(ds, False)

        ds.Clear()
        mySql = "Select * From tblMaintenance Where Opt_Keys = 'INS Count'"
        ds = LoadSQL(mySql, "tblMaintenance")
        ds.Tables(0).Rows(0).Item("Opt_Values") = ds.Tables(0).Rows(0).Item("Opt_Values") - 1
        SaveEntry(ds, False)
        InventoryController.AddInventory("IND 00001", 1)

        'mySql = "SELECT * FROM DOC WHERE CODE = '" & "COI# " & _coiNo & "'"
        'ds = LoadSQL(mySql, "Doc")
        'ds.Tables(0).Rows(0).Item("Status") = "V"
        'SaveEntry(ds, False)
        'InventoryController.AddInventory("IND 00001", 1)

        Dim NewOtp As New ClassOtp("VOID INSURANCE", diagOTP.txtPIN.Text, "COI# " & COInumber)
        TransactionVoidSave(TransactionName, EncoderID, POSuser.UserID, "COI# " & COInumber)
        RemoveDailyTimeLog(InsuranceID, "1", TransactionName)
    End Sub

    Public Function LoadLastIDNumberInsurance() As Single
        Dim mySql As String = "SELECT * FROM TBLINSURANCE ORDER BY INSURANCEID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("INSURANCEID")
    End Function

    Friend Sub UpdateInsurance()
        Dim mysql As String = "Select * From TBLINSURANCE Where INSURANCEID = " & _id
        Dim fillData As String = "TBLINSURANCE"
        Dim ds As DataSet = LoadSQL(mysql, fillData)

        With ds.Tables(fillData).Rows(0)
            .Item("Pawnticket") = _refNum
        End With
        database.SaveEntry(ds, False)
    End Sub
#End Region

End Class
