Module Pawn

    Private Pawnticket() As String = {1, 2, 3, 4, 5}
    Private Loandate() As Date = {#7/25/2016#, #7/26/2016#, #7/27/2016#, #7/28/2016#, #7/29/2016#}
    Private Maturity() As Date = {#8/25/2016#, #8/26/2016#, #8/27/2016#, #8/28/2016#, #8/29/2016#}
    Private expiry() As Date = {#11/25/2016#, #11/26/2016#, #11/27/2016#, #11/28/2016#, #11/29/2016#}
    Private auction() As Date = {#12/25/2016#, #12/26/2016#, #12/27/2016#, #12/28/2016#, #12/29/2016#}
    Private status() As String = {"S", "S", "S", "S", "S"}

    Private Item() As String = {"Ring", "Watch", "Ring", "Watch", "Earring"}
    Private Printlayout() As String = {"Sample", "Sample", "Sample", "Sample", "Sample"}
    Sub Populate()
        For i As Integer = 0 To 4
            Dim NewPawnTicket As New PawnTicket2
            With NewPawnTicket
                .PawnTicket = Pawnticket(i)
                .LoanDate = Loandate(i)
                .MaturityDate = Maturity(i)
                .ExpiryDate = expiry(i)
                .AuctionDate = auction(i)
                .Status = status(i)

                .PawnItem.ItemClass.ClassName = Item(i)
                .PawnItem.ItemClass.PrintLayout = Printlayout(i)
                .PawnItem.ItemClass.created_at = Now
                .Save_PawnTicket()
            End With

        Next
    End Sub
End Module
