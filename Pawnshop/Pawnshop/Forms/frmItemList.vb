Public Class frmItemList
    Dim mOtherForm As Boolean = False
    Dim frmOrig As formSwitch.FormName
    Dim ds As New DataSet

    Dim selectedItem As ItemClass

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
        ClearField()

        If mOtherForm Then
            btnView.Visible = False
        Else
            btnSearch.Visible = True
        End If

        LoadActiveItem()

        If Not mOtherForm Then
            txtSearchItmLst.Focus()
        End If

        txtSearchItmLst.Text = IIf(txtSearchItmLst.Text <> "", txtSearchItmLst.Text, "")
        If txtSearchItmLst.Text <> "" Then
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


    Private Sub ClearField()
        txtSearchItmLst.Text = ""
        lvItem.Items.Clear()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not mOtherForm Then
            btnSelect.Visible = False
        End If
        ' LoadActiveItem()
        frmItemList_Load(sender, e)
        searchItem()
    End Sub
    Private Sub searchItem()
        If txtSearchItmLst.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearchItmLst.Text
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
            txtSearchItmLst.SelectAll()
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


    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        mOtherForm = True
        btnSelect.Visible = True
        txtSearchItmLst.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click

        If lvItem.Items.Count = 0 Then Exit Sub
        Dim idx As Integer = CInt(lvItem.FocusedItem.Text)

        Dim selectedItem As New ItemClass
        selectedItem.LoadItem(idx)

        'lvItem.Items.Clear()
        'For Each spec As ItemSpecs In selectedItem.ItemSpecifications
        '    lvItem.Items.Add(spec.SpecName)
        'Next

        formSwitch.ReloadFormFromSearch2(frmOrig, selectedItem)
        Me.Close()

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

        frmAdminPanel.dgSpecs.Rows.Clear()

        frmAdminPanel.LoadSpec(idx)
        frmAdminPanel.LoadItemList(selectedItem)
        frmAdminPanel.Show()
        Me.Hide()

    End Sub

    Private Sub frmItemList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        LoadActiveItem()
        txtSearchItmLst.Text = ""
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub


   
    Private Sub txtSearchItmLst_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearchItmLst.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub
End Class