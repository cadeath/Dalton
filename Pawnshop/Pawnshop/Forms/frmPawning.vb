Public Class frmPawning

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmPawning_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.F1
                Console.WriteLine("New Loan!")
                btnLoan.PerformClick()
            Case Keys.F2
                txtSearch.Focus()
            Case Keys.F4
                Console.WriteLine("Renewal")
            Case Keys.F5
                Console.WriteLine("Redeem")
        End Select
    End Sub

    Private Sub frmPawning_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        MsgBox("Under development")
    End Sub

    Private Sub btnLoan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoan.Click
        frmNewloan.NewLoan()
        frmNewloan.Show()
    End Sub
End Class