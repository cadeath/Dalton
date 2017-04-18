Public Class frmReadTableHash

    Private Sub frmReadTableHash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub brnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnBrowse.Click
        ofd.ShowDialog()
        txtPath.Text = ofd.FileName
    End Sub

    Private Sub txtRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRead.Click
        database.dbName = txtPath.Text
        'lbTableName.Items.Clear()
        If txtQuery.Text = "" Then Exit Sub
        Dim mysql As String = " " & txtQuery.Text & ""
        Dim ds As DataSet = LoadSQL(mysql)

        For Each dt In ds.Tables

            'For Each column As DataColumn In dt.Columns
            '    Dim NewCH As New ColumnHeader

            '    NewCH.Text = column.ColumnName
            '    lvData.Columns.Add(NewCH)

            'Next
            ''Dim lv As ListViewItem = lvData.Items.Add()
            'For Each row As DataRow In dt.rows
            '    For i As Integer = 0 To dt.row.count - 1
            '        Console.WriteLine("rows " & row.Item(i))
            '    Next

            'Next
            ShowDataInLvw(dt, ds)
        Next

    End Sub

    Public Sub ShowDataInLvw(ByVal data As DataTable, ByVal ds As DataSet)
        lvData.Items.Clear()
        For Each col As DataColumn In data.Columns
            lvData.Columns.Add(col.ToString)
        Next

        For Each row As DataRow In data.Rows
            Dim lst As ListViewItem
            lst = lvData.Items.Add(row(0))
            For i As Integer = 1 To data.Columns.Count - 1
                Console.WriteLine("ItemRows: " & row(i).ToString)
                lst.SubItems.Add(row(i).ToString)
            Next
        Next

        txtHash.Text = security.GetMD5(ds)
    End Sub

End Class