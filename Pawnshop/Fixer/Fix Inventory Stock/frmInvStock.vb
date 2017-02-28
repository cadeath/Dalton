Public Class frmInvStock
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub frmInvStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
        Disable(1)
        Try
            FixInventory()

            MsgBox("Succesful Updated", MsgBoxStyle.Information, "System")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "E R R O R")
        End Try
        Disable(0)
    End Sub

    Private Sub Disable(ByVal st As Boolean)
        btnFix.Enabled = Not st
    End Sub

    Private Sub FixInventory()
        Dim fix As String = "Select * From ITEMMASTER "
        fix &= "Where onHand >= 2 And "
        fix &= "ItemCode Not Like '%SMT%' "
        fix &= "And ItemCode Not Like '%IND%' "
        Dim fillFix As String = "ItemMaster"
        Dim fixDs As DataSet = LoadSQL(fix, fillFix)

        For Each dr In fixDs.Tables(0).Rows

            Dim mysql As String = "Select * From ItemMaster Where ItemCode = '" & dr.item("ItemCode") & "'"
            Dim filldata As String = "ItemMaster"
            Dim ds As DataSet = LoadSQL(mysql, filldata)
            ds.Tables(filldata).Rows(0).Item("onHand") = 1
            SaveEntry(ds, False)

            Dim dsNewRow As DataRow
            mySql = "SELECT * FROM DOCLINES ROWS 1"
            fillData = "DOCLINES"
            ds = LoadSQL(mySql, fillData)
            dsNewRow = ds.Tables(fillData).NewRow
            With dsNewRow
                .Item("DOCID") = 569
                .Item("ITEMCODE") = dr.item("ItemCode")
                .Item("DESCRIPTION") = dr.item("Description")
                .Item("QTY") = 1
            End With
            ds.Tables(fillData).Rows.Add(dsNewRow)
            database.SaveEntry(ds)
        Next
    End Sub

End Class