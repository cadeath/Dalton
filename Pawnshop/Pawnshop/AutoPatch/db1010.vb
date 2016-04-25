Module db1010
    Const ALLOWABLE_VERSION As String = "1.0.9"
    Const LATEST_VERSION As String = "1.0.10"

    Sub PatchUp()
        If Not isPatchable(ALLOWABLE_VERSION) Then Exit Sub

        Dim DROP_VIEW As String = "DROP VIEW PRINT_PAWNING;"
        Dim CREATE_NEW_PRINT_PAWNING As String
        Dim mySql As String
        mySql = "CREATE VIEW PRINT_PAWNING( "
        mySql &= vbCrLf & "  PAWNID, PAWNTICKET, LOANDATE, MATUDATE, "
        mySql &= vbCrLf & "  EXPIRYDATE, ITEMTYPE, PAWNER, FULLADDRESS, "
        mySql &= vbCrLf & "  PRINCIPAL, APPRAISAL, INTEREST, ADVINT,"
        mySql &= vbCrLf & "  SERVICECHARGE, NETAMOUNT, DESCRIPTION,"
        mySql &= vbCrLf & "  CONTACTNUMBER, ORNUM, ORDATE, PENALTY,"
        mySql &= vbCrLf & "  RENEWDUE, REDEEMDUE) "
        mySql &= vbCrLf & "AS "
        mySql &= vbCrLf & "SELECT "
        mySql &= vbCrLf & "  P.PAWNID, P.PAWNTICKET, P.LOANDATE, P.MATUDATE, P.EXPIRYDATE, P.ITEMTYPE, "
        mySql &= vbCrLf & "    C.FIRSTNAME || ' ' || C.LASTNAME AS PAWNER, "
        mySql &= vbCrLf & "    C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY AS FULLADDRESS,"
        mySql &= vbCrLf & "    P.PRINCIPAL, P.APPRAISAL, P.INTEREST, P.ADVINT, P.SERVICECHARGE,"
        mySql &= vbCrLf & "    P.NETAMOUNT, P.DESCRIPTION, C.PHONE1 AS CONTACTNUMBER,"
        mySql &= vbCrLf & "    P.ORNUM, P.ORDATE, P.PENALTY, P.RENEWDUE, P.REDEEMDUE"
        mySql &= vbCrLf & "FROM TBLPAWN P "
        mySql &= vbCrLf & "INNER JOIN TBLCLIENT C ON C.CLIENTID = P.CLIENTID;"

        CREATE_NEW_PRINT_PAWNING = mySql

        Try

            ' REMOVE VIEW
            RunCommand(DROP_VIEW)

            ' CREATE VIEW
            RunCommand(CREATE_NEW_PRINT_PAWNING)


            Database_Update(LATEST_VERSION)
            Log_Report("SYSTEM PATCHED UP FROM 1.0.9 TO 1.0.10")
        Catch ex As Exception
            Log_Report(ex.ToString & "[1.0.10]")
        End Try
    End Sub
End Module
