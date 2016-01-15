Module formSwitch

    Friend Enum FormName As Integer
        devForm = 0
        frmMTSend = 1 'Money Transfer
        frmPawning = 2
        frmInsurance = 3
        frmMTReceive = 4
        frmDollar = 5
        frmPawnItem = 6
        frmDollarSimple = 7
    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cl As Client)
        Select Case gotoForm
            Case FormName.devForm
                devClient.LoadClientInfo(cl)
            Case FormName.frmMTSend
                frmMoneyTransfer.LoadSenderInfo(cl)
            Case FormName.frmInsurance
                frmInsurance.LoadHolder(cl)
            Case FormName.frmMTReceive
                frmMoneyTransfer.LoadReceiverInfo(cl)
            Case FormName.frmPawnItem
                frmPawnItem.LoadClient(cl)
            Case FormName.frmDollarSimple
                frmDollorSimple.LoadClient(cl)
        End Select
    End Sub

End Module