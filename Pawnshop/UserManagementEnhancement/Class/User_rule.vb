Imports DeathCodez.Security

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

    Private _Access_Type As Boolean
    Public Property Access_Type() As Boolean
        Get
            Return _Access_Type
        End Get
        Set(ByVal value As Boolean)
            _Access_Type = value
        End Set
    End Property


#End Region

#Region "Procedures and Functions"

    Friend Function adpri_Save(ByVal priv_type As String) As Boolean
        mySql = String.Format("SELECT * FROM " & fillData & " WHERE PRIVILEGE_TYPE = '{0}'", priv_type)
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(0).Rows.Count > 0 Then
            MsgBox("This Privilege type is already Exists.", MsgBoxStyle.Critical, "Warning")
            Return False
        End If

        Dim dsnewRow As DataRow
        dsnewRow = ds.Tables(fillData).NewRow
        With dsnewRow
            .Item("Privilege_type") = _Privilege_Type
            .Item("Access_Type") = _Access_Type
        End With
        ds.Tables(0).Rows.Add(dsnewRow)
        database.SaveEntry(ds)

        Return True
    End Function

#End Region
End Class
