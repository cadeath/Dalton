Public Class frmRedeem

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        txtAppraisal.ReadOnly = False
        Me.Show()
    End Sub

    Private Sub frmRedeem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Receiptdate.Value = Date.Now
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        frmNewloan.Show()

    End Sub
End Class