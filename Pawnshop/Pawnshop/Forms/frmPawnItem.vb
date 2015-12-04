Public Class frmPawnItem
    'Version 2.2
    ' - Remake SAVE
    'Version 2.1
    ' - Fixing Auth
    ' - Fixing GUI

    Friend transactionType As String = "L"
    Friend PawnItem As PawnTicket
    Friend PawnCustomer As Client

    Private PawnInfo() As Hashtable
    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private currentORNumber As Integer = GetOption("ORLastNum")
    Private TypeInt As Double, bug As Boolean = False

    Private appraiser As Hashtable

    'Advance Interest
    Private DelayInt As Double, ServiceCharge As Double
    Private ItemPrincipal As Double, AdvanceInt As Double

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

        If Not isReady() Then
            MsgBox("I think you are missing something", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Select Case transactionType
            Case "L" : SaveNewLoan()
            Case "X" : SaveRedeem()
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

        ComputeAdvanceInterest()
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
            'txtRenew.BackColor = Drawing.SystemColors.Control
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
            .DelayInterest = txtInt.Text
            .Penalty = txtPenalty.Text
            .ServiceCharge = txtService.Text
            .EVAT = txtEvat.Text
            .RedeemDue = txtRedeem.Text
            .Status = transactionType

            .SaveTicket(False)
        End With
    End Sub

    Private Sub ComputeAdvanceInterest()
        If Not IsNumeric(txtPrincipal.Text) Then Exit Sub

        ItemPrincipal = CDbl(txtPrincipal.Text)
        DelayInt = ItemPrincipal * GetInt(30)
        ServiceCharge = GetServiceCharge(ItemPrincipal)
        AdvanceInt = DelayInt + ServiceCharge

        If transactionType = "L" Or transactionType = "R" Then
            txtInt.Text = DelayInt
            txtService.Text = ServiceCharge
            txtAdv.Text = AdvanceInt
        End If
        txtNet.Text = ItemPrincipal - AdvanceInt
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

            .AppraiserID = GetAppraiserID(cboAppraiser.Text)
            .Status = transactionType

            .SaveTicket()
        End With
    End Sub

    Private Function CheckAuth() As Boolean
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
        Dim daysDue As Integer = IIf(overDays.Days > 0, overDays.Days, 0)
        ComputeAdvanceInterest()

        If typ = "R" Then
            GeneratePT()
        End If

        txtOver.Text = daysDue
        If Not typ = "X" Then
            txtInt.Text = DelayInt
            txtService.Text = GetServiceCharge(PawnItem.Principal)
        End If

        txtPenalty.Text = GetInt(dayDiffNew, "Penalty") * PawnItem.Principal
        txtEvat.Text = PawnItem.EVAT

        txtRenew.Text = AdvanceInt + CDbl(txtEvat.Text) + CDbl(txtPenalty.Text)
        txtRedeem.Text = PawnItem.Principal + CDbl(txtEvat.Text) + CDbl(txtPenalty.Text)
        If transactionType = "X" Then
            txtRedeem.BackColor = Drawing.SystemColors.Window
            txtRedeem.Focus()
        Else
            'txtRenew.ReadOnly = False
            txtRenew.Focus()
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
        'currentPawnTicket = pt.PawnTicket
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
        'currentORNumber = pt.OfficialReceiptNumber
        txtReceiptDate.Text = IIf(pt.OfficialReceiptDate = #12:00:00 AM#, "", pt.OfficialReceiptDate)
        txtPrincipal2.Text = IIf(pt.Principal = 0, "", pt.Principal)

        txtOver.Text = pt.DaysOverDue
        txtInt.Text = pt.Interest
        txtPenalty.Text = pt.Penalty
        txtService.Text = pt.ServiceCharge
        txtEvat.Text = pt.EVAT

        txtRenew.Text = pt.RedeemDue
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
    End Sub

    Private Sub ChangeForm()
        Select Case transactionType
            Case "D"
                lblTransaction.Text = "Display Ticket Information"
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

        AdvanceInterest()
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
                txtAuction.Text = CurrentDate.AddDays(63).ToShortDateString
            Case Else
                txtExpiry.Text = CurrentDate.AddDays(89).ToShortDateString
                txtAuction.Text = CurrentDate.AddDays(123).ToShortDateString
        End Select
        AdvanceInterest()
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

    Private Sub AdvanceInterest()
        TypeInt = GetInt(30)

        If txtPrincipal.Text <> "" Then
            txtNet.Text = CDbl(txtPrincipal.Text) - (CDbl(txtPrincipal.Text) * TypeInt)
            If transactionType = "L" Then
                txtAdv.Text = (CDbl(txtPrincipal.Text) * TypeInt) + CDbl(GetServiceCharge(txtPrincipal.Text))
            End If
        End If

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
                    Console.WriteLine("Interest is now " & TypeInt)
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
    End Sub

    Private Sub SaveRenew()
        Dim oldPT As Integer = PawnItem.PawnTicket

        'ComputeAdvanceInterest()
        'Redeem
        With PawnItem
            .OfficialReceiptNumber = currentORNumber
            .OfficialReceiptDate = CurrentDate

            .DaysOverDue = txtOver.Text
            .DelayInterest = txtInt.Text
            .Penalty = txtPenalty.Text
            .ServiceCharge = txtService.Text
            .EVAT = txtEvat.Text
            .RenewDue = txtRenew.Text
            .RedeemDue = txtRedeem.Text
            .Status = "0"

            .SaveTicket(False)
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

            .Principal = txtPrincipal.Text
            .AdvanceInterest = AdvanceInt
            .NetAmount = .Principal - AdvanceInt
            .Status = "R"

            '.OfficialReceiptNumber = CurrentOR()
            '.OfficialReceiptDate = CurrentDate
            .SaveTicket()
        End With

        AddPTNum()
    End Sub
#End Region

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click

    End Sub
End Class