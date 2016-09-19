﻿Public Class dev_NewItem

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
        Laptop.ItemSpecifications = LaptopSpecs

        Laptop.SaveItem()


        ' LAPTOP
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

        Cellphone.SaveItem()
    End Sub
End Class