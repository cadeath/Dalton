Module PawningScheme

    Friend CELScheme As Boolean = True

    ' CELLPHONE ITEM TYPE SCHEME
    Friend ForceRenew As Boolean = True
    Const ALLOW_DAY_CELSCHEME As Integer = 30

    Friend Sub Init_CEL(PawnCEL As PawnTicket)
        If Not CELScheme Then Exit Sub 'Scheme Function
        If PawnCEL.ItemType <> "CEL" Then Exit Sub 'For CEL Item Type ONLY

        Console.WriteLine("Initiating CEL SCHEME!")

        ' Allowing on the Second Month only to renew.
        Dim difDay = PawnCEL.AuctionDate - CurrentDate
        Console.WriteLine(String.Format("There are {0} days between Auction Data and the Current Date", difDay.Days))
        If ALLOW_DAY_CELSCHEME < difDay.Days Then Exit Sub

        Console.WriteLine("Difference was covered. Force Renew")
        If ForceRenew Then frmPawnItem.btnRenew.Enabled = True
    End Sub

End Module
