Public Class dev_Pawning2

    Private ItemClass As Hashtable
    Private newPawnTicket As PawnTicket2
    Private newItem As PawnItem
    Private AutoCompute As PawnCompute

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
        If Not DeclareItem() Then Exit Sub

        With AutoCompute
            txtNetAmount.Text = .NetAmount
            txtDaysOver.Text = .DaysOverDue
            txtInt.Text = .Interest
            txtPenalty.Text = .Penalty
            txtSC.Text = .ServiceCharge
            txtAdvInt.Text = .AdvanceInterest
            txtRenewDue.Text = .RenewDue
            txtRedeemDue.Text = .RedeemDue
        End With

    End Sub

    Private Function DeclareItem() As Boolean
        If cboType.Text = "" Then Return False
        If txtPrincipal.Text = "" Then Return False

        Dim isDPJ As Boolean
        isDPJ = rbDPJ.Checked

        Dim intS As New InterestScheme
        intS.LoadScheme(GetSchemeID(cboType.Text))

        txtMatu.Text = loanDate.SelectionRange.Start.AddDays(29).ToShortDateString
        Select Case cboType.Text
            Case "CELLPHONE"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = loanDate.SelectionRange.Start.AddDays(62).ToShortDateString
            Case Else
                txtExpiry.Text = loanDate.SelectionRange.Start.AddDays(119).ToShortDateString
                txtAuction.Text = loanDate.SelectionRange.Start.AddDays(152).ToShortDateString
        End Select

        AutoCompute = New PawnCompute _
            (txtPrincipal.Text, intS, current.SelectionRange.Start, DateTime.Parse(txtMatu.Text), isDPJ)

        Return True
    End Function

    Private Sub txtMatu_DoubleClick(sender As Object, e As System.EventArgs) Handles txtMatu.DoubleClick
        dev_Pawning.Show()
    End Sub

    Private Function GetSchemeID(ByVal Item As String)
        Dim mysql As String = "Select * from tblItem Where ItemClass = '" & Item & "'"
        Dim fillData As String = "tblItem"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        If ds.Tables(0).Rows.Count = 0 Then
            Return 0
        End If
        Return ds.Tables(0).Rows(0).Item("Scheme_ID")
    End Function
End Class