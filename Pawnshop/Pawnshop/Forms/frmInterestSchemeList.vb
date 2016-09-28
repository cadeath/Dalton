Public Class frmInterestSchemeList
    Dim filldata As String = "TBLINTSCHEMES"

    Dim tmpScheme As InterestScheme
    Dim selectedSchemeDetails As Scheme_Interest

    Private Sub frmInterestSchemeList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadScheme()


        txtSearch.Text = IIf(txtSearch.Text <> "", txtSearch.Text, "")
        If txtSearch.Text <> "" Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub LoadScheme()
        Dim mySql As String = "SELECT * FROM " & filldata
        Dim ds As DataSet = LoadSQL(mySql)

        lvSchemeList.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows

            Dim lv As ListViewItem = lvSchemeList.Items.Add(dr("SCHEMEID"))
            lv.SubItems.Add(dr("SCHEMENAME"))
            lv.SubItems.Add(dr("DESCRIPTION"))
        Next
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        If lvSchemeList.SelectedItems.Count <= 0 Then Exit Sub

        Dim Schemeid As Integer
        Schemeid = lvSchemeList.FocusedItem.Text
        Console.WriteLine("SchemeID: " & Schemeid)

        tmpScheme = New InterestScheme
        tmpScheme.LoadScheme(Schemeid)

        lblSchemeID.Text = tmpScheme.SchemeID

        frmInterestScheme.lvIntScheme.Items.Clear()

        For Each SchemeDetail As Scheme_Interest In tmpScheme.SchemeDetails
            With SchemeDetail

                Dim row As ListViewItem

                row = New ListViewItem(.DayFrom)
                row.SubItems.Add(.DayTo)
                row.SubItems.Add(.Interest)
                row.SubItems.Add(.Penalty)
                row.SubItems.Add(.Remarks)

                frmInterestScheme.lvIntScheme.Items.Add(row)

            End With
        Next

        frmInterestScheme.LoadSchemeList(tmpScheme)
        frmInterestScheme.Show()
        Me.Hide()

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        searchItem()
    End Sub

    Private Sub searchItem()
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        Dim mySql As String = "SELECT * FROM " & filldata & " WHERE "
        mySql &= String.Format("UPPER (SchemeName) LIKE UPPER('%{0}%')", secured_str)

        Console.WriteLine("SQL: " & mySql)
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxRow As Integer = ds.Tables(0).Rows.Count

        lvSchemeList.Items.Clear()

        If MaxRow <= 0 Then
            Console.WriteLine("No Item List Found")
            MsgBox("Query not found", MsgBoxStyle.Information)
            txtSearch.SelectAll()
            lvSchemeList.Items.Clear()
            Exit Sub
        End If

        MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Item")
        For Each dr As DataRow In ds.Tables(0).Rows

            Dim lv As ListViewItem = lvSchemeList.Items.Add(dr("SchemeID"))
            lv.SubItems.Add(dr("SchemeName"))
            lv.SubItems.Add(dr("Description"))
        Next
    End Sub

    Private Sub lvSchemeList_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSchemeList.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub frmInterestSchemeList_FormClosed(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles MyBase.FormClosed
        LoadScheme()
        txtSearch.Text = ""
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvSchemeList_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvSchemeList.KeyDown
        If e.KeyCode = Keys.Enter Then
            btnView.PerformClick()
        End If
    End Sub
End Class