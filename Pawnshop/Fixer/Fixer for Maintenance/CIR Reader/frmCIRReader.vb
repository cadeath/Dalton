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
        Dim lv As ListViewItem = Nothing

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

            If dsRate.Tables.IndexOf(tbl.TableName) = 0 Then

                For clm As Integer = 0 To dsRate.Tables(fillData).Columns.Count - 1

                    AddaColumn(dsRate.Tables(fillData).Columns.Item(clm).ToString, lvCIR)
                Next

                For Each dr As DataRow In dsRate.Tables(fillData).Rows
                    Dim dsNewRow As DataRow
                    dsNewRow = dsRate.Tables(fillData).NewRow

                    lv = lvCIR.Items.Add(IIf(IsDBNull(dsRate.Tables(fillData).Rows(i).Item(0)), " ", dsRate.Tables(fillData).Rows(i).Item(0)))
                    For setColumn As Integer = 1 To dsRate.Tables(fillData).Columns.Count - 1
                        'dsRate.Tables(fillData).Rows(setColumn).Item(setColumn)
                        Console.WriteLine("Column " & dsRate.Tables(fillData).Rows(i).Item(setColumn))
                        lv.SubItems.Add(IIf(IsDBNull(dsRate.Tables(fillData).Rows(i).Item(setColumn)), " ", dsRate.Tables(fillData).Rows(i).Item(setColumn)))
                    Next
                    Application.DoEvents()
                    i += 1
                Next
            Else
                Dim lvSample As ListView = New ListView, tmp As ListView
                With lvSample
                    .Location = New Point(12, 333)
                    .Size = New Size(699, 253)
                    .GridLines = True
                    .FullRowSelect = True
                    .View = View.Details
                    .Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
                End With
                Controls.Add(lvSample)
                tmp = RenameValue(lvSample, "lv" & tbl.TableName)

                For clm As Integer = 0 To dsRate.Tables(fillData).Columns.Count - 1
                    AddaColumn(dsRate.Tables(fillData).Columns.Item(clm).ToString, tmp)
                Next

                For Each dr As DataRow In dsRate.Tables(fillData).Rows
                    Dim dsNewRow As DataRow

                    dsNewRow = dsRate.Tables(fillData).NewRow

                    lv = tmp.Items.Add(IIf(IsDBNull(dsRate.Tables(fillData).Rows(i).Item(0)), " ", dsRate.Tables(fillData).Rows(i).Item(0)))
                    For setColumn As Integer = 1 To dsRate.Tables(fillData).Columns.Count - 1
                        lv.SubItems.Add(IIf(IsDBNull(dsRate.Tables(fillData).Rows(i).Item(setColumn)), " ", dsRate.Tables(fillData).Rows(i).Item(setColumn)))
                    Next
                    Application.DoEvents()
                    i += 1
                Next

            End If
        Next
       
    End Sub

    Private Function RenameValue(ByVal lv As ListView, ByVal NewName As String) As ListView
        Dim tempCtrl As ListView
        'For Each tempCtrl In Me.Controls

        '    If tempCtrl.Name = OldName Then
        '        tempCtrl.Name = NewName
        '    End If
        'Next
        lv.Name = NewName
        tempCtrl = lv
        Return tempCtrl
    End Function

    Private Function ErrCheck(ByVal str As String) As String
        If str.Contains("Table unknown") Then
            Return "Table not found"
        End If

        Return "UNKNOWN"
    End Function

    Private Sub AddaColumn(ByRef ColumnString As String, ByVal lv As ListView)
        Dim NewCH As New ColumnHeader

        NewCH.Text = ColumnString
        lv.Columns.Add(NewCH)
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

End Class