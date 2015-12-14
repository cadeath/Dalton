Public Class frmMIS

    Private Sub frmMIS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtImportPath.Text = ""
    End Sub

    Private Sub CreateLOG()
        If lvImportResult.Items.Count <= 0 Then Exit Sub

        Dim fileName As String = "importLog-" & Now.ToString("yyyyMMdd-mm") & ".txt"
        Dim url As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) & "\" & fileName
        If System.IO.File.Exists(url) Then System.IO.File.Delete(url)
        System.IO.File.Create(url).Dispose()

        Dim objWriter As New System.IO.StreamWriter(url, True)
        objWriter.WriteLine("Extracting " & txtImportPath.Text)
        For Each lv As ListViewItem In lvImportResult.Items
            objWriter.WriteLine("Ln " & lv.Text & " - " & lv.SubItems(1).Text)
        Next

        objWriter.Close()
    End Sub

    Friend Sub AddReport(ByVal ln As Integer, ByVal desc As String)
        Dim lv As ListViewItem = lvImportResult.Items.Add(ln)
        lv.SubItems.Add(desc)
    End Sub

    Private Sub ofdImport_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdImport.FileOk
        txtImportPath.Text = ofdImport.FileName
    End Sub

    Private Sub btnImportBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImportBrowse.Click
        ofdImport.ShowDialog()
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim th As System.Threading.Thread
        th = New Threading.Thread(AddressOf doImport)
        th.Start()

        CreateLOG()
    End Sub

    Private Sub doImport()
        ImportTemplate(txtImportPath.Text)
    End Sub

    Friend Sub AddProgress()
        pbData.Value += 1
    End Sub

    Friend Sub fileLoading(ByVal max As Integer)
        If max = 0 Then
            pbData.Visible = False
            Me.Enabled = True
        Else
            pbData.Maximum = max
            pbData.Visible = True
            Me.Enabled = False
        End If
    End Sub

End Class