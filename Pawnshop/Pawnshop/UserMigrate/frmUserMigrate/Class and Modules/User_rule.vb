

Public Class User_rule

    Private fillData As String = "tbl_userRule"
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

    Private _Privilege_Type As String
    Public Property Privilege_Type() As String
        Get
            Return _Privilege_Type
        End Get
        Set(ByVal value As String)
            _Privilege_Type = value
        End Set
    End Property

    Private _Access_Type As String
    Public Property Access_Type() As String
        Get
            Return _Access_Type
        End Get
        Set(ByVal value As String)
            _Access_Type = value
        End Set
    End Property

#End Region

#Region "Procedures and Functions"

    Friend Sub adpri_Save(ByVal priv_type As String)
        mySql = String.Format("SELECT * FROM " & fillData & " WHERE PRIVILEGE_TYPE = '{0}'", priv_type)
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(0).Rows.Count > 0 Then
            With ds.Tables(0).Rows(0)
                .Item("Privilege_type") = _Privilege_Type
            End With
            database.SaveEntry(ds, False)
            Exit Sub
        End If

        Dim dsnewRow As DataRow
        dsnewRow = ds.Tables(fillData).NewRow
        With dsnewRow
            .Item("Privilege_type") = _Privilege_Type
        End With
        ds.Tables(0).Rows.Add(dsnewRow)
        database.SaveEntry(ds)
    End Sub

#End Region
End Class
