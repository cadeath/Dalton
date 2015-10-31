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
                btnRenew.PerformClick()
            Case Keys.F5
                Console.WriteLine("Redeem")
                btnRedeem.PerformClick()
        End Select
    End Sub

    Private Sub frmPawning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive()
        'frmOpenStore.Show()
        'frmOpenStore.Focus()
    End Sub

    Private Sub btnLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoan.Click
        frmNewloan.NewLoan()
        frmNewloan.Show()
    End Sub

    Friend Sub LoadActive()
        Dim mySql As String = "SELECT * FROM tblpawn WHERE Status = 'L' OR Status = 'R' OR Status = 'S' ORDER BY LoanDate ASC, PAWNID ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        lvPawners.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpPawn As New PawnTicket
            tmpPawn.LoadTicketInRow(dr)

            AddItem(tmpPawn)
            Console.WriteLine("Pawn: " & tmpPawn.PawnID)
        Next
    End Sub

    Private Sub AddItem(ByVal tk As PawnTicket)
        Dim ticket As String
        ticket = String.Format("{0:000000}", tk.PawnTicket)
        Dim lv As ListViewItem = lvPawners.Items.Add(ticket)
        lv.SubItems.Add(tk.ItemType)
        lv.SubItems.Add(tk.Description)
        lv.SubItems.Add(String.Format("{0} {1}", tk.Pawner.FirstName, tk.Pawner.LastName))
        lv.SubItems.Add(tk.LoanDate)
        lv.SubItems.Add(tk.MaturityDate)
        lv.SubItems.Add(tk.ExpiryDate)
        lv.SubItems.Add(tk.AuctionDate)
        lv.SubItems.Add(tk.Principal)

        Select Case tk.Status
            Case "0" : lv.BackColor = Color.LightGray
            Case "X" : lv.BackColor = Color.Red
            Case "W" : lv.BackColor = Color.Red
            Case "V" : lv.BackColor = Color.Gray
        End Select
    End Sub

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvPawners.Items.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub

        Dim mySql As String = "SELECT * FROM tblpawn WHERE "
        If IsNumeric(txtSearch.Text) Then mySql &= vbCr & "PAWNTICKET = " & CInt(txtSearch.Text) & " OR "
        mySql &= vbCr & "UPPER(DESCRIPTION) LIKE UPPER('%" & txtSearch.Text & "%')"
        mySql &= vbCr & " OR UPPER(ITEMTYPE) LIKE UPPER('%" & txtSearch.Text & "%')"

        Console.WriteLine(mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Single = ds.Tables(0).Rows.Count
        Dim clientID As Integer = 0

        lvPawners.Items.Clear()
        If MaxRow = 0 Then

            mySql = "SELECT * FROM tblClient WHERE "
            mySql &= vbCr & "UPPER(FIRSTNAME) LIKE UPPER('%" & txtSearch.Text & "%') OR "
            mySql &= vbCr & "UPPER(MIDDLENAME) LIKE UPPER('%" & txtSearch.Text & "%') OR "
            mySql &= vbCr & "UPPER(LASTNAME) LIKE UPPER('%" & txtSearch.Text & "%')"

            ds.Clear()
            ds = LoadSQL(mySql)
            MaxRow = ds.Tables(0).Rows.Count
            If MaxRow = 0 Then
                Console.WriteLine("No Pawn, No Client, No found")
                MsgBox("Query not found", MsgBoxStyle.Information)
                Exit Sub
            End If

            For Each dr As DataRow In ds.Tables(0).Rows
                clientID = dr.Item("ClientID")
                Dim xDs As DataSet

                mySql = "SELECT * FROM tblpawn WHERE clientID = " & clientID
                xDs = LoadSQL(mySql)
                MaxRow = xDs.Tables(0).Rows.Count
                If MaxRow > 0 Then
                    lvPawners.Items.Clear()
                    For Each xdr As DataRow In xDs.Tables(0).Rows
                        Dim tmpTicket As New PawnTicket
                        tmpTicket.LoadTicketInRow(xdr)
                        AddItem(tmpTicket)
                    Next
                End If
            Next
        Else
            For Each dr As DataRow In ds.Tables(0).Rows
                Dim tmpTicket As New PawnTicket
                tmpTicket.LoadTicketInRow(dr)
                AddItem(tmpTicket)
            Next
        End If


        lvPawners.Focus()
        MsgBox(MaxRow & " result found.", MsgBoxStyle.Information)
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvPawners.SelectedItems.Count <= 0 Then Exit Sub

        Dim idx As Integer = CInt(lvPawners.FocusedItem.Text)
        Dim tmpTicket As New PawnTicket
        tmpTicket.LoadTicket(idx, "PawnTicket")
        frmNewloan.LoadPawnTicket(tmpTicket, "D")
        frmNewloan.Show()
    End Sub

    Private Sub lvPawners_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPawners.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub lvPawners_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPawners.KeyPress
        If isEnter(e) Then
            btnView.PerformClick()
        End If
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        If lvPawners.SelectedItems.Count > 0 Then
            btnView.PerformClick()
            frmNewloan.SwitchTransaction("RENEW")
        End If
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If lvPawners.SelectedItems.Count > 0 Then
            btnView.PerformClick()
            frmNewloan.SwitchTransaction("REDEEM")
        End If
    End Sub
End Class