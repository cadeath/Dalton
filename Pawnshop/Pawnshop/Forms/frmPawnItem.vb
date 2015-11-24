Public Class frmPawnItem

    Friend transactionType As String = "L"
    Friend PawnItem As PawnTicket

    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private PawnInfo() As Hashtable

    Private Sub frmPawnItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

#Region "GUI"
    Private Sub ClearFields()
        txtCustomer.Text = ""
        txtAddr.Text = ""
        txtBDay.Text = ""
        txtContact.Text = ""

        cboType.Text = ""
        cboCat.Text = ""
        txtDesc.Text = ""
        txtGram.Text = ""
        cboKarat.Text = ""

        txtTicket.Text = ""
        txtOldTicket.Text = ""
        txtLoan.Text = ""
        txtMatu.Text = ""
        txtExpiry.Text = ""
        txtAuction.Text = ""
        txtAppr.Text = ""
        txtPrincipal.Text = ""
        txtAdv.Text = ""
        txtNet.Text = ""

        txtReceipt.Text = ""
        txtReceiptDate.Text = ""
        txtAppr2.Text = ""
        txtOver.Text = ""
        txtPenalty.Text = ""
        txtService.Text = ""
        txtEvat.Text = ""
        txtRenew.Text = ""
        txtRedeem.Text = ""
    End Sub

    Private Sub txtAppr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppr.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrincipal.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtGram_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGram.KeyPress
        DigitOnly(e)
    End Sub
#End Region

#Region "Controller"
    Friend Sub NewLoan()
        txtCustomer.Focus()
        transactionType = "L"

        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        dateChange(cboType.Text)
    End Sub

    Private Sub dateChange(ByVal typ As String)
        Select Case typ
            Case "CEL"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = CurrentDate.AddDays(63).ToShortDateString
            Case Else
                txtExpiry.Text = CurrentDate.AddDays(89).ToShortDateString
                txtAuction.Text = CurrentDate.AddDays(123).ToShortDateString
        End Select
    End Sub

    Private Function CurrentPTNumber() As String
        Return String.Format("{0:000000}", currentPawnTicket)
    End Function

    Private Sub LoadInformation()

    End Sub

    Private Sub LoadPawnInfo()
        cboType.Items.Clear()
        cboCat.Items.Clear()
        cboKarat.Items.Clear()

        'Type
        Dim mySql As String = "SELECT DISTINCT TYPE FROM tblClass ORDER BY TYPE ASC"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim cnt As Integer = 0, classCNT As Integer = ds.Tables(0).Rows.Count
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr.Item("TYPE"))
            cnt += 1
        Next
        cboType.SelectedIndex = 0

        'Category
        cnt = 0 : mySql = "SELECT * FROM tblClass WHERE "
        For cnt = 0 To classCNT - 1
            Dim str As String = mySql & String.Format("TYPE = '{0}'", cboType.Items(cnt)) & " ORDER BY CATEGORY ASC"
            ds.Clear()
            ds = LoadSQL(str)
            Dim x As Integer = 0
            For Each dr As DataRow In ds.Tables(0).Rows
                PawnInfo(cnt).Add(x, dr.Item("Category"))
                x += 1
            Next
        Next


    End Sub
#End Region

End Class