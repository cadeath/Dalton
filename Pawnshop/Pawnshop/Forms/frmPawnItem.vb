Public Class frmPawnItem

    Friend transactionType As String = "L"
    Friend PawnItem As PawnTicket

    Private PawnInfo(4) As ArrayList
    Private currentPawnTicket As Integer = GetOption("PawnLastNum")

    Private appraiser As Hashtable

    Private Sub frmPawnItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadInformation()
        LoadAppraisers()
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

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        On Error Resume Next

        Dim idx As Integer = cboType.SelectedIndex
        cboCat.Items.Clear()
        For Each dStr In PawnInfo(idx)
            cboCat.Items.Add(dStr)
        Next

        'for JWL
        If cboType.Text = "JWL" Then
            txtGram.ReadOnly = False
            cboKarat.Enabled = True
        Else
            txtGram.ReadOnly = True
            cboKarat.Enabled = False
        End If
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
        If Not mod_system.isAuthorized Then
            diagAuthorization.Show()
            diagAuthorization.txtUser.Text = cboAppraiser.Text
            diagAuthorization.fromForm = Me
        End If
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

    Friend Sub NewLoan()
        txtCustomer.Focus()
        transactionType = "L"

        txtTicket.Text = CurrentPTNumber()
        txtLoan.Text = CurrentDate.ToShortDateString
        txtMatu.Text = CurrentDate.AddDays(29).ToShortDateString
        dateChange(cboType.Text)
    End Sub

    Friend Sub LoadClient(ByVal cl As Client)
        txtCustomer.Text = String.Format("{0} {1}" & IIf(cl.Suffix <> "", "," & cl.Suffix, ""), cl.FirstName, cl.LastName)
        txtAddr.Text = String.Format("{0} {1} " + vbCrLf + "{2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBDay.Text = cl.Birthday
        txtContact.Text = cl.Cellphone1 & IIf(cl.Cellphone2 <> "", ", " & cl.Cellphone2, "")
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
        LoadPawnInfo()
    End Sub

    Private Sub LoadPawnInfo()
        cboType.Items.Clear()
        cboCat.Items.Clear()
        cboKarat.Items.Clear()

        'Type
        Dim mySql As String = "SELECT DISTINCT TYPE FROM tblClass ORDER BY TYPE ASC"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim classCNT As Integer = ds.Tables(0).Rows.Count
        For Each dr As DataRow In ds.Tables(0).Rows
            cboType.Items.Add(dr.Item("TYPE"))
        Next
        cboType.SelectedIndex = 0

        'Category
        'ReDim PawnInfo(classCNT - 1)
        Dim cnt As Integer = 0 : mySql = "SELECT * FROM tblClass WHERE "
        For cnt = 0 To classCNT - 1
            Dim str As String = mySql & String.Format("TYPE = '{0}'", cboType.Items(cnt)) & " ORDER BY CATEGORY ASC"
            ds.Clear()
            ds = LoadSQL(str)
            Dim x As Integer = 0
            cboCat.Items.Clear()

            PawnInfo(cnt) = New ArrayList
            Dim tmpArr As New ArrayList
            Console.WriteLine("Batch " & cnt + 1 & " ===================")
            For Each dr As DataRow In ds.Tables(0).Rows
                tmpArr.Add(dr.Item("Category"))
                cboCat.Items.Add(dr.Item("Category"))
                Console.WriteLine(x + 1 & ". " & dr.Item("Category"))
                x += 1
            Next
            PawnInfo(cnt).AddRange(tmpArr)
        Next

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

    
End Class