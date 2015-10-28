Module formSwitch

    Friend Enum FormName As Integer
        devForm = 0
        frmMT = 1 'Money Transfer
        frmPawning = 2
        frmInsurance = 3
    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cl As Client)
        Select Case gotoForm
            Case FormName.devForm
                devClient.LoadClientInfo(cl)
            Case FormName.frmMT
                frmMoneyTransfer.LoadClient_Sender(cl)
            Case FormName.frmPawning
                frmNewloan.LoadPawnerInfo(cl)
            Case FormName.frmInsurance
                frmInsurance.LoadHolder(cl)
        End Select
    End Sub

End Module