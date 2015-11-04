Public Class frmDollar

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPost_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPost.Click

    End Sub

    Private Function isvalid() As Boolean
        If txtPesoRate.Text = "" Then txtPesoRate.Focus() : Return False
        If cboDenomination.Text = "" Then cboDenomination.Focus() : Return False
        If txtSerial.Text = "" Then txtSerial.Focus() : Return False


        Return True
    End Function
End Class