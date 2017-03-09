Public Class frmFixDoclineDecimal
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub frmFixDoclineDecimal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtData.Text = firebird
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Try
            database.dbName = txtData.Text
            Doclines()

            Invlines()

            UpdateOptions("DBVersion", "1.2.3.2")

            MsgBox("Succesful Updated", MsgBoxStyle.Information, "System")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
        Disable(0)
    End Sub

    Private Sub Doclines()
        Dim DropViewStockCard As String = "DROP VIEW STOCK_CARD;"

        Dim NewUnitPrice As String = "ALTER TABLE DOCLINES ADD UNITNEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim NewSalePrice As String = "ALTER TABLE DOCLINES ADD SALENEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim NewQty As String = "ALTER TABLE DOCLINES ADD QTYNEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim NewRowTotal As String = "ALTER TABLE DOCLINES ADD ROWTOTALNEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim UpdateNew As String = "Update Doclines set UnitNew = UnitPrice, SaleNew = SalePrice, QtyNew = Qty, RowTotalNew = RowTotal where DLID <> 0"
        Dim DropUnit As String = "ALTER TABLE DOCLINES DROP UNITPRICE;"
        Dim DropSale As String = "ALTER TABLE DOCLINES DROP SALEPRICE;"
        Dim DropQty As String = "ALTER TABLE DOCLINES DROP QTY;"
        Dim DropRowTotal As String = "ALTER TABLE DOCLINES DROP ROWTOTAL;"
        Dim ChangeUnit As String = "ALTER TABLE DOCLINES ALTER COLUMN UNITNEW TO UNITPRICE;"
        Dim ChangeSale As String = "ALTER TABLE DOCLINES ALTER COLUMN SALENEW TO SALEPRICE;"
        Dim ChangeQty As String = "ALTER TABLE DOCLINES ALTER COLUMN QTYNEW TO QTY;"
        Dim ChangeRowTotal As String = "ALTER TABLE DOCLINES ALTER COLUMN ROWTOTALNEW TO ROWTOTAL;"

        Dim QtyPost As String = "ALTER TABLE DOCLINES ALTER COLUMN QTY POSITION 5;"
        Dim UnitPost As String = "ALTER TABLE DOCLINES ALTER COLUMN UNITPRICE POSITION 6;"
        Dim SalePost As String = "ALTER TABLE DOCLINES ALTER COLUMN SALEPRICE POSITION 7;"
        Dim RowTotal As String = "ALTER TABLE DOCLINES ALTER COLUMN ROWTOTAL POSITION 8;"
        Dim UomPost As String = "ALTER TABLE DOCLINES ALTER COLUMN UOM POSITION 9;"
        Dim RemarkPost As String = "ALTER TABLE DOCLINES ALTER COLUMN REMARKS POSITION 10;"

        RunCommand(DropViewStockCard)

        RunCommand(NewUnitPrice)
        RunCommand(NewSalePrice)
        RunCommand(NewQty)
        RunCommand(NewRowTotal)
        RunCommand(UpdateNew)
        RunCommand(DropUnit)
        RunCommand(DropSale)
        RunCommand(DropQty)
        RunCommand(DropRowTotal)
        RunCommand(ChangeUnit)
        RunCommand(ChangeSale)
        RunCommand(ChangeQty)
        RunCommand(ChangeRowTotal)

        RunCommand(QtyPost)
        RunCommand(UnitPost)
        RunCommand(SalePost)
        RunCommand(RowTotal)
        RunCommand(UomPost)
        RunCommand(RemarkPost)

    End Sub

    Private Sub Invlines()
        Dim NewQty As String = "ALTER TABLE INVLINES ADD NEWQTY DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim NewUnit As String = "ALTER TABLE INVLINES ADD NEWUNIT DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim NewSale As String = "ALTER TABLE INVLINES ADD NEWSALE DECIMAL(12, 6) DEFAULT '0.0';"
        Dim NewRowTotal As String = "ALTER TABLE INVLINES ADD NEWROWTOTAL DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
        Dim UpdateNewInv As String = "Update InvLines set NewUnit = UnitPrice, NewSale = SalePrice, NewQty = Qty, NewRowTotal = RowTotal where InvID <> 0"
        Dim DropQty As String = "ALTER TABLE INVLINES DROP QTY;"
        Dim DropUnit As String = "ALTER TABLE INVLINES DROP UNITPRICE;"
        Dim DropSale As String = "ALTER TABLE INVLINES DROP SALEPRICE;"
        Dim DropRowTotal As String = "ALTER TABLE INVLINES DROP ROWTOTAL;"
        Dim ChangeQty As String = "ALTER TABLE INVLINES ALTER COLUMN NEWQTY TO QTY;"
        Dim ChangeUnit As String = "ALTER TABLE INVLINES ALTER COLUMN NEWUNIT TO UNITPRICE;"
        Dim ChangeSale As String = "ALTER TABLE INVLINES ALTER COLUMN NEWSALE TO SALEPRICE;"
        Dim ChangeRowTotal As String = "ALTER TABLE INVLINES ALTER COLUMN NEWROWTOTAL TO ROWTOTAL;"

        Dim PosQty As String = "ALTER TABLE INVLINES ALTER COLUMN QTY POSITION 5;"
        Dim PostUnit As String = "ALTER TABLE INVLINES ALTER COLUMN UNITPRICE POSITION 6;"
        Dim PostSale As String = "ALTER TABLE INVLINES ALTER COLUMN SALEPRICE POSITION 7;"
        Dim PostRowTotal As String = "ALTER TABLE INVLINES ALTER COLUMN ROWTOTAL POSITION 8;"
        Dim PostUom As String = "ALTER TABLE INVLINES ALTER COLUMN UOM POSITION 9;"
        Dim PostRemark As String = "ALTER TABLE INVLINES ALTER COLUMN REMARKS POSITION 10;"


        Dim CreateViewStockCard As String = "CREATE VIEW STOCK_CARD( "
        CreateViewStockCard &= vbCrLf & "DOCTYPE, "
        CreateViewStockCard &= vbCrLf & "DOCDATE, "
        CreateViewStockCard &= vbCrLf & "REFNUM, "
        CreateViewStockCard &= vbCrLf & "ITEMCODE, "
        CreateViewStockCard &= vbCrLf & "DESCRIPTION, "
        CreateViewStockCard &= vbCrLf & "QTY, "
        CreateViewStockCard &= vbCrLf & "STATUS )"
        CreateViewStockCard &= vbCrLf & "AS SELECT "
        CreateViewStockCard &= vbCrLf & "'IN' AS DOCTYPE, I.DOCDATE, I.REFNUM, IL.ITEMCODE, IL.DESCRIPTION, IL.QTY, I.DOCSTATUS AS STATUS"
        CreateViewStockCard &= vbCrLf & "FROM INVLINES IL "
        CreateViewStockCard &= vbCrLf & "INNER JOIN INV I ON I.DOCID = IL.DOCID "
        CreateViewStockCard &= vbCrLf & "UNION "
        CreateViewStockCard &= vbCrLf & "SELECT "
        CreateViewStockCard &= vbCrLf & "( Case D.DOCTYPE "
        CreateViewStockCard &= vbCrLf & "WHEN 0 THEN 'SALES' "
        CreateViewStockCard &= vbCrLf & "WHEN 1 THEN 'SALES' "
        CreateViewStockCard &= vbCrLf & "WHEN 2 THEN 'RECALL' "
        CreateViewStockCard &= vbCrLf & "WHEN 3 THEN 'RETURNS' "
        CreateViewStockCard &= vbCrLf & "WHEN 4 THEN 'STOCKOUT' "
        CreateViewStockCard &= vbCrLf & "End "
        CreateViewStockCard &= vbCrLf & ") , D.DOCDATE, D.CODE AS REFNUM, DL.ITEMCODE, DL.DESCRIPTION, DL.QTY, D.STATUS "
        CreateViewStockCard &= vbCrLf & "FROM DOCLINES DL "
        CreateViewStockCard &= vbCrLf & "INNER JOIN DOC D ON D.DOCID = DL.DOCID "
        CreateViewStockCard &= vbCrLf & "WHERE D.STATUS <> 'V' "

        RunCommand(NewQty)
        RunCommand(NewUnit)
        RunCommand(NewSale)
        RunCommand(NewRowTotal)
        RunCommand(UpdateNewInv)
        RunCommand(DropQty)
        RunCommand(DropUnit)
        RunCommand(DropSale)
        RunCommand(DropRowTotal)
        RunCommand(ChangeQty)
        RunCommand(ChangeUnit)
        RunCommand(ChangeSale)
        RunCommand(ChangeRowTotal)

        RunCommand(PosQty)
        RunCommand(PostUnit)
        RunCommand(PostSale)
        RunCommand(PostRowTotal)
        RunCommand(PostUom)
        RunCommand(PostRemark)

        RunCommand(CreateViewStockCard)
    End Sub

    Private Sub txtData_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtData.DoubleClick
        ofdDB.ShowDialog()
        txtData.Text = ofdDB.FileName
    End Sub

End Class