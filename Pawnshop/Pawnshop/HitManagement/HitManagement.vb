Module HitManagement

    Private CLID As Single
    Private FULLNAME As String
    Private isHIT As Boolean = False

    Const HIT_MAX As Integer = 3
    Friend Const dsName As String = "TBLHIT"

    Friend Sub do_PawningHit(ByVal cus As Customer, ByVal pt As Single)
        CLID = cus.CustomerID
        FULLNAME = String.Format("{0}, {1} {2}", cus.LastName, cus.FirstName, cus.Suffix)

        Dim ds As DataSet
        Dim mySql As String = "SELECT * FROM OPT "
        mySql &= "WHERE CLIENTID = " & CLID
        mySql &= " ORDER BY LOANDATE DESC"

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= HIT_MAX Then
            ds.Clear()

            mySql = "SELECT * FROM TBLHIT"
            Dim dsName As String = "TBLHIT"

            ds = LoadSQL(mySql, dsName)
            Dim dsNewRow As DataRow
            dsNewRow = ds.Tables(dsName).NewRow
            With dsNewRow
                .Item("HIT_DATE") = CurrentDate
                .Item("PAWNID") = CLID
                .Item("PAWNER") = FULLNAME
                .Item("PT") = pt
            End With
            ds.Tables(dsName).Rows.Add(dsNewRow)

            database.SaveEntry(ds)

            If DEV_MODE Then Log_Report("HIT FOUND")
        End If
    End Sub


    Friend Function Generate_HitReport(dt As Date) As String
        Dim mySql As String
        mySql = "SELECT DISTINCT H.HIT_DATE, H.PAWNID, H.PAWNER, C.BIRTHDAY, "
        mySql &= vbCrLf & "	(SELECT (CASE WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11)AND PH.ISPRIMARY = 1	"
        mySql &= vbCrLf & "	THEN PH.PHONENUMBER WHEN (CHAR_LENGTH(PH.PHONENUMBER)=11) THEN PH.PHONENUMBER	"
        mySql &= vbCrLf & "	ELSE NULL END)AS CONTACTNUMBER FROM KYC_PHONE PH LEFT JOIN KYC_CUSTOMERS CC ON CC.ID = PH.CUSTID	"
        mySql &= vbCrLf & "	WHERE CHAR_LENGTH(PH.PHONENUMBER)='11' AND PH.ISPRIMARY = 1	"
        mySql &= vbCrLf & "	OR CHAR_LENGTH(PH.PHONENUMBER)=11 AND PH.CUSTID =CC.ID ORDER BY PH.ISPRIMARY DESC ROWS 1),	"
        mySql &= vbCrLf & "C.STREET1 || ' ' || C.BRGY1 || ' ' || C.CITY1 || ' ' || C.PROVINCE1 AS FULLADDRESS,"
        mySql &= vbCrLf & "P.PAWNTICKET, CASE WHEN P.OLDTICKET = 0  THEN P.PRINCIPAL ELSE 0 END AS PRINCIPAL"
        mySql &= vbCrLf & "FROM TBLHIT H "
        mySql &= vbCrLf & "INNER JOIN OPT P ON P.CLIENTID = H.PAWNID "
        mySql &= vbCrLf & "INNER JOIN " & CUSTOMER_TABLE & " C ON C.ID = P.CLIENTID"
        mySql &= vbCrLf & "WHERE "
        mySql &= vbCrLf & String.Format(" H.HIT_DATE = '{0}'", dt.ToShortDateString)
        Return mySql
    End Function
End Module
