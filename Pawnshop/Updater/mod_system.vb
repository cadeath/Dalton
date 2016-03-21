Module mod_system

    Sub Developers_Note(str As String)
        Console.WriteLine(String.Format("[{0}] ", Now.ToString("hh:mm:ss")) & str)
    End Sub

    Function isAllowed(ByVal allow As String) As Boolean
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblMaintenance WHERE OPT_KEYS = 'DBVersion'"
        ds = LoadSQL(mySql)

        If allow = ds.Tables(0).Rows(0).Item("OPT_VALUES") Then
            Return True
        End If

        Return False
    End Function

    Sub Database_Update(str As String)
        Dim mySql As String = "UPDATE tblMaintenance"
        mySql &= String.Format(" SET OPT_VALUES = '{0}' ", str)
        mySql &= "WHERE OPT_KEYS = 'DBVersion'"

        RunCommand(mySql)
    End Sub

    Function isUpdated() As Boolean
        Dim ds As DataSet, mySql As String
        mySql = "SELECT * FROM tblMaintenance WHERE OPT_KEYS = 'DBVersion'"
        ds = LoadSQL(mySql)

        If ds.Tables(0).Rows(0).Item("OPT_VALUES") = frmMain.LATEST_DBVERSION Then
            Return True
        End If

        Return False
    End Function
End Module
