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
        frmMoneyExchange = 8
        frmAdminPanel = 9

        frmPawningV2_Client = 10
        frmPawningV2_Specs = 11
        frmPawningV2_Claimer = 12
        frmPawningV2_SpecsValue = 13
        frmPawningV2_InterestScheme = 14

        Coi = 15
        layAway = 16
        layAwayExist = 17

    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cl As Customer)
        Select Case gotoForm
            'Case FormName.devForm
            '    devClient.LoadClientInfo(cl)
            'Case FormName.frmMTSend
            '    frmMoneyTransfer.LoadSenderInfo(cl)
            'Case FormName.frmInsurance
            '    frmInsurance.LoadHolder(cl)
            'Case FormName.frmMTReceive
            '    frmMoneyTransfer.LoadReceiverInfo(cl)
            'Case FormName.frmPawnItem
            '    frmPawnItem.LoadClient(cl)
            'Case FormName.frmDollarSimple
            '    frmDollorSimple.LoadClient(cl)
            'Case FormName.frmMoneyExchange
            '    frmmoneyexchange.LoadClient(cl)

            'Case FormName.frmPawningV2_Client
            '    frmPawningItemNew.LoadClient(cl)
            'Case FormName.frmPawningV2_Claimer
            '    frmPawningItemNew.LoadCliamer(cl)

            'Case FormName.layAway
            '    frmLayAway.LoadClient(cl)
            'Case FormName.layAwayExist
            '    frmAddCustomer.LoadClient(cl)
        End Select
    End Sub
End Module