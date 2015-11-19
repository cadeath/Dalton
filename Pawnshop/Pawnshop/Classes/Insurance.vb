Imports System.Data.Odbc

Public Class Insurance

    Private fillData As String = "tblInsurance"
    Private mySql As String = "SELECT * FROM "

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

    Private _client As Client
    Public Property Client() As Client
        Get
            Return _client
        End Get
        Set(ByVal value As Client)
            _client = value
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

#End Region

#Region "Procedures"
    
    Public Sub SaveInsurance()
        Dim ds As DataSet = LoadSQL(mySql & fillData, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("CoiNo") = _coiNo
            .Item("ClientID") = _client.ID
            .Item("TransDate") = _transDate
            .Item("Amount") = _amount
            .Item("ValidDate") = _validity
            .Item("EncoderID") = _encoderID
            .Item("SystemInfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub

    Public Sub LoadInsurance(ByVal id As String)
        mySql = "SELECT * FROM " & fillData & " WHERE InsuranceID = " & id
        Dim ds As DataSet = LoadSQL(mySql)

        LoadByRow(ds.Tables(fillData).Rows(0))
    End Sub

    Public Sub LoadByRow(ByVal dr As DataRow)
        With dr
            _coiNo = .Item("CoiNo")
            Dim tmpC As New Client
            tmpC.LoadClient(.Item("ClientID"))
            _client = tmpC
            _transDate = .Item("TransDate")
            _amount = .Item("Amount")
            _validity = .Item("ValidDate")
            _encoderID = .Item("EncoderID")
        End With
    End Sub
#End Region

End Class
