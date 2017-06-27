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

    'Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cl As Client)
    '    Select Case gotoForm
    '        Case FormName.devForm
    '            devClient.LoadClientInfo(cl)
    '        Case FormName.frmMTSend
    '            frmMoneyTransfer.LoadSenderInfo(cl)
    '        Case FormName.frmInsurance
    '            frmInsurance.LoadHolder(cl)
    '        Case FormName.frmMTReceive
    '            frmMoneyTransfer.LoadReceiverInfo(cl)
    '        Case FormName.frmPawnItem
    '            frmPawnItem.LoadClient(cl)
    '        Case FormName.frmDollarSimple
    '            frmDollorSimple.LoadClient(cl)
    '        Case FormName.frmMoneyExchange
    '            frmmoneyexchange.LoadClient(cl)

    '        Case FormName.frmPawningV2_Client
    '            frmPawningItemNew.LoadClient(cl)
    '        Case FormName.frmPawningV2_Claimer
    '            frmPawningItemNew.LoadCliamer(cl)

    '        Case FormName.layAway
    '            frmLayAway.LoadClient(cl)
    '        Case FormName.layAwayExist
    '            frmAddCustomer.LoadClient(cl)
    '    End Select
    'End Sub

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cus As Customer)
        Select Case gotoForm
            Case FormName.frmMTSend
                frmMoneyTransfer.LoadSenderInfo(cus)
            Case FormName.frmInsurance
                frmInsurance.LoadHolder(cus)
            Case FormName.frmMTReceive
                frmMoneyTransfer.LoadReceiverInfo(cus)
            Case FormName.frmMoneyExchange
                frmmoneyexchange.LoadCustomer(cus)

            Case FormName.frmPawningV2_Client
                frmPawningItemNew.LoadClient(cus)
            Case FormName.frmPawningV2_Claimer
                frmPawningItemNew.LoadCliamer(cus)

            Case FormName.layAway
                frmLayAway.LoadClient(cus)
            Case FormName.layAwayExist
                frmAddCustomer.LoadClient(cus)
        End Select
    End Sub

    Friend Sub ReloadFormFromItemList(gotoForm As FormName, Selected_Specs As ItemClass)
        Select Case gotoForm
            Case FormName.frmPawningV2_Specs
                frmPawningItemNew.Load_ItemSpecification(Selected_Specs)
            Case FormName.frmPawningV2_SpecsValue
                frmAdminPanel.Load_ItemSpecification(Selected_Specs)

        End Select
    End Sub

    Friend Sub ReloadFormFromInterestList(ByVal gotoForm As FormName, ByVal selected_scheme As InterestScheme)
        Select Case gotoForm
            Case FormName.frmPawningV2_Specs
                frmAdminPanel.LoadSchemeList(selected_scheme)
        End Select
    End Sub

    Friend Sub ReloadFormFromSearch1(ByVal gotoForm As FormName, ByVal cr As Currency)
        Select Case gotoForm
            Case FormName.frmMoneyExchange
                frmmoneyexchange.LoadCurrencyall(cr)
        End Select
    End Sub

    Friend Sub ReloadFormFromInsurance(ByVal gotoForm As FormName, ByVal Ins As Insurance)
        Select Case gotoForm
            Case FormName.Coi
                frmAddCoi.LoadCoi(Ins)
            Case FormName.frmInsurance
                frmInsurance.LoadInsurance(Ins)
        End Select
    End Sub
End Module