Module Fixing_Mlang

    Private EXTRACT_TABLES() As String = _
        {"tblBORROW", "tblCASHCOUNT", "tblCASHTRANS", "tblCLIENT", "tblDAILY", "tblDOLLAR", _
         "tblIDENTIFICATION", "tblINSURANCE", "tblJOURNAL", "tblMONEYTRANSFER", "tblPAWN"}
    Private UPDATE_TABLES() As String = _
        {"tblMAINTENANCE", "tbl_GAMIT"}

    Private mySql As String, fillData As String
    Private ds As DataSet

    Private Function CheckTables() As Boolean
        For Each tbl In EXTRACT_TABLES
            mySql = "SELECT FIRST 1 * FROM " & tbl
            Try
                ds = LoadSQL(mySql)
            Catch ex As Exception
                MsgBox(String.Format("Table {0} not found", tbl))
                Return False
            End Try
        Next

        Return True
    End Function
End Module