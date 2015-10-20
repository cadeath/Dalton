Public Class frmInsurance

    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpDate.ValueChanged
    End Sub

    Private Sub dtpExpiry_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpExpiry.ValueChanged

    End Sub

    Private Sub frmInsurance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        dtpDate.Value = Date.Now
        dtpExpiry.Value = dtpDate.Value.AddDays(120)
    End Sub
    Private Sub txtSender_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHolder.TextChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub GroupBox3_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox3.Enter

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtHolder.ReadOnly = False
        btnNew.Enabled = False
        btnSave.Enabled = True
        btnBrowse.Enabled = False
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click

    End Sub
End Class