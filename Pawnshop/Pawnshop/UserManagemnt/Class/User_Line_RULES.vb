
Public Class User_Line_RULES
    Private fillData As String = "tbl_userline"
    Private mySql As String = String.Empty

#Region "Properties"
    Private _USERLINE_ID As Integer
    Public Property USERLINE_ID() As Integer
        Get
            Return _USERLINE_ID
        End Get
        Set(ByVal value As Integer)
            _USERLINE_ID = value
        End Set
    End Property

    Private _USERID As Integer
    Public Property USERID() As Integer
        Get
            Return _USERID
        End Get
        Set(ByVal value As Integer)
            _USERID = value
        End Set
    End Property

    Private _PRIVILEGE_TYPE As String
    Public Property PRIVILEGE_TYPE() As String
        Get
            Return _PRIVILEGE_TYPE
        End Get
        Set(ByVal value As String)
            _PRIVILEGE_TYPE = value
        End Set
    End Property


    Private _ACCESS_TYPE As String
    Public Property ACCESS_TYPE() As String
        Get
            Return _ACCESS_TYPE
        End Get
        Set(ByVal value As String)
            _ACCESS_TYPE = value
        End Set
    End Property

    Private _DATE_UPDATED_LINE As Date
    Public Property DATE_UPDATED_LINE() As Date
        Get
            Return _DATE_UPDATED_LINE
        End Get
        Set(ByVal value As Date)
            _DATE_UPDATED_LINE = value
        End Set
    End Property

    Private _DATE_CREATED_LINE As Date
    Public Property DATE_CREATED_LINE() As Date
        Get
            Return _DATE_CREATED_LINE
        End Get
        Set(ByVal value As Date)
            _DATE_CREATED_LINE = value
        End Set
    End Property

    Private _UsersRules As UserRuleCol
    Public Property UsersRules() As UserRuleCol
        Get
            Return _UsersRules
        End Get
        Set(ByVal value As UserRuleCol)
            _UsersRules = value
        End Set
    End Property

#End Region


#Region "FUNCTIONS AND PROCEDURES"
    Friend Sub LOAD_USER_RULES()
        mySql = String.Format("SELECT * FROM " & fillData & " WHERE USERID = '{0}'", IDX)
        Dim ds As DataSet = LoadSQL(mySql, fillData)

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("Unable to load user privilege.", MsgBoxStyle.Critical, "Error") : Exit Sub

        _UsersRules = New UserRuleCol
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim getUserRule As New User_Line_RULES
            With getUserRule
                .USERLINE_ID = dr.Item("Userline_ID")
                .USERID = dr.Item("UserID")
                .PRIVILEGE_TYPE = dr.Item("Privilege_Type")
                .ACCESS_TYPE = dr.Item("Access_type")
                .DATE_UPDATED_LINE = dr.Item("Date_Updated_line")
                .DATE_CREATED_LINE = dr.Item("Date_Created_line")
            End With
            _UsersRules.Add(getUserRule)

            Load_userline(dr)
        Next
    End Sub


    Public Sub Load_userline(ByVal dr As DataRow)
        With dr
            _USERLINE_ID = .Item("Userline_ID")
            _USERID = .Item("UserID")
            _PRIVILEGE_TYPE = .Item("Privilege_Type")
            _ACCESS_TYPE = .Item("Access_type")
            _DATE_UPDATED_LINE = .Item("Date_Updated_line")
            _DATE_CREATED_LINE = .Item("Date_Created_line")
        End With
    End Sub

    Function HasPrivilege(ByVal priv As String) As String
        Try
            For Each priv_acc As User_Line_RULES In _UsersRules
                If priv_acc.PRIVILEGE_TYPE = priv Then
                    If priv_acc.ACCESS_TYPE = "Full Access" Then
                        Return "Full Access"
                    ElseIf priv_acc.ACCESS_TYPE = "No Access" Then
                        Return "No Access"
                    ElseIf priv_acc.ACCESS_TYPE = "Read Only" Then
                        Return "Read Only"
                    End If
                End If
            Next
        Catch ex As Exception
            Return ""
        End Try

        Return ""
    End Function
#End Region
End Class
