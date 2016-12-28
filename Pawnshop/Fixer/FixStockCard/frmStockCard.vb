Public Class frmStockCard
    Const DBPATH As String = "\W3W1LH4CKU.FDB"

    Private Sub frmStockCard_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
            Dim DropViewStockCard As String = "DROP VIEW STOCK_CARD;"

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

            RunCommand(DropViewStockCard)

            RunCommand(CreateViewStockCard)

            MsgBox("Successfull", MsgBoxStyle.Information, "Fix Stock Card")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "ERROR")
            Exit Sub
        End Try
        Disable(0)
    End Sub
End Class