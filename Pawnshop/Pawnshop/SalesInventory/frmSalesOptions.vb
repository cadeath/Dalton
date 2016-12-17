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

    Private Sub btnSaleReport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaleReport.Click
        Dim mySql As String, dsName As String, rptPath As String
        dsName = "dsSales"
        rptPath = "Reports\rpt_SalesReport.rdlc"
        mySql = "SELECT D.DOCID, "
        mySql &= "CASE D.DOCTYPE "
        mySql &= "WHEN 0 THEN 'SALES' "
        mySql &= "WHEN 1 THEN 'SALES' "
        mySql &= "WHEN 2 THEN 'RECALL' "
        mySql &= "WHEN 3 THEN 'RETURNS' "
        mySql &= "WHEN 4 THEN 'STOCKOUT' "
        mySql &= "End AS DOCTYPE, "
        mySql &= "D.MOP, D.CODE, D.CUSTOMER, D.DOCDATE, D.NOVAT, D.VATRATE, D.VATTOTAL, D.DOCTOTAL, "
        mySql &= "D.STATUS, D.REMARKS,"
        mySql &= "DL.ITEMCODE, DL.DESCRIPTION, DL.QTY, DL.UNITPRICE, DL.SALEPRICE, DL.ROWTOTAL "
        mySql &= "FROM DOC D "
        mySql &= "INNER JOIN DOCLINES DL ON DL.DOCID = D.DOCID "
        mySql &= "WHERE D.DOCDATE = '" & monCal.SelectionStart.ToShortDateString & "' AND D.STATUS <> 'V'"

        If DEV_MODE Then Console.WriteLine(mySql)
        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "DATE : " & monCal.SelectionStart.ToString("MMMM dd, yyyy"))
        addParameter.Add("branchName", branchName)
        addParameter.Add("txtUsername", POSuser.UserName)

        frmReport.ReportInit(mySql, dsName, rptPath, addParameter)
        frmReport.Show()
    End Sub
End Class