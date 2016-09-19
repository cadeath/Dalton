﻿Module formSwitch
    ''' <summary>
    ''' This module where every form was assign by a digit which underlying the form.
    ''' </summary>
    ''' <remarks></remarks>
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

        NewPawning = 10
        PawnClaimer = 11
        Item = 12

        frmPawningNew = 13

        frmitemList = 14
    End Enum
    ''' <summary>
    ''' This method select what form you want to go.
    ''' </summary>
    ''' <param name="gotoForm">gotoform here is a variable that hold all forms.</param>
    ''' <param name="cl"></param>
    ''' <remarks></remarks>
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
            Case FormName.frmMoneyExchange
                frmmoneyexchange.LoadClient(cl)

            Case FormName.NewPawning
                frmPawningNew.LoadClient(cl)
            Case FormName.PawnClaimer
                frmPawningNew.LoadCliamer(cl)
        End Select
    End Sub
    ''' <remarks></remarks>
    Friend Sub ReloadFormFromSearch1(ByVal gotoForm As FormName, ByVal cr As Currency)
        Select Case gotoForm
            Case FormName.frmMoneyExchange
                frmmoneyexchange.LoadCurrencyall(cr)
        End Select
    End Sub

    Friend Sub ReloadFormFromSearch2(ByVal gotoForm As FormName, ByVal it As ItemClass)

        Select Case gotoForm
            Case FormName.frmAdminPanel
                'frmAdminPanel.LoadItemall(it)
            Case FormName.Item
                frmPawningNew.LoadItem(it)
        End Select

    End Sub
End Module