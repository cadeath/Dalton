Module Pawn

    Private Pawnticket() As String = {1, 2, 3, 4, 5}
    Private Loandate() As Date = {#7/25/2016#, #7/26/2016#, #7/27/2016#, #7/28/2016#, #7/29/2016#}
    Private Maturity() As Date = {#8/25/2016#, #8/26/2016#, #8/27/2016#, #8/28/2016#, #8/29/2016#}
    Private expiry() As Date = {#11/25/2016#, #11/26/2016#, #11/27/2016#, #11/28/2016#, #11/29/2016#}
    Private auction() As Date = {#12/25/2016#, #12/26/2016#, #12/27/2016#, #12/28/2016#, #12/29/2016#}
    Private status() As String = {"S", "S", "S", "S", "S"}

    Private ClassID() As Integer = {1, 9, 1, 9, 4}
    Private Item() As String = {"RING", "WATCH", "RING", "WATCH", "EARRINGS"}
    Private Principals() As Double = {1200, 6300, 1300, 5000, 6300}
    Private Printlayout() As String = _
        {"RING 3G UU WITH INSIGNIA", "ROLEX ANG RELO NI LEROY", "RING 4.1G UF WITH TEMPLAR LOGO", "BAYWALK BODIES", "TRIBAL EARRINGS"}
    Sub Populate()
        Dim mySql As String = "SELECT * FROM OPT WHERE PAWNTICKET = 1"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count > 0 Then Exit Sub

        Console.WriteLine("Populating...")
        For i As Integer = 0 To 4
            Dim NewPawnTicket As New PawnTicket2
            With NewPawnTicket
                .PawnTicket = Pawnticket(i)
                .LoanDate = Loandate(i)
                .MaturityDate = Maturity(i)
                .ExpiryDate = expiry(i)
                .AuctionDate = auction(i)
                .Status = status(i)
                .Principal = Principals(i)

                .PawnItem.ItemClass.ID = ClassID(i)
                .PawnItem.ItemClass.ClassName = Item(i)
                .PawnItem.ItemClass.PrintLayout = Printlayout(i)
                .PawnItem.ItemClass.created_at = Now
                .Save_PawnTicket()
            End With

        Next
    End Sub
End Module
