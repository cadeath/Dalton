﻿Imports System.IO
Imports Microsoft.Office.Interop

Public Class frmSampleExtract
    Private HashPath As New Hashtable
    Private path As String

    Private Sub btnBrowseData_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseData.Click
        If Not fbdBackup.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        txtPath.Text = fbdBackup.SelectedPath
    End Sub

    Public Sub ProcessDirectory(ByVal targetDirectory As String)
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

    Public Sub ProcessFile(ByVal path As String)
        HashPath.Add(path, path)
        Console.WriteLine("Processed file '{0}'.", path)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtExtract.Click
        ProcessDirectory(txtPath.Text)
        LoadQuery()
    End Sub

    Private Sub LoadQuery()
        Try
            Dim mysql As String = "" & txtQuery.Text & ""

            sfdPath.FileName = String.Format("{0}.xlsx", "Sample")
            path = txtSavePath.Text & "\" & sfdPath.FileName
            ExtractToExcell(mysql, path, HashPath)

        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
        End Try

        Dim ans As DialogResult = MsgBox("Successfully Data Converted", MsgBoxStyle.Information + MsgBoxStyle.OkOnly + MsgBoxStyle.DefaultButton2)
        If ans = Windows.Forms.DialogResult.OK Then
            pbProgress.Value = pbProgress.Minimum
        End If
    End Sub

    Friend Sub ExtractToExcell(ByVal mySql As String, ByVal dest As String, ByVal ht As Hashtable)
        Try
            If dest = "" Then Exit Sub

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
                oSheet.Name = "Consolidate"

            For Each hash As DictionaryEntry In ht
                database.dbName = hash.Value
                Dim rowCnt As Integer
                Dim ds As DataSet = LoadSQL(mySql)
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
                ds = LoadSQL(mySql)

                ' ADD BRANCHCODE
                InsertArrayElement(tmpCount, 0, "BRANCHCODE")

                ' HEADERS
                Dim cnt As Integer = 0
                For Each hr In tmpCount
                    cnt += 1 : oSheet.Cells(1, cnt).value = hr
                Next


                ' EXTRACTING
                Console.Write("Extracting")
                rowCnt += 2
                For Each dr As DataRow In ds.Tables(0).Rows
                    For colCnt As Integer = 0 To tmpCount.Count - 1
                        If colCnt = 0 Then
                            oSheet.Cells(rowCnt, colCnt + 1).value = GetOption("BranchCode")
                        Else
                            oSheet.Cells(rowCnt, colCnt + 1).value = dr(colCnt - 1) 'dr(colCnt - 1) move the column by -1
                        End If
                    Next
                    'pbProgress.Value = pbProgress.Value + 1
                    rowCnt += 1

                    Console.Write(".")
                    Application.DoEvents()
                Next
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

    Private Sub frmSampleExtract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
        txtSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub
End Class