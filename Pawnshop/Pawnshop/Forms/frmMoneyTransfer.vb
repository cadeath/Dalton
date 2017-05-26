Imports System.Data.Odbc
Public Class frmMoneyTransfer

    Dim senderClient As Customer
    Dim receiverClient As Customer
    Private currentMe As Integer = GetOption("MEnumLast")
    Private currentMr As Integer = GetOption("MRNumLast")
    Dim moneytransferIDNumber As MoneyTransfer
    Friend displayOnly As Boolean = False
    Dim idME As Integer, idMR As Integer
    Dim basicCharges As Double, commission As Double
    Private MOD_NAME As String = "MONEYTRANSFER"

    ' NOTE - ADDING SERVICE
    ' STEP 3 - Add array count
    'Private daltonService(16) As MoneyTransferService

    'Private Sub Main()
    '    ' NOTE - ADDING SERVICE
    '    ' STEP 1 - Create an Object
    '    Dim tmp As New MoneyTransferService
    '    With tmp
    '        .Code = "0001"
    '        .ServiceName = "Pera Padala"
    '        .isGenerated = True
    '        .KeySend = "MEnumLast"
    '        .KeyReceived = "MRNumLast"
    '        .ChargeCode = "perapadala"
    '    End With

    '    ' NOTE - ADDING SERVICE
    '    ' STEP 2 - Add it at daltonService
    '    daltonService(0) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0017"
    '        .ServiceName = "Pera Padala - PMFTC"
    '        .isGenerated = True
    '        .ChargeCode = "perapadalapmftc"
    '        .KeySend = "MEnumLast"
    '        .KeyReceived = "MRNumLast"
    '    End With
    '    daltonService(1) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0002"
    '        .ServiceName = "Western Union - Local"
    '        .isGenerated = False
    '        .AccountName = "Due to / From Western Union"
    '        .ChargeCode = "western"
    '    End With
    '    daltonService(2) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0003"
    '        .ServiceName = "Western Union - Intl"
    '        .isGenerated = False
    '        .AccountName = "Due to / From Western Union"
    '        .ChargeCode = "western - intl"
    '    End With
    '    daltonService(3) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0004"
    '        .ServiceName = "Cebuana Llhuiller"
    '        .isGenerated = False
    '        .AccountName = "Due to/from Cebuana Llhuiller"
    '        .ChargeCode = "cebuana"
    '    End With
    '    daltonService(4) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0005"
    '        .ServiceName = "GPRS - GPRS to GPRS"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to gprs"
    '        .hasPayoutCommission = True
    '    End With
    '    daltonService(5) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0006"
    '        .ServiceName = "GPRS - GPRS to Smart Money"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to smartmoney"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(6) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0007"
    '        .ServiceName = "GPRS - Smartmoney To GPRS"
    '        .isGenerated = False
    '        .ChargeCode = "smartmoney to gprs"
    '        .hasPayoutCommission = True
    '        .ReceiveOnly = True
    '    End With
    '    daltonService(7) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0008"
    '        .ServiceName = "GPRS - GPRS to BANK (UCPB/PNB)"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to bank-ucpbpnb"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(8) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0009"
    '        .ServiceName = "GPRS - GPRS to BANK (BDO/Chinabank)"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to bank-bdochina"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(9) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0010"
    '        .ServiceName = "GPRS - GPRS to BANK (DBP)"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to dbp"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(10) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0011"
    '        .ServiceName = "GPRS - GPRS to BANK (MetroBank)"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to metrobank"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(11) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0012"
    '        .ServiceName = "GPRS - GPRS to BANK (Maybank/LandBank)"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to maylandbank"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(12) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0013"
    '        .ServiceName = "GPRS - iREMIT to GPRS"
    '        .isGenerated = False
    '        .ChargeCode = "iremit to gprs"
    '        .hasPayoutCommission = True
    '        .ReceiveOnly = True
    '    End With
    '    daltonService(13) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0014"
    '        .ServiceName = "GPRS - NYBP/Transfast to GPRS"
    '        .isGenerated = False
    '        .ChargeCode = "nybptransfast to gprs"
    '        .hasPayoutCommission = True
    '        .ReceiveOnly = True
    '    End With
    '    daltonService(14) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0015"
    '        .ServiceName = "GPRS - GPRS to Moneygram"
    '        .isGenerated = False
    '        .ChargeCode = "gprs to moneygram"
    '        .hasPayoutCommission = True
    '        .SendOnly = True
    '    End With
    '    daltonService(15) = tmp

    '    tmp = New MoneyTransferService
    '    With tmp
    '        .Code = "0016"
    '        .ServiceName = "GPRS - Moneygram to GPRS"
    '        .isGenerated = False
    '        .ChargeCode = "moneygram to gprs"
    '        .hasPayoutCommission = True
    '        .ReceiveOnly = True
    '    End With
    '    daltonService(16) = tmp

    '    'Pera Padala
    '   idME = daltonService(0).GetSendLast
    '    idMR = daltonService(0).GetReceivedLast

    '    'Pera Padala - PMFTC
    '    idME = daltonService(1).GetSendLast
    '    idMR = daltonService(1).GetReceivedLast
    'End Sub

    Private Sub SendReceiveStatusCheck()
        'Dim idx As Integer = cboType.SelectedIndex
        'If Not daltonService(idx).SendOnly And Not daltonService(idx).ReceiveOnly Then
        '    rbSend.Enabled = True
        '    rbReceive.Enabled = True
        'End If

        'If daltonService(idx).SendOnly Or daltonService(idx).ReceiveOnly Then
        '    rbSend.Enabled = Not daltonService(idx).ReceiveOnly
        '    rbReceive.Enabled = Not daltonService(idx).SendOnly
        '    rbSend.Checked = daltonService(idx).SendOnly
        '    rbReceive.Checked = daltonService(idx).ReceiveOnly
        'End If

        Select Case GetActionType(cboType.Text, MTValues.ActionType)
            Case "0"
                rbSend.Enabled = True
                rbReceive.Enabled = False
                rbSend.Checked = True
            Case "1"
                rbSend.Enabled = False
                rbReceive.Enabled = True
                rbReceive.Checked = True
            Case Else
                rbSend.Enabled = True
                rbReceive.Enabled = True
        End Select

    End Sub
    Enum MTValues As Integer
        isGenerated = 0
        ActionType = 1
        HasPayoutCommission = 3
    End Enum
    Private Function GetActionType(ByVal ChargeName As String, ByVal MT As MTValues)
        If ChargeName = "" Then Return Nothing
        Dim mysql As String = "Select * From tblMTCharge Where ChargeName = '" & ChargeName & "'"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        Select Case MT
            Case MTValues.ActionType
                If IsDBNull(ds.Tables(0).Rows(0).Item("Action_Type")) Then Return ""
                Return ds.Tables(0).Rows(0).Item("Action_Type")

            Case MTValues.HasPayoutCommission
                Return ds.Tables(0).Rows(0).Item("HASPAYOUTCOMMISION")

            Case MTValues.isGenerated
                Return ds.Tables(0).Rows(0).Item("ISGENERATED")
        End Select

        Return ""
    End Function

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchSender.Click
        If rbReceive.Checked Then
            RequirementLevel = 1
        Else
            RequirementLevel = 3
        End If
        Dim secured_str As String = txtSender.Text
        secured_str = DreadKnight(secured_str)
        frmClientNew.SearchSelect(secured_str, FormName.frmMTSend)
        frmClientNew.Show()
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
        ' Main()
        ClearField()
        LockFields(True)
        ' LoadServices()
        LoadServiceType()

        lblWhere.Text = "Send To"
        rbSend.Focus()
        Console.WriteLine("Form LOADED successfully")
    End Sub


    'Private Sub LoadServices()
    '    cboType.Items.Clear()
    '    For Each el As MoneyTransferService In daltonService
    '        cboType.Items.Add(el.ServiceName)
    '    Next
    '    If cboType.Items.Count > 0 Then cboType.SelectedIndex = 0
    'End Sub

    Private Sub LoadServiceType()
        Dim mysql As String = "Select * From tblMTCharge"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        For Each dr In ds.Tables(0).Rows
            cboType.Items.Add(dr.item("ChargeName"))
        Next
    End Sub

    Private Function GenerateMrNum() As Boolean
        'Check Mr if existing
        Dim mySql As String, ds As DataSet
        If txtTransNum.Text <> "" And rbSend.Checked = False Then

            mySql = "SELECT DISTINCT TRANSID,MONEYTRANS,SERVICETYPE FROM TBLMONEYTRANSFER "
            mySql &= "WHERE TRANSID = '" & currentMr & "' AND MONEYTRANS='1' AND SERVICETYPE = 'Pera Padala'"
            ds = LoadSQL(mySql)
            If ds.Tables(0).Rows.Count >= 1 Then : MsgBox("ME# " & currentMr.ToString("000000") & " already existed.", MsgBoxStyle.Critical) : Return False
            End If
        End If
        Return True
    End Function
    Private Function GenerateMeNum() As Boolean
        'Check ME if existing
        Dim mySql As String, ds As DataSet
        mySql = "SELECT DISTINCT TRANSID,MONEYTRANS,SERVICETYPE FROM TBLMONEYTRANSFER "
        mySql &= "WHERE TRANSID = '" & currentMe & "' AND MONEYTRANS='0' AND SERVICETYPE= 'Pera Padala'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then : MsgBox("ME# " & currentMe.ToString("000000") & " already existed.", MsgBoxStyle.Critical) : Return False
        End If
        Return True
    End Function


    Private Function CurrentMRNumber(Optional ByVal num1 As Integer = 0) As String
        Return String.Format("{000000}", If(num1 = 0, currentMr, num1))
    End Function

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
        'cboType.SelectedIndex = 0

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

        ' If Not daltonService(idx).isGenerated And txtRefNum.Text = "" Then txtRefNum.Focus() : Return False
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
        If Not GenerateMeNum() Then : Exit Sub
        End If
        If Not GenerateMrNum() Then : Exit Sub
        End If

        Dim ans As DialogResult = MsgBox("Do you want to post this transaction?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
        If ans = Windows.Forms.DialogResult.No Then Exit Sub
        Dim CashCount_Name As String = ""
        Dim transID As Integer = 0
        Dim idx As Integer = cboType.SelectedIndex
        'If daltonService(idx).isGenerated Then
        '    If rbSend.Checked Then
        '        transID = idME
        '    Else
        '        transID = idMR
        '    End If
        'End If

        If GetActionType(cboType.Text, MTValues.isGenerated) = 1 Then
            If rbSend.Checked Then
                transID = currentMe
            Else
                transID = currentMr
            End If
        End If

        Dim fillData As String = "tblCharge", strType As String = "", strBracket As String
        Dim strAmount As String = txtAmount.Text

        If cboType.Text = "Cebuana Llhuiller" Then
            strType = "cebuana"
        ElseIf cboType.Text = "Pera Padala - PMFTC" Then
            strType = "perapadalapmftc"
        ElseIf cboType.Text = "Pera Padala" Then
            strType = "perapadala"
        ElseIf cboType.Text = "Western Union - Local" Then
            strType = "western"
        ElseIf cboType.Text = "Western Union - Intl" Then
            strType = "western - intl"
        ElseIf cboType.Text = "GPRS - GPRS to Smart Money" Then
            strType = "gprs to smartmoney"
        ElseIf cboType.Text = "GPRS - GPRS to BANK (UCPB/PNB)" Then
            strType = "gprs to bank-ucpbpnb"
        ElseIf cboType.Text = "GPRS - GPRS to BANK (BDO/Chinabank)" Then
            strType = "gprs to bank-bdochina"
        ElseIf cboType.Text = "GPRS - GPRS to BANK (DBP)" Then
            strType = "gprs to dbp"
        ElseIf cboType.Text = "GPRS - GPRS to BANK (MetroBank)" Then
            strType = "gprs to metrobank"
        ElseIf cboType.Text = "GPRS - GPRS to BANK (MetroBank)" Then
            strType = "gprs to metrobank"
        ElseIf cboType.Text = "GPRS - GPRS to BANK (Maybank/LandBank)" Then
            strType = "gprs to maylandbank"
        ElseIf cboType.Text = "GPRS - iREMIT to GPRS" Then
            strType = "iremit to gprs"
        ElseIf cboType.Text = "GPRS - NYBP/Transfast to GPRS" Then
            strType = "nybptransfast to gprs"
        ElseIf cboType.Text = "GPRS - GPRS to Moneygram" Then
            strType = "gprs to moneygram"
        ElseIf cboType.Text = "GPRS - GPRS to GPRS" Then
            strType = "gprs to gprs"
        End If

        Dim ds As DataSet, mySql As String
        mySql = "SELECT AMOUNT FROM tblcharge C "
        mySql &= " WHERE type = '" & strType & "' and '" & strAmount & "' <= C.AMOUNT ORDER BY AMOUNT ASC ROWS 1"
        ds = LoadSQL(mySql, fillData)
        If ds.Tables(fillData).Rows.Count < 1 Then
            strBracket = "0"
        Else
            strBracket = ds.Tables(fillData).Rows(0).Item("AMOUNT")
        End If
        Dim mtTrans As New MoneyTransfer
        With mtTrans
            'Send Money - Branch Received Money (Send In) - 0
            'Receive Money - Branch Payout (Payout) - 1
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
            .Bracket = strBracket
            .Save()
            Select Case cboType.Text
                Case "Pera Padala"
                    MOD_NAME = "PERA PADALA "
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "ME# " & idME, "PADALA IN", , , "PERA PADALA OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.TransferAmount, "Credit", "Pera Padala Fund Payable", "ME# " & idME, , , , "PERA PADALA OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.ServiceCharge, "Credit", "Pera Padala Service Charge", "ME# " & idME, , , , "PERA PADALA OUT", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "OUT"

                        currentMe += 1
                    Else
                        AddJournal(.TransferAmount, "Debit", "Pera Padala Fund Payable", "MR# " & idMR, , , , "PERA PADALA IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "MR# " & idMR, "PADALA OUT", , , "PERA PADALA IN", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "IN"

                        currentMr += 1
                    End If
                Case "Pera Padala - PMFTC"
                    MOD_NAME = "PERA PADALA "
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "ME# " & idME, "PADALA IN", , , "Pera Padala - PMFTC OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.TransferAmount, "Credit", "Pera Padala Fund Payable", "ME# " & idME, , , , "Pera Padala - PMFTC OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.ServiceCharge, "Credit", "Pera Padala Service Charge", "ME# " & idME, , , , "Pera Padala - PMFTC OUT", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "OUT"

                        currentMe += 1
                    Else
                        AddJournal(.TransferAmount, "Debit", "Pera Padala Fund Payable", "MR# " & idMR, , , , "Pera Padala - PMFTC IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "MR# " & idMR, "PADALA OUT", , , "Pera Padala - PMFTC IN", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "IN"

                        currentMr += 1
                    End If
                Case "Western Union - Local", "Western Union - Intl"
                    MOD_NAME = "WESTERN UNION "
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "WE|Ref# " & .ReferenceNumber, "WESTERN IN", , , "WESTERN UNION OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Due to / From Western Union", "WE|Ref# " & .ReferenceNumber, , , , "WESTERN UNION OUT", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "OUT"

                    Else
                        AddJournal(.NetAmount, "Debit", "Due to / From Western Union", "WE|Ref# " & .ReferenceNumber, , , , "WESTERN UNION IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "WE|Ref# " & .ReferenceNumber, "WESTERN OUT", , , "WESTERN UNION IN", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "IN"

                    End If
                Case "Cebuana Llhuiller"
                    MOD_NAME = "PERA LINK "
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "CL|Ref# " & .ReferenceNumber, "CEBUANA IN", , , "Cebuana Llhuiller OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Due to/from Cebuana Llhuiller", "CL|Ref# " & .ReferenceNumber, , , , "Cebuana Llhuiller OUT", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "OUT"

                    Else
                        AddJournal(.NetAmount, "Debit", "Due to/from Cebuana Llhuiller", "CL|Ref# " & .ReferenceNumber, , , , "Cebuana Llhuiller IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "CL|Ref# " & .ReferenceNumber, "CEBUANA OUT", , , "Cebuana Llhuiller IN", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "IN"

                    End If
                Case "GPRS to GPRS"
                    'GPRS ----------------------------------
                    MOD_NAME = "GPRS "
                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "G2G|Ref# " & .ReferenceNumber, "GPRS-GPRS", , , "GPRS - GPRS to GPRS OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "G2G|Ref# " & .ReferenceNumber, , , , "GPRS - GPRS to GPRS OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount - commission, "Credit", "GPRS Remittance/ Bills Payment Fund", "G2G|Ref# " & .ReferenceNumber, , , , "GPRS - GPRS to GPRS OUT", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "OUT"

                    Else
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "G2G|Ref# " & .ReferenceNumber, "GPRS-GPRS", , , "GPRS - GPRS to GPRS IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "G2G|Ref# " & .ReferenceNumber, , , , "GPRS - GPRS to GPRS IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount + commission, "Debit", "GPRS Remittance/ Bills Payment Fund", "G2G|Ref# " & .ReferenceNumber, , , , "GPRS - GPRS to GPRS IN", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "IN"

                    End If
                Case "GPRS to Smart Money", "GPRS to BANK (UCPB/PNB)", "GPRS to BANK (BDO/Chinabank)", _
                    "GPRS to BANK (DBP)", "GPRS to BANK (MetroBank)", "GPRS to BANK (Maybank/LandBank)", _
                    "iREMIT to GPRS", "NYBP/Transfast to GPRS", "GPRS to Moneygram"
                    MOD_NAME = "GPRS "
                    Select Case cboType.Text
                        Case "GPRS to Smart Money"
                            CashCount_Name = "GPRS - GPRS to Smart Money"

                        Case "GPRS to BANK (UCPB/PNB)"
                            CashCount_Name = "GPRS - GPRS to BANK (UCPB/PNB)"

                        Case "GPRS to BANK (BDO/Chinabank)"
                            CashCount_Name = "GPRS - GPRS to BANK (BDO/Chinabank)"

                        Case "GPRS to BANK (DBP)"
                            CashCount_Name = "GPRS - GPRS to BANK (DBP)"

                        Case "GPRS to BANK (MetroBank)"
                            CashCount_Name = "GPRS - GPRS to BANK (MetroBank)"

                        Case "GPRS to BANK (Maybank/LandBank)"
                            CashCount_Name = "GPRS - GPRS to BANK (Maybank/LandBank)"

                        Case "iREMIT to GPRS"
                            CashCount_Name = "GPRS - iREMIT to GPRS"

                        Case "NYBP/Transfast to GPRS"
                            CashCount_Name = "GPRS - NYBP/Transfast to GPRS"

                        Case "GPRS to Moneygram"
                            CashCount_Name = "GPRS - GPRS to Moneygram"

                    End Select

                    If rbSend.Checked Then
                        AddJournal(.NetAmount, "Debit", "Revolving Fund", "GPRS|Ref# " & .ReferenceNumber, CashCount_Name, , , CashCount_Name & " OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "GPRS|Ref# " & .ReferenceNumber, , , , CashCount_Name & " OUT", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount - commission, "Credit", "GPRS Remittance/ Bills Payment Fund", "GPRS|Ref# " & .ReferenceNumber, , , , CashCount_Name & " OUT", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "OUT"

                    Else
                        AddJournal(.NetAmount + commission, "Debit", "GPRS Remittance/ Bills Payment Fund", "GPRS|Ref# " & .ReferenceNumber, , , , CashCount_Name & " IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(.NetAmount, "Credit", "Revolving Fund", "GPRS|Ref# " & .ReferenceNumber, CashCount_Name, , , CashCount_Name & " IN", .LoadLastIDNumberMoneyTransfer)
                        AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "GPRS|Ref# " & .ReferenceNumber, , , , CashCount_Name & " IN", .LoadLastIDNumberMoneyTransfer)
                        MOD_NAME &= "IN"

                    End If
                    ' ISSUE: 0001
                    ' GPRS - Smartmoney To GPRS, wrong Journal Entries
                Case "Smartmoney To GPRS", "Moneygram to GPRS"
                    ' Amt 4000 | 3995 gprsRemitFund debit = 3980 rf credit + 15 income credit
                    MOD_NAME = "GPRS OUT"
                    Select Case cboType.Text
                        Case "Smartmoney To GPRS"
                            CashCount_Name = "GPRS - Smartmoney To GPRS"
                        Case "Moneygram to GPRS"
                            CashCount_Name = "GPRS - Moneygram to GPRS"
                    End Select

                    AddJournal(.NetAmount + commission, "Debit" _
                               , "GPRS Remittance/ Bills Payment Fund", "GPRS_R|Ref# " & .ReferenceNumber, , , , CashCount_Name & " IN", .LoadLastIDNumberMoneyTransfer)
                    AddJournal(.NetAmount, "Credit", "Revolving Fund", "GPRS_R|Ref# " & .ReferenceNumber, CashCount_Name, , , CashCount_Name & " IN", .LoadLastIDNumberMoneyTransfer)
                    AddJournal(commission, "Credit", "Service Income from GPRS Remittance & Bills Payment", "GPRS_R|Ref# " & .ReferenceNumber, , , , CashCount_Name & " IN", .LoadLastIDNumberMoneyTransfer)

                    'AddTimelyLogs(CashCount_Name & " OUT", String.Format("Transfer a total amount of Php{0} to {1}", .NetAmount.ToString("#,##0.00"), cboLocation.Text, .NetAmount), , , , .LoadLastIDNumberMoneyTransfer)
            End Select

            AddTimelyLogs(MOD_NAME, String.Format("Transfer a total amount of Php{0} to {1}", .NetAmount.ToString("#,##0.00"), cboLocation.Text, .NetAmount), , , , .LoadLastIDNumberMoneyTransfer)

        End With

        'If daltonService(idx).isGenerated Then
        '    If rbSend.Checked Then
        '        idME += 1 : daltonService(idx).SetSendLast(idME)
        '    Else
        '        idMR += 1 : daltonService(idx).SetReceivedLast(idMR)
        '    End If
        'End If

        If GetActionType(cboType.Text, MTValues.isGenerated) = 1 Then
            If rbSend.Checked Then
                currentMe += 1
                UpdateOptions("MEnumLast", currentMe)
            Else
                currentMr += 1
                UpdateOptions("MRNumLast", currentMr)
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

        Me.Close()
    End Sub

    Friend Sub LoadSenderInfo(ByVal cus As Customer)
        txtSender.Text = String.Format("{0} {1}", cus.FirstName, cus.LastName)
        txtSenderAddr.Text = String.Format("{0} {1} {2} {3}", cus.PresentStreet, cus.PresentBarangay, cus.PresentCity, cus.PresentProvince)

        For Each id As NewIdentificationCard In cus.CustomersIDs
            If id.isPrimary = True Then
                txtSenderID.Text = id.IDType
                txtSenderIDNum.Text = id.IDNumber
                GoTo NExtLineTODO
            End If
        Next

        For Each id As NewIdentificationCard In cus.CustomersIDs
            txtSenderID.Text = id.IDType
            txtSenderIDNum.Text = id.IDNumber
            GoTo NExtLineTODO
        Next

NExtLineTODO:
        senderClient = cus
        txtReceiver.Focus()
    End Sub

    Friend Sub LoadReceiverInfo(ByVal cus As Customer)
        txtReceiver.Text = String.Format("{0} {1}", cus.FirstName, cus.LastName)
        txtReceiverAddr.Text = String.Format("{0} {1} {2} {3}", cus.PresentStreet, cus.PresentBarangay, cus.PresentCity, cus.PresentProvince)

        For Each id As NewIdentificationCard In cus.CustomersIDs
            If id.isPrimary = True Then
                txtReceiverID.Text = id.IDType
                txtReceiverIDNum.Text = id.IDNumber
                GoTo NExtLineTODO
            End If
        Next

        For Each id As NewIdentificationCard In cus.CustomersIDs
            txtReceiverID.Text = id.IDType
            txtReceiverIDNum.Text = id.IDNumber
            GoTo NExtLineTODO
        Next

NExtLineTODO:
        receiverClient = cus
        txtReceiver.Focus()
    End Sub

    Private Sub btnSearchReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchReceiver.Click
        If rbReceive.Checked Then
            RequirementLevel = 3
        Else
            RequirementLevel = 1
        End If
        Dim secured_str As String = txtReceiver.Text
        secured_str = DreadKnight(secured_str)
        frmClientNew.SearchSelect(secured_str, FormName.frmMTReceive)
        frmClientNew.Show()
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
        'If rbReceive.Checked And Not daltonService(idx).hasPayoutCommission Then Return 0

        Dim fillData As String = "tblCharge"
        Dim ds As DataSet, mySql As String
        mySql = "SELECT * FROM " & fillData & String.Format(" WHERE type = '{0}'", type)
        'If daltonService(idx).hasPayoutCommission Then
        '    mySql &= " AND Remarks LIKE '"
        '    mySql &= IIf(rbSend.Checked, "Send In%'", "Pay Out%'")
        'End If
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
        'ComputeCharges()

        Compute()
        cboLocation.Focus()
    End Sub

    'Private Sub ComputeCharges()
    '    If Not IsNumeric(txtAmount.Text) Then Exit Sub

    '    basicCharges = GetCharge(CDbl(txtAmount.Text), FindServices(cboType.Text).ChargeCode)
    '    txtCharge.Text = basicCharges
    '    ComputeNet()

    '    Console.WriteLine(String.Format("Amount: {0} | ServiceCharge: {1} | Commission: {2}", _
    '                                    txtAmount.Text, basicCharges, commission))
    'End Sub

    'Private Function FindServices(ByVal str As String) As MoneyTransferService
    '    For Each daltonSrv In daltonService
    '        If daltonSrv.ServiceName = str Then Return daltonSrv
    '    Next

    '    Return Nothing
    'End Function

    'Private Sub ComputeNet()
    '    If txtCharge.Text = "" Then Exit Sub
    '    If txtAmount.Text = "" Then Exit Sub

    '    Dim net As Double = CDbl(txtCharge.Text) + CDbl(txtAmount.Text)
    '    ' ISSUE: 0001 02/04/2016
    '    ' Payout Service Charge, auto deduct
    '    If daltonService(cboType.SelectedIndex).ReceiveOnly Then
    '        net = CDbl(txtAmount.Text) - CDbl(txtCharge.Text)
    '    End If
    '    txtNetAmount.Text = net
    'End Sub

    Private Sub Compute()
        If cboType.Text = "" Then Exit Sub
        If txtAmount.Text = "" OrElse txtAmount.Text = 0 Then Exit Sub

        Dim com As New ComputeCharge(cboType.Text, CInt(txtAmount.Text))

        commission = com.Commision
        txtCommission.Text = com.Commision

        'If rbSend.Checked Then
        '    txtNetAmount.Text = com.NetAmount
        '    txtCharge.Text = com.Charge
        'Else
        '    txtNetAmount.Text = com.NetAmount - com.Charge
        'End If

        Select Case GetActionType(cboType.Text, MTValues.ActionType)
            Case "0"
                txtNetAmount.Text = com.NetAmount
                txtCharge.Text = com.Charge
            Case "1"
                txtNetAmount.Text = com.NetAmount - com.Charge
            Case Else
                txtNetAmount.Text = com.NetAmount
                txtCharge.Text = com.Charge
        End Select
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
        'Dim idx As Integer = cboType.SelectedIndex
        Dim st As Boolean = False
        'If cboType.Items.Count <= 0 Then Exit Sub
        'If displayOnly Then Exit Sub

        'If daltonService(idx).isGenerated Then
        '    If rbSend.Checked Then
        '        DisplayNumber(idME)
        '        st = False
        '    Else
        '        DisplayNumber(idMR)
        '        st = True
        '    End If
        'Else
        '    txtTransNum.Text = ""
        '    st = True
        'End If

        'txtRefNum.ReadOnly = Not st
        'ComputeCharges()
        Dim GetActionValue As String = GetActionType(cboType.Text, MTValues.isGenerated)
        If GetActionValue = 1 Then
            If rbSend.Checked Then
                DisplayNumber(currentMe)
                st = False
            Else
                DisplayNumber(currentMr)
                st = True
            End If
        Else
            txtTransNum.Text = ""
            st = True
        End If

        txtRefNum.ReadOnly = Not st
        Compute()
    End Sub

    Private Sub rbSend_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSend.CheckedChanged
        If rbSend.Checked Then lblWhere.Text = "Send To"
        CheckTracking()
    End Sub

    Private Sub rbReceive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbReceive.CheckedChanged
        If rbReceive.Checked Then
            'ComputeNet()
            Compute()
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