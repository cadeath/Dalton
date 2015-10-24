Public Class frmNewloan

    Dim Pawner As Client
    Dim currentPawnTicket As Integer = 10026
    Dim transactionType As String

    Private Sub LoadItemType()
        Dim itmType As String() = {"JWL", "APP", "BIG", "CEL"}
        cboItemtype.Items.Clear()
        cboItemtype.Items.AddRange(itmType)
    End Sub

    Private Sub ItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemtype.SelectedIndexChanged
        cboCategory.Items.Clear()
        cboCategory.Text = ""
        'Enable Grams and Karat
        If cboItemtype.SelectedItem = "JWL" Then
            txtGrams.ReadOnly = False
            cboKarat.Enabled = True
        Else
            txtGrams.ReadOnly = True
            cboKarat.Enabled = False
        End If
        'Sub Category
        If cboItemtype.SelectedItem = "APP" Then
            cboCategory.Items.Add("CAMERA")
            cboCategory.Items.Add("CARPENTRY TOOLS")
            cboCategory.Items.Add("HOME APP-SMALL")
            cboCategory.Items.Add("LAPTOP")
            cboCategory.Items.Add("NOTEBOOK")

        ElseIf cboItemtype.SelectedItem = "BIG" Then
            cboCategory.Items.Add("BIKE")
            cboCategory.Items.Add("HOME APP-BIG")
            cboCategory.Items.Add("MOTORCYCLE")

        ElseIf cboItemtype.SelectedItem = "CEL" Then
            cboCategory.Items.Add("CELLPHONE")
            cboCategory.Items.Add("TABLET")

        ElseIf cboItemtype.SelectedItem = "JWL" Then
            cboCategory.Items.Add("ANKLET")
            cboCategory.Items.Add("BANGLE")
            cboCategory.Items.Add("BRACELET")
            cboCategory.Items.Add("BROUCH")
            cboCategory.Items.Add("EARRINGS")
            cboCategory.Items.Add("NECKLACE")
            cboCategory.Items.Add("PENDANT")
            cboCategory.Items.Add("RING")
        End If

        'Dates
        LoanDate.Value = Date.Now
        Maturity.Value = LoanDate.Value.AddDays(30)
        If cboItemtype.SelectedItem = "CEL" Then
            Expiry.Value = LoanDate.Value.AddDays(30)
            Auction.Value = LoanDate.Value.AddDays(63)
        Else
            Expiry.Value = LoanDate.Value.AddDays(90)
            Auction.Value = LoanDate.Value.AddDays(123)
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppraisal.KeyPress
        DigitOnly(e)
    End Sub


    Private Sub LoadAppraisers()
        Dim users() As String = {"Eskie", "Frances", "Mai2", "Jayr"}
        cboAppraiser.Items.Clear()
        cboAppraiser.Items.AddRange(users)
    End Sub

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtPawner.Text, FormName.frmPawning)
        frmClient.Show()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLoanlist.Show()
    End Sub

    ''' <summary>
    ''' Identify if the KeyPress is enter
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <returns>Boolean</returns>
    Private Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
    Private Sub txtDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.KeyPress
        If isEnter(e) Then
            cboItemtype.Focus()
        End If
    End Sub

    Private Sub Maturity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Maturity.ValueChanged

    End Sub

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtAppraisal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppraisal.TextChanged
        txtTotal.Text = txtAppraisal.Text
        txtPrincipal.Text = txtAppraisal.Text
    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged

    End Sub

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub


    Private Sub btnLess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLess.Click
        lblLess.Visible = True
        txtLess.Visible = True
        txtLess.ReadOnly = False
        btnLess.Enabled = False
    End Sub

    Private Sub txtless_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLess.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub frmNewloan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadAppraisers()
        NewLoan()
    End Sub

    Friend Sub NewLoan()
        transactionType = "L"

        ' Pawner
        txtPawner.ReadOnly = False
        txtPawner.Focus()

        ' Item Information
        cboItemtype.Enabled = True
        txtDesc.ReadOnly = False
        cboCategory.Enabled = True
        txtGrams.ReadOnly = False
        cboKarat.Enabled = True

        ' Ticket Information
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(30) : Maturity.Enabled = False
        Expiry.Value = LoanDate.Value.AddDays(60) : Expiry.Enabled = False
        Auction.Value = LoanDate.Value.AddDays(90) : Auction.Enabled = False
        txtAppraisal.ReadOnly = False
        txtPrincipal.ReadOnly = False
        txtTotal.ReadOnly = False

        ' Receipt Information
        grpReceipt.Enabled = False
        txtRefNo.ReadOnly = False
        dtpDate.Value = CurrentDate
        txtAppr.ReadOnly = False
        txtLess.ReadOnly = False
        txtOverDue.ReadOnly = False
        txtDelayInt.ReadOnly = False
        txtPenalty.ReadOnly = False
        txtSrvChrg.ReadOnly = False
        txtEvat.ReadOnly = False
        txtRenewDue.ReadOnly = False
        txtRedeemDue.ReadOnly = False

        cboAppraiser.Text = ""
        cboAppraiser.Enabled = True

        LoadCurrentPawnTicket()
    End Sub

    Friend Sub LoadPawnerInfo(ByVal cl As Client)
        txtPawner.Text = String.Format("{0} {1} {2} {3}", cl.FirstName, cl.MiddleName, cl.LastName, cl.Suffix)
        txtAddress.Text = String.Format("{0} {1} {2}, {3}" & vbCrLf & "{4}", cl.AddressSt, cl.AddressBrgy, cl.AddressProvince, cl.AddressCity, cl.ZipCode)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        lblAge.Text = GetCurrentAge(DateTime.Parse(txtBDay.Text)) & " years old"
        txtPhone.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "") & IIf(cl.Telephone <> "", ", " & cl.Telephone, "")

        cboItemtype.Focus()
        Pawner = cl
    End Sub

    Private Sub LoadCurrentPawnTicket()
        txtTicket.Text = String.Format("{0:000000}", currentPawnTicket)
    End Sub

    Private Sub ClearFields()
        ' Pawner
        txtPawner.Text = ""
        txtAddress.Text = ""
        txtBDay.Text = ""
        txtPhone.Text = ""

        ' Item Information
        txtDesc.Text = ""
        cboItemtype.Text = ""
        ' Jewel
        txtGrams.Text = ""
        cboKarat.Text = ""

        ' Ticket Information
        txtTicket.Text = ""
        txtNticket.Text = ""
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(30)
        Expiry.Value = LoanDate.Value.AddDays(60)
        Auction.Value = LoanDate.Value.AddDays(90)
        txtAppraisal.Text = ""
        txtPrincipal.Text = ""
        txtTotal.Text = ""

        ' Receipt Information
        txtRefNo.Text = ""
        dtpDate.Value = CurrentDate
        txtAppr.Text = ""
        txtLess.Text = ""
        txtOverDue.Text = ""
        txtDelayInt.Text = ""
        txtPenalty.Text = ""
        txtSrvChrg.Text = ""
        txtEvat.Text = ""
        txtRenewDue.Text = ""
        txtRedeemDue.Text = ""

        cboAppraiser.Text = ""
        cboAppraiser.Items.Clear()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtPawner_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPawner.TextChanged

    End Sub

    Private Sub cboKarat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboKarat.KeyPress
        If isEnter(e) Then
            txtAppraisal.Focus()
        End If
    End Sub

    Private Sub cboKarat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboKarat.LostFocus
        txtAppraisal.Focus()
    End Sub

    Private Sub txtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrincipal.TextChanged
        txtTotal.Text = txtPrincipal.Text
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim tmpPawnTicket As New PawnTicket
        With tmpPawnTicket
            .PawnTicket = txtTicket.Text
            .Pawner = Pawner
            .LoanDate = LoanDate.Value
            .MaturityDate = Maturity.Value
            .ExpiryDate = Expiry.Value
            .AuctionDate = Auction.Value
            .ItemType = cboItemtype.Text
            .CategoryID = GetCategoryID(cboCategory.Text)
            .Description = txtDesc.Text
            If cboItemtype.Text = "JWL" Then
                .Karat = cboKarat.Text
                .Grams = txtGrams.Text
            End If
            .Appraisal = txtAppraisal.Text
            .Principal = txtPrincipal.Text
            .NetAmount = txtTotal.Text
            .AppraiserID = GetAppraiserID(cboAppraiser.Text)
            .Status = transactionType
            If transactionType <> "A" Then
                .Interest = txtDelayInt.Text
                .NewTicket = txtNticket.Text
                .OfficialReceiptNumber = txtRefNo.Text
                .OfficialReceiptDate = dtpDate.Value
                .LessPrincipal = txtLess.Text
                .EVAT = txtEvat.Text
                .DaysOverDue = txtOverDue.Text
                .DelayInterest = txtDelayInt.Text
                .Penalty = txtPenalty.Text
                .ServiceCharge = txtSrvChrg.Text
                .RenewDue = txtRenewDue.Text
                .RedeemDue = txtRedeemDue.Text
            End If

            .SaveTicket()
        End With
    End Sub

    Private Function GetCategoryID(ByVal typ As String) As Integer
        ' Must be in the database
        Select Case typ
            Case "CAMERA"
                Return 0
            Case "CARPENTRY TOOLS"
                Return 1
            Case "HOME APP-SMALL"
                Return 2
            Case "LAPTOP"
                Return 3
            Case "NOTEBOOK"
                Return 4
            Case "BIKE"
                Return 5
            Case "HOME APP-BIG"
                Return 6
            Case "MOTORCYCLE"
                Return 7
            Case "CELLPHONE"
                Return 8
            Case "TABLET"
                Return 9
            Case "ANKLET"
                Return 10
            Case "BANGLE"
                Return 11
            Case "BROUCH"
                Return 12
            Case "EARRINGS"
                Return 13
            Case "NECKLASE"
                Return 14
            Case "PENDANT"
                Return 15
            Case "RING"
                Return 16
            Case Else
                Return 99
        End Select
    End Function

    Private Function GetAppraiserID(ByVal name As String) As Integer
        Select Case name
            Case "Eskie"
                Return 0
            Case "Frances"
                Return 1
            Case "Mai2"
                Return 2
            Case "Jayr"
                Return 3
            Case Else
                Return 99
        End Select
    End Function

    Private Sub cboCategory_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboCategory.LostFocus
        If cboItemtype.Text = "JWL" Then
            txtGrams.Focus()
        Else
            txtAppraisal.Focus()
        End If
    End Sub
End Class

