Module Fix_ORrenewedItem

    Friend Sub Fixing()
        Dim mySql As String
        mySql = "UPDATE OPT "
        mySql &= vbCrLf & "SET ORDATE = '01/01/0001', ORNUM = 0 ,DAYSOVERDUE=0 , PENALTY=0, RENEWDUE=0, REDEEMDUE=0"
        mySql &= vbCrLf & "WHERE STATUS = 'R' AND ORNUM <> 0"

        RunCommand(mySql)
    End Sub

End Module
