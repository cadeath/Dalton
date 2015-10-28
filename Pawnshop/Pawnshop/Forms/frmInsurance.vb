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
        txtAmount.ReadOnly = False
        btnSearch.Enabled = True
    End Sub

    Private Sub btnVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVoid.Click

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.SearchSelect(txtHolder.Text, FormName.frmInsurance)
        frmClient.Show()
    End Sub
    Friend Sub LoadHolder(ByVal cl As Client)
        txtHolder.Text = String.Format("{0} {1} {2}", cl.FirstName, cl.LastName, cl.Suffix)
        txtSenderAddr.Text = String.Format("{0} {1} {2}", cl.AddressSt, cl.AddressBrgy, cl.AddressCity)
        txtBirthdate.Text = cl.Birthday.ToString("MMM dd, yyyy")
    End Sub

    Private Sub txtAmount_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAmount.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim SaveInsurance As New Insurance
        SaveInsurance.COI = txtCoi.Text
        With SaveInsurance
            .TransDate = dtpDate.Value
        End With
    End Sub
End Class