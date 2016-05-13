Module HitManagement

    Private CLID As Single
    Private FULLNAME As String
    Private isHIT As Boolean = False

    Const HIT_MAX As Integer = 3
    Friend Const dsName As String = "TBLHIT"

    Friend Sub do_PawningHit(cl As Client, pt As Single)
        CLID = cl.ID
        FULLNAME = String.Format("{0}, {1} {2}", cl.LastName, cl.FirstName, cl.Suffix)

        Dim ds As DataSet
        Dim mySql As String = "SELECT * FROM TBLPAWN "
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
        ' TODO:
        ' SQL IS NOT RIGHT
        Dim mySql As String
        mySql = "SELECT H.PAWNID, H.PAWNER, C.BIRTHDAY, "
        mySql &= vbCrLf & "C.ADDR_STREET || ' ' || C.ADDR_BRGY || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE AS FULLADDRESS, "
        mySql &= vbCrLf & "    C.BIRTHDAY, C.PHONE1, C.PHONE2, P.PAWNTICKET, P.PRINCIPAL"
        mySql &= vbCrLf & "FROM TBLHIT H "
        mySql &= vbCrLf & "RIGHT JOIN TBLPAWN P "
        mySql &= vbCrLf & "ON H.PAWNID = P.CLIENTID "
        mySql &= vbCrLf & "INNER JOIN TBLCLIENT C "
        mySql &= vbCrLf & "ON C.CLIENTID = H.PAWNID "
        mySql &= vbCrLf & String.Format("WHERE HIT_DATE = '{0}' ", dt.ToShortDateString)
        mySql &= vbCrLf & "ORDER H.PAWNER ASC"

        Return mySql
    End Function
End Module