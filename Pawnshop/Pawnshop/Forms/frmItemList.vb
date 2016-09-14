Public Class frmItemList
    Dim mOtherForm As Boolean = False

    Dim frmOrig As formSwitch.FormName
    Dim ds As New DataSet

    Friend GetItem As Item

    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        If Not mOtherForm Then ClearField()

        LoadActiveItem()
        'LoadSpec()

        If Not mOtherForm Then
            txtSearch.Focus()
        End If

        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub


    Friend Sub LoadActiveItem(Optional ByVal mySql As String = "SELECT * FROM tbl_ITEM where ITEMID <> 0 ORDER BY itemid ASC")
        Dim ds As DataSet
        ds = LoadSQL(mySql)
        lvItem.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpItem As New Item
            tmpItem.LoaditemByRow(dr)
            AddItem(tmpItem)
        Next
    End Sub

    Friend Sub LoadSpec(Optional ByVal mySql As String = "Select * from tbl_specification where specid <> 0 ORDER BY SPECID ASC")
        Dim ds As DataSet
        ds = LoadSQL(mySql)
        lvItem.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpItem As New Item
            tmpItem.LoadSpecByRow(dr)
            'AddItem(tmpItem)
        Next
    End Sub

    Private Sub AddItem(ByVal dl As Item)
        Dim lv As ListViewItem = lvItem.Items.Add(dl.itemID)
        lv.SubItems.Add(dl.Classification)
        lv.SubItems.Add(dl.Category)
        lv.SubItems.Add(dl.Description)
        lv.SubItems.Add(dl.PrintLayout)
    End Sub


    Private Sub ClearField()
        txtSearch.Text = ""
        lvItem.Items.Clear()
    End Sub


    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvItem.Items.Count = 0 Then Exit Sub

        If lvItem.SelectedItems.Count = 0 Then
            lvItem.Items(0).Focused = True
        End If
        Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
        GetItem = New Item
        GetItem.LoadItem(idx)
        GetItem.LoadSpec(idx)
        formSwitch.ReloadFormFromSearch2(frmOrig, GetItem)
        lblItemID.Text = idx
        frmAdminPanel.LoadSpec()
        Me.Hide()

    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchItem()
    End Sub
    Private Sub searchItem()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM tbl_ITEM WHERE "
        mySql &= String.Format("UPPER (ITEMCATEGORY) LIKE UPPER('%{0}%')", secured_str)

        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count

        lvItem.Items.Clear()

        If MaxRow <= 0 Then
            Console.WriteLine("No Item List Found")
            MsgBox("Query not found", MsgBoxStyle.Information)
            txtSearch.SelectAll()
            lvItem.Items.Clear()
            Exit Sub
        End If

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Item")
        LoadActiveItem(mySql)
    End Sub

   
    Private Sub lvItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvItem.KeyDown
        If e.KeyCode = Keys.Enter Then
            If Not mOtherForm Then
                btnView.PerformClick()
            Else
                btnSelect.PerformClick()
            End If
        End If
    End Sub

    Private Sub lvItem_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick

        If Not mOtherForm Then
            btnView.PerformClick()
        Else
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub lvItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.Click
        Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
        GetItem = New Item
        GetItem.LoadItem(idx)
        formSwitch.ReloadFormFromSearch2(frmOrig, GetItem)
        lblItemID.Text = idx
    End Sub

  
    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
        frmAdminPanel.Show()
    End Sub

    Private Sub frmItemList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        frmAdminPanel.btnUpdate.Enabled = False
        frmAdminPanel.btnSave.Enabled = True
        frmAdminPanel.clearfields()
        frmAdminPanel.reaDOnlyFalse()
    End Sub
   
    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        
        If lvItem.SelectedItems.Count <= 0 Then Exit Sub

        Dim ItemID As Integer
        ItemID = lvItem.FocusedItem.Text
        Console.WriteLine("ITEMID : " & ItemID)

        Dim tempITEM As New Item
        tempITEM.LoadItem(ItemID)

        frmAdminPanel.Show()
        frmAdminPanel.LoadItemall(tempITEM)
        frmAdminPanel.LoadSpec()
        Me.Hide()
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        If lvItem.Items.Count = 0 Then Exit Sub

        If lvItem.SelectedItems.Count = 0 Then
            lvItem.Items(0).Focused = True
        End If
        Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
        GetItem = New Item
        GetItem.LoadItem(idx)
        formSwitch.ReloadFormFromSearch2(frmOrig, GetItem)
        lblItemID.Text = idx
        frmAdminPanel.LoadItemall(GetItem)
        frmAdminPanel.LoadSpec()
        Me.Hide()
    End Sub
End Class