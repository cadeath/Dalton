Module Pawn

    Private Pawnticket() As String = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10}
    Private Loandate() As Date = {#10/25/2016#, #10/26/2016#, #10/27/2016#, #10/28/2016#, #10/29/2016#, #10/30/2016#, #10/31/2016#, #11/1/2016#, #11/2/2016#, #11/3/2016#}
    Private Maturity() As Date = {#11/25/2016#, #11/26/2016#, #11/27/2016#, #11/28/2016#, #11/29/2016#, #11/30/2016#, #11/30/2016#, #12/1/2016#, #12/2/2016#, #12/3/2016#}
    Private expiry() As Date = {#12/25/2016#, #12/26/2016#, #12/27/2016#, #12/28/2016#, #12/29/2016#, #12/30/2016#, #12/31/2016#, #1/1/2017#, #1/2/2017#, #1/3/2017#}
    Private auction() As Date = {#1/25/2017#, #1/26/2017#, #1/27/2017#, #1/28/2017#, #1/29/2017#, #1/30/2017#, #1/31/2017#, #2/1/2017#, #2/2/2017#, #2/3/2017#}
    Private status() As String = {"L", "L", "L", "L", "L", "L", "L", "L", "L", "L"}
    Private ClientID() As Integer = {1, 1, 1, 1, 1, 1, 1, 1, 1, 1}

    Private ClassID() As Integer = {1, 9, 1, 9, 4, 1, 9, 1, 9, 4}
    Private Item() As String = {"RING", "WATCH", "RING", "WATCH", "EARRINGS", "RING", "WATCH", "RING", "WATCH", "EARRINGS"}
    Private Principals() As Double = {1200, 6300, 1300, 5000, 6300, 1200, 6300, 1300, 5000, 6300}
    Private Printlayout() As String = _
        {"RING 3G UU WITH INSIGNIA", "ROLEX ANG RELO NI LEROY", "RING 4.1G UF WITH TEMPLAR LOGO", "BAYWALK BODIES", "TRIBAL EARRINGS", _
         "RING 3G UU WITH INSIGNIA", "ROLEX ANG RELO NI LEROY", "RING 4.1G UF WITH TEMPLAR LOGO", "BAYWALK BODIES", "TRIBAL EARRINGS"}
    Sub Populate()
        Dim mySql As String = "SELECT * FROM OPT WHERE PAWNTICKET = 1"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count > 0 Then Exit Sub

        Console.WriteLine("Populating...")
        For i As Integer = 0 To 9
            Dim NewPawnTicket As New PawnTicket2
            With NewPawnTicket
                .PawnTicket = Pawnticket(i)
                .LoanDate = Loandate(i)
                .MaturityDate = Maturity(i)
                .ExpiryDate = expiry(i)
                .AuctionDate = auction(i)
                .Status = status(i)
                .Principal = Principals(i)
                .Pawner.CustomerID = ClientID(i)

                .PawnItem.ItemClass.ID = ClassID(i)
                .PawnItem.ItemClass.ClassName = Item(i)
                .PawnItem.ItemClass.PrintLayout = Printlayout(i)
                .PawnItem.ItemClass.created_at = Now
                .Save_PawnTicket()
            End With

        Next
        Dim tmpClient As New Customer

        With tmpClient
            .FirstName = "JUNMAR"
            .MiddleName = "ESPINOSA"
            .LastName = "HONOR"
            .Sex = 1
            .Save()
        End With
        Console.WriteLine("Finish")
    End Sub
End Module
