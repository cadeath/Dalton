﻿Public Class frmPawning

    Friend isMoreThan100 As Boolean = False

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    ''' <summary>
    '''This case function allow you use short key.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
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

    ''' <summary>
    ''' load the clearfields and loadActive method.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmPawning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadActive_v2()

        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()
    End Sub

    ''' <summary>
    ''' show the form pawn item and add new loan.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoan.Click
        If frmPawnItem.Visible = True Then
            MsgBox("Close Pawn Item Form Before To Proceed Other Transaction" _
                                            , MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2, _
                                             "Form Already Open")
        Else
            frmPawningItemNew.Show()
            frmPawningItemNew.NewLoan()
        End If
    End Sub

    ''' <summary>
    ''' load the specific client either renew or redeem or segregated.
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub LoadActive()
        Dim st As String = "1"

        st &= IIf(chkRenew.Checked, "1", "0")
        st &= IIf(chkRedeem.Checked, "1", "0")
        st &= IIf(chkSeg.Checked, "1", "0")

        Dim mySql As String = "SELECT FIRST 100 * FROM tblPawn WHERE LoanDate <= '" & CurrentDate.ToShortDateString
        'mySql = "SELECT * FROM tblpawn WHERE LoanDate <= '" & CurrentDate.ToShortDateString
        If st = "1000" Then
            mySql &= "' AND (Status = 'L' OR Status = 'R') ORDER BY LoanDate ASC, PAWNID ASC"
        Else
            'mySql &= "' AND (Status = 'L' OR Status = 'R' "
            mySql &= "' AND ("
            If st.Substring(1, 1) = "1" Then mySql &= "Status = '0' " 'Renew
            If st.Substring(2, 1) = "1" Then
                If st.Substring(1, 1) = "1" Then mySql &= " OR "
                mySql &= "Status = 'X' " 'Redeem
            End If
            If st.Substring(3, 1) = "1" Then
                If st.Substring(2, 1) = "1" Then mySql &= " OR "
                If st.Substring(1, 1) = "1" And st.Substring(2, 1) = "0" Then mySql &= " OR "
                mySql &= "Status = 'S' " 'Segregate
            End If

            mySql &= ") ORDER BY LoanDate DESC, PAWNID DESC"

        End If
        Dim ds As DataSet = LoadSQL(mySql)

        'HACK
        'Add proper PAWNING REFRESHER if display is not the same with the query
        If ds.Tables(0).Rows.Count = lvPawners.Items.Count And lvPawners.Items.Count > 10 Then
            'Exit Sub
        End If

        lvPawners.Items.Clear()
        dbReaderOpen()

        Dim PawnReader = LoadSQL_byDataReader(mySql)
        While PawnReader.Read

            Dim readerPT As New PawnTicket
            readerPT.LoadTicketInReader(PawnReader)
            AddItem(readerPT)

        End While

        dbReaderClose()
    End Sub

    Friend Sub ReloadForm()
        ClearFields()
        LoadActive_v2()
    End Sub

    Private Sub LoadActive_v2()
        If isMoreThan100 Then Exit Sub

        Dim i As Integer = 0
        Dim mySql As String = "SELECT FIRST 100 * FROM PAWN_LIST "
        mySql &= String.Format("WHERE LOANDATE <= '{0}' ", CurrentDate.ToShortDateString)
        mySql &= "AND (STATUS = 'L' OR STATUS = 'R') "
        mySql &= "ORDER BY PAWNTICKET ASC"

        lvPawners.Items.Clear()
        dbReaderOpen()

        Dim PawnReader = LoadSQL_byDataReader(mySql)
        While PawnReader.Read

            Dim lv As ListViewItem = lvPawners.Items.Add(DisplayPawnTicket(PawnReader("PAWNTICKET")))
            lv.SubItems.Add(PawnReader("ITEMCLASS"))
            lv.SubItems.Add(PawnReader("DESCRIPTION"))
            lv.SubItems.Add(PawnReader("CLIENT"))
            lv.SubItems.Add(PawnReader("LOANDATE"))
            lv.SubItems.Add(PawnReader("MATUDATE"))
            lv.SubItems.Add(PawnReader("EXPIRYDATE"))
            lv.SubItems.Add(PawnReader("AUCTIONDATE"))
            lv.SubItems.Add(PawnReader("PRINCIPAL"))
            i += 1

            If i >= 100 Then isMoreThan100 = True
        End While
        
        dbReaderClose()
    End Sub

    ''' <summary>
    ''' This method will allow you to add new load.
    ''' </summary>
    ''' <param name="tk"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal tk As PawnTicket)
        Dim ticket As String
        ticket = String.Format("{0:000000}", tk.PawnTicket)
        Dim lv As ListViewItem = lvPawners.Items.Add(ticket)
        Dim tmpItem As ItemClass = New ItemClass
        lv.SubItems.Add(tmpItem.Category)
        lv.SubItems.Add(tmpItem.Description)
        lv.SubItems.Add(String.Format("{0} {1}", tk.Pawner.FirstName, tk.Pawner.LastName))
        lv.SubItems.Add(tk.LoanDate)
        lv.SubItems.Add(tk.MaturityDate)
        lv.SubItems.Add(tk.ExpiryDate)
        lv.SubItems.Add(tk.AuctionDate)
        lv.SubItems.Add(tk.Principal)
        lv.Tag = tk.PawnID

        Select Case tk.Status
            Case "0" : lv.BackColor = Color.LightGray
            Case "X" : lv.BackColor = Color.Red
            Case "S" : lv.BackColor = Color.Yellow
            Case "W" : lv.BackColor = Color.Red
            Case "V" : lv.BackColor = Color.Gray
        End Select
    End Sub

    ''' <summary>
    ''' This method will clear the txtsearch and listview items
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFields()
        txtSearch.Text = ""
        lvPawners.Items.Clear()
    End Sub

    ''' <summary>
    ''' search the client who already has transaction.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Length <= 3 Then
            MsgBox("3 Characters Below Not Allowed.", MsgBoxStyle.Exclamation, "Client Search")
        Else
            PawningSearch()
        End If
    End Sub

    Private Sub PawningSearch()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim strWords As String() = secured_str.Split(New Char() {" "c})
        Dim mySql As String, name As String


        mySql = "Select * from Pawn_List Where "
        If rbAll.Checked Then
            If IsNumeric(secured_str) Then mySql &= vbCr & "PAWNTICKET like " & "'%" & CInt(secured_str) & "%'" & " OR "
            ' mySql &= "UPPER(ITEMCLASS) LIKE UPPER('%" & secured_str & "%') OR "
            mySql &= "UPPER(DESCRIPTION) LIKE UPPER('%" & secured_str & "%') OR "
            For Each name In strWords

                mySql &= vbCr & " UPPER(CLIENT) LIKE UPPER('%" & name & "%') and "
                If name Is strWords.Last Then
                    mySql &= vbCr & " UPPER(CLIENT) LIKE UPPER('%" & name & "%') "
                    Exit For
                End If

            Next
        ElseIf rbPawnTicket.Checked Then
            mySql &= vbCr & "PAWNTICKET like " & "'%" & CInt(secured_str) & "%'"
        ElseIf rbPawner.Checked Then
            For Each name In strWords

                mySql &= vbCr & " UPPER(CLIENT) LIKE UPPER('%" & name & "%') and "
                If name Is strWords.Last Then
                    mySql &= vbCr & " UPPER(CLIENT) LIKE UPPER('%" & name & "%') "
                    Exit For
                End If
            Next
        ElseIf rbDescription.Checked Then
            mySql &= "UPPER(DESCRIPTION) LIKE UPPER('%" & secured_str & "%')"
        End If
        lvPawners.Items.Clear()
        dbReaderOpen()
        Dim i As Integer = 0, ds As DataSet = LoadSQL(mySql)
        Dim PawnReader = LoadSQL_byDataReader(mySql)
        While PawnReader.Read

            Dim lv As ListViewItem = lvPawners.Items.Add(DisplayPawnTicket(PawnReader("PAWNTICKET")))
            lv.SubItems.Add(PawnReader("ITEMCLASS"))
            lv.SubItems.Add(PawnReader("DESCRIPTION"))
            lv.SubItems.Add(PawnReader("CLIENT"))
            lv.SubItems.Add(PawnReader("LOANDATE"))
            lv.SubItems.Add(PawnReader("MATUDATE"))
            lv.SubItems.Add(PawnReader("EXPIRYDATE"))
            lv.SubItems.Add(PawnReader("AUCTIONDATE"))
            lv.SubItems.Add(PawnReader("PRINCIPAL"))
            i += 1

            If i >= 100 Then isMoreThan100 = True

            Select Case PawnReader("Status")
                Case "0" : lv.BackColor = Color.LightGray
                Case "X" : lv.BackColor = Color.Red
                Case "S" : lv.BackColor = Color.Yellow
                Case "W" : lv.BackColor = Color.Red
                Case "V" : lv.BackColor = Color.Gray
            End Select
        End While
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count
        If MaxRow <= 0 Then
            MsgBox("Query not found", MsgBoxStyle.Critical)
            Exit Sub
        End If
        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Client")
        If lvPawners.Items.Count > 0 Then
            lvPawners.Focus()
            lvPawners.Items(0).Selected = True
            lvPawners.Items(0).EnsureVisible()
        End If
        dbReaderClose()

    End Sub

    ''' <summary>
    ''' to perform enter without clicking the search button.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
        If rbPawnTicket.Checked Then
            DigitOnly(e)
        End If
    End Sub

    ''' <summary>
    ''' to view the information of the client.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvPawners.SelectedItems.Count <= 0 Then Exit Sub

        Dim idx As Integer = CInt(lvPawners.FocusedItem.Text)
        Dim tmpTicket As New PawnTicket2
        tmpTicket.Load_PawnTicket(idx)
        frmPawningItemNew.Show()
        frmPawningItemNew.transactionType = "D"
        frmPawningItemNew.Load_PawnTicket(tmpTicket)

    End Sub

    ''' <summary>
    ''' 
    ''' double click the disire client in the listview to view thier information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvPawners_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvPawners.DoubleClick
        btnView.PerformClick()
    End Sub

    ''' <summary>
    ''' perform enter in the desire client in the listview to view thier information.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub lvPawners_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvPawners.KeyPress
        If isEnter(e) Then
            btnView.PerformClick()
        End If
    End Sub

    ''' <summary>
    ''' click button to renew expiration date of transaction.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        If lvPawners.SelectedItems.Count > 0 Then
            If frmPawnItem.Visible = True Then

                MsgBox("Close Pawn Item Form Before To Proceed Other Transaction" _
                                            , MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2, _
                                             "Form Already Open")
            Else
                If lvPawners.SelectedItems.Count = 0 Then Exit Sub

                Dim pt_Selected As New PawnTicket2
                pt_Selected.Load_PawnTicket(CInt(lvPawners.FocusedItem.Text))

                frmPawningItemNew.Show()
                frmPawningItemNew.Load_PawnTicket(pt_Selected)
                frmPawningItemNew.Renew()

            End If
        End If
    End Sub

    ''' <summary>
    ''' click button to redeem the item of the client
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If lvPawners.SelectedItems.Count > 0 Then
            If frmPawnItem.Visible = True Then
                MsgBox("Close Pawn Item Form Before To Proceed Other Transaction" _
                                                           , MsgBoxStyle.Exclamation + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2, _
                                                            "Form Already Open")
            Else

                If lvPawners.SelectedItems.Count = 0 Then Exit Sub

                Dim pt_Selected As New PawnTicket2
                pt_Selected.Load_PawnTicket(CInt(lvPawners.FocusedItem.Text))

                frmPawningItemNew.Show()
                frmPawningItemNew.Load_PawnTicket(pt_Selected)
                frmPawningItemNew.Redeem()

            End If
        End If
    End Sub

    ''' <summary>
    ''' checkbox to load the renew client in listview 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkRenew_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRenew.CheckedChanged
        LoadActive()
    End Sub

    ''' <summary>
    ''' checkbox to load the redeem client in listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkRedeem_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRedeem.CheckedChanged
        LoadActive()
    End Sub

    ''' <summary>
    ''' checkbox to load the segregated client in listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub chkSeg_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSeg.CheckedChanged
        LoadActive()
    End Sub

    Private Function DisplayPawnTicket(ByVal pt As Integer) As String
        Return pt.ToString("0000000")
    End Function

    Private Sub rbPawnTicket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbPawnTicket.Click, _
        rbPawner.Click, rbDescription.Click, rbAll.Click
        txtSearch.Clear()
    End Sub

    Private Sub GroupBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.DoubleClick
        If mod_system.DEV_MODE Then

            Dim pt As Integer = lvPawners.FocusedItem.Text
            Dim pawnTicket As New PawnTicket2
            pawnTicket.Load_PawnTicket(pt)

            Console.WriteLine(pawnTicket.PawnItem.ItemClass.ClassName)

            For Each pawnSpec As PawnItemSpec In pawnTicket.PawnItem.PawnItemSpecs
                Console.WriteLine(pawnSpec.SpecsValue)
            Next
        End If
    End Sub
End Class