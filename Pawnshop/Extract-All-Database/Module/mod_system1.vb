' Changelog
' v2 7/28/16
'  - Added ExtractToExcel
' v1.4 2/17/16
'  - Log Module
' v1.3 11/19/15
'  - CommandPrompt Added
' v1.2 11/6/15
'  - Added ESK File
' v1.1 10/20/15
'  - Added decimal . in DigitOnly
'  - Added isMoney

Imports Microsoft.Office.Interop
Module mod_system1


    'Dim BranchCode As String = GetOption("BranchCode")
    'Public branchName As String = GetOption("BranchName")
    'Public AREACODE As String = GetOption("BranchArea")
    'Public REVOLVING_FUND As String = GetOption("RevolvingFund")

    Friend Sub ClientExtractToExcel(ByVal headers As String(), ByVal mySql As String, ByVal dest As String, ByVal i As Integer)
        If dest = "" Then Exit Sub

        Dim BRANCHCODE As String = GetOption("BranchCode")

        If i = 1 Then

            Dim ds As DataSet = LoadSQL(mySql)
            frmDatabseExtractor.ProgressBar1.Value = 0
            frmDatabseExtractor.ProgressBar1.Maximum = ds.Tables(0).Rows.Count
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
            oSheet.Name = "Extract"

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
                        oSheet.Cells(rowCnt, colCnt + 1).value = BRANCHCODE
                    Else
                        oSheet.Cells(rowCnt, colCnt + 1).value = dr(colCnt - 1) 'dr(colCnt - 1) move the column by -1
                    End If
                Next
                rowCnt += 1

                Console.Write(".")
                frmDatabseExtractor.ProgressBar1.Value = frmDatabseExtractor.ProgressBar1.Value + 1
                Application.DoEvents()
                frmDatabseExtractor.lblStatus.Text = String.Format("{0}%", ((frmDatabseExtractor.ProgressBar1.Value / frmDatabseExtractor.ProgressBar1.Maximum) * 100).ToString("F2"))
            Next

            frmDatabseExtractor.ProgressBar1.Minimum = 0 : frmDatabseExtractor.ProgressBar1.Value = 0 : frmDatabseExtractor.lblStatus.Text = "0.00%"
            oWB.SaveAs(dest)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            Console.WriteLine("Data Extracted")
        Else

            Dim ds As DataSet = LoadSQL(mySql)
            frmDatabseExtractor.ProgressBar1.Value = 0
            frmDatabseExtractor.ProgressBar1.Maximum = ds.Tables(0).Rows.Count

            Dim xls As New Excel.Application
            Dim book As Excel.Workbook
            Dim sheet As Excel.Worksheet

            xls.Workbooks.Open(dest)

            book = xls.ActiveWorkbook
            sheet = book.ActiveSheet

            Dim MaxColumn As Integer = sheet.Cells(1, sheet.Columns.Count).End(Excel.XlDirection.xlToLeft).column
            Dim MaxEntries As Integer = sheet.Cells(sheet.Rows.Count, 1).End(Excel.XlDirection.xlUp).row

            Dim checkHeaders(MaxColumn) As String
            For cnt As Integer = 0 To MaxColumn - 1
                checkHeaders(cnt) = sheet.Cells(1, cnt + 1).value
            Next : checkHeaders(MaxColumn) = book.Worksheets(1).name

            InsertArrayElement(headers, 0, "BRANCHCODE")

            ' EXTRACTING
            Console.Write("Extracting")
            Dim rowCnt As Integer = MaxEntries
            For Each dr As DataRow In ds.Tables(0).Rows
                For colCnt As Integer = 0 To headers.Count - 1
                    If colCnt = 0 Then
                        sheet.Cells(rowCnt, colCnt + 1).value = BRANCHCODE
                    Else
                        sheet.Cells(rowCnt, colCnt + 1).value = dr(colCnt - 1) 'dr(colCnt - 1) move the column by -1
                    End If
                Next
                rowCnt += 1

                Console.Write(".")
                frmDatabseExtractor.ProgressBar1.Value = frmDatabseExtractor.ProgressBar1.Value + 1
                Application.DoEvents()
                frmDatabseExtractor.lblStatus.Text = String.Format("{0}%", ((frmDatabseExtractor.ProgressBar1.Value / frmDatabseExtractor.ProgressBar1.Maximum) * 100).ToString("F2"))
            Next

            frmDatabseExtractor.ProgressBar1.Minimum = 0 : frmDatabseExtractor.ProgressBar1.Value = 0 : frmDatabseExtractor.lblStatus.Text = "0.00%"
            book.Save()
            xls.Workbooks.Close()
            xls.Quit()
            releaseObject(sheet)
            releaseObject(book)
            releaseObject(xls)

        End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
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

    ' HASHTABLE FUNCTIONS
    Public Function GetIDbyName(ByVal name As String, ByVal ht As Hashtable) As Integer
        For Each dt As DictionaryEntry In ht
            If dt.Value = name Then
                Return dt.Key
            End If
        Next

        Return 0
    End Function

    Public Function GetNameByID(ByVal id As Integer, ByVal ht As Hashtable) As String
        For Each dt As DictionaryEntry In ht
            If dt.Key = id Then
                Return dt.Value
            End If
        Next

        Return "ES" & "KIE GWA" & "PO"
    End Function



End Module
