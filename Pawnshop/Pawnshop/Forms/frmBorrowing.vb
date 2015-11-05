Public Class frmBorrowing

    Private Sub frmBorrowing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        LoadLastRefNum()
        LoadBranches()
    End Sub

    Private Sub LoadLastRefNum()
        Dim num As Integer = GetOption("BorrowingLastNum")
        txtRef.Text = String.Format("{0:000000}", num)
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

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click
        If Not isValid() Then Exit Sub
        If Not sfdMoneyFile.ShowDialog = Windows.Forms.DialogResult.OK Then Exit Sub


        MsgBox("Saved!", MsgBoxStyle.Information)
    End Sub

    Private Function isValid() As Boolean
        If cboBranch.Text = "" Then cboBranch.Focus() : Return False
        If txtAmount.Text = "" Then txtAmount.Focus() : Return False
        If txtParticulars.Text = "" Then txtParticulars.Focus() : Return False

        Return True
    End Function
End Class