Public Class frmPLU

    Private qtyItm As Double = 1
    Private queued_IMD As New CollectionItemData
    Private Modname As String = ""

    Private fromSales As Boolean = True
    Private fromInventory As Boolean = False
    Private isRedeem As Boolean = False
    Friend isLayAway As Boolean = False
    Friend isCustomPrice As Boolean = False
    Friend isStockOut As Boolean = False

    Friend Sub From_Sales()
        Me.fromSales = True
        Me.fromInventory = False

        txtCode.Select()
    End Sub

    Friend Sub From_Inventories()
        Me.fromSales = False
        Me.fromInventory = True

        txtCode.Select()
    End Sub

    Friend Sub isAuctionRedeem()
        Me.isRedeem = True
        txtCode.Select()
    End Sub

    Private Sub frmPLU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        If isLayAway = True Then
            btnStock.Text = "Payments"
            'btnDiscount.Visible = False
            'btnCustom.Visible = False
        End If
    End Sub

    Friend Sub RefreshList(Optional ByVal ItemCode As String = "")
        If ItemCode = "" Then
            Load_PLU()
            Exit Sub
        End If

        Dim loadITEM As New cItemData
        loadITEM.Load_Item(ItemCode)
        Dim lv As ListViewItem = lvItem.FindItemWithText(ItemCode)
        lv.SubItems(1).Text = loadITEM.Description
        lv.SubItems(2).Text = loadITEM.Category
        lv.SubItems(3).Text = loadITEM.UnitofMeasure
        lv.SubItems(4).Text = loadITEM.onHand
        If fromSales Then lv.SubItems(5).Text = ToCurrency(loadITEM.SalePrice)
        If fromInventory Then lv.SubItems(5).Text = ToCurrency(loadITEM.UnitPrice)
    End Sub

    Private Function ToCurrency(ByVal money As Double) As String
        Return money.ToString("#,##0.00")
    End Function

    Private Sub ClearFields()
        txtCode.Text = ""
        lvItem.Items.Clear()
    End Sub

#Region "ProgressBar"
    Private Sub PG_Init(ByVal st As Boolean, Optional ByVal max As Integer = 0)
        pb_itm.Visible = st
        pb_itm.Value = 0
        pb_itm.Maximum = max

        Me.Enabled = Not st
    End Sub

    Private Sub pgValue(ByVal val As Integer)
        pb_itm.Value = val
    End Sub
