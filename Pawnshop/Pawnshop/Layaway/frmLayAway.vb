Public Class frmLayAway

    Friend Customer As Client
    Friend Item As cItemData
    Dim tmpBalance As Double
    Dim tmpLayID As Integer
    Friend isOld As Boolean = False
    Friend isNewLayAway As Boolean = False
    Private forfeitDate As Date
    Private InvoiceNum As Double = GetOption("InvoiceNum")


    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try

            If Not isValid() Then Exit Sub

            Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "Posting")
            If ans = Windows.Forms.DialogResult.No Then Exit Sub

            LayAwaySave()

            MsgBox("Item Posted", MsgBoxStyle.Information, "LayAway")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
             End Try
        Me.Close()
    End Sub

    Private Sub frmLayAway_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearText()
    End Sub

    Private Sub ClearText()
        txtAddress.Clear()
        txtCustomer.Clear()
        txtItemCode.Clear()
        txtDescription.Clear()
        txtAmount.Clear()
        lblCost.Text = ""
        lblPenalty.Text = ""
        lblBalance.Text = ""
        lblLayAwayDate.Text = ""
        lblForfeitDate.Text = ""
        lblPercent.Text = ""
    End Sub

    Private Sub Disable()
        txtCustomer.Enabled = False
        txtItemCode.Enabled = False
        btnSearch.Enabled = False
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.layAway)
        frmClient.Show()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddress.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)

        Customer = New Client
        Customer = cl
        txtAmount.Focus()
    End Sub

    Friend Sub LoadItemEncode(ByVal tmpItem As cItemData)
        If tmpItem.SalePrice <= 0 Then MsgBox("Price Error", MsgBoxStyle.Critical, "Not Valid") : Me.Close() : Exit Sub
        txtItemCode.Text = tmpItem.ItemCode
        txtDescription.Text = tmpItem.Description
        lblCost.Text = tmpItem.SalePrice
        tmpBalance = tmpItem.SalePrice
        lblBalance.Text = tmpItem.SalePrice
        lblLayAwayDate.Text = CurrentDate.ToShortDateString
        lblForfeitDate.Text = CurrentDate.AddDays(119).ToShortDateString
        lblPercent.Text = tmpItem.SalePrice * 0.2

        Item = tmpItem
        Compute()
    End Sub

    Private Sub txtCustomer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomer.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            btnOK.PerformClick()
        End If
    End Sub

    Private Function isValid() As Boolean
        If isNewLayAway = True Then

            If Item Is Nothing Then MsgBox("No Item Selected", MsgBoxStyle.Exclamation, "Not Valid!") : Return False
            If Customer Is Nothing Then MsgBox("No Customer Selected", MsgBoxStyle.Exclamation, "Not Valid!") : Return False

            Dim tmpPercent As Double = Val(lblCost.Text) * 0.2
            If txtAmount.Text = "" Then

                MsgBox("Please Paid at least " & tmpPercent, MsgBoxStyle.Information, "Not Valid!")
                Return False
            ElseIf txtAmount.Text = 0 Then

                MsgBox("Please Paid at least " & tmpPercent, MsgBoxStyle.Information, "Not Valid!")
                Return False
            ElseIf Not txtAmount.Text >= tmpPercent Then

                MsgBox("Please Paid at least " & tmpPercent, MsgBoxStyle.Information, "Not Valid!")
                Return False
            End If

            If txtAmount.Text >= Val(lblCost.Text) Then Return False

        Else

            If (txtAmount.Text = "" OrElse txtAmount.Text = 0) Then MsgBox("Please fill the Amount", MsgBoxStyle.Information, "Not Valid") : Return False
            'If txtAmount.Text = 0 Then MsgBox("Please fill the Amount", MsgBoxStyle.Information, "Not Valid") : Return False

        End If

        If CInt(Val(lblBalance.Text)) < 0 Then MsgBox("Invalid Amount", MsgBoxStyle.Information, "Error") : Return False

        Return True
    End Function

    Private Sub txtAmount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        Compute()
    End Sub

    Friend Sub LoadExistInfo(ByVal ItemCode As String)
        Dim mysql As String = "Select LY.LAYID, LY.DOCDATE, LY.FORFEITDATE, LY.CUSTOMERID, "
        mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, LY.BALANCE "
        mysql &= "From TBLLAYAWAY LY "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
        mysql &= "WHERE LY.BALANCE <> 0 AND LY.ITEMCODE = '" & ItemCode & "' "
        Dim ds As DataSet = LoadSQL(mysql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("ItemCode Not Found!", MsgBoxStyle.Critical, "Error") : Exit Sub

        With ds.Tables(0).Rows(0)
            Customer = New Client
            Customer.LoadClient(.Item("CUSTOMERID"))
            tmpLayID = .Item("LayID")
            LoadClient(Customer)


            txtItemCode.Text = .Item("ItemCOde")
            Item = New cItemData
            mysql = "Select * From ItemMaster Where ItemCode = '" & .Item("ItemCode") & "'"
            Dim ItmDs As DataSet = LoadSQL(mysql, "ItemMaster")
            Item.Load_Item(ItmDs.Tables(0).Rows(0).Item("ITEMID"))

            txtDescription.Text = .Item("Description")
            lblCost.Text = Math.Round(.Item("Price"), 2, MidpointRounding.AwayFromZero)
            lblLayAwayDate.Text = .Item("DocDate").ToShortDateString
            lblForfeitDate.Text = .Item("ForfeitDate").ToShortDateString

            Dim PenaltyDate As Date = .Item("DocDate").AddDays(89).ToShortDateString
            If CurrentDate >= PenaltyDate Then
                tmpBalance = Math.Round(.Item("Balance") + (.Item("Balance") * 0.02), 2, MidpointRounding.AwayFromZero)
                lblBalance.Text = tmpBalance
                lblPenalty.Text = Math.Round(.Item("Balance") * 0.02, 2, MidpointRounding.AwayFromZero)
            Else
                tmpBalance = .Item("Balance")
                lblBalance.Text = tmpBalance
            End If

            isOld = True
            Disable()
            If .Item("Status") = 0 Then
                btnOK.Enabled = False
                txtAmount.Enabled = False
            End If
        End With
    End Sub

    Private Sub LayAwaySave()
        Dim lay As New LayAway
        Dim layLines As New LayAwayLines

        If isOld = True Then
            With layLines
                .LayID = tmpLayID
                .PaymentDate = CurrentDate
                .ControlNumber = String.Format("{1}#{0:000000}", InvoiceNum, "CI")
                .Amount = txtAmount.Text
                If lblPenalty.Text <> "" Then .Penalty = CDbl(Val(lblPenalty.Text))
                .PaymentEncoder = UserID
                .SaveLayAwayLines()
            End With

            With lay
                .LoadByID(tmpLayID)
                .UpdateBalance(CInt(lblBalance.Text))
            End With

            layLines.LoadByLayID(tmpLayID)
            If lblBalance.Text = 0 Then
                Dim AllPayments As Double
                If Val(lblCost.Text) <> layLines.GetSumPayments Then
                    AllPayments = Val(lblCost.Text) - Val(lblBalance.Text)
                Else

                    AllPayments = layLines.GetSumPayments
                End If

                    'If Full Paid Add Journal for Full Paid
                    AddJournal(txtAmount.Text, "Debit", "Revolving Fund", "LAYAWAY " & lay.ItemCode, "LAYAWAY", , , "LAYAWAY", layLines.LayLinesLastID)
                    AddJournal(AllPayments - txtAmount.Text, "Debit", "Advances from customer", "LAYAWAY " & lay.ItemCode, , , "LAY-AWAY PAYMENTS", "LAYAWAY ADVANCES", layLines.LayLinesLastID)
                    AddJournal(AllPayments - CInt(Val(lblPenalty.Text)), "Credit", "Cash Offsetting Account", "LAYAWAY " & lay.ItemCode, , , "LAY-AWAY PAYMENTS", "LAYAWAY", layLines.LayLinesLastID)

                    'if Transaction have penalty
                    If lblPenalty.Text <> "" Then
                        AddJournal(CInt(Val(lblPenalty.Text)), "Credit", "Income from Penalty on Layaway", "LAYAWAY " & lay.ItemCode, , , "LAY-AWAY PAYMENTS", "LAYAWAY", layLines.LayLinesLastID)
                    End If

                    lay.ItemOnLayMode(txtItemCode.Text, False)
                    InventoryController.DeductInventory(lay.ItemCode, 1)

                    Dim mySql As String = "SELECT * FROM DOC ROWS 1"
                    Dim fillData As String = "DOC"
                    Dim ds As DataSet = LoadSQL(mySql, fillData)
                    Dim dsNewRow As DataRow
                    dsNewRow = ds.Tables(fillData).NewRow
                    With dsNewRow
                        .Item("DOCTYPE") = 0
                        .Item("CODE") = String.Format("{1}#{0:000000}", InvoiceNum, "INV")
                        .Item("MOP") = "C"
                        .Item("CUSTOMER") = txtCustomer.Text
                        .Item("DOCDATE") = CurrentDate
                        .Item("DOCTOTAL") = lblCost.Text
                        .Item("USERID") = POSuser.UserID
                    End With
                    ds.Tables(fillData).Rows.Add(dsNewRow)
                    database.SaveEntry(ds)

                    Dim DOCID As Integer = 0
                    mySql = "SELECT * FROM DOC ORDER BY DOCID DESC ROWS 1"
                    ds = LoadSQL(mySql, fillData)
                    DOCID = ds.Tables(fillData).Rows(0).Item("DOCID")


                    mySql = "SELECT * FROM DOCLINES ROWS 1"
                    fillData = "DOCLINES"
                    ds = LoadSQL(mySql, fillData)

                    dsNewRow = ds.Tables(fillData).NewRow
                    With dsNewRow
                        .Item("DOCID") = DOCID
                        .Item("ITEMCODE") = txtItemCode.Text
                        .Item("DESCRIPTION") = txtDescription.Text
                        .Item("QTY") = 1
                        .Item("SALEPRICE") = lblCost.Text
                        .Item("ROWTOTAL") = lblCost.Text
                    End With
                    ds.Tables(fillData).Rows.Add(dsNewRow)

                    database.SaveEntry(ds)
            Else

                    'Add Journal For Payment
                    AddJournal(txtAmount.Text, "Debit", "Revolving Fund", "LAYAWAY " & lay.ItemCode, "LAYAWAY", , , "LAYAWAY", layLines.LayLinesLastID)
                    AddJournal(txtAmount.Text, "Credit", "Advances from customer", "LAYAWAY " & lay.ItemCode, , , "LAY-AWAY PAYMENTS", "LAYAWAY", layLines.LayLinesLastID)

                    'if Transaction Have Penalty
                    If lblPenalty.Text <> "" Then
                        AddJournal(lblPenalty.Text, "Credit", "Income from Penalty", "LAYAWAY " & lay.ItemCode, , , "LAY-AWAY PAYMENTS", "LAYAWAY", layLines.LayLinesLastID)
                    End If

                End If

        Else
            With lay
                .DocDate = CurrentDate
                .ForfeitDate = CurrentDate.AddDays(119).ToShortDateString
                .CustomerID = Customer.ID
                .ItemCode = txtItemCode.Text
                .Price = CDbl(lblCost.Text)
                .Balance = CDbl(lblBalance.Text)
                .Status = 1
                .Encoder = UserID
                .SaveLayAway()
            End With

            With layLines
                .LayID = lay.LayLastID
                .PaymentDate = CurrentDate
                .ControlNumber = String.Format("{1}#{0:000000}", InvoiceNum, "CI")
                .Amount = CDbl(txtAmount.Text)
                .PaymentEncoder = UserID
                .SaveLayAwayLines()
            End With

            lay.ItemOnLayMode(txtItemCode.Text)

            'Add Journal For Payment
            AddJournal(txtAmount.Text, "Debit", "Revolving Fund", "LAYAWAY " & lay.ItemCode, "LAYAWAY", , , "LAYAWAY", layLines.LayLinesLastID)
            AddJournal(txtAmount.Text, "Credit", "Advances from customer", "LAYAWAY " & lay.ItemCode, , , "LAY-AWAY PAYMENTS", "LAYAWAY", layLines.LayLinesLastID)
        End If

        InvoiceNum += 1
        UpdateOptions("InvoiceNum", InvoiceNum)
    End Sub

    Private Sub Compute()
        If txtAmount.Text <> "" Then
            lblBalance.Text = tmpBalance - txtAmount.Text
        Else
            lblBalance.Text = tmpBalance
        End If
    End Sub

End Class