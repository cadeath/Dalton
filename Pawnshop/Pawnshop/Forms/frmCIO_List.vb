Public Class frmCIO_List
    'Private OTPDisable As Boolean = IIf(GetOption("OTP") = "YES", True, False)

    Dim fillData As String = "tblCashTrans"
    Dim filldata1 As String = "TBL_DAILYTIMELOG"
    ''' <summary>
    ''' load the clearfield and loadactive method
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCIO_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        LoadActive()

        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub
    ''' <summary>
    ''' clear the textbox and listview data field
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearField()
        txtSearch.Text = ""
        lvCIO.Items.Clear()
    End Sub
    ''' <summary>
    ''' load all transaction in cash in / out
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub LoadActive()
        Dim mySql As String = "SELECT FIRST 50 * FROM " & fillData
        mySql &= " WHERE Status = 1 ORDER BY TransID DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each cio As DataRow In ds.Tables(0).Rows
            AddItem(cio)
        Next
    End Sub
    ''' <summary>
    ''' load the date to the listview.
    ''' </summary>
    ''' <param name="cio"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal cio As DataRow)
        Dim tmpCIO As New CashInOutTransaction
        tmpCIO.LoadCashIObyRow(cio)

        Dim lv As ListViewItem = lvCIO.Items.Add(tmpCIO.TransactionID)
        lv.SubItems.Add(tmpCIO.Type)
        lv.SubItems.Add(tmpCIO.TransactionDate.ToString("MMM d, yyyy"))
        lv.SubItems.Add(tmpCIO.Category)
        lv.SubItems.Add(tmpCIO.Transaction)
        lv.SubItems.Add(tmpCIO.Amount)
        lv.SubItems.Add(tmpCIO.Particulars)
        lv.Tag = tmpCIO.TransactionID
        If tmpCIO.Status = 0 Then lv.BackColor = Color.LightGray

        Console.WriteLine(String.Format("{0}. {1} - {2} {3}", lv.Tag, tmpCIO.TransactionID, tmpCIO.Transaction, tmpCIO.Amount))
    End Sub
    ''' <summary>
    ''' search all data from filldata 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text.Length <= 3 Then
            MsgBox("3 Characters Below Not Allowed.", MsgBoxStyle.Exclamation, "Cash In/Out Search")
        Else
            Dim secured_str As String = txtSearch.Text
            secured_str = DreadKnight(secured_str)

            Dim mySql As String = "SELECT * FROM " & fillData
            mySql &= (" WHERE UPPER(Category) LIKE UPPER('%" & secured_str & "%') OR UPPER(TransName) LIKE UPPER('%" & secured_str & "%') OR UPPER(Remarks) LIKE UPPER('%" & secured_str & "%')")
            If IsNumeric(secured_str) Then mySql &= " OR Amount = " & secured_str
            mySql &= " ORDER BY TransID DESC"

            Dim ds As DataSet = LoadSQL(mySql)
            lvCIO.Items.Clear()
            For Each dr As DataRow In ds.Tables(0).Rows
                AddItem(dr)
            Next

            Console.WriteLine("SQL: " & mySql)
            Dim MaxRow As Integer = ds.Tables(0).Rows.Count
            'lvCIO.Items.Clear()
            If MaxRow <= 0 Then
                Console.WriteLine("No CashIN/CashOut")
                MsgBox("Query not found", MsgBoxStyle.Information)
                txtSearch.SelectAll()
                lvCIO.Items.Clear()
                Exit Sub
            End If
            MsgBox(MaxRow & " result found", MsgBoxStyle.Information, "Search Currency")
        End If
    End Sub
    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="id"></param>
    ''' <remarks></remarks>
    Private Sub VoidID(ByVal id As Integer)
        Dim result As String = MsgBox("Do you to Void this Transaction", MsgBoxStyle.YesNo, "Pawnshop")
        If result = vbNo Then Exit Sub
        Dim mySql As String = String.Format("SELECT * FROM {0} WHERE TransID = {1}", fillData, id)
        Dim ds As DataSet = LoadSQL(mySql, fillData)
        Dim getID As Single = ds.Tables(0).Rows(0).Item("TransID")
        Dim transDate As Date = ds.Tables(0).Rows(0).Item("TRANSDATE")

        ds.Tables(fillData).Rows(0).Item("Status") = 0
        Dim CashID As Integer = lvCIO.FocusedItem.Tag
        Dim Transactiontype As String = ""

        'If lblCashID.Text = CashID Then
        '    Transactiontype = lblType.Text
        'End If
        If lblType.Text = "Receipt Cash Offsetting Account" Then
            Transactiontype = lblType.Text + " " + lblCategory.Text
            If Transactiontype = "Receipt Cash Offsetting Account SALES OF INVENTORIABLES" Then
                Transactiontype = "Receipt Cash Offsetting Account SALES OF INVENTORI"
            ElseIf Transactiontype = "Receipt Cash Offsetting Account Commission from SMART MONEY Cash Out" Then
                Transactiontype = "Receipt Cash Offsetting Account Commission from SM"
            End If
        ElseIf lblType.Text = "Receipt Service Income from GPRS Remittance & Bills Payment" Then
            Transactiontype = "Receipt Service Income from GPRS Remittance & Bill"
        ElseIf lblType.Text = "INVENTORY IN Smart Money Payable - Perfecom" Then
            Transactiontype = "INVENTORY IN"
        ElseIf lblType.Text = "BDO ATM CASHOUT BDO ATM CASHOUT" Then
            Transactiontype = "BDO ATM CASHOUT"
        ElseIf lblType.Text = "Disbursement Smart Money Inventory Offsetting Account" Then
            Transactiontype = "Disbursement Smart Money Inventory Offsetting Acco"
        ElseIf lblType.Text = "Disbursement Repairs & Maintenance-Store & Office Equip." Then
            Transactiontype = "Disbursement Repairs & Maintenance-Store & Office"
        Else
            Transactiontype = lblType.Text
        End If

            Dim strCategory As String
            Select Case lblCategory.Text
                Case "BDO ATM CASHOUT"
                    strCategory = "BDO ATM"
            Case "INVENTORY IN", "AUCTION REDEEM", "Commission from SMART MONEY Cash Out", "FUND REPLENISHMENT", "DEPOSIT OF EXCESS FUND"
                strCategory = "CASH IN/OUT"
            Case "PETTY CASH ", "LAY-AWAY PAYMENTS"
                strCategory = "CASH IN/OUT"
            Case "TICKETING - GPRS", "GPRS LOADING", "GPRS - BILL PAYMENT"
                strCategory = "GPRS"
                Case "SMART MONEY PADALA"
                    strCategory = "SMARTMONEY IN"
            Case "SALES OF INVENTORIABLES"
                strCategory = "SALES OF INV"
            Case "ECPAY - LOAD", "ECPAY - Bills Payment"
                strCategory = "ECPAY"
            Case "SMART MONEY ENCASHMENT-CASHOUT-Dalton"
                strCategory = "SMARTMONEY OUT"
            Case Else
                strCategory = lblCategory.Text
        End Select


            Dim mySql2 As String = "SELECT * FROM " & filldata1 & " WHERE MOD_NAME = '" & strCategory & "' AND TRANSID =" & CashID
            Dim ds2 As DataSet = LoadSQL(mySql2, filldata1)
            Dim SrvTypDailyTimelog As String = ds2.Tables(0).Rows(0).Item("MOD_NAME")

            ' ISSUE: 0001
            ' Cash InOut exclusive only for the same date.
            If transDate.Date <> CurrentDate.Date Then
                MsgBox("You cannot void transaction in a DIFFERENT date", MsgBoxStyle.Critical)
                Exit Sub
            End If
        database.SaveEntry(ds, False)
        Dim tmpCIO As Integer = ds.Tables(0).Rows(0).Item("ENCODERID")

        Dim NewOtp As New ClassOtp("VOID " & lblCategory.Text, diagOTP.txtPIN.Text, "CashIn/OutID# " & id)
        TransactionVoidSave(lblCategory.Text, tmpCIO, POSuser.UserID, "CashIn/OutID# " & id)

            RemoveJournal(CashID, , Transactiontype)
            RemoveDailyTimeLog(CashID, "1", SrvTypDailyTimelog)
            If strCategory = "CASH IN/OUT" Then
            RemoveDailyTimeLog(CashID, "0", SrvTypDailyTimelog)
        ElseIf strCategory = "SALES OF INV" And lblCategory.Text = "LAY-AWAY PAYMENTS" Then
            RemoveDailyTimeLog(CashID, "0", SrvTypDailyTimelog)
        End If
            MsgBox("Transaction Voided", MsgBoxStyle.Information)
    End Sub
    ''' <summary>
    ''' This button perform search the desired data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

    ''' <summary>
    ''' This button void the transaction.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvCIO.SelectedItems.Count <= 0 Then Exit Sub
        'If Not OTPDisable Then
        '    diagOTP.FormType = diagOTP.OTPType.VoidCashInOut
        '    If Not CheckOTP() Then Exit Sub
        'Else
        '    VoidCIO()
        'End If

        OTPVoiding_Initialization()

        If Not OTPDisable Then
            diagGeneralOTP.GeneralOTP = OtpSettings
            diagGeneralOTP.TopMost = True
            diagGeneralOTP.ShowDialog()
            If Not diagGeneralOTP.isValid Then
                Exit Sub
            Else
                VoidCIO()
            End If
        Else
            VoidCIO()
        End If
    End Sub

    Friend Sub VoidCIO()
        Dim idx As Integer = lvCIO.FocusedItem.Tag
        VoidID(idx)
        lvCIO.Items.Clear()
        LoadActive()
    End Sub

    Private Sub lvCIO_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvCIO.MouseClick
        If lvCIO.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvCIO.FocusedItem.Tag
        Dim tmpCASHTrans As New CashInOutTransaction
        lblCashID.Text = idx
        lblCategory.Text = tmpCASHTrans.LoadCategory
        lblType.Text = tmpCASHTrans.LoadType+ " " + tmpCASHTrans.LoadTransname
    End Sub
End Class