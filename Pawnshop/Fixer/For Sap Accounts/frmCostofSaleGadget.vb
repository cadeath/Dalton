Public Class frmCostofSaleGadget
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub LoadPath()
        Dim readValue = My.Computer.Registry.GetValue(
    "HKEY_LOCAL_MACHINE\Software\cdt-S0ft\Pawnshop", "InstallPath", Nothing)

        Dim firebird As String = readValue & DBPATH
        database.dbName = firebird
        txtDB.Text = firebird
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub frmCostofSaleGadget_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadPath()
    End Sub

    Private Sub btnFix_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFix.Click
        Disable(1)
        Fix()
        Disable(0)
    End Sub

    Private Sub Fix()
        Dim mysql As String = "Select * From tblCash Where Category = 'COST OF SALES' and Transname = 'Cost of Sales - Auction Redeem - Gadget'"
        Dim fillData As String = "tblCash"
        Dim ds As DataSet = LoadSQL(mysql, fillData)

        If ds.Tables(0).Rows.Count = 0 Then MsgBox("No Data to be Change", MsgBoxStyle.Critical, "Error")
            ds.Tables(0).Rows(0).Item("SapAccount") = "_SYS00000001118"
            SaveEntry(ds, False)

        MsgBox("Successfuly Fix!", MsgBoxStyle.Information, "System Data")
    End Sub
End Class