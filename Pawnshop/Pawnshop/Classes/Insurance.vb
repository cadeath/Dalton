Imports System.Data.Odbc

Public Class Insurance

#Region "Variables"
    Private _id As Integer = 0
    Private _coi As Integer = 0
    Private _cid As Integer = 0
    Private _date As Date
    Private _amount As Integer = 0
    Private _valid As Date

    Private fillData As String = "tblInsurance"
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
    Public Property COI As Integer
        Get
            Return _coi
        End Get
        Set(ByVal value As Integer)
            _coi = value
        End Set
    End Property
    Public Property CID As Integer
        Get
            Return _cid
        End Get
        Set(ByVal value As Integer)
            _cid = value
        End Set
    End Property
    Public Property TransDate As Date
        Get
            Return _date
        End Get
        Set(ByVal value As Date)
            _date = value
        End Set
    End Property
    Public Property Amount As Integer
        Get
            Return _amount
        End Get
        Set(ByVal value As Integer)
            _amount = value
        End Set
    End Property

    Public Property ValidDate
        Get
            Return _valid
        End Get
        Set(ByVal value)
            _valid = value
        End Set
    End Property
#End Region

    Public Sub Save()
        Dim ds As New DataSet, dt As New DataTable(fillData)

        ds.Tables.Add(dt)
        With ds.Tables(fillData).Columns
            .Add(New DataColumn("insuranceid", GetType(Integer)))
            .Add(New DataColumn("ciono", GetType(Integer)))
            .Add(New DataColumn("clientid", GetType(Integer)))
            .Add(New DataColumn("transdate", GetType(Date)))
            .Add(New DataColumn("amount", GetType(Double)))
            .Add(New DataColumn("validdate", GetType(Date)))
            .Add(New DataColumn("encoderid", GetType(Integer)))
            .Add(New DataColumn("systeminfo", GetType(Date)))
        End With
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("ciono") = _coi
            .Item("clienid") = _cid
            .Item("transdate") = _date
            .Item("amount") = _amount
            .Item("validdate") = _valid
            .Item("encoderid") = UserID
            .Item("systeminfo") = Now
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
    End Sub
End Class
