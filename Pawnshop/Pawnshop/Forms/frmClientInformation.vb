Public Class frmClientInformation

    Private Sub frmClientInformation_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ClearFields()
        txtFirstName.Focus()
    End Sub

    Private Sub ClearFields()
        txtFirstName.Text = ""
        txtMiddleName.Text = ""
        txtLastName.Text = ""
        txtSuffix.Text = ""

        txtStreet.Text = ""
        txtBrgy.Text = ""
        txtCity.Text = ""
        txtProvince.Text = ""
        txtZip.Text = ""

        cboGender.DropDownStyle = ComboBoxStyle.DropDownList
        cboGender.Items.Clear()
        cboGender.Items.Add("Male")
        cboGender.Items.Add("Female")
        dtpBday.Value = Now

        txtCP1.Text = ""
        txtCP2.Text = ""
        txtTele.Text = ""
        txtOthers.Text = ""

        cboIDtype.DropDownStyle = ComboBoxStyle.DropDownList
        txtRef.Text = ""
        txtRemarks.Text = ""
        lvID.Items.Clear()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtZip.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtCP1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP1.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtCP2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCP2.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtTele_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTele.KeyPress
        DigitOnly(e)
    End Sub
End Class