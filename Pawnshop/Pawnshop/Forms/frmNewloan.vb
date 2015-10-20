Public Class frmNewloan

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboKarat.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmNewloan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
       
       
    End Sub
    Private Sub Expiry_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Expiry.ValueChanged
      
    End Sub

    Private Sub Category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 

    End Sub

    Private Sub ItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboItemType.SelectedIndexChanged
        cboCategory.Items.Clear()
        cboCategory.Text = ""
        If cboItemType.SelectedItem = "JWL" Then
            txtGrams.ReadOnly = False
        Else
            txtGrams.ReadOnly = True
        End If
        'Sub Category
        If cboItemType.SelectedItem = "APP" Then
            cboCategory.Items.Add("CAMERA")
            cboCategory.Items.Add("CARPENTRY TOOLS")
            cboCategory.Items.Add("HOME APP-SMALL")
            cboCategory.Items.Add("LAPTOP")
            cboCategory.Items.Add("NOTEBOOK")

        ElseIf cboItemType.SelectedItem = "BIG" Then
            cboCategory.Items.Add("BIKE")
            cboCategory.Items.Add("HOME APP-BIG")
            cboCategory.Items.Add("MOTORCYCLE")

        ElseIf cboItemType.SelectedItem = "CEL" Then
            cboCategory.Items.Add("CELLPHONE")
            cboCategory.Items.Add("TABLET")

        ElseIf cboItemType.SelectedItem = "JWL" Then
            cboCategory.Items.Add("ANKLET")
            cboCategory.Items.Add("BANGLE")
            cboCategory.Items.Add("BRACELET")
            cboCategory.Items.Add("BROUCH")
            cboCategory.Items.Add("EARRINGS")
            cboCategory.Items.Add("NECKLACE")
            cboCategory.Items.Add("PENDANT")
            cboCategory.Items.Add("RING")
        End If
        'Dates
        LoanDate.Value = Date.Now
        Maturity.Value = Date.Now.AddDays(30)
        If cboItemType.SelectedItem = "CEL" Then
            Expiry.Value = Date.Now.AddDays(30)
            Auction.Value = Date.Now.AddDays(60)
        Else
            Expiry.Value = Date.Now.AddDays(90)
            Auction.Value = Date.Now.AddDays(123)
        End If
    End Sub

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtGrams_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrams.TextChanged
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppraisal.KeyPress
        DigitOnly(e)
        'If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
        'e.Handled = True
        'End If
    End Sub

    Private Sub txtAppraisal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppraisal.TextChanged

    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged
        txtTotal.Text = txtAppraisal.Text
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtPawner.ReadOnly = False
        txtPawndesc.ReadOnly = False
        txtAppraisal.ReadOnly = False
        cboItemType.Enabled = True
        cboCategory.Enabled = True
        btnBrowse.Enabled = False
        btnSave.Enabled = True
        btnNew.Enabled = False
    End Sub
End Class

