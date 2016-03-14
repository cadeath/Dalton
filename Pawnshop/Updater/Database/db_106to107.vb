Module db_106to107

    ' Fixing Insurance Table
    ' Converting PawnTicket data type INTEGER
    ' into data type VAR(20) and use it as
    ' References Number

    Private mySql As String

    Friend Sub do_fixing()
        Fix_InsuranceTable()
    End Sub

    Private Sub Fix_InsuranceTable()
        mySql = "ALTER TABLE TBLINSURANCE "
        mySql &= "ALTER COLUMN PAWNTICKET "
        mySql &= "TYPE VARCHAR(20);"

        RunCommand(mySql)
    End Sub

End Module