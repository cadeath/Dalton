Module SeedItemData
    Friend Sub Populate()
        If isPopulated() Then Exit Sub

        Dim vid001 As New cItemData
        With vid001
            .ItemCode = "VID 0001"
            .Description = "NVIDIA GT 750"
            .Barcode = "GCNV31200"
            .Category = "PERIPHERALS"
            .SubCategory = "VIDEO CARDS"
            .SalePrice = 6600
            .Save_ItemData()
        End With

        Dim vid002 As New cItemData
        With vid002
            .ItemCode = "VID 0002"
            .Description = "AMD RADEON HD 150"
            .Barcode = "GCRAD3010"
            .Category = "PERIPHERALS"
            .SubCategory = "VIDEO CARDS"
            .SalePrice = 3500
            .Save_ItemData()
        End With

        Dim vid003 As New cItemData
        With vid003
            .ItemCode = "VID 0003"
            .Description = "NVIDIA GTX 550"
            .Barcode = "GCNV5100"
            .Category = "PERIPHERALS"
            .SubCategory = "VIDEO CARDS"
            .SalePrice = 8900
            .onHold = True
            .Save_ItemData()
        End With
    End Sub

    Private Function isPopulated() As Boolean
        Dim mySql As String = "SELECT * FROM ITEMMASTER"
        Dim ds As DataSet = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count > 0 Then Return True

        Return False
    End Function
End Module
