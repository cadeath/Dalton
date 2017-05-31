Module update_tblCharges

    Private mySql As String
    Private fillData As String
    Private ds As DataSet

    Private Function LoadLatest_Charges(url As String) As DataSet
        'Swap DB URL
        Dim orgURL As String = database.dbName
        database.dbName = url

        mySql = "SELECT * FROM tblCharge ORDER BY ID ASC"
        ds = New DataSet
        ds = LoadSQL(mySql)
        database.dbName = orgURL

        Return ds
    End Function

    Sub doUpdateCharges(src As String, dest As String)
        Dim lastestCharges As DataSet = LoadLatest_Charges(src)
        fillData = "tblCharge"

        For Each dr As DataRow In lastestCharges.Tables(0).Rows
            Dim id As Integer = dr.Item("ID")
            Dim type As String = dr.Item("Type")
            Dim Amt As Double = dr.Item("Amount")
            Dim chrg As Double = dr.Item("Charge")
            Dim commission As Double = dr.Item("Commission")
            Dim remarks As String = IIf(IsDBNull(dr.Item("Remarks")), "", dr.Item("Remarks"))

            mySql = "SELECT * FROM tblCharge WHERE ID = " & id
            ds = LoadSQL(mySql, fillData)

            If ds.Tables(fillData).Rows.Count = 0 Then
                'Add Entry
                Dim dsNewRow As DataRow
                dsNewRow = ds.Tables(fillData).NewRow
                With dsNewRow
                    .Item("Type") = type
                    .Item("Amount") = Amt
                    .Item("Charge") = chrg
                    .Item("Commission") = commission
                    If remarks <> "" Then .Item("Remarks") = remarks
                End With
                ds.Tables(fillData).Rows.Add(dsNewRow)
                database.SaveEntry(ds)
            Else
                'Modify Entry
                With ds.Tables(fillData).Rows(0)
                    .Item("Type") = type
                    .Item("Amount") = Amt
                    .Item("Charge") = chrg
                    .Item("Commission") = commission
                    If remarks <> "" Then .Item("Remarks") = remarks
                End With

                database.SaveEntry(ds, False)
            End If
        Next


    End Sub
End Module