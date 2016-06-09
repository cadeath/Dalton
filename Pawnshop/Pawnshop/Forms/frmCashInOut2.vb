Public Class frmCashInOut2

    Dim cashInCat As Hashtable, ciTrans() As Hashtable
    Dim cashOutCat As Hashtable, coTrans() As Hashtable
    Dim selectedType As String = "Receipt"
    Dim LineNum As Integer = 1, CIOtransactions As New CollectionCIO
    Dim isCustomInOut As Boolean = False
    Dim transName As String
    Private MOD_NAME As String = "CASH IN/OUT"

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Function isValid() As Boolean
        If lvDetails.Items.Count <= 0 Then txtAmt.Focus() : Return False

        Return True
    End Function
    ''' <summary>
    ''' click button to Post the transaction that already add in listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isValid() Then Exit Sub
        If MsgBox("Do you want to post the transaction?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then Exit Sub

        For Each cio As CashInOutTransaction In CIOtransactions
            cio.Save()
            Select Case cio.Category
                Case "BDO ATM CASHOUT"
                    MOD_NAME = "BDO ATM"
                Case "TICKETING - WU"
                    MOD_NAME = "TICKETING - WU"
                Case "SALES OF INVENTORIABLES"
                    MOD_NAME = "SALES OF INV"
                Case "SMART MONEY PADALA"
                    MOD_NAME = "SMARTMONEY IN"
                Case "SMART MONEY ENCASHMENT-CASHOUT-Dalton"
                    MOD_NAME = "SMARTMONEY OUT"
                Case "TICKETING - GPRS"
                    MOD_NAME = "GPRS"
                Case Else
                    Select Case True
                        Case cio.Category.StartsWith("ECPAY")
                            MOD_NAME = "ECPAY"
                        Case cio.Category.StartsWith("GPRS")
                            MOD_NAME = "GPRS"
                        Case Else
                            AddTimelyLogs(MOD_NAME, cio.Transaction, cio.Amount, False)
                    End Select
            End Select
            AddTimelyLogs(MOD_NAME, cio.Transaction, cio.Amount)
        Next

        MsgBox("Information Posted", MsgBoxStyle.Information)
        CIOtransactions = New CollectionCIO
        btnCashIn.PerformClick()
        LineNum = 1
    End Sub
    ''' <summary>
    ''' add data to listview
    ''' </summary>
    ''' <param name="cio"></param>
    ''' <remarks></remarks>
    Private Sub AddItem(ByVal cio As CashInOutTransaction)
        Dim lv As ListViewItem = lvDetails.Items.Add(LineNum)
        lv.SubItems.Add(cio.Category)
        lv.SubItems.Add(cio.Transaction)
        lv.SubItems.Add(cio.Amount)
        lv.SubItems.Add(cio.Particulars)

        CIOtransactions.Add(cio)
        LineNum += 1
    End Sub
    ''' <summary>
    ''' load the clearfields, loadtables, cashinsetup method
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub frmCashInOut2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        web_ads.AdsDisplay = webAds
        web_ads.Ads_Initialization()

        ClearFields()
        LoadTables()
        cashInSetup()
    End Sub
    ''' <summary>
    ''' if category change automatically transaction name change
    ''' </summary>
    ''' <param name="ht"></param>
    ''' <remarks></remarks>
    Private Sub UpdateCategory(ByVal ht As Hashtable)
        cboCat.Items.Clear()
        For Each el As DictionaryEntry In ht
            cboCat.Items.Add(el.Value)
        Next
    End Sub
    ''' <summary>
    ''' if transaction detect the category change automacally transaction change
    ''' </summary>
    ''' <param name="ht"></param>
    ''' <remarks></remarks>
    Private Sub UpdateTransaction(ByVal ht As Hashtable)
        cboTrans.Items.Clear()
        For Each el As DictionaryEntry In ht
            cboTrans.Items.Add(el.Value)
        Next
    End Sub
    ''' <summary>
    ''' click button to begin cash in transaction
    ''' if other transaction not post data will be clear
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub cashInSetup() Handles btnCashIn.Click
        On Error Resume Next

        Dim ans As DialogResult
        If selectedType <> "Receipt" Then
            ans = MsgBox("Unsave data will be clear." + vbCr + "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        isCustomInOut = False
        gpTrans.Enabled = True

        cboCat.Items.Clear()
        UpdateCategory(cashInCat)
        cboCat.SelectedIndex = 0

        cboTrans.Items.Clear()
        UpdateTransaction(ciTrans(0))
        cboTrans.SelectedIndex = 0

        lvDetails.Items.Clear()
        CIOtransactions = New CollectionCIO
        selectedType = "Receipt"
        Me.Text = "Cash In [Receipt]"
    End Sub
    ''' <summary>
    ''' This method wil clear the textbox, combobox and listview in this form.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub ClearFields()
        cboCat.Items.Clear()
        cboTrans.Items.Clear()
        txtAmt.Text = ""
        txtParticulars.Text = ""
        lvDetails.Items.Clear()
    End Sub

    Private Sub LoadTables()
        Dim mySql As String, ds As DataSet, fillData As String = "tblCash"

        'Load Categories
        mySql = "SELECT DISTINCT Category FROM " & fillData
        mySql &= String.Format(" WHERE Type = '{0}'", selectedType)
        ds = LoadSQL(mySql, fillData)

        cashInCat = New Hashtable
        Dim cnt As Integer = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            cashInCat.Add(cnt, dr.Item("Category")) : cnt += 1
        Next

        ds.Clear()
        mySql = "SELECT DISTINCT Category FROM " & fillData
        mySql &= " WHERE Type = 'Disbursement'"
        ds = LoadSQL(mySql, fillData)
        cashOutCat = New Hashtable
        cnt = 0
        For Each dr As DataRow In ds.Tables(fillData).Rows
            cashOutCat.Add(cnt, dr.Item("Category")) : cnt += 1
        Next

        'Load Transaction Names
        Dim MaxRow As Integer = 0, tmpType As String = "Receipt"
        cnt = 0
        ReDim ciTrans(cashInCat.Count - 1)
        For Each el As DictionaryEntry In cashInCat
            mySql = "SELECT * FROM " & fillData
            mySql &= String.Format(" WHERE TYPE = '{0}' AND CATEGORY = '{1}'", tmpType, el.Value)
            ds.Clear()
            ds = LoadSQL(mySql, fillData)
            MaxRow = ds.Tables(fillData).Rows.Count - 1
            ciTrans(cnt) = New Hashtable
            For Each dr As DataRow In ds.Tables(fillData).Rows
                ciTrans(cnt).Add(dr.Item("CashID"), dr.Item("TransName"))
            Next
            cnt += 1
        Next

        tmpType = "Disbursement"
        cnt = 0
        ReDim coTrans(cashOutCat.Count - 1)
        For Each el As DictionaryEntry In cashOutCat
            mySql = "SELECT * FROM " & fillData
            mySql &= String.Format(" WHERE TYPE = '{0}' AND CATEGORY = '{1}'", tmpType, el.Value)
            ds.Clear()
            ds = LoadSQL(mySql, fillData)
            MaxRow = ds.Tables(fillData).Rows.Count - 1
            coTrans(cnt) = New Hashtable
            For Each dr As DataRow In ds.Tables(fillData).Rows
                coTrans(cnt).Add(dr.Item("CashID"), dr.Item("TransName"))
            Next
            cnt += 1
        Next

        'Display
        cnt = 0
        For Each el As DictionaryEntry In cashInCat
            Console.WriteLine(el.Value & "=========================")
            For Each y As DictionaryEntry In ciTrans(cnt)
                Console.WriteLine(y.Value)
            Next
            cnt += 1
        Next
        Console.WriteLine("------======================= ===============-----------")
        cnt = 0
        For Each el As DictionaryEntry In cashOutCat
            Console.WriteLine(el.Value & "=========================")
            For Each y As DictionaryEntry In coTrans(cnt)
                Console.WriteLine(y.Value)
            Next
            cnt += 1
        Next
    End Sub
    ''' <summary>
    ''' This combobox display the category and automatically display the transaction in the cboTrans
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub cboCat_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCat.SelectedIndexChanged
        Dim idx As Integer = cboCat.SelectedIndex
        Dim selectHT As New Hashtable

        Select Case selectedType
            Case "Receipt"
                selectHT = ciTrans(idx)
            Case "Disbursement"
                selectHT = coTrans(idx)
        End Select

        UpdateTransaction(selectHT)
        cboTrans.SelectedIndex = 0
    End Sub
    ''' <summary>
    ''' This method will automatically increment after every transaction.
    ''' </summary>
    ''' <remarks></remarks>
    Private Sub Renumber()
        For cnt As Integer = 0 To lvDetails.Items.Count - 1
            lvDetails.Items(cnt).Text = cnt + 1
        Next
    End Sub
    ''' <summary>
    ''' This button perform the cashout of data.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnCashOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCashOut.Click
        On Error Resume Next

        Dim ans As DialogResult
        If selectedType <> "Disbursement" Then
            ans = MsgBox("Unsave data will be clear." + vbCr + "Do you want to continue?", MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2 + MsgBoxStyle.Information)
            If ans = Windows.Forms.DialogResult.No Then Exit Sub
        End If
        isCustomInOut = False
        gpTrans.Enabled = True

        cboCat.Items.Clear()
        UpdateCategory(cashOutCat)
        cboCat.SelectedIndex = 0

        cboTrans.Items.Clear()
        UpdateTransaction(coTrans(0))
        cboTrans.SelectedIndex = 0

        lvDetails.Items.Clear()
        CIOtransactions = New CollectionCIO
        selectedType = "Disbursement"
        Me.Text = "Cash Out [Disbursement]"
    End Sub
    ''' <summary>
    ''' This button remove the item in the listview details.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If lvDetails.SelectedItems.Count <= 0 Then Exit Sub
        Dim idx As Integer = lvDetails.FocusedItem.Index
        lvDetails.Items(idx).Remove()
        CIOtransactions.Remove(idx)
        Renumber()
    End Sub
    ''' <summary>
    ''' This function will create getcashID and select data from tblcash.
    ''' </summary>
    ''' <param name="transname"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function getCashID(ByVal transname As String) As Integer
        Dim mySql As String, ID As Integer = 0
        mySql = "SELECT * FROM tblCash WHERE TRANSNAME = '" & transname & "'"

        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count = 0 Then MsgBox("TRANSNAME not FOUND", MsgBoxStyle.Critical, "CASH") : Return ID

        ID = ds.Tables(0).Rows(0).Item("CASHID")

        Return ID
    End Function
    ''' <summary>
    ''' click button to add the cash in to listview
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Not isValidAdd() Then Exit Sub

        Dim tmpCio As New CashInOutTransaction
        Dim selectHT As New Hashtable
        Dim idx As Integer = cboCat.SelectedIndex
        Dim category As String

        If Not isCustomInOut Then
            Select Case selectedType
                Case "Receipt"
                    selectHT = ciTrans(idx)
                Case "Disbursement"
                    selectHT = coTrans(idx)
            End Select
        Else

        End If

        With tmpCio
            If Not isCustomInOut Then
                .CashID = GetKey(selectHT, cboTrans.Text)
                category = cboCat.Text
                transName = cboTrans.Text
            Else
                Select Case transName
                    Case "Smart Money Payable - Perfecom"
                        .CashID = getCashID(transName)
                        selectedType = "INVENTORY IN"
                    Case "BDO ATM CASHOUT"
                        .CashID = getCashID("Due to/from BDO")
                        selectedType = "BDO ATM CASHOUT"
                End Select

                category = selectedType
            End If

            .TransactionDate = CurrentDate
            .Type = selectedType
            .Category = category
            .Transaction = transName
            .Amount = txtAmt.Text
            .Particulars = txtParticulars.Text
            .EncoderID = UserID
            .Status = True
        End With

        AddItem(tmpCio) : txtAmt.Text = ""
        txtParticulars.Text = "" : txtAmt.Focus()
    End Sub

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
    ''' <summary>
    ''' function that return the focus to txtamt.text if detect no value
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Private Function isValidAdd() As Boolean
        If txtAmt.Text = "" Then txtAmt.Focus() : Return False

        Return True
    End Function

    Private Sub txtAmt_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmt.KeyPress
        DigitOnly(e)
    End Sub
    ''' <summary>
    ''' click button to view the list of all cash in receipt
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmCIO_List.Show()
    End Sub
    ''' <summary>
    ''' click button to change the transaction name to Smart Money Payable - Perfecom
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnInvIn_Click(sender As System.Object, e As System.EventArgs) Handles btnInvIn.Click
        isCustomInOut = True
        transName = "Smart Money Payable - Perfecom"

        gpTrans.Enabled = False
        txtAmt.Focus()

    End Sub
    ''' <summary>
    ''' click button to change the transaction name to BDO ATM Cashout
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnBDOCashOut_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBDOCashOut.Click
        isCustomInOut = True
        transName = "BDO ATM CASHOUT"

        gpTrans.Enabled = False
        txtAmt.Focus()
    End Sub
End Class