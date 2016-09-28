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

    Private Function GetItemClassIDByName(name As String) As Integer
        For Each i As DictionaryEntry In ItemClass_ht
            If i.Value = name Then
                Return i.Key
            End If
        Next

        Return 0
    End Function

    Private Sub Button4_Click(sender As System.Object, e As System.EventArgs) Handles Button4.Click
        Dim newItem As New PawnItem
        With newItem
            .ItemID = GetItemClassIDByName(cboItem.Text)
            .ItemClass = cboItem.Text
            .Status = "A"

            .Save_PawnItem()
        End With

        Dim lastID As Integer = newItem.Get_LastID

        Dim newPT As New PawnTicket2
        With newPT
            Randomize()
            .PawnTicket = CInt(Int((100 * Rnd()) + 1))
            .LoanDate = Now.ToShortDateString
            .MaturityDate = Now.AddDays(33)
            .ExpiryDate = Now.AddDays(93)
            .AuctionDate = Now.AddDays(123)

            .Appraisal = CInt(Int((10000 * Rnd()) + 1))
            .Principal = .Appraisal
            .NetAmount = .Appraisal
            .AppraiserID = 1
            .EncoderID = 1
            .ClaimerID = 0
            .PawnItemID = lastID

            .Save_PawnTicket()
        End With
    End Sub
End Class