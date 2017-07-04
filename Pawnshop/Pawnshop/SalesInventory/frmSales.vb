Imports Microsoft.Reporting.WinForms

Public Class frmSales

    Enum TransType As Integer
        Cash = 0
        Check = 1
        Auction = 2
        Returns = 3
        StockOut = 4
        LayAway = 5
    End Enum

    Friend TransactionMode As TransType
    Friend ht_BroughtItems As New Hashtable

    Private InvoiceNum As Double = GetOption("InvoiceNum")
    Private ReturnNum As Double = GetOption("SalesReturnNum")
    Private StockOutNum As Double = GetOption("STONum")
    Private PRINTER_PT As String = GetOption("PRINTER")
    Private VAT As Double = 0
    Private DOC_TYPE As Integer = 0 '0 - SALES, 4 - StockOut
    Private DOC_NOVAT As Double = 0
    Private DOC_VATTOTAL As Double = 0
    Private DOC_TOTAL As Double = 0

    Private canTransact As Boolean = True
    Private isLoadTrans As Boolean = False

    Private Sub frmSales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        If DEV_MODE Then Pawn.Populate()
    End Sub

    Private Sub TestConsole()
        Console.WriteLine(CurrentDate)
        Console.WriteLine(CurrentDate.ToString("yyyyMMdd"))
    End Sub

    Private Sub frmSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If DEV_MODE Then TestConsole()

        ClearField()
        txtSearch.Select()

        'VAT SETUP
        If hasVAT() Then
            lblNoVat.Visible = True
        Else
            lblNoVat.Visible = False
        End If

        CheckOR()

        'If DEV_MODE Then
        '    dev_Menu_SalesInventory.Show()
        'End If
    End Sub

    Private Sub CheckOR()
        Dim mySql As String = "SELECT * FROM DOC WHERE CODE = "
        Dim prefix As String = ""
        Dim ControlNum As Integer = 0


        Select Case TransactionMode
            Case TransType.Returns
                prefix = "RET"
                ControlNum = ReturnNum
            Case TransType.Cash, TransType.Check, TransType.Auction
                prefix = "INV"
                ControlNum = InvoiceNum
            Case TransType.StockOut
                prefix = "STO"
                ControlNum = StockOutNum
        End Select

        Dim uniq As String = String.Format("'{1}#{0:000000}'", ControlNum, prefix)
        mySql &= uniq


        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then
            canTransact = False
            MsgBox("NUMBER ALREADY EXISTED" + vbCrLf + "PLEASE BE ADVICED", MsgBoxStyle.Critical, uniq)
        End If
    End Sub

