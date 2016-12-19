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

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Try
            Dim DropViewStockCard As String = "DROP VIEW STOCK_CARD;"

            Dim NewUnitPrice As String = "ALTER TABLE DOCLINES ADD UNITNEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
            Dim NewSalePrice As String = "ALTER TABLE DOCLINES ADD SALENEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
            Dim NewQty As String = "ALTER TABLE DOCLINES ADD QTYNEW DECIMAL(12, 6) NOT NULL;"
            Dim NewRowTotal As String = "ALTER TABLE DOCLINES ADD ROWTOTALNEW DECIMAL(12, 6) NOT NULL;"
            Dim UpdateNew As String = "Update Doclines set UnitNew = UnitPrice, SaleNew = SalePrice, QtyNew = Qty, RowTotalNew = RowTotal where DLID <> 0"
            Dim DropUnit As String = "ALTER TABLE DOCLINES DROP UNITPRICE;"
            Dim DropSale As String = "ALTER TABLE DOCLINES DROP SALEPRICE;"
            Dim DropQty As String = "ALTER TABLE DOCLINES DROP QTY;"
            Dim DropRowTotal As String = "ALTER TABLE DOCLINES DROP ROWTOTAL;"
            Dim ChangeUnit As String = "ALTER TABLE DOCLINES ALTER COLUMN UNITNEW TO UNITPRICE;"
            Dim ChangeSale As String = "ALTER TABLE DOCLINES ALTER COLUMN SALENEW TO SALEPRICE;"
            Dim ChangeQty As String = "ALTER TABLE DOCLINES ALTER COLUMN QTYNEW TO QTY;"
            Dim ChangeRowTotal As String = "ALTER TABLE DOCLINES ALTER COLUMN QTYNEW TO QTY;"


            Dim CreateViewStockCard As String = "CREATE VIEW STOCK_CARD( "
            CreateViewStockCard &= "DOCTYPE, "
            CreateViewStockCard &= "DOCDATE, "
            CreateViewStockCard &= "REFNUM, "
            CreateViewStockCard &= "ITEMCODE, "
            CreateViewStockCard &= "DESCRIPTION, "
            CreateViewStockCard &= "QTY )"
            CreateViewStockCard &= "AS SELECT "
            CreateViewStockCard &= "'IN' AS DOCTYPE, I.DOCDATE, I.REFNUM, IL.ITEMCODE, IL.DESCRIPTION, IL.QTY "
            CreateViewStockCard &= "FROM INVLINES IL "
            CreateViewStockCard &= "INNER JOIN INV I ON I.DOCID = IL.DOCID "
            CreateViewStockCard &= "UNION "
            CreateViewStockCard &= "SELECT "
            CreateViewStockCard &= "( Case D.DOCTYPE "
            CreateViewStockCard &= "WHEN 0 THEN 'SALES' "
            CreateViewStockCard &= "WHEN 1 THEN 'SALES' "
            CreateViewStockCard &= "WHEN 2 THEN 'RECALL' "
            CreateViewStockCard &= "WHEN 3 THEN 'RETURNS' "
            CreateViewStockCard &= "WHEN 4 THEN 'STOCKOUT' "
            CreateViewStockCard &= "End "
            CreateViewStockCard &= ") , D.DOCDATE, D.CODE AS REFNUM, DL.ITEMCODE, DL.DESCRIPTION, DL.QTY "
            CreateViewStockCard &= "FROM DOCLINES DL "
            CreateViewStockCard &= "INNER JOIN DOC D ON D.DOCID = DL.DOCID; "

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

            RunCommand(CreateViewStockCard)

            MsgBox("Succesful Updated", MsgBoxStyle.Information, "System")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
    End Sub

End Class