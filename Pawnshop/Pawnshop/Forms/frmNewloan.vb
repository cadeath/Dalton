Public Class frmNewloan

    Private Sub ComboBox3_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Karat.SelectedIndexChanged
       
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
        DigitOnly(e)
    End Sub

    Private Sub LoanDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LoanDate.ValueChanged

    End Sub

    Private Sub btnSearchSender_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        frmClient.Show()
    End Sub

    Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        frmLoanlist.Show()
    End Sub

    ''' <summary>
    ''' Identify if the KeyPress is enter
    ''' </summary>
    ''' <param name="e">KeyPressEventArgs</param>
    ''' <returns>Boolean</returns>
    Private Function isEnter(ByVal e As KeyPressEventArgs) As Boolean
        If Asc(e.KeyChar) = 13 Then
            Return True
        End If
        Return False
    End Function

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPawner.KeyPress
        If isEnter(e) Then
            btnSearch.PerformClick()
        End If
    End Sub
    Private Sub txtDesc_KeyPress(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.KeyPress
        'ItemType.Focus()
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

    Private Sub txtGrams_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtGrams.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtGrams_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtGrams.TextChanged

    End Sub

    Private Sub txtAppraisal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAppraisal.TextChanged
        txtTotal.Text = txtAppraisal.Text
        'txtPrincipal.Text = txtAppraisal.Text
    End Sub

    Private Sub txtTotal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTotal.TextChanged

    End Sub

    Private Sub txtPawner_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPawner.KeyPress

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnLess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLess.Click
        lblLess.Visible = True
        txtless.Visible = True
        txtless.ReadOnly = False
        btnLess.Enabled = False
    End Sub

    Private Sub txtless_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtless.KeyPress
        DigitOnly(e)
    End Sub

    Private Sub txtless_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtless.TextChanged

    End Sub

    Private Sub txtDesc_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDesc.TextChanged

    End Sub

    Private Sub txtPrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPrincipal.TextChanged

    End Sub
End Class

