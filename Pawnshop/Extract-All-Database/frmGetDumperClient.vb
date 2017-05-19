Imports Microsoft.Office.Interop
Public Class frmGetDumperClient

    Dim FBD As FolderBrowserDialog
    Dim Counter As Integer = 0
    Dim brnch As String = ""



    Private Sub btnBrowseTemplate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseTemplate.Click
        FBD = New FolderBrowserDialog
        FBD.ShowDialog()
        txtTemplatePath.Text = FBD.SelectedPath

        dir2.ProcessDirectory(txtTemplatePath.Text)
        Counter = lvTemplateList.Items.Count
        txtTemplatecount.Text = "|Template: " & Counter
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        FBD = New FolderBrowserDialog
        FBD.ShowDialog()
        txtDBpath.Text = FBD.SelectedPath

        dir1.ProcessDirectory(txtDBpath.Text)

        Counter = lvDatabaselist.Items.Count
        txtCount.Text = "Database: " & Counter
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If txtDBpath.Text = "" Or txtTemplatePath.Text = "" Or lvDatabaselist.Items.Count = 0 Then Exit Sub

        For Each tmplete As ListViewItem In lvTemplateList.Items

            Dim oXL As New Excel.Application
            Dim oWB As Excel.Workbook
            Dim oSheet As Excel.Worksheet
            Dim str As String = tmplete.SubItems(0).Text
            
            oWB = oXL.Workbooks.Open(str)
            oSheet = oWB.Worksheets(1)

            Dim MaxColumn As Integer = oSheet.Cells(1, oSheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
            Dim MaxEntries As Integer = oSheet.Cells(oSheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

            Dim checkHeaders(MaxColumn) As String
            For cnt As Integer = 0 To MaxColumn - 1
                checkHeaders(cnt) = oSheet.Cells(1, cnt + 1).value
            Next : checkHeaders(MaxColumn) = oWB.Worksheets(1).name

            Me.Enabled = False
            For cnt = 2 To MaxEntries
                brnch = oSheet.Cells(cnt, 1).value


            Next
            Me.Enabled = True

unloadObj:
            'Memory Unload
            oSheet = Nothing
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

        Next

        MsgBox("Item Loaded", MsgBoxStyle.Information)
    End Sub

    Private Function CheckBranch(ByVal branch As String) As Boolean
        If brnch = branch Then Return False
        Return False
    End Function

    Private Sub getBranch()
        'database.dbName = lv.SubItems(0).Text
        '    Dim ds As DataSet
    End Sub
End Class