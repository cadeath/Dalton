Public Class frmMoneyTransfer

    Dim senderClient As Client
    Dim receiverClient As Client
    Friend displayOnly As Boolean = False

    Dim idME As Integer, idMR As Integer
    Dim basicCharges As Double, commission As Double
    Private MOD_NAME As String = "MONEYTRANSFER"

    ' NOTE - ADDING SERVICE
    ' STEP 3 - Add array count
    Private daltonService(16) As MoneyTransferService

    ''' <summary>
    ''' Initializing Money Transfer Services
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Main()
        ' NOTE - ADDING SERVICE
        ' STEP 1 - Create an Object
        Dim tmp As New MoneyTransferService
        With tmp
            .Code = "0001"
            .ServiceName = "Pera Padala"
            .isGenerated = True
            .KeySend = "MEnumLast"
            .KeyReceived = "MRNumLast"
            .ChargeCode = "perapadala"
        End With

        ' NOTE - ADDING SERVICE
        ' STEP 2 - Add it at daltonService
        daltonService(0) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0017"
            .ServiceName = "Pera Padala - PMFTC"
            .isGenerated = True
            .ChargeCode = "perapadalapmftc"
            .KeySend = "MEnumLast"
            .KeyReceived = "MRNumLast"
        End With
        daltonService(1) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0002"
            .ServiceName = "Western Union - Local"
            .isGenerated = False
            .AccountName = "Due to / From Western Union"
            .ChargeCode = "western"
        End With
        daltonService(2) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0003"
            .ServiceName = "Western Union - Intl"
            .isGenerated = False
            .AccountName = "Due to / From Western Union"
            .ChargeCode = "western - intl"
        End With
        daltonService(3) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0004"
            .ServiceName = "Cebuana Llhuiller"
            .isGenerated = False
            .AccountName = "Due to/from Cebuana Llhuiller"
            .ChargeCode = "cebuana"
        End With
        daltonService(4) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0005"
            .ServiceName = "GPRS - GPRS to GPRS"
            .isGenerated = False
            .ChargeCode = "gprs to gprs"
            .hasPayoutCommission = True
        End With
        daltonService(5) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0006"
            .ServiceName = "GPRS - GPRS to Smart Money"
            .isGenerated = False
            .ChargeCode = "gprs to smartmoney"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(6) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0007"
            .ServiceName = "GPRS - Smartmoney To GPRS"
            .isGenerated = False
            .ChargeCode = "smartmoney to gprs"
            .hasPayoutCommission = True
            .ReceiveOnly = True
        End With
        daltonService(7) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0008"
            .ServiceName = "GPRS - GPRS to BANK (UCPB/PNB)"
            .isGenerated = False
            .ChargeCode = "gprs to bank-ucpbpnb"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(8) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0009"
            .ServiceName = "GPRS - GPRS to BANK (BDO/Chinabank)"
            .isGenerated = False
            .ChargeCode = "gprs to bank-bdochina"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(9) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0010"
            .ServiceName = "GPRS - GPRS to BANK (DBP)"
            .isGenerated = False
            .ChargeCode = "gprs to dbp"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(10) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0011"
            .ServiceName = "GPRS - GPRS to BANK (MetroBank)"
            .isGenerated = False
            .ChargeCode = "gprs to metrobank"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(11) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0012"
            .ServiceName = "GPRS - GPRS to BANK (Maybank/LandBank)"
            .isGenerated = False
            .ChargeCode = "gprs to maylandbank"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(12) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0013"
            .ServiceName = "GPRS - iREMIT to GPRS"
            .isGenerated = False
            .ChargeCode = "iremit to gprs"
            .hasPayoutCommission = True
            .ReceiveOnly = True
        End With
        daltonService(13) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0014"
            .ServiceName = "GPRS - NYBP/Transfast to GPRS"
            .isGenerated = False
            .ChargeCode = "nybptransfast to gprs"
            .hasPayoutCommission = True
            .ReceiveOnly = True
        End With
        daltonService(14) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0015"
            .ServiceName = "GPRS - GPRS to Moneygram"
            .isGenerated = False
            .ChargeCode = "gprs to moneygram"
            .hasPayoutCommission = True
            .SendOnly = True
        End With
        daltonService(15) = tmp

        tmp = New MoneyTransferService
        With tmp
            .Code = "0016"
            .ServiceName = "GPRS - Moneygram to GPRS"
            .isGenerated = False
            .ChargeCode = "moneygram to gprs"
            .hasPayoutCommission = True
            .ReceiveOnly = True
        End With
        daltonService(16) = tmp

        'Pera Padala
        idME = daltonService(0).GetSendLast
        idMR = daltonService(0).GetReceivedLast

        'Pera Padala - PMFTC
        idME = daltonService(1).GetSendLast
        idMR = daltonService(1).GetReceivedLast
    End Sub

    Private Sub SendReceiveStatusCheck()
        Dim idx As Integer = cboType.SelectedIndex
        If Not daltonService(idx).SendOnly And Not daltonService(idx).ReceiveOnly Then
            rbSend.Enabled = True
            rbReceive.Enabled = True
        End If

        If daltonService(idx).SendOnly Or daltonService(idx).ReceiveOnly Then
            rbSend.Enabled = Not daltonService(idx).ReceiveOnly
            rbReceive.Enabled = Not daltonService(idx).SendOnly
            rbSend.Checked = daltonService(idx).SendOnly
            rbReceive.Checked = daltonService(idx).ReceiveOnly
        End If

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
        rbSend.Focus()

        Console.WriteLine("Form LOADED successfully")
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
        Dim CashCount_Name As String = ""

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
            .Commission = commission
            .NetAmount = txtNetAmount.Text
            .Location = cboLocation.Text
            .Status = "A" 'Active
            .EncoderID = UserID

            Select Case cboType.Text
                Case "Pera Padala"
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "ME# " & idME, "PADALA IN")
                        AddJournal(.TransferAmount, "Credit", "Pera Padala Fund Payable", "ME# " & idME)
                        AddJournal(.ServiceCharge, "Credit", "Pera Padala Service Charge", "ME# " & idME)
                    Else
                        AddJournal(.TransferAmount, "Debit", "Pera Padala Fund Payable", "MR# " & idMR)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "MR# " & idMR, "PADALA OUT")
                    End If
                Case "Pera Padala - PMFTC"
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "ME# " & idME, "PADALA IN")
                        AddJournal(.TransferAmount, "Credit", "Pera Padala Fund Payable", "ME# " & idME)
                        AddJournal(.ServiceCharge, "Credit", "Pera Padala Service Charge", "ME# " & idME)
                    Else
                        AddJournal(.TransferAmount, "Debit", "Pera Padala Fund Payable", "MR# " & idMR)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "MR# " & idMR, "PADALA OUT")
                    End If
                Case "Western Union - Local", "Western Union - Intl"
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "WE|Ref# " & .ReferenceNumber, "WESTERN IN")
                        AddJournal(.NetAmount, "Credit", "Due to / From Western Union", "WE|Ref# " & .ReferenceNumber)
                    Else
                        AddJournal(.NetAmount, "Debit", "Due to / From Western Union", "WE|Ref# " & .ReferenceNumber)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "WE|Ref# " & .ReferenceNumber, "WESTERN OUT")
                    End If
                Case "Cebuana Llhuiller"
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "CL|Ref# " & .ReferenceNumber, "CEBUANA IN")
                        AddJournal(.NetAmount, "Credit", "Due to/from Cebuana Llhuiller", "CL|Ref# " & .ReferenceNumber)
                    Else
                        AddJournal(.NetAmount, "Debit", "Due to/from Cebuana Llhuiller", "CL|Ref# " & .ReferenceNumber)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "CL|Ref# " & .ReferenceNumber, "CEBUANA OUT")
                    End If
                Case "GPRS - GPRS to GPRS"
                    'GPRS ----------------------------------
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "G2G|Ref# " & .ReferenceNumber, "GPRS-GPRS")
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "G2G|Ref# " & .ReferenceNumber)
                        AddJournal(.NetAmount - commission, "Credit", "GPRS Remittance/ Bills Payment Fund", "G2G|Ref# " & .ReferenceNumber)
                    Else
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "G2G|Ref# " & .ReferenceNumber, "GPRS-GPRS")
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "G2G|Ref# " & .ReferenceNumber)
                        AddJournal(.NetAmount + commission, "Debit", "GPRS Remittance/ Bills Payment Fund", "G2G|Ref# " & .ReferenceNumber)
                    End If
                Case "GPRS - GPRS to Smart Money", "GPRS - GPRS to BANK (UCPB/PNB)", "GPRS - GPRS to BANK (BDO/Chinabank)", _
                    "GPRS - GPRS to BANK (DBP)", "GPRS - GPRS to BANK (MetroBank)", "GPRS - GPRS to BANK (Maybank/LandBank)", _
                    "GPRS - iREMIT to GPRS", "GPRS - NYBP/Transfast to GPRS", "GPRS - GPRS to Moneygram"

                    Select Case cboType.Text
                        Case "GPRS - GPRS to Smart Money"
                            CashCount_Name = "GPRS-SmartMoney"
                        Case "GPRS - GPRS to BANK (UCPB/PNB)"
                            CashCount_Name = "GPRS-(UCPB/PNB)"
                        Case "GPRS - GPRS to BANK (BDO/Chinabank)"
                            CashCount_Name = "GPRS-(BDO/Chinabank)"
                        Case "GPRS - GPRS to BANK (DBP)"
                            CashCount_Name = "GPRS-DBP"
                        Case "GPRS - GPRS to BANK (MetroBank)"
                            CashCount_Name = "GPRS-MetroBank"
                        Case "GPRS - GPRS to BANK (Maybank/LandBank)"
                            CashCount_Name = "GPRS-(Maybank/LandBank)"
                        Case "GPRS - iREMIT to GPRS"
                            CashCount_Name = "iREMIT"
                        Case "GPRS - NYBP/Transfast to GPRS"
                            CashCount_Name = "NYBP/Transfast"
                        Case "GPRS - GPRS to Moneygram"
                            CashCount_Name = "GPRS-Moneygram"

                    End Select

                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "GPRS|Ref# " & .ReferenceNumber, CashCount_Name)
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "GPRS|Ref# " & .ReferenceNumber)
                        AddJournal(.NetAmount - commission, "Credit", "GPRS Remittance/ Bills Payment Fund", "GPRS|Ref# " & .ReferenceNumber)
                    Else
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "GPRS|Ref# " & .ReferenceNumber, CashCount_Name)
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "GPRS|Ref# " & .ReferenceNumber)
                        AddJournal(.NetAmount + commission, "Debit", "GPRS Remittance/ Bills Payment Fund", "GPRS|Ref# " & .ReferenceNumber)


                    End If
                    ' ISSUE: 0001
                    ' GPRS - Smartmoney To GPRS, wrong Journal Entries
                Case "GPRS - Smartmoney To GPRS", "GPRS - Moneygram to GPRS"
                    ' Amt 4000 | 3995 gprsRemitFund debit = 3980 rf credit + 15 income credit
                    Select Case cboType.Text
                        Case "GPRS - Smartmoney To GPRS"
                            CashCount_Name = "SmartMoney-GPRS"
                        Case "GPRS - Moneygram to GPRS"
                            CashCount_Name = "Moneygram-GPRS"
                    End Select

                    AddJournal(.NetAmount + commission, "Debit" _
                               , "GPRS Remittance/ Bills Payment Fund", "GPRS_R|Ref# " & .ReferenceNumber)
                    AddJournal(.NetAmount, "Credit", "Revolving Fund", "GPRS_R|Ref# " & .ReferenceNumber, CashCount_Name)
                    AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "GPRS_R|Ref# " & .ReferenceNumber)
            End Select

            .Save()
            AddTimelyLogs(MOD_NAME, String.Format("Transfer a total amount of Php{0} to {1}", .NetAmount.ToString("#,##0.00"), cboLocation.Text))
        End With

        If daltonService(idx).isGenerated Then
            If rbSend.Checked Then
                idME += 1 : daltonService(idx).SetSendLast(idME)
            Else
                idMR += 1 : daltonService(idx).SetReceivedLast(idMR)
            End If
        End If

        MsgBox("Transaction Saved", MsgBoxStyle.Information)

        'ISSUE: 0002 02/06/2016
        'Money Transfer - Enable multiple encoding
        Dim xans As DialogResult = _
            MsgBox("Do you want to enter another one?", MsgBoxStyle.YesNo + MsgBoxStyle.Information + MsgBoxStyle.DefaultButton2)
        If xans = Windows.Forms.DialogResult.Yes Then
            frmMoneyTransfer_Load(sender, e)
            Exit Sub
        End If

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

    Private Function GetCharge(ByVal amt As Double, Optional ByVal type As String = "perapadala") As Double
        'Version 2
        ' - Include Commission and complicated computations

        Dim idx As Integer = cboType.SelectedIndex
        If rbReceive.Checked And Not daltonService(idx).hasPayoutCommission Then Return 0

        Dim fillData As String = "tblCharge"
        Dim ds As DataSet, mySql As String
        mySql = "SELECT * FROM " & fillData & String.Format(" WHERE type = '{0}'", type)
        If daltonService(idx).hasPayoutCommission Then
            mySql &= " AND Remarks LIKE '"
            mySql &= IIf(rbSend.Checked, "Send In%'", "Pay Out%'")
        End If
        mySql &= " ORDER BY AMOUNT ASC"
        ds = LoadSQL(mySql)

        Console.WriteLine(mySql)
        Console.WriteLine("Entries >> " & ds.Tables(0).Rows.Count)
        If ds.Tables(0).Rows.Count = 0 Then Console.WriteLine("No charges!!! Charge Code not found.") : Return 0

        For Each dr As DataRow In ds.Tables(0).Rows
            If amt <= CDbl(dr.Item("AMOUNT")) Then
                'Including Commission and complicated computations
                Console.WriteLine("Max: " & dr.Item("AMOUNT") & "| Charge: " & dr.Item("Charge"))

                Dim ServChrge As Double = 0, remarks As String = ""
                ServChrge = dr.Item("Charge")
                commission = IIf(IsDBNull(dr.Item("Commission")), 0, dr.Item("Commission"))
                remarks = IIf(IsDBNull(dr.Item("Remarks")), "", dr.Item("Remarks"))

                If remarks.Split("|").Count > 1 Then
                    Dim tmpSrvAmt As Double = 0
                    'ServiceCharge
                    Select Case remarks.Split("|")(1)
                        Case "Percent"
                            tmpSrvAmt = ServChrge / 100
                            ServChrge = amt * tmpSrvAmt
                        Case Else
                            MsgBox("Remarks INVALID!" + vbCrLf + "No SERVICE CHARGE", vbCritical, "DEVELOPER Warning")
                            ServChrge = 0
                    End Select

                    'Commission
                    If remarks.Split("|").Count <= 2 Then Exit For
                    Select Case remarks.Split("|")(2)
                        Case "SLC" 'ServiceCharge Less Charge
                            commission = ServChrge - commission
                        Case Else
                            MsgBox("Remarks INVALID!" + vbCrLf + "No COMMISSION", vbCritical, "DEVELOPER Warning")
                            commission = 0
                    End Select

                    'If Not (remarks = "Payout" And rbReceive.Checked) Then
                    '    ServChrge = 0
                    'End If
                End If

                Return ServChrge
            End If
        Next

        Console.WriteLine(String.Format("LIMIT! for  {0} with 1.5% of {1}", amt, amt * 0.015))
        Return amt * 0.015
    End Function

    Private Sub txtAmount_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAmount.LostFocus
        ComputeCharges()
        cboLocation.Focus()
    End Sub

    Private Sub ComputeCharges()
        If Not IsNumeric(txtAmount.Text) Then Exit Sub

        basicCharges = GetCharge(CDbl(txtAmount.Text), FindServices(cboType.Text).ChargeCode)
        txtCharge.Text = basicCharges
        ComputeNet()

        Console.WriteLine(String.Format("Amount: {0} | ServiceCharge: {1} | Commission: {2}", _
                                        txtAmount.Text, basicCharges, commission))
    End Sub

    Private Function FindServices(str As String) As MoneyTransferService
        For Each daltonSrv In daltonService
            If daltonSrv.ServiceName = str Then Return daltonSrv
        Next

        Return Nothing
    End Function

    Private Sub ComputeNet()
        If txtCharge.Text = "" Then Exit Sub
        If txtAmount.Text = "" Then Exit Sub

        Dim net As Double = CDbl(txtCharge.Text) + CDbl(txtAmount.Text)
        ' ISSUE: 0001 02/04/2016
        ' Payout Service Charge, auto deduct
        If daltonService(cboType.SelectedIndex).ReceiveOnly Then
            net = CDbl(txtAmount.Text) - CDbl(txtCharge.Text)
        End If
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
        ComputeCharges()
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
        SendReceiveStatusCheck()
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