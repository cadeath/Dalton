Public Class frmSalesReport

    Enum SaleReport As Integer
        Sale = 0
        Inventory = 1
        StockOut = 2
        StockIn = 3

        SalesMonthly = 4
        StockOutMonthly = 5
        StockInMonthly = 6
    End Enum
    Friend FormType As SaleReport = SaleReport.Sale

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If cboReportType.Visible Then
            Select Case cboReportType.Text
                Case "Sales Report"
                    FormType = SaleReport.SalesMonthly
                Case "StockOut Report"
                    FormType = SaleReport.StockOutMonthly
                Case "StockIn Report"
                    FormType = SaleReport.StockInMonthly

            End Select
        End If

        Select Case FormType
            Case SaleReport.Sale
                SalesReport()
            Case SaleReport.Inventory
                InventoryReport()
            Case SaleReport.StockOut
                StockOutReport()
            Case SaleReport.StockIn
                StockInReport()


            Case SaleReport.SalesMonthly

            Case SaleReport.StockOutMonthly

            Case SaleReport.StockInMonthly

        End Select
    End Sub

    Private Sub SalesReport()
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

    Private Sub InventoryReport()
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

    Private Sub frmSalesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If NoFilter() Then
            cboReportType.Visible = False
        Else
            cboReportType.Visible = True
        End If

        Select Case FormType
            Case SaleReport.Sale
                Me.Text = "Sales Report"
            Case SaleReport.Inventory
                Me.Text = "Inventory Report"
            Case SaleReport.StockOut
                Me.Text = "StockOut Report"
            Case SaleReport.StockIn
                Me.Text = "Stock In Report"
        End Select
    End Sub

    Private Sub StockOutReport()
        Dim mySql As String
        mySql = "Select D.CODE, D.CUSTOMER, DL.ITEMCODE, DL.DESCRIPTION, DL.QTY "
        mySql &= "From Doc D INNER JOIN DOCLINES DL ON DL.DOCID = D.DOCID "
        mySql &= "Where D.CODE LIKE '%STO#%' AND D.DOCDATE = '" & monCal.SelectionStart.ToShortDateString & "'"

        Dim dic As New Dictionary(Of String, String)
        dic.Add("txtMonthOf", monCal.SelectionStart.ToShortDateString)
        dic.Add("branchName", branchName)
        dic.Add("txtStock", "Stock Out Report")

        frmReport.ReportInit(mySql, "dsStockOut", "Reports\rpt_StockOutReport.rdlc", dic)
        frmReport.Show()
    End Sub

    Private Sub StockInReport()
        Dim mySql As String
        mySql = "SELECT I.REFNUM as CODE, I.PARTNER as CUSTOMER,  IL.ITEMCODE, "
        mySql &= "IL.DESCRIPTION, IL.QTY "
        mySql &= "FROM INVLINES IL INNER JOIN INV I ON I.DOCID = IL.DOCID "
        mySql &= "Where I.DOCDATE = '" & monCal.SelectionStart.ToShortDateString & "'"

        Dim dic As New Dictionary(Of String, String)
        dic.Add("txtMonthOf", monCal.SelectionStart.ToShortDateString)
        dic.Add("branchName", branchName)
        dic.Add("txtStock", "Stock In Report")

        frmReport.ReportInit(mySql, "dsStockOut", "Reports\rpt_StockOutReport.rdlc", dic)
        frmReport.Show()
    End Sub


    Private Function NoFilter() As Boolean
        Select Case FormType
            Case SaleReport.Sale
                Return True
            Case SaleReport.StockOut
                Return True
                'Case SaleReport.LayAway
                '    Return True
            Case SaleReport.Inventory
                Return True
            Case SaleReport.StockIn
                Return True
                'Case SaleReport.Forfeit
                '    Return True
                'Case SaleReport.LayawayList
                '    Return True
        End Select
        Return False
    End Function
End Class