#Region "Function"
    ''' <summary>
    ''' Get the current VAT
    ''' </summary>
    ''' <returns>Boolean</returns>
    ''' <remarks></remarks>
    Private Function hasVAT() As Boolean

        'VAT = 12 / 100
        If VAT = 0 Then
            Return False
        Else
            Return True
        End If
    End Function

    Friend Sub AddItem(ByVal itm As cItemData, Optional ByVal isRedeem As Boolean = False)
        Dim ItemAmount As Double
        Dim hasSelected As Boolean = False
        Dim SMTAdd As Double = 0
        Dim isSMTrans As Boolean = False
        If itm.ItemCode = "SMT 00002" Then isLoadTrans = True

        For Each AddedItems As ListViewItem In lvSale.Items
            If isRedeem = False Then
                If AddedItems.Text = itm.ItemCode Then
                    hasSelected = True
                    Exit For
                End If
            End If
        Next


        If hasSelected Then
            With lvSale.FindItemWithText(itm.ItemCode)
                If TransactionMode = TransType.Auction Then
                    .SubItems(2).Text = 1
                Else
                    Console.WriteLine("Old Qty " & .SubItems(2).Text)
                    .SubItems(2).Text += itm.Quantity
                    Console.WriteLine("New Qty " & .SubItems(2).Text)
                End If

                If itm.ItemCode = "SMT 00071" Then
                    Dim tmp As cItemData = ht_BroughtItems.Item(itm.ItemCode)
                    tmp.SalePrice = itm.SalePrice
                    ItemAmount = .SubItems(2).Text * itm.SalePrice
                Else
                    'ItemAmount = (itm.Quantity * itm.SalePrice)
                    ItemAmount = (.SubItems(2).Text * .SubItems(3).Text)
                End If

                If TransactionMode = TransType.Auction Then
                    .SubItems(2).Text = ItemAmount
                Else
                    '.SubItems(4).Text = (ItemAmount + CDbl(.SubItems(4).Text)).ToString("#,##0.00")
                    .SubItems(4).Text = ItemAmount.ToString("#,##0.00")
                End If
            End With


        Else
            'If NEW
            Dim lv As ListViewItem = lvSale.Items.Add(itm.ItemCode)
            lv.SubItems.Add(itm.Description)
            lv.SubItems.Add(itm.Quantity)

            lv.SubItems.Add(itm.SalePrice.ToString("#,##0.00"))
            ItemAmount = (itm.SalePrice * itm.Quantity)

            lv.SubItems.Add(ItemAmount.ToString("#,##0.00"))
            lv.SubItems.Add(itm.SRP.ToString("#,##0.00"))
            lv.SubItems.Add(itm.Discount)

            If itm.ItemCode = "SMT 00056" Then
                isSMTrans = True
                Dim itm2 As New cItemData
                itm2.ItemCode = "SMT 00058"
                itm2.Load_Item()
                Dim SmtCom As SMTCompute
                SmtCom = New SMTCompute(itm.Quantity)
                itm2.Quantity = SmtCom.Commision

                With lvSale.FindItemWithText("SMT 00056")
                    .SubItems(2).Text += SmtCom.TransferFee
                    ItemAmount = (.SubItems(2).Text * .SubItems(3).Text)
                    .SubItems(4).Text = ItemAmount.ToString("#,##0.00")
                    SMTAdd = SmtCom.TransferFee
                End With

                Dim lv2 As ListViewItem = lvSale.Items.Add(itm2.ItemCode)
                lv2.SubItems.Add(itm2.Description)
                lv2.SubItems.Add(itm2.Quantity)

                lv2.SubItems.Add(itm2.SalePrice.ToString("#,##0.00"))
                ItemAmount = (itm2.SalePrice * itm2.Quantity)

                lv2.SubItems.Add(ItemAmount.ToString("#,##0.00"))
                lv2.SubItems.Add(itm2.SRP.ToString("#,##0.00"))
                lv2.SubItems.Add(itm2.Discount)

                ht_BroughtItems.Add(itm2.ItemCode, itm2)
            End If
        End If

        Dim src_idx As String = IIf(TransactionMode = TransType.Auction, itm.Tags, itm.ItemCode)

        If ht_BroughtItems.ContainsKey(src_idx) Then
            Dim tmp As cItemData = ht_BroughtItems.Item(src_idx)
            tmp.Quantity += itm.Quantity
        Else
            ht_BroughtItems.Add(src_idx, itm)
        End If

        If isSMTrans = True Then
            If ht_BroughtItems.ContainsKey(src_idx) Then
                Dim tmp As cItemData = ht_BroughtItems.Item("SMT 00056")
                tmp.Quantity += SMTAdd
            End If
            SMTAdd = 0
        End If

        DOC_TOTAL = 0
        For Each lv As ListViewItem In lvSale.Items
            DOC_TOTAL += CDbl(lv.SubItems(4).Text)
        Next

        Display_Total(DOC_TOTAL)
    End Sub

    Friend Sub ClearSearch()
        txtSearch.Text = ""
        txtSearch.Focus()
    End Sub

    Private Sub ForcePosting()
        btnPost.PerformClick()
    End Sub

    Private Sub Form_HotKeys(ByVal e As System.Windows.Forms.KeyEventArgs)
        Select Case e.KeyCode
            Case 112 'F1
                'frmIMD.Show()
            Case 113 'F2
                tsbPLU.PerformClick()
            Case 114 'F3
                tsbCustomer.PerformClick()
            Case 116 'F5
                tsbCash.PerformClick()
            Case 117 'F6
                tsbCheck.PerformClick()
            Case 120 'F9
                ForcePosting()
        End Select
    End Sub
#End Region

#Region "GUI"
    Private Sub ClearField()
        lvSale.Items.Clear()
        lblCustomer.Text = "One-Time Customer"
        txtSearch.Text = ""
        lblNoVat.Text = Display_NoVat(0)
        Display_Total(0)
        isLoadTrans = False
    End Sub

    Private Function Display_Total(ByVal tot As Double) As Double
        Dim final As Double = tot.ToString("##000.00")

        Dim TOTALVAT As Double = final * VAT
        Display_NoVat(final)
        DOC_VATTOTAL = TOTALVAT

        final += TOTALVAT
        lblTotal.Text = String.Format("Php {0:#,##0.00}", final)
        DOC_TOTAL = final

        Return final
    End Function

    Private Function Display_NoVat(ByVal tot As Double) As Double
        lblNoVat.Text = String.Format("Php {0:#,##0.00}", tot)
        DOC_NOVAT = tot

        Return tot
    End Function
#End Region

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub IS_AUCTIONREDEEM()
        If TransactionMode = TransType.Auction Then
            frmPLU.isAuctionRedeem()
            Populate3()
        End If
    End Sub


    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmPLU.Show()
        frmPLU.From_Sales()

        IS_AUCTIONREDEEM()

        If TransactionMode = TransType.StockOut Then frmPLU.isStockOut = True
        If TransactionMode = TransType.LayAway Then frmPLU.isLayAway = True
        If txtSearch.Text.Length > 0 Then frmPLU.SearchSelect(txtSearch.Text) : Exit Sub

        frmPLU.Load_PLU()
    End Sub

    Private Sub txtSearch_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSearch.KeyDown
        Form_HotKeys(e)
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then btnSearch.PerformClick()
    End Sub

    Private Sub tsbIMD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbIMD.Click
        'frmIMD.Show()
        frmImport_IMD.Show()
    End Sub

    Private Sub tsbPLU_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbPLU.Click
        If TransactionMode = TransType.LayAway Then frmPLU.isLayAway = True
        frmPLU.Show()
        frmPLU.Load_PLU()
    End Sub

    Private Sub tsbCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCustomer.Click
        Dim defaultName As String = "One-Time Customer"
        Dim promptName As String = InputBox("Customer's Name", "Customer", defaultName)

        If promptName = "" Then lblCustomer.Text = defaultName : Exit Sub
        lblCustomer.Text = promptName
    End Sub

    Private Sub lvSale_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lvSale.KeyDown
        If lvSale.SelectedItems.Count = 0 Then Exit Sub

        If e.KeyCode = Keys.Delete Then
            If TransactionMode = TransType.Auction Then Exit Sub
            Dim idx As Integer = lvSale.FocusedItem.Index
            If Not IsNumeric(lvSale.Items(idx).SubItems(2).Text) Then
                Log_Report(String.Format("[SALES DELETE] {0} have an NON-NUMERIC QTY", lvSale.Items(idx).Text))
                MsgBox(String.Format("{0} has NON-NUMERIC Quantity", lvSale.Items(idx).Text), MsgBoxStyle.Critical, "INVALID ITEMCODE")
                Exit Sub
            End If

            Console.WriteLine("Removing " & lvSale.Items(idx).Text)

            If MsgBox("Do you want remove this item?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + vbDefaultButton2, "Removing...") = vbYes Then
                Dim itm As New cItemData
                itm.ItemCode = lvSale.Items(idx).Text
                itm.Load_Item()

                If itm.ItemCode = "SMT 00071" Then
                    DOC_TOTAL -= GetEloadPrice(CDbl(lvSale.Items(idx).SubItems(2).Text)) * CDbl(lvSale.Items(idx).SubItems(2).Text)
                Else
                    DOC_TOTAL -= CDbl(lvSale.Items(idx).SubItems(3).Text) * CDbl(lvSale.Items(idx).SubItems(2).Text)
                End If
                ht_BroughtItems.Remove(itm.ItemCode)
                lvSale.Items(idx).Remove()

            Else
                Exit Sub
            End If
            Display_Total(DOC_TOTAL)
        End If


        For Each lvi As ListViewItem In lvSale.Items
            If lvi.Text.Contains("SMT 00002") Then
                isLoadTrans = True
            Else
                isLoadTrans = False
            End If

        Next
        If lvSale.Items.Count = 0 Then isLoadTrans = False

    End Sub

    Private Sub tsbCheck_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCheck.Click
        If ShiftMode() Then
            Load_asCheck()
        End If

    End Sub

    Private Sub tsbCash_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCash.Click
        If ShiftMode() Then
            Load_asCash()
        End If

    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not MsgBox("Do you want to POST?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + vbDefaultButton2, "POSTING...") = vbYes Then
            Exit Sub
        End If
        CheckOR()
        If Not canTransact Then Exit Sub

        If lvSale.Items.Count = 0 Then MsgBox("Nothing to be Post!", MsgBoxStyle.Critical, "Error") : Exit Sub

        Dim mySql As String, fillData As String
        Dim getLastID As Integer = 0
        Dim Remarks As String = ""
        Dim unsec_Customer As String = lblCustomer.Text
        Dim prefix As String = "", DocCode As String = ""
        Dim LoadWalletType As String = ""

        ' SALES RETURN
        If TransactionMode = TransType.Returns Then Remarks = InputBox("PARTICULARS", "Particulars")

        ' INVENTORY STOCK OUT
        If TransactionMode = TransType.StockOut Then
            Dim retVal(1) As String
            If frmSalesStockOut.ShowDialog(retVal) <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If

            If Not isOTPOn("Stockout") Then
                OTPStockOut_Initialization()

                diagGeneralOTP.GeneralOTP = OtpSettings
                diagGeneralOTP.TopMost = True
                diagGeneralOTP.ShowDialog()
                If Not diagGeneralOTP.isValid Then
                    Exit Sub
                End If

                Dim NewOtp As New ClassOtp("Stockout", diagOTP.txtPIN.Text)
            End If

            unsec_Customer = retVal(0) 'Branch
            Remarks = retVal(1) 'Particulars
        End If

        If isLoadTrans = True Then
            Dim LoadRetVal(0) As String
            diagLoadTrans.rbLoadWallet.Checked = True
            If diagLoadTrans.ShowLoadType(LoadRetVal) <> Windows.Forms.DialogResult.OK Then
                Exit Sub
            End If
            LoadWalletType = LoadRetVal(0)
        End If

        'Creating Document
        mySql = "SELECT * FROM DOC ROWS 1"
        fillData = "DOC"

        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim dsNewRow As DataRow
        dsNewRow = ds.Tables(fillData).NewRow

        Select Case TransactionMode
            Case TransType.Returns
                prefix = "RET"
                DocCode = String.Format("{1}#{0:000000}", ReturnNum, prefix)
            Case TransType.Cash, TransType.Check, TransType.Auction
                prefix = "INV"
                DocCode = String.Format("{1}#{0:000000}", InvoiceNum, prefix)
            Case TransType.StockOut
                prefix = "STO"
                DocCode = String.Format("{1}#{0:000000}", StockOutNum, prefix)
        End Select

        With dsNewRow
            .Item("DOCTYPE") = DOC_TYPE
            .Item("CODE") = DocCode
            .Item("MOP") = GetModesOfPayment(TransactionMode)
            .Item("CUSTOMER") = unsec_Customer
            .Item("DOCDATE") = CurrentDate
            .Item("NOVAT") = DOC_NOVAT
            .Item("VATRATE") = VAT
            .Item("VATTOTAL") = DOC_VATTOTAL
            .Item("DOCTOTAL") = DOC_TOTAL
            .Item("USERID") = POSuser.UserID
            If Remarks <> "" Then .Item("REMARKS") = Remarks
        End With
        ds.Tables(fillData).Rows.Add(dsNewRow)

        database.SaveEntry(ds)
        Dim DOCID As Integer = 0

        mySql = "SELECT * FROM DOC ORDER BY DOCID DESC ROWS 1"
        ds = LoadSQL(mySql, fillData)
        DOCID = ds.Tables(fillData).Rows(0).Item("DOCID")

        Console.Write("Loading")
        While DOCID = 0
            Application.DoEvents()
            Console.Write(".")
        End While
        Console.WriteLine()

        'Creating DocumentLines
        mySql = "SELECT * FROM DOCLINES ROWS 1"
        fillData = "DOCLINES"
        ds = LoadSQL(mySql, fillData)

        For Each ht As DictionaryEntry In ht_BroughtItems
            Dim itm As New cItemData
            itm = ht.Value

            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("DOCID") = DOCID
                .Item("ITEMCODE") = itm.ItemCode
                .Item("DESCRIPTION") = itm.Description
                .Item("QTY") = itm.Quantity * IIf(TransactionMode = TransType.Returns, -1, 1)
                .Item("UNITPRICE") = itm.UnitPrice
                .Item("SALEPRICE") = itm.SalePrice
                .Item("ROWTOTAL") = itm.SalePrice * itm.Quantity
                .Item("UOM") = itm.UnitofMeasure

                If itm.Discount = 0 Then
                    .Item("Remarks") = Nothing
                Else
                    .Item("Remarks") = "Price " & itm.SRP & " Discounted " & itm.Discount & "%"
                End If

                If itm.ItemCode = "SMT 00002" Then
                    If isLoadTrans = True Then
                        .Item("Remarks") = LoadWalletType
                    End If
                End If

            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)

            database.SaveEntry(ds)

            If itm.isInventoriable Then

                If itm.ItemCode = "SMT 00002" Then
                    Select Case LoadWalletType
                        Case "LOAD WALLET", "REMOTE LOAD"
                            If TransactionMode <> TransType.Returns Then
                                InventoryController.DeductInventory(itm.ItemCode, itm.Quantity)
                            Else
                                InventoryController.AddInventory(itm.ItemCode, itm.Quantity)
                            End If
                    End Select

                Else
                    If TransactionMode <> TransType.Returns Then
                        InventoryController.DeductInventory(itm.ItemCode, itm.Quantity)
                    Else
                        InventoryController.AddInventory(itm.ItemCode, itm.Quantity)
                    End If

                End If

            End If

            If TransactionMode = TransType.Auction Then
                ' PULLOUT IN THE INVENTORY
                InventoryController.PullOut(itm)
            End If

            ' JOURNAL ENTRY
            getLastID = GetDocLines_LastID()
            If TransactionMode <> TransType.StockOut Then
                If itm.ItemCode = "SMT 00002" Then
                    Select Case LoadWalletType
                        Case "REMOTE RECEIVE", "LOAD WALLET"
                            If TransactionMode = TransType.Returns Then
                                AddJournal(itm.SalePrice * itm.Quantity, "Debit", "Cash Offsetting Account", "SALES " & itm.ItemCode, , , "SALES OF INVENTORIABLES", "SALES RETURN", getLastID)
                                AddJournal(itm.SalePrice * itm.Quantity, "Credit", "Revolving Fund", "SALES " & itm.ItemCode, "SALES", , , "SALES RETURN", getLastID)
                            ElseIf TransactionMode = TransType.Cash OrElse TransactionMode = TransType.Check Then
                                AddJournal(itm.SalePrice * itm.Quantity, "Debit", "Revolving Fund", "SALES " & itm.ItemCode, "SALES", , , "SALES", getLastID)
                                AddJournal(itm.SalePrice * itm.Quantity, "Credit", "Cash Offsetting Account", "SALES " & itm.ItemCode, , , "SALES OF INVENTORIABLES", "SALES", getLastID)
                            End If
                    End Select
                Else
                    If TransactionMode = TransType.Returns Then
                        AddJournal(itm.SalePrice * itm.Quantity, "Debit", "Cash Offsetting Account", "SALES " & itm.ItemCode, , , "SALES OF INVENTORIABLES", "SALES RETURN", getLastID)
                        AddJournal(itm.SalePrice * itm.Quantity, "Credit", "Revolving Fund", "SALES " & itm.ItemCode, "SALES", , , "SALES RETURN", getLastID)
                    Else
                        If TransactionMode <> TransType.Auction Then
                            AddJournal(itm.SalePrice * itm.Quantity, "Debit", "Revolving Fund", "SALES " & itm.ItemCode, "SALES", , , "SALES", getLastID)
                            AddJournal(itm.SalePrice * itm.Quantity, "Credit", "Cash Offsetting Account", "SALES " & itm.ItemCode, , , "SALES OF INVENTORIABLES", "SALES", getLastID)
                        Else
                            ' JE FOR AUCTION REDEEM

                            ' SELLING PRICE
                            AddJournal(itm.SalePrice, "Debit", "Revolving Fund", "RECALL PT#" & CInt(itm.Tags).ToString("000000"), "AUCTION", , , "RECALL", getLastID)
                            AddJournal(itm.SalePrice, "Credit", itm.Get_AuctionCode, "RECALL PT#" & CInt(itm.Tags).ToString("000000"), "AUCTION", , "AUCTION REDEEM", "RECALL", getLastID)
                            ' PRINCIPAL
                            AddJournal(itm.UnitPrice, "Debit", itm.Get_CostCode, "COS-RECALL PT#" & CInt(itm.Tags).ToString("000000"), , , , "COSRECALL", getLastID)
                            AddJournal(itm.UnitPrice, "Credit", "Inventory Merchandise - Segregated", "COS-RECALL PT#" & CInt(itm.Tags).ToString("000000"), , , , "COSRECALL", getLastID)
                        End If
                    End If
                End If
            End If
        Next
        ItemPosted()

        If TransactionMode = TransType.StockOut Then
            If MsgBox("Do you want to generate STO File?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information, "STO") = _
            MsgBoxResult.Yes Then
                Dim DefaultSrc As String = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
                Dim STONUM As Integer = GetOption("STONum") - 1
                DefaultSrc &= "\" & String.Format("STO{2} {0}{1}.xlsx", BranchCode, CurrentDate.ToString("yyyyMMdd"), STONUM.ToString("000"))
                InventoryController.Export_STO(DefaultSrc, DOCID, unsec_Customer)
            End If
        End If

        If MsgBox("Do you want to print it?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + vbDefaultButton2, "PRINT") = MsgBoxResult.Yes Then
            PrintOR(DOCID)
        End If

        MsgBox("ITEM POSTED", MsgBoxStyle.Information)
        ClearField()
    End Sub

    Private Function GetDocLines_LastID() As Integer
        Dim mySql As String = "SELECT * FROM DOCLINES ORDER BY DLID DESC ROWS 1"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("DLID")
    End Function

    Private Function GetModesOfPayment(ByVal x As TransType)
        Select Case x
            Case TransType.Cash
                Return "C"
            Case TransType.Check
                Return "Q"
            Case TransType.Returns
                Return "R"
            Case TransType.StockOut
                Return "S"
        End Select

        Return "0"
    End Function

    Private Sub ItemPosted()


        Select Case TransactionMode
            Case TransType.Returns
                ReturnNum += 1 'INCREMENT Return Control Number
                UpdateOptions("SalesReturnNum", ReturnNum)
            Case TransType.Cash, TransType.Check, TransType.Auction
                InvoiceNum += 1 'INCREMENT Invoice Control Number
                UpdateOptions("InvoiceNum", InvoiceNum)
            Case TransType.StockOut
                StockOutNum += 1 'INCREMENT Stock Out Control Number
                UpdateOptions("STONum", StockOutNum)
        End Select

        ht_BroughtItems.Clear()
    End Sub

    Private Sub PrintOR(ByVal docID As Integer)
        ' Check if able to print
        Dim printerName As String = PRINTER_PT
        If Not canPrint(printerName) Then Exit Sub

        ' Execute SQL
        Dim mySql As String = "SELECT * FROM SALES_OR WHERE DOCID = " & docID
        Dim ds As DataSet, fillData As String = "OR"
        ds = LoadSQL(mySql, fillData)

        ' Declare AutoPrint
        Dim autoPrint As Reporting
        Dim report As LocalReport = New LocalReport
        autoPrint = New Reporting

        ' Initialize Auto Print
        report.ReportPath = "Reports\OfficialReceipt.rdlc"
        report.DataSources.Add(New ReportDataSource(fillData, ds.Tables(fillData)))

        ' Assign Parameters
        Dim dic As New Dictionary(Of String, String)
        With ds.Tables(0).Rows(0)
            dic.Add("txtORNum", .Item("CODE"))
            dic.Add("txtPostingDate", .Item("DOCDATE"))
            dic.Add("txtCustomer", .Item("CUSTOMER"))
        End With

        ' Importer Parameters
        If Not dic Is Nothing Then
            For Each nPara In dic
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        ' Executing Auto Print
        autoPrint.Export(report)
        autoPrint.m_currentPageIndex = 0
        autoPrint.Print(printerName)

        'frmReport.ReportInit(mySql, "OR", "Reports\OfficialReceipt.rdlc", dic)
        'frmReport.Show()
    End Sub

    Private Sub tsbRefund_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbRefund.Click
        'UNDERCONSTRUCTION()
    End Sub

    Private Sub tsbSalesReturn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbSalesReturn.Click
        If Not (POSuser.isSuperUser Or POSuser.canReturn) Then
            MsgBox("You don't have access to the Return", MsgBoxStyle.Critical, "Authorization Invalid")
            Exit Sub
        Else
            If ShiftMode() Then
                Load_asReturns()
            End If
        End If
    End Sub

    Private Function canPrint(ByVal printerName As String) As Boolean
        Try
            Dim printDocument As Drawing.Printing.PrintDocument = New Drawing.Printing.PrintDocument
            printDocument.PrinterSettings.PrinterName = printerName
            Return printDocument.PrinterSettings.IsValid
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Sub tsbReceipt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbReceipt.Click
        If TransactionMode = TransType.LayAway Then
            frmLayAwayLookUp.Show()
        Else
            frmPrint.Show()
        End If
    End Sub

    Private Sub Label1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Label1.DoubleClick
        If DEV_MODE Then
            SeedItemData.Populate()
            Console.WriteLine("ITEM POPULATED")
        End If
    End Sub

    Private Sub tsbtnAuction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnAuction.Click

        If ShiftMode() Then
            If TransactionMode <> TransType.Auction Then
                TransactionMode = TransType.Auction
                lblSearch.Text = "TICKET:"
                lblMode.Text = "RECALL"

                IS_AUCTIONREDEEM()

                DOC_TYPE = 2
            Else
                Load_asCash()
            End If
        End If
    End Sub

    Private Function GetTransName(ByVal itm As cItemData) As String
        Select Case itm.Category
            Case "JEWELRY" 'JWL
            Case "GADGET", "CAMERA" 'CEL
            Case "APPLIANCE", "BIG" 'APP BIG-APP
            Case Else
                Return ""
        End Select

        Return ""
    End Function

    Private Sub tsbtnOption_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnOption.Click
        frmSalesOptions.Show()
    End Sub

    Private Sub tsbtnOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnOut.Click
        If Not (POSuser.isSuperUser Or POSuser.canStockOut) Then
            MsgBox("You don't have access to the StockOut", MsgBoxStyle.Critical, "Authorization Invalid")
            Exit Sub
        Else
            If ShiftMode() Then
                Load_asStockOut()
            End If
        End If
    End Sub

#Region "Load Transactions Type"
    Private Sub Load_ORNUM()
        Select Case TransactionMode
            Case TransType.Returns
                ReturnNum = GetOption("SalesReturnNum")
            Case TransType.Cash, TransType.Check, TransType.Auction
                InvoiceNum = GetOption("InvoiceNum")
            Case TransType.StockOut
                StockOutNum = GetOption("STONum")
        End Select
    End Sub

    Private Sub Load_asReturns()
        lblMode.Text = "RETURNS"
        TransactionMode = TransType.Returns
        lblSearch.Text = "ITEM:"

        Load_ORNUM()
        DOC_TYPE = 3
    End Sub

    Private Sub Load_asStockOut()
        lblMode.Text = "STOCKOUT"
        TransactionMode = TransType.StockOut
        lblSearch.Text = "ITEM:"

        Load_ORNUM()
        DOC_TYPE = 4
    End Sub

    Private Sub Load_asCash()
        lblMode.Text = "CASH"
        TransactionMode = TransType.Cash
        lblSearch.Text = "ITEM:"

        Load_ORNUM()
        DOC_TYPE = 0
    End Sub

    Private Sub Load_asCheck()
        lblMode.Text = "CHECK"
        TransactionMode = TransType.Check
        lblSearch.Text = "ITEM:"

        Load_ORNUM()
        DOC_TYPE = 0
    End Sub

    Private Sub Load_asLayAway()
        lblMode.Text = "LAYAWAY"
        TransactionMode = TransType.LayAway
        lblSearch.Text = "ITEM:"
        DOC_TYPE = 0
    End Sub

    Private Function ShiftMode() As Boolean
        If lvSale.Items.Count = 0 Then Return True

        Dim ans = MsgBox("You are about the change MODE. And the List will be clear" + vbCr + "Do you want to continue?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
        If ans = MsgBoxResult.Yes Then
            ClearField()
            Return True
        End If

        Return False
    End Function
#End Region

    Private Sub tsbtnLay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbtnLay.Click
        If Not (POSuser.isSuperUser Or POSuser.canLayAway) Then
            MsgBox("You don't have access to the Layaway", MsgBoxStyle.Critical, "Authorization Invalid")
            Exit Sub
        Else
            If ShiftMode() Then
                Load_asLayAway()
            End If
        End If
    End Sub

    'Private Sub LayAwaySearch(ByVal Search As String)
    '    Try
    '    Dim mysql As String
    '    mysql = "Select * From tbllayAway Where Balance <> 0 And UPPER(ItemCode) = UPPER('" & Search & "')"
    '    Dim ds As DataSet = LoadSQL(mysql)

    '    If ds.Tables(0).Rows.Count = 0 Then
    '        mysql = "Select * From ItemMaster Where isLayAway <> '0' "
    '        If Search <> "" Then mysql &= " And UPPER(ItemCode) = UPPER('" & Search & "')"
    '        ds.Clear()
    '        ds = LoadSQL(mysql, "ItemMaster")
    '        If ds.Tables(0).Rows.Count = 0 Then MsgBox("No Item Found!", MsgBoxStyle.Information, "Lay Away") : Exit Sub

    '        With frmPLU
    '            .Show()
    '            .isLayAway = True
    '        End With

    '        If Search <> "" Then
    '            frmPLU.Load_PLU(Search)
    '        Else
    '            frmPLU.Load_PLU()
    '        End If
    '    Else
    '        frmLayAway.Show()
    '        frmLayAway.LoadExistInfo(ds.Tables(0).Rows(0).Item("LayID"))
    '    End If
    '    Catch ex As Exception
    '        MsgBox(ex.Message, MsgBoxStyle.Critical, "Error")
    '    End Try
    'End Sub

End Class