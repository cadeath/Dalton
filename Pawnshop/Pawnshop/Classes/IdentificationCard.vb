'Changelog
' v1.1
'  - Fix ID selected

Public Class IdentificationCard

#Region "Variables"
    Private _id As Integer
    Private _clientID As Integer
    Private _IDType As String = String.Empty
    Private _RefNum As String = String.Empty
    Private _Remarks As String = String.Empty
    Private _isSelected As Boolean = 0
    Private fillData As String = "tblidentification"
#End Region

#Region "Properties"
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

    Public Property isSelected As Boolean
        Set(ByVal value As Boolean)
            _isSelected = value
        End Set
        Get
            Return _isSelected
        End Get
    End Property
#End Region

#Region "Functions and Procedures"
    Public Function Save() As Boolean
        Dim ds As New DataSet, mySql As String = "SELECT * FROM " & fillData
        ds = LoadSQL(mySql, fillData)

        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow
        With dsNewRow
            .Item("ClientID") = _clientID
            .Item("IDType") = _IDType
            .Item("RefNum") = _RefNum
            .Item("isSelected") = _isSelected
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

    Public Function Modify() As Boolean
        Dim mySql As String, ds As DataSet

        mySql = "SELECT * FROM tblIdentification WHERE id = " & Me.ID
        ds = LoadSQL(mySql, fillData)

        With ds.Tables(0).Rows(0)
            .Item("IDType") = _IDType
            .Item("RefNum") = _RefNum
            .Item("Remarks") = _Remarks
            .Item("isSelected") = _isSelected
        End With

        database.SaveEntry(ds, False)

        Return True
    End Function

    Public Sub Selected()
        _isSelected = True
    End Sub

    Private Sub ClearSelected()
        Dim mySql As String

        mySql = "SELECT * FROM tblIdentification WHERE ClientID = " & Me.ClientID
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        For Each dr As DataRow In ds.Tables(0).Rows
            With dr
                .Item("isSelected") = 0
            End With
        Next
        database.SaveEntry(ds, False) 'Deselect all
    End Sub

    Public Sub LoadID(ByVal id As Integer)
        Dim mySql As String = "SELECT * FROM tblIdentification WHERE id = " & id
        Dim ds As DataSet = LoadSQL(mySql)

        With ds.Tables(0).Rows(0)
            _id = .Item("id")
            _clientID = .Item("clientID")
            _IDType = .Item("IDType")
            _RefNum = .Item("RefNum")
            _Remarks = .Item("Remarks")
            _isSelected = .Item("isSelected")
        End With
    End Sub
#End Region
End Class
