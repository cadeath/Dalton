Public Class frmItemList
    Dim mOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName
    Dim ds As New DataSet

    Friend Sub LoadActiveItem(Optional ByVal mySql As String = "SELECT * FROM tblITEM where ITEMID <> 0 ORDER BY itemid ASC")
        Dim ds As DataSet
        ds = LoadSQL(mySql)
        lvItem.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpItem As New ItemClass
            tmpItem.LoadByRow(dr)
            AddItem(tmpItem)
        Next
    End Sub

    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' ClearField()
        ' If Not mOtherForm Then ClearField()


        'loadItemClass()
        LoadActiveItem()

        If Not mOtherForm Then
            txtSearch.Focus()
        End If

        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub AddItem(ByVal dl As ItemClass)
        Dim lv As ListViewItem = lvItem.Items.Add(dl.ID)
        lv.SubItems.Add(dl.ItemClass)
        lv.SubItems.Add(dl.Category)
        lv.SubItems.Add(dl.Description)
        'lv.SubItems.Add(dl.InterestRate)
        lv.SubItems.Add(dl.isRenewable)
        lv.SubItems.Add(dl.PrintLayout)
    End Sub

    'Private Sub loadItemClass()
    '    Dim mySql As String = "SELECT * FROM tblItem"
    '    Dim ds As DataSet = LoadSQL(mySql)

    '    lvItem.Items.Clear()
    '    For Each dr As DataRow In ds.Tables(0).Rows

    '        Dim lv As ListViewItem = lvItem.Items.Add(dr("ItemID"))
    '        lv.SubItems.Add(dr("ItemClass"))
    '        lv.SubItems.Add(dr("ItemCategory"))
    '        lv.SubItems.Add(dr("Description"))
    '        ' lv.SubItems.Add(dr("Int_rate"))
    '        lv.SubItems.Add(dr("IsRenew"))
    '        lv.SubItems.Add(dr("Print_Layout"))
    '    Next
    'End Sub

    Private Sub ClearField()
        txtSearch.Text = ""
        lvItem.Items.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchItem()
    End Sub
    Private Sub searchItem()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM tblITEM WHERE "
        mySql &= String.Format("UPPER (ITEMCLASS) LIKE UPPER('%{0}%')", secured_str)

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
        For Each dr As DataRow In ds.Tables(0).Rows

            Dim lv As ListViewItem = lvItem.Items.Add(dr("ItemID"))
            lv.SubItems.Add(dr("ItemClass"))
            lv.SubItems.Add(dr("ItemCategory"))
            lv.SubItems.Add(dr("Description"))
            lv.SubItems.Add(dr("Int_rate"))
            lv.SubItems.Add(dr("IsRenew"))
            lv.SubItems.Add(dr("Print_Layout"))
        Next
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


    ''Private Sub lvItem_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
    ''    If Not mOtherForm Then
    ''        btnView.PerformClick()
    ''    Else
    ''        btnSelect.PerformClick()
    ''    End If
    ''End Sub

    ' ''Private Sub lvItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.Click
    ' ''    Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
    ' ''    GetItem = New Item
    ' ''    GetItem.LoadItem(idx)

    ' ''    GetItem.LoadSpec(idx)

    ' ''    formSwitch.ReloadFormFromSearch2(frmOrig, GetItem)
    ' ''    lblItemID.Text = idx
    ' ''End Sub


    ''Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
    ''    Me.Close()
    ''    frmAdminPanel.Show()
    ''End Sub

    ''Private Sub frmItemList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
    ''    frmAdminPanel.btnUpdate.Enabled = False
    ''    frmAdminPanel.btnSave.Enabled = True
    ''    frmAdminPanel.clearfields()
    ''    frmAdminPanel.reaDOnlyFalse()
    ''End Sub

    ''Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

    ''    If lvItem.SelectedItems.Count <= 0 Then Exit Sub

    ''    Dim ItemID As Integer
    ''    ItemID = lvItem.FocusedItem.Text
    ''    Console.WriteLine("ITEMID : " & ItemID)

    ''    Dim tempITEM As New Item
    ''    tempITEM.LoadItem(ItemID)
    ''    lblItemID.Text = ItemID

    ''    frmAdminPanel.LoadItemall(tempITEM)
    ''    frmAdminPanel.LoadSpec()
    ''    frmAdminPanel.Show()
    ''    Me.Hide()
    ''End Sub

    ''Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

    ''    If lvItem.Items.Count = 0 Then Exit Sub

    ''    If lvItem.SelectedItems.Count = 0 Then
    ''        lvItem.Items(0).Focused = True
    ''    End If
    ''    Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
    ''    GetItem = New Item
    ''    GetItem.LoadItem(idx)
    ''    GetItem.LoadSpec(idx)

    ''    lblItemID.Text = (idx)


    ''    formSwitch.ReloadFormFromSearch2(frmOrig, GetItem)
    ''    ' lblItemID.Text = idx
    ''    ' frmAdminPanel.LoadItemall(GetItem)
    ''    'frmAdminPanel.LoadSpec()
    ''    Me.Hide()

    ''End Sub


    'Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

    '    If lvItem.Items.Count = 0 Then Exit Sub

    '    If lvItem.SelectedItems.Count = 0 Then
    '        lvItem.Items(0).Focused = True
    '    End If
    '    Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
    '    Dim getitem As ItemClass
    '    Dim getspec As ItemSpecs = New ItemSpecs

    '    getitem = New ItemClass
    '    getitem.LoadItem(idx)

    '    getspec.LoadItemSpecs(idx)
    '    lblItemID.Text = (idx)


    '    formSwitch.ReloadFormFromSearch2(frmOrig, GetItem)
    '    ' lblItemID.Text = idx
    '    ' frmAdminPanel.LoadItemall(GetItem)
    '    'frmAdminPanel.LoadSpec()
    '    Me.Hide()

    'End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        mOtherForm = True
        btnSelect.Visible = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    ''Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
    ''    mOtherForm = True
    ''    btnSelect.Visible = True
    ''    txtSearch.Text = src
    ''    frmOrig = frmOrigin
    ''End Sub

   
    
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        'If lvClient.Items.Count = 0 Then Exit Sub

        'If lvClient.SelectedItems.Count = 0 Then
        '    lvClient.Items(0).Focused = True
        'End If
        'Dim idx As Integer = CInt(lvClient.FocusedItem.Text)
        'GetClient = New Client
        'GetClient.LoadClient(idx)


        'formSwitch.ReloadFormFromSearch(frmOrig, GetClient)

        'Me.Close()
        

        Dim idx As Integer = CInt(lvItem.FocusedItem.Text)

        Dim selectedItem As New ItemClass
        selectedItem.LoadItem(idx)

        'lblItemID.Text = selectedItem.ID


        'lvItem.Items.Clear()
        'For Each spec As ItemSpecs In selectedItem.ItemSpecifications
        '    lvItem.Items.Add(spec.SpecName)
        'Next

        formSwitch.ReloadFormFromSearch2(frmOrig, selectedItem)
        Me.Close()

    End Sub


    Private Sub lvItem_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
        'If Not mOtherForm Then
        '    btnView.PerformClick()
        'Else
        btnSelect.PerformClick()
        'End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
       Dim idx As Integer = CInt(lvItem.FocusedItem.Text)
      
        Dim selectedItem As New ItemClass
        selectedItem.LoadItem(idx)

        lblItemID.Text = selectedItem.ID
        lvItem.Text = selectedItem.ItemClass

        lvItem.Items.Clear()

        For Each spec As ItemSpecs In selectedItem.ItemSpecifications
            Dim IsRenew As String
            IsRenew = spec.isRequired.ToString

            frmAdminPanel.dgSpecification.Rows.Add(spec.ShortCode, spec.SpecName, spec.SpecType, spec.SpecLayout, spec.UnitOfMeasure, IsRenew)

        Next

        frmAdminPanel.LoadItemList(selectedItem)
        frmAdminPanel.Show()
        Me.Hide()
    End Sub

    Private Sub frmItemList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        'loadItemClass()
        txtSearch.Text = ""
    End Sub

End Class