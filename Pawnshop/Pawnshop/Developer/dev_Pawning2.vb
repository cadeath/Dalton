Public Class dev_Pawning2

    Private ItemClass As Hashtable
    Private newPawnTicket As PawnTicket2
    Private newItem As PawnItem

    Private Sub dev_Pawning2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_ItemClass()
    End Sub

    Private Sub Load_ItemClass()
        Dim mySql As String = "SELECT * FROM TBLITEM ORDER BY ITEMID ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        ItemClass = New Hashtable
        cboType.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr("ITEMCLASS"))
            ItemClass.Add(dr("ITEMID"), dr("ITEMCLASS"))
        Next
    End Sub

    Private Sub btnCompute_Click(sender As System.Object, e As System.EventArgs) Handles btnCompute.Click
        If DeclareItem() Then Exit Sub

        'Dim newCompute As New PawnCompute(newPawnTicket, current.SelectionRange.Start, If(rbDPJ.Checked, True, False))
        'With newCompute
        '    txtDaysOver.Text = .DaysOverDue

        '    txtNetAmount.Text = .NetAmount.ToString("P #,##0.00")
        '    txtAdvInt.Text = .AdvanceInterest.ToString("#,##0.00")
        '    txtInt.Text = .Interest.ToString("#,##0.00")
        '    txtPenalty.Text = .Penalty.ToString("#,##0.00")
        '    txtSC.Text = .ServiceCharge.ToString("#,##0.00")

        '    txtRenewDue.Text = .RenewDue.ToString("#,##0.00")
        '    txtRedeemDue.Text = .RedeemDue.ToString("#,##0.00")
        'End With
    End Sub

    Private Function DeclareItem() As Boolean
        If cboType.Text = "" Then Return True
        If txtPrincipal.Text = "" Then Return True

        Dim selClass As New ItemClass
        selClass.LoadItem(GetIDbyName(cboType.Text, ItemClass))


        newItem = New PawnItem
        With newItem
            .ItemClass = selClass
        End With

        Dim newPT As New PawnTicket2
        With newPT
            .LoanDate = loanDate.SelectionRange.Start
            .MaturityDate = .LoanDate.AddDays(29)
            .ExpiryDate = .LoanDate.AddDays(119)
            .AuctionDate = .LoanDate.AddDays(152)

            .PawnItem = newItem
            .Principal = CDbl(txtPrincipal.Text)
        End With

        newPawnTicket = newPT

        Console.WriteLine("Item: " & newPawnTicket.PawnItem.ItemClass.ClassName)
        Console.WriteLine("Scheme: " & newPawnTicket.PawnItem.ItemClass.InterestScheme.SchemeName)

        Console.WriteLine("Scheme Details===================")
        For Each Int As Scheme_Interest In newPawnTicket.PawnItem.ItemClass.InterestScheme.SchemeDetails
            Console.WriteLine(String.Format("{0} - {1} -> {2}", Int.DayFrom, Int.DayTo, Int.Interest * 100))
        Next

        Return False
    End Function

    Private Sub txtMatu_DoubleClick(sender As Object, e As System.EventArgs) Handles txtMatu.DoubleClick
        dev_Pawning.Show()
    End Sub

End Class