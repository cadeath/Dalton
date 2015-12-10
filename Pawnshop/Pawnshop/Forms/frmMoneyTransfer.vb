Public Class frmMoneyTransfer

    Dim senderClient As Client
    Dim receiverClient As Client
    Friend displayOnly As Boolean = False

    Dim idME As Integer, idMR As Integer

    Private daltonService(2) As MoneyTransferService

    Private Sub Main()
        Dim tmp As New MoneyTransferService
        With tmp
            .Code = "0001"
            .ServiceName = "Pera Padala"
            .isGenerated = True
            .KeySend = "MEnumLast"
            .KeyReceived = "MRNumLast"
        End With
        daltonService(0) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0002"
            .ServiceName = "Western Union"
            .isGenerated = False
        End With
        daltonService(1) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0003"
            .ServiceName = "Cebuana Llhuiller"
            .isGenerated = False
        End With
        daltonService(2) = tmp

        'Pera Padala
        idME = daltonService(0).GetSendLast
        idMR = daltonService(1).GetReceivedLast
    End Sub

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSender.Click
        If rbReceive.Checked Then
            RequirementLevel = 1
        Else
            RequirementLevel = 3
        End If

        frmClient.SearchSelect(txtSender.Text, FormName.frmMTSend)
        frmClient.Show()
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub DisplayNumber(Optional ByVal num As Integer = 0)
        If num = 0 Then txtTransNum.Text = ""
        txtTransNum.Text = String.Format("{0:000000}", num)
    End Sub

    Private Sub txtSender_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSender.KeyPress
        If isEnter(e) Then
            btnSearchSender.PerformClick()
        End If
    End Sub

    Friend Sub LoadMT(ByVal mt As MoneyTransfer)
        LockFields(True)
        txtSender.ReadOnly = True
        txtReceiver.ReadOnly = True
        txtRefNum.ReadOnly = True
        txtAmount.ReadOnly = True
        cboLocation.Enabled = False

        Select Case mt.TransactionType
            Case 1 : rbReceive.Checked = True
            Case 0 : rbSend.Checked = True
        End Select

        cboType.Text = mt.ServiceType
        LoadSenderInfo(mt.Sender)
        LoadReceiverInfo(mt.Receiver)

        txtRefNum.Text = mt.ReferenceNumber
        txtAmount.Text = mt.TransferAmount
        txtCharge.Text = mt.ServiceCharge
        txtNetAmount.Text = mt.NetAmount
        cboLocation.Text = mt.Location

        btnPost.Enabled = False

        Me.Text &= "| Date: " & mt.TransactionDate


        cboType.Enabled = False
        btnSearchSender.Enabled = False
        btnSearchReceiver.Enabled = False
        rbReceive.Enabled = False
        rbSend.Enabled = False
    End Sub

    Private Sub frmMoneyTransfer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Main()
        ClearField()
        LockFields(True)
        LoadServices()
        lblWhere.Text = "Send To"
        'MsgBox("This module is under construction", MsgBoxStyle.Information)
        rbSend.Focus()
    End Sub

    Private Sub LoadServices()
        cboType.Items.Clear()
        For Each el As MoneyTransferService In daltonService
            cboType.Items.Add(el.ServiceName)
        Next
        If cboType.Items.Count > 0 Then cboType.SelectedIndex = 0
    End Sub

    Private Function GetLocations() As String()
        Dim mySql As String = "SELECT DISTINCT Location FROM tblMoneyTransfer ORDER BY Location ASC"
        Dim ds As DataSet = LoadSQL(mySql)

        Dim MaxRow As Integer = ds.Tables(0).Rows.Count
        Dim tmpStr(MaxRow - 1) As String, cnt As Integer = 0
        For Each dr As DataRow In ds.Tables(0).Rows
            tmpStr(cnt) = dr.Item("Location")
            cnt += 1
        Next

        Return tmpStr
    End Function

    Private Sub ClearField()
        rbSend.Checked = True
        cboType.SelectedIndex = 0

        txtTransNum.Text = ""
        txtSender.Text = "" : txtSenderAddr.Text = ""
        txtSenderID.Text = "" : txtSenderIDNum.Text = ""

        txtReceiver.Text = "" : txtReceiverAddr.Text = ""
        txtReceiverID.Text = "" : txtReceiverIDNum.Text = ""

        txtRefNum.Text = "" : txtAmount.Text = ""
        txtCharge.Text = "" : txtNetAmount.Text = ""
        cboLocation.Text = ""

        cboLocation.Items.Clear()
        cboLocation.Items.AddRange(GetLocations)
    End Sub

    Private Sub LockFields(ByVal st As Boolean)
        txtSenderAddr.ReadOnly = st
        txtSenderID.ReadOnly = st
        txtSenderIDNum.ReadOnly = st

        txtReceiverAddr.ReadOnly = st
        txtReceiverID.ReadOnly = st
        txtReceiverIDNum.ReadOnly = st

        txtCharge.ReadOnly = st
        txtNetAmount.ReadOnly = st
    End Sub

    Private Function isValid() As Boolean
        Dim idx As Integer = cboType.SelectedIndex
        If cboType.Text = "" Then cboType.Focus() : Return False

        If Not daltonService(idx).isGenerated And txtRefNum.Text = "" Then txtRefNum.Focus() : Return False
        If rbSend.Checked Then
            If senderClient Is Nothing Then txtSender.Focus() : MsgBox("Please select Sender", MsgBoxStyle.Critical) : Return False
            If txtSenderIDNum.Text = "" Then txtSenderIDNum.Focus() : MsgBox("Please input ID Number", MsgBoxStyle.Critical) : Return False
            If receiverClient Is Nothing Then txtReceiver.Focus() : MsgBox("Please select Receiver", MsgBoxStyle.Critical) : Return False
        Else
            If senderClient Is Nothing Then txtSender.Focus() : MsgBox("Please select Sender", MsgBoxStyle.Critical) : Return False
            If receiverClient Is Nothing Then txtReceiver.Focus() : MsgBox("Please select Receiver", MsgBoxStyle.Critical) : Return False
            If txtReceiverIDNum.Text = "" Then txtReceiverIDNum.Focus() : MsgBox("Please input ID Number", MsgBoxStyle.Critical) : Return False
            If txtRefNum.Text = "" Then txtRefNum.Focus() : Return False
        End If

        If txtAmount.Text = "" Then txtAmount.Focus() : Return False
        If cboLocation.Text = "" Then cboLocation.Focus() : Return False

        Return True
    End Function

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isValid() Then Exit Sub

        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub

        Dim transID As Integer = 0
        Dim idx As Integer = cboType.SelectedIndex
        If daltonService(idx).isGenerated Then
            If rbSend.Checked Then
                transID = idME
            Else
                transID = idMR
            End If
        End If


        Dim mtTrans As New MoneyTransfer
        With mtTrans
            .TransactionType = IIf(rbReceive.Checked, 1, 0)
            .TransactionID = transID
            .ServiceType = cboType.Text
            .TransactionDate = CurrentDate
            .Sender = senderClient
            .Receiver = receiverClient
            .ReferenceNumber = txtRefNum.Text
            .TransferAmount = txtAmount.Text
            .ServiceCharge = txtCharge.Text
            .NetAmount = txtNetAmount.Text
            .Location = cboLocation.Text
            .Status = "A" 'Active
            .EncoderID = UserID

            .Save()
        End With

        If daltonService(idx).isGenerated Then
            If rbSend.Checked Then
                idME += 1 : daltonService(idx).SetSendLast(idME)
            Else
                idMR += 1 : daltonService(idx).SetReceivedLast(idMR)
            End If
        End If

        MsgBox("Transaction Saved", MsgBoxStyle.Information)
        frmMTlist.LoadActive()
        Me.Close()
    End Sub

    Friend Sub LoadSenderInfo(ByVal cl As Client)
        txtSender.Text = String.Format("{0} {1}", cl.FirstName, cl.LastName)
        txtSenderAddr.Text = String.Format("{0} {1} {2} {3}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity, cl.AddressProvince)
        txtSenderID.Text = cl.IDType
        txtSenderIDNum.Text = cl.IDNumber

        senderClient = cl
        txtReceiver.Focus()
    End Sub

    Friend Sub LoadReceiverInfo(ByVal cl As Client)
        txtReceiver.Text = String.Format("{0} {1}", cl.FirstName, cl.LastName)
        txtReceiverAddr.Text = String.Format("{0} {1} {2} {3}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity, cl.AddressProvince)
        txtReceiverID.Text = cl.IDType
        txtReceiverIDNum.Text = cl.IDNumber

        receiverClient = cl
        txtRefNum.Focus()
    End Sub

    Private Sub btnSearchReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchReceiver.Click
        If rbReceive.Checked Then
            RequirementLevel = 3
        Else
            RequirementLevel = 1
        End If
        frmClient.SearchSelect(txtReceiver.Text, FormName.frmMTReceive)
        frmClient.Show()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
        If isEnter(e) Then
            cboLocation.Focus()
        End If
    End Sub

    Private Sub txtRefNum_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtRefNum.KeyPress
        If isEnter(e) Then
            txtAmount.Focus()
        End If
    End Sub

    Private Function GetCharge(ByVal amt As Double) As Double
        If rbReceive.Checked Then Return 0

        Dim type As String = "perapadala", fillData As String = "tblCharge"
        Dim ds As DataSet, mySql As String
        mySql = "SELECT * FROM " & fillData
        ds = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            If amt <= CDbl(dr.Item("AMOUNT")) Then
                Console.WriteLine("Max: " & dr.Item("AMOUNT") & "| Charge: " & dr.Item("Charge"))
                Return CDbl(dr.Item("Charge"))
            End If
        Next

        Console.WriteLine(String.Format("LIMIT! for  {0} with 1.5% of {1}", amt, amt * 0.015))
        Return amt + (amt * 0.015)
    End Function

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus
        txtCharge.Text = GetCharge(CDbl(txtAmount.Text))
        ComputeNet()
    End Sub

    Private Sub ComputeNet()
        If txtCharge.Text = "" Then Exit Sub
        If txtAmount.Text = "" Then Exit Sub

        Dim net As Double = CDbl(txtCharge.Text) + CDbl(txtAmount.Text)

        txtNetAmount.Text = net
    End Sub

    Private Sub txtReceiver_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReceiver.KeyPress
        If isEnter(e) Then
            btnSearchReceiver.PerformClick()
        End If
    End Sub

    Private Sub txtLocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If isEnter(e) Then
            btnPost.PerformClick()
        End If
    End Sub

    Private Sub CheckTracking()
        Dim idx As Integer = cboType.SelectedIndex
        Dim st As Boolean = False
        If cboType.Items.Count <= 0 Then Exit Sub
        If displayOnly Then Exit Sub

        If daltonService(idx).isGenerated Then
            If rbSend.Checked Then
                DisplayNumber(idME)
                st = False
            Else
                DisplayNumber(idMR)
                st = True
            End If
        Else
            txtTransNum.Text = ""
            st = True
        End If

        txtRefNum.ReadOnly = Not st
    End Sub

    Private Sub rbSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSend.CheckedChanged
        If rbSend.Checked Then lblWhere.Text = "Send To"
        CheckTracking()
    End Sub

    Private Sub rbReceive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceive.CheckedChanged
        If rbReceive.Checked Then
            ComputeNet()
            lblWhere.Text = "Send From"
        End If
        CheckTracking()
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        CheckTracking()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmMTlist.Show()
    End Sub

    Private Sub cboLocation_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cboLocation.KeyPress
        If isEnter(e) Then
            btnPost.PerformClick()
        End If
    End Sub
End Class