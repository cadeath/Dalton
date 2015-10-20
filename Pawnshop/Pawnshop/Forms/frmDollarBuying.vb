Public Class frmDollarBuying

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCustomer.ReadOnly = False
        txtSerial.ReadOnly = False
        txtDeno.ReadOnly = False
        txtRate.ReadOnly = False
        btnSave.Enabled = True
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub txtRate_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtRate.TextChanged

    End Sub
End Class