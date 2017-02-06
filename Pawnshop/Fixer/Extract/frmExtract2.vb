Imports Microsoft.Office.Interop
Imports System.IO

Public Class frmExtract2
    Private path As String

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If txtPath.Text = "" Then Exit Sub
        Disable(1)
        Dim text As String = ""
        Dim files() As String = IO.Directory.GetFiles(txtPath.Text, "*.FDB")

        For Each sFile As String In files
            database.dbName = sFile
            Dim ds As DataSet = LoadSQL(txtQuery.Text)

            pbProgress.Maximum = ds.Tables(0).Rows.Count
            LoadQuery()
            pbProgress.Value = pbProgress.Minimum
        Next

        Dim ans As DialogResult = MsgBox("Successfully Data Converted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2)
        If ans = Windows.Forms.DialogResult.OK Then
            pbProgress.Value = pbProgress.Minimum
        End If

        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnExtract.Enabled = Not st
    End Sub

    Private Sub frmExtract2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
        txtSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub btnBrowseData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseData.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtPath.Text = fbdBackup.SelectedPath
    End Sub

    Private Sub btnBrowseSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseSave.Click
        'If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        'txtSavePath.Text = fbdBackup.SelectedPath
    End Sub

    Friend Sub ExtractToExcell(ByVal headers As String(), ByVal mySql As String, ByVal dest As String)
        Try
            If dest = "" Then Exit Sub

            Dim ds As DataSet = LoadSQL(mySql)

            'Load Excel
            Dim oXL As New Excel.Application
            If oXL Is Nothing Then
                MessageBox.Show("Excel is not properly installed!!")
                Return
            End If

            Dim oWB As Excel.Workbook
            Dim oSheet As Excel.Worksheet

            oXL = CreateObject("Excel.Application")
            oXL.Visible = False

            oWB = oXL.Workbooks.Add
            oSheet = oWB.ActiveSheet
            oSheet.Name = GetOption("BranchCode") & "_DAILY"

            ' ADD BRANCHCODE
            InsertArrayElement(headers, 0, "BRANCHCODE")

            ' HEADERS
            Dim cnt As Integer = 0
            For Each hr In headers
                cnt += 1 : oSheet.Cells(1, cnt).value = hr
            Next

            ' EXTRACTING
            Console.Write("Extracting")
            Dim rowCnt As Integer = 2
            For Each dr As DataRow In ds.Tables(0).Rows
                For colCnt As Integer = 0 To headers.Count - 1
                    If colCnt = 0 Then
                        oSheet.Cells(rowCnt, colCnt + 1).value = GetOption("BranchCode")
                    Else
                        oSheet.Cells(rowCnt, colCnt + 1).value = dr(colCnt - 1) 'dr(colCnt - 1) move the column by -1
                    End If
                Next
                pbProgress.Value = pbProgress.Value + 1
                rowCnt += 1

                Console.Write(".")
                Application.DoEvents()
            Next

            oWB.SaveAs(dest)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            Console.WriteLine("Data Extracted")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub InsertArrayElement(Of T)( _
         ByRef sourceArray() As T, _
         ByVal insertIndex As Integer, _
         ByVal newValue As T)

        Dim newPosition As Integer
        Dim counter As Integer

        newPosition = insertIndex
        If (newPosition < 0) Then newPosition = 0
        If (newPosition > sourceArray.Length) Then _
           newPosition = sourceArray.Length

        Array.Resize(sourceArray, sourceArray.Length + 1)

        For counter = sourceArray.Length - 2 To newPosition Step -1
            sourceArray(counter + 1) = sourceArray(counter)
        Next counter

        sourceArray(newPosition) = newValue
    End Sub

    Private Sub LoadQuery(Optional ByVal Series As Integer = 0)
        Try
            Dim mysql As String = "" & txtQuery.Text & ""
            Dim ds As DataSet = LoadSQL(mysql)
            Dim tmpTableName As New TextBox, tmp As String

            If lbTableName.Items.Count < 1 Then

                For Each dt In ds.Tables
                    For Each column In dt.Columns
                        tmpTableName.AppendText(column.ColumnName & " ")
                    Next
                Next
            Else

                For Each obj In lbTableName.Items
                    tmpTableName.AppendText(obj.ToString & " ")
                Next

            End If
            tmp = tmpTableName.Text.TrimEnd

            Dim tmpCount() As String = tmp.Split(CChar(" "))
            Dim tmpString() As String = {tmp}
            sfdPath.FileName = String.Format("{0}.xlsx", GetOption("BranchCode", Series))
            path = txtSavePath.Text & "\" & sfdPath.FileName
            ExtractToExcell(tmpCount, mysql, path)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            lbTableName.Items(lbTableName.SelectedIndex) = txtHeader.Text
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            database.dbName = txtPath.Text
            lbTableName.Items.Clear()
            If txtQuery.Text = "" Then Exit Sub
            Dim mysql As String = " " & txtQuery.Text & ""
            Dim ds As DataSet = LoadSQL(mysql)

            For Each dt In ds.Tables
                For Each column In dt.Columns
                    lbTableName.Items.Add(column.ColumnName)
                Next
            Next
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try
    End Sub
End Class