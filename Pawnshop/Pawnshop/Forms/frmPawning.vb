Public Class frmPawning

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmPawning_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Console.WriteLine("New Loan!")
                btnLoan.PerformClick()
            Case Keys.F2
                txtSearch.Focus()
            Case Keys.F4
                Console.WriteLine("Renewal")
            Case Keys.F5
                Console.WriteLine("Redeem")
        End Select
    End Sub

    Private Sub frmPawning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive()
        MsgBox("Under development")
    End Sub

    Private Sub btnLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoan.Click
        frmNewloan.NewLoan()
        frmNewloan.Show()
    End Sub

    Private Sub LoadActive()
        Dim mySql As String = "SELECT * FROM tblpawn WHERE Status = 'L' OR Status = 'R' OR Status = 'S'"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpPawn As New PawnTicket
            tmpPawn.LoadTicketInRow(dr)

            AddItem(tmpPawn)
            Console.WriteLine("Pawn: " & tmpPawn.PawnID)
        Next
    End Sub

    Private Sub AddItem(ByVal tk As PawnTicket)
        Dim lv As ListViewItem = lvPawners.Items.Add(tk.PawnTicket)
        lv.SubItems.Add(tk.ItemType)
        lv.SubItems.Add(tk.Description)
        lv.SubItems.Add(String.Format("{0} {1}", tk.Pawner.FirstName, tk.Pawner.LastName))
        lv.SubItems.Add(tk.LoanDate)
        lv.SubItems.Add(tk.MaturityDate)
        lv.SubItems.Add(tk.ExpiryDate)
        lv.SubItems.Add(tk.AuctionDate)
        lv.SubItems.Add(tk.NetAmount)
    End Sub

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvPawners.Items.Clear()
    End Sub
End Class