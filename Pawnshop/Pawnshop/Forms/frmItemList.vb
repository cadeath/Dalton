Public Class frmItemList
    Private ItemClasses_ht As Hashtable
 Dim ds As New DataSet
    Dim selectedItem As ItemClass


    'FORMS
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName

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
    


    Private Sub AddItem(ByVal dl As ItemClass)
        Dim lv As ListViewItem = lvItem.Items.Add(dl.ID)
        lv.SubItems.Add(dl.ClassName)
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
        'txtSearch.Text = ""
        lvItem.Items.Clear()
    End Sub


    Private Sub searchItem()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM tblITEM WHERE "
        mySql &= String.Format("UPPER (ITEMCLASS) LIKE UPPER('%{0}%')", secured_str)

        Console.WriteLine("SQL: " & mySql)

    End Sub
    Private Sub ClearFields()
        txtSearch.Text = ""
        lvItem.Items.Clear()
    End Sub

    '    Private Sub LoadActive_ItemClasses(Optional mySql As String = "SELECT * FROM TBLITEM WHERE ONHOLD = 0")
    'MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Item")
    '        For Each dr As DataRow In ds.Tables(0).Rows	
    '        Dim ds As DataSet = LoadSQL(mySql)


    ' 	Dim lv As ListViewItem = lvItem.Items.Add(dr("ItemID"))
    '            lv.SubItems.Add(dr("ItemClass"))
    '            lv.SubItems.Add(dr("ItemCategory"))
    '            lv.SubItems.Add(dr("Description"))
    '        ItemClasses_ht = New Hashtable
    '        lvItem.Items.Clear()
    '        For Each dr As DataRow In ds.Tables(0).Rows
    '            Dim itmClass As New ItemClass
    '            itmClass.LoadByRow(dr)
    '            AddItem(itmClass)

    '	dim lv as listViewItem = lvItem.items.add(dr("ItemID"))
    '		lv.subItems.Add(dr("ItemClass"))
    '		lv.subItems.add(dr("ItemCategory"))
    '		lv.SubItems.Add(dr("Description"))
    '            lv.SubItems.Add(dr("IsRenew"))
    '            lv.SubItems.Add(dr("Print_Layout"))
    '            ItemClasses_ht.Add(itmClass.ID, itmClass)
    '        Next
    '	end sub

    Private Sub lvItem_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        'If e.KeyCode = Keys.Enter Then
        '    If Not mOtherForm Then
        '        btnView.PerformClick()
        '    Else
        '        btnSelect.PerformClick()
        '    End If
        'End If
    End Sub

    'Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
    '    mOtherForm = True
    '    btnSelect.Visible = True
    '    txtSearch.Text = src
    '    frmOrig = frmOrigin
    'End Sub


    Private Sub frmItemList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs)
        'loadItemClass()
        txtSearch.Text = ""
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    'Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    '    If Not mOtherForm Then ClearField()
    '    If mOtherForm Then
    '        btnView.Visible = False
    '    Else
    '        ClearField()
    '        btnSelect.Visible = False
    '    End If

    '    'loadItemClass()
    '    LoadActiveItem()

    '    If Not mOtherForm Then
    '        txtSearch.Focus()
    '    End If

    '    txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
    '    If txtSearch.Text <> "" Then
    '        btnSearch.PerformClick()
    '    End If
    'End Sub

    'Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    '    searchItem()
    'End Sub

    'Private Sub btnView_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
    '    Dim idx As Integer = CInt(lvItem.FocusedItem.Text)

    '    selectedItem = New ItemClass
    '    selectedItem.LoadItem(idx)

    '    'lblItemID.Text = selectedItem.ID

    '    frmAdminPanel.dgSpecs.Rows.Clear()

    '    frmAdminPanel.LoadSpec(idx)
    '    frmAdminPanel.LoadItemList(selectedItem)
    '    frmAdminPanel.Show()
    '    Me.Close()
    'End Sub

    Friend Sub SearchSelect(src As String, frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub


    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim mySql As String = "SELECT * FROM TBLITEM WHERE "
        mySql &= String.Format("(UPPER (ITEMCLASS) LIKE UPPER('%{0}%') OR UPPER (ITEMCATEGORY) LIKE UPPER('%{0}%')) AND ONHOLD = 0 ", txtSearch.Text)
        mySql &= "ORDER BY ITEMID ASC"

        ' LoadActive_ItemClasses(mySql)
        MsgBox(String.Format("{0} item found.", lvItem.Items.Count), MsgBoxStyle.Information)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


    'Private Sub lvItem_KeyDown_1(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvItem.KeyDown
    '    If Not mOtherForm Then
    '        btnView.PerformClick()
    '    Else
    '        btnSelect.PerformClick()
    '    End If
    'End Sub

    Private Sub btnSelect_Click(sender As System.Object, e As System.EventArgs) Handles btnSelect.Click
        If lvItem.Items.Count = 0 Then Exit Sub

        If lvItem.SelectedItems.Count = 0 Then
            lvItem.Items(0).Focused = True
        End If

        Dim idx As Integer
        idx = CInt(lvItem.FocusedItem.Text)

        Dim Selected_ItemClass As New ItemClass
        For Each dt As DictionaryEntry In ItemClasses_ht
            If dt.Key = idx Then

                Selected_ItemClass = dt.Value
                formSwitch.ReloadFormFromItemList(frmOrig, Selected_ItemClass)
                Me.Close()
                Exit Sub
            End If
        Next

        MsgBox("Error loading hash table", MsgBoxStyle.Critical, "CRITICAL")
    End Sub

    Private Sub lvItem_DoubleClick(sender As Object, e As System.EventArgs) Handles lvItem.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvItem_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles lvItem.KeyPress
        Console.WriteLine("ENTER!")
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As System.Object, e As System.EventArgs) Handles txtSearch.TextChanged

    End Sub

End Class