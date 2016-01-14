Imports Microsoft.Reporting.WinForms

Public Class frmPawnItem
    'Version 2.3
    ' - Add Printing
    'Version 2.2
    ' - Remake SAVE
    'Version 2.1
    ' - Fixing Auth
    ' - Fixing GUI

    ' Functions
    ' LoadPawnTicket(PawnTicket,Status)
    ' Status = Transaction Type

    Friend transactionType As String = "L"
    Friend PawnItem As PawnTicket
    Friend PawnCustomer As Client

    Private PawnInfo() As Hashtable
    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private currentORNumber As Integer = GetOption("ORLastNum")
    Private TypeInt As Double, bug As Boolean = False
    Private daysDue As Integer

    Private appraiser As Hashtable
    Private isOldItem As Boolean = False
    Private AdvanceInterest As Double, DelayInt As Double, ServiceCharge As Double
    Private ItemPrincipal As Double, Penalty As Double

    Const ITEM_REDEEM As String = "REDEEM"
    Const ITEM_NEWLOAN As String = "NEW LOAN"
    Const ITEM_RENEW As String = "RENEW"


    Private Sub frmPawnItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadInformation()
        LoadAppraisers()
        If transactionType = "L" Then NewLoan()
    End Sub

  #Region "GUI"
    Private Sub ClearFields()
        mod_system.isAuthorized = False

        txtCustomer.Text = ""
        txtAddr.Text = ""
        txtBDay.Text = ""
        txtContact.Text = ""

        cboType.Text = ""
        cboCat.Text = ""
        txtDesc.Text = ""
        txtGram.Text = ""
        'cboKarat.Text = ""

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
        txtPrincipal2.Text = ""
        txtOver.Text = ""
        txtPenalty.Text = ""
        txtService.Text = ""
        txtEvat.Text = ""
        txtRenew.Text = ""
        txtRedeem.Text = ""
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        Dim transDate As Date
        If PawnItem.Status = "X" Then
            transDate = PawnItem.OfficialReceiptDate
        Else
            transDate = PawnItem.LoanDate
        End If

        If CurrentDate.Date <> transDate Then
            MsgBox("Unable to void transaction NOT on the same date.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If lblNPT.Visible Then MsgBox("Inactive Transaction", MsgBoxStyle.Critical) : Exit Sub

        PawnItem.VoidCancelTicket()
        MsgBox("Transaction Voided", MsgBoxStyle.Information)
        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Sub txtAppr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppr.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            txtPrincipal.Focus()
        End If
    End Sub

    Private Sub txtPrincipal_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrincipal.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            If transactionType <> "L" Then
                txtNet.Focus()
            Else
                cboAppraiser.Focus()
            End If
        End If
    End Sub

    Private Sub txtGram_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGram.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            If cboType.Text = "JWL" Then
                cboKarat.Focus()
            Else
                txtAppr.Focus()
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Sub cboType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboType.KeyPress
        If isEnter(e) Then
            cboCat.Focus()
        End If
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        On Error Resume Next

        Dim idx As Integer = cboType.SelectedIndex
        Console.WriteLine("Selected Type: " & idx)
        cboCat.Items.Clear()
        For Each dStr As DictionaryEntry In PawnInfo(idx)
            cboCat.Items.Add(dStr.Value)
        Next
        cboCat.SelectedIndex = 0

        'for JWL
        If cboType.Text = "JWL" Then
            txtGram.ReadOnly = False
            cboKarat.Enabled = True
        Else
            txtGram.ReadOnly = True
            cboKarat.Enabled = False
        End If

        dateChange(cboType.Text)
    End Sub

    Private Sub cboAppraiser_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboAppraiser.KeyPress
        If isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub cboAppraiser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAppraiser.LostFocus
        CheckAuth()
    End Sub

    Private Sub cboAppraiser_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAppraiser.SelectedIndexChanged
        If POSuser.UserName = cboAppraiser.Text Then
            lblAuth.Text = "Verified"
            mod_system.isAuthorized = True
        Else
            mod_system.isAuthorized = False
            lblAuth.Text = "Unverified"

            Exit Sub
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtCustomer.Text, FormName.frmPawnItem)
        frmClient.Show()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Not CheckAuth() Then Exit Sub

        If Not isReady() And transactionType = "L" Then
            MsgBox("I think you are missing something", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Select Case transactionType
            Case "L" : SaveNewLoan() : PrintNewLoan()
            Case "X" : SaveRedeem() : PrintRedeemOR()
            Case "R" : SaveRenew()
        End Select

        MsgBox("Item Posted!", MsgBoxStyle.Information)
        If transactionType = "R" Then
            frmPawning.LoadActive()
            Me.Close()
            Exit Sub
        End If

        If transactionType <> "X" Then AddPTNum()
        If transactionType = "X" Then
            AddORNum()
            frmPawning.LoadActive()
            Me.Close()
            Exit Sub
        End If


        ans = MsgBox("Do you want to enter another one?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2)
        If ans = Windows.Forms.DialogResult.No Then
            frmPawning.LoadActive()

            Me.Close()
            Exit Sub
        End If

        cboAppraiser.Text = ""
        txtCustomer.Focus()
        ClearFields()
        NewLoan()
    End Sub

    Private Sub AddPTNum()
        currentPawnTicket += 1
        UpdateOptions("PawnLastNum", currentPawnTicket)
    End Sub

    Private Sub AddORNum()
        currentORNumber += 1
        UpdateOptions("ORLastNum", currentORNumber)
    End Sub

    Private Sub tmrVerifier_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrVerifier.Tick
        If mod_system.isAuthorized Then
            lblAuth.Text = "Verified"
        Else
            lblAuth.Text = "Unverified"
        End If
    End Sub

    Private Sub txtCustomer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCustomer.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub cboCat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboCat.KeyPress
        If isEnter(e) Then
            txtDesc.Focus()
        End If
    End Sub

    Private Sub txtNet_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNet.KeyPress
        DigitOnly(e)
        If isEnter(e) And transactionType = "L" Then
            cboAppraiser.Focus()
        End If
        If transactionType = "X" Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub txtPrincipal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrincipal.KeyUp
        On Error Resume Next

        LoanAdvanceInterest()
        txtPrincipal2.Text = txtPrincipal.Text
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If transactionType = "X" Then
            btnRedeem.Text = "&Redeem"
            txtRedeem.BackColor = Drawing.SystemColors.Control
            transactionType = "D"
            btnVoid.Enabled = True
            btnSave.Enabled = False

            LoadPawnTicket(PawnItem, "D")
            Exit Sub
        End If
        If transactionType <> "D" Then
            MsgBox("Please press cancel to switch transaction mode", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Redeem()
        btnSave.Enabled = True
        btnRedeem.Text = "&Cancel"
        btnVoid.Enabled = False
    End Sub

    Private Sub txtRedeem_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRedeem.KeyPress
        If isEnter(e) And transactionType = "X" Then
            btnSave.PerformClick()
        End If
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        If transactionType = "R" Then
            btnRenew.Text = "Rene&w"
            txtRenew.BackColor = Drawing.SystemColors.Control
            transactionType = "D"
            btnVoid.Enabled = True
            btnSave.Enabled = False

            LoadPawnTicket(PawnItem, "D")
            Exit Sub
        End If
        If transactionType <> "D" Then
            MsgBox("Please press cancel to switch transaction mode", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Redeem("R")
        btnSave.Enabled = True
        btnRenew.Text = "&Cancel"
        btnVoid.Enabled = False
    End Sub

    Private Sub txtRenew_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRenew.KeyPress
        DigitOnly(e)
        If transactionType = "R" And isEnter(e) Then
            btnSave.PerformClick()
        End If
    End Sub
#End Region

#Region "Controller"

    Private Sub SaveRedeem()
        With PawnItem
            .OfficialReceiptNumber = currentORNumber
            .OfficialReceiptDate = CurrentDate

            .DaysOverDue = txtOver.Text
            .Interest = txtInt.Text
            .Penalty = txtPenalty.Text
            .ServiceCharge = txtService.Text
            .EVAT = txtEvat.Text
            .RedeemDue = txtRedeem.Text
            .Status = transactionType

            .SaveTicket(False)

            If isOldItem Then
                AddJournal(.RedeemDue, "Debit", "Revolving Fund", "PT# " & .PawnTicket, ITEM_REDEEM)
                AddJournal(.Principal, "Credit", "Inventory Merchandise - Loan", "PT# " & .PawnTicket)
                AddJournal(.Interest, "Credit", "Interest on Loans", "PT# " & .PawnTicket)
                AddJournal(.Penalty, "Credit", "Interest on Loans", "PT# " & .PawnTicket)
                AddJournal(.ServiceCharge, "Credit", "Loans Service Charge", "PT# " & .PawnTicket)
            Else
                AddJournal(.RedeemDue, "Debit", "Revolving Fund", "PT# " & .PawnTicket, ITEM_REDEEM)
                AddJournal(.Principal, "Credit", "Inventory Merchandise - Loan", "PT# " & .PawnTicket)
                If daysDue > 3 Then
                    AddJournal(.Interest, "Credit", "Interest on Loans", "PT# " & .PawnTicket)
                    AddJournal(.Penalty, "Credit", "Interest on Loans", "PT# " & .PawnTicket)
                End If
            End If
        End With
    End Sub

    Private Sub ComputeInterests()
        If Not IsNumeric(txtPrincipal.Text) Then Exit Sub
        ItemPrincipal = CDbl(txtPrincipal.Text)

        AdvanceInterest = ItemPrincipal * GetInt(30)
        ServiceCharge = GetServiceCharge(ItemPrincipal)
        DelayInt = ItemPrincipal * GetInt(IIf(daysDue > 3, daysDue + 30, 0))
        Penalty = ItemPrincipal * GetInt(daysDue + 30, "Penalty")

        If Not PawnItem Is Nothing And PawnItem.AdvanceInterest = 0 Then
            'OLD Migrate
            If daysDue <= 3 Then DelayInt += AdvanceInterest
            If transactionType = "X" Then AdvanceInterest = 0
            If transactionType = "R" Then ServiceCharge += ServiceCharge

            isOldItem = True
        Else
            isOldItem = False
            'New Transactions
            If transactionType = "X" Then
                ServiceCharge = 0
            End If

            If daysDue > 3 Then
                DelayInt -= AdvanceInterest
            End If
        End If

        txtAdv.Text = AdvanceInterest
        txtOver.Text = daysDue
        txtInt.Text = DelayInt
        txtPenalty.Text = Penalty
        txtService.Text = ServiceCharge
        txtEvat.Text = 0

        If transactionType = "R" Then
            txtRenew.Text = AdvanceInterest + ServiceCharge + DelayInt + Penalty
            txtRedeem.Text = 0
            txtNet.Text = PawnItem.Principal - AdvanceInterest - ServiceCharge
        ElseIf transactionType = "X" Then
            txtRenew.Text = 0
            txtRedeem.Text = PawnItem.Principal + DelayInt + Penalty + ServiceCharge
        End If
    End Sub

    Private Sub SaveNewLoan()
        PawnItem = New PawnTicket
        With PawnItem
            .PawnTicket = currentPawnTicket
            .Pawner = PawnCustomer
            .LoanDate = txtLoan.Text
            .MaturityDate = txtMatu.Text
            .ExpiryDate = txtExpiry.Text
            .AuctionDate = txtAuction.Text
            .ItemType = cboType.Text
            .CategoryID = GetKey(PawnInfo(cboType.SelectedIndex), cboCat.Text)
            .Description = txtDesc.Text
            If cboType.Text = "JWL" Then .Karat = cboKarat.Text
            If cboType.Text = "JWL" Then .Grams = txtGram.Text
            .Appraisal = txtAppr.Text
            .Principal = txtPrincipal.Text
            .AdvanceInterest = txtAdv.Text
            .NetAmount = txtNet.Text

            If IsNumeric(txtInt.Text) Then .Interest = txtInt.Text
            If IsNumeric(txtService.Text) Then .ServiceCharge = txtService.Text
            If IsNumeric(txtEvat.Text) Then .EVAT = txtEvat.Text

            .AppraiserID = GetAppraiserID(cboAppraiser.Text)
            .Status = transactionType

            .SaveTicket()

            Dim tmpRemarks As String = "PT# " & currentPawnTicket
            AddJournal(.Principal, "Debit", "Inventory Merchandise - Loan", tmpRemarks)
            AddJournal(.NetAmount, "Credit", "Revolving Fund", tmpRemarks, ITEM_REDEEM)
            AddJournal(.AdvanceInterest, "Credit", "Interest on Loans", tmpRemarks)
            AddJournal(.ServiceCharge, "Credit", "Loans Service Charge", tmpRemarks)
        End With
    End Sub

    Private Function CheckAuth() As Boolean
        If transactionType <> "L" And cboAppraiser.Text = "" Then mod_system.isAuthorized = True

        If Not mod_system.isAuthorized And cboAppraiser.Text <> "" Then
            diagAuthorization.Show()
            diagAuthorization.TopMost = True
            diagAuthorization.txtUser.Text = cboAppraiser.Text
            diagAuthorization.fromForm = Me
            Return False
        End If

        Return True
    End Function

    Private Sub GeneratePT()
        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        dateChange(cboType.Text)

        If transactionType = "R" Then
            txtTicket.Text = CurrentPTNumber(GetOption("PawnLastNum"))
            txtOldTicket.Text = CurrentPTNumber(PawnItem.PawnTicket)
        End If
    End Sub

    Friend Sub Redeem(Optional ByVal typ As String = "X")
        transactionType = typ
        GenerateReceipt()

        Dim dayDiff = CurrentDate - PawnItem.LoanDate
        Dim dayDiffNew As Integer = dayDiff.Days + 1
        Dim overDays = CurrentDate - PawnItem.MaturityDate
        daysDue = IIf(overDays.Days > 0, overDays.Days, 0)
        ComputeInterests()

        If typ = "R" Then
            GeneratePT()
        End If

        If transactionType = "X" Then
            txtRedeem.BackColor = Drawing.SystemColors.Window
            txtRedeem.Focus()
        Else
            If transactionType = "R" Then
                txtRenew.Focus()
                txtRenew.BackColor = Drawing.SystemColors.Window
            End If
        End If

        ChangeForm()
    End Sub

    Private Function AddServerCharge(ByVal principal As Double) As Double
        Return GetServiceCharge(principal)
    End Function

    Private Function GetServiceCharge(ByVal principal As Double) As Double
        Dim srvPrin As Double = principal
        Dim ret As Double = 0

        If srvPrin < 500 Then
            ret = srvPrin * 0.01
        Else
            ret = 5
        End If

        Return ret
    End Function

    Private Sub GenerateReceipt()
        txtReceipt.Text = currentORNumber
        txtReceiptDate.Text = CurrentDate.ToShortDateString
    End Sub

    Friend Sub LoadCatName()
        cboCat.Text = GetCatName(PawnItem.CategoryID)
    End Sub

    Friend Sub LoadPawnTicket(ByVal pt As PawnTicket, ByVal type As String)
        LoadClient(pt.Pawner)
        cboType.Text = pt.ItemType
        cboCat.Text = GetCatName(pt.CategoryID)
        txtDesc.Text = pt.Description
        txtGram.Text = pt.Grams
        cboKarat.Text = pt.Karat

        txtTicket.Text = CurrentPTNumber(pt.PawnTicket)
        txtOldTicket.Text = pt.OldTicket
        txtLoan.Text = pt.LoanDate
        txtMatu.Text = pt.MaturityDate
        txtExpiry.Text = pt.ExpiryDate
        txtAuction.Text = pt.AuctionDate

        txtAppr.Text = pt.Appraisal
        txtPrincipal.Text = pt.Principal
        txtAdv.Text = pt.AdvanceInterest
        txtNet.Text = pt.NetAmount

        txtReceipt.Text = IIf(pt.OfficialReceiptNumber = 0, "", pt.OfficialReceiptNumber)
        txtReceiptDate.Text = IIf(pt.OfficialReceiptDate = #12:00:00 AM#, "", pt.OfficialReceiptDate)
        txtPrincipal2.Text = IIf(pt.Principal = 0, "", pt.Principal)

        txtOver.Text = pt.DaysOverDue
        txtInt.Text = pt.Interest
        txtPenalty.Text = pt.Penalty
        txtService.Text = pt.ServiceCharge
        txtEvat.Text = pt.EVAT

        txtRenew.Text = pt.RenewDue
        txtRedeem.Text = pt.RedeemDue

        cboAppraiser.Text = GetAppraiserByID(pt.AppraiserID)

        transactionType = type
        PawnItem = pt

        mod_system.isAuthorized = True
        If transactionType = "D" Then
            LockFields(True)
            btnSave.Enabled = False : btnRenew.Enabled = True
            btnRedeem.Enabled = True : btnVoid.Enabled = True
        End If

        ChangeForm()
        If PawnItem.Status = "R" Then Me.Text &= " [RENEW]"
        If PawnItem.Status = "0" Then Me.Text &= " [INACTIVE/RENEWED]"
        If PawnItem.Status = "X" Then Me.Text &= " [REDEEMED]"
        If PawnItem.Status = "S" Then Me.Text &= " [SEGREGATED]"
        If PawnItem.Status = "W" Then Me.Text &= " [WITHDRAW] - Pull Out: " & PawnItem.PullOutDate.ToShortDateString
        If PawnItem.Status = "V" Then Me.Text &= " [VOIDED]"

        Select Case PawnItem.Status
            Case "0", "S", "W", "V"
                LockFields(1)
            Case "X"
                LockFields(1)
                btnVoid.Enabled = True
        End Select

        If PawnItem.ItemType = "CEL" Then btnRenew.Enabled = False 'Disable Renewal for Cellphone

        'Get New Number
        Dim mySql As String = "SELECT * FROM tblPawn WHERE OldTicket = " & PawnItem.PawnTicket
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count <> 0 Then
            lblNPT.Visible = True
            lblNPT.Text &= CurrentPTNumber(ds.Tables(0).Rows(0).Item("PawnTicket"))
        End If
    End Sub

    Private Sub ChangeForm()
        Select Case transactionType
            Case "D"
                lblTransaction.Text = "Ticket Information"
            Case "L"
                lblTransaction.Text = "New Loan"
            Case "R"
                lblTransaction.Text = "Renew"
            Case "X"
                lblTransaction.Text = "Redeem"
        End Select
    End Sub

    Private Function GetAppraiserByID(ByVal id As Integer) As String
        For Each el As DictionaryEntry In appraiser
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function GetAppraiserID(ByVal name As String) As Integer
        For Each el As DictionaryEntry In appraiser
            If el.Value = name Then
                Return el.Key
            End If
        Next

        Return 0
    End Function

    Private Function GetCatName(ByVal id As Integer) As String
        Dim idx As Integer = cboType.SelectedIndex

        For Each el As DictionaryEntry In PawnInfo(idx)
            If el.Key = id Then
                Return el.Value
            End If
        Next

        Return "N/A"
    End Function

    Private Function isReady() As Boolean
        'Checking Numerics
        If Not IsNumeric(txtGram.Text) And cboType.Text = "JWL" Then txtGram.Focus() : Return False
        If Not IsNumeric(txtAppr.Text) Then txtAppr.Focus() : Return False
        If Not IsNumeric(txtPrincipal.Text) Then txtPrincipal.Focus() : Return False

        If CDbl(txtAppr.Text) < CDbl(txtPrincipal.Text) Then
            MsgBox("Lesser Appraisal over Principal is not acceptable", MsgBoxStyle.Critical)
            txtAppr.SelectAll() : txtAppr.Focus()
            Return False
        End If

        If txtCustomer.Text = "" Then txtCustomer.Focus() : Return False
        If cboType.Text = "" Then cboType.Focus() : Return False
        If cboCat.Text = "" Then cboCat.Focus() : Return False

        If cboType.Text = "JWL" Then
            If txtGram.Text = "" Then txtGram.Focus() : Return False
            If cboKarat.Text = "" Then cboKarat.Focus() : Return False
        End If

        If txtAppr.Text = "" Then txtAppr.Focus() : Return False
        If txtPrincipal.Text = "" Then txtPrincipal.Focus() : Return False
        If cboAppraiser.Text = "" Then cboAppraiser.Focus() : Return False

        Return True
    End Function

    Private Function GetKey(ByVal ht As Hashtable, ByVal val As String) As String
        If ht.ContainsValue(val) Then
            For Each el As DictionaryEntry In ht
                If el.Value = val Then
                    Return el.Key
                End If
            Next
        End If
        Return "N/A"
    End Function

    Friend Sub NewLoan()
        txtCustomer.Focus()
        transactionType = "L"
        GeneratePT()
        dateChange(cboType.Text)
        txtPrincipal2.Text = txtPrincipal.Text
        btnRenew.Enabled = False
        btnRedeem.Enabled = False
        btnVoid.Enabled = False

        'AdvanceInterest()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        txtContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        PawnCustomer = cl
        cboType.Focus()
        'cboType.DroppedDown = True
    End Sub

    Private Sub dateChange(ByVal typ As String)
        Select Case typ
            Case "CEL"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = CurrentDate.AddDays(62).ToShortDateString
            Case Else
                txtExpiry.Text = CurrentDate.AddDays(119).ToShortDateString
                txtAuction.Text = CurrentDate.AddDays(152).ToShortDateString
        End Select
        ComputeInterests()
    End Sub

    Private Function CurrentPTNumber(Optional ByVal num As Integer = 0) As String
        Return String.Format("{0:000000}", If(num = 0, currentPawnTicket, num))
    End Function

    Private Function CurrentOR() As String
        Return String.Format("{0:000000}", currentORNumber)
    End Function

    Private Sub LoadInformation()
        LoadPawnInfo()
    End Sub

    Private Sub LoadPawnInfo()
        cboType.Items.Clear()
        cboCat.Items.Clear()
        'cboKarat.Items.Clear()

        'Type
        Dim mySql As String = "SELECT DISTINCT TYPE FROM tblClass ORDER BY TYPE ASC"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim classCNT As Integer = ds.Tables(0).Rows.Count
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr.Item("TYPE"))
        Next
        cboType.SelectedIndex = 0

        'Category
        ReDim PawnInfo(classCNT - 1)
        Dim cnt As Integer = 0 : mySql = "SELECT * FROM tblClass WHERE "
        For cnt = 0 To classCNT - 1
            Dim str As String = mySql & String.Format("TYPE = '{0}'", cboType.Items(cnt)) & " ORDER BY CATEGORY ASC"
            ds.Clear()
            ds = LoadSQL(str)
            Dim x As Integer = 0
            cboCat.Items.Clear()

            PawnInfo(cnt) = New Hashtable
            Console.WriteLine("Batch " & cnt + 1 & " ===================")
            For Each dr As DataRow In ds.Tables(0).Rows
                Console.WriteLine(x + 1 & ". " & dr.Item("Category"))
                PawnInfo(cnt).Add(dr.Item("ClassID"), dr.Item("Category"))
                x += 1
            Next

            Console.WriteLine("Re-Display ================")
            For Each el As DictionaryEntry In PawnInfo(cnt)
                Console.WriteLine(String.Format("{0}. {1}", el.Key, el.Value))
            Next
            Console.WriteLine("")
        Next

        For Each el As DictionaryEntry In PawnInfo(0)
            cboCat.Items.Add(el.Value)
        Next
        cboCat.SelectedIndex = 0

    End Sub

    Private Sub LoadAppraisers()
        Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        Dim ds As DataSet = LoadSQL(mySql)

        appraiser = New Hashtable
        cboAppraiser.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpUser As New ComputerUser
            tmpUser.LoadUserByRow(dr)
            Console.WriteLine(tmpUser.FullName & " loaded.")

            appraiser.Add(tmpUser.UserID, tmpUser.UserName)
            cboAppraiser.Items.Add(tmpUser.UserName)
        Next
    End Sub

    Private Sub LoanAdvanceInterest()
        TypeInt = GetInt(30)

        If transactionType = "L" Then
            txtAdv.Text = (CDbl(txtPrincipal.Text) * TypeInt)
            txtInt.Text = CDbl(txtPrincipal.Text) * TypeInt
            txtService.Text = GetServiceCharge(txtPrincipal.Text)
        End If
        txtNet.Text = CDbl(txtPrincipal.Text) - (CDbl(txtPrincipal.Text) * TypeInt) - CDbl(txtService.Text)

    End Sub

    Private Function GetInt(ByVal days As Integer, Optional ByVal tbl As String = "Interest") As Double
        Dim mySql As String = "SELECT * FROM tblInt WHERE ItemType = '" & cboType.Text & "' AND STATUS = 0"
        Dim ds As DataSet = LoadSQL(mySql), TypeInt As Double

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim min As Integer = 0, max As Integer = 0
            min = dr.Item("DayFrom") : max = dr.Item("DayTo")

            Select Case days
                Case min To max
                    TypeInt = dr.Item(tbl)
                    Console.WriteLine(tbl & " is now " & TypeInt & " for " & cboType.Text)
                    Return TypeInt
            End Select
        Next

        Return 0
    End Function

    Private Sub LockFields(ByVal st As Boolean)
        txtCustomer.ReadOnly = st
        btnSearch.Enabled = Not st
        cboType.Enabled = Not st
        cboCat.Enabled = Not st
        txtDesc.Enabled = Not st
        txtGram.Enabled = Not st
        cboKarat.Enabled = Not st
        txtAppr.Enabled = Not st
        txtPrincipal.Enabled = Not st
        cboAppraiser.Enabled = Not st
        btnRenew.Enabled = Not st
        btnRedeem.Enabled = Not st
        btnVoid.Enabled = Not st
        btnSave.Enabled = Not st
    End Sub

    Private Sub SaveRenew()
        Dim oldPT As Integer = PawnItem.PawnTicket
        Dim principal As Double, netAmt As Double
        Dim interest As Double, advInt As Double
        Dim servChar As Double, penalty As Double
        Dim redeemDue As Double

        'Redeem
        With PawnItem
            .OfficialReceiptNumber = currentORNumber
            .OfficialReceiptDate = CurrentDate

            .DaysOverDue = txtOver.Text
            .Interest = txtInt.Text
            .Penalty = txtPenalty.Text
            .ServiceCharge = txtService.Text
            .EVAT = txtEvat.Text
            .RenewDue = txtRenew.Text
            .RedeemDue = txtRedeem.Text
            .Status = "0"

            .SaveTicket(False)

            principal = CDbl(txtPrincipal.Text)
            netAmt = CDbl(txtNet.Text)
            interest = CDbl(txtInt.Text)
            advInt = CDbl(txtAdv.Text)
            servChar = CDbl(txtService.Text)
            penalty = CDbl(txtPenalty.Text)
            redeemDue = CDbl(txtRedeem.Text)

        End With
        AddORNum()
        GeneratePT()

        With PawnItem
            .PawnTicket = CurrentPTNumber()
            .OldTicket = oldPT
            .LoanDate = CurrentDate
            .MaturityDate = txtMatu.Text
            .ExpiryDate = txtExpiry.Text
            .AuctionDate = txtAuction.Text

            .OfficialReceiptNumber = 0
            .OfficialReceiptDate = Nothing

            .DaysOverDue = 0
            .Interest = 0
            .Penalty = 0
            .ServiceCharge = 0
            .EVAT = 0
            .RenewDue = 0
            .RedeemDue = 0

            .Principal = txtPrincipal.Text
            .AdvanceInterest = AdvanceInterest
            .NetAmount = .Principal - AdvanceInterest
            .Status = "R"

            .SaveTicket()

            AddJournal(CDbl(txtRenew.Text), "Debit", "Revolving Fund", "PT# " & oldPT, ITEM_REDEEM)
            AddJournal(interest + advInt + penalty, "Credit", "Interest on Loans", "PT# " & oldPT)
            AddJournal(servChar, "Credit", "Loans Service Charge", "PT# " & oldPT)
        End With

        AddPTNum()
    End Sub

#End Region

#Region "Printing"
    Private Sub PrintNewLoan()
        PrintPawnTicket()
    End Sub

    Private Sub PrintPawnTicket()
        Dim autoPrintPT As Reporting
        On Error Resume Next

        Dim printerName As String = "EPSON LX-300+ /II Parallel"
        If Not canPrint(printerName) Then Exit Sub

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting


        Dim mySql As String, dsName As String = "dsPawnTicket"
        mySql = "SELECT * FROM PRINT_PAWNING WHERE PAWNID = " & PawnItem.PawnID
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        report.ReportPath = "Reports\layout01.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        Dim addParameters As New Dictionary(Of String, String)
        If isOldItem Then
            addParameters.Add("txtDescription", PawnItem.Description)
        Else
            addParameters.Add("txtDescription", pawning.DisplayDescription(PawnItem))
        End If

        'addParameters.Add("txtItemInterest", GetInt(30))
        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        autoPrintPT.Export(report)
        autoPrintPT.m_currentPageIndex = 0
        autoPrintPT.Print(printerName)
    End Sub

    Private Sub PrintRedeemOR()
        Dim autoPrintPT As Reporting
        On Error Resume Next

        Dim printerName As String = "EPSON LX-300+ /II Parallel"
        If Not canPrint(printerName) Then Exit Sub

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String
        mySql = "SELECT * FROM PRINT_PAWNING WHERE PAWNID = " & PawnItem.PawnID
        Dim dsName As String = "dsOR"
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        report.ReportPath = "Reports\layout02.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        Dim paymentStr As String = _
            String.Format("PT# {0:000000} with a payment amount of Php {1}", PawnItem.PawnTicket, PawnItem.RedeemDue)
        Dim addParameters As New Dictionary(Of String, String)
        addParameters.Add("txtPayment", paymentStr)
        addParameters.Add("txtDescription", PawnItem.Description)
        addParameters.Add("txtTotalDue", CDbl(PawnItem.RedeemDue))

        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        Dim paperSize As New Dictionary(Of String, Double)
        paperSize.Add("width", 8.5)
        paperSize.Add("height", 4.5)

        'frmReport.ReportInit(mySql, dsName, report.ReportPath, addParameters, False)
        'frmReport.Show()

        autoPrintPT.Export(report, paperSize)
        autoPrintPT.m_currentPageIndex = 0
        autoPrintPT.Print(printerName)
    End Sub

    Private Sub frmPawnItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.DoubleClick
        PrintNewLoan()
    End Sub

    Private Function canPrint(ByVal printerName As String) As Boolean
        Try
            Dim printDocument As Drawing.Printing.PrintDocument = New Drawing.Printing.PrintDocument
            printDocument.PrinterSettings.PrinterName = printerName
            Return printDocument.PrinterSettings.IsValid
        Catch ex As Exception
            Return False
        End Try
    End Function
#End Region

End Class