Public Class frmCustomer

    Private Sub frmCustomer_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        ClearFields()
    End Sub

    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As System.Object, e As System.EventArgs) Handles btnSave.Click

    End Sub

    Private Sub ClearFields()
        txtFName.Text = ""
        txtMName.Text = ""
        txtLName.Text = ""

        'BASIC 
        txtSt1.Text = ""
        cboBrgy1.Text = ""
        cboCity1.Text = ""
        cboProv1.Text = ""
        cboZip1.Text = ""

        txtSt2.Text = ""
        cboBrgy2.Text = ""
        cboCity2.Text = ""
        cboProv2.Text = ""
        cboZip2.Text = ""

        dtpBday.Value = Now
        txtBdayPlace.Text = ""
        txtNationality.Text = ""
        cboGender.Text = "Female"
        txtSrcFund.Text = ""

        cboPhone.Items.Clear()
        rbLow.Checked = True

        'IDENTIFY
        cboType.SelectedIndex = 0
        txtIDNum.Text = ""
        lvID.Items.Clear()

    End Sub

    Private Sub btnPlus_Click(sender As System.Object, e As System.EventArgs) Handles btnPlus.Click
        
    End Sub
End Class
