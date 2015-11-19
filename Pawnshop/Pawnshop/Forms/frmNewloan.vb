Public Class frmNewloan

    Dim Pawner As Client
    Dim PawnItem As PawnTicket, VoidPawnItem As PawnTicket
    Dim currentPawnTicket As Integer = GetLastNum()
    Dim currentOR As Integer = GetORNum()
    Dim transactionType As String, appraiser As Hashtable

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
        ComputeNetAmount()

        cboCategory.Items.Clear()
        cboCategory.Text = ""
        'Enable Grams and Karat
        If cboItemtype.SelectedItem = "JWL" Then
            txtGrams.ReadOnly = False
            cboKarat.Enabled = True
        Else
            txtGrams.ReadOnly = True
            cboKarat.Enabled = False
            txtGrams.Text = ""
            cboKarat.SelectedIndex = -1
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
        'LoanDate.Value = Date.Now
        Maturity.Value = LoanDate.Value.AddDays(29)
        If cboItemtype.SelectedItem = "CEL" Then
            Expiry.Value = Maturity.Value
            Auction.Value = LoanDate.Value.AddDays(63)
        Else
            Expiry.Value = LoanDate.Value.AddDays(89)
            Auction.Value = LoanDate.Value.AddDays(123)
        End If
    End Sub

    Private Sub LoadAppraisers()
        Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        Dim ds As DataSet = LoadSQL(mySql)

<<<<<<< HEAD
        Try
            appraisal = New Hashtable
            appraisal.Clear()
            cboAppraiser.Items.Clear()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

=======
        appraiser = New Hashtable
        cboAppraiser.Items.Clear()
>>>>>>> refs/remotes/origin/Backup
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpUser As New ComputerUser
            tmpUser.LoadUserByRow(dr)
            Console.WriteLine(tmpUser.FullName & " loaded.")

<<<<<<< HEAD
            appraisal.Add(tmpUser.UserID, tmpUser.UserName)
=======
            appraiser.Add(tmpUser.UserID, tmpUser.UserName)
