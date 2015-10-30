Module formSwitch

    Friend Enum FormName As Integer
        devForm = 0
        frmMTSend = 1 'Money Transfer
        frmPawning = 2
        frmMTReceive = 4
    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cl As Client)
        Select Case gotoForm
            Case FormName.devForm
                devClient.LoadClientInfo(cl)
            Case FormName.frmMTSend
                frmMoneyTransfer.LoadSenderInfo(cl)
            Case FormName.frmPawning
                frmNewloan.LoadPawnerInfo(cl)
            Case FormName.frmMTReceive
                frmMoneyTransfer.LoadReceiverInfo(cl)
        End Select
    End Sub

End Module