Module db1011
    Const ALLOWABLE_VERSION As String = "1.0.10"
    Const LATEST_VERSION As String = "1.0.11"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW MONEY_TRANSFER;"
        Dim CREATE_NEW_PRINT_PAWNING As String
        Dim mySql As String
        mySql = "CREATE VIEW MONEY_TRANSFER( "
        mySql &= vbCrLf & "  SERVICETYPE,  TRANSDATE,"
        mySql &= vbCrLf & "  MONEYTRANS,  REFNUM,"
        mySql &= vbCrLf & "  PAYOUT,  SENDOUT,"
        mySql &= vbCrLf & "  SERVICECHARGE,  COMMISSION,"
        mySql &= vbCrLf & "  NETAMOUNT,  SENDERNAME,"
        mySql &= vbCrLf & "  RECEIVERNAME)"
        mySql &= vbCrLf & "AS "
        mySql &= vbCrLf & "SELECT "
        mySql &= vbCrLf & "  ServiceType, TransDate,"
        mySql &= vbCrLf & "    CASE MoneyTrans "
        mySql &= vbCrLf & "      WHEN 0 THEN 'PAYOUT'"
        mySql &= vbCrLf & "      WHEN 1 THEN 'SENDIN'"
        mySql &= vbCrLf & "      ELSE 'NA'"
        mySql &= vbCrLf & "    END AS MoneyTrans,"
        mySql &= vbCrLf & "    CASE"
        mySql &= vbCrLf & "      WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 0"
        mySql &= vbCrLf & "      THEN 'ME# ' || LPAD(TransID,5,0)"
        mySql &= vbCrLf & "    WHEN ServiceType = 'Pera Padala' AND MoneyTrans = 1"
        mySql &= vbCrLf & "      THEN 'MR# ' || LPAD(TransID,5,0)"
        mySql &= vbCrLf & "      ELSE RefNum END as RefNum,"
        mySql &= vbCrLf & "    CASE MoneyTrans"
        mySql &= vbCrLf & "      WHEN 0 THEN AMOUNT "
        mySql &= vbCrLf & "      ELSE 0 END AS PAYOUT,"
        mySql &= vbCrLf & "    CASE MoneyTrans"
        mySql &= vbCrLf & "      WHEN 1 THEN AMOUNT "
        mySql &= vbCrLf & "      ELSE 0 END AS SENDOUT,"
        mySql &= vbCrLf & "    ServiceCharge,"
        mySql &= vbCrLf & "    Commission,"
        mySql &= vbCrLf & "    NETAMOUNT, SENDERNAME, RECEIVERNAME"
        mySql &= vbCrLf & "FROM "
        mySql &= vbCrLf & "  TBLMONEYTRANSFER"
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & "  Status = 'A';"

        CREATE_NEW_PRINT_PAWNING = mySql
        Console.WriteLine(mySql)

        Try

            ' REMOVE VIEW
            RunCommand(DROP_VIEW)

            ' CREATE VIEW
            RunCommand(CREATE_NEW_PRINT_PAWNING)


            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.10 TO 1.0.11")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.0.11]")
        End Try
    End Sub
End Module
