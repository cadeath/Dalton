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
            Dim NewUnitPrice As String = "ALTER TABLE DOCLINES ADD UNITNEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
            Dim NewSalePrice As String = "ALTER TABLE DOCLINES ADD SALENEW DECIMAL(12, 6) DEFAULT '0.0' NOT NULL;"
            Dim UpdateNew As String = "Update Doclines set UnitNew = UnitPrice, SaleNew = SalePrice where DLID <> 0"
            Dim DropUnit As String = "ALTER TABLE DOCLINES DROP UNITPRICE;"
            Dim DropSale As String = "ALTER TABLE DOCLINES DROP SALEPRICE;"
            Dim ChangeUnit As String = "ALTER TABLE DOCLINES ALTER COLUMN UNITNEW TO UNITPRICE;"
            Dim ChangeSale As String = "ALTER TABLE DOCLINES ALTER COLUMN SALENEW TO SALEPRICE;"

            RunCommand(NewUnitPrice)
            RunCommand(NewSalePrice)
            RunCommand(UpdateNew)
            RunCommand(DropUnit)
            RunCommand(DropSale)
            RunCommand(ChangeUnit)
            RunCommand(ChangeSale)

            MsgBox("Succesful Updated", MsgBoxStyle.Information, "System")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
    End Sub

End Class