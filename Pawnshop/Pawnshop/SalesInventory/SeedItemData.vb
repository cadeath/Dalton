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

    Friend Sub Populate2()
        If isPopulated() Then Exit Sub

        Dim FREEBIES As New cItemData
        With FREEBIES
            .ItemCode = "FRE 00584"
            .Description = "POWER BANK 2600MH - FREEBIES"
            .Category = "FREEBIES"
            .SalePrice = 0
            .Save_ItemData()
        End With

        FREEBIES = New cItemData
        With FREEBIES
            .ItemCode = "FRE 00579"
            .Description = "CORD PROTECTOR -  FREEBIES"
            .Category = "FREEBIES"
            .SalePrice = 0
            .Save_ItemData()
        End With

        FREEBIES = New cItemData
        With FREEBIES
            .ItemCode = "FRE 00580"
            .Description = "MONOPAD WITH HOLDER - FREEBIES"
            .Category = "FREEBIES"
            .SalePrice = 0
            .Save_ItemData()
        End With

        Dim HUAWEI As New cItemData
        With HUAWEI
            .ItemCode = "CEL 04224"
            .Description = "HUAWEI P9 LITE GOLD	1"
            .Barcode = "HWP9LG0001"
            .Category = "CELLPHONE"
            .SubCategory = "HUAWEI"
            .SalePrice = 29000
            .Save_ItemData()
        End With

        Dim ITEMS As New cItemData
        With ITEMS
            .ItemCode = "SMP 00027"
            .Description = "LOAD WALLET	50000"
            .Category = "SMARTLOAD"
            .SalePrice = 0.64
            .Save_ItemData()
        End With

        ITEMS = New cItemData
        With ITEMS
            .ItemCode = "SMP 00074"
            .Description = "SMART MONEY PADALA 4000"
            .Category = "SMARTLOAD"
            .SalePrice = 0.65
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
