Module PawningScheme

    Friend CELScheme As Boolean = True

    Friend Sub Notify_Renewal(PawnNotify As PawnTicket)

        Dim mySql As String = String.Format("SELECT * FROM TBLCLASS WHERE CLASSID = {0}", PawnNotify.CategoryID)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim Renewal_Limit As Integer = ds.Tables(0).Rows(0).Item("RENEWLIMIT")

        If Renewal_Limit - 1 <= PawnNotify.RenewalCount And Not Renewal_Limit = 0 Then
            MsgBox("THIS PAWNED ITEM WAS ALREADY BEEN RENEWED FOR 5 TIMES OR MORE" + vbCrLf + "PLEASE BE ADVICE", vbInformation + vbOKOnly + vbDefaultButton2, "RENEWAL NOTIFICATION")
        End If
    End Sub

    Friend Sub Notify_Renewal(ByVal pt As PawnTicket2)

    End Sub

End Module