#End Region

    Friend Sub Load_PLU(Optional ByVal src As String = "")
        Dim quickLoader As Integer = 0
        Dim mySql As String
        Dim ds As DataSet
        lvItem.Items.Clear()

        queued_IMD.Clear()

        If isRedeem Then
            mySql = "SELECT PT.*,ITEM.ITEMCLASS,CL.SALESID,CL.COSTID "
            mySql &= vbCrLf & "FROM OPT PT "
            mySql &= vbCrLf & "INNER JOIN OPI ITEM "
            mySql &= vbCrLf & "ON ITEM.PAWNITEMID = PT.PAWNITEMID "
            mySql &= vbCrLf & "INNER JOIN TBLITEM CL "
            mySql &= vbCrLf & "ON CL.ITEMID = ITEM.ITEMID "
            mySql &= vbCrLf & "WHERE PT.STATUS = 'S'"
            If src <> "" Then
                mySql &= vbCrLf & " AND ("
                If IsNumeric(src) Then
                    mySql &= String.Format("PT.PAWNTICKET LIKE '%{0}%' OR ", src)
                End If
                mySql &= String.Format("LOWER(PT.DESCRIPTION) LIKE '%{0}%'", DreadKnight(src).ToLower)
                mySql &= ")"
            End If

            ds = LoadSQL("SELECT COUNT(*) FROM OPT WHERE STATUS = 'S'")
        ElseIf isLayAway Then

            mySql = "Select FIRST 100 * FROM ITEMMASTER WHERE isLayAway <> 0 "
            If src <> "" Then
                mySql = "Select * From ItemMaster Where isLayAway <> 0 "
                mySql &= "AND (Upper(ItemCode) LIKE Upper('%" & src & "%') OR UPPER(DESCRIPTION) LIKE UPPER('%" & src & "%')) "
            End If

            ds = LoadSQL("Select Count(*) From ItemMaster Where isLayAway <> 0 ")
        Else
            mySql = "SELECT FIRST 100 * FROM ITEMMASTER WHERE onHold = 0 AND ItemCode <> 'RECALL00' AND ItemCode <> 'IND 00001' AND onHand <> 0 AND OnLayAway <> 1 ORDER BY ITEMCODE ASC"

            If src <> "" Then
                mySql = "SELECT * FROM ITEMMASTER WHERE onHold = 0"
                mySql &= String.Format(" AND (LOWER(ITEMCODE) LIKE '%{0}%' OR LOWER(DESCRIPTION) LIKE '%{0}%' OR LOWER(CATEGORIES) LIKE '%{0}%' OR LOWER(SUBCAT) LIKE '%{0}%' OR LOWER(BARCODE) LIKE '%{0}%') AND ItemCode <> 'RECALL00' ", src.ToLower)
                mySql &= " AND onLayAway <> 1 "
                mySql &= " ORDER BY ITEMCODE ASC"
            End If

            ds = LoadSQL("SELECT COUNT(*) FROM ITEMMASTER WHERE onHold = 0 AND ItemCode <> 'RECALL00' AND ItemCode <> 'IND 00001' AND onLayAway <> 1")
        End If

        Dim MaxResult As Integer = ds.Tables(0).Rows(0).Item(0)
        If MaxResult = 0 Then Exit Sub

        Console.WriteLine("SQL: " & mySql)

        'If Not txtCode.Text = "" Then Exit Sub
        dbReaderOpen()
        Dim dsR = LoadSQL_byDataReader(mySql)
        PG_Init(True, MaxResult)
        While dsR.Read

            Dim itmReader As New cItemData
            If isRedeem Then
                With itmReader
                    .ItemCode = "RECALL00"
                    .Load_ItemCode()

                    .Description = String.Format("PT#{0:000000} {1}", dsR("PAWNTICKET"), dsR("DESCRIPTION"))
                    .Category = dsR("ITEMCLASS")
                    .UnitofMeasure = "PIECE"
                    .UnitPrice = dsR("PRINCIPAL")
                    .SalePrice = dsR("PRINCIPAL")
                    .Tags = dsR("PAWNTICKET")
                    .AuctionID = dsR("SALESID")
                    .CostID = dsR("COSTID")
                End With
            Else
                itmReader.LoadReader_Item(dsR)
            End If
            queued_IMD.Add(itmReader)
            AddItem(itmReader)

            quickLoader += 1
            pgValue(quickLoader)
            If quickLoader Mod 10 = 0 Then Application.DoEvents()
        End While
        dbReaderClose()

        PG_Init(False)

        AutoSelect()
    End Sub

    Friend Sub SearchSelect(ByVal unsecured_String As String)
        Dim qty As String = ""

        If Not unsecured_String.Contains("*") Then
            txtCode.Text = unsecured_String
        Else
            qty = unsecured_String.Split("*")(0)
            qtyItm = If(IsNumeric(qty), qty, 0)
            txtCode.Text = unsecured_String.Split("*")(1)
        End If

        btnSearch.PerformClick()
    End Sub

#Region "GUI"
    Private Sub AddItem(ByVal itm As cItemData)
        Dim lv As ListViewItem = lvItem.Items.Add(itm.ItemCode)
        If itm.onHold Then lv.BackColor = Color.Red : lv.ForeColor = Color.White : lv.ToolTipText = String.Format("{0} is ON HOLD", itm.ItemCode)

        lv.SubItems.Add(itm.Description)
        lv.SubItems.Add(itm.Category)
        lv.SubItems.Add(itm.UnitofMeasure)
        lv.SubItems.Add(IIf(isRedeem, 1, itm.onHand))
        lv.SubItems.Add(ToCurrency(itm.SalePrice))

        If itm.OnLayAway Then lv.BackColor = Color.Yellow
    End Sub

    Private Sub ClearField()
        txtCode.Text = ""
        lvItem.Items.Clear()
    End Sub

    Private Sub AutoSelect()
        lvItem.Focus()
        If lvItem.Items.Count = 0 Then Exit Sub

        lvItem.Items(0).Selected = True
    End Sub
