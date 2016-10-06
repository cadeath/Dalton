Public Class frmItemList
    Private ItemClasses_ht As Hashtable
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

    Private Sub ClearFields()
        txtSearch.Text = ""
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

    Private Sub LoadActive_ItemClasses(Optional ByVal mySql As String = "SELECT * FROM TBLITEM WHERE ONHOLD = 0")
        Dim ds As DataSet = LoadSQL(mySql)

        ItemClasses_ht = New Hashtable
        lvItem.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim itmClass As New ItemClass
            itmClass.LoadByRow(dr)
            AddItem(itmClass)

            ItemClasses_ht.Add(itmClass.ID, itmClass)
        Next

    End Sub

    Private Sub AddItem(ByVal itm As ItemClass)
        Dim lv As ListViewItem = lvItem.Items.Add(itm.ID)
        lv.SubItems.Add(itm.ClassName)
        lv.SubItems.Add(itm.Category)
        lv.SubItems.Add(itm.Description)
        lv.SubItems.Add(itm.isRenewable)
        lv.SubItems.Add(itm.PrintLayout)
    End Sub

    Friend Sub SearchSelect(ByVal src As String, ByVal frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub frmItemList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)
        Dim mySql As String = "SELECT * FROM TBLITEM WHERE "
        mySql &= String.Format("(UPPER (ITEMCLASS) LIKE UPPER('%{0}%') OR UPPER (ITEMCATEGORY) LIKE UPPER('%{0}%')) AND ONHOLD = 0 ", secured_str)
        mySql &= "ORDER BY ITEMID ASC"

        LoadActive_ItemClasses(mySql)
        MsgBox(String.Format("{0} item found.", lvItem.Items.Count), MsgBoxStyle.Information)
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
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

    Private Sub lvItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvItem.DoubleClick
        btnSelect.PerformClick()
    End Sub

    Private Sub lvItem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvItem.KeyPress
        Console.WriteLine("ENTER!")
        If isEnter(e) Then
            btnSelect.PerformClick()
        End If
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtSearchItmLst_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

End Class