Public Class frmNewloan

    Dim Pawner As Client
    Dim PawnItem As PawnTicket
    Dim currentPawnTicket As Integer = GetLastNum()
    Dim currentOR As Integer = GetORNum()
    Dim transactionType As String

    Private Function GetORNum() As Integer
        Return GetOption("ORLastNum")
    End Function

    Private Function GetLastNum() As Integer
        Return GetOption("PawnLastNum")
    End Function

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

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtAppraisal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppraisal.TextChanged
        txtTotal.Text = txtAppraisal.Text
        txtPrincipal.Text = txtAppraisal.Text
    End Sub

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub txtless_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        DigitOnly(e)
    End Sub

    Private Sub frmNewloan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If IsNothing(Pawner) Then
            ClearFields()
            LoadAppraisers()
            NewLoan()
        End If
    End Sub

    Friend Sub NewLoan()
        transactionType = "L"
        Me.Text = "New Loan"
        lblTitle.Text = "New Loan"

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
        txtTotal.BackColor = System.Drawing.SystemColors.Window

        ' Receipt Information
        grpReceipt.Enabled = False
        txtRefNo.ReadOnly = False
        dtpDate.Value = CurrentDate
        txtAppr.ReadOnly = False
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

        btnRedeem.Enabled = False
        btnRenew.Enabled = False
    End Sub

    Friend Sub LoadPawnTicket(ByVal tk As PawnTicket, ByVal tt As String)
        transactionType = tt

        ' Pawner
        LoadPawnerInfo(tk.Pawner)
        Pawner = tk.Pawner
        btnSearch.Enabled = False

        ' Item Information
        cboItemtype.Text = tk.ItemType
        txtDesc.Text = tk.Description
        cboCategory.Text = GetCategoryByID(tk.CategoryID)
        txtGrams.Text = IIf(tk.Grams = 0, "", tk.Grams)
        cboKarat.Text = tk.Karat
        txtAppraisal.Text = tk.Appraisal
        txtPrincipal.Text = tk.Principal
        txtTotal.Text = tk.NetAmount

        ' Ticket Information
        txtTicket.Text = String.Format("{0:000000}", tk.PawnTicket)
        txtNticket.Text = IIf(tk.OldTicket = 0, String.Format("{0:000000}", 0), String.Format("{0:000000}", tk.OldTicket))
        LoanDate.Value = tk.LoanDate
        Maturity.Value = tk.MaturityDate
        Expiry.Value = tk.ExpiryDate
        Auction.Value = tk.AuctionDate
        txtAppraisal.Text = tk.Appraisal
        txtPrincipal.Text = tk.Principal

        ' Receipt Information
        txtRefNo.Text = tk.OfficialReceiptNumber
        dtpDate.Value = IIf(tk.OfficialReceiptDate = #12:00:00 AM#, dtpDate.MinDate, tk.OfficialReceiptDate)
        txtAppr.Text = tk.Appraisal
        txtOverDue.Text = tk.DaysOverDue
        txtDelayInt.Text = tk.DelayInterest
        txtPenalty.Text = tk.Penalty
        txtSrvChrg.Text = tk.ServiceCharge
        txtEvat.Text = tk.EVAT
        txtRenewDue.Text = tk.RenewDue
        txtRedeemDue.Text = tk.RedeemDue

        LoadAppraisers()
        cboAppraiser.Text = GetAppraiserById(tk.AppraiserID)

        PawnItem = tk

        Select Case tt
            Case "D" 'Display
                ' Pawner
                txtPawner.ReadOnly = True

                ' Item Information
                cboItemtype.Enabled = False
                txtDesc.ReadOnly = True
                cboCategory.Enabled = False
                txtGrams.ReadOnly = True
                cboKarat.Enabled = False

                ' Ticket Information
                Maturity.Enabled = False
                Expiry.Enabled = False
                Auction.Enabled = False
                txtAppraisal.ReadOnly = True
                txtPrincipal.ReadOnly = True

                ' Receipt Information
                grpReceipt.Enabled = False

                cboAppraiser.Enabled = False
                btnSave.Enabled = False
                btnRedeem.Visible = True
                btnRenew.Visible = True

                Dim st As String = "N/A"
                Select Case tk.Status
                    Case "0"
                        st = "Inactive"
                    Case "L"
                        st = "Active"
                    Case "X"
                        st = "Redeemed"
                    Case "R"
                        st = "Renewed"
                    Case "W"
                        st = "Withdrawed"
                    Case "S"
                        st = "Segregated"
                    Case "V"
                        st = "Void"
                End Select

                Me.Text = "Pawn Ticket Number " & tk.PawnTicket & " [" & st & "]"
                lblTitle.Text = "Display"
        End Select
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
        lblAge.Text = "-"

        ' Item Information
        txtDesc.Text = ""
        cboItemtype.SelectedIndex = -1
        cboCategory.SelectedIndex = -1
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
        txtOverDue.Text = ""
        txtDelayInt.Text = ""
        txtPenalty.Text = ""
        txtSrvChrg.Text = ""
        txtEvat.Text = ""
        txtRenewDue.Text = ""
        txtRedeemDue.Text = ""

        cboAppraiser.SelectedIndex = -1
        LoadCurrentPawnTicket()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub cboKarat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboKarat.KeyPress
        If isEnter(e) Then
            txtAppraisal.Focus()
        End If
    End Sub

    Private Sub cboKarat_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboKarat.LostFocus
        txtAppraisal.Focus()
    End Sub

    Private Sub txtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrincipal.KeyPress
        If isEnter(e) Then
            txtTotal.Focus()
        End If
    End Sub

    Private Sub txtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrincipal.TextChanged
        txtTotal.Text = txtPrincipal.Text
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtAppraisal.Text = "" Then txtAppraisal.Focus() : Exit Sub
        If txtTotal.Text = "" Then txtTotal.Focus() : Exit Sub

        If transactionType = "X" Then
            Dim netAmt As Double = CDbl(txtTotal.Text)
            Dim redeemDue As Double = CDbl(txtRedeemDue.Text)

            If netAmt < redeemDue Then
                MsgBox("Please pay the exact for REDEEM DUE", MsgBoxStyle.Critical)
                Exit Sub
            End If

            If netAmt > redeemDue Then
                Dim change As Double = redeemDue - netAmt
                Dim tmpRes As DialogResult = MsgBox("Php " & Math.Abs(change), MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Change?")
                If tmpRes = Windows.Forms.DialogResult.No Then Exit Sub
            End If

            RedeemPawnTicket()
            Exit Sub
        End If

        Dim oldPT As Integer = 0
        If transactionType = "R" Then
            oldPT = PawnItem.PawnID
        End If
        Dim ptToBeSave As New PawnTicket
        With ptToBeSave
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
            If transactionType = "R" Then
                Console.WriteLine("Less: " & CDbl(txtRenewDue.Text) - CDbl(txtTotal.Text))
                If CDbl(txtRenewDue.Text) - CDbl(txtTotal.Text) < 0 Then
                    Dim lessPrin As Double
                    lessPrin = Math.Abs(CDbl(txtRenewDue.Text) - CDbl(txtTotal.Text))
                    .Principal = CDbl(txtPrincipal.Text) - lessPrin
                End If
            Else
                .Principal = txtPrincipal.Text
            End If
            .NetAmount = txtTotal.Text
            .AppraiserID = GetAppraiserID(cboAppraiser.Text)
            .Status = transactionType
            If transactionType <> "L" Then
                .Interest = txtDelayInt.Text
                .OldTicket = txtNticket.Text
                .OfficialReceiptNumber = txtRefNo.Text
                .OfficialReceiptDate = dtpDate.Value
                .EVAT = txtEvat.Text
                .DaysOverDue = txtOverDue.Text
                .DelayInterest = txtDelayInt.Text
                .Penalty = txtPenalty.Text
                .ServiceCharge = txtSrvChrg.Text
                .RenewDue = txtRenewDue.Text
                .RedeemDue = txtRedeemDue.Text
            End If

            .SaveTicket()
            currentPawnTicket += 1
            database.UpdateOptions("PawnLastNum", CInt(currentPawnTicket))
        End With

        If transactionType = "R" Then
            PawnItem = ptToBeSave
            Dim dsInactive As DataSet = LoadSQL("SELECT * FROM TBLPAWN WHERE PawnId = " & oldPT, "TBLPAWN")
            dsInactive.Tables("tblPawn").Rows(0).Item("STATUS") = 0
            database.SaveEntry(dsInactive, False)
        End If

        MsgBox("Ticket Posted", MsgBoxStyle.Information, "Transaction Saved")
        Dim ans As DialogResult = MsgBox("Do you want to enter another one?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "Question")
        If ans = Windows.Forms.DialogResult.Yes Then
            ClearFields()
            NewLoan()
        Else
            frmPawning.LoadActive()
            Me.Close()
        End If
    End Sub

    Private Sub RedeemPawnTicket()
        Dim mySql As String = "SELECT * FROM TBLPAWN WHERE pawnID = " & PawnItem.PawnID
        Dim ds As DataSet = LoadSQL(mySql, "tblPawn")
        ds.Tables("tblPawn").Rows(0).Item("Status") = "X"
        database.SaveEntry(ds)

        MsgBox(String.Format("Pawn Ticket: {0} redeem", PawnItem.PawnTicket), MsgBoxStyle.Information, "Thank you")
        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Function GetCategoryByID(ByVal id As Integer) As String
        Dim cat() As String
        cat = {"CAMERA", "CARPENTRY TOOLS", "HOME APP-SMALL", "LAPTOP", "NOTEBOOK", _
               "BIKE", "HOME APP-BIG", "MOTORCYCLE", "CELLPHONE", "TABLET", "ANKLET", _
               "BANGLE", "BRACELET", "BROUCH", "EARRINGS", "NECKLACE", "PENDANT", "RING"}
        Return cat(id)
    End Function

    Private Function GetCategoryID(ByVal typ As String) As Integer
        ' Must be in the database
        Select Case typ
            Case "CAMERA" : Return 0
            Case "CARPENTRY TOOLS" : Return 1
            Case "HOME APP-SMALL" : Return 2
            Case "LAPTOP" : Return 3
            Case "NOTEBOOK" : Return 4
            Case "BIKE" : Return 5
            Case "HOME APP-BIG" : Return 6
            Case "MOTORCYCLE" : Return 7
            Case "CELLPHONE" : Return 8
            Case "TABLET" : Return 9
            Case "ANKLET" : Return 10
            Case "BANGLE" : Return 11
            Case "BRACELET" : Return 12
            Case "BROUCH" : Return 13
            Case "EARRINGS" : Return 14
            Case "NECKLACE" : Return 15
            Case "PENDANT" : Return 16
            Case "RING" : Return 17
            Case Else : Return 99
        End Select
    End Function

    Private Function GetAppraiserById(ByVal id As Integer) As String
        Dim app() As String
        app = {"Eskie", "Frances", "Mai2", "Jayr"}

        Return app(id)
    End Function

    Private Function GetAppraiserID(ByVal name As String) As Integer
        Select Case name
            Case "Eskie" : Return 0
            Case "Frances" : Return 1
            Case "Mai2" : Return 2
            Case "Jayr" : Return 3
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

    Private Sub cboAppraiser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAppraiser.KeyPress
        If isEnter(e) And cboAppraiser.Text <> "" Then
            AddAuthentication()
        End If
    End Sub

    Private Sub AddAuthentication()
        btnSave.PerformClick()
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        Renewal()
    End Sub

    Private Sub Renewal()
        transactionType = "R"

        'Buttons
        btnRenew.Text = "C&ancel"
        btnRedeem.Text = "R&edeem"
        btnSave.Enabled = True

        grpPawner.Enabled = False
        grpItem.Enabled = False
        grpTicket.Enabled = True
        txtTicket.ReadOnly = True
        txtNticket.ReadOnly = True
        LoanDate.Enabled = False
        Maturity.Enabled = False
        Expiry.Enabled = False
        Auction.Enabled = False
        txtAppraisal.ReadOnly = True
        txtPrincipal.ReadOnly = True
        txtTotal.ReadOnly = False

        grpReceipt.Enabled = True

        'Ticket Information
        txtTicket.Text = String.Format("{0:000000}", currentPawnTicket)
        txtNticket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(30)
        Expiry.Value = LoanDate.Value.AddDays(60)
        Auction.Value = LoanDate.Value.AddDays(90)
        txtAppraisal.Text = PawnItem.Appraisal
        txtPrincipal.Text = PawnItem.Principal

        txtRefNo.Text = String.Format("{0:000000}", currentOR)
        dtpDate.Value = CurrentDate
        txtAppr.Text = PawnItem.Appraisal
        Dim diff = CurrentDate - Maturity.Value
        If diff.Days > 0 Then
            txtOverDue.Text = diff.Days
        Else
            txtOverDue.Text = 0
        End If
        txtPenalty.Text = GetPenalty(CInt(txtOverDue.Text), PawnItem.Principal)
        txtSrvChrg.Text = GetServiceCharge(PawnItem.Principal)
        txtEvat.Text = GetOption("Evat") ' No EVAT implemented

        txtRenewDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text)
        txtRedeemDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text) + CDbl(PawnItem.Appraisal)

        txtTotal.Text = txtRenewDue.Text ' Total
        txtTotal.Focus()
        txtTotal.SelectAll()
    End Sub

    Private Function GetServiceCharge(ByVal appraisal As Double) As Double
        Return 3
    End Function

    Private Function GetPenalty(ByVal days As Integer, ByVal appraisal As Double) As Double
        Dim rate As Double
        rate = 0.02
        Return rate * appraisal
    End Function

    Private Function GetInterest(ByVal transDate As Date, ByVal appraisal As Double) As Double
        Dim int As Double
        int = 0.25

        Return appraisal * int
    End Function

    Private Sub txtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        If (transactionType = "R" Or transactionType = "X") And isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        Redeem()
    End Sub

    Private Sub Redeem()
        transactionType = "X"

        'Buttons
        btnRenew.Text = "&Renew"
        btnRedeem.Text = "C&ancel"
        btnSave.Enabled = True

        grpPawner.Enabled = False : grpItem.Enabled = False
        grpTicket.Enabled = True : txtTicket.ReadOnly = True
        txtNticket.ReadOnly = True : LoanDate.Enabled = False
        Maturity.Enabled = False : Expiry.Enabled = False
        Auction.Enabled = False : txtAppraisal.ReadOnly = True
        txtPrincipal.ReadOnly = True : txtTotal.ReadOnly = False

        grpReceipt.Enabled = True

        'Ticket Information
        txtTicket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
        LoanDate.Value = PawnItem.LoanDate
        Maturity.Value = LoanDate.Value.AddDays(30)
        Expiry.Value = LoanDate.Value.AddDays(60)
        Auction.Value = LoanDate.Value.AddDays(90)
        txtAppraisal.Text = PawnItem.Appraisal
        txtPrincipal.Text = PawnItem.Principal

        txtRefNo.Text = String.Format("{0:000000}", currentOR)
        dtpDate.Value = CurrentDate
        txtAppr.Text = PawnItem.Appraisal
        Dim diff = CurrentDate - Maturity.Value
        If diff.Days > 0 Then
            txtOverDue.Text = diff.Days
        Else
            txtOverDue.Text = 0
        End If
        txtPenalty.Text = GetPenalty(CInt(txtOverDue.Text), PawnItem.Principal)
        txtSrvChrg.Text = GetServiceCharge(PawnItem.Principal)
        txtEvat.Text = GetOption("Evat") ' No EVAT implemented

        txtRenewDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text)
        txtRedeemDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text) + CDbl(PawnItem.Principal)

        txtTotal.Text = txtRedeemDue.Text ' Total
        txtTotal.Focus()
        txtTotal.SelectAll()
    End Sub
End Class

