Public Class frmMassDiscount
    Private lvwColumnSorter As New ListViewColumnSorter

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lvItem.Items.Clear()
        Dim mysql As String = "Select * From ItemMaster Where Onhand = 1 And ItemCode <> 'RECALL00' "
            mysql &= "And UPPER(ItemCode) Like UPPER('%" & txtSearchCode.Text & "%') "
        mysql &= "OR UPPER(Description) Like UPPER('%" & txtSearchCode.Text & "%') OR UPPER(Categories) Like UPPER('%" & txtSearchCode.Text & "%')"
     
        Dim ds As DataSet = LoadSQL(mysql, "ItemMaster")

        For Each dr In ds.Tables(0).Rows
            LoadbyDatarow(dr)
        Next
    End Sub

    Private Sub frmMassDiscount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lvItem.Items.Clear()
        lvDiscount.Items.Clear()
        LoadItem()
        lvItem.ListViewItemSorter = lvwColumnSorter
        lvDiscount.ListViewItemSorter = lvwColumnSorter
    End Sub

    Private Sub LoadItem()
        Dim mysql As String = "Select * From ItemMaster Where Onhand = 1 And ItemCode <> 'RECALL00'"
        Dim ds As DataSet = LoadSQL(mysql, "ItemMaster")

        For Each dr In ds.Tables(0).Rows
            LoadbyDatarow(dr)
        Next

    End Sub

    Private Sub LoadbyDatarow(ByVal dr As DataRow)
        Dim lv As ListViewItem = lvItem.Items.Add(dr.Item("ITEMCODE"))

        lv.SubItems.Add(dr.Item("DESCRIPTION"))
        lv.SubItems.Add(dr.Item("CATEGORIES").ToString)
        lv.SubItems.Add(dr.Item("UOM").ToString)
        lv.SubItems.Add(dr.Item("ONHAND"))
        lv.SubItems.Add(ToCurrency(dr.Item("SALEPRICE")))
        lv.SubItems.Add("")

    End Sub

    Private Function ToCurrency(ByVal money As Double) As String
        Return money.ToString("#,##0.00")
    End Function

    Private Sub txtSearchCode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearchCode.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Friend Sub DisplayValue(ByVal Discount As Double, ByVal id As Integer)
        lvItem.Items(id).SubItems(6).Text = Discount
    End Sub

    Private Sub lvItem_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvItem.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lvItem.Sort()
    End Sub

    Private Sub btnAllPull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAllPull.Click
        If lvItem.Items.Count <= 0 Then Exit Sub

        For Each itm As ListViewItem In lvItem.Items
            Dim tmp As New cItemData
            tmp.ItemCode = itm.Text
            tmp.Load_Item()
            AddItemDiscount(tmp)
        Next
        lvItem.Items.Clear()
    End Sub

    Private Sub AddItemDiscount(ByVal dis As cItemData)
        For Each itm As ListViewItem In lvDiscount.Items
            If itm.Text.Contains(dis.ItemCode) Then Exit Sub
        Next

        Dim lv As ListViewItem = lvDiscount.Items.Add(dis.ItemCode)

        lv.SubItems.Add(dis.Description)
        lv.SubItems.Add(dis.Category)
        lv.SubItems.Add(dis.SalePrice)
        lv.SubItems.Add("")
    End Sub

    Private Sub btnOnePull_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOnePull.Click
        If lvItem.SelectedItems.Count <= 0 Then Exit Sub

        Dim idx As String = lvItem.FocusedItem.Text
        Dim tmp As New cItemData
        tmp.ItemCode = idx
        tmp.Load_Item()
        AddItemDiscount(tmp)
        lvItem.Items.RemoveAt(lvItem.FocusedItem.Index)
    End Sub

    Private Sub lvDiscount_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvDiscount.KeyDown
        If lvDiscount.SelectedItems.Count = 0 Then Exit Sub

        If e.KeyCode = Keys.Delete Then
            For Each itm As ListViewItem In lvDiscount.SelectedItems
                itm.Remove()
            Next
        End If
    End Sub

    Private Sub lvDiscount_ColumnClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnClickEventArgs) Handles lvDiscount.ColumnClick
        ' Determine if the clicked column is already the column that is 
        ' being sorted.
        If (e.Column = lvwColumnSorter.SortColumn) Then
            ' Reverse the current sort direction for this column.
            If (lvwColumnSorter.Order = SortOrder.Ascending) Then
                lvwColumnSorter.Order = SortOrder.Descending
            Else
                lvwColumnSorter.Order = SortOrder.Ascending
            End If
        Else
            ' Set the column number that is to be sorted; default to ascending.
            lvwColumnSorter.SortColumn = e.Column
            lvwColumnSorter.Order = SortOrder.Ascending
        End If

        ' Perform the sort with these new sort options.
        Me.lvItem.Sort()
    End Sub

    Private Sub btnSearchItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchItem.Click

        For Each itm As ListViewItem In lvDiscount.Items
            If itm.Text.Contains(UCase(txtSearchItem.Text)) Then
                itm.Selected = True
                Exit For
            End If
        Next
    End Sub
End Class