#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim unsec_src As String = txtCode.Text

        Load_PLU(DreadKnight(unsec_src))
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Console.WriteLine(lvItem.SelectedItems(0).Index)
        Dim idx As Integer = lvItem.SelectedItems(0).Index
        Dim LayAmount As Double = 0

        Dim selected_Itm As New cItemData
        selected_Itm = queued_IMD.Item(idx)
        If selected_Itm.onHold Then
            MsgBox("ITEM IS CURRENTLY ONHOLD", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Dim hasSelected As Boolean = False

        If selected_Itm.OnLayAway = False Then
            If selected_Itm.SalePrice = 0 Or isRedeem Then

                For Each AddedItems As ListViewItem In frmSales.lvSale.Items

                    If AddedItems.Text = selected_Itm.ItemCode Then
                        hasSelected = True
                        Exit For
                    End If
                Next

                If hasSelected = False Then
                    If isStockOut = True Then GoTo NextLineTODO
                    OTPCustomPrice_Initialization()

                    If Not isOTPOn("CustomPrice") Then
                        diagGeneralOTP.GeneralOTP = OtpSettings
                        diagGeneralOTP.TopMost = True
                        diagGeneralOTP.ShowDialog()
                        If Not diagGeneralOTP.isValid Then
                            Exit Sub
                        Else
                            isCustomPrice = True
                            GoTo NextLineTODO
                        End If
                    Else
                        isCustomPrice = True
                        GoTo NextLineTODO
                    End If
NextLineTODO:
                    Dim tmp As String = String.Empty
                    'InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
                    While Not IsNumeric(tmp)
                        tmp = InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
                        If tmp = "" Then Exit Sub
                    End While

                    Dim customPrice As Double = CDbl(tmp)
                    selected_Itm.SalePrice = customPrice
                    LayAmount = customPrice
                Else
                    If isRedeem Then
                        If isStockOut = True Then GoTo NextLineTODO1
                        If Not isOTPOn("CustomPrice") Then
                            diagGeneralOTP.GeneralOTP = OtpSettings
                            diagGeneralOTP.TopMost = True
                            diagGeneralOTP.ShowDialog()
                            If Not diagGeneralOTP.isValid Then
                                Exit Sub
                            Else
                                isCustomPrice = True
                                GoTo NextLineTODO1
                            End If
                        Else
                            isCustomPrice = True
                            GoTo NextLineTODO1
                        End If
NextLineTODO1:
                        Dim tmp As String = InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
                        While Not IsNumeric(tmp)
                            tmp = InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
                            If tmp = "" Then Exit Sub
                        End While

                        Dim customPrice As Double = CDbl(tmp)
                        selected_Itm.SalePrice = customPrice
                    Else
                        selected_Itm.SalePrice = frmSales.lvSale.FindItemWithText(selected_Itm.ItemCode).SubItems(4).Text.ToString
                    End If
                End If
            End If

            Dim UnitPrice As Double = 0
            If fromInventory Then
                If isStockOut = True Then GoTo NextLineTODO2
                If Not isOTPOn("CustomPrice") Then
                    diagGeneralOTP.GeneralOTP = OtpSettings
                    diagGeneralOTP.TopMost = True
                    diagGeneralOTP.ShowDialog()
                    If Not diagGeneralOTP.isValid Then
                        Exit Sub
                    Else
                        isCustomPrice = True
                        GoTo NextLineTODO2
                    End If
                Else
                    isCustomPrice = True
                    GoTo NextLineTODO2
                End If
NextLineTODO2:

                UnitPrice = InputBox("Price: ", "Custom Unit Price", selected_Itm.UnitPrice)
            End If

            If isLayAway = True Then
                frmLayAway.Show()
                frmLayAway.LoadItemEncode(selected_Itm)
                frmLayAway.isNewLayAway = True
                If Not isOTPOn("CustomPrice") Then
                    If isCustomPrice Then
                        Dim NewOtp As New ClassOtp("Lay Away Custom Price", diagGeneralOTP.txtPIN.Text, "ItemCode: " & selected_Itm.ItemCode & _
                                        ", Custom Price:" & selected_Itm.SalePrice)
                    End If
                End If
            Else
                If fromSales Then
                    If isRedeem Then qtyItm = 1
                    selected_Itm.Quantity = qtyItm
                    selected_Itm.SRP = selected_Itm.SalePrice
                    selected_Itm.Discount = 0

                    If isRedeem = True Then
                        frmSales.AddItem(selected_Itm, True)
                    Else
                        frmSales.AddItem(selected_Itm)
                    End If
                    frmSales.ClearSearch()

                    If isStockOut = True Then GoTo stockout
                    If Not isOTPOn("CustomPrice") Then
                        If isCustomPrice Then
                            Select Case frmSales.TransactionMode
                                Case frmSales.TransType.Returns : Modname = "Returns"
                                Case frmSales.TransType.Cash : Modname = "Cash"
                                Case frmSales.TransType.Check : Modname = "Check"
                                Case frmSales.TransType.Auction : Modname = "Auction"
                            End Select
                            Dim NewOtp As New ClassOtp(Modname & " Custom Price", diagGeneralOTP.txtPIN.Text, "ItemCode: " & selected_Itm.ItemCode & _
                                          ", Custom Price:" & selected_Itm.SalePrice)
                        End If
                    End If
stockout:
                End If
            End If
        Else
            frmLayAway.Show()
            frmLayAway.LoadExistInfo(selected_Itm.ItemCode)
        End If
        Me.Close()
    End Sub

    Private Sub lvItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvItem.KeyPress
        If Asc(e.KeyChar) = 13 Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub txtCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCode.KeyPress
        If Asc(e.KeyChar) = 13 Then btnSearch.PerformClick()
    End Sub

    Private Sub txtCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCode.LostFocus
        AutoSelect()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As String = lvItem.FocusedItem.Index
        Dim selectedITM As New cItemData
        selectedITM = queued_IMD.Item(idx)

        frmIMD.Show()
        frmIMD.Load_ItemData(selectedITM)
    End Sub

    Private Sub btnStock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStock.Click
        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer
        idx = lvItem.FocusedItem.Index
        Console.WriteLine(lvItem.Items(idx).Text)
        If isLayAway = True Then
            If lvItem.SelectedItems.Count = 0 Then Exit Sub

            frmLayAwayPaymentList.Show()
            frmLayAwayPaymentList.LoadListPayment(lvItem.Items(idx).Text)
        Else
            frmView_Stock.Load_ItemCode(lvItem.Items(idx).Text)
            frmView_Stock.Show()
        End If
    End Sub

    Private Sub btnDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDiscount.Click
        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvItem.SelectedItems(0).Index
        Dim selected_Itm As New cItemData
        selected_Itm = queued_IMD.Item(idx)

        If selected_Itm.OnLayAway = True Then MsgBox("ItemCode " & selected_Itm.ItemCode & " Already on Layaway", MsgBoxStyle.Critical, "Error") : Exit Sub
        If selected_Itm.SalePrice = 0 Then MsgBox("ItemCode " & selected_Itm.ItemCode & " No Price", MsgBoxStyle.Critical, "Error") : Exit Sub
        Dim price As Double = selected_Itm.SalePrice
        Dim discount As Integer = selected_Itm.Discount
        Dim i As Double, subTotal As Double

        If selected_Itm.Discount <> 0 Then
            i = (Val(discount) / 100)
            subTotal = Val(price) * i
            selected_Itm.SalePrice = Val(price) - subTotal
        End If

        selected_Itm.Quantity = qtyItm
        selected_Itm.SRP = price

        If isLayAway = False Then
           
            frmSales.AddItem(selected_Itm)
            frmSales.Show()
        Else
            frmLayAway.Show()
            frmLayAway.LoadItemEncode(selected_Itm)
            frmLayAway.isNewLayAway = True
        End If
       
        Me.Close()
    End Sub

    Private Sub btnCustom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCustom.Click
        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvItem.SelectedItems(0).Index

        Dim selected_Itm As New cItemData
        selected_Itm = queued_IMD.Item(idx)

        If selected_Itm.OnLayAway = True Then MsgBox("ItemCode " & selected_Itm.ItemCode & " Already on Layaway", MsgBoxStyle.Critical, "Error") : Exit Sub

        If isStockOut = True Then GoTo NextLineTODO
        OTPCustomPrice_Initialization()

        If Not isOTPOn("CustomPrice") Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.TopMost = True
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isValid Then
                Exit Sub
            Else
                GoTo NextLineTODO
            End If
        Else
            GoTo NextLineTODO
        End If

NextLineTODO:
       
        selected_Itm.Quantity = qtyItm
        Dim tmp As String = String.Empty '= InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
        While Not IsNumeric(tmp)
            tmp = InputBox("Enter Price", "Custom Price", selected_Itm.SalePrice)
            If tmp = "" Then Exit Sub
        End While

        Dim customPrice As Double = CDbl(tmp)
        selected_Itm.SRP = selected_Itm.SalePrice
        selected_Itm.SalePrice = customPrice

        'If Not isOTPOn("CustomPrice") Then
        Select Case frmSales.TransactionMode
            Case frmSales.TransType.Returns : Modname = "Returns"
            Case frmSales.TransType.Cash : Modname = "Cash"
            Case frmSales.TransType.Check : Modname = "Check"
            Case frmSales.TransType.Auction : Modname = "Auction"
        End Select
        Dim NewOtp As New ClassOtp(Modname & " Custom Price", diagGeneralOTP.txtPIN.Text, "ItemCode: " & selected_Itm.ItemCode & _
                                   ", Custom Price:" & selected_Itm.SalePrice)
        'End If
        If isLayAway = False Then
            frmSales.AddItem(selected_Itm)
            frmSales.ClearSearch()
        Else
            frmLayAway.Show()
            frmLayAway.LoadItemEncode(selected_Itm)
            frmLayAway.isNewLayAway = True
        End If

        Me.Close()
    End Sub

    Private Sub lvItem_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lvItem.MouseClick
        If lvItem.SelectedItems.Count = 0 Then Exit Sub
        Dim idx As Integer = lvItem.SelectedItems(0).Index

        Dim selected_Itm As New cItemData
        selected_Itm = queued_IMD.Item(idx)

        If isLayAway = True Then
            If selected_Itm.OnLayAway = True Then
                btnDiscount.Visible = False
                btnCustom.Visible = False
            Else
                btnDiscount.Visible = True
                btnCustom.Visible = True
            End If
        End If
    End Sub
End Class