
Module usersDateValUpdate
    Private maintable As String = "tbl_user_default"
    Dim mysql As String = String.Empty
  
    Friend Sub UserVal(ByVal AccntExpiry As Integer, ByVal psswordExpiry As Integer, _
                       ByVal failedAttmpt As Integer)
        mysql = "SELECT * FROM " & maintable & " WHERE USERNAME <> 'POSadmin' AND STATUS = 1"
        Dim ds As DataSet = LoadSQL(mysql, maintable)


        For Each user As DataRow In ds.Tables(0).Rows
            mysql = "SELECT * FROM " & maintable & " WHERE USERPASS  = '" & user.Item("USERPASS") & "'"
            Dim ds1 As DataSet = LoadSQL(mysql, maintable)


            Console.WriteLine(user.Item("USERNAME"))
            With ds1.Tables(0).Rows(0)
                .Item("PASSWORD_EXPIRY") = Now.AddDays(AccntExpiry)
                .Item("PASSWORD_AGE") = Now.AddDays(psswordExpiry)

                .Item("EXPIRY_COUNTER") = AccntExpiry
                .Item("FAILEDATTEMPNUM") = failedAttmpt

                database.SaveEntry(ds1, False)
            End With
        Next
    End Sub
End Module
