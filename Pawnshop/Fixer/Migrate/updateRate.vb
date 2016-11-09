
Module updateRate
    Private dsRate As DataSet
    ' Private ds As String = database.dbName
    Private isFailed As Boolean = False
    Private fillData As String, mySql As String

    Sub do_RateUpdate(ByVal url As String, Optional ByVal dbSrc As String = "")
        Dim fs As New System.IO.FileStream(url, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Try
            dsRate = bf.Deserialize(fs)
        Catch ex As Exception
            MsgBox("It seems the file is being tampered.", MsgBoxStyle.Critical)
            fs.Close()
            isFailed = True
        End Try
        fs.Close()
        For Each tbl As DataTable In dsRate.Tables
            If isFailed Then Exit Sub
            fillData = tbl.TableName
            mySql = "SELECT * FROM " & fillData
            If dbSrc <> "" Then database.dbName = dbSrc
            Dim ds As DataSet, MaxDS As Integer = 0, MaxRate As Integer = 0

            Try

                ds = LoadSQL(mySql, fillData)

                MaxDS = ds.Tables(fillData).Rows.Count
                MaxRate = dsRate.Tables(fillData).Rows.Count
                Console.WriteLine("Table " & fillData & " found.")
            Catch ex As Exception
                Select Case ErrCheck(ex.ToString)
                    Case "Table not found"
                        MsgBox("File unable to verify its data", MsgBoxStyle.Critical)
                    Case Else
                        MsgBox("Unknown error occurred", MsgBoxStyle.Critical)
                End Select
                Exit Sub
            End Try


            Dim i As Integer = 0
            Dim ID As String = ds.Tables(fillData).Columns.Item(0).ColumnName


            'Remove Excessive entries
            Console.WriteLine("Checking excessive entries")
            ds = LoadSQL(mySql, fillData)
            mySql = "DELETE FROM " & fillData
            mySql &= " WHERE " & ID & " > " & (0)

            ds.Clear()
            ds = LoadSQL(mySql, fillData)

            Console.WriteLine("Updating table") : i = 0
            For Each dr As DataRow In dsRate.Tables(fillData).Rows

                mySql = "SELECT * FROM " & fillData
                mySql &= " WHERE " & ID & " = " & dr.Item(0)

                ds.Clear()
                ds = LoadSQL(mySql, fillData)
                If ds.Tables(fillData).Rows.Count = 1 Then

                    For setColumn As Integer = 1 To dsRate.Tables(fillData).Columns.Count - 1
                        ds.Tables(fillData).Rows(0).Item(setColumn) = _
                            dsRate.Tables(fillData).Rows(i).Item(setColumn)
                    Next
                    database.SaveEntry(ds, False)
                Else
                    Dim dsNewRow As DataRow
                    dsNewRow = ds.Tables(fillData).NewRow

                    For setColumn As Integer = 0 To dsRate.Tables(fillData).Columns.Count - 1
                        With dsNewRow
                            .Item(setColumn) = _
                            dsRate.Tables(fillData).Rows(i).Item(setColumn)
                        End With
                    Next
                    ds.Tables(fillData).Rows.Add(dsNewRow)
                    database.SaveEntry(ds)
                End If

                Application.DoEvents()
                i += 1
            Next
        Next
    End Sub
    Private Function ErrCheck(str As String) As String
        If str.Contains("Table unknown") Then
            Return "Table not found"
        End If

        Return "UNKNOWN"
    End Function

End Module
