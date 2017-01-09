Public Class frmLayAway

    Friend Customer As Client
    Dim tmpBalance As Integer = 0
    Dim tmpDate As Date

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If Not Compute() Then Exit Sub
        If Customer Is Nothing Then MsgBox("No Customer Selected!", MsgBoxStyle.Information, "Error") : Exit Sub
        If lblPenalty.Text = Nothing Then lblPenalty.Text = 0
        frmSales.LayCustomer = Customer.ID
        frmSales.LayItemCode = txtItemCode.Text
        frmSales.LayCost = CInt(lblCost.Text)
        frmSales.LayAmount = txtAmount.Text
        frmSales.LayBalance = CInt(lblBalance.Text)
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

    Friend Sub LoadItemEncode(ByVal Item As cItemData)
        txtItemCode.Text = Item.ItemCode
        txtDescription.Text = Item.Description
        lblCost.Text = Item.SalePrice
        tmpBalance = Item.SalePrice

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

    Private Function Compute() As Boolean
        Dim tmpPercent As Integer = CInt(lblCost.Text) * 0.2
        If Not txtAmount.Text >= tmpPercent Then
            MsgBox("Please Paid at least 20%", MsgBoxStyle.Information, "Not Valid!")
            Return False
        End If
        Return True
    End Function

    Private Sub txtAmount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        If txtAmount.Text <> "" Then
            lblBalance.Text = tmpBalance - txtAmount.Text
        Else
            lblBalance.Text = tmpBalance
        End If
    End Sub

    Friend Sub LoadExistInfo(ByVal Item As String)
        Dim mysql As String = "Select LY.LAYID, LY.DOCDATE, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
        mysql &= "C.ADDR_STREET || ' ' || C.ADDR_CITY || ' ' || C.ADDR_PROVINCE || ' ' || C.ADDR_ZIP as FULLADDRESS, "
        mysql &= "C.PHONE1 AS CONTACTNUMBER, C.BIRTHDAY, "
        mysql &= "LY.ITEMCODE, ITM.DESCRIPTION , LY.PRICE, LY.STATUS, LYL.DOCDATE AS DATEPAYMENT, LYL.AMOUNT, "
        mysql &= "LYL.BALANCE, LYL.STATUS AS LINESTATUS "
        mysql &= "From TBLLAYAWAY LY "
        mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = LY.CUSTOMERID "
        mysql &= "INNER JOIN TBLLAYLINES LYL ON LYL.LAYID = LY.LAYID "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = LY.ITEMCODE "
        mysql &= "WHERE LYL.STATUS <> 'V' AND LY.ITEMCODE = '" & Item & "'"
        Dim ds As DataSet = LoadSQL(mysql)
        With ds.Tables(0).Rows(0)
            txtCustomer.Text = .Item("FULLNAME")
            txtAddress.Text = .Item("FULLADDRESS")
            lblContact.Text = .Item("CONTACTNUMBER")
            lblDOB.Text = .Item("BIRTHDAY")
            lblCost.Text = .Item("Price")
            txtItemCode.Text = .Item("ItemCOde")
            txtDescription.Text = .Item("Description")

            tmpDate = .Item("DocDate").AddDays(90).ToShortDateString
            If CurrentDate >= tmpDate Then
                tmpBalance = .Item("Balance") + (.Item("Price") * 0.02)
                lblBalance.Text = tmpBalance
            Else
                tmpBalance = .Item("Balance")
                lblBalance.Text = tmpBalance
            End If
           
        End With
    End Sub
End Class