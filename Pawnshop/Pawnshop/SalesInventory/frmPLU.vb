Public Class frmPLU

    Private qtyItm As Double = 1
    Private queued_IMD As New CollectionItemData

    Private fromSales As Boolean = True
    Private fromInventory As Boolean = False

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

    Private Sub frmPLU_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        For Each itm As cItemData In queued_IMD
            Console.WriteLine(itm.ItemCode)
        Next
    End Sub

    Private Sub frmPLU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
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
        lv.SubItems(3).Text = loadITEM.UnitOfMeasure
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

    Friend Sub Load_PLU()
        Dim quickLoader As Integer = 0
        Dim mySql As String = "SELECT * FROM ITEMMASTER WHERE onHold = 0 ORDER BY ITEMCODE ASC"

        Dim ds As DataSet = LoadSQL("SELECT COUNT(*) FROM ITEMMASTER WHERE onHold = 0")
        Dim MaxResult As Integer = ds.Tables(0).Rows(0).Item(0)

        If Not txtCode.Text = "" Then Exit Sub
        dbReaderOpen()
        Dim dsR = LoadSQL_byDataReader(mySql)
        PG_Init(True, MaxResult)
        While dsR.Read

            Dim itmReader As New cItemData
            itmReader.LoadReader_Item(dsR)
            queued_IMD.Add(itmReader)
            AddItem(itmReader)

            quickLoader += 1
            pgValue(quickLoader)
            If quickLoader Mod 10 = 0 Then Application.DoEvents()
        End While
        dbReaderClose()

        PG_Init(False)
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
        lv.SubItems.Add(itm.onHand)
        lv.SubItems.Add(ToCurrency(itm.SalePrice))
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

        Dim mySql As String = "SELECT * FROM ITEMMASTER "
        mySql &= String.Format("WHERE LOWER(ITEMCODE) LIKE '%{0}%' OR LOWER(DESCRIPTION) LIKE '%{0}%' OR LOWER(CATEGORIES) LIKE '%{0}%' OR LOWER(SUBCAT) LIKE '%{0}%' OR LOWER(BARCODE) LIKE '%{0}%'", DreadKnight(unsec_src).ToLower)

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("ITEM NOT FOUND", MsgBoxStyle.Information) : Exit Sub

        ' Clear in Collections
        lvItem.Items.Clear()
        queued_IMD.Clear()

        dbReaderOpen()

        Dim dsR = LoadSQL_byDataReader(mySql)
        While dsR.Read

            Dim tmpItm As New cItemData
            tmpItm.LoadReader_Item(dsR)
            AddItem(tmpItm)

        End While

        dbReaderClose()
        AutoSelect()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvItem.SelectedItems.Count = 0 Then Exit Sub

        Console.WriteLine(lvItem.SelectedItems(0).Index)
        Dim idx As Integer = lvItem.SelectedItems(0).Index

        Dim selected_Itm As New cItemData
        selected_Itm.Load_Item(lvItem.SelectedItems(0).Text)

        If selected_Itm.SalePrice = 0 Then
            Dim customPrice As Double = InputBox("Enter Price", "Custom Price", 0)
            selected_Itm.SalePrice = customPrice
        End If

        Dim UnitPrice As Double = 0
        If fromInventory Then
            UnitPrice = InputBox("Price: ", "Custom Unit Price", selected_Itm.UnitPrice)
        End If

        If fromSales Then
            frmSales.AddItem(selected_Itm, qtyItm)
            frmSales.ClearSearch()
        Else
            'frmInventoryIn.AddItem(selected_Itm, qtyItm, UnitPrice)
            'frmInventoryIn.ClearSearch()
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

        Dim itmCode As String = lvItem.FocusedItem.Text
        Dim selectedITM As New cItemData
        selectedITM.Load_Item(itmCode)

        frmIMD.Show()
        frmIMD.Load_ItemData(selectedITM)
    End Sub
End Class