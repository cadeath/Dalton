Public Class frmBorrowBrowse
  
    Private Sub frmBorrowBrowse_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadBorrowings()

        'Authorization
        With POSuser
            btnVoid.Enabled = .canVoid
        End With
    End Sub
   
    Private Sub ClearFields()
        txtBranch.Text = ""
        txtOut.Text = ""
        txtDate.Text = ""
        txtParticular.Text = ""
        txtUrl.Text = ""

        lvBorrowings.Items.Clear()
    End Sub
    Private Sub LoadBorrowings(Optional ByVal mySql As String = "SELECT * FROM tblBorrow WHERE Status = 'C' or Status = 'D' ORDER BY TransDate DESC")
        Dim ds As DataSet = LoadSQL(mySql)

        lvBorrowings.Items.Clear()
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
        LBLBORROWINGID.Text = idx
        txtBranch.Text = tmpBB.BranchName
        txtDate.Text = tmpBB.TransactionDate
        txtOut.Text = lvBorrowings.SelectedItems(0).SubItems(3).Text
        txtParticular.Text = tmpBB.Remarks
    End Sub
    Public Sub GetBorrowingID()
        If lvBorrowings.SelectedItems.Count = 0 Then Exit Sub
        Dim ID As Integer
        Dim idx As Integer = lvBorrowings.FocusedItem.Tag
        Dim tmpBB As New Borrowings
        tmpBB.LoadBorrow(idx)
        ID = idx
    End Sub
    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click
        If lvBorrowings.SelectedItems.Count = 0 Then Exit Sub
        If MsgBox("Do you want to void this transaction?", MsgBoxStyle.Information + MsgBoxStyle.YesNo + MsgBoxStyle.DefaultButton2, "V O I D") _
            = MsgBoxResult.No Then
            Exit Sub
        End If

        Dim idx As Integer = lvBorrowings.FocusedItem.Tag
        Dim tmpBB As New Borrowings
        tmpBB.LoadBorrow(idx)
        If CurrentDate.Date <> tmpBB.TransactionDate.Date Then
            MsgBox("You cannot void transaction in a DIFFERENT date", MsgBoxStyle.Critical)
            Exit Sub
        End If

        tmpBB.VoidBorrowings()
        MsgBox("Transaction #" & tmpBB.ReferenceNumber & " Void.")
        LoadBorrowings()
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
        Dim ht As New Hashtable
        ht = GetBorrowing(txtUrl.Text)
        If ht Is Nothing Then Exit Sub

        If Not GetIntegrity(ht) Then MsgBox("Invalid for file." & vbCr & "Please generate another key.", MsgBoxStyle.Critical) : Exit Sub
        Dim refNum As String, TransDate As Date, eskBrancCode As String, Amount As Double, Remarks As String
        refNum = ht(0) : TransDate = ht(1) : eskBrancCode = ht(2) : Amount = ht(3) : Remarks = ht(4)

        If eskBrancCode <> BranchCode Then MsgBox("This file is not for this branch", MsgBoxStyle.Critical) : Exit Sub

        'Check Ref Duplication
        Dim mySql As String = "SELECT * FROM tblBorrow WHERE RefNum = '" & refNum & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count > 0 Then
            MsgBox("Transaction already uploaded", MsgBoxStyle.Critical)
            Exit Sub
        End If

        Dim tmpBB As New Borrowings
        With tmpBB
            .ReferenceNumber = refNum
            .TransactionDate = TransDate
            .BranchCode = eskBrancCode
            .BranchName = GetBranchName(BranchCode)
            .Amount = Amount
            .Remarks = Remarks
            .Status = "D"
            .EncoderID = UserID

            .SaveBorrowings()

            AddJournal(.Amount, "Debit", "Revolving Fund", "To " & BranchCode, "BORROW IN")
            AddJournal(.Amount, "Credit", "Due to/from Branches", "To " & BranchCode)
        End With

        MsgBox("Borrowings Posted", MsgBoxStyle.Information)
        ClearFields()
        LoadBorrowings()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        ofdEskFile.ShowDialog()
        If ofdEskFile.FileName = Nothing Then Exit Sub
        txtUrl.Text = ofdEskFile.FileName
    End Sub
    Private Sub GroupBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox1.DoubleClick
        devVerifyESK.Show()
    End Sub

    Private Function GetBorrowing(ByVal url As String) As Hashtable
        If System.IO.File.Exists(txtUrl.Text) = False Then Return Nothing

        Dim fs As New System.IO.FileStream(txtUrl.Text, IO.FileMode.Open)
        Dim bf As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()

        Dim hashTable As New Hashtable
        Try
            hashTable = bf.Deserialize(fs)
        Catch ex As Exception
            Console.WriteLine("It seems the file is being tampered.")
            fs.Close()
            Return Nothing
        End Try
        fs.Close()

        Dim isValid As Boolean = False
        If hashTable(5) = _
            security.HashString( _
                hashTable(0) & hashTable(1) & _
                hashTable(2) & hashTable(3) & _
                hashTable(4)) Then
            isValid = True
        Else
            isValid = False
        End If

        If isValid Then Return hashTable
        Return Nothing
    End Function

    Private Function GetIntegrity(ByVal hx As Hashtable) As Boolean
        Dim xStr As String = security.HashString(hx(0) & hx(1) & hx(2) & hx(3) & hx(4))
        If hx(5) = xStr Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Function GetBranchName(ByVal branchCode As String) As String
        Dim mySql As String = "SELECT * FROM tblBranches WHERE SAPCODE = '" & branchCode & "'"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("branchName")
    End Function

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim mySql As String = "SELECT * FROM tblBorrow WHERE "
        mySql &= String.Format("UPPER(REFNUM) LIKE '%{0}%' ", txtSearch.Text)
        If IsNumeric(txtSearch.Text) Then mySql &= String.Format("OR AMOUNT = {0} ", txtSearch.Text)
        mySql &= "ORDER BY TransDate DESC"

        LoadBorrowings(mySql)
        If lvBorrowings.Items.Count = 0 Then
            MsgBox("No result found.", MsgBoxStyle.Critical)
        Else
            MsgBox(String.Format("{0} result found", lvBorrowings.Items.Count))
        End If
    End Sub

    Private Sub txtSearch_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSearch.KeyPress
        If isEnter(e) Then btnSearch.PerformClick()
    End Sub

End Class