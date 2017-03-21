Module Users_Access
    Dim mysql As String = String.Empty
    Public Function Verify_Access(ByVal priv_type As String) As String
        mysql = "SELECT * FROM TBL_USERLINE WHERE USERID = " & SYSTEM_USERIDX & " AND PRIVILEGE_TYPE = '" & priv_type & "'"
        Dim ds As DataSet = LoadSQL(mysql, "TBL_USERLINE")

        If ds.Tables(0).Rows(0).Item("ACCESS_TYPE") = "Full Access" Then
            Return "Full Access"
        End If

        If ds.Tables(0).Rows(0).Item("ACCESS_TYPE") = "Read Only" Then
            Return "Read Only"
        End If

        If ds.Tables(0).Rows(0).Item("ACCESS_TYPE") = "No Access" Then
            Return "No Access"
        End If

        Return Nothing
    End Function

   
End Module
