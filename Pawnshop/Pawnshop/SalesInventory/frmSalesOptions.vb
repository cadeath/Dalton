Public Class frmSalesOptions

    Private Sub btnInventory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInventory.Click
        Dim mySql As String
        Dim SelectedDate As Date = monCal.SelectionStart.ToShortDateString

        mySql = "SELECT "
        mySql &= vbCrLf & "	ITM.ITEMCODE, ITM.DESCRIPTION, ITM.CATEGORIES, ITM.SUBCAT,"
        mySql &= vbCrLf & "	COALESCE(ITM.ONHAND - SUM(TBL.QTY),ITM.ONHAND) AS ACTUAL,"
        mySql &= vbCrLf & "    ITM.ONHAND"
        mySql &= vbCrLf & "FROM ("
        mySql &= vbCrLf & "SELECT "
        mySql &= vbCrLf & "    'IN' as TYPE, I.DOCDATE, IL.ITEMCODE, IL.QTY"
        mySql &= vbCrLf & "FROM INV I"
        mySql &= vbCrLf & "INNER JOIN INVLINES IL"
        mySql &= vbCrLf & "ON I.DOCID = IL.DOCID"
        mySql &= vbCrLf & "WHERE I.DOCDATE > '" & SelectedDate & "'"
        mySql &= vbCrLf & "UNION"
        mySql &= vbCrLf & "SELECT "
        mySql &= vbCrLf & "    'SALES' AS TYPE, D.DOCDATE, DL.ITEMCODE, DL.QTY * -1"
        mySql &= vbCrLf & "FROM DOC D"
        mySql &= vbCrLf & "INNER JOIN DOCLINES DL"
        mySql &= vbCrLf & "ON D.DOCID = DL.DOCID"
        mySql &= vbCrLf & "WHERE D.DOCDATE > '" & SelectedDate & "'"
        mySql &= vbCrLf & ") TBL"
        mySql &= vbCrLf & "RIGHT JOIN ITEMMASTER ITM"
        mySql &= vbCrLf & "ON ITM.ITEMCODE = TBL.ITEMCODE"
        mySql &= vbCrLf & "WHERE ITM.ONHAND <> 0"
        mySql &= vbCrLf & "GROUP BY "
        mySql &= vbCrLf & "	ITM.ITEMCODE, ITM.DESCRIPTION, ITM.CATEGORIES, ITM.SUBCAT, ITM.ONHAND"

        Dim dic As New Dictionary(Of String, String)
        dic.Add("txtMonthOf", SelectedDate.ToLongDateString)
        dic.Add("branchName", branchName)

        frmReport.ReportInit(mySql, "dsInventory", "Reports\rpt_InventoryPOS.rdlc", dic)
        frmReport.Show()
    End Sub

    Private Sub btnIMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIMD.Click
        frmImport_IMD.Show()
    End Sub


    Private Sub btnRePrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRePrint.Click
        frmPrint.Show()
    End Sub


    Private Sub btnSTO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSTO.Click
        frmInventory.Show()
    End Sub

    Private Sub btnPTU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPTU.Click
        frmExtractor.FormType = frmExtractor.ExtractType.PTUFile
        frmExtractor.Show()
    End Sub

End Class