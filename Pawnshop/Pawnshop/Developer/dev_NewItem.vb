Public Class dev_NewItem

    Private sel_Item As ItemClass
    Private sel_spec As ItemSpecs

    Private Sub btnPop_Click(sender As System.Object, e As System.EventArgs) Handles btnPop.Click

        ' LAPTOP
        Dim Laptop As New ItemClass
        Dim LaptopSpecs As New CollectionItemSpecs
        Laptop.ItemClass = "Laptop"
        Laptop.Category = "Gadget"
        Laptop.Description = "With the inches of 14 or more, and has NUMERIC KEYPAD."
        Laptop.isRenewable = True
        Laptop.PrintLayout = "[ClassName] [serial]" & vbCrLf & "[desc]"
        Laptop.InterestRate = 0.04

        Dim shortCodes As String() = {"serial", "desc"}
        Dim specsName As String() = {"Serial", "Description"}
        Dim specsType As String() = {"String", "String"}
        Dim specsLayout As String() = {"TextBox", "MultiLine"}
        Dim isReq As Boolean() = {True, True}

        For i As Integer = 0 To isReq.Length - 1
            Dim itemSpec As New ItemSpecs
            With itemSpec
                .ShortCode = shortCodes(i)
                .SpecName = specsName(i)
                .SpecLayout = specsLayout(i)
                .SpecType = specsType(i)
                .isRequired = isReq(i)
            End With

            LaptopSpecs.Add(itemSpec)
        Next
        'Laptop.ItemSpecifications = LaptopSpecs

        'Laptop.SaveItem()


        ' CELLPHONE
        Dim Cellphone As New ItemClass
        Dim CellSpecs As New CollectionItemSpecs

        With Cellphone
            .ItemClass = "Cellphone"
            .Category = "Gadget"
            .Description = "Cellular Devices"
            .isRenewable = True
            .PrintLayout = "[ClassName] [serial]" & vbCrLf & "[desc]"
            .InterestRate = 0.04
        End With

        shortCodes = {"serial", "desc"}
        specsName = {"Serial", "Description"}
        specsType = {"String", "String"}
        specsLayout = {"TextBox", "MultiLine"}
        isReq = {True, True}

        For i As Integer = 0 To isReq.Length - 1
            Dim itemSpec As New ItemSpecs
            With itemSpec
                .ShortCode = shortCodes(i)
                .SpecName = specsName(i)
                .SpecLayout = specsLayout(i)
                .SpecType = specsType(i)
                .isRequired = isReq(i)
            End With

            CellSpecs.Add(itemSpec)
        Next
        Cellphone.ItemSpecifications = CellSpecs

        Cellphone.Save_ItemClass()


        ' JEWELRY
        Dim BRACELET As New ItemClass
        Dim BRACELETSPECS As New CollectionItemSpecs

        With BRACELET
            .ItemClass = "Bracelet"
            .Category = "Jewelry"
            '.Description = "Cellular Devices"
            .isRenewable = True
            .PrintLayout = "1 [ClassName] [G] [K:ENCRYPTED]"
            .InterestRate = 0.03
        End With

        shortCodes = {"G", "K", "desc"}
        specsName = {"Grams", "Karat", "Description"}
        specsType = {"String", "String", "String"}
        specsLayout = {"TextBox", "Karat", "MultiLine"}
        isReq = {True, True, False}

        For i As Integer = 0 To isReq.Length - 1
            Dim itemSpec As New ItemSpecs
            With itemSpec
                .ShortCode = shortCodes(i)
                .SpecName = specsName(i)
                .SpecLayout = specsLayout(i)
                .SpecType = specsType(i)
                .isRequired = isReq(i)
            End With

            BRACELETSPECS.Add(itemSpec)
        Next
        BRACELET.ItemSpecifications = BRACELETSPECS

        BRACELET.Save_ItemClass()


        'ItemClass_Seed.Populate()
    End Sub

    Private Sub btnLoadClass_Click(sender As System.Object, e As System.EventArgs) Handles btnLoadClass.Click
        Dim mySql As String = "SELECT * FROM tblItem"
        Dim ds As DataSet = LoadSQL(mySql)

        lsClass.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows

            lsClass.Items.Add(dr("ItemID"))

        Next
    End Sub

    Private Sub lsClass_DoubleClick(sender As Object, e As System.EventArgs) Handles lsClass.DoubleClick
        Dim idx As Integer = lsClass.SelectedIndex
        Dim itemID As Integer = lsClass.Items(idx).ToString

        sel_Item = New ItemClass
        sel_Item.LoadItem(itemID)
        txtCategory.Text = sel_Item.Category
        txtPrint.Text = sel_Item.PrintLayout

        lblID.Text = sel_Item.ID
        'lblCLass.Text = sel_Item.ItemClass

        lsSpecs.Items.Clear()
        For Each spec As ItemSpecs In sel_Item.ItemSpecifications

            lsSpecs.Items.Add(spec.SpecName)

        Next
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        sel_spec.SpecName = txtSpec.Text
        sel_spec.ShortCode = txtCode.Text
        sel_spec.UpdateSpecs()

        sel_Item.Category = txtCategory.Text
        sel_Item.PrintLayout = txtPrint.Text
        sel_Item.Update()
    End Sub

    Private Sub lsSpecs_DoubleClick(sender As Object, e As System.EventArgs) Handles lsSpecs.DoubleClick
        Dim idx As Integer = lsSpecs.SelectedIndex
        'Dim specID As Integer = lsSpecs.Items(idx).ToString

        sel_spec = New ItemSpecs
        sel_spec = sel_Item.ItemSpecifications(idx)
        txtSpec.Text = sel_spec.SpecName
        txtCode.Text = sel_spec.ShortCode
    End Sub
End Class