>>>>>>> refs/remotes/origin/Backup
            cboAppraiser.Items.Add(tmpUser.UserName)
        Next
    End Sub

    Private Sub AddPTNumber()
        currentPawnTicket += 1
        database.UpdateOptions("PawnLastNum", CInt(currentPawnTicket))
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

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            cboKarat.Focus()
        End If
    End Sub

    Private Sub txtAppraisal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppraisal.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            txtPrincipal.Focus()
        End If
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

    Private Sub frmNewloan_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        For Each eL As DictionaryEntry In appraisal
            Console.WriteLine(eL)
        Next
    End Sub

    Private Sub frmNewloan_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F4
                Console.WriteLine("Renewal")
                'Renewal()
                SwitchTransaction("RENEW")
            Case Keys.F5
                Console.WriteLine("Redeem")
                'Redeem()
                SwitchTransaction("REDEEM")
        End Select
    End Sub

    Private Sub frmNewloan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

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
        txtGrams.Text = ""
        cboKarat.Enabled = True
        cboKarat.Text = ""

        ' Ticket Information
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(29) : Maturity.Enabled = False
        If cboItemtype.Text = "CEL" Then
            Expiry.Value = Maturity.Value : Expiry.Enabled = False
            Auction.Value = LoanDate.Value.AddDays(63) : Auction.Enabled = False
        Else
            Expiry.Value = LoanDate.Value.AddDays(89) : Expiry.Enabled = False
            Auction.Value = LoanDate.Value.AddDays(123) : Auction.Enabled = False
        End If
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

        Dim appraiser As New ComputerUser
        appraiser.LoadUser(tk.AppraiserID)
        cboAppraiser.Text = appraiser.UserName

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

                ' Disable renew
                If tk.Status = "0" Or tk.Status = "V" Or tk.Status = "W" Or tk.Status = "S" Or tk.Status = "X" Then
                    btnRenew.Enabled = False
                    btnRedeem.Enabled = False
                End If

                ' Activate Void
                If tk.Status = "L" Or tk.Status = "R" Or tk.Status = "W" Then
                    btnVoid.Enabled = True
                End If
                If tk.Status = "V" Then
                    If GetOldPT() <> Nothing Then
                        lblVOID.Text = "New Ticket: " & GetOldPT()
                        lblVOID.Visible = True
                        btnVoid.Visible = False
                    End If
                End If

                ' Activate Cancel
                If tk.Status = "X" Then
                    btnVoid.Enabled = True
                    btnVoid.Text = "CANCEL"
                End If
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
        cboKarat.SelectedIndex = -1

        ' Ticket Information
        txtTicket.Text = ""
        txtNticket.Text = ""
        LoanDate.Value = CurrentDate
        Maturity.Value = LoanDate.Value.AddDays(29)
        Expiry.Value = LoanDate.Value.AddDays(89)
        Auction.Value = LoanDate.Value.AddDays(123)
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
        'frmPawning.LoadActive()
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
        DigitOnly(e)
        If isEnter(e) Then
            txtTotal.Focus()
        End If
    End Sub

    Private Sub txtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrincipal.TextChanged
        ComputeNetAmount()
    End Sub

    Private Sub ComputeNetAmount()
        If txtPrincipal.Text = "" Then Exit Sub

        If advanceInterestNumberofMonth > 0 Then
            Dim int = GetPawnshop(30, cboItemtype.Text)

            txtTotal.Text = CDbl(txtPrincipal.Text) - (CDbl(txtPrincipal.Text) * int)
        Else
            txtTotal.Text = txtPrincipal.Text
        End If
    End Sub

    Private Function checkPayments() As Boolean
        If transactionType = "L" Then
            If CDbl(txtPrincipal.Text) > CDbl(txtAppraisal.Text) Then txtPrincipal.Focus() : Return False
            If CDbl(txtTotal.Text) > CDbl(txtPrincipal.Text) Then txtTotal.Focus() : Return False

            Return True
        End If

        Dim shouldPay As Double = CDbl(txtRedeemDue.Text)
        If CDbl(txtTotal.Text) > shouldPay Then Return False

        Return True
    End Function

    Private Function CompleteFields() As Boolean
        Dim ret As Boolean = True

        If cboItemtype.Text = "" Then cboItemtype.Focus() : ret = False
        If cboCategory.Text = "" Then cboCategory.Focus() : ret = False

        'Jewel
        If cboItemtype.Text = "JWL" Then
            If txtGrams.Text = "" Or Not checkNumeric(txtGrams) Then txtGrams.Focus() : ret = False
            If cboKarat.Text = "" Then cboKarat.Focus() : ret = False
        End If

        ' Ticket
        If txtAppraisal.Text = "" Or Not checkNumeric(txtAppraisal) Then txtAppraisal.Focus() : ret = False
        If txtPrincipal.Text = "" Or Not checkNumeric(txtPrincipal) Then txtPrincipal.Focus() : ret = False
        If txtTotal.Text = "" Then txtTotal.Focus() : ret = False

        If cboAppraiser.Text = "" Then cboAppraiser.Focus() : ret = False

        Return ret
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not mod_system.isAuthorized Then OpenAuthorization() : Exit Sub
        If Not CompleteFields() Then Exit Sub

        If Not checkPayments() Then
            MsgBox("Check payment", MsgBoxStyle.Critical, "Payment Problem")
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2)
        If ans = Windows.Forms.DialogResult.No Then
            Exit Sub
        End If


        Select Case transactionType
            Case "R"
                PawnItem.RenewTicket()
                currentOR += 1
                database.UpdateOptions("ORLastNum", CInt(currentOR))
            Case "X"
                PawnItem.RenewTicket()
                currentOR += 1
                database.UpdateOptions("ORLastNum", CInt(currentOR))
        End Select

        Dim newPawnItem As New PawnTicket
        With newPawnItem
            .PawnTicket = txtTicket.Text
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
                If CDbl(txtRenewDue.Text) - CDbl(txtTotal.Text) < 0 Then
                    Dim lessPrin As Double
                    lessPrin = Math.Abs(CDbl(txtRenewDue.Text) - CDbl(txtTotal.Text))
                    .Principal = CDbl(txtPrincipal.Text) - lessPrin
                Else
                    .Principal = txtPrincipal.Text
                End If
            ElseIf transactionType = "L" Then
                .Principal = txtPrincipal.Text
            End If
            .NetAmount = txtTotal.Text
            .AppraiserID = appraisal(cboAppraiser.Text)
            .Status = transactionType
            .AdvanceInterestPerDays = advanceInterestNumberofMonth
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
            If transactionType <> "X" Then
                AddPTNumber()
            End If
        End With

        If transactionType <> "L" Then
            MsgBox("Transaction Successful", MsgBoxStyle.Information)
            frmPawning.LoadActive()
            Me.Close()

            Exit Sub
        End If

        ans = MsgBox("Do you want to enter more?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then
            frmPawning.LoadActive()
            Me.Close()
        Else
            ClearFields()
            NewLoan()
            txtPawner.Focus()
        End If
    End Sub

    Private Sub RedeemPawnTicket()
        Dim mySql As String = "SELECT * FROM TBLPAWN WHERE pawnID = " & PawnItem.PawnID
        Dim ds As DataSet = LoadSQL(mySql, "tblPawn")
        ds.Tables("tblPawn").Rows(0).Item("Status") = "X"
        ds.Tables("tblPawn").Rows(0).Item("EncoderID") = UserID
        database.SaveEntry(ds)

        MsgBox(String.Format("Pawn Ticket: {0} redeem", PawnItem.PawnTicket), MsgBoxStyle.Information, "Thank you")
        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Sub RenewPawnTicket(ByVal id As Integer)
        Dim ds As DataSet, tbl As String = "tblPawn"
        ds = LoadSQL("SELECT * FROM TBLPAWN WHERE PawnId = " & id, "tblPawn")

        ds.Tables(tbl).Rows(0).Item("STATUS") = 0
        ds.Tables(tbl).Rows(0).Item("EncoderID") = UserID
        database.SaveEntry(ds, False)
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

<<<<<<< HEAD
=======
    Private Function GetAppraiserById(ByVal id As Integer) As String
        For Each user In appraiser
            If user.key = id Then
                Return user.value
            End If
        Next

        Return "N/A"
    End Function

>>>>>>> refs/remotes/origin/Backup
    Private Function GetAppraiserID(ByVal name As String) As Integer
        For Each user In appraiser
            Console.Write(user.value & " USER VALUE")
            If user.value = name Then
                Return user.key
            End If
        Next
        Return 999999
    End Function

    Private Sub cboCategory_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCategory.KeyPress
        If isEnter(e) Then
            txtDesc.Focus()
        End If
    End Sub

    Private Sub cboAppraiser_DropDownClosed(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAppraiser.DropDownClosed
        OpenAuthorization()
    End Sub

    Private Sub OpenAuthorization()
        If POSuser.UserName = cboAppraiser.Text Then
            mod_system.isAuthorized = True
            Exit Sub
        End If
        diagAuthorization.Show()
        diagAuthorization.fromForm = Me
        Dim tmpUser As New ComputerUser
        tmpUser.LoadUser(GetAppraiserID(cboAppraiser.Text))
        diagAuthorization.LoadUser(tmpUser)
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
        If btnRenew.Text <> "&Renew" Then
            btnRenew.Text = "&Renew"
            CancelTrans()
            transactionType = "D"
            Exit Sub
        End If
        If transactionType = "D" Then
            SwitchTransaction("RENEW")
        Else
            MsgBox("Please cancel current transaction mode", MsgBoxStyle.Information)
        End If
    End Sub

    Private Sub CancelTrans()
        LoadPawnTicket(PawnItem, "D")
        txtTotal.ReadOnly = True
    End Sub

    Private Function GetServiceCharge(ByVal principal As Double) As Double
        Dim srvPrin As Double = CDbl(txtPrincipal.Text)
        Dim ret As Double = 0

        If srvPrin < 500 Then
            ret = srvPrin * 0.01
        Else
            ret = 5
        End If

        Return ret
    End Function

    Private Function GetPenalty(ByVal principal As Double) As Double
        Dim rate As Double
        Dim diff = CurrentDate - PawnItem.LoanDate
        rate = GetPawnshop(diff.Days, PawnItem.ItemType, "Penalty")

        Return rate * principal
    End Function

    Private Function GetInterest(ByVal principal As Double) As Double
        Dim int As Double
        Dim diff = CurrentDate - PawnItem.LoanDate
        If PawnItem.OldTicket = 0 Then
            If PawnItem.AdvanceInterestPerDays > diff.Days Then
                int = 0
            Else
                If diff.Days - PawnItem.AdvanceInterestPerDays >= 9 Then
                    int = GetPawnshop(diff.Days - PawnItem.AdvanceInterestPerDays, PawnItem.ItemType)
                Else
                    int = GetPawnshop(9, PawnItem.ItemType)
                End If
            End If
        Else
            int = GetPawnshop(diff.Days, PawnItem.ItemType)
        End If

        Console.WriteLine("GetInterest")
        Console.WriteLine("Loan: " & PawnItem.LoanDate)
        Console.WriteLine("Matu: " & PawnItem.MaturityDate)
        Console.WriteLine("Date: " & CurrentDate)
        Console.WriteLine("Day: " & diff.Days + 1)
        Console.WriteLine("Int: " & int)
        Console.WriteLine("Prin: " & principal)
        Console.WriteLine("NetDue: " & int * principal)
        If advanceInterestNumberofMonth > 0 Then
            Console.WriteLine("with One Month Advance Interest")
        End If

        Return principal * int
    End Function

    Private Sub txtTotal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTotal.KeyPress
        DigitOnly(e)
        If (transactionType = "R" Or transactionType = "X") And isEnter(e) Then
            btnSave.PerformClick()
        End If
        If transactionType = "L" Then
            cboAppraiser.Focus()
        End If
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If btnRedeem.Text <> "R&edeem" Then
            btnRedeem.Text = "R&edeem"
            CancelTrans()
            transactionType = "D"
            Exit Sub
        End If
        If transactionType = "D" Then
            SwitchTransaction("REDEEM")
        Else
            MsgBox("Please cancel current transaction mode", MsgBoxStyle.Information)
        End If
    End Sub

    Friend Sub SwitchTransaction(ByVal typ As String)
        Try

        Catch ex As Exception

        End Try
        If transactionType = "L" Then Exit Sub

        'Buttons
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

        txtRefNo.Text = String.Format("{0:000000}", currentOR)
        dtpDate.Value = CurrentDate
        txtAppr.Text = PawnItem.Appraisal
        Dim diff = CurrentDate - PawnItem.MaturityDate
        If diff.Days > 0 Then
            txtOverDue.Text = diff.Days
        Else
            txtOverDue.Text = 0
        End If
        txtDelayInt.Text = GetInterest(PawnItem.Principal)
        txtPenalty.Text = GetPenalty(PawnItem.Principal)
        txtSrvChrg.Text = GetServiceCharge(PawnItem.Principal)
        txtEvat.Text = GetOption("Evat") ' No EVAT implemented

        txtRenewDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text)
        txtRedeemDue.Text = CDbl(txtDelayInt.Text) + CDbl(txtPenalty.Text) + CDbl(txtSrvChrg.Text) + CDbl(PawnItem.Principal)

        Select Case typ
            Case "REDEEM"
                'Ticket Information
                txtTicket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
                txtNticket.Text = String.Format("{0:000000}", PawnItem.OldTicket)
                LoanDate.Value = PawnItem.LoanDate
                Maturity.Value = PawnItem.MaturityDate
                Expiry.Value = PawnItem.ExpiryDate
                Auction.Value = PawnItem.AuctionDate
                txtAppraisal.Text = PawnItem.Appraisal
                txtPrincipal.Text = PawnItem.Principal

                transactionType = "X"
                btnRedeem.Text = "C&ancel"
                btnRenew.Text = "&Renew"
                txtTotal.Text = txtRedeemDue.Text ' Total
                txtTotal.ReadOnly = True
            Case "RENEW"
                'Ticket Information
                txtTicket.Text = String.Format("{0:000000}", currentPawnTicket)
                txtNticket.Text = String.Format("{0:000000}", PawnItem.PawnTicket)
                LoanDate.Value = CurrentDate
                Maturity.Value = LoanDate.Value.AddDays(29) : Maturity.Enabled = False
                If PawnItem.ItemType = "CEL" Then
                    Expiry.Value = Maturity.Value : Expiry.Enabled = False
                    Auction.Value = LoanDate.Value.AddDays(63) : Auction.Enabled = False
                Else
                    Expiry.Value = LoanDate.Value.AddDays(89) : Expiry.Enabled = False
                    Auction.Value = LoanDate.Value.AddDays(123) : Auction.Enabled = False
                End If
                txtAppraisal.Text = PawnItem.Appraisal
                txtPrincipal.Text = PawnItem.Principal

                transactionType = "R"
                btnRedeem.Text = "R&edeem"
                btnRenew.Text = "C&ancel"
                txtTotal.Text = txtRenewDue.Text ' Total
                txtTotal.ReadOnly = False
            Case Else
                Exit Sub
        End Select

        txtTotal.Focus()
        txtTotal.SelectAll()
    End Sub

#Region "Pawnshop Information"
    Friend Function GetPawnshop(ByVal day As Integer, ByVal pawnItemType As String, Optional ByVal mainType As String = "Interest") As Double
        Dim mySql As String = "SELECT * FROM tblint WHERE ItemType = '" & pawnItemType & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        day += 1 'Include the Loan Date

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim min As Integer = 0, max As Integer = 0
            min = dr.Item("DayFrom") : max = dr.Item("DayTo")

            Select Case day
                Case min To max
                    Return dr.Item(mainType)
            End Select
        Next

        MsgBox("Day " & day & " is out of bound.", MsgBoxStyle.Critical)
        Return 0
    End Function
#End Region

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        Dim ans As DialogResult = _
        MsgBox("Do you want to void this transaction?", vbCritical + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "W A R N I N G")
        Dim currentPT As Integer = PawnItem.PawnTicket

        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        If PawnItem.LoanDate <> CurrentDate.Date Then
            MsgBox("You cannot VOID in a different DATE", MsgBoxStyle.Critical)
            Exit Sub
        End If

        PawnItem.VoidCancelTicket()

        ' Wrong Pawn
        If PawnItem.Status = "L" Then
            frmPawning.LoadActive()
            Me.Close()
            Exit Sub
        End If

        PawnItem.LoadTicket(PawnItem.OldTicket, "PawnTicket")
        If PawnItem.OldTicket = Nothing Then
            PawnItem.ChangeStatus("L")
        Else
            PawnItem.ChangeStatus("R")
        End If

        'PawnItem.SaveTicket(False)
        MsgBox("PT# " & currentPT & vbCr & "Is now VOID", MsgBoxStyle.Information)

        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Function GetOldPT() As Integer
        'On Error Resume Next

        Dim pt As Integer = PawnItem.PawnTicket
        Dim ds As DataSet, mySql As String = _
            "SELECT * FROM tblPawn WHERE OldTicket = " & pt
        ds = LoadSQL(mySql)

        Dim newPT As Integer
        newPT = ds.Tables(0).Rows(0).Item("PawnTicket")

        Return newPT
    End Function

    Private Sub txtDesc_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDesc.LostFocus
        If cboItemtype.Text = "JWL" Then
            txtGrams.Focus()
        Else
            txtAppraisal.Focus()
        End If
    End Sub

<<<<<<< HEAD
=======
    Private Sub cboAppraiser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAppraiser.SelectedIndexChanged
        If POSuser.UserName = cboAppraiser.Text Then
            mod_system.isAuthorized = True
        Else
            mod_system.isAuthorized = False
        End If
    End Sub

>>>>>>> refs/remotes/origin/Backup
End Class
