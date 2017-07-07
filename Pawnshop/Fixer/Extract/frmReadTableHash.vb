Imports System.IO
Imports System.Windows.Forms
Public Class frmReadTableHash
    Private HT As New Hashtable

    Private Sub frmReadTableHash_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub brnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles brnBrowse.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtPath.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub ProcessDirectory(ByVal targetDirectory As String)
        Dim fileEntries As String() = Directory.GetFiles(targetDirectory, "*.FDB")

        Dim fileName As String
        For Each fileName In fileEntries
            ProcessFile(fileName)

        Next fileName
        Dim subdirectoryEntries As String() = Directory.GetDirectories(targetDirectory)
        Dim subdirectory As String
        For Each subdirectory In subdirectoryEntries
            ProcessDirectory(subdirectory)

        Next subdirectory
    End Sub

    Private Sub ProcessFile(ByVal path As String)
        HT.Add(path, path)
        Console.WriteLine("Processed file '{0}'.", path)
    End Sub

    Private Sub txtRead_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRead.Click
        If txtQuery.Text = "" Then Exit Sub
        Disable(1)
        Try
            ProcessDirectory(txtPath.Text)

            ClearListView()
            Dim mysql As String = " " & txtQuery.Text & ""
            database.dbName = HT.Values(0)
            Dim dsHead As DataSet = LoadSQL(mysql)


            Dim PbMaxValue As Integer = 0
            If chkOnly.Checked = True Then

                PbMaxValue = HT.Count

            Else

                For Each hash As DictionaryEntry In HT
                    database.dbName = hash.Value
                    Dim ds As DataSet = LoadSQL(mysql)
                    PbMaxValue += ds.Tables(0).Rows.Count
                Next

            End If
            pbProcess.Maximum = PbMaxValue

            If chkOnly.Checked = True Then
                lvData.Columns.Add("Branch")
                lvData.Columns.Add("Hash Value")

            Else

                For Each dt In dsHead.Tables
                    For Each col As DataColumn In dt.Columns
                        lvData.Columns.Add(col.ToString)
                    Next
                    lvData.Columns.Add("Hash Value")
                Next
            End If

            For Each hash As DictionaryEntry In HT
                database.dbName = hash.Value
                Dim ds As DataSet = LoadSQL(mysql)

                If chkOnly.Checked = True Then

                    Dim lst As ListViewItem = lvData.Items.Add(GetOption("BranchCode"))
                    lst.SubItems.Add(security.GetMD5(FieldsOnly(ds)))
                    pbProcess.Value += 1

                Else

                    For Each dt In ds.Tables
                        For Each row As DataRow In dt.Rows
                            Dim lst As ListViewItem = lvData.Items.Add(row(0))
                            For i As Integer = 1 To dt.Columns.Count - 1
                                Console.WriteLine("ItemRows: " & row(i).ToString)
                                lst.SubItems.Add(row(i).ToString)
                            Next
                            lst.SubItems.Add(security.GetMD5(ds))
                            pbProcess.Value += 1

                        Next
                    Next
                End If

            Next

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        HT.Clear()
        pbProcess.Value = pbProcess.Minimum
        Disable(0)
    End Sub

    'Private Sub ShowDataInLvw(ByVal data As DataTable, ByVal ds As DataSet)
    '    lvNewData.Items.Clear()
    '    For Each col As DataColumn In data.Columns
    '        lvNewData.Columns.Add(col.ToString)
    '    Next

    '    For Each row As DataRow In data.Rows
    '        Dim lst As ListViewItem
    '        lst = lvNewData.Items.Add(row(0))
    '        For i As Integer = 1 To data.Columns.Count - 1
    '            Console.WriteLine("ItemRows: " & row(i).ToString)
    '            lst.SubItems.Add(row(i).ToString)
    '        Next
    '    Next

    '    'txtHash.Text = security.GetMD5(ds)
    ' End Sub

    Private Sub btnMatch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMatch.Click
        For Each itm As ListViewItem In lvData.Items
            If itm.SubItems(getCindex("Hash Value")).Text.Contains(txtMatch.Text) Then
                itm.Selected = True
                itm.Focused = True
                itm.BackColor = Color.Lime
            Else
                itm.BackColor = Color.Red
            End If
        Next
    End Sub

    Private Function getCindex(ByVal cName As String) As Integer

        For x As Integer = 0 To lvData.Columns.Count - 1
            If lvData.Columns(x).Text = cName Then
                Return x
            End If
        Next

        Return -1
    End Function

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

    Private Sub lvData_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvData.DoubleClick
        If lvData.SelectedItems.Count <= 0 Then Exit Sub

        For Each itm As ListViewItem In lvData.SelectedItems
            txtHash.Text = itm.SubItems(getCindex("Hash Value")).Text
        Next

    End Sub

    Private Sub ClearListView()
        lvData.Columns.Clear()
        lvData.Items.Clear()
    End Sub

    Private Function FieldsOnly(ByVal ds As DataSet) As DataSet
        For i As Int32 = 1 To ds.Tables(0).Rows.Count
            ds.Tables(0).Rows.RemoveAt(0)
        Next
        Return ds
    End Function

    Private Sub Disable(ByVal st As Boolean)
        txtQuery.Enabled = Not st
        btnRead.Enabled = Not st
    End Sub
End Class