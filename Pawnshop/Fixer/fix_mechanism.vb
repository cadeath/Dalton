Module fix_mechanism
    Private mySql As String = ""
    Private fillData As String = ""
    Private ds As DataSet

    Function getClientID(ByVal firstName As String, ByVal lastName As String) As Integer
        mySql = "SELECT * FROM tblClient"
        mySql &= String.Format(" WHERE FIRSTNAME = '{0}' AND LASTNAME = '{1}'", firstName, lastName)

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If

        Return ds.Tables(0).Rows(0).Item("ClientID")
    End Function
End Module