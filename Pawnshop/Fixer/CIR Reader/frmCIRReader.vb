Public Class frmCIRReader
    Private dsRate As DataSet
    Private isFailed As Boolean = False
    Private fillData As String, mySql As String

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdUpdate.ShowDialog()

        If Not System.IO.File.Exists(txtPath.Text) Then Exit Sub

        'Disable(1)
        do_RateUpdate(txtPath.Text)
        'Disable(0)
    End Sub

    Private Sub ofdUpdate_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ofdUpdate.FileOk
        txtPath.Text = ofdUpdate.FileName
    End Sub

    Private Sub do_RateUpdate(ByVal url As String, Optional ByVal dbSrc As String = "")
        Dim fs As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Try
            dsRate = bf.Deserialize(fs)
        Catch ex As Exception
            MsgBox("It seems the file is being tampered.", MsgBoxStyle.Critical)
            Log_Report(String.Format("[{0}] - ", url) & ex.ToString)
            fs.Close()
            isFailed = True
            If isFailed Then Exit Sub
        End Try
        fs.Close()

        For Each tbl As DataTable In dsRate.Tables

            fillData = tbl.TableName
            mySql = "SELECT * FROM " & fillData
            If dbSrc <> "" Then database.dbName = dbSrc
            Dim MaxDS As Integer = 0, MaxRate As Integer = 0
            Dim i As Integer = 0

            For clm As Integer = 0 To dsRate.Tables(fillData).Columns.Count - 1
                AddaColumn("Columns " & clm)
            Next

            For Each dr As DataRow In dsRate.Tables(fillData).Rows
                Dim dsNewRow As DataRow
                dsNewRow = dsRate.Tables(fillData).NewRow

                Dim lv As ListViewItem = lvCIR.Items.Add(IIf(IsDBNull(dsRate.Tables(fillData).Rows(i).Item(0)), " ", dsRate.Tables(fillData).Rows(i).Item(0)))
                For setColumn As Integer = 1 To dsRate.Tables(fillData).Columns.Count - 1
                    'dsRate.Tables(fillData).Rows(setColumn).Item(setColumn)
                    Console.WriteLine("Column " & dsRate.Tables(fillData).Rows(i).Item(setColumn))
                    lv.SubItems.Add(IIf(IsDBNull(dsRate.Tables(fillData).Rows(i).Item(setColumn)), " ", dsRate.Tables(fillData).Rows(i).Item(setColumn)))
                Next
                Application.DoEvents()
                i += 1
            Next
        Next
       
    End Sub

    Private Function ErrCheck(ByVal str As String) As String
        If str.Contains("Table unknown") Then
            Return "Table not found"
        End If

        Return "UNKNOWN"
    End Function

    Private Sub AddaColumn(ByRef ColumnString As String)
        Dim NewCH As New ColumnHeader

        NewCH.Text = ColumnString
        lvCIR.Columns.Add(NewCH)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SelectPT(txtSearch.Text)
    End Sub

    Private Sub SelectPT(ByVal pt As String)

        'For Each itm As ListViewItem In lvCIR.Items
        '    If itm.SubItems.Contains(pt) Then
        '        itm.Selected = True
        '        Exit For
        '    End If
        'Next
    End Sub

    Private Sub frmCIRReader_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class