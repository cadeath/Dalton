Imports System.IO
Public Class frmDatabseExtractor
    Dim headers As String()

    Dim mysql As New Hashtable

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        FBD.ShowDialog()
        txtSource.Text = FBD.SelectedPath
        dir.ProcessDirectory(txtSource.Text)
    End Sub

    Private Sub OFD_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs)
        txtSource.Text = FBD.SelectedPath
    End Sub

    Private Sub btnExtract_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExtract.Click
        If LV_DBList.Items.Count = 0 Then Exit Sub

        SFD.ShowDialog()

        Dim COUNT As Integer = LV_DBList.Items.Count
        Dim countx As Integer = 0

        For Each lv As ListViewItem In LV_DBList.Items
            countx += 1

            If COUNT = 0 Then Exit For
            COUNT -= 1

            database.dbName = lv.SubItems(0).Text

            Dim ds As DataSet = LoadSQL(txtQuery.Text)

            Try
                If ds.Tables(0).Rows.Count <= 0 Then GoTo NexTStep
            Catch ex As Exception
                MsgBox("Check the sql.")
            End Try

                Dim tmpTextbox As New TextBox
                Dim idx As Integer = 0
                For Each c As DataColumn In ds.Tables(0).Columns
                    idx += 1
                    tmpTextbox.AppendText(c.ColumnName & " ")
                Next
                Dim mid As String = tmpTextbox.Text.Trim
                headers = mid.Split(CChar(" "))

                ExtractToExcel(headers, txtQuery.Text, SFD.FileName, countx)
NexTStep:
        Next

        MsgBox("Successfully Extracted.", MsgBoxStyle.Information, "Extract")
        LV_DBList.Items.Clear()
        txtSource.Text = ""
    End Sub


    Private Sub Gen_Query()

        Dim stDate As Date = GetFirstDate(monCal.SelectionRange.Start)
        Dim enDate As Date = GetLastDate(monCal.SelectionRange.End)
        Dim selDate As Date = monCal.SelectionStart.ToShortDateString

        Dim ExtractType As String() = {"LOANS", "Vault_INV"}

        Dim mysql As New dir
        Dim Vault_SQL As String() = {mysql.new_loan(stDate, enDate), mysql.Vault(selDate)}

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




End Class
