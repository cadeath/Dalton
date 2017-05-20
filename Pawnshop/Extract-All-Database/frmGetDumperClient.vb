Imports Microsoft.Office.Interop
Public Class frmGetDumperClient

    Dim FBD As FolderBrowserDialog
    Dim sfd As New SaveFileDialog
    Dim Counter As Integer = 0
    Dim brnch As String = ""
    Dim mysql As String = String.Empty

    Dim dbBranch As String = ""
    Dim tmpFullname As String = ""
    Dim headers As String()

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
        sfd.ShowDialog()

        Dim i As Integer = 0
        For Each tmplete As ListViewItem In lvTemplateList.Items
            i += 1
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

            brnch = oSheet.Cells(2, 1).value

            For Each dblist As ListViewItem In lvDatabaselist.Items
                database.dbName = dblist.SubItems(0).Text
                dbBranch = GetOption("BranchCode") : Console.WriteLine("dbBranch:" & dbBranch)

                For cnt = 2 To MaxEntries
                    brnch = oSheet.Cells(cnt, 1).value

                    tmpFullname = String.Format("{0}{1}", oSheet.Cells(cnt, 2).value, oSheet.Cells(cnt, 4).value)

                    If oSheet.Cells(cnt, 3).value <> "" Then
                        tmpFullname = String.Format("{0}{1} {2}", oSheet.Cells(cnt, 2).value, oSheet.Cells(cnt, 3).value, oSheet.Cells(cnt, 4).value)
                    End If

                    If oSheet.Cells(cnt, 5).value <> "" Then
                        tmpFullname = oSheet.Cells(cnt, 2).value & "" & oSheet.Cells(cnt, 3).value & "" & oSheet.Cells(cnt, 4).value _
                            & "" & oSheet.Cells(cnt, 5).value
                    End If
                    
                    mysql = "	SELECT C.CLIENTID, C.FIRSTNAME || ' ' || C.MIDDLENAME || ' ' || C.LASTNAME || ' ' || 	"
                    mysql &= "	CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END AS CLIENT, C.PHONE1 AS CONTACTNUMBER, 	"
                    mysql &= "	C.BIRTHDAY FROM TBLCLIENT C	"
                    mysql &= "	WHERE ( C.FIRSTNAME || ' ' || C.MIDDLENAME || ' ' || C.LASTNAME || ' ' || 	"
                    mysql &= " 	CASE WHEN C.SUFFIX is Null THEN '' ELSE C.SUFFIX END) = '" & tmpFullname & "'"
                    mysql &= "  AND BIRTHDAY ='" & oSheet.Cells(cnt, 7).VALUE & "'"

                    Console.WriteLine(oSheet.Cells(cnt, 8).value)
                    If oSheet.Cells(cnt, 8).value <> "" Then
                        mysql &= "AND SEX ='" & oSheet.Cells(cnt, 8).VALUE & "' "
                    End If

                    If oSheet.Cells(cnt, 9).VALUE.ToString <> "" Then
                        mysql &= "AND C.PHONE1 = '" & oSheet.Cells(cnt, 9).value & "' "
                    End If

                    Dim ds As DataSet = LoadSQL(mysql, "TBLCLIENT")

                    Dim tmpTextbox As New TextBox
                    Dim idx As Integer = 0
                    For Each c As DataColumn In ds.Tables(0).Columns
                        idx += 1
                        tmpTextbox.AppendText(c.ColumnName & " ")
                    Next
                    Dim mid As String = tmpTextbox.Text.Trim
                    headers = mid.Split(CChar(" "))

                    ' ExtractToExcel(headers, mysql, sfd.FileName, countx)
                Next
            Next
unloadObj:
            'Memory Unload
            oSheet = Nothing
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            Console.WriteLine(i & ", " & brnch)
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