Imports Microsoft.Office.Interop
Imports System.IO
Public Class Extract
    Const DBPATH As String = "\W3W1LH4CKU.FDB"
    Private path As String

    Private Sub LoadQuery()
        Dim mysql As String = "" & txtQuery.Text & ""
        Dim ds As DataSet = LoadSQL(mysql)
        Dim tmpTableName As New TextBox, tmp As String

        'For Each obj In lbTableName.Items
        '    tmpTableName.AppendText(obj.ToString & " ")
        'Next

        For Each dt In ds.Tables
            For Each column In dt.Columns
                tmpTableName.AppendText(column.ColumnName & " ")
            Next
        Next
        tmp = tmpTableName.Text.TrimEnd
     
        Dim tmpCount() As String = tmp.Split(CChar(" "))
        Dim tmpString() As String = {tmp}
        sfdPath.FileName = String.Format("{0}.xlsx", GetOption("BranchCode"))
        path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & sfdPath.FileName
        ExtractToExcell(tmpCount, mysql, path)

        MsgBox("Successfully Extracted", MsgBoxStyle.Information, "Extract")
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtPath.Text = firebird
    End Sub

    Private Sub Extract_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtQuery.ScrollBars = ScrollBars.Vertical
        LoadPath()
        txtSavePath.Text = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        LoadQuery()
    End Sub

    Friend Sub ExtractToExcell(ByVal headers As String(), ByVal mySql As String, ByVal dest As String)
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

    Private Function GetOption(ByVal keys As String) As String
        Dim mySql As String = "SELECT * FROM tblmaintenance WHERE opt_keys = '" & keys & "'"
        Dim ret As String
        Try
            Dim ds As DataSet = LoadSQL(mySql)
            ret = ds.Tables(0).Rows(0).Item("opt_values")
        Catch ex As Exception
            ret = 0
        End Try

        Return ret
    End Function

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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try

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

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sfdPath.ShowDialog()
    End Sub

    Private Sub lbTableName_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbTableName.DoubleClick
        lbTableName.Items(lbTableName.SelectedIndex) = txtHeader.Text
    End Sub
End Class