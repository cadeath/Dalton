Public Class frmPullOut

    Private fillData As String = "tblPawn"
    Private mySql As String = ""

    Private Sub frmPullOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadSegregated()
    End Sub

    Private Sub LoadSegregated()
        mySql = "SELECT * FROM " & fillData
        mySql &= " WHERE STATUS = 'S' ORDER BY PawnID DESC"

        Dim ds As New DataSet
        ds = LoadSQL(mySql, fillData)

        lvSeg.Items.Clear()
        For Each dr As DataRow In ds.Tables(fillData).Rows
            Dim tmpPawnItem As New PawnTicket
            tmpPawnItem.LoadTicketInRow(dr)
            AddItemSeg(tmpPawnItem)
        Next
    End Sub

    Private Sub AddItemSeg(ByVal pt As PawnTicket)
        Dim lv As ListViewItem = lvSeg.Items.Add(pt.PawnTicket)
        lv.SubItems.Add(String.Format("{0} {1}{2}", pt.Pawner.FirstName, pt.Pawner.LastName, IIf(pt.Pawner.Suffix <> "", "," & pt.Pawner.Suffix, "")))
        lv.SubItems.Add(pt.ItemType)
        lv.SubItems.Add(pt.LoanDate)
        lv.SubItems.Add(pt.AuctionDate)
    End Sub
End Class