Public Class frmBorrowing

    Private Sub frmBorrowing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub ClearFields()
        txtRef.Text = ""
        cboBranch.Items.Clear()
        txtAmount.Text = ""
        txtParticulars.Text = ""
    End Sub

    Private Sub LoadBranches()
        Dim mySql As String = "SELECT * FROM tblBranches"
        Dim ds As DataSet = LoadSQL(mySql)
        Dim MaxCount As Integer = ds.Tables(0).Rows.Count

        Dim str(MaxCount - 1) As String
        For cnt As Integer = 0 To MaxCount - 1
            str(cnt) = ds.Tables(0).Rows(cnt).Item("BranchName")
        Next

        cboBranch.Items.AddRange(str)
    End Sub
End Class