Public Class IdentificationCard

    Private _id As Integer
    Private _clientID As Integer
    Private _IDType As String = String.Empty
    Private _RefNum As String = String.Empty
    Private _Remarks As String = String.Empty
    Private fillData As String = "ShowID"

    Public ReadOnly Property ID As Integer
        Get
            Return _id
        End Get
    End Property

    Public Property ClientID As Integer
        Get
            Return _clientID
        End Get
        Set(ByVal value As Integer)
            _clientID = value
        End Set
    End Property

    Public Property IDType As String
        Get
            Return _IDType
        End Get
        Set(ByVal value As String)
            _IDType = value
        End Set
    End Property

    Public Property ReferenceNumber As String
        Get
            Return _RefNum
        End Get
        Set(ByVal value As String)
            _RefNum = value
        End Set
    End Property

    Public Property Remarks As String
        Get
            Return _Remarks
        End Get
        Set(ByVal value As String)
            _Remarks = value
        End Set
    End Property

    Public Function Save() As Boolean
        'Creating Virtual Database
        Dim ds As New DataSet, dt As New DataTable(fillData)

        'Constructing Database
        ds.Tables.Add(dt)
        With ds.Tables(fillData).Columns
            ' Primary not required
            '.Add(New DataColumn("id", GetType(Integer))) 'AutoIncrement
            .Add(New DataColumn("ClientID", GetType(Integer)))
            .Add(New DataColumn("IDType", GetType(String)))
            .Add(New DataColumn("RefNum", GetType(String)))
            .Add(New DataColumn("Remarks", GetType(String)))
        End With

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("ClientID") = _clientID
            .Item("IDType") = _IDType
            .Item("RefNum") = _RefNum
            .Item("Remarks") = _Remarks
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        Try
            database.SaveEntry(ds)
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function
End Class
