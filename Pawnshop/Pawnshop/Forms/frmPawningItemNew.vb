Imports Microsoft.Reporting.WinForms

Public Class frmPawningItemNew
    Friend transactionType As String = "L"
    Friend PT_Entry As New PawnTicket2 'Serve as Pawn Ticket
    Friend PawnedItem As New PawnItem 'Serve as Pawned Item
    Friend Pawner As Client
    Friend Pawner_OtherClaimer As New Client
    Private isOldItem As Boolean = False
    Private isEarlyRedeem As Boolean = False

    Private ItemClasses_ht As Hashtable
    Private Appraisers_ht As Hashtable

    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private currentORNumber As Integer = GetOption("ORLastNum")

    Private LoanDate As Date, MaturityDate As Date, ExpiryDate As Date, AuctionDate As Date
    Private Appraisal As Double, Principal As Double, AdvanceInterest As Double, NetAmount As Double
    Private ORNum As Integer, ORDate As Date, DaysOverDue As Integer, PawnInterest As Double, PawnPenalty As Double, PawnServiceCharge As Double, eVat As Double = 0
    Private RenewDue As Double, RedeemDue As Double


    Private PRINTER_PT As String = GetOption("PrinterPT")
    Private PRINTER_OR As String = GetOption("PrinterOR")

    Const MOD_NAME As String = "PAWNING"
    Const ITEM_REDEEM As String = "REDEEM"
    Const ITEM_NEWLOAN As String = "NEW LOAN"
    Const ITEM_RENEW As String = "RENEW"
    Const HAS_ADVINT As Boolean = True
    Const PAUSE_OR As Boolean = False
    Const OR_COPIES As Integer = 2
    Const MONTH_COMPUTE As Integer = 4

    Private unableToSave As Boolean = False

    Private PRINT_PTOLD As Integer = 0
    Private PRINT_PTNEW As Integer = 0
    Private SAP_ACCOUNTCODE() As String = _
        {"_SYS00000000143",
        "_SYS00000001056",
        "_SYS00000000300",
        "_SYS00000000298",
        "_SYS00000001072",
        "_SYS00000001071",
        "_SYS00000000297"}

    Dim Critical_Language() As String =
            {"Failed to verify hash value to the "}
    'Private OTPDisable As Boolean = IIf(GetOption("OTP") = "YES", True, False)
    Private Reprint As Boolean = False
    Private ReadyToPrint As Boolean = False

    Private Sub ClearFields()
        mod_system.isAuthorized = False

        txtCustomer.Text = ""
        txtAddr.Text = ""
        txtBDay.Text = ""
        txtContact.Text = ""

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

        txtClassification.Text = ""
        txtClaimer.Clear()
        lvSpec.Items.Clear()
    End Sub

    Private Sub LoadAppraisers()
        Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0='"
        Dim ds As DataSet = LoadSQL(mySql)

        Appraisers_ht = New Hashtable
        cboAppraiser.Items.Clear()

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim u As New ComputerUser
            u.LoadUserByRow(dr)

            ' UNCOMMENT ON FINAL
            'If u.canAppraise Then
            '    cboAppraiser.Items.Add(u.UserName)
            '    Appraisers_ht.Add(u.UserID, u)
            'End If

            ' REMOVE ON FINAL
            ' Appraiser have canAppraise

            cboAppraiser.Items.Add(u.UserName)
            Appraisers_ht.Add(u.UserID, u.UserName)
        Next
    End Sub

    Private Sub btnSearchClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClassification.Click
        Dim secured_str As String = txtClassification.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.frmPawningV2_Specs)
        frmItemList.Show()
    End Sub

    Private Sub btnSearchClaimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClaimer.Click
        Dim secured_str As String = txtClaimer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.frmPawningV2_Claimer)
        frmClient.Show()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        txtContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        Pawner = New Client
        Pawner = cl
        txtClassification.Focus()
    End Sub

    Friend Sub LoadCliamer(ByVal cl As Client)
        txtClaimer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        Pawner_OtherClaimer = cl
    End Sub

    Friend Sub Load_ItemSpecification(ByVal Item As ItemClass)
        PawnedItem.ItemClass = Item
        txtClassification.Text = Item.ClassName

        ItemClasses_ht = New Hashtable
        lvSpec.Items.Clear()
        For Each spec As ItemSpecs In PawnedItem.ItemClass.ItemSpecifications
            Dim lv As ListViewItem = lvSpec.Items.Add(spec.SpecName)
            lv.SubItems.Add("")
            ItemClasses_ht.Add(spec.SpecID, spec.SpecName)
        Next

        txtClassification.Text = Item.ClassName

        dateChange(PawnedItem.ItemClass)
        lvSpec.Focus()
        lvSpec.Items(0).Selected = True

    End Sub

    Private Sub AddItem(ByVal Item As DataRow)
        Dim tmpItem As New ItemSpecs
        tmpItem.LoadItemSpecs_row(Item)

        Dim lv As ListViewItem = lvSpec.Items.Add(tmpItem.SpecID)
        lv.SubItems.Add(tmpItem.SpecName)
        lv.SubItems.Add(tmpItem.SpecLayout)
        lv.SubItems.Add(tmpItem.SpecType)
        lv.SubItems.Add("")
        lv.Tag = tmpItem.SpecID

    End Sub

    Private Sub lvSpec_ColumnWidthChanging(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ColumnWidthChangingEventArgs) Handles lvSpec.ColumnWidthChanging
        If Me.lvSpec.Columns(e.ColumnIndex).Width = 0 Then
            e.Cancel = True
            e.NewWidth = Me.lvSpec.Columns(e.ColumnIndex).Width
        End If
    End Sub

    Friend Sub DisplayValue(value As String, id As Integer)
        lvSpec.Items(id).SubItems(1).Text = value
    End Sub

    Private Sub InputSpec()
        If lvSpec.SelectedItems.Count = 0 Then Exit Sub

        Dim tmpSpec As New ItemSpecs
        Dim idx As Integer = lvSpec.FocusedItem.Index
        Dim selectedID As Integer = GetIDbyName(lvSpec.FocusedItem.Text, ItemClasses_ht)
        tmpSpec.LoadItemSpecs(selectedID)

        Select Case tmpSpec.SpecLayout
            Case "TextBox"
                frm_PanelTextbox.DisplaySpecs(lvSpec.FocusedItem.Text)
                frm_PanelTextbox.retID = idx
                frm_PanelTextbox.inputType = tmpSpec.SpecType
                frm_PanelTextbox.ShowDialog()
            Case "Yes/No"
                frm_PanelYesNo.DisplaySpecs(lvSpec.FocusedItem.Text)
                frm_PanelYesNo.retID = idx
                frm_PanelYesNo.ShowDialog()
            Case "MultiLine"
                frm_PanelMultiline.DisplaySpecs(lvSpec.FocusedItem.Text)
                frm_PanelMultiline.retID = idx
                frm_PanelMultiline.ShowDialog()
        End Select
    End Sub

    Private Sub lvSpec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvSpec.KeyPress
        If isEnter(e) Then
            InputSpec()
        End If
    End Sub

    Private Sub lvSpec_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lvSpec.DoubleClick
        InputSpec()
    End Sub

    Private Function isValid() As Boolean
        If Pawner Is Nothing Then MsgBox("Please select your customer", MsgBoxStyle.Information) : txtCustomer.Focus() : Return False
        If PawnedItem.ItemClass Is Nothing Then MsgBox("Please select an item", MsgBoxStyle.Information) : txtClassification.Focus() : Return False
        If txtAppr.Text = "" Then txtAppr.Focus() : Return False
        If txtPrincipal.Text = "" Then txtPrincipal.Focus() : Return False
        If CDbl(txtPrincipal.Text) > CDbl(txtAppr.Text) Then MsgBox("Principal is greater than Appraisal", MsgBoxStyle.Critical) : txtAppr.Focus() : Return False
        'If Not mod_system.isAuthorized Then CheckAuth() : Return False
        If cboAppraiser.Text = "" Then cboAppraiser.Focus() : Return False

            If Not IsNumeric(txtAppr.Text) Then txtAppr.Focus() : Return False
            If Not IsNumeric(txtPrincipal.Text) Then txtPrincipal.Focus() : Return False

            Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If unableToSave Then Exit Sub
        If Not CheckAuth() Then Exit Sub
        If Not isValid() And transactionType = "L" Then
            MsgBox("I think you are missing something", MsgBoxStyle.Critical)
            Exit Sub
        End If
        If MsgBox("Do you want to save this transaction?", _
                  MsgBoxStyle.YesNo + MsgBoxStyle.Information, _
                  "Saving...") = MsgBoxResult.No Then Exit Sub

        Select Case transactionType
            Case "L"
                SaveNewLoan()
                If ReadyToPrint = False Then
                    Exit Sub
                Else
                    PrintNewLoan()
                End If

            Case "R"
                SaveRenew() : PrintRenew()

            Case "X"
                SaveRedeem() : If Not PAUSE_OR Then do_RedeemOR()
        End Select
        Me.Close()
    End Sub

    Private Sub SaveRedeem()
        'If Pawner_OtherClaimer.ID = 0 Then Exit Sub
        With PT_Entry.PawnItem
            .WithdrawDate = CurrentDate
            .Status = "X"
            .Save_PawnItem()
        End With

        With PT_Entry
            .ORNumber = currentORNumber
            .ORDate = CurrentDate
            .DaysOverDue = DaysOverDue
            .DelayInterest = PawnInterest
            .Penalty = PawnPenalty
            .ServiceCharge = PawnServiceCharge
            .Status = "X"
            .ClaimerID = Pawner_OtherClaimer.ID
            .RenewDue = 0
            .RedeemDue = RedeemDue

            .Update_PawnTicket()

            If isEarlyRedeem Then
                Dim itmPrn As Double = .Principal
                Dim itmAdv As Double = .AdvanceInterest
                Dim itmDue As Double = RedeemDue

                Dim itmEarly As Double = itmAdv - (itmPrn - itmDue)
                'itmEarly -= CDbl(txtService.Text) 'Lesser Service Charge

                .DelayInterest = itmEarly
                .EarlyReddem = itmEarly
            Else
                .DelayInterest = txtInt.Text
            End If

            If isOldItem Then
                AddJournal(.RedeemDue, "Debit", "Revolving Fund", "REDEEM PT# " & .PawnTicket, ITEM_REDEEM, , , "REDEMPTION", PT_Entry.PawnID)
                AddJournal(.Principal, "Credit", "Inventory Merchandise - Loan", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)

                'Changed in V1.2
                AddJournal(.DelayInterest, "Credit", "Interest on Redemption", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)
                AddJournal(.Penalty, "Credit", "Income from Penalty on Redemption", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)
                AddJournal(.ServiceCharge, "Credit", "Loans Service Charge", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)
            Else
                AddJournal(.RedeemDue, "Debit", "Revolving Fund", "REDEEM PT# " & .PawnTicket, ITEM_REDEEM, , , "REDEMPTION", PT_Entry.PawnID)
                If isEarlyRedeem Then
                    Dim rndInt As Double = .AdvanceInterest - .EarlyReddem

                    'Changed in V1.2
                    AddJournal(Math.Round(rndInt, 2), "Debit", "Interest on Redemption", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION EARLY", PT_Entry.PawnID)
                End If
                AddJournal(.Principal, "Credit", "Inventory Merchandise - Loan", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)
                If DaysOverDue > 3 Then
                    'Changed in V1.2
                    AddJournal(.DelayInterest, "Credit", "Interest on Redemption", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)
                    AddJournal(.Penalty, "Credit", "Income from Penalty on Redemption", "REDEEM PT# " & .PawnTicket, , , , "REDEMPTION", PT_Entry.PawnID)
                End If
            End If

            AddTimelyLogs("REDEMPTION", String.Format("PT# {0} ", .PawnTicket.ToString("000000")), RedeemDue, , , PT_Entry.PawnID)

            AddNumber(DocumentClass.OfficialReceipt)
            MsgBox("Item Redeemed", MsgBoxStyle.Information)

            If frmPawning.Visible And Not frmPawning.isMoreThan100 Then
                frmPawning.ReloadForm()
            End If

        End With
    End Sub

    Private Sub SaveRenew()
        Dim oldPawnTicket As Integer = 0

        'Renewal Increment
        PT_Entry.PawnItem.RenewalCnt += 1
        PT_Entry.PawnItem.Save_PawnItem()

        'Inactive OLD Pawnticket
        oldPawnTicket = PT_Entry.PawnTicket
        With PT_Entry
            .Status = 0 'Inactive

            .AdvanceInterest = AdvanceInterest

            .ORNumber = currentORNumber
            .ORDate = CurrentDate
            .DaysOverDue = DaysOverDue
            .DelayInterest = PawnInterest
            .Penalty = PawnPenalty
            .ServiceCharge = PawnServiceCharge

            .RenewDue = RenewDue
            .RedeemDue = 0

            .Update_PawnTicket()
        End With

        RefreshInput()
        Dim newPT As New PawnTicket2
        newPT = PT_Entry
        With newPT
            .PawnTicket = currentPawnTicket
            .OldTicket = oldPawnTicket
            .LoanDate = LoanDate
            .MaturityDate = MaturityDate
            .ExpiryDate = ExpiryDate
            .AuctionDate = AuctionDate

            'REMOVE OFFICALRECEIPT INFORMATION
            .ORDate = Nothing
            .ORNumber = 0
            .DaysOverDue = 0
            .Penalty = 0
            .RenewDue = 0
            .RedeemDue = 0
            .ServiceCharge = IIf(isOldItem, 0, CInt(PawnServiceCharge))

            .Appraisal = PT_Entry.Appraisal
            .Principal = PT_Entry.Principal
            .NetAmount = PT_Entry.NetAmount

            .Status = "R"
            .PawnItem = PT_Entry.PawnItem
            .Pawner = PT_Entry.Pawner
            .ClaimerID = Pawner_OtherClaimer.ID
            'INCLUDE THE CLAIMER HERE
            '?????????????????

            .AdvanceInterest = AdvanceInterest

            PRINT_PTNEW = .PawnTicket
            PRINT_PTOLD = .OldTicket

            .Save_PawnTicket()

            AddJournal(RenewDue, "Debit", "Revolving Fund", "PT# " & oldPawnTicket, ITEM_RENEW, , , "RENEWALS", .LoadLastIDNumberPawn)
            AddJournal(PawnInterest + .AdvanceInterest, "Credit", "Interest on Renewal", "PT# " & oldPawnTicket, , , , "RENEWALS", .LoadLastIDNumberPawn)
            AddJournal(PawnPenalty, "Credit", "Income from Penalty on Renewal", "PT# " & oldPawnTicket, , , , "RENEWALS", .LoadLastIDNumberPawn)
            AddJournal(PawnServiceCharge, "Credit", "Loans Service Charge", "PT# " & oldPawnTicket, , , , "RENEWALS", .LoadLastIDNumberPawn)

            AddTimelyLogs("RENEWALS", String.Format("PT#{0}", PT_Entry.PawnTicket.ToString("000000")), RenewDue, , String.Format("PT#{0}", oldPawnTicket.ToString("000000")), .LoadLastIDNumberPawn)
        End With

        AddNumber(DocumentClass.Pawnticket)
        AddNumber(DocumentClass.OfficialReceipt)
        MsgBox("Item Renewed", MsgBoxStyle.Information)

        If frmPawning.Visible And Not frmPawning.isMoreThan100 Then
            frmPawning.ReloadForm()
        End If
    End Sub

    Private Sub RefreshInput()
        ' DECLARING INPUT ===============================================
        Appraisal = CDbl(txtAppr.Text)
        Principal = CDbl(txtPrincipal.Text)
        LoanDate = DateTime.Parse(txtLoan.Text)
        MaturityDate = DateTime.Parse(txtMatu.Text)
        ExpiryDate = DateTime.Parse(txtExpiry.Text)
        AuctionDate = DateTime.Parse(txtAuction.Text)
    End Sub

    Private Sub SaveNewLoan()
        If Not isValid() Then Exit Sub
        ' CHECKING REQUIRED FIELDS
        Dim i As Integer = 0
        Try
        For Each reqSpec As ItemSpecs In PawnedItem.ItemClass.ItemSpecifications
            If reqSpec.isRequired Then
                If lvSpec.Items(i).SubItems(1).Text = "" Then
                    MsgBox("This one requires information", MsgBoxStyle.Critical, reqSpec.SpecName)
                    ReadyToPrint = False
                    Exit Sub
                Else
                    ReadyToPrint = True
                End If
            End If

            i += 1
        Next

        ' SAVING PAWNED ITEM INFORMATION ================================

        ' Saving Pawned Item Specification
        i = 0
        Dim PawnSpecs As New CollectionPawnItemSpecs
        For Each ItmSpc As ItemSpecs In PawnedItem.ItemClass.ItemSpecifications
            Dim pwnSpec As New PawnItemSpec
            pwnSpec.UnitOfMeasure = ItmSpc.UnitOfMeasure
            pwnSpec.SpecName = ItmSpc.SpecName
            pwnSpec.SpecType = ItmSpc.SpecType
            pwnSpec.SpecsValue = lvSpec.Items(i).SubItems(1).Text
            pwnSpec.isRequired = ItmSpc.isRequired

            PawnSpecs.Add(pwnSpec)
            i += 1
        Next
        PawnedItem.PawnItemSpecs = PawnSpecs
        RefreshInput()
        ' END - SAVING PAWNED ITEM INFORMATION ==========================

        With PT_Entry
            .Pawner = Pawner
            .PawnItem = PawnedItem

            'Personnel
            .AppraiserID = GetIDbyName(cboAppraiser.Text, Appraisers_ht)
            .EncoderID = POSuser.UserID

            .PawnTicket = currentPawnTicket
            .LoanDate = LoanDate
            .MaturityDate = MaturityDate
            .ExpiryDate = ExpiryDate
            .AuctionDate = AuctionDate

            .Appraisal = Appraisal
            .Principal = Principal

            .AdvanceInterest = AdvanceInterest
            .ServiceCharge = PawnServiceCharge
            .NetAmount = NetAmount
            .Save_PawnTicket()

            Dim tmpRemarks As String = "PT# " & currentPawnTicket.ToString("000000")
            AddJournal(.Principal, "Debit", "Inventory Merchandise - Loan", tmpRemarks, , , , "NEW LOANS", .LoadLastIDNumberPawn)
            AddJournal(.NetAmount, "Credit", "Revolving Fund", tmpRemarks, ITEM_NEWLOAN, , , "NEW LOANS", .LoadLastIDNumberPawn)
            AddJournal(.AdvanceInterest, "Credit", "Interest on Loans", tmpRemarks, , , , "NEW LOANS", .LoadLastIDNumberPawn)
            AddJournal(.ServiceCharge, "Credit", "Loans Service Charge", tmpRemarks, , , , "NEW LOANS", .LoadLastIDNumberPawn)


            'AddTimelyLogs(MOD_NAME, "NEW LOAN - " & tmpRemarks)
            AddTimelyLogs("NEW LOANS", tmpRemarks, .NetAmount, , , .LoadLastIDNumberPawn)
            HitManagement.do_PawningHit(PT_Entry.Pawner, PT_Entry.PawnTicket)
        End With

            AddNumber(DocumentClass.Pawnticket)

            MsgBox("Item Saved", MsgBoxStyle.Information)

        'NewLoan()
        txtCustomer.Focus()
        If frmPawning.Visible And Not frmPawning.isMoreThan100 Then
            frmPawning.ReloadForm()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Please Check the fields!")
        End Try
    End Sub

    Private Sub dateChange(selectedClass As ItemClass)
        If selectedClass Is Nothing Then Exit Sub

        Select Case selectedClass.ClassName
            Case "CELLPHONE", "TABLET"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = CurrentDate.AddDays(62).ToShortDateString
            Case Else
                txtExpiry.Text = CurrentDate.AddDays(119).ToShortDateString
                txtAuction.Text = CurrentDate.AddDays(152).ToShortDateString
        End Select

        ReComputeInterest()
    End Sub

    Private Sub Update_MoneyUserInput()
        If txtAppr.Text = "" Then Exit Sub
        If Not IsNumeric(txtAppr.Text) Then Exit Sub
        If txtPrincipal.Text = "" Then Exit Sub
        If Not IsNumeric(txtPrincipal.Text) Then Exit Sub

        Appraisal = CDbl(txtAppr.Text)
        Principal = CDbl(txtPrincipal.Text)
    End Sub

    Private Function MoneyFormat(dbl As Double) As String
        Return dbl.ToString("#,##0.00")
    End Function

    Private Sub ReComputeInterest()
        Console.WriteLine("Recomputing...")

        Update_MoneyUserInput()
        If Principal = 0 Then Exit Sub

        Dim AutoCompute As PawnCompute
        Dim isDPJ As Boolean = True

        If transactionType <> "L" Then
            'REMANTIC NO ADVANCE INTEREST
            If PT_Entry.AdvanceInterest = 0 Then
                isDPJ = False
                'isOldItem = Not isDPJ
            End If
        End If

        Try
            AutoCompute = New PawnCompute _
            (Principal, PawnedItem.ItemClass.InterestScheme, CurrentDate, PT_Entry.MaturityDate, isDPJ)
        Catch ex As Exception
            Console.WriteLine("Incomplete Data")
            Console.WriteLine(ex.Message)
            Exit Sub
        End Try

        PawnServiceCharge = AutoCompute.ServiceCharge
        AdvanceInterest = AutoCompute.AdvanceInterest
        NetAmount = AutoCompute.NetAmount

        txtService.Text = MoneyFormat(PawnServiceCharge)
        txtAdv.Text = MoneyFormat(AdvanceInterest)
        txtNet.Text = MoneyFormat(NetAmount)
        isEarlyRedeem = AutoCompute.isEarlyRedeem
        isOldItem = Not isDPJ

        If transactionType = "R" Or transactionType = "X" Then
            GenerateORNum()
            With AutoCompute
                txtOver.Text = .DaysOverDue : DaysOverDue = .DaysOverDue
                txtInt.Text = .Interest.ToString("#,##0.00") : PawnInterest = .Interest
                txtPenalty.Text = .Penalty.ToString("#,##0.00") : PawnPenalty = .Penalty
                txtService.Text = .ServiceCharge.ToString("#,##0.00") : PawnServiceCharge = .ServiceCharge
                txtEvat.Text = (0).ToString("#,##0.00")

                txtRenew.Text = (0).ToString("#,##0.00") : RenewDue = .RenewDue
                txtRedeem.Text = (0).ToString("#,##0.00") : RedeemDue = .RedeemDue

                If transactionType = "R" Then txtRenew.Text = .RenewDue.ToString("#,##0.00")
                If transactionType = "X" Then txtRedeem.Text = .RedeemDue.ToString("#,##0.00")
            End With
        End If

        '    Dim intHash As String = ""

        '    If transactionType = "D" Then Exit Sub 'Display No Recommute
        '    If txtMatu.Text = "" Then Exit Sub 'No Maturity Date

        '    Dim itemPrincipal As Double, isDPJ As Boolean = False

        '    If txtPrincipal.Text = "" Or Not IsNumeric(txtPrincipal.Text) Then
        '        itemPrincipal = 0
        '    Else
        '        itemPrincipal = CDbl(txtPrincipal.Text)
        '    End If

        '    Dim matuDateTmp
        '    If Not PT_Entry Is Nothing Then
        '        ' Not for new Loan
        '        'If PawnItem.AdvanceInterest <> 0 Then isDPJ = True
        '        'matuDateTmp = PawnItem.MaturityDate
        '        'intHash = PawnItem.INT_Checksum
        '    Else
        '        'New Loan
        '        isDPJ = True
        '        matuDateTmp = CDate(txtMatu.Text)
        '        intHash = TBLINT_HASH
        '    End If
        '    daltonCompute = New PawnCalculation(itemPrincipal, txtClassification.Text, CurrentDate, matuDateTmp, isDPJ, intHash)

        '    With daltonCompute
        '        daysDue = .DaysOverDue
        '        Net_Amount = .NetAmount
        '        AdvanceInterest = .AdvanceInterest
        '        ServiceCharge = .ServiceCharge
        '        DelayInt = .Interest
        '        Penalty = .Penalty
        '        Renew_Due = .RenewDue
        '        Redeem_Due = .RedeemDue

        '        isOldItem = Not isDPJ
        '        isEarlyRedeem = .isEarlyRedeem

        '    End With

        '    txtNet.Text = Net_Amount.ToString("Php #,##0.00")

        '    'Display Advance Interest for Renew and New Loan
        '    If HAS_ADVINT And (transactionType = "R" Or transactionType = "L") Then
        '        txtAdv.Text = AdvanceInterest.ToString("#,##0.00")
        '    End If

        '    If isDPJ Then
        '        'New Items
        '        If transactionType = "X" Then
        '            ' Redeem
        '            txtService.Text = 0
        '        Else
        '            'Non Redeem
        '            txtService.Text = ServiceCharge.ToString("#,##0.00")
        '        End If
        '    Else
        '        'Remantic
        '        txtService.Text = ServiceCharge.ToString("#,##0.00")
        '    End If

        '    'Non New Loan
        '    If transactionType <> "L" Then
        '        txtOver.Text = daysDue
        '        If daysDue <= 3 Then
        '            If DelayInt > AdvanceInterest Then
        '                DelayInt -= AdvanceInterest
        '            Else
        '                DelayInt = 0
        '            End If
        '            Penalty = 0
        '        Else
        '            If DelayInt > AdvanceInterest And transactionType <> "X" Then _
        '                DelayInt -= AdvanceInterest
        '        End If

        '        If transactionType = "X" Then
        '            txtRenew.Text = 0
        '            txtRedeem.Text = Redeem_Due.ToString("Php #,##0.00")
        '            If daysDue > 3 Then DelayInt -= AdvanceInterest
        '        ElseIf transactionType = "R" Then
        '            txtRenew.Text = Renew_Due.ToString("Php #,##0.00")
        '            txtRedeem.Text = 0
        '            'DelayInt -= AdvanceInterest
        '        End If

        '        txtInt.Text = DelayInt.ToString("#,##0.00")
        '        txtPenalty.Text = Penalty.ToString("#,##0.00")
        '    End If
    End Sub

    Enum DocumentClass As Integer
        Pawnticket = 0
        OfficialReceipt = 1
    End Enum

    Private Sub AddNumber(doc As DocumentClass)
        Select Case doc
            Case DocumentClass.Pawnticket
                currentPawnTicket += 1
                UpdateOptions("PawnLastNum", currentPawnTicket)
            Case DocumentClass.OfficialReceipt
                currentORNumber += 1
                UpdateOptions("ORLastNum", currentORNumber)
        End Select
    End Sub

    Private Function CurrentPTNumber(Optional ByVal num As Integer = 0) As String
        Return String.Format("{0:000000}", If(num = 0, currentPawnTicket, num))
    End Function

    Private Function CurrentOR() As String
        Return String.Format("{0:000000}", currentORNumber)
    End Function

    Private Sub GenerateORNum()
        txtReceipt.Text = CurrentOR()
        txtReceiptDate.Text = CurrentDate.ToString("MM/dd/yyyy")
        txtPrincipal2.Text = txtPrincipal.Text
    End Sub


    Private Sub GeneratePT()
        'Check PT if existing
        Dim mySql As String, ds As DataSet
        'mySql = "SELECT * FROM tblPAWN " 'OLD TABLE
        mySql = "SELECT * FROM OPT "
        mySql &= "WHERE PAWNTICKET = '" & currentPawnTicket & "'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then _
            MsgBox("PT# " & currentPawnTicket.ToString("000000") & " already existed.", MsgBoxStyle.Critical) : unableToSave = True : Exit Sub

        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        dateChange(PawnedItem.ItemClass)

        If transactionType = "R" Then
            txtTicket.Text = CurrentPTNumber(GetOption("PawnLastNum"))
            txtOldTicket.Text = CurrentPTNumber(PT_Entry.PawnTicket)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.frmPawningV2_Client)
        frmClient.Show()
    End Sub

    Private Sub txtClassification_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClassification.KeyPress
        If isEnter(e) Then
            btnSearchClassification.PerformClick()
        End If
    End Sub

    Private Sub txtPrincipal_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtPrincipal.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            cboAppraiser.Focus()
            cboAppraiser.DroppedDown = True
        End If
    End Sub

    Private Sub frmPawningItemNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadAppraisers()

        ' If transactionType = "L" Then NewLoan()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtCustomer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyDown
        If e.KeyCode = 13 Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub cboAppraiser_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles cboAppraiser.KeyPress
        If lblAuth.Text = "Verified" Then
            If Not cboAppraiser.DroppedDown Then
                btnSave.PerformClick()
            End If
        End If
    End Sub

    Private Sub cboAppraiser_LostFocus(sender As Object, e As System.EventArgs) Handles cboAppraiser.LostFocus
        CheckAuth()
    End Sub

    Private Sub cboAppraiser_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cboAppraiser.SelectedIndexChanged
        If POSuser.UserName = cboAppraiser.Text Then
            lblAuth.Text = "Verified"
            mod_system.isAuthorized = True
        Else
            mod_system.isAuthorized = False
            lblAuth.Text = "Unverified"
            Exit Sub
        End If
    End Sub

    Friend Sub Load_PawnTicket(pt As PawnTicket2)
        LoadClient(pt.Pawner)


        Load_ItemSpecification(pt.PawnItem.ItemClass)

        Dim i As Integer = 0
        For Each pawnSpec As PawnItemSpec In pt.PawnItem.PawnItemSpecs
            lvSpec.Items(i).SubItems(1).Text = pawnSpec.SpecsValue
            i += 1
        Next

        txtTicket.Text = CurrentPTNumber(pt.PawnTicket)
        txtOldTicket.Text = pt.OldTicket
        txtLoan.Text = pt.LoanDate
        txtMatu.Text = pt.MaturityDate
        txtExpiry.Text = pt.ExpiryDate
        txtAuction.Text = pt.AuctionDate

        txtAppr.Text = pt.Appraisal.ToString("#,##0.00")
        txtPrincipal.Text = pt.Principal.ToString("#,##0.00")
        txtAdv.Text = pt.AdvanceInterest.ToString("#,##0.00")
        txtNet.Text = pt.NetAmount.ToString("#,##0.00")
        txtService.Text = pt.ServiceCharge.ToString("#,##0.00")

        txtReceipt.Text = IIf(pt.ORNumber = 0, "", pt.ORNumber)
        txtReceiptDate.Text = IIf(pt.ORDate = #12:00:00 AM#, "", pt.ORDate)
        txtPrincipal2.Text = IIf(pt.Principal = 0, "", pt.Principal)

        cboAppraiser.Text = GetNameByID(pt.AppraiserID, Appraisers_ht)

        txtOver.Text = pt.DaysOverDue
        txtInt.Text = pt.DelayInterest
        txtPenalty.Text = pt.Penalty
        txtService.Text = pt.ServiceCharge

        txtRenew.Text = pt.RenewDue
        txtRedeem.Text = pt.RedeemDue

        'Disable
        txtCustomer.ReadOnly = True
        btnSearch.Enabled = False
        txtClassification.Enabled = False
        btnSearchClassification.Enabled = False
        txtAppr.Enabled = False
        txtPrincipal.Enabled = False
        cboAppraiser.Enabled = False

        PT_Entry = pt
        PRINT_PTOLD = pt.OldTicket
        PRINT_PTNEW = pt.PawnTicket

        mod_system.isAuthorized = True
        If transactionType = "D" Then
            LockFields(True)
            btnSave.Enabled = False : btnRenew.Enabled = True
            btnRedeem.Enabled = True : btnPrint.Enabled = True
            btnVoid.Enabled = True : btnAddCoi.Enabled = False
        End If

        ChangeForm()
        If PT_Entry.Status = "R" Then Me.Text &= " [RENEW]"
        If PT_Entry.Status = "0" Then Me.Text &= " [INACTIVE/RENEWED]"
        If PT_Entry.Status = "X" Then Me.Text &= " [REDEEMED]"
        If PT_Entry.Status = "S" Then Me.Text &= " [SEGREGATED]"
        If PT_Entry.Status = "W" Then Me.Text &= " [WITHDRAW] - Pull Out: " & PT_Entry.PawnItem.WithdrawDate.ToShortDateString
        If PT_Entry.Status = "V" Then Me.Text &= " [VOIDED]"

        Select Case pt.Status
            Case "0", "S", "W", "V"
                LockFields(1)
            Case "X"
                LockFields(1)
                Authorization()
        End Select
    End Sub

    Private Sub Authorization()
        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub

    Private Function CheckAuth() As Boolean
        If transactionType <> "L" And cboAppraiser.Text = "" Then mod_system.isAuthorized = True

        If Not mod_system.isAuthorized And cboAppraiser.Text <> "" Then
            'diagAuthorization.TopMost = True
            diagAuthorization.txtUser.Text = cboAppraiser.Text
            diagAuthorization.fromForm = Me
                diagAuthorization.Show()
            Return False
        End If

        If unableToSave Then Return False
        If Pawner Is Nothing Then
            txtCustomer.SelectAll()
            txtCustomer.Focus()

            Return False
        End If
        Return True
    End Function

    Friend Sub Redeem()
        transactionType = "X"
        'GeneratePT()

        ReComputeInterest()
        grpClaimer.Enabled = True

        lblTransaction.Text = "Redemption"
    End Sub

    Friend Sub Renew()
        transactionType = "R"
        GeneratePT()

        ReComputeInterest()
        grpClaimer.Enabled = True

        lblTransaction.Text = "Renewal"
    End Sub

    Friend Sub NewLoan()
        ClearFields()

        Pawner = Nothing
        PT_Entry = New PawnTicket2
        PawnedItem = New PawnItem
        lvSpec.Enabled = True

        cboAppraiser.SelectedIndex = -1
        GeneratePT()

        'Disable Stuff
        btnRenew.Enabled = False
        btnRedeem.Enabled = False
        btnVoid.Enabled = False
        btnPrint.Enabled = False
        grpClaimer.Enabled = False
    End Sub

    Private Sub txtAppr_KeyPress(sender As Object, e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppr.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            txtPrincipal.Focus()
        End If
    End Sub

    Private Sub tmrVerifier_Tick(sender As System.Object, e As System.EventArgs) Handles tmrVerifier.Tick
        If mod_system.isAuthorized Then
            lblAuth.Text = "Verified"
        Else
            lblAuth.Text = "Unverified"
        End If
    End Sub

    Private Sub btnRenew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRenew.Click
        If transactionType = "R" Then
            btnRenew.Text = "Rene&w"
            txtRenew.BackColor = Drawing.SystemColors.Control
            transactionType = "D"
            btnSave.Enabled = False
            btnPrint.Enabled = True
            btnAddCoi.Enabled = False
            Load_PawnTicket(PT_Entry)
            Exit Sub
        End If
        If transactionType <> "D" Then
            MsgBox("Please press cancel to switch transaction mode", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Renew()
        btnPrint.Enabled = False
        btnSave.Enabled = True
        btnAddCoi.Enabled = True
        btnRenew.Text = "&Cancel"

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

    Private Function GetInt(ByVal days As Integer, Optional ByVal tbl As String = "Interest") As Double
        Dim mySql As String = "SELECT * FROM tblItem WHERE UPPER(ITEMCLASS) = UPPER('" & txtClassification.Text & "')"
        Dim ds As DataSet = LoadSQL(mySql), TypeInt As Double
        Dim tmpSchemeID As String = ds.Tables(0).Rows(0).Item("SCHEME_ID")

        Dim sqlScheme As String = "SELECT  I.SCHEMENAME, I.DESCRIPTION, D.DAYFROM, D.DAYTO, "
        sqlScheme &= "D.INTEREST, D.PENALTY, D.REMARKS FROM TBLINTSCHEMES I INNER JOIN TBLINTSCHEME_DETAILS D ON I.SCHEMEID = D.SCHEMEID "
        sqlScheme &= "Where I.SCHEMEID ='" & tmpSchemeID & "'"

        Dim SchemeDs As DataSet = LoadSQL(sqlScheme)
        For Each dr As DataRow In SchemeDs.Tables(0).Rows
            Dim min As Integer = 0, max As Integer = 0
            min = dr.Item("DayFrom") : max = dr.Item("DayTo")

            Select Case days
                Case min To max
                    TypeInt = dr.Item(tbl)
                    'Console.WriteLine(tbl & " is now " & TypeInt & " for " & cboType.Text)
                    Return TypeInt
            End Select
        Next

        Return 0
    End Function

    ' TODO: JUNMAR
    ' PLEASE CHECK IF THIS IS STILL WORKING
    Private Function DisplayComputation(ByVal PTInfo As PawnTicket2, ByVal type As String) As String
        Dim disp As String

        disp = ""
        Dim Dc As PawnCompute
        Dim monthCnt As Integer = 30

        If Not isRenewable(PTInfo) And type = "Renew" Then Return "NON RENEWABLE"

        Dim diff = PTInfo.AuctionDate - PTInfo.LoanDate
        Dim lessNum As Integer = DateDiff(DateInterval.Day, PTInfo.LoanDate, PTInfo.AuctionDate)
        lessNum = lessNum / 30
        If Not lessNum < MONTH_COMPUTE Then
            lessNum = MONTH_COMPUTE
        End If

        Dim isDJ As Boolean = IIf(PTInfo.AdvanceInterest <> 0, True, False)

        For x As Integer = 0 To lessNum - 1
            'Dim Dc As PawnCompute
            Dim isDPJ As Boolean = True

            If transactionType <> "L" Then
                'REMANTIC NO ADVANCE INTEREST
                If PT_Entry.AdvanceInterest = 0 Then
                    isDPJ = False
                End If
            End If

            Try
                Dc = New PawnCompute _
                (PTInfo.Principal, PTInfo.PawnItem.ItemClass.InterestScheme, PTInfo.LoanDate.AddDays(monthCnt), PTInfo.MaturityDate, isDPJ)
            Catch ex As Exception
                Console.WriteLine(ex.Message)
            End Try

            Dim prefix As String = ""
            Select Case x
                Case 0
                    If isDJ Then
                        prefix = "AdvInt "
                    Else
                        prefix = "DelayInt "
                    End If
                Case 1
                    prefix = "2ndMon "
                Case 2
                    prefix = "3rdMon "
                Case 3
                    prefix = "4thMon "
                Case 4
                    prefix = "5thMon "
            End Select

            Select Case type
                Case "Renew"
                    disp &= String.Format("{1}{0:#,##0.00} / ", Dc.RenewDue, prefix)
                Case "Redeem"
                    disp &= String.Format("{1}{0:#,##0.00} / ", Dc.RedeemDue, prefix)
                Case Else
                    Return "INVALID TYPE"
            End Select
            monthCnt += 30
        Next

        Return disp
    End Function

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Reprint = True
        SaveReprint()
        If PT_Entry.Status = "L" Or PT_Entry.Status = "R" Then
            PrintNewLoan()
        End If

        If PT_Entry.Status = "0" Then
            PrintNewLoan()
            do_RenewOR()
        End If

        If PT_Entry.Status = "X" Then
            do_RedeemOR()
        End If

    End Sub

    Private Function isRenewable(ByVal pt As PawnTicket2) As Boolean
        Dim mySql As String = "SELECT * FROM tblItem WHERE "
        mySql &= "UPPER(ITEMCLASS) = UPPER('" & pt.PawnItem.ItemClass.ClassName & "')"
        Dim ds As DataSet = LoadSQL(mySql, "tblItem")
        Dim tmpIsRenew As Boolean
        Select Case ds.Tables(0).Rows(0).Item("ISRENEW")
            Case 1
                tmpIsRenew = True
            Case 0
                tmpIsRenew = False
        End Select

        Return tmpIsRenew
    End Function

    Private Sub LockFields(ByVal st As Boolean)
        txtCustomer.ReadOnly = st
        btnSearch.Enabled = Not st
        txtAppr.Enabled = Not st
        txtPrincipal.Enabled = Not st
        cboAppraiser.Enabled = Not st
        btnRenew.Enabled = Not st
        btnRedeem.Enabled = Not st
        If POSuser.canVoid Then btnVoid.Enabled = Not st
        btnSave.Enabled = Not st
        lvSpec.Enabled = Not st
        btnAddCoi.Enabled = Not st
    End Sub

    Private Sub PrintNewLoan()
        Dim ans As DialogResult = _
            MsgBox("Do you want to print?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2, "Print")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim autoPrintPT As Reporting
        'On Error Resume Next

        Dim printerName As String = PRINTER_PT
        If Not canPrint(printerName) Then Exit Sub

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String, dsName As String = "dsPawnTicket"
        mySql = "SELECT * FROM PAWN_LIST WHERE PAWNID = " & PT_Entry.PawnID
        If PT_Entry.PawnID = 0 Then mySql = "SELECT * FROM PAWN_LIST ORDER BY PAWNID DESC ROWS 1"
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        Dim pt As Integer = ds.Tables(0).Rows(0).Item("PAWNID")
        PT_Entry.Load_PTid(pt)

        report.ReportPath = "Reports\layout01.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        Dim addParameters As New Dictionary(Of String, String)
        'If isOldItem Then
        '    addParameters.Add("txtDescription", PT_Entry.Description)
        'Else
        '    addParameters.Add("txtDescription", pawning.DisplayDescription(PawnItem))
        'End If
        If PT_Entry.Description Is Nothing Then
            addParameters.Add("txtDescription", "N/A")
        Else
            addParameters.Add("txtDescription", PT_Entry.DescriptionWithAppraiser)
        End If
        addParameters.Add("txtItemInterest", GetInt(30) * 100)
        addParameters.Add("txtUsername", POSuser.FullName)

        Dim total As Double
        total = PT_Entry.AdvanceInterest + PT_Entry.ServiceCharge
        total = total * GetInt(30)
        total = total / PT_Entry.NetAmount
        total = total * 100

        total = Math.Round(total, 2, MidpointRounding.AwayFromZero)
        addParameters.Add("txtRateInPercent", total)

        If Reprint = True Then
            addParameters.Add("txtReprint", "Reprint")
        Else
            addParameters.Add("txtReprint", " ")
        End If


        ' Add Monthly Computation
        Dim strCompute As String

        strCompute = "Renew: " & DisplayComputation(PT_Entry, "Renew")
        Console.WriteLine(strCompute)
        addParameters.Add("txtRenewCompute", strCompute)
        strCompute = "Redeem: " & DisplayComputation(PT_Entry, "Redeem")
        Console.WriteLine(strCompute)
        addParameters.Add("txtRedeemCompute", strCompute)

        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        If DEV_MODE Then
            frmReport.ReportInit(mySql, dsName, report.ReportPath, addParameters, False)
            frmReport.Show()
        Else
            autoPrintPT.Export(report)
            autoPrintPT.m_currentPageIndex = 0
            autoPrintPT.Print(printerName)
        End If

        Me.Focus()
    End Sub

    Private Sub PrintRenew()
        Dim ans As DialogResult = _
            MsgBox("Do you want to print?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + vbDefaultButton2, "Print")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        PrintRenewPT()
        If Not PAUSE_OR Then do_RenewOR()
    End Sub

    Private Sub PrintRenewPT()
        Dim autoPrintPT As Reporting

        Dim printerName As String = PRINTER_PT
        If Not canPrint(printerName) Then Exit Sub

        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting


        Dim mySql As String, dsName As String = "dsRenewPT"
        'mySql = "SELECT * FROM PRINT_PAWNING WHERE PAWNID = " & PawnItem.PawnID
        mySql = "SELECT * FROM PAWN_LIST ORDER BY PAWNID DESC ROWS 1"
        Dim ds As DataSet = LoadSQL(mySql, dsName)

        report.ReportPath = "Reports\layout03.rdlc"
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))

        Dim addParameters As New Dictionary(Of String, String)
        'If isOldItem Then
        '    addParameters.Add("txtDescription", PT_Entry.Description)
        'Else
        '    addParameters.Add("txtDescription", pawning.DisplayDescription(PawnItem))
        'End If
        If PT_Entry.Description Is Nothing Then
            addParameters.Add("txtDescription", "N/A")
        Else
            addParameters.Add("txtDescription", PT_Entry.DescriptionWithAppraiser)
        End If
        addParameters.Add("txtInterest", PT_Entry.AdvanceInterest)
        addParameters.Add("txtServiceCharge", PT_Entry.ServiceCharge / 2)
        addParameters.Add("txtItemInterest", GetInt(30) * 100)
        addParameters.Add("txtOLDPT", "PT# " & PT_Entry.OldTicket.ToString("000000"))
        addParameters.Add("txtUsername", POSuser.FullName)

        Dim total As Double
        total = PT_Entry.AdvanceInterest + PT_Entry.ServiceCharge
        total = total * GetInt(30)
        total = total / PT_Entry.NetAmount
        total = total * 100

        total = Math.Round(total, 2, MidpointRounding.AwayFromZero)
        addParameters.Add("txtRateInPercent", total)

        ' Add Monthly Computation
        Dim strCompute As String
        strCompute = "Renew: " & DisplayComputation(PT_Entry, "Renew")
        Console.WriteLine(strCompute)
        addParameters.Add("txtRenewCompute", strCompute)
        strCompute = "Redeem: " & DisplayComputation(PT_Entry, "Redeem")
        Console.WriteLine(strCompute)
        addParameters.Add("txtRedeemCompute", strCompute)

        If Not addParameters Is Nothing Then
            For Each nPara In addParameters
                Dim tmpPara As New ReportParameter
                tmpPara.Name = nPara.Key
                tmpPara.Values.Add(nPara.Value)
                report.SetParameters(New ReportParameter() {tmpPara})
                Console.WriteLine(String.Format("{0}: {1}", nPara.Key, nPara.Value))
            Next
        End If

        Try
            If DEV_MODE Then
                frmReport.ReportInit(mySql, dsName, report.ReportPath, addParameters, False)
                frmReport.Show()
            Else
                autoPrintPT.Export(report)
                autoPrintPT.m_currentPageIndex = 0
                autoPrintPT.Print(printerName)
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "PRINT FAILED")
            Log_Report("PRINT FAILED: " & ex.ToString)
        End Try

        Me.Focus()
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.VoidPawning
            If Not CheckOTP() Then Exit Sub
        Else
            VoidPawning()
        End If
    End Sub

    Friend Sub VoidPawning()
        Dim ans As DialogResult = _
           MsgBox("Do you want to VOID this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.Critical + vbDefaultButton2, "W A R N I N G")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim transDate As Date
        If PT_Entry.Status = "X" Then
            transDate = PT_Entry.ORDate
        ElseIf PT_Entry.Status = "L" Then
            transDate = PT_Entry.LoanDate
        Else
            transDate = PT_Entry.LoanDate
        End If

        If CurrentDate.Date <> transDate Then
            MsgBox("Unable to void transaction NOT on the same date.", MsgBoxStyle.Critical)
            Exit Sub
        End If

        If lblNPT.Visible Then MsgBox("Inactive Transaction", MsgBoxStyle.Critical) : Exit Sub
        PT_Entry.VoidCancelTicket()

        MsgBox("Transaction Voided", MsgBoxStyle.Information)
        'frmPawning.LoadActive()
        Me.Close()
    End Sub

    Private Sub btnRedeem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRedeem.Click
        If transactionType = "X" Then
            btnRedeem.Text = "&Redeem"
            txtRedeem.BackColor = Drawing.SystemColors.Control
            transactionType = "D"
            btnSave.Enabled = False
            btnPrint.Enabled = True
            btnAddCoi.Enabled = False

            Load_PawnTicket(PT_Entry)
            Exit Sub
        End If
        If transactionType <> "D" Then
            MsgBox("Please press cancel to switch transaction mode", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Redeem()
        btnPrint.Enabled = False
        btnSave.Enabled = True
        btnRedeem.Text = "&Cancel"
        btnAddCoi.Enabled = True
    End Sub

    Private Sub do_RenewOR()
        For i As Integer = 1 To OR_COPIES
            PrintRenewOR2()
            System.Threading.Thread.Sleep(1000)
        Next
    End Sub

    Private Sub PrintRenewOR2()
        Dim autoPrintPT As Reporting
        Dim printerName As String = PRINTER_OR
        If Not DEV_MODE Then If Not canPrint(printerName) Then Exit Sub
        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String, ptIDx As Single = PT_Entry.PawnID
        mySql = "SELECT * FROM PAWN_LIST WHERE PAWNID = " & ptIDx
        Dim dsName As String = "dsPawn"
        Dim ds As DataSet = LoadSQL(mySql, dsName)
        Dim paymentStr As String, descStr As String
        Dim rptPath As String
        rptPath = "Reports\_layout03.rdlc"
        Dim addParameters As New Dictionary(Of String, String)

        report.ReportPath = rptPath
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))
        PT_Entry.Load_PTid(ptIDx)

        descStr = _
            String.Format("Renewal of PT# {0:000000}" + vbCrLf + _
                          "New PT# {1:000000}", PRINT_PTOLD, PRINT_PTNEW)

        paymentStr = _
        String.Format("PT# {0:000000} with a payment amount of Php {1:#,##0.00}", PT_Entry.PawnTicket, PT_Entry.RenewDue)
        addParameters.Add("txtPayment", paymentStr)
        addParameters.Add("dblTotalDue", PT_Entry.RenewDue)
        addParameters.Add("txtDescription", descStr)
        addParameters.Add("txtCoi", GetTotalCoi(String.Format("PT#{0:000000}", PRINT_PTNEW)))

        If Reprint = True Then
            addParameters.Add("txtReprint", "Reprint")
        Else
            addParameters.Add("txtReprint", " ")
        End If

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
        paperSize.Add("height", 4.5) 'Reprint only

        If DEV_MODE And 0 Then
            frmReport.ReportInit(mySql, dsName, rptPath, addParameters, False)
            frmReport.Show()

            Exit Sub
        End If

        Try
            autoPrintPT.Export(report, paperSize)
            autoPrintPT.m_currentPageIndex = 0
            autoPrintPT.Print(printerName)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "PRINT FAILED")
            Log_Report("PRINT FAILED: " & ex.ToString)
        End Try
    End Sub

    Private Sub do_RedeemOR()
        Dim ans As DialogResult = _
            MsgBox("Do you want to print?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + vbDefaultButton2, "Print")
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        For cnt As Integer = 1 To OR_COPIES
            PrintRedeemOR2()
            System.Threading.Thread.Sleep(1000)
        Next
    End Sub

    Private Sub PrintRedeemOR2()
        Dim autoPrintPT As Reporting
        Dim printerName As String = PRINTER_OR
        If Not DEV_MODE Then If Not canPrint(printerName) Then Exit Sub
        Dim report As LocalReport = New LocalReport
        autoPrintPT = New Reporting

        Dim mySql As String, ptIDx As Single = PT_Entry.PawnID
        mySql = "SELECT * FROM PAWN_LIST WHERE PAWNID = " & ptIDx
        Dim dsName As String = "dsPawn"
        Dim ds As DataSet = LoadSQL(mySql, dsName)
        Dim paymentStr As String, descStr As String
        Dim rptPath As String
        rptPath = "Reports\_layout03.rdlc"
        Dim addParameters As New Dictionary(Of String, String)

        report.ReportPath = rptPath
        report.DataSources.Add(New ReportDataSource(dsName, ds.Tables(dsName)))
        PT_Entry.Load_PTid(ptIDx)

        descStr = _
            String.Format("REDEMPTION OF PT# {0:000000}", PT_Entry.PawnTicket)
        paymentStr = _
        String.Format("PT# {0:000000} with a payment amount of Php {1:#,##0.00}", PT_Entry.PawnTicket, PT_Entry.RedeemDue)
        addParameters.Add("txtPayment", paymentStr)
        addParameters.Add("dblTotalDue", PT_Entry.RedeemDue)
        addParameters.Add("txtDescription", descStr)
        addParameters.Add("txtCoi", GetTotalCoi(String.Format("PT#{0:000000}", PT_Entry.PawnTicket)))

        If Reprint = True Then
            addParameters.Add("txtReprint", "Reprint")
        Else
            addParameters.Add("txtReprint", " ")
        End If

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
        paperSize.Add("height", 4.5) 'Reprint only

        If DEV_MODE Then

            frmReport.ReportInit(mySql, dsName, rptPath, addParameters, Nothing)
            frmReport.Show()

            Exit Sub
        End If

        Try
            autoPrintPT.Export(report, paperSize)
            autoPrintPT.m_currentPageIndex = 0
            autoPrintPT.Print(printerName)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "PRINT FAILED")
            Log_Report("PRINT FAILED: " & ex.ToString)
        End Try
    End Sub

    Private Sub GroupBox6_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox6.DoubleClick
        If DEV_MODE Then
            Console.WriteLine(PT_Entry.DescriptionBuilder())
        End If
    End Sub

    Private Sub txtClaimer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClaimer.KeyPress
        If isEnter(e) Then
            btnSearchClaimer.PerformClick()
        End If
    End Sub

    Private Sub SaveReprint()
        Dim mysql As String = "SELECT * FROM TBLREPRINT "
        Dim ds As DataSet = LoadSQL(mysql, "TBLREPRINT")
        Dim dsNewRow As DataRow, transname As String
        dsNewRow = ds.Tables("TBLREPRINT").NewRow
        With dsNewRow
            .Item("PAWNTICKET") = PT_Entry.PawnTicket
            Select Case PT_Entry.Status
                Case "X"
                    transname = "Redeem"
                Case "L"
                    transname = "New Loan"
                Case "0"
                    transname = "Renewed"
                Case "R"
                    transname = "Renew"
                Case "S"
                    transname = "Segre"
                Case Else
                    transname = PT_Entry.Status
            End Select
            .Item("TRANSNAME") = transname
            .Item("Reprint_At") = Now
            .Item("Reprint_By") = POSuser.UserID
        End With
        ds.Tables("TBLREPRINT").Rows.Add(dsNewRow)
        database.SaveEntry(ds)
    End Sub

    Private Sub txtPrincipal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrincipal.Leave
        ReComputeInterest()
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

    Private Sub txtAppr_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppr.Leave
        ReComputeInterest()
    End Sub

    Private Function GetTotalCoi(ByVal Ticket As String) As Integer
        Dim mysql As String = "Select Sum(Amount)as Amount from tblInsurance Where PAWNTICKET = '" & Ticket & "'"
        Dim fillData As String = "tblInsurance"
        Dim ds As DataSet = LoadSQL(mysql, fillData)
        If IsDBNull(ds.Tables(0).Rows(0).Item("Amount")) Then Return 0
        Return ds.Tables(0).Rows(0).Item("Amount")
    End Function

    Private Sub btnAddCoi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddCoi.Click
        If Not isValid() Then Exit Sub
        frmAddCoi.Show()
        frmAddCoi.Ticket = txtTicket.Text
    End Sub
End Class