Public Class frmNewloan

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Karat.SelectedIndexChanged
       
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Me.Close()
    End Sub
    Private Sub Expiry_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Expiry.ValueChanged
      
    End Sub

    Private Sub Category_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) 

    End Sub

    Private Sub ItemType_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemType.SelectedIndexChanged
        Category.Items.Clear()
        Category.Text = ""
        'Enable Grams and Karat
        If ItemType.SelectedItem = "JWL" Then
            txtGrams.ReadOnly = False
            Karat.Enabled = True
        Else
            txtGrams.ReadOnly = True
            Karat.Enabled = False
        End If
        'Sub Category
        If ItemType.SelectedItem = "APP" Then
            Category.Items.Add("CAMERA")
            Category.Items.Add("CARPENTRY TOOLS")
            Category.Items.Add("HOME APP-SMALL")
            Category.Items.Add("LAPTOP")
            Category.Items.Add("NOTEBOOK")

        ElseIf ItemType.SelectedItem = "BIG" Then
            Category.Items.Add("BIKE")
            Category.Items.Add("HOME APP-BIG")
            Category.Items.Add("MOTORCYCLE")

        ElseIf ItemType.SelectedItem = "CEL" Then
            Category.Items.Add("CELLPHONE")
            Category.Items.Add("TABLET")

        ElseIf ItemType.SelectedItem = "JWL" Then
            Category.Items.Add("ANKLET")
            Category.Items.Add("BANGLE")
            Category.Items.Add("BRACELET")
            Category.Items.Add("BROUCH")
            Category.Items.Add("EARRINGS")
            Category.Items.Add("NECKLACE")
            Category.Items.Add("PENDANT")
            Category.Items.Add("RING")
        End If
        'Dates
        LoanDate.Value = Date.Now
        Maturity.Value = Date.Now.AddDays(30)
        If ItemType.SelectedItem = "CEL" Then
            Expiry.Value = Date.Now.AddDays(30)
            Auction.Value = Date.Now.AddDays(60)
        Else
            Expiry.Value = Date.Now.AddDays(90)
            Auction.Value = Date.Now.AddDays(123)
        End If
    End Sub
    Private Sub TextBox2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAppraisal.KeyPress

        If Not Char.IsDigit(e.KeyChar) And Not Char.IsControl(e.KeyChar) Then
            e.Handled = True
        End If
        txtTotal.Text = txtAppraisal.Text
    End Sub

    Private Sub LoanDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoanDate.ValueChanged

    End Sub

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmSearchLoans.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        txtPawner.ReadOnly = False
        txtDesc.ReadOnly = False
        txtAppraisal.ReadOnly = False
        btnSave.Enabled = True
        btnBrowse.Enabled = False
        Category.Enabled = True
        ItemType.Enabled = True
        btnNew.Enabled = False
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
        frmLoanlist.Show()
    End Sub

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPawner.KeyPress
     
    End Sub
    Private Sub txtDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.KeyPress
        ItemType.Focus()
    End Sub

    Private Sub Category_SelectedIndexChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category.SelectedIndexChanged
        If ItemType.SelectedItem = "JWL" Then
            Category.Focus()
        Else
            txtAppraisal.Focus()
        End If
    End Sub

    Private Sub Maturity_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Maturity.ValueChanged

    End Sub
End Class

