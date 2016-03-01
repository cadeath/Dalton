Module Service

    Private mySql As String, fillData As String
    Private ds As DataSet

    Function ExtractServices2ds(ByVal src As String) As DataSet
        mySql = "SELECT * FROM TBLCASH ORDER BY CASHID ASC"
        database.dbName = src
        ds = LoadSQL(mySql)

        Developers_Note("Source entries is " & ds.Tables(0).Rows.Count)
        Return ds
    End Function

    Sub Update_Services(ByVal ds As DataSet)
        Dim MaxEntries As Integer = 0, wasModified As Boolean = False
        mySql = "SELECT * FROM TBLCASH ORDER BY CASHID ASC"
        fillData = "TBLCASH"

        Dim updateDS As DataSet
        updateDS = LoadSQL(mySql, fillData)
        Developers_Note("Entries to be updated is " & updateDS.Tables(0).Rows.Count)

        MaxEntries = ds.Tables(0).Rows.Count
        For i As Integer = 0 To MaxEntries - 1
            wasModified = False

            If i + 1 < updateDS.Tables(fillData).Rows.Count Then
                If Not IsDBNull(ds.Tables(0).Rows(i).Item(1)) Then _
            If ds.Tables(0).Rows(i).Item(1) <> updateDS.Tables(fillData).Rows(i).Item(1) Then _
                updateDS.Tables(fillData).Rows(i).Item(1) = ds.Tables(0).Rows(i).Item(1) : wasModified = True

                If Not IsDBNull(ds.Tables(0).Rows(i).Item(2)) Then _
                If ds.Tables(0).Rows(i).Item(2) <> updateDS.Tables(fillData).Rows(i).Item(2) Then _
                    updateDS.Tables(fillData).Rows(i).Item(2) = ds.Tables(0).Rows(i).Item(2) : wasModified = True

                If ds.Tables(0).Rows(i).Item(3) <> updateDS.Tables(fillData).Rows(i).Item(3) Then _
                    updateDS.Tables(fillData).Rows(i).Item(3) = ds.Tables(0).Rows(i).Item(3) : wasModified = True

                If ds.Tables(0).Rows(i).Item(4) <> updateDS.Tables(fillData).Rows(i).Item(4) Then _
                    updateDS.Tables(fillData).Rows(i).Item(4) = ds.Tables(0).Rows(i).Item(4) : wasModified = True

                If Not IsDBNull(ds.Tables(0).Rows(i).Item(5)) Then _
                If ds.Tables(0).Rows(i).Item(5) <> updateDS.Tables(fillData).Rows(i).Item(5) Then _
                    updateDS.Tables(fillData).Rows(i).Item(5) = ds.Tables(0).Rows(i).Item(5) : wasModified = True

                If ds.Tables(0).Rows(i).Item(6) <> updateDS.Tables(fillData).Rows(i).Item(6) Then _
                    updateDS.Tables(fillData).Rows(i).Item(6) = ds.Tables(0).Rows(i).Item(6) : wasModified = True

                If wasModified Then database.SaveEntry(updateDS, False) : Developers_Note("Row " & i & " was modified.")
            Else
                Dim dsNewRow As DataRow
                dsNewRow = updateDS.Tables(fillData).NewRow
                With ds.Tables(0).Rows(i)
                    dsNewRow.Item(1) = .Item(1)
                    dsNewRow.Item(2) = .Item(2)
                    dsNewRow.Item(3) = .Item(3)
                    dsNewRow.Item(4) = .Item(4)
                    If Not IsDBNull(.Item(5)) Then dsNewRow.Item(5) = .Item(5)
                    dsNewRow.Item(6) = .Item(6)
                End With
                updateDS.Tables(fillData).Rows.Add(dsNewRow)
                SaveEntry(updateDS)
                Developers_Note("Entry added!!!")
            End If
        Next
        Developers_Note("Checking Services DONE.")
    End Sub

End Module
