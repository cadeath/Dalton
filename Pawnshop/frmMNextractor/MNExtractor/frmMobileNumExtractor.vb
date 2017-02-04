Imports Microsoft.Office.Interop
Public Class frmMobileNumExtractor
    Dim OFD As New OpenFileDialog
    Dim dest As String = My.Computer.FileSystem.SpecialDirectories.Desktop
    Dim BranchCode As String

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        OFDD.ShowDialog()

        txtPath.Text = OFDD.FileName
        database.dbName = txtPath.Text
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If txtPath.Text = "" Then Exit Sub

        Dim str As String = txtPath.Text
        If str.Contains(".FDB") = True Then

            If dbName <> "W3W1LH4CKU.FDB" Then
                MsgBox("Invalid file name." & vbCrLf & "Please try again", MsgBoxStyle.Critical, "")
                txtPath.Text = ""
                database.dbName = ""
                Exit Sub
            End If

            BranchCode = GetOption("BranchCode")

            Me.Enabled = False
            Dim mysql As String = "SELECT DISTINCT (FirstName ||' '|| LastName ||' '|| MiddleName) as Fullname,PHONE1,PHONE2,PHONE3," & _
                                  "PHONE_OTHERS FROM TBLCLIENT WHERE PHONE1 <>'' AND (CHAR_LENGTH(PHONE1)='11')"
            Dim ds As DataSet = LoadSQL(mysql, "TBLCLIENT")

            Dim Headers As String() = {"Fullname", "PHONE1", "PHONE2", "PHONE2", "PHONE_OTHERS"}

            dest = dest & "\" & String.Format("{2}{1}{0}.xlsx", Now.ToString("MMddyyyy"), BranchCode, "MNEXTRACT")  'BranchCode + Date
            MNExtract(Headers, mysql, dest)

            MsgBox("Finished", MsgBoxStyle.Information, Me.Text)
        Else
            MsgBox("Invalid file name." & vbCrLf & "Please try again", MsgBoxStyle.Critical, "")
        End If

      
        txtPath.Text = ""
        database.dbName = ""
        Me.Enabled = True
    End Sub



    Friend Sub MNExtract(ByVal headers As String(), ByVal mySql As String, ByVal dest As String)
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
                    oSheet.Cells(rowCnt, colCnt + 1).value = BranchCode
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

  
End Class