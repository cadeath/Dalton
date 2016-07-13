Module PawningScheme

    Friend CELScheme As Boolean = True

    Friend Sub Notify_Renewal()
        MsgBox("THIS PAWNED ITEM WAS ALREADY BEEN RENEWED FOR 5 TIMES OR MORE" + vbCrLf + "PLEASE BE ADVICE", vbInformation + vbYesNo + vbDefaultButton2, "RENEWAL NOTIFICATION")
    End Sub

End Module
