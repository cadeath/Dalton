Imports System.Data.Odbc

Public Class frmView_Stock

    Private Sub frmView_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub Load_ItemCode(ByVal IMD As String)
        Dim mySql As String, ds As DataSet
        mySql = String.Format("SELECT * FROM STOCK_CARD WHERE ITEMCODE = '{0}'", IMD)

        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then Exit Sub
        lblDesc.Text = ds.Tables(0).Rows(0).Item("DESCRIPTION")

        dbReaderOpen()
        lvStock.Items.Clear()
        Dim StockCard = LoadSQL_byDataReader(mySql)
        While StockCard.Read

            Dim lv As ListViewItem = lvStock.Items.Add(StockCard("DocDate"))
            lv.SubItems.Add(StockCard("RefNum"))
            lv.SubItems.Add(StockCard("ItemCode"))
            lv.SubItems.Add(StockCard("Description"))
            lv.SubItems.Add(StockCard("Qty").ToString("#,##0.00"))

        End While


        dbReaderClose()
    End Sub

End Class