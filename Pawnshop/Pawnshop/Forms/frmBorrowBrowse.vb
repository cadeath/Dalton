Public Class frmBorrowBrowse

    Private Sub frmBorrowBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadBorrowings()
    End Sub

    Private Sub ClearFields()
        txtBranch.Text = ""
        txtOut.Text = ""
        txtDate.Text = ""
        txtParticular.Text = ""
        txtUrl.Text = ""

        lvBorrowings.Items.Clear()
    End Sub

    Private Sub LoadBorrowings()
        Dim mySql As String = "SELECT * FROM tblBorrow WHERE Status = 'C' or Status = 'D' ORDER BY TransDate DESC"
        Dim ds As DataSet = LoadSQL(mySql)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim tmpBB As New Borrowings
            tmpBB.LoadBorrowByRow(dr)
            AddItem(tmpBB)
        Next
    End Sub

    Private Sub AddItem(ByVal br As Borrowings)
        Dim lv As ListViewItem = lvBorrowings.Items.Add(br.ReferenceNumber)
        lv.SubItems.Add(br.TransactionDate)
        lv.SubItems.Add(br.BranchCode)
        Dim debcre As String
        If br.Status = "C" Or br.Status = "VC" Then
            debcre = String.Format("({0})", br.Amount)
        Else
            debcre = String.Format("{0}", br.Amount)
        End If
        lv.SubItems.Add(debcre)
        lv.SubItems.Add(br.Remarks)
        lv.Tag = br.BorrowID
        If br.Status.Contains("V") Then lv.BackColor = Color.LightGray
    End Sub

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click
        If lvBorrowings.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvBorrowings.FocusedItem.Tag
        Dim tmpBB As New Borrowings
        tmpBB.LoadBorrow(idx)

        txtBranch.Text = tmpBB.BranchName
        txtDate.Text = tmpBB.TransactionDate
        txtOut.Text = lvBorrowings.SelectedItems(0).SubItems(3).Text
        txtParticular.Text = tmpBB.Remarks
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvBorrowings.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvBorrowings.FocusedItem.Tag
        Dim tmpBB As New Borrowings
        tmpBB.LoadBorrow(idx)
        If CurrentDate.Date <> tmpBB.TransactionDate.Date Then
            MsgBox("You cannot void transaction in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        tmpBB.VoidBorrowings()
        MsgBox("Transaction #" & tmpBB.ReferenceNumber & " Void.")
    End Sub

    Private Sub lvBorrowings_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lvBorrowings.DoubleClick
        btnView.PerformClick()
    End Sub

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        If lvBorrowings.SelectedItems.Count = 0 Then Exit Sub

        Dim idx As Integer = lvBorrowings.FocusedItem.Tag
        Dim tmpBB As New Borrowings
        tmpBB.LoadBorrow(idx)

        Dim brwFile As New Hashtable
        With brwFile
            .Add(0, tmpBB.ReferenceNumber) 'RefNum
            .Add(1, tmpBB.TransactionDate.Date.ToShortDateString) 'TransDate
            .Add(2, tmpBB.BranchCode) 'BranchCode
            .Add(3, tmpBB.Amount) 'Amount
            .Add(4, tmpBB.Remarks) 'Remarks
        End With

        If Not sfdMoneyFile.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Dim fileSave As String = sfdMoneyFile.FileName
        'Generate File
        CreateEsk(fileSave, brwFile)

        MsgBox("Key Generated", MsgBoxStyle.Information)
    End Sub

    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click

    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdEskFile.ShowDialog()
        If ofdEskFile.FileName = Nothing Then Exit Sub
        txtUrl.Text = ofdEskFile.FileName
    End Sub

    Private Sub GroupBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.DoubleClick
        devVerifyESK.Show()
    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub
End Class