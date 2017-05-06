Public Class devMTCharge

    Private Sub devMTCharge_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim mysql As String = "Select * From tblMTCharge"
        Dim ds As DataSet = LoadSQL(mysql, "tblMTCharge")

        For Each dr In ds.Tables(0).Rows
            cboType.Items.Add(dr.item("ChargeName"))
        Next
    End Sub

    Private Sub Compute()
        If cboType.Text = "" Then Exit Sub
        If txtAmount.Text = "" OrElse txtAmount.Text = 0 Then Exit Sub

        Dim com As New ComputeCharge(cboType.Text, CInt(txtAmount.Text))
        txtCharge.Text = com.Charge
        txtCommision.Text = com.Commision
        txtNetAmount.Text = txtAmount.Text - com.Charge
    End Sub

    Private Sub txtAmount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAmount.KeyUp
        Compute()
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub cboType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboType.SelectedIndexChanged
        Compute()
    End Sub
End Class