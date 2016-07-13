Module PawningScheme

    Friend CELScheme As Boolean = True

    Friend Sub Notify_Renewal(PawnNotify As PawnTicket)

        Dim mySql As String = String.Format("SELECT * FROM TBLCLASS WHERE CATID = {0}", PawnNotify.CategoryID)
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows(0).Item("RENEWLIMIT") >= PawnNotify.RenewalCount Then
            MsgBox("THIS PAWNED ITEM WAS ALREADY BEEN RENEWED FOR 5 TIMES OR MORE" + vbCrLf + "PLEASE BE ADVICE", vbInformation + vbYesNo + vbDefaultButton2, "RENEWAL NOTIFICATION")
        End If
    End Sub

End Module
