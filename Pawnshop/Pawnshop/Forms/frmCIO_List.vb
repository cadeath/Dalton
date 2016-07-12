Public Class frmCIO_List
    Private OTPDisable As Boolean = IIf(GetOption("OTP") = "YES", True, False)

    Dim fillData As String = "tblCashTrans"
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
        Dim mySql As String = "SELECT * FROM " & fillData
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
        Dim mySql As String = "SELECT * FROM " & fillData
        mySql &= String.Format(" WHERE Category LIKE '%{0}%' OR TransName LIKE '%{0}%' OR Remarks LIKE '%{0}%'", txtSearch.Text)
        If IsNumeric(txtSearch.Text) Then mySql &= " OR Amount = " & txtSearch.Text
        mySql &= " ORDER BY TransID DESC"

        Dim ds As DataSet = LoadSQL(mySql)
        lvCIO.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            AddItem(dr)
        Next
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

        If lblCashID.Text = CashID Then
            Transactiontype = lblType.Text

        ElseIf lblCashID.Text = CashID Then
            Transactiontype = lblType.Text
        ElseIf lblCashID.Text = CashID Then
            Transactiontype = lblType.Text
        ElseIf lblCashID.Text = CashID Then
            Transactiontype = lblType.Text
        End If

        ' ISSUE: 0001
        ' Cash InOut exclusive only for the same date.
        If transDate.Date <> CurrentDate.Date Then
            MsgBox("You cannot void transaction in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If
        database.SaveEntry(ds, False)

        RemoveJournal(transID:=CashID, TransType:=Transactiontype)
        RemoveDailyTimeLog(CashID)
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

    Private Function CheckOTP() As Boolean
        diagOTP.Show()
        diagOTP.TopMost = True
        Return False
        Return True
    End Function

    ''' <summary>
    ''' This button void the transaction.
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.VoidCashInOut
            If Not CheckOTP() Then Exit Sub
        Else
            VoidCIO()
        End If
    End Sub

    Friend Sub VoidCIO()
        If lvCIO.SelectedItems.Count <= 0 Then Exit Sub
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
        lblType.Text = tmpCASHTrans.LoadType
    End Sub
End Class