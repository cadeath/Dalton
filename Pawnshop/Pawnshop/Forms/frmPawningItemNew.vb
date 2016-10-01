Imports Microsoft.Reporting.WinForms

Public Class frmPawningItemNew
    Friend PawnCustomer As Client
    Friend PawnClaimer As Client
    Friend PawnItem As ItemClass
    Friend transactionType As String = "L"
    Private PawnCalc As PawnCompute

    Friend PT_Entry As New PawnTicket2
    Private appraiser As Hashtable
    Private PawnInfo() As Hashtable
    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private currentORNumber As Integer = GetOption("ORLastNum")
    Private TypeInt As Double, bug As Boolean = False
    Private daysDue As Integer
    Private isOldItem As Boolean = False
    Private AdvanceInterest As Double, DelayInt As Double, ServiceCharge As Double
    Private ItemPrincipal As Double, Penalty As Double, Net_Amount As Double
    Private Renew_Due As Double, Redeem_Due As Double

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

    Private isEarlyRedeem As Boolean = False
    Private earlyDays As Integer = 0
    Private unableToSave As Boolean = False
    Private daltonCompute As PawnCalculation

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

    Private selected_ClassSpecs As Hashtable
    Private new_PawnItem As New PawnItem

    Private Sub ClearFields()
        mod_system.isAuthorized = False

        txtCustomer.Text = ""
        txtAddr.Text = ""
        txtBDay.Text = ""
        txtContact.Text = ""
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

        txtClassification.Text = ""
        txtClaimer.Clear()

    End Sub

    Private Function GetAppraiserID(ByVal name As String) As Integer
        For Each el As DictionaryEntry In appraiser
            If el.Value = name Then
                Return el.Key
            End If
        Next

        Return 0
    End Function

    Private Sub LoadAppraisers()
        'Dim mySql As String = "SELECT * FROM tbl_Gamit WHERE PRIVILEGE <> 'PDuNxp8S9q0=' AND STATUS <> 0"
        'Dim ds As DataSet = LoadSQL(mySql)

        'appraiser = New Hashtable
        'cboAppraiser.Items.Clear()
        'For Each dr As DataRow In ds.Tables(0).Rows
        '    Dim tmpUser As New ComputerUser
        '    tmpUser.LoadUserByRow(dr)
        '    If tmpUser.canAppraise Then
        '        Console.WriteLine(tmpUser.FullName & " loaded.")
        '        appraiser.Add(tmpUser.UserID, tmpUser.UserName)
        '        cboAppraiser.Items.Add(tmpUser.UserName)
        '    End If
        'Next
    End Sub

    Private Sub btnSearchClassification_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClassification.Click
        Dim secured_str As String = txtClassification.Text
        secured_str = DreadKnight(secured_str)
        frmItemList.SearchSelect(secured_str, FormName.Item)
        frmItemList.Show()
    End Sub

    Private Sub btnSearchClaimer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchClaimer.Click
        Dim secured_str As String = txtClaimer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.PawnClaimer)
        frmClient.Show()
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        txtContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        PawnCustomer = cl
        txtClassification.Focus()
    End Sub

    Friend Sub LoadCliamer(ByVal cl As Client)
        txtClaimer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        PawnClaimer = cl
    End Sub

    Friend Sub LoadItem(ByVal Item As ItemClass)

        new_PawnItem.ItemClass = Item
        txtClassification.Text = Item.ClassName

        selected_ClassSpecs = New Hashtable
        lvSpec.Items.Clear()
        For Each spec As ItemSpecs In Item.ItemSpecifications
            Dim lv As ListViewItem = lvSpec.Items.Add(spec.SpecName)
            lv.SubItems.Add("")
            selected_ClassSpecs.Add(spec.SpecID, spec.SpecName)
        Next
    End Sub

    Private Sub AddItem(ByVal cio As DataRow)
        Dim tmpItem As New ItemSpecs
        tmpItem.LoadItemSpecs_row(cio)

        Dim lv As ListViewItem = lvSpec.Items.Add(tmpItem.SpecID)
        lv.SubItems.Add(tmpItem.SpecName)
        lv.SubItems.Add(tmpItem.SpecLayout)
        lv.SubItems.Add(tmpItem.SpecType)
        lv.SubItems.Add("")
        'lv.SubItems.Add(tmpCIO.Amount)
        'lv.SubItems.Add(tmpCIO.Particulars)
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
        Dim selectedID As Integer = GetIDbyName(lvSpec.FocusedItem.Text, selected_ClassSpecs)
        tmpSpec.LoadItemSpecs(selectedID)

        Select Case tmpSpec.SpecLayout
            Case "TextBox"
                frm_PanelTextbox.retID = idx
                frm_PanelTextbox.inputType = tmpSpec.SpecType
                frm_PanelTextbox.ShowDialog()
            Case "Yes/No"
                frm_PanelYesNo.retID = idx
                frm_PanelYesNo.ShowDialog()
            Case "MultiLine"
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveNewLoan()
    End Sub
    Private Sub SaveNewLoan()
        Dim pawnSpecs As New CollectionPawnItemSpecs
        PawnItem.LoadItem(PawnItem.ID)
        Dim i As Integer = 0
        For Each spec As ItemSpecs In PawnItem.ItemSpecifications
            Dim spc As New PawnItemSpec

            spc.UnitOfMeasure = spec.UnitOfMeasure
            spc.SpecName = spec.SpecName
            spc.SpecType = spec.SpecType
            spc.SpecsValue = lvSpec.Items(i).SubItems(1).Text
            spc.isRequired = spec.isRequired
            pawnSpecs.Add(spc)

            i += 1
        Next

        Dim newItem As New PawnItem
        With newItem
            .ItemID = PawnItem.ID
            '.ItemClass = txtClassification.Text
            '.SchemeID = tmpItem.SchemeID
            .Status = "A"
            .PawnItemSpecs = pawnSpecs

            .Save_PawnItem()
        End With

        Dim tmpPawnTicket As PawnTicket2 = New PawnTicket2
        With tmpPawnTicket
            .PawnTicket = txtTicket.Text
            .LoanDate = txtLoan.Text
            .MaturityDate = txtMatu.Text
            .ExpiryDate = txtExpiry.Text
            .AuctionDate = txtAuction.Text
            .Appraisal = txtAppr.Text
            .Principal = txtPrincipal.Text
            .NetAmount = txtNet.Text
            .AppraiserID = GetAppraiserID(cboAppraiser.Text)
            .EncoderID = POSuser.UserID
            .ClaimerID = PawnClaimer.ID
            .ClientID = PawnCustomer.ID
            .PawnItem = newItem

            .Save_PawnTicket()
        End With

    End Sub


    Private Sub dateChange(selectedClass As ItemClass)
        Select Case selectedClass.Category
            Case "GADGET"
                txtExpiry.Text = txtMatu.Text
                txtAuction.Text = CurrentDate.AddDays(62).ToShortDateString
            Case Else
                txtExpiry.Text = CurrentDate.AddDays(119).ToShortDateString
                txtAuction.Text = CurrentDate.AddDays(152).ToShortDateString
        End Select

        ReComputeInterest()
    End Sub

    Private Sub Assembling_Transactions()

    End Sub


    Private Sub ReComputeInterest()
        Dim intHash As String = ""

        If transactionType = "D" Then Exit Sub 'Display No Recommute
        If txtMatu.Text = "" Then Exit Sub 'No Maturity Date

        Dim itemPrincipal As Double, isDPJ As Boolean = False

        If txtPrincipal.Text = "" Or Not IsNumeric(txtPrincipal.Text) Then
            itemPrincipal = 0
        Else
            itemPrincipal = CDbl(txtPrincipal.Text)
        End If

        Dim matuDateTmp
        If Not PT_Entry Is Nothing Then
            ' Not for new Loan
            'If PawnItem.AdvanceInterest <> 0 Then isDPJ = True
            'matuDateTmp = PawnItem.MaturityDate
            'intHash = PawnItem.INT_Checksum
        Else
            'New Loan
            isDPJ = True
            matuDateTmp = CDate(txtMatu.Text)
            intHash = TBLINT_HASH
        End If
        daltonCompute = New PawnCalculation(itemPrincipal, txtClassification.Text, CurrentDate, matuDateTmp, isDPJ, intHash)

        With daltonCompute
            daysDue = .DaysOverDue
            Net_Amount = .NetAmount
            AdvanceInterest = .AdvanceInterest
            ServiceCharge = .ServiceCharge
            DelayInt = .Interest
            Penalty = .Penalty
            Renew_Due = .RenewDue
            Redeem_Due = .RedeemDue

            isOldItem = Not isDPJ
            isEarlyRedeem = .isEarlyRedeem

        End With

        txtNet.Text = Net_Amount.ToString("Php #,##0.00")

        'Display Advance Interest for Renew and New Loan
        If HAS_ADVINT And (transactionType = "R" Or transactionType = "L") Then
            txtAdv.Text = AdvanceInterest.ToString("#,##0.00")
        End If

        If isDPJ Then
            'New Items
            If transactionType = "X" Then
                ' Redeem
                txtService.Text = 0
            Else
                'Non Redeem
                txtService.Text = ServiceCharge.ToString("#,##0.00")
            End If
        Else
            'Remantic
            txtService.Text = ServiceCharge.ToString("#,##0.00")
        End If

        'Non New Loan
        If transactionType <> "L" Then
            txtOver.Text = daysDue
            If daysDue <= 3 Then
                If DelayInt > AdvanceInterest Then
                    DelayInt -= AdvanceInterest
                Else
                    DelayInt = 0
                End If
                Penalty = 0
            Else
                If DelayInt > AdvanceInterest And transactionType <> "X" Then _
                    DelayInt -= AdvanceInterest
            End If

            If transactionType = "X" Then
                txtRenew.Text = 0
                txtRedeem.Text = Redeem_Due.ToString("Php #,##0.00")
                If daysDue > 3 Then DelayInt -= AdvanceInterest
            ElseIf transactionType = "R" Then
                txtRenew.Text = Renew_Due.ToString("Php #,##0.00")
                txtRedeem.Text = 0
                'DelayInt -= AdvanceInterest
            End If

            txtInt.Text = DelayInt.ToString("#,##0.00")
            txtPenalty.Text = Penalty.ToString("#,##0.00")
        End If
    End Sub

    Private Function CurrentPTNumber(Optional ByVal num As Integer = 0) As String
        Return String.Format("{0:000000}", If(num = 0, currentPawnTicket, num))
    End Function

    Private Function CurrentOR() As String
        Return String.Format("{0:000000}", currentORNumber)
    End Function

    ''' <summary>
    ''' This is call when you wanted to generate new PawnTicket Number Sequence
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub GeneratePT()
        'Check PT if existing
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblPAWN "
        mySql &= "WHERE PAWNTICKET = '" & currentPawnTicket & "'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then _
            MsgBox("PT# " & currentPawnTicket.ToString("000000") & " already existed.", MsgBoxStyle.Critical) : unableToSave = True : Exit Sub

        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        'dateChange(txtClassification.Text)

        If transactionType = "R" Then
            txtTicket.Text = CurrentPTNumber(GetOption("PawnLastNum"))
            txtOldTicket.Text = CurrentPTNumber(PT_Entry.PawnTicket)
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim secured_str As String = txtCustomer.Text
        secured_str = DreadKnight(secured_str)
        frmClient.SearchSelect(secured_str, FormName.NewPawning)
        frmClient.Show()
    End Sub

    Private Sub txtClassification_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtClassification.KeyPress
        If isEnter(e) Then
            btnSearchClassification.PerformClick()
        End If
    End Sub

    Private Sub txtPrincipal_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrincipal.KeyUp
        ReComputeInterest()
    End Sub

    Private Sub frmPawningItemNew_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadAppraisers()
        'If transactionType = "L" Then NewLoan()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtCustomer_KeyDown(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles txtCustomer.KeyDown
        If e.KeyCode = 13 Then
            btnSearch.PerformClick()
        End If
    End Sub

End Class