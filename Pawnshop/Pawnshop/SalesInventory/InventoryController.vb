Module InventoryController
    Dim mySql As String, ds As DataSet

    Friend Sub AddInventory(ByVal itemCode As String, Optional ByVal Qty As Integer = 1)
        mySql = String.Format("SELECT * FROM ITEMMASTER WHERE ITEMCODE = '{0}'", itemCode)
        ds = LoadSQL(mySql, "ITEMMASTER")

        If Not ds.Tables(0).Rows.Count = 1 Then
            Console.WriteLine("PROBLEM ON ITEM " & itemCode)
            MsgBox("PROBLEM ON ITEM " & itemCode, MsgBoxStyle.Critical)
            Exit Sub
        End If

        ds.Tables("ITEMMASTER").Rows(0).Item("ONHAND") += Qty
        database.SaveEntry(ds)
    End Sub

    Friend Sub DeductInventory(ByVal itemCode As String, Optional ByVal Qty As Integer = 1)
        mySql = String.Format("SELECT * FROM ITEMMASTER WHERE ITEMCODE = '{0}'", itemCode)
        ds = LoadSQL(mySql, "ITEMMASTER")

        If Not ds.Tables(0).Rows.Count = 1 Then
            Console.WriteLine("PROBLEM ON ITEM " & itemCode)
            MsgBox("PROBLEM ON ITEM " & itemCode, MsgBoxStyle.Critical)
            Exit Sub
        End If

        ds.Tables("ITEMMASTER").Rows(0).Item("ONHAND") -= Qty
        database.SaveEntry(ds)
    End Sub

End Module
