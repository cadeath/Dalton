Public Class frmMTlist
    Private OTPDisable As Boolean = IIf(GetOption("OTP") = "YES", True, False)

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMTlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        LoadActive()
        txtSearch.Focus()

        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub

    Private Sub ClearField()
        txtSearch.Text = ""
        lvMoneyTransfer.Items.Clear()
    End Sub

    Friend Sub LoadActive()
        Dim mySql As String = "SELECT FIRST 50 * FROM tblMoneyTransfer WHERE Status = 'A' ORDER BY TransDate DESC"
        Dim ds As DataSet
        ds = LoadSQL(mySql)

        lvMoneyTransfer.Items.Clear()
        Console.WriteLine("Record Found: " & ds.Tables(0).Rows.Count)
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpMT As New MoneyTransfer
            tmpMT.LoadTransactionByRow(dr)
            AddItem(tmpMT)
        Next
    End Sub

    Private Sub AddItem(ByVal mt As MoneyTransfer)
        Dim TransNum As String = ""
        If mt.ServiceType = "Pera Padala" Then
            If mt.TransactionType = 0 Then
                TransNum = "ME #" & mt.TransactionID
            Else
                TransNum = "MR #" & mt.TransactionID
            End If
        End If

        Dim lv As ListViewItem = lvMoneyTransfer.Items.Add(IIf(mt.TransactionID = 0, "", TransNum))
        lv.SubItems.Add(mt.ReferenceNumber)
        lv.SubItems.Add(mt.TransactionDate)
        lv.SubItems.Add(IIf(mt.TransactionType = 1, "Receive", "Send"))
        lv.SubItems.Add(mt.ServiceType)
        lv.SubItems.Add(String.Format("{0} {1}", mt.Sender.FirstName, mt.Sender.LastName))
        lv.SubItems.Add(String.Format("{0} {1}", mt.Receiver.FirstName, mt.Receiver.LastName))
        lv.SubItems.Add(mt.TransferAmount)
        If mt.Status = "V" Then lv.BackColor = Color.LightGray
        If mt.Status = "I" Then lv.BackColor = Color.Red
        lv.Tag = mt.ID
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If txtSearch.Text = "" Then Exit Sub
        Dim secured_str As String = txtSearch.Text
        secured_str = DreadKnight(secured_str)

        ' to be added more comprehensive searching
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblMoneyTransfer WHERE refNum LIKE '%" & secured_str & "%' OR "
        mySql &= "UPPER(RECEIVERNAME) LIKE UPPER('%" & secured_str & "%') OR UPPER(SENDERNAME) LIKE UPPER('%" & secured_str & "%')"
        ds = LoadSQL(mySql)

        If ds.Tables(0).Rows.Count = 0 Then
            MsgBox("No result found", MsgBoxStyle.Information)
            Exit Sub
        End If

        lvMoneyTransfer.Items.Clear()
        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpMT As New MoneyTransfer
            tmpMT.LoadTransactionByRow(dr)
            AddItem(tmpMT)
        Next

        MsgBox(ds.Tables(0).Rows.Count & " result found.", MsgBoxStyle.Information)
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvMoneyTransfer.SelectedItems.Count = 0 Then Exit Sub

        Dim tmpMT As New MoneyTransfer
        tmpMT.LoadTransaction(lvMoneyTransfer.SelectedItems(0).Tag)
        frmMoneyTransfer.Show()
        frmMoneyTransfer.displayOnly = True
        frmMoneyTransfer.LoadMT(tmpMT)
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        frmMoneyTransfer.Show()
    End Sub

    Private Sub lvMoneyTransfer_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvMoneyTransfer.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Function CheckOTP() As Boolean
        diagOTP.Show()
        diagOTP.TopMost = True
        Return False
        Return True
    End Function

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If Not OTPDisable Then
            diagOTP.FormType = diagOTP.OTPType.VoidMoneyTransfer
            If Not CheckOTP() Then Exit Sub
        Else
            VoidMoneyTransfer()
        End If
    End Sub
    Friend Sub VoidMoneyTransfer()
        If lvMoneyTransfer.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvMoneyTransfer.FocusedItem.Tag
        Dim tmpMT As New MoneyTransfer
        tmpMT.LoadTransaction(idx)

        Console.WriteLine("Today is " & CurrentDate)
        Console.WriteLine("Trans: " & tmpMT.TransactionDate.Date)
        If CurrentDate.Date <> tmpMT.TransactionDate Then
            MsgBox("You cannot void a transaction in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim ans = InputBox("Please indicate reason", "Voiding #" & tmpMT.ReferenceNumber)
        If ans.Length <= 5 Or ans = "" Then
            MsgBox("Please INDICATE reason", MsgBoxStyle.Information)
            Exit Sub
        End If

        tmpMT.VoidTransaction(ans)
        MsgBox(String.Format("Transaction #{0} is now void.", _
                             IIf(tmpMT.ServiceType = "Pera Padala", tmpMT.TransactionID, tmpMT.ReferenceNumber), _
                             MsgBoxStyle.Information, "Transaction Void"))
        LoadActive()
    End Sub
    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub

    Private Sub lvMoneyTransfer_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles lvMoneyTransfer.KeyPress
        If isEnter(e) Then
            If lvMoneyTransfer.SelectedItems.Count = 1 Then
                btnView.PerformClick()
            End If
        End If
    End Sub

    Private Sub lvMoneyTransfer_MouseClick(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles lvMoneyTransfer.MouseClick
        If lvMoneyTransfer.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvMoneyTransfer.FocusedItem.Tag
        Dim tmpMT As New MoneyTransfer
        Dim strMoneyTrans As String
        Label2.Text = idx
        If tmpMT.LoadMoneyTrans = "0" Then
            strMoneyTrans = "OUT"
        ElseIf tmpMT.LoadMoneyTrans = "1" Then
            strMoneyTrans = "IN"
        End If
        lblModname.Text = tmpMT.LoadServiceType + " " + strMoneyTrans
    End Sub
End Class