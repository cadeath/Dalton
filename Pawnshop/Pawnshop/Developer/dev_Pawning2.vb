Public Class dev_Pawning2

    Private ItemClass As Hashtable
    Private newItem As PawnItem

    Private Sub dev_Pawning2_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_ItemClass()
    End Sub

    Private Sub Load_ItemClass()
        Dim mySql As String = "SELECT * FROM TBLITEM ORDER BY ITEMID ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        ItemClass = New Hashtable
        cboType.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr("ITEMCLASS"))
            ItemClass.Add(dr("ITEMID"), dr("ITEMCLASS"))
        Next
    End Sub

    Private Sub btnCompute_Click(sender As System.Object, e As System.EventArgs) Handles btnCompute.Click
        
        DeclareItem()

    End Sub

    Private Sub DeclareItem()
        Dim selClass As New ItemClass
        selClass.LoadItem(GetIDbyName(cboType.Text, ItemClass))


        newItem = New PawnItem
        With newItem

        End With
    End Sub
End Class