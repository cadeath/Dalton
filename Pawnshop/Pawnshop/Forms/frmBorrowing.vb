Public Class frmBorrowing

    Const MOD_NAME As String = "BORROWINGS"
    Dim currentBornum As Integer = GetOption("BorrowingLastNum")
    Dim branchcode As String = GetOption("BranchCode")
    Dim newborrow = String.Format("{1}{0:000000}", currentBornum, BranchCode)

    Private Sub frmBorrowing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.TopMost = True
        frmMain.SettingsToolStripMenuItem.Enabled = False
        ClearFields()
        LoadLastRefNum()
        LoadBranches()
    End Sub

    Private Sub LoadLastRefNum()
        Dim num As Integer = GetOption("BorrowingLastNum")
        txtRef.Text = String.Format("{1}{0:000000}", num, branchcode)
    End Sub

    Private Sub AddRefNum()
        Dim num As Integer = GetOption("BorrowingLastNum")
        num += 1
        UpdateOptions("BorrowingLastNum", num)
    End Sub

    Private Sub ClearFields()
        txtRef.Text = ""
        cboBranch.Items.Clear()
        txtAmount.Text = ""
        txtParticulars.Text = ""
    End Sub

    Private Sub LoadBranches()
        Dim mySql As String = "SELECT * FROM tblBranches WHERE SAPCode <> '" & BranchCode & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxCount As Integer = ds.Tables(0).Rows.Count

        Dim str(MaxCount - 1) As String
        For cnt As Integer = 0 To MaxCount - 1
            str(cnt) = ds.Tables(0).Rows(cnt).Item("BranchName")
        Next
        cboBranch.Items.AddRange(str)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
    End Sub

    Private Function GetBranchCode(ByVal branchName As String) As String
        Dim mySql As String = "SELECT * FROM tblBranches WHERE BranchName = '" & branchName & "'"
        Dim ds As DataSet = LoadSQL(mySql)
        Return ds.Tables(0).Rows(0).Item("SapCode")
    End Function

    Private Function BorrowingNum() As Boolean
        Dim mySql As String, ds As DataSet
        mySql = "SELECT DISTINCT REFNUM FROM tblBORROW "
        mySql &= "WHERE REFNUM = '" & newborrow & "'"
        ds = LoadSQL(mySql)
        If ds.Tables(0).Rows.Count >= 1 Then : MsgBox("Borrowing# " & newborrow & " already existed.", MsgBoxStyle.Critical) : Return False
        End If
        Return True
    End Function

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isValid() Then Exit Sub

        If Not BorrowingNum() Then : Exit Sub
        End If

        If Not sfdMoneyFile.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub
        Dim fileSave As String = sfdMoneyFile.FileName
        Dim saveBorrow As New Borrowings
        With saveBorrow
            .ReferenceNumber = txtRef.Text
            .TransactionDate = CurrentDate
            .BranchCode = GetBranchCode(cboBranch.Text)
            .BranchName = cboBranch.Text
            .Amount = txtAmount.Text
            .Remarks = txtParticulars.Text
            .Status = "C" 'Credit
            .EncoderID = UserID

            .SaveBorrowings()
            AddRefNum()

            AddJournal(.Amount, "Credit", "Revolving Fund", "Ref# " & .LastIDNumber & " To " & branchcode, "BORROW OUT", , , "BORROWINGS", .LastIDNumber)
            AddJournal(.Amount, "Debit", "Due to/from Branches", "Ref# " & .LastIDNumber & " To " & branchcode, , , , "BORROWINGS", .LastIDNumber)
            AddTimelyLogs(MOD_NAME, String.Format("SENT MONEY TO {0} - Php {1:#,##0.00}", saveBorrow.BranchCode, saveBorrow.Amount), saveBorrow.Amount, False, , .LastIDNumber)

        End With

        Dim brwFile As New Hashtable
        With brwFile
            .Add(0, saveBorrow.ReferenceNumber) 'RefNum
            .Add(1, saveBorrow.TransactionDate.Date.ToShortDateString) 'TransDate
            .Add(2, saveBorrow.BranchCode) 'BranchCode
            .Add(3, saveBorrow.Amount) 'Amount
            .Add(4, saveBorrow.Remarks) 'Remarks

        End With

       
        'Generate File
        CreateEsk(fileSave, brwFile)
        MsgBox("Saved!", MsgBoxStyle.Information)
        Me.Close()
    End Sub

  Private Function isValid() As Boolean
        If cboBranch.Text = "" Then cboBranch.Focus() : Return False
        If txtAmount.Text = "" Then txtAmount.Focus() : Return False
        If txtParticulars.Text = "" Then txtParticulars.Focus() : Return False
        Return True
    End Function
   Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmBorrowBrowse.Show()
    End Sub

    Private Sub btnBrowseOldEsk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseOldEsk.Click
        ofdEskFile.ShowDialog()
        If ofdEskFile.FileName = Nothing Then Exit Sub
        txtUrl.Text = ofdEskFile.FileName
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
    Private Function GetBranchName(ByVal branchCode As String) As String
        Dim mySql As String = "SELECT * FROM tblBranches WHERE SAPCODE = '" & branchCode & "'"
        Dim ds As DataSet = LoadSQL(mySql)

        Return ds.Tables(0).Rows(0).Item("branchName")
    End Function
    Private Function GetIntegrity(ByVal hx As Hashtable) As Boolean
        Dim xStr As String = security.HashString(hx(0) & hx(1) & hx(2) & hx(3) & hx(4))
        If hx(5) = xStr Then
            Return True
        Else
            Return False
        End If
    End Function
    Private Sub btnUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpload.Click
        Dim ht As New Hashtable
        ht = GetBorrowing(txtUrl.Text)
        If ht Is Nothing Then Exit Sub

        If Not GetIntegrity(ht) Then MsgBox("Invalid for file." & vbCr & "Please generate another key.", MsgBoxStyle.Critical) : Exit Sub
        Dim refNum As String, TransDate As Date, eskBrancCode As String, Amount As Double, Remarks As String
        refNum = ht(0) : TransDate = ht(1) : eskBrancCode = ht(2) : Amount = ht(3) : Remarks = ht(4)

        If eskBrancCode <> branchcode Then MsgBox("This file is not for this branch", MsgBoxStyle.Critical) : Exit Sub

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
            .BranchName = GetBranchName(branchcode)
            .Amount = Amount
            .Remarks = Remarks
            .Status = "D"
            .EncoderID = UserID

            .SaveBorrowings()

            AddJournal(.Amount, "Debit", "Revolving Fund", "To " & branchcode, "BORROW IN", , , "BORROW IN", .LastIDNumber)
            AddJournal(.Amount, "Credit", "Due to/from Branches", "To " & branchcode, , , , "BORROW IN", .LastIDNumber)
        End With

        MsgBox("Borrowings Posted", MsgBoxStyle.Information)
    End Sub

    Private Sub btnBrowse2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse2.Click
        frmBorrowBrowse.Show()
    End Sub

    Private Sub frmBorrowing_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        frmMain.SettingsToolStripMenuItem.Enabled = True
    End Sub
End Class