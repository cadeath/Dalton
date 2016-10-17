Public Class frmItemList
    Private ItemClasses_ht As Hashtable

    'FORMS
    Private fromOtherForm As Boolean = False
    Private frmOrig As formSwitch.FormName

    Private Sub ClearFields()
        txtSearch.Text = ""
        lvItem.Items.Clear()
    End Sub

    Private Sub LoadActive_ItemClasses(Optional mySql As String = "SELECT * FROM TBLITEM WHERE ONHOLD = 0")
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

    Private Sub AddItem(itm As ItemClass)
        Dim lv As ListViewItem = lvItem.Items.Add(itm.ID)
        lv.SubItems.Add(itm.ClassName)
        lv.SubItems.Add(itm.Category)
        lv.SubItems.Add(itm.Description)
        lv.SubItems.Add(itm.isRenewable)
        lv.SubItems.Add(itm.PrintLayout)
    End Sub

    Friend Sub SearchSelect(src As String, frmOrigin As formSwitch.FormName)
        fromOtherForm = True
        txtSearch.Text = src
        frmOrig = frmOrigin
    End Sub

    Private Sub frmItemList_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        If txtSearch.Text = "" Then Exit Sub

        btnSearch.PerformClick()
    End Sub

    Private Sub btnSearch_Click(sender As System.Object, e As System.EventArgs) Handles btnSearch.Click
        Dim mySql As String = "SELECT * FROM TBLITEM WHERE "
        mySql &= String.Format("(UPPER (ITEMCLASS) LIKE UPPER('%{0}%') OR UPPER (ITEMCATEGORY) LIKE UPPER('%{0}%')) AND ONHOLD = 0 ", txtSearch.Text)
        mySql &= "ORDER BY ITEMID ASC"

        LoadActive_ItemClasses(mySql)
        MsgBox(String.Format("{0} item found.", lvItem.Items.Count), MsgBoxStyle.Information)
    End Sub

    Private Sub btnClose_Click(sender As System.Object, e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

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
End Class