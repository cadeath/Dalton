Imports Microsoft.Office.Interop

Module FileManipulation

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
            oSheet.Cells(3, 1).value = 1
            oSheet.Cells(3, 2).value = .Item("DOCDATE").ToString("yyyymmdd")
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
            oSheet.Cells(row, 5).value = dr("Quantity")
            oSheet.Cells(row, 6).value = To_WhsCode

            row += 1
        Next

        oWB.SaveAs(src)
        oSheet = Nothing
        oWB.Close(False)
        oWB = Nothing
        oXL.Quit()
        oXL = Nothing

        MsgBox("STO File Created", MsgBoxStyle.Information)
    End Sub

End Module
