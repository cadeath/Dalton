Public Class frmReadTableHash

    Private Sub frmReadTableHash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub brnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnBrowse.Click
        ofd.ShowDialog()
        txtPath.Text = ofd.FileName
    End Sub

    Private Sub txtRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        database.dbName = txtPath.Text
        'lbTableName.Items.Clear()
        If txtQuery.Text = "" Then Exit Sub

        Try

            Dim mysql As String = " " & txtQuery.Text & ""
            Dim ds As DataSet = LoadSQL(mysql)

            For Each dt In ds.Tables
                ShowDataInLvw(dt, ds)
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
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

    Private Sub btnMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatch.Click
        If txtHash.Text = txtMatch.Text Then
            MsgBox("Value match", MsgBoxStyle.Information, "Hash Matching . . .")
        Else
            MsgBox("Value not match", MsgBoxStyle.Critical, "Hash Matching . . .")
        End If
    End Sub

    Private Sub txtMatch_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMatch.KeyPress
        If isEnter(e) Then
            btnMatch.PerformClick()
        End If
    End Sub

    Private Sub txtQuery_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtQuery.KeyDown
        If e.KeyCode = Keys.Enter AndAlso e.Control Then
            btnRead.PerformClick()
        End If
    End Sub
End Class