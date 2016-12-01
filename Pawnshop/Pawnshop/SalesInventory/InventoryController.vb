Imports Microsoft.Office.Interop

Module InventoryController
    Dim mySql As String, ds As DataSet

    Const INTEGRITY_CHECK As String = "9nKFB3fmcquj4CNHjDz7atiD7JOv892aQiKESns50sH/rBAxkxEe3by5N607DFRcORSXzwVcEfviYb5TRjoSck/YScmjycq+lOzWi+Gh01S7oF7hsp4EKYw4jXAUeGTe"

    Friend Sub AddInventory(ByVal itemCode As String, Optional ByVal Qty As Integer = 1)
        mySql = String.Format("SELECT * FROM ITEMMASTER WHERE ITEMCODE = '{0}'", itemCode)
        ds = LoadSQL(mySql, "ITEMMASTER")

        If Not ds.Tables(0).Rows.Count = 1 Then
            Console.WriteLine("PROBLEM ON ITEM " & itemCode)
            MsgBox("PROBLEM ON ITEM " & itemCode, MsgBoxStyle.Critical)
            Exit Sub
        End If

        ds.Tables("ITEMMASTER").Rows(0).Item("ONHAND") += Qty
        ds.Tables("ITEMMASTER").Rows(0).Item("UPDATE_TIME") = Now()
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
        ds.Tables("ITEMMASTER").Rows(0).Item("UPDATE_TIME") = Now()
        database.SaveEntry(ds, False)
    End Sub

    Friend Sub PullOut(ByVal RecalledItem As cItemData)
        Dim mySql As String, ds As DataSet, PawnItemID As Integer = 0
        mySql = "SELECT * FROM OPT WHERE PAWNTICKET = " & RecalledItem.Tags

        ds = LoadSQL(mySql, "OPT")
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("FAILED TO EXECUTE PULLOUT") : Exit Sub

        PawnItemID = ds.Tables(0).Rows(0).Item("PAWNITEMID")

        ' UPDATING OPT
        ds.Tables("OPT").Rows(0).Item("STATUS") = "W"
        ds.Tables("OPT").Rows(0).Item("UPDATED_AT") = Now
        database.SaveEntry(ds, False)

        ds.Clear()
        mySql = "SELECT * FROM OPI WHERE PAWNITEMID = " & PawnItemID
        ds = LoadSQL(mySql, "OPI")
        If ds.Tables(0).Rows.Count = 0 Then
            Log_Report(String.Format("UPDATING OPI PROBLEM - TAG:{0}|PAWNITEMID:{1}|DESC:{2}", _
                                     RecalledItem.Tags, PawnItemID, RecalledItem.Description))
            MsgBox("FAILED TO LOAD PAWNITEMID", MsgBoxStyle.Critical)
            Exit Sub
        End If

        ' UPDATING OPI
        ds.Tables("OPI").Rows(0).Item("STATUS") = "W"
        ds.Tables("OPI").Rows(0).Item("WITHDRAWDATE") = CurrentDate
        ds.Tables("OPI").Rows(0).Item("UPDATED_AT") = Now
        database.SaveEntry(ds, False)

        Console.WriteLine(RecalledItem.Description & " is now pulled out")
    End Sub

    Friend Function TemplateIntegrityCheck(ByVal headers() As String) As Boolean
        Dim mergeHeaders As String = ""
        For Each head In headers
            mergeHeaders &= head
        Next

        'Console.WriteLine(mergeHeaders)

        If HashString(mergeHeaders) = INTEGRITY_CHECK Then
            Return True
        End If

        Return False
    End Function
End Module
