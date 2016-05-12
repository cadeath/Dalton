Public Class frmBorrowing

    Const MOD_NAME As String = "BORROWINGS"

    Private Sub frmBorrowing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadLastRefNum()
        LoadBranches()
    End Sub

    Private Sub LoadLastRefNum()
        Dim num As Integer = GetOption("BorrowingLastNum")
        txtRef.Text = String.Format("{1}{0:000000}", num, BranchCode)
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

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isValid() Then Exit Sub
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

            AddJournal(.Amount, "Credit", "Revolving Fund", "Ref# " & .LastIDNumber & "To " & BranchCode, "BORROW OUT")
            AddJournal(.Amount, "Debit", "Due to/from Branches", "Ref# " & .LastIDNumber & "To " & BranchCode)
        End With

        Dim brwFile As New Hashtable
        With brwFile
            .Add(0, saveBorrow.ReferenceNumber) 'RefNum
            .Add(1, saveBorrow.TransactionDate.Date.ToShortDateString) 'TransDate
            .Add(2, saveBorrow.BranchCode) 'BranchCode
            .Add(3, saveBorrow.Amount) 'Amount
            .Add(4, saveBorrow.Remarks) 'Remarks
        End With

        AddTimelyLogs(MOD_NAME, String.Format("SENT MONEY TO {0} - Php {1:#,##0.00}", saveBorrow.BranchCode, saveBorrow.Amount), saveBorrow.Amount, False)

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

End Class