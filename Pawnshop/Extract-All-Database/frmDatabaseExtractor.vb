Imports System.IO
Imports Microsoft.Office.Interop


Public Class frmDatabseExtractor
    Dim headers As String()
    Dim Counter As Integer = 0
    Dim mysql As New Hashtable

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        FBD.ShowDialog()
        txtSource.Text = FBD.SelectedPath
        dir.ProcessDirectory(txtSource.Text)

        Counter = LV_DBList.Items.Count
        ToolCount.Text = Counter
    End Sub

    Private Sub OFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        txtSource.Text = FBD.SelectedPath
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If LV_DBList.Items.Count = 0 Then Exit Sub

        SFD.ShowDialog()
        Dim maxEntries As Integer = 0

        Dim COUNT As Integer = LV_DBList.Items.Count
        Dim countx As Integer = 0

        For Each lv As ListViewItem In LV_DBList.Items
            Me.Enabled = False
            countx += 1

            If COUNT = 0 Then Exit For
            COUNT -= 1

            database.dbName = lv.SubItems(0).Text
            Dim ds As DataSet

            Try
                ds = LoadSQL(txtQuery.Text)
                If ds.Tables(0).Rows.Count = 0 Then
                    GoTo NexTStep
                End If

            Catch ex As Exception
                If MsgBox("Check the sql.", MsgBoxStyle.OkOnly) = MsgBoxResult.Ok Then
                    GoTo nextSTEPTODO
                End If
            End Try

            Dim tmpTextbox As New TextBox
            Dim idx As Integer = 0
            For Each c As DataColumn In ds.Tables(0).Columns
                idx += 1
                tmpTextbox.AppendText(c.ColumnName & " ")
            Next
            Dim mid As String = tmpTextbox.Text.Trim
            headers = mid.Split(CChar(" "))

            ToolCount.Text = COUNT

            ExtractToExcel(headers, txtQuery.Text, SFD.FileName, countx)

NexTStep:
        Next


        Convert(SFD.FileName)

        If File.Exists(SFD.FileName) Then
            File.Delete(SFD.FileName)
        End If

        MsgBox("Successfully Extracted.", MsgBoxStyle.Information, "Extract")

nextSTEPTODO:
        Me.Enabled = True
        LV_DBList.Items.Clear()
        txtSource.Text = ""
        txtQuery.Text = ""
        

    End Sub


    Private Sub Gen_Query()

        Dim stDate As Date = Now

        Dim ExtractType As String() = {"LOANS", "Vault_INV"}

        Dim mysql As New dir
        Dim Vault_SQL As String() = {mysql.new_loan(stDate, stDate), mysql.Vault(stDate)}

        For i As Integer = 0 To ExtractType.Count - 1
            Dim lv As ListViewItem = LVQuery.Items.Add(ExtractType(i))
            lv.SubItems.Add(Vault_SQL(i))
        Next

    End Sub

    Private Sub frmDatabseExtractor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Gen_Query()
    End Sub

    Private Sub LVQuery_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LVQuery.DoubleClick

        txtQuery.Text = LVQuery.SelectedItems(0).SubItems(1).Text

    End Sub

    Private Sub Convert(ByVal S As String)
        Dim oFSO, oInputFile, oOutputFile
        Dim oStr As String
        oFSO = CreateObject("Scripting.FileSystemObject")

        Dim oInfo As New ProcessStartInfo
        Dim oExcel As New Excel.Application
        Dim oWorkBook As Excel.Workbook

        oInfo.CreateNoWindow = False
        With oExcel
            .Visible = False
            .DisplayAlerts = False
        End With

        If System.IO.File.Exists(Replace(S, "xls", "csv")) = True Then
            System.IO.File.Delete(Replace(S, "xls", "csv"))
            GoTo x
        Else
x:
            If Not File.Exists(S) Then
                Exit Sub
            End If

            oWorkBook = oExcel.Workbooks.Open(S)
            oWorkBook = oExcel.Workbooks.Open(S)

            oWorkBook.SaveAs(Filename:=Replace(S, "xls", "csv"), FileFormat:=Microsoft.Office.Interop.Excel.XlFileFormat.xlTextMSDOS)

            oWorkBook.Close()
            oExcel.DisplayAlerts = False
            oExcel.Quit()

            oInputFile = oFSO.OpenTextFile(Replace(S, "xls", "csv"))
            oStr = oInputFile.ReadAll
            oStr = Replace(oStr, vbTab, ",")

            oOutputFile = oFSO.CreateTextFile(Replace(S, "xls", "csv"), True)
            oOutputFile.Write(oStr)
        End If

        If File.Exists(S) Then
            File.Delete(S)
        End If
    End Sub

 
End Class
