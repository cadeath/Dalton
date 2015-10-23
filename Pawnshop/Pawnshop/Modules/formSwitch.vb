Module formSwitch

    Friend Enum FormName As Integer
        devForm = 0
        frmMT = 1 'Money Transfer
    End Enum

    Friend Sub ReloadFormFromSearch(ByVal gotoForm As FormName, ByVal cl As Client)
        Select Case gotoForm
            Case FormName.devForm
                devClient.LoadClientInfo(cl)
        End Select
    End Sub

End Module