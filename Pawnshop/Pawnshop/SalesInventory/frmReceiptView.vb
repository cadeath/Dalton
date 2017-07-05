Public Class frmReceiptView

    Friend Sub LoadItems(ByVal IDx As Integer)
        lvSaleItem.Items.Clear()
        Dim mysql As String = "Select * From DocLines Where DocID = " & IDx
        Dim ds As DataSet = LoadSQL(mysql)

        For Each dr In ds.Tables(0).Rows
            Additems(dr)
        Next
    End Sub

    Private Sub Additems(ByVal dr As DataRow)
        With dr
            Dim lv As ListViewItem = lvSaleItem.Items.Add(.Item("DLID"))
            lv.SubItems.Add(.Item("ItemCode"))
            lv.SubItems.Add(.Item("Description"))
            lv.SubItems.Add(.Item("Qty"))
            lv.SubItems.Add(.Item("SalePrice"))
            lv.SubItems.Add(.Item("RowTotal"))
        End With

    End Sub
End Class