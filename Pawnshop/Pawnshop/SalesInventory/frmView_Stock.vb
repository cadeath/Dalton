Imports System.Data.Odbc

Public Class frmView_Stock

    Private Sub frmView_Stock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Friend Sub Load_ItemCode(ByVal IMD As String)
        Dim mySql As String, desc As String
        mySql = String.Format("SELECT * FROM STOCK_CARD WHERE ITEMCODE = '{0}'", IMD)

        dbReaderOpen()
        lvStock.Items.Clear()
        Dim StockCard = LoadSQL_byDataReader(mySql)
        While StockCard.Read

            Dim lv As ListViewItem = lvStock.Items.Add(StockCard("DocDate"))
            lv.SubItems.Add(StockCard("RefNum"))
            lv.SubItems.Add(StockCard("ItemCode"))
            lv.SubItems.Add(StockCard("Description"))
            lv.SubItems.Add(StockCard("Qty"))

            desc = StockCard("Description")
        End While

        lblDesc.Text = desc
        dbReaderClose()
    End Sub

End Class