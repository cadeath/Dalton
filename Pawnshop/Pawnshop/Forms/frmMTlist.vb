Public Class frmMTlist

    Dim daltonService As MoneyTransferService()

    Private Sub Main()
        Dim tmp As New MoneyTransferService
        With tmp
            .Code = "0001"
            .ServiceName = "Pera Padala"
            .isGenerated = True

        End With

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub frmMTlist_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearField()
        LoadActive()
        txtSearch.Focus()
    End Sub

    Private Sub ClearField()
        txtSearch.Text = ""
        lvMoneyTransfer.Items.Clear()
    End Sub

    Friend Sub LoadActive()
        Dim mySql As String = "SELECT * FROM tblMoneyTransfer WHERE Status = 'A' ORDER BY TransDate DESC"
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
        Dim TransNum As String
        If mt.ServiceType = "Pera Padala" Then
            If mt.TransactionType = 0 Then
                TransNum = "ME #" & mt.TransactionID
            Else
                TransNum = "MR #" & mt.TransactionID
            End If
        End If

        Dim lv As ListViewItem = lvMoneyTransfer.Items.Add(IIf(mt.TransactionID = 0, "", mt.TransactionID))
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

        ' to be added more comprehensive searching
        Dim mySql As String, ds As DataSet
        mySql = "SELECT * FROM tblMoneyTransfer WHERE refNum LIKE '%" & txtSearch.Text & "%' "
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

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvMoneyTransfer.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvMoneyTransfer.FocusedItem.Tag
        Dim tmpMT As New MoneyTransfer
        tmpMT.LoadTransaction(idx)

        Console.WriteLine("Today is " & CurrentDate)
        Console.WriteLine("Trans: " & tmpMT.TransactionDate.Date)
        If CurrentDate.Date <> tmpMT.TransactionDate Then MsgBox("You cannot void a transaction in a DIFFERENT date", MsgBoxStyle.Critical) : Exit Sub

        Dim ans = InputBox("Please indicate reason", "Voiding #" & tmpMT.ReferenceNumber)
        If ans.Length <= 5 Or ans = "" Then
            MsgBox("Please INDICATE reason", MsgBoxStyle.Information)
            Exit Sub
        End If

        tmpMT.VoidTransaction(ans)
        MsgBox(String.Format("Transaction #{0} is now void.", tmpMT.ReferenceNumber), MsgBoxStyle.Information, "Transaction Void")
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
End Class