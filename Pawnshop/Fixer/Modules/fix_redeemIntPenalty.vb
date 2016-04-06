''' <summary>
''' Fixing issues in 1110c
''' Recording Penalty and Interest for Redemptions without Interest and Penalty
''' Redeem Due is correct even the Interest and Penalty were recorded.
''' </summary>
''' <remarks></remarks>
Module fix_redeemIntPenalty

    Private PAWN As String = "TBLPAWN"

    Sub Main()
        Dim mySql As String = _
            "SELECT * FROM " & PAWN & _
            " WHERE PRINCIPAL = REDEEMDUE AND ADVINT <> 0 AND INTEREST <> 0 AND STATUS = 'X'" & _
            " ORDER BY ORNUM DESC "

        Dim ds As DataSet = LoadSQL(mySql, PAWN)
        If ds.Tables(PAWN).Rows.Count = 0 Then Exit Sub

        For Each dr As DataRow In ds.Tables(PAWN).Rows
            dr("INTEREST") = 0
            dr("PENALTY") = 0
        Next

        database.SaveEntry(ds, False)
        MsgBox(ds.Tables(0).Rows.Count & " FIXED.")
    End Sub
End Module