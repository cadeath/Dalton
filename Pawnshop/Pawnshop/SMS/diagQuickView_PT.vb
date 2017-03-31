Public Class diagQuickView_PT

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Friend Sub Load_Pawnticket(ptNum As Integer)
        Dim display_pawnticket As New PawnTicket2
        display_pawnticket.Load_PawnTicket(ptNum)

        ClearFields()

        'Loading ItemClass Specifications
        txtClass.Text = display_pawnticket.PawnItem.ItemClass.ClassName
        Dim specCnt As Integer = 0
        For Each spec As ItemSpecs In display_pawnticket.PawnItem.ItemClass.ItemSpecifications
            Dim pawnSpecs As PawnItemSpec = display_pawnticket.PawnItem.PawnItemSpecs.Item(specCnt)

            Dim lv As ListViewItem = lvSpecs.Items.Add(spec.SpecName)
            lv.SubItems.Add(pawnSpecs.SpecsValue)

            specCnt += 1
        Next

        With display_pawnticket
            'Loading Ticket Information
            txtTicket.Text = .PawnTicket
            txtOld.Text = .OldTicket
            txtLoan.Text = ddFormat(.LoanDate)
            txtExpiry.Text = ddFormat(.ExpiryDate)
            txtAuction.Text = ddFormat(.AuctionDate)

            txtPrincipal.Text = .Principal.ToString("#,##0.00")
            txtNetAmount.Text = .NetAmount.ToString("#,##0.00")
            txtAppraiser.Text = GetUsername(.AppraiserID)

            'Loading Customer Information
            txtCustomer.Text = String.Format("{0} {1}", .Pawner.FirstName, .Pawner.LastName)
            txtAddr.Text = String.Format("{0} {1}" & vbCrLf & "{2}", .Pawner.AddressSt, .Pawner.AddressBrgy, .Pawner.AddressCity)
            txtBday.Text = ddFormat(.Pawner.Birthday)
            txtNumber.Text = .Pawner.Cellphone1
        End With

    End Sub

    Private Function GetUsername(id As Integer) As String
        Dim appraiser As New ComputerUser
        appraiser.LoadUser(id)

        Return appraiser.FullName
    End Function

    Private Sub ClearFields()
        txtClass.Text = ""
        lvSpecs.Items.Clear()

        txtTicket.Text = ""
        txtOld.Text = ""
        txtLoan.Text = ""
        txtExpiry.Text = ""
        txtAuction.Text = ""
        txtPrincipal.Text = ""
        txtNetAmount.Text = ""
        txtAppraiser.Text = ""

        txtCustomer.Text = ""
        txtAddr.Text = ""
        txtBday.Text = ""
        txtNumber.Text = ""
    End Sub

    Private Function ddFormat(dt As Date) As String
        Return dt.ToShortDateString
    End Function
End Class