Public Class frmPawnItem
    'Version 2.1
    ' - Fixing Auth
    ' - Fixing GUI

    Friend transactionType As String = "L"
    Friend PawnItem As PawnTicket
    Friend PawnCustomer As Client

    Private PawnInfo() As Hashtable
    Private currentPawnTicket As Integer = GetOption("PawnLastNum")
    Private currentORNumber As Integer = GetOption("ORLastNum")

    Private appraiser As Hashtable

    Private Sub frmPawnItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadInformation()
        LoadAppraisers()
        If transactionType = "L" Then
            NewLoan()
        End If
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

    Private Sub cboAppraiser_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAppraiser.LostFocus
        CheckAuth()
    End Sub

    Private Function CheckAuth() As Boolean
        If Not mod_system.isAuthorized Then
            diagAuthorization.Show()
            diagAuthorization.TopMost = True
            diagAuthorization.txtUser.Text = cboAppraiser.Text
            diagAuthorization.fromForm = Me
            Return False
        End If

        Return True
    End Function

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

        PawnItem = New PawnTicket
        Console.WriteLine("PT: " & currentPawnTicket)
        Console.WriteLine("Customer: " & PawnCustomer.FirstName)
        Console.WriteLine("LoanDate: " & txtLoan.Text)
        Console.WriteLine("Maturity: " & txtMatu.Text)
        Console.WriteLine("Expiry: " & txtExpiry.Text)
        Console.WriteLine("Auc: " & txtAuction.Text)
        Console.WriteLine("Type: " & cboType.Text)
        Console.WriteLine("CatID: " & GetKey(PawnInfo(cboType.SelectedIndex), cboCat.Text))
        Console.WriteLine("Desc: " & txtDesc.Text)
        Console.WriteLine("Karat: " & cboKarat.Text)
        Console.WriteLine("Gram: " & txtGram.Text)
        Console.WriteLine("Appr: " & txtAppr.Text)
        Console.WriteLine("Prin: " & txtPrincipal.Text)
        Console.WriteLine("Net: " & txtNet.Text)

        Console.WriteLine("Status: " & transactionType)
        Console.WriteLine("Appraiser: " & GetKey(appraiser, cboAppraiser.Text))
        'With PawnItem
        '    .PawnTicket = currentPawnTicket
        '    .Pawner = PawnCustomer
        '    .LoanDate = txtLoan.Text
        '    .MaturityDate = txtMatu.Text
        '    .ExpiryDate = txtExpiry.Text
        '    .AuctionDate = txtAuction.Text
        '    .ItemType = cboType.Text
        '    .CategoryID = PawnInfo(cboType.SelectedIndex)(cboCat.Text)
        '    .Description = txtDesc.Text
        '    .Karat = cboKarat.Text
        '    .Grams = txtGram.Text
        '    .Appraisal = txtAppr.Text
        '    .Principal = txtPrincipal.Text
        '    .NetAmount = txtNet.Text
        '    If transactionType <> "L" Then
        '        .OldTicket = txtOldTicket.Text
        '        '.LessPrincipal= 'No Variable yet
        '        .DaysOverDue = txtOver.Text
        '        .Penalty = txtPenalty.Text
        '        .ServiceCharge = txtService.Text

        '        .OfficialReceiptNumber = txtReceipt.Text
        '        .OfficialReceiptDate = txtReceiptDate.Text
        '        .Interest = txtInt.Text
        '        .EVAT = txtEvat.Text

        '        .RenewDue = txtRedeem.Text
        '        .RedeemDue = txtRedeem.Text
        '    End If
        '    .Status = transactionType
        '    .AppraiserID = appraiser(cboAppraiser.Text)

        '    .SaveTicket()
        'End With

        MsgBox("Item Posted!", MsgBoxStyle.Information)
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
        If isEnter(e) Then
            cboAppraiser.Focus()
        End If
    End Sub
#End Region

#Region "Controller"
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

        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        dateChange(cboType.Text)

        txtReceipt.Text = currentORNumber
        txtReceiptDate.Text = CurrentDate.ToShortDateString
        txtPrincipal2.Text = txtPrincipal.Text

        btnRenew.Enabled = False
        btnRedeem.Enabled = False
        btnVoid.Enabled = False
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBDay.Text = cl.Birthday.ToString("MMM dd, yyyy")
        txtContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")

        PawnCustomer = cl
        cboType.Focus()
        cboType.DroppedDown = True
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
#End Region

    Private Sub txtPrincipal_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPrincipal.KeyUp
        txtPrincipal2.Text = txtPrincipal.Text
        txtNet.Text = txtPrincipal.Text
    End Sub

End Class