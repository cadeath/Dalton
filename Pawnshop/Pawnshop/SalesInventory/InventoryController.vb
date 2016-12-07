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

    Friend Sub Export_STO(ByVal src As String, ByVal DocID As Integer, ByVal To_WhsCode As String)
        If src = "" Then Exit Sub

        ' Excel Headers
        Dim headers1() As String = {"DocEntry", "DocDate", "JournalMemo", "FromWarehouse"}
        Dim headers11() As String = {"DocEntry", "DocDate", "JrnlMemo", "Filler"}
        Dim headers2() As String = {"ParentKey", "LineNum", "ItemCode", "ItemDescription", "Quantity", "Warehouse"}
        Dim headers22() As String = {"DocNum", "LineNum", "ItemCode", "Dscription", "Quantity", "WhsCode"}

        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM DOC WHERE DOCID = " & DocID
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("Document not found", MsgBoxStyle.Critical) : Exit Sub

        Dim oXL As New Excel.Application
        If oXL Is Nothing Then
            MessageBox.Show("Excel is not properly installed!!")
            Exit Sub
        End If

        Dim oWB As Excel.Workbook
        Dim oSheet As Excel.Worksheet

        oXL = CreateObject("Excel.Application")
        oXL.Visible = False

        oWB = oXL.Workbooks.Add
        oSheet = oWB.ActiveSheet

        'Sheet 1
        Dim col As Integer = 1
        For Each hd In headers1
            oSheet.Cells(1, col).value = hd
            col += 1
        Next
        col = 1
        For Each hd In headers11
            oSheet.Cells(2, col).value = hd
            col += 1
        Next

        With ds.Tables(0).Rows(0)
            Dim dt As Date = .Item("DOCDATE")
            oSheet.Cells(3, 1).value = 1
            oSheet.Cells(3, 2).value = dt.ToString("yyyyMMdd")
            oSheet.Cells(3, 3).value = "System Generated"
            oSheet.Cells(3, 4).value = BranchCode
        End With

        'Sheet 2
        col = 1
        For Each hd In headers2
            oSheet.Cells(1, col).value = hd
            col += 1
        Next
        col = 1
        For Each hd In headers22
            oSheet.Cells(2, col).value = hd
            col += 1
        Next

        'Dim headers22() As String = {"DocNum", "LineNum", "ItemCode", "Dscription", "Quantity", "WhsCode"}
        mySql = "SELECT * FROM DOCLINES WHERE DOCID = " & DocID
        ds = LoadSQL(mySql)
        Dim row As Integer = 3
        For Each dr As DataRow In ds.Tables(0).Rows
            oSheet.Cells(row, 1).value = 1
            oSheet.Cells(row, 2).value = row - 2
            oSheet.Cells(row, 3).value = dr("ItemCode")
            oSheet.Cells(row, 4).value = dr("Description")
            oSheet.Cells(row, 5).value = dr("QTY")
            oSheet.Cells(row, 6).value = To_WhsCode

            row += 1
        Next

        oWB.SaveAs(src)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("STO File Created" + vbCrLf + "Check out your desktop", MsgBoxStyle.Information)
    End Sub
End Module
