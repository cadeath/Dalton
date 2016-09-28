Public Class dev_PT_test
    Private pawnClient As New Client

    Private ItemClass_ht As New Hashtable

    Private Sub dev_PT_test_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Load_Client()
        Load_ItemClass()
    End Sub

    Private Sub Load_ItemClass()
        Dim mySql As String = "SELECT * FROM TBLITEM"
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        ItemClass_ht.Clear()
        cboItem.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            ItemClass_ht.Add(dr("ITEMID"), dr("ITEMCLASS"))
            cboItem.Items.Add(dr("ITEMCLASS"))
        Next
    End Sub

    Private Sub Load_Client()
        Dim mySql As String = "SELECT * FROM TBLCLIENT"
        Dim ds As DataSet = LoadSQL(mySql)

        cboClient.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            cboClient.Items.Add(dr("ClientID"))
        Next
    End Sub


    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs) Handles Button1.Click
        Client_Seed.Populate()
        Load_Client()
    End Sub

    Private Sub Button2_Click(sender As System.Object, e As System.EventArgs) Handles Button2.Click
        pawnClient.LoadClient(CInt(cboClient.Text))
        Console.WriteLine(String.Format("PawnID {0} [{1}] is selected.", pawnClient.ID, pawnClient.FirstName))
    End Sub

    Private Sub Button3_Click(sender As System.Object, e As System.EventArgs) Handles Button3.Click
        ItemClass_Seed.Populate()
    End Sub
End Class