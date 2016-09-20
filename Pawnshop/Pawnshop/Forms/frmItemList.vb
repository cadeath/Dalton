Public Class frmItemList
    Dim mOtherForm As Boolean = False

    Dim frmOrig As formSwitch.FormName

    Dim selectedItem As ItemClass
    'Dim ds As New DataSet

    'Friend GetItem As ItemClass


    'Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
    '    mOtherForm = True
    '    btnSelect.Visible = True
    '    txtSearch.Text = src
    '    frmOrig = frmOrigin
    'End Sub

    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        If Not mOtherForm Then ClearField()


        loadItemClass()

        If Not mOtherForm Then
            txtSearch.Focus()
        End If

        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub


    'Friend Sub LoadActiveItem(Optional ByVal mySql As String = "SELECT * FROM TBLITEM where ITEMID <> 0 ORDER BY ITEMID ASC")
    '    Dim ds As DataSet
    '    ds = LoadSQL(mySql)
    '    lvItem.Items.Clear()

    '    For Each dr As DataRow In ds.Tables(0).Rows
    '        Dim tmpItem As New ItemClass
    '        '  tmpItem.LoadItem(ID)
    '        AddItem(tmpItem)
    '    Next
    'End Sub
    Private Sub loadItemClass()
        Dim mySql As String = "SELECT * FROM tblItem"
        Dim ds As DataSet = LoadSQL(mySql)

        lvItem.Items.Clear()
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
        For Each dr As DataRow In ds.Tables(0).Rows

            Dim lv As ListViewItem = lvItem.Items.Add(dr("ItemID"))
            lv.SubItems.Add(dr("ItemClass"))
            lv.SubItems.Add(dr("ItemCategory"))
            lv.SubItems.Add(dr("Description"))
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
        

        'Dim idx As Integer = CInt(lvItem.FocusedItem.Text)

        'Dim selectedItem As New ItemClass
        'selectedItem.LoadItem(idx)

        'lblItemID.Text = selectedItem.ID

        'lvItem.Items.Clear()
        'For Each spec As ItemSpecs In selectedItem.ItemSpecifications
        '    lvItem.Items.Add(spec.SpecName)
        'Next
    End Sub


    Private Sub lvItem_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
        If Not mOtherForm Then
            btnView.PerformClick()
        Else
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim idx As Integer = CInt(lvItem.FocusedItem.Text)

        selectedItem = New ItemClass
        selectedItem.LoadItem(idx)

        lblItemID.Text = selectedItem.ID

        frmAdminPanel.dgSpecification.Rows.Clear()

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
        loadItemClass()
        txtSearch.Text = ""
    End Sub
End Class