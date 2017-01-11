Public Class frmLayAway

    Friend Customer As Client
    Friend Item As cItemData
    Dim tmpBalance As Integer = 0
    Dim tmpLayID As Integer
    Friend isOld As Boolean = False
    Private forfeitDate As Date

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Try

            If Not isValid() Then Exit Sub
            'If lblPenalty.Text = Nothing Then lblPenalty.Text = 0
            'frmSales.LayCustomer = Customer.ID
            'frmSales.LayItemCode = txtItemCode.Text
            'frmSales.LayCost = CInt(lblCost.Text)
            'frmSales.LayAmount = txtAmount.Text
            'frmSales.LayBalance = CInt(lblBalance.Text)
            'frmSales.LayID = tmpLayID
            'frmSales.LayisOld = isOld
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
        lblContact.Text = ""
        lblDOB.Text = ""
        lblCost.Text = ""
        lblPenalty.Text = ""
        lblBalance.Text = ""
    End Sub

    Private Sub Disable()
        txtCustomer.Enabled = False
        txtItemCode.Enabled = False
        btnSearch.Enabled = False
        btnSearchItemCode.Enabled = False
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
        lblDOB.Text = cl.Birthday.ToString("MMM dd, yyyy")
        lblContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        Customer = New Client
        Customer = cl
        txtAmount.Focus()
    End Sub

    Friend Sub LoadItemEncode(ByVal tmpItem As cItemData)
        txtItemCode.Text = tmpItem.ItemCode
        txtDescription.Text = tmpItem.Description
        lblCost.Text = tmpItem.SalePrice
        tmpBalance = tmpItem.SalePrice
        lblBalance.Text = tmpItem.SalePrice
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
        If Item Is Nothing Then MsgBox("No Item Selected", MsgBoxStyle.Exclamation, "Not Valid!") : Return False
        If Customer Is Nothing Then MsgBox("No Customer Selected", MsgBoxStyle.Exclamation, "Not Valid!") : Return False
        Dim tmpPercent As Integer = CInt(lblCost.Text) * 0.2
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

        Return True
    End Function

    Private Sub txtAmount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        Compute()
    End Sub

    Friend Sub LoadExistInfo(ByVal ID As String)
        Dim mysql As String = "Select LY.LAYID, LY.DOCDATE, C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
        mysql &= "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        mysql &= "C.PHONE1 AS CONTACTNUMBER, C.BIRTHDAY, "
        mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, LYL.DOCDATE AS DATEPAYMENT, LYL.AMOUNT, "
        mysql &= "LY.BALANCE, LYL.STATUS AS LINESTATUS, LYL.PENALTY "
        mysql &= "From TBLLAYAWAY LY "
        mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
        mysql &= "INNER JOIN TBLLAYLINES LYL ON LYL.LAYID = LY.LAYID "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
        mysql &= "WHERE LYL.STATUS <> 'V' AND LY.LAYID = '" & ID & "'"
        Dim ds As DataSet = LoadSQL(mysql)
        With ds.Tables(0).Rows(0)
            Customer = New Client
            Customer.LoadClient(.Item("CLIENTID"))
            tmpLayID = .Item("LayID")
            LoadClient(Customer)


            txtItemCode.Text = .Item("ItemCOde")
            Item = New cItemData
            mysql = "Select * From ItemMaster Where ItemCode = '" & .Item("ItemCode") & "'"
            Dim ItmDs As DataSet = LoadSQL(mysql, "ItemMaster")
            Item.Load_Item(ItmDs.Tables(0).Rows(0).Item("ITEMID"))

            txtDescription.Text = .Item("Description")
            lblCost.Text = .Item("Price")


            If CurrentDate >= .Item("DocDate").AddDays(90).ToShortDateString Then
                tmpBalance = .Item("Balance") + (.Item("Price") * 0.02)
                lblBalance.Text = tmpBalance
                lblPenalty.Text = .Item("Price") * 0.02
            Else
                tmpBalance = .Item("Balance")
                lblBalance.Text = tmpBalance
                lblPenalty.Text = .Item("Penalty")
            End If
            isOld = True
            Disable()
        End With
    End Sub

    Private Sub btnSearchItemCode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchItemCode.Click
        With frmPLU
            .Show()
            .Load_PLU(txtItemCode.Text)
            .isLayAway = True
        End With
    End Sub

    Private Sub LayAwaySave()
        Dim lay As New LayAway
        Dim layLines As New LayAwayLines
        If isOld = True Then
            With layLines
                .LayID = tmpLayID
                .DocDate = CurrentDate
                .Amount = txtAmount.Text
                .Penalty = lblPenalty.Text
                .SaveLayAwayLines()
            End With
            If lblBalance.Text = 0 Then
                With lay
                    .Balance = CInt(lblBalance.Text)
                    .UpdateBalance(tmpLayID)
                End With


                'Dim mysql As String = "Select * From ItemMaster Where ItemCode = '" & txtItemCode.Text & "'"
                'Dim fillData As String = "ItemMaster"
                'Dim ds As DataSet = LoadSQL(mysql, fillData)
                'InventoryController.DeductInventory(txtItemCode.Text, ds.Tables(0).Rows(0).Item("Onhand"))
            End If
        Else
            With lay
                .DocDate = CurrentDate
                .ForfeitDate = CurrentDate.AddDays(90).ToShortDateString
                .CustomerID = Customer.ID
                .ItemCode = txtItemCode.Text
                .Price = lblCost.Text
                .Balance = lblBalance.Text
                .Status = "A"
                .SaveLayAway()
            End With

            With layLines
                .LayID = lay.LayLastID
                .DocDate = CurrentDate
                .Amount = txtAmount.Text
                .SaveLayAwayLines()
            End With
            lay.ItemOnLayMode(txtItemCode.Text)
        End If
    End Sub

    Private Sub txtItemCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtItemCode.KeyPress
        If isEnter(e) Then
            btnSearchItemCode.PerformClick()
        End If
    End Sub

    Private Sub Compute()
        If txtAmount.Text <> "" Then
            lblBalance.Text = tmpBalance - txtAmount.Text
        Else
            lblBalance.Text = tmpBalance
        End If
    End Sub
End Class