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
Module mod_system


    'Dim BranchCode As String = GetOption("BranchCode")
    'Public branchName As String = GetOption("BranchName")
    'Public AREACODE As String = GetOption("BranchArea")
    'Public REVOLVING_FUND As String = GetOption("RevolvingFund")

    Public Function CommandPrompt(ByVal app As String, ByVal args As String) As String
        Dim oProcess As New Process()
        Dim oStartInfo As New ProcessStartInfo(app, args)
        oStartInfo.UseShellExecute = False
        oStartInfo.RedirectStandardOutput = True
        oStartInfo.WindowStyle = ProcessWindowStyle.Hidden
        oStartInfo.CreateNoWindow = True
        oProcess.StartInfo = oStartInfo

        oProcess.Start()

        Dim sOutput As String
        Using oStreamReader As System.IO.StreamReader = oProcess.StandardOutput
            sOutput = oStreamReader.ReadToEnd()
        End Using

        Return sOutput
    End Function

  
    Friend Function DigitOnly(ByVal e As System.Windows.Forms.KeyPressEventArgs, Optional isWhole As Boolean = False)
        Console.WriteLine("char: " & e.KeyChar & " -" & Char.IsDigit(e.KeyChar))
        If e.KeyChar <> ControlChars.Back Then
            If isWhole Then
                e.Handled = Not (Char.IsDigit(e.KeyChar))
            Else
                e.Handled = Not (Char.IsDigit(e.KeyChar) Or e.KeyChar = ".")
            End If

        End If

        Return Not (Char.IsDigit(e.KeyChar))
    End Function

    Friend Function checkNumeric(ByVal txt As TextBox) As Boolean
        If IsNumeric(txt.Text) Then
            Return True
        End If

        Return False
    End Function

    Friend Function DreadKnight(ByVal str As String, Optional ByVal special As String = Nothing) As String
        str = str.Replace("'", "''")
        str = str.Replace("""", """""")

        If special <> Nothing Then
            str = str.Replace(special, "")
        End If

        Return str
    End Function

    ''' <summary>
    ''' Identify if the KeyPress is enter
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <returns>Boolean</returns>
    Friend Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Friend Function GetCurrentAge(ByVal dob As Date) As Integer
        Dim age As Integer
        age = Today.Year - dob.Year
        If (dob > Today.AddYears(-age)) Then age -= 1
        Return age
    End Function

    ''' <summary>
    ''' Use to verify entry
    ''' </summary>
    ''' <param name="txtBox">TextBox of the Money</param>
    ''' <returns>Boolean</returns>
    Friend Function isMoney(ByVal txtBox As TextBox) As Boolean
        Dim isGood As Boolean = False

        If Double.TryParse(txtBox.Text, 0.0) Then
            isGood = True
        End If

        Return isGood
    End Function

    Friend Function GetFirstDate(ByVal curDate As Date) As Date
        Dim firstDay = DateSerial(curDate.Year, curDate.Month, 1)
        Return firstDay
    End Function

    Friend Function GetLastDate(ByVal curDate As Date) As Date
        Dim original As DateTime = curDate  ' The date you want to get the last day of the month for
        Dim lastOfMonth As DateTime = original.Date.AddDays(-(original.Day - 1)).AddMonths(1).AddDays(-1)

        Return lastOfMonth
    End Function


    Friend Sub ExtractToExcel(ByVal headers As String(), ByVal mySql As String, ByVal dest As String, ByVal i As Integer)
        If dest = "" Then Exit Sub

        Dim BRANCHCODE As String = GetOption("BranchCode")

        If i = 1 Then

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
                Application.DoEvents()
            Next

            oWB.SaveAs(dest)
            oSheet = Nothing
            oWB.Close(False)
            oWB = Nothing
            oXL.Quit()
            oXL = Nothing

            Console.WriteLine("Data Extracted")
        Else

            Dim ds As DataSet = LoadSQL(mySql)


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
                Application.DoEvents()
            Next


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
    Public Function GetIDbyName(name As String, ht As Hashtable) As Integer
        For Each dt As DictionaryEntry In ht
            If dt.Value = name Then
                Return dt.Key
            End If
        Next

        Return 0
    End Function

    Public Function GetNameByID(id As Integer, ht As Hashtable) As String
        For Each dt As DictionaryEntry In ht
            If dt.Key = id Then
                Return dt.Value
            End If
        Next

        Return "ES" & "KIE GWA" & "PO"
    End Function



#Region "Log Module"
    Const LOG_FILE As String = "syslog.txt"
    Private Sub CreateLog()
        Dim fsEsk As New System.IO.FileStream(LOG_FILE, IO.FileMode.CreateNew)
        fsEsk.Close()
    End Sub

    Friend Sub Log_Report(ByVal str As String)
        If Not System.IO.File.Exists(LOG_FILE) Then CreateLog()

        Dim recorded_log As String = _
            String.Format("[{0}] " & str, Now.ToString("MM/dd/yyyy HH:mm:ss"))

        Dim fs As New System.IO.FileStream(LOG_FILE, IO.FileMode.Append, IO.FileAccess.Write)
        Dim fw As New System.IO.StreamWriter(fs)
        fw.WriteLine(recorded_log)
        fw.Close()
        fs.Close()
        Console.WriteLine("Recorded")
    End Sub
#End Region
End Module
