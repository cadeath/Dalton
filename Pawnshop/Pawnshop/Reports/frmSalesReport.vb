Public Class frmSalesReport

    Enum SaleReport As Integer
        Sale = 0
        Inventory = 1
        StockOut = 2
        LayAway = 3
        SalesMonthly = 4
        StockOutMontly = 5
        LayAwayMontly = 6
    End Enum
    Friend FormType As SaleReport = SaleReport.SalesMonthly

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If cboReportType.Text = "" And cboReportType.Visible Then Exit Sub

        If cboReportType.Visible Then
            Select Case cboReportType.Text
                Case "Sales Report"
                    FormType = SaleReport.SalesMonthly
                Case "StockOut Report"
                    FormType = SaleReport.StockOutMontly
                Case "LayAway Report"
                    FormType = SaleReport.LayAwayMontly
            End Select
        End If
       
        Select Case FormType
            Case SaleReport.Sale
                SalesReport()
            Case SaleReport.SalesMonthly
                SalesReportMonthly()
            Case SaleReport.Inventory
                InventoryReport()
            Case SaleReport.StockOut
                StockOutReport()
            Case SaleReport.StockOutMontly
                StockOutMonthlyReport()
            Case SaleReport.LayAway
                LayAwayReport()
            Case SaleReport.LayAwayMontly
                LayAwayMonthlyReport()
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

    Private Sub SalesReportMonthly()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)
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
        mySql &= "WHERE D.DOCDATE BETWEEN '" & st.ToShortDateString & "' AND '" & en.ToShortDateString & "' AND D.STATUS <> 'V'"

        If DEV_MODE Then Console.WriteLine(mySql)
        Dim addParameter As New Dictionary(Of String, String)
        addParameter.Add("txtMonthOf", "FOR THE MONTH OF " + st.ToString("MMMM yyyy"))
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

    Private Function NoFilter() As Boolean
        Select Case FormType
            Case SaleReport.Sale
                Return True
            Case SaleReport.StockOut
                Return True
            Case SaleReport.LayAway
                Return True
            Case SaleReport.Inventory
                Return True
        End Select
        Return False
    End Function
        

    Private Sub frmSalesReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If NoFilter() Then
            cboReportType.Visible = False
        Else
            cboReportType.Visible = True
        End If

        Select Case FormType
            Case SaleReport.Sale, SaleReport.SalesMonthly
                Me.Text = "Sales Report"
            Case SaleReport.Inventory
                Me.Text = "Inventory Report"
            Case SaleReport.StockOut, SaleReport.StockOutMontly
                Me.Text = "StockOut Report"
            Case SaleReport.LayAway, SaleReport.LayAwayMontly
                Me.Text = "LayAway Report"
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

        frmReport.ReportInit(mySql, "dsStockOut", "Reports\rpt_StockOutReport.rdlc", dic)
        frmReport.Show()
    End Sub

    Private Sub StockOutMonthlyReport()
        Dim mySql As String
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)

        mySql = "Select D.CODE, D.CUSTOMER, DL.ITEMCODE, DL.DESCRIPTION, DL.QTY "
        mySql &= "From Doc D INNER JOIN DOCLINES DL ON DL.DOCID = D.DOCID "
        mySql &= "Where D.CODE LIKE '%STO#%' AND D.DOCDATE BETWEEN '" & st.ToShortDateString & "' AND '" & en.ToShortDateString & "' "

        Dim dic As New Dictionary(Of String, String)
        dic.Add("txtMonthOf", "FOR THE MONTH OF " + st.ToString("MMMM yyyy"))
        dic.Add("branchName", branchName)

        frmReport.ReportInit(mySql, "dsStockOut", "Reports\rpt_StockOutReport.rdlc", dic)
        frmReport.Show()
    End Sub

    Private Sub LayAwayReport()
        Dim mysql As String = "SELECT L.LAYID, L.DOCDATE, L.FORFEITDATE, "
        mysql &= "C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
        mysql &= "ITM.ITEMCODE, ITM.DESCRIPTION, L.PRICE, L.STATUS, USR.FULLNAME AS ENCODER, "
        mysql &= "LY.PAYMENTDATE, LY.CONTROLNUM, LY.AMOUNT, LY.PENALTY, LY.STATUS AS LYSTATUS, "
        mysql &= "USR2.FULLNAME AS PAYMENTENCODER "
        mysql &= "FROM TBLLAYAWAY L "
        mysql &= "INNER JOIN TBLLAYLINES LY ON LY.LAYID = L.LAYID "
        mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = L.CUSTOMERID "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = L.ITEMCODE "
        mysql &= "INNER JOIN TBL_GAMIT USR ON USR.USERID = L.ENCODER "
        mysql &= "INNER JOIN TBL_GAMIT USR2 ON USR2.USERID = LY.PAYMENTENCODER "
        mysql &= "WHERE L.STATUS = 1 AND LY.STATUS = 1 AND PAYMENTDATE = '" & monCal.SelectionStart.ToShortDateString & "'"

        Dim dic As New Dictionary(Of String, String)
        dic.Add("txtMonthOf", monCal.SelectionStart.ToShortDateString)
        dic.Add("branchName", branchName)

        frmReport.ReportInit(mysql, "dsLayAway", "Reports\rpt_layAwayReport.rdlc", dic)
        frmReport.Show()
    End Sub

    Private Sub LayAwayMonthlyReport()
        Dim st As Date = GetFirstDate(monCal.SelectionStart)
        Dim en As Date = GetLastDate(monCal.SelectionEnd)
        Dim mysql As String = "SELECT L.LAYID, L.DOCDATE, L.FORFEITDATE, "
        mysql &= "C.CLIENTID, C.FIRSTNAME || ' ' || C.LASTNAME || ' ' || C.SUFFIX AS FULLNAME, "
        mysql &= "ITM.ITEMCODE, ITM.DESCRIPTION, L.PRICE, L.STATUS, USR.FULLNAME AS ENCODER, "
        mysql &= "LY.PAYMENTDATE, LY.CONTROLNUM, LY.AMOUNT, LY.PENALTY, LY.STATUS AS LYSTATUS, "
        mysql &= "USR2.FULLNAME AS PAYMENTENCODER "
        mysql &= "FROM TBLLAYAWAY L "
        mysql &= "INNER JOIN TBLLAYLINES LY ON LY.LAYID = L.LAYID "
        mysql &= "INNER JOIN TBLCLIENT C ON C.CLIENTID = L.CUSTOMERID "
        mysql &= "INNER JOIN ITEMMASTER ITM ON ITM.ITEMCODE = L.ITEMCODE "
        mysql &= "INNER JOIN TBL_GAMIT USR ON USR.USERID = L.ENCODER "
        mysql &= "INNER JOIN TBL_GAMIT USR2 ON USR2.USERID = LY.PAYMENTENCODER "
        mysql &= "WHERE L.STATUS = 1 AND LY.STATUS = 1 AND PAYMENTDATE BETWEEN '" & st.ToShortDateString & "' AND '" & en.ToShortDateString & "'"

        Dim dic As New Dictionary(Of String, String)
        dic.Add("txtMonthOf", "FOR THE MONTH OF " + st.ToString("MMMM yyyy"))
        dic.Add("branchName", branchName)

        frmReport.ReportInit(mysql, "dsLayAway", "Reports\rpt_layAwayReport.rdlc", dic)
        frmReport.Show()
    End Sub
